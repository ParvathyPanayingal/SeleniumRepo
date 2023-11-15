
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelfExamples;

List<string> drivers = new List<string>();
drivers.Add("Chrome");
//drivers.Add("Edge");

foreach (var d in drivers)
{
    AmazonTests az = new AmazonTests(); //object can be created inside or outside.

    switch (d)
    {
        case "Chrome":
            az.InitializeChromeDriver(); break;
        case "Edge":
            az.InitializeEdgeDriver(); break;

    }

    try
    {
        //az.TitleTest();
        //az.LogoClickTest();
        //Thread.Sleep(3000);
        //az.SearchProductTest();
        //az.ReloadHomePage();
        //az.TodaysDealsTest();
        //az.SignInAccListTest();
        az.SearchAndFilterProductByBrandTest();
        Thread.Sleep(1000);
        az.SortBySelectTest();


    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }
    catch(NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }
    az.Destruct();
}







/*
Console.WriteLine("1.Edge 2.Chrome");
int ch=Convert.ToInt32(Console.ReadLine());
switch (ch)
{
    case 1:
        gHTests.InitializeEdgeDriver();break;
    case 2:
        gHTests.InitializeChromeDriver();break;
}
*/
/*
GHTests gHTests = new();

List<string> drivers = new List<string>();
drivers.Add("Chrome");
drivers.Add("Edge");

foreach (var d in drivers)
{
    switch (d)
    {
        case "Chrome":
            gHTests.InitializeChromeDriver(); break;
        case "Edge":
            gHTests.InitializeEdgeDriver(); break;

    }
    try
    {
        gHTests.TitleTest();
        gHTests.PageSourceandURLTest();
        gHTests.GoogleSearchTest();
        gHTests.GmailLinkTest();
        gHTests.ImagesLinkTest();
        gHTests.LocalizationTest();
        //gHTests.GAppYoutube();

    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }
    gHTests.Destruct();
}*/



