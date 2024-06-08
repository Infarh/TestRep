using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Globalization;

var opts = new ChromeOptions();
opts.AddArguments("--headless=new"); 
using var driver = new ChromeDriver(opts);

driver.Navigate().GoToUrl("https://scrapingclub.com/exercise/list_infinite_scroll/");

// var html = driver.PageSource;
// Console.WriteLine(html);

driver
    .FindElements(By.CssSelector(".post"))
    .Select(e => new 
    { 
        Name = e.FindElement(By.CssSelector("h4")).Text, 
        Price = decimal.Parse(e.FindElement(By.CssSelector("h5")).Text.TrimStart('$'), CultureInfo.InvariantCulture)
    })
    .ToList()
    .ForEach(Console.WriteLine);

driver.Quit();


Console.WriteLine("End.");