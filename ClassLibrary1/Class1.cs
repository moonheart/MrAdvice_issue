using ArxOne.MrAdvice.Advice;

namespace ClassLibrary1;

public class GenericAdvice<TReturn>: Attribute, IMethodAdvice
{
    public void Advise(MethodAdviceContext context)
    {
        if (context.IsTargetMethodAsync)
        {
            context.ReturnValue = Task.FromResult((object)2);
        }
        else
        {
            context.ReturnValue = 2;
        }
    }
}

public class NonGenericAdvice: Attribute, IMethodAdvice
{
    public void Advise(MethodAdviceContext context)
    {
        if (context.IsTargetMethodAsync)
        {
            context.ReturnValue = Task.FromResult((object)2);
        }
        else
        {
            context.ReturnValue = 2;
        }
    }
}

public class MyClass2
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