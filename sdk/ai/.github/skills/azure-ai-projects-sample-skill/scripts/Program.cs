using System;
using System.Threading.Tasks;

#region Snippet:Sample_FunctionFoo_MySampl_Async
public async Task Foo()
{
    await Task.Delay(1000);
    Console.WriteLine("Hello world!")
}
#endregion