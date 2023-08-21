using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA.PageObjects
{

    public class ContactFormPageObject
    {
        //The URL of the page to be opened in the browser
        private const string ContactPageUrl = "https://career.usetech.ru/contacts/";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public ContactFormPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Finding elements by XPath
        private IWebElement FullNameInput => _webDriver.FindElement(By.XPath("//*[@placeholder = \"Иванов Иван Иванович\"]"));
        private IWebElement EmailInput => _webDriver.FindElement(By.XPath("//*[@placeholder = \"ivanov@mail.ru\"]"));
        private IWebElement AgreeCheckbox => _webDriver.FindElement(By.XPath("//*[@data-name = \"acceptance-577\"]"));
        private IWebElement ContactFormError => _webDriver.FindElement(By.XPath("//*[@class = \"contacts__form-response\"]"));
        private IWebElement EmailError => _webDriver.FindElement(By.XPath("//*[@data-name = \"your-email\"]"));
        private IWebElement FullNameError => _webDriver.FindElement(By.XPath("//*[@data-name = \"your-name\"]"));
        private IWebElement SendButton => _webDriver.FindElement(By.XPath("//*[@type = \"submit\"]"));

        public void EnterFullName(string fullname)
        {
            //Enter text
            FullNameInput.SendKeys(fullname);
        }

        public void EnterEmail(string email)
        {
            //Enter text
            EmailInput.SendKeys(email);
        }

        public void ClickAgree()
        {
            //Click the Agree checkbox
            AgreeCheckbox.Click();
        }

        public void ClickSend()
        {
            //Click the Send button
            SendButton.Click();
        }

        public void OpenURL()
        {
            //Open URL
            _webDriver.Navigate().GoToUrl(ContactPageUrl);
        }

        public string WaitContactFormError()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => ContactFormError.Text,
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitFullNameError()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => FullNameError.Text,
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitEmailError()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => EmailError.Text,
                result => !string.IsNullOrEmpty(result));
        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });
        }
    }
}