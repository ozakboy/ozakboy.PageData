# Ozakboy.PageData

[![nuget](https://img.shields.io/badge/nuget-ozakboy.PageData-blue)](https://www.nuget.org/packages/Ozakboy.PageData/) 
[![github](https://img.shields.io/badge/github-ozakboy.PageData-blue)](https://github.com/ozakboy/ozakboy.PageData)

[English](README.md) | [繁體中文](README_zh-TW.md) 

適用於 .NET 應用程式的輕量級分頁函式庫。支援多種資料來源（包括 Lists、IQueryable 和 IEnumerable）的分頁功能，讓您能夠輕鬆地在應用程式中實現分頁。

## 主要特點

- 簡單直觀的分頁實現
- 支援多種資料來源型別（List<T>、IQueryable<T>、IEnumerable<T>）
- 靈活的分頁大小配置
- 完整的分頁資訊
- 資料轉換支援
- 擴展方法便於整合
- 相容於 Entity Framework Core 查詢

## 安裝方式

透過 NuGet Package Manager 安裝：

```bash
Install-Package Ozakboy.PageData
```

或使用 .NET CLI：

```bash
dotnet add package Ozakboy.PageData
```

## 支援的框架版本

- .NET 6.0
- .NET 7.0
- .NET 8.0

## 核心元件

### 1. PageInfo
包含基本分頁資訊：
- 當前頁碼
- 每頁項目數（Limit）
- 總項目數
- 總頁數

### 2. VPageData<T>
泛型類別，包含：
- 分頁後的資料（List<T>）
- 分頁資訊（PageInfo）

### 3. ASearchPageInfo
搜尋參數的抽象基類：
- 基本頁碼屬性
- 預設每頁限制數屬性

## 使用範例

### 基本使用方式

```csharp
using Ozakboy.PageData;

// 使用 List<T>
var myList = new List<string>() { "項目1", "項目2", "項目3", ... };
var pagedResult = myList.ToPageData(page: 1, limit: 10);

// 使用 IQueryable（例如 Entity Framework）
var query = dbContext.Users.Where(u => u.IsActive);
var pagedUsers = query.ToPageData(page: 1, limit: 10);

// 使用 IEnumerable
IEnumerable<Product> products = GetProducts();
var pagedProducts = products.ToPageData(page: 1, limit: 10);
```

### 資料轉換範例

```csharp
var pagedResult = query.ToPageData(1, 10)
    .Select(user => new UserDto 
    {
        Id = user.Id,
        Name = user.Name
    });
```

### 自訂搜尋參數

```csharp
public class UserSearchParams : ASearchPageInfo
{
    public string? SearchName { get; set; }
    public bool? IsActive { get; set; }
}

// 使用方式
var searchParams = new UserSearchParams 
{
    Page = 1,
    Limit = 10,
    SearchName = "張"
};
```

### 存取分頁資訊

```csharp
var result = query.ToPageData(1, 10);

Console.WriteLine($"目前頁數：{result.PageInfo.Page}");
Console.WriteLine($"每頁項目數：{result.PageInfo.Limit}");
Console.WriteLine($"總項目數：{result.PageInfo.Total}");
Console.WriteLine($"總頁數：{result.PageInfo.TotalPage}");
```

## 擴展方法

本函式庫通過 `ToPageDataExtensions` 提供多個擴展方法：

- `ToPageData<T>(this List<T>, int page, int limit)`
- `ToPageData<T>(this List<T>, int page, int limit, int total)`
- `ToPageData<T>(this IQueryable<T>, int page, int limit)`
- `ToPageData<T>(this IQueryable<T>, int page, int limit, int total)`
- `ToPageData<T>(this IEnumerable<T>, int page, int limit)`
- `ToPageData<T>(this IEnumerable<T>, int page, int limit, int total)`

## 授權條款

本專案依據 LICENSE 檔案中指定的條款授權。

## 參與貢獻

歡迎提交貢獻！請隨時提交 Pull Request。

## 支援與協助

如果您遇到任何問題或有任何疑問，請在 GitHub 儲存庫中建立 Issue。