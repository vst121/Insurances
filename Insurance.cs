
using System.Net;

public interface IInsurance
{
    string Name { get; set; }
    double Price { get; set; }
}

public class Insurance1 : IInsurance
{
    public string Name { get; set; }
    public double Price { get; set; }
}


public class Insurance2 : IInsurance
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Text { get; set; }
}

public interface IInsuranceHandler
{
    Type ConcreteType { get; }
    void HandleInsurance(IInsurance ins);
}

public abstract class InsuranceHandlerBase<TConcreteMessage> : IInsuranceHandler where TConcreteMessage : IInsurance
{
    public Type ConcreteType => typeof(TConcreteMessage);
    public void HandleInsurance(IInsurance ins)
    {
        if (ins is not TConcreteMessage concreteins) return;
        Handle(concreteins);
    }
    protected abstract void Handle(TConcreteMessage ins);
}

public class InsuranceHandler1 : InsuranceHandlerBase<Insurance1>
{
    protected override void Handle(Insurance1 ins)
    {
        Console.WriteLine("Handling Insurance1 ...");
        Console.WriteLine($"Name: {ins.Name}");
        Console.WriteLine($"Price: {ins.Price}");
        Console.WriteLine();
    }
}

public class InsuranceHandler2 : InsuranceHandlerBase<Insurance2>
{
    protected override void Handle(Insurance2 ins)
    {
        Console.WriteLine("Handling Insurance2 ...");
        Console.WriteLine($"Name: {ins.Name}");
        Console.WriteLine($"Price: {ins.Price}");
        Console.WriteLine($"Text: {ins.Text}");
        Console.WriteLine();
    }
}

public class InsuranceProcessor
{
    private readonly Dictionary<Type, IInsuranceHandler> _handlers = new();

    public InsuranceProcessor()
    {
    }
    public void AddHandler(IInsuranceHandler handler)
    {
        var concreteInsuranceType = handler.ConcreteType;
        _handlers[concreteInsuranceType] = handler;
    }

    public void ProcessInsurances(List<IInsurance> insList)
    {
        foreach (var ins in insList)
        {
            if (_handlers.TryGetValue(ins.GetType(), out var handler))
            {
                handler.HandleInsurance(ins);
            }
            else
            {
                throw new Exception($"invalid type {ins.GetType()} !");
            }
        }
    }
}

