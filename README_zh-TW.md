# Ozakboy.PageData

[![nuget](https://img.shields.io/badge/nuget-ozakboy.PageData-blue)](https://www.nuget.org/packages/Ozakboy.PageData/) 
[![github](https://img.shields.io/badge/github-ozakboy.PageData-blue)](https://github.com/ozakboy/ozakboy.PageData)

[English](README.md) | [�c�餤��](README_zh-TW.md) 

�A�Ω� .NET ���ε{�������q�Ť����禡�w�C�䴩�h�ظ�ƨӷ��]�]�A Lists�BIQueryable �M IEnumerable�^�������\��A���z������P�a�b���ε{������{�����C

## �D�n�S�I

- ²�檽�[��������{
- �䴩�h�ظ�ƨӷ����O�]List<T>�BIQueryable<T>�BIEnumerable<T>�^
- �F���������j�p�t�m
- ���㪺������T
- ����ഫ�䴩
- �X�i��k�K���X
- �ۮe�� Entity Framework Core �d��

## �w�ˤ覡

�z�L NuGet Package Manager �w�ˡG

```bash
Install-Package Ozakboy.PageData
```

�Ψϥ� .NET CLI�G

```bash
dotnet add package Ozakboy.PageData
```

## �䴩���ج[����

- .NET 6.0
- .NET 7.0
- .NET 8.0

## �֤ߤ���

### 1. PageInfo
�]�t�򥻤�����T�G
- ��e���X
- �C�����ؼơ]Limit�^
- �`���ؼ�
- �`����

### 2. VPageData<T>
�x�����O�A�]�t�G
- �����᪺��ơ]List<T>�^
- ������T�]PageInfo�^

### 3. ASearchPageInfo
�j�M�Ѽƪ���H�����G
- �򥻭��X�ݩ�
- �w�]�C��������ݩ�

## �ϥνd��

### �򥻨ϥΤ覡

```csharp
using Ozakboy.PageData;

// �ϥ� List<T>
var myList = new List<string>() { "����1", "����2", "����3", ... };
var pagedResult = myList.ToPageData(page: 1, limit: 10);

// �ϥ� IQueryable�]�Ҧp Entity Framework�^
var query = dbContext.Users.Where(u => u.IsActive);
var pagedUsers = query.ToPageData(page: 1, limit: 10);

// �ϥ� IEnumerable
IEnumerable<Product> products = GetProducts();
var pagedProducts = products.ToPageData(page: 1, limit: 10);
```

### ����ഫ�d��

```csharp
var pagedResult = query.ToPageData(1, 10)
    .Select(user => new UserDto 
    {
        Id = user.Id,
        Name = user.Name
    });
```

### �ۭq�j�M�Ѽ�

```csharp
public class UserSearchParams : ASearchPageInfo
{
    public string? SearchName { get; set; }
    public bool? IsActive { get; set; }
}

// �ϥΤ覡
var searchParams = new UserSearchParams 
{
    Page = 1,
    Limit = 10,
    SearchName = "�i"
};
```

### �s��������T

```csharp
var result = query.ToPageData(1, 10);

Console.WriteLine($"�ثe���ơG{result.PageInfo.Page}");
Console.WriteLine($"�C�����ؼơG{result.PageInfo.Limit}");
Console.WriteLine($"�`���ؼơG{result.PageInfo.Total}");
Console.WriteLine($"�`���ơG{result.PageInfo.TotalPage}");
```

## �X�i��k

���禡�w�q�L `ToPageDataExtensions` ���Ѧh���X�i��k�G

- `ToPageData<T>(this List<T>, int page, int limit)`
- `ToPageData<T>(this List<T>, int page, int limit, int total)`
- `ToPageData<T>(this IQueryable<T>, int page, int limit)`
- `ToPageData<T>(this IQueryable<T>, int page, int limit, int total)`
- `ToPageData<T>(this IEnumerable<T>, int page, int limit)`
- `ToPageData<T>(this IEnumerable<T>, int page, int limit, int total)`

## ���v����

���M�ר̾� LICENSE �ɮפ����w�����ڱ��v�C

## �ѻP�^�m

�w�ﴣ��^�m�I���H�ɴ��� Pull Request�C

## �䴩�P��U

�p�G�z�J�������D�Φ�����ðݡA�Цb GitHub �x�s�w���إ� Issue�C