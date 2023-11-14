
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelfExamples;

GHTests gHTests = new ();

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
}


