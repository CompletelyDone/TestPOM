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
        private By incInputA = By.CssSelector("[ng-click=\"inca()\"]");
        private By decInputA = By.CssSelector("[ng-click=\"deca()\"]");
        private By incInputB = By.CssSelector("[ng-click=\"incb()\"]");
        private By decInputB = By.CssSelector("[ng-click=\"decb()\"]");
        private By inputATextBox = By.CssSelector("[ng-model=\"a\"]");
        private By inputBTextBox = By.CssSelector("[ng-model=\"b\"]");
        private By selector = By.CssSelector("operation");
        private By result = By.ClassName("result");

        public void IncreaseA()
        {
            driver.FindElement(this.incInputA).Click();
        }
        public void IncreaseB()
        {
            driver.FindElement(this.incInputB).Click();
        }
        public void DecreaseA()
        {
            driver.FindElement(this.decInputA).Click();
        }
        public void DecreaseB()
        {
            driver.FindElement(this.decInputB).Click();
        }
        public void InputValueA(string value)
        {
            driver.FindElement(this.inputATextBox).Clear();
            driver.FindElement(this.inputATextBox).SendKeys(value);
        }
        public void InputValueB(string value)
        {
            driver.FindElement(this.inputBTextBox).Clear();
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