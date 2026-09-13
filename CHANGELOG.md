# Changelog

本檔記錄本套件所有值得注意的變更。
All notable changes to this package are documented here.

格式依循 [Keep a Changelog](https://keepachangelog.com/zh-TW/1.1.0/),版號依循
[語意化版本](https://semver.org/lang/zh-TW/)。
The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/) and the versioning follows
[Semantic Versioning](https://semver.org/).

## [1.2.1] - 2026-09-13

### 問題修正 / Fixed

- `PageInfo(page, limit, total)` 在 `limit` 為 0 時除以零:double 的 Infinity 轉 `int` 是未定義行為,實務上 `TotalPage` 會變成
  `int.MinValue`。現在 `limit` 或 `total` 小於等於 0 時 `TotalPage` 一律為 0。計算式公開為 `PageInfo.CalculateTotalPage(total, limit)`,
  改用整數運算(不經過 double),中間值用 `long` 避免接近 `int.MaxValue` 時溢位。
  `PageInfo(page, limit, total)` divided by zero when `limit` was 0: double Infinity cast to `int` is undefined and yielded
  `int.MinValue`. A `limit` or `total` of zero or less now gives `TotalPage = 0`. The calculation is exposed as
  `PageInfo.CalculateTotalPage(total, limit)` and uses integer arithmetic with a `long` intermediate.

## [1.2.0] - 2026-09-13

換目標框架的版本。公開 API 沒有任何變更,升級不需要改呼叫端程式碼。
A retargeting release. No public API changes, so upgrading needs no caller changes.

### 破壞性變更 / Breaking

- **移除 net6.0 與 net7.0 目標 / Removed the net6.0 and net7.0 targets**:兩者都已在 2024 年結束支援。
  **仍停在 net6.0 / net7.0 的專案請改吃 netstandard2.0 資產** —— 不必改任何程式碼,NuGet 會自動挑,
  因為 net6.0 / net7.0 都相容 .NET Standard 2.0 與 2.1。會受影響的只有把 `lib/net6.0/` 路徑寫死的建置腳本。
  Both reached end of life in 2024. Projects still on net6.0 / net7.0 resolve the netstandard2.0 asset
  instead, automatically and with no code changes; only build scripts that hard-code `lib/net6.0/` need attention.

### 新增功能 / Added

- **目標框架改為 `netstandard2.0;netstandard2.1;net8.0;net9.0;net10.0`**:
  netstandard2.0 讓涵蓋範圍往回延伸到 .NET Framework 4.6.1+,往前補上 net9.0 與 net10.0。
  五個目標框架的相依樹都是空的,套件本身不帶任何 NuGet 相依。
  netstandard2.0 extends reach back to .NET Framework 4.6.1+, and net9.0 / net10.0 extend it forward.
  All five targets ship with an empty dependency graph.

- **補上自動化測試 / An automated test suite**:`tests/ozakboy.PageData.Tests/`,MSTest,
  對 net8.0 與 net10.0 各跑一遍,涵蓋三個公開型別的建構、六個 `ToPageData` 多載的多載解析、
  切頁邊界(最後一頁不滿、超過最後一頁)、`Select` 的型別轉換與分頁資訊保留。這是本套件第一份測試。
  The package's first test suite, running against both net8.0 and net10.0.

### 功能優化 / Changed

- **`VPageData<T>` 的兩個屬性不再可能是 Null / `VPageData<T>` no longer hands back nulls**:
  `PageData` 與 `PageInfo` 改為預設初始化成空集合與空 `PageInfo`。
  只有無參數建構函式受影響 —— 其他建構函式本來就會賦值兩者。
  影響範圍:先前用無參數建構函式建出來、再檢查 `PageData == null` 的程式碼,現在拿到的是空集合而不是 Null,
  會走到「有集合但沒資料」那一條路徑,而那正是空頁本來就該有的語意。
  Only the parameterless constructor is affected; every other constructor already assigned both.
  Code that null-checked `PageData` after using it now sees an empty page instead of null.

### 技術改進 / Changed (internal)

- **移除 `Microsoft.SourceLink.GitHub` 套件參照 / Removed the `Microsoft.SourceLink.GitHub` package reference**:
  .NET 8 起 SourceLink 已內建於 SDK,只要有 `PublishRepositoryUrl` + `EmbedUntrackedSources`,
  產出的 nuspec `repository` 元素與 PDB 來源對映跟外掛套件完全一樣(五個目標框架實測皆同)。
  移除的動機是它的傳遞相依 `Microsoft.Build.Tasks.Git` 帶有弱點公告,而它只在建置期用到、對消費者沒有價值。
  建置期異動,消費者不受影響。
  SourceLink ships in the SDK since .NET 8, so the package only added a vulnerable build-time transitive
  dependency. Build-only change.

- **`DocumentationFile` 不再釘死成單一檔名 / `DocumentationFile` is no longer pinned to one path**:
  原本寫死 `file.xml`,多目標框架下五個 TFM 會搶同一個檔案,打包進去的 XML 註解也只會剩最後一個 TFM 的版本。
  改為只留 `GenerateDocumentationFile`,由 SDK 依 TFM 各自輸出;
  現在 `lib/<tfm>/Ozakboy.PageData.xml` 五份都在,IntelliSense 在每個目標框架上都讀得到註解。
  With five targets the pinned path made them race for one file and packed only the last one;
  each target now ships its own `lib/<tfm>/Ozakboy.PageData.xml`.

- **補齊 XML 註解、修掉錯誤的 `param` 標籤 / XML docs completed and stale `param` tags removed**:
  `VPageData<T>` 有四個建構函式完全沒有註解(CS1591),三個 `ToPageData` 多載掛著不存在的
  `_total` 參數標籤(CS1572),`IQueryable` / `IEnumerable` 的多載則整段複製 `List<T>` 的說明。
  同時把每個多載「會不會自己切頁」寫進 `remarks` —— 這是本套件最容易用錯的地方:
  帶總筆數的多載視資料為**已經切好頁**,不會再切;不帶的才會自己切。
  套件現在在五個目標框架上都是 0 警告建置。
  Four constructors had no docs at all, three overloads carried a `param` tag for a parameter that does
  not exist, and the IQueryable / IEnumerable overloads had the List overload's text copied verbatim.
  Each overload's `remarks` now states whether it slices. The package builds with 0 warnings on all five targets.

- **`PackageReleaseNotes` 改寫成實際內容 / `PackageReleaseNotes` now describes the release**:
  先前不論版本都寫著 "Initial release" 與已經不正確的框架清單。
  It previously said "Initial release" regardless of version, alongside a stale framework list.

- **`README_zh-TW.md` 轉存為 UTF-8 / `README_zh-TW.md` re-encoded as UTF-8**:
  原檔是 Big5,在 GitHub 與多數編輯器上整份顯示為亂碼。內容未改,只換編碼。
  The file was Big5-encoded and rendered as mojibake everywhere; content unchanged, encoding only.

## [1.1.1] - 2024-11-23

本檔建立於 1.2.0,1.1.1 與更早的版本沒有留下變更記錄。
1.1.1 的目標框架為 net6.0 / net7.0 / net8.0。
This changelog starts at 1.2.0; 1.1.1 and earlier have no recorded entries.
1.1.1 targeted net6.0 / net7.0 / net8.0.
