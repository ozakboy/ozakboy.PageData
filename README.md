# Ozakboy.PageData

[![nuget](https://img.shields.io/badge/nuget-ozakboy.PageData-blue)](https://www.nuget.org/packages/Ozakboy.PageData/) 
[![github](https://img.shields.io/badge/github-ozakboy.PageData-blue)](https://github.com/ozakboy/ozakboy.PageData)

一個提供資料分頁功能的 .NET 函式庫。

## 功能特色

- 簡單高效的分頁實現
- 支援多種集合類型 (List<T>, IQueryable<T>, IEnumerable<T>)
- 便捷的擴充方法
- 內建分頁資訊追蹤
- 支援多個 .NET 版本

## 安裝方式

透過 NuGet Package Manager 安裝：

```bash
Install-Package Ozakboy.PageData
```

或使用 .NET CLI：

```bash
dotnet add package Ozakboy.PageData
```

## 支援框架

- .NET 6.0
- .NET 7.0
- .NET 8.0

## 核心元件

### 類別

1. `VPageData<T>`
   - 分頁資料的主要容器
   - 同時包含資料內容和分頁資訊
   - 支援泛型型別

2. `PageInfo`
   - 包含分頁的相關資訊
   - 屬性：
     - `Page`：目前頁數
     - `Limit`：每頁顯示數量
     - `Total`：資料總筆數
     - `TotalPage`：總頁數

3. `ASearchPageInfo`（抽象類別）
   - 實作自訂搜尋分頁的基底類別
   - 預設每頁顯示 10 筆資料
   - 最小頁數為 1

### 擴充方法

`ToPageData` 擴充方法支援多種簽章：

```csharp
// 用於 List<T>
List<T>.ToPageData(page, limit)
List<T>.ToPageData(page, limit, total)

// 用於 IQueryable<T>
IQueryable<T>.ToPageData(page, limit)
IQueryable<T>.ToPageData(page, limit, total)

// 用於 IEnumerable<T>
IEnumerable<T>.ToPageData(page, limit)
IEnumerable<T>.ToPageData(page, limit, total)
```

## 使用範例

```csharp
using Ozakboy.PageData;

// List<T> 範例
var myList = new List<string> { "A", "B", "C", "D", "E" };
var pagedResult = myList.ToPageData(page: 1, limit: 2);

// IQueryable 範例
var queryable = dbContext.Users.Where(u => u.IsActive);
var pagedUsers = queryable.ToPageData(page: 1, limit: 10);

// 存取結果
foreach (var item in pagedResult.PageData)
{
    Console.WriteLine(item);
}

// 存取分頁資訊
Console.WriteLine($"目前頁數：{pagedResult.PageInfo.Page}");
Console.WriteLine($"總頁數：{pagedResult.PageInfo.TotalPage}");
Console.WriteLine($"總筆數：{pagedResult.PageInfo.Total}");
```

## 授權條款

本專案採用 LICENSE 檔案中所述之條款授權。

## 貢獻指南

歡迎提交貢獻！請隨時提交 Pull Request。

## 相關連結

- [NuGet 套件](https://www.nuget.org/packages/Ozakboy.PageData/)
- [GitHub 儲存庫](https://github.com/ozakboy/ozakboy.PageData)

## 套件說明

這是一個簡單易用的分頁套件，主要用於處理大量資料的分頁顯示需求。透過簡潔的 API 設計，讓開發者能夠輕鬆實現資料分頁功能，提升應用程式的效能和使用者體驗。