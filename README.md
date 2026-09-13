# Ozakboy.PageData

[![nuget](https://img.shields.io/badge/nuget-ozakboy.PageData-blue)](https://www.nuget.org/packages/Ozakboy.PageData/) 
[![github](https://img.shields.io/badge/github-ozakboy.PageData-blue)](https://github.com/ozakboy/ozakboy.PageData)

[English](README.md) | [繁體中文](README_zh-TW.md) 

A lightweight and flexible pagination library for .NET applications. Easily implement pagination functionality in your applications with support for various data sources including Lists, IQueryable, and IEnumerable.

## Features

- Simple and intuitive pagination implementation
- Support for multiple data source types (List<T>, IQueryable<T>, IEnumerable<T>)
- Flexible page size configuration
- Complete paging information
- Data transformation support
- Extension methods for easy integration
- Compatible with Entity Framework Core queries

## Installation

Install via NuGet Package Manager:

```bash
Install-Package Ozakboy.PageData
```

Or via .NET CLI:

```bash
dotnet add package Ozakboy.PageData
```

## Supported Frameworks

- .NET Standard 2.0
- .NET Standard 2.1
- .NET 8.0
- .NET 9.0
- .NET 10.0

The package has no NuGet dependencies on any of them.

Projects on .NET 6.0 or .NET 7.0 keep working through the .NET Standard 2.0 asset, which NuGet picks
automatically — no code changes needed. The dedicated net6.0 and net7.0 targets were removed in 1.2.0
because both frameworks reached end of life. The .NET Standard 2.0 asset also covers
.NET Framework 4.6.1 and later.

## Core Components

### 1. PageInfo
Contains basic pagination information:
- Current page number
- Items per page (Limit)
- Total items count
- Total pages

### 2. VPageData<T>
Generic class that holds:
- Paginated data (List<T>)
- Page information (PageInfo)

### 3. ASearchPageInfo
Abstract base class for search parameters:
- Base page number property
- Default limit (items per page) property

## Usage Examples

### Basic Usage

```csharp
using Ozakboy.PageData;

// With List<T>
var myList = new List<string>() { "item1", "item2", "item3", ... };
var pagedResult = myList.ToPageData(page: 1, limit: 10);

// With IQueryable (e.g., Entity Framework)
var query = dbContext.Users.Where(u => u.IsActive);
var pagedUsers = query.ToPageData(page: 1, limit: 10);

// With IEnumerable
IEnumerable<Product> products = GetProducts();
var pagedProducts = products.ToPageData(page: 1, limit: 10);
```

### With Data Transformation

```csharp
var pagedResult = query.ToPageData(1, 10)
    .Select(user => new UserDto 
    {
        Id = user.Id,
        Name = user.Name
    });
```

### Custom Search Parameters

```csharp
public class UserSearchParams : ASearchPageInfo
{
    public string? SearchName { get; set; }
    public bool? IsActive { get; set; }
}

// Usage
var searchParams = new UserSearchParams 
{
    Page = 1,
    Limit = 10,
    SearchName = "John"
};
```

### Accessing Page Information

```csharp
var result = query.ToPageData(1, 10);

Console.WriteLine($"Current Page: {result.PageInfo.Page}");
Console.WriteLine($"Items Per Page: {result.PageInfo.Limit}");
Console.WriteLine($"Total Items: {result.PageInfo.Total}");
Console.WriteLine($"Total Pages: {result.PageInfo.TotalPage}");
```

## Extension Methods

The library provides several extension methods through `ToPageDataExtensions`:

- `ToPageData<T>(this List<T>, int page, int limit)`
- `ToPageData<T>(this List<T>, int page, int limit, int total)`
- `ToPageData<T>(this IQueryable<T>, int page, int limit)`
- `ToPageData<T>(this IQueryable<T>, int page, int limit, int total)`
- `ToPageData<T>(this IEnumerable<T>, int page, int limit)`
- `ToPageData<T>(this IEnumerable<T>, int page, int limit, int total)`

## License

This project is licensed under the terms specified in the LICENSE file.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Author

- ozakboy

## Support

If you encounter any issues or have questions, please file an issue on the GitHub repository.