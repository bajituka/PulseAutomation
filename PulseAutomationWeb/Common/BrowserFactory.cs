using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace PulseAutomationWeb.Common
{
    
    public class BrowserFactory
    {

        public static IWebDriver getBrowser(string browserName)
        {
            IWebDriver driver = null;
            var options = new ChromeOptions();

            switch (browserName)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    options.AddArgument("no-sandbox");
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            return driver;
        }
    }
}
