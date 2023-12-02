using Lib;
using Lib.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test
{
    public class CalculatorPageTest
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        public void Teardown()
        {
            driver.Dispose();
        }

        [TestCase("123", "321", "123 + 321 = 444")]
        public void IntAintBSum(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('+');
            Assert.AreEqual(expected, page.PrintResult());
        }

        [TestCase("123", "122", "123 - 122 = 1")]
        public void IntAintBSub(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('-');
            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("-5", "-4", "-5 - -4 = -1")]
        public void NegativeIntAintBSub(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('-');
            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("5", "6", "5 * 6 = 30")]
        public void IntAintBMult(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('*');
            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("33", "3", "33 / 3 = 11")]
        public void IntAintBDivid(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('/');
            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("1 + 0 = 1")]
        public void IncA(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.IncreaseA();

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("0 + 1 = 1")]
        public void IncB(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.IncreaseB();

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("-1 + 0 = -1")]
        public void DecA(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.DecreaseA();

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("0 + -1 = -1")]
        public void DecB(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.DecreaseB();

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("5 / 0 = null")]
        public void DivideByZero(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA("5");
            page.InputValueB("0");
            page.ChooseTheOperation('/');

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("1.5", "1.3", "1.5 + 1.3 = 2.8")]
        public void FloatSum(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);


            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("1.5", "1.3", "1.5 - 1.3 = 0.2")] //Выводит неправильное значение
        public void FloatSub(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('-');

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("-1.5", "1.3", "-1.5 - 1.3 = -2.8")]
        public void FloatSubNegative(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('-');

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("0.3", "2.5", "0.3 * 2.5 = 0.75")]
        public void FloatMult(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('*');

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("0.3", "0.2", "0.3 / 0.2 = 1.5")] //Выводит неправильное значение
        public void FloatDiv(string a, string b, string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA(a);
            page.InputValueB(b);
            page.ChooseTheOperation('/');

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("1.5 + 0 = 1.5")]
        public void InputFloatWithDot(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA("1.5");

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("null + 0 = null")]
        public void InputAFloatWithComma(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA("1,5");

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("0 + null = null")]
        public void InputBFloatWithComma(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueB("1,5");

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("null + 0 = null")]
        public void InputString(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA("Привет Андрей");

            Assert.AreEqual(expected, page.PrintResult());
        }
        [TestCase("null + 0 = null")]
        public void InputSymbols(string expected)
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            SimpleCalculatorPage page = new SimpleCalculatorPage(driver);

            page.InputValueA("@#$%*?");

            Assert.AreEqual(expected, page.PrintResult());
        }
    }
}