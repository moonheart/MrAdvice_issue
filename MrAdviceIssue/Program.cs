// See https://aka.ms/new-console-template for more information

using ClassLibrary1;

var myClass1 = new MyClass1();
Console.WriteLine($"await myClass1.Method1() = {await myClass1.Method1()}");
Console.WriteLine($"await myClass1.Method2() = {await myClass1.Method2()}");

var myClass2 = new MyClass2();
Console.WriteLine($"await myClass2.Method1() = {await myClass2.Method1()}");
Console.WriteLine($"await myClass2.Method2() = {await myClass2.Method2()}");

public class MyClass1
{
    [GenericAdvice<List<int>>]
    public async Task<int> Method1()
    {
        await Task.Delay(1);
        return 1;
    }
    
    [NonGenericAdvice]
    public async Task<int> Method2()
    {
        await Task.Delay(1);
        return 1;
    }
}