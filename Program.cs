// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Xml.Linq;

List<IInsurance> insList = new();

Console.WriteLine("Hello, Insurance World!");
Console.WriteLine();

InsuranceProcessor ip = new();

InsuranceHandler1 ih1 = new();
InsuranceHandler2 ih2 = new();

ip.AddHandler(ih1);
ip.AddHandler(ih2);

IInsurance ins1 = new Insurance1() 
{
    Name = "Ins1-Name",
    Price = 10000.11,
};
insList.Add(ins1);

IInsurance ins2 = new Insurance2()
{
    Name = "Ins2-Name",
    Price = 20200.22,
    Text = "Extra Info",
};
insList.Add(ins2);

ip.ProcessInsurances(insList);

Console.ReadLine();

