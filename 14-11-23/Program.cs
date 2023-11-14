
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelfExamples;

GHTests gHTests = new GHTests();
Console.WriteLine("1.Edge 2.Chrome");
int ch=Convert.ToInt32(Console.ReadLine());
switch (ch)
{
    case 1:
        gHTests.InitializeEdgeDriver();break;
    case 2:
        gHTests.InitializeChromeDriver();break;
}
try
{
    gHTests.TitleTest();
    gHTests.PageSourceandURLTest();
    gHTests.GoogleSearchTest();

}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}

gHTests.Destruct();
