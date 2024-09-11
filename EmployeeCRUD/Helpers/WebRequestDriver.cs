using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace EmployeeCRUD.Helpers
{
    public class WebRequestDriver
    {
        private readonly IWebDriver driver;
        public WebRequestDriver()
        {
            driver = new ChromeDriver(@"C:\Users\w111962\source\repos\EmployeeCRUD\EmployeeCRUD\Drivers\chromedriver.exe");
        }
        public void Navigate()
        {
            driver.Navigate().GoToUrl("https://crudcrud.com/");
            Thread.Sleep(3000);
        }    
        
        public string FindApiUniqueId()
        {
            try
            {
                IWebElement apiKeyElement = driver.FindElement(By.XPath("//*[@class='endpoint-url notification is-light is-family-code is-size-7-mobile']"));
                string endpoint = apiKeyElement.Text;

                // Regular expression to fetch the API key(alphanumeric after '/api/')
                string pattern = @"api\/([a-zA-Z0-9]+)$";

                // Use Regex to extract the API key
                Match match = Regex.Match(endpoint, pattern);
                string apiKey;
                if (match.Success)
                {
                    apiKey = match.Groups[1].Value;
                    Console.WriteLine("Extracted API Key: " + apiKey);
                }
                else
                {
                    Console.WriteLine("No API key found in the URL.");
                    apiKey = "KeyNotFound";
                }

                return apiKey;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Could not find the API key element on the page.");
                return ("KeyNotFound");
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }
        
    }
        
}
