using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lib.Pages
{
    public class SimpleCalculatorPage
    {
        private IWebDriver driver;
        private TimeSpan timeout = TimeSpan.FromSeconds(5);

        public SimpleCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            try
            {
                new WebDriverWait(driver, timeout)
                    .Until(drv => drv.FindElement(By.CssSelector("body > h1")).Text == "AngularJS calculator");
            }
            catch
            {
                throw new Exception("Не удалось загрузить страницу SimpleCalculator");
            }
        }

        private By incButtonAElem = By
            .CssSelector("body > div > table > tbody > tr:nth-child(1) > td:nth-child(3) > button:nth-child(1)");
        private By decButtonAElem = By
            .CssSelector("body > div > table > tbody > tr:nth-child(1) > td:nth-child(3) > button:nth-child(2)");
        private By incButtonBElem = By
            .CssSelector("body > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > button:nth-child(1)");
        private By decButtonBElem = By
            .CssSelector("body > div > table > tbody > tr:nth-child(2) > td:nth-child(3) > button:nth-child(2)");
        private By inputATextBox = By.CssSelector("body > div > table > tbody > tr:nth-child(1) > td:nth-child(2) > input");
        private By inputBTextBox = By.CssSelector("body > div > table > tbody > tr:nth-child(2) > td:nth-child(2) > input");
        private By selector = By.CssSelector("operation");
        private By result = By.ClassName("result");

        public void InputValueA(string value)
        {
            driver.FindElement(this.inputATextBox).SendKeys(value);
        }
        public void InputValueB(string value)
        {
            driver.FindElement(this.inputBTextBox).SendKeys(value);
        }
        public void ChooseTheOperation(char c)
        {
            switch (c)
            {
                case '+':
                    driver.FindElement(By.CssSelector("body > div > table > tbody > tr:nth-child(3) > td:nth-child(2) > select > option:nth-child(1)")).Click();
                    break;
                case '-':
                    driver.FindElement(By.CssSelector("body > div > table > tbody > tr:nth-child(3) > td:nth-child(2) > select > option:nth-child(2)")).Click();
                    break; 
                case '*':
                    driver.FindElement(By.CssSelector("body > div > table > tbody > tr:nth-child(3) > td:nth-child(2) > select > option:nth-child(3)")).Click();
                    break;
                case '/':
                    driver.FindElement(By.CssSelector("body > div > table > tbody > tr:nth-child(3) > td:nth-child(2) > select > option:nth-child(4)")).Click();
                    break;
                default:
                    throw new ArgumentException("Wrong char");
            }
        }
        public String PrintResult()
        {
            return driver.FindElement(this.result).Text;
        }
    }
}