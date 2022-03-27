// See https://aka.ms/new-console-template for more information
using Ozakboy.PageData;
Console.WriteLine("Hello, World!");


var Users = new List<User>()
{
    new User() { name = "a1" ,  Age = 10}  ,
    new User() { name = "a2" ,  Age = 11}  ,
    new User() { name = "a3" ,  Age = 12}  ,
    new User() { name = "a4" ,  Age = 13}  ,
    new User() { name = "a5" ,  Age = 14}  ,
    new User() { name = "a6" ,  Age = 15}  ,
    new User() { name = "a7" ,  Age = 16}  ,
    new User() { name = "a8" ,  Age = 17}  ,
    new User() { name = "a9" ,  Age = 18}  ,
    new User() { name = "a10" ,  Age = 19}  ,
    new User() { name = "a11" ,  Age = 20}  ,
    new User() { name = "a12" ,  Age = 21}  ,
    new User() { name = "a13" ,  Age = 22}  ,
    new User() { name = "a14" ,  Age = 23}  ,
};

var UserPageData = Users.ToPageData(1,10);
foreach (var item in UserPageData.PageData)
{
    Console.WriteLine($"name:{item.name} Age:{item.Age}");
}
Console.WriteLine($"==============================");
UserPageData = Users.ToPageData(2, 10);
foreach (var item in UserPageData.PageData)
{
    Console.WriteLine($"name:{item.name} Age:{item.Age}");
}
UserPageData = Users.Where(x=>x.Age > 15).ToPageData(1, 10);
Console.WriteLine($"==============================");
foreach (var item in UserPageData.PageData)
{
    Console.WriteLine($"name:{item.name} Age:{item.Age}");
}


public class User
{
    public string name { get; set; }

    public int Age { get; set; }
}

