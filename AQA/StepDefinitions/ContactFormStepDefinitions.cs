using AQA.Drivers;
using AQA.PageObjects;

namespace AQA.StepDefinitions
{
    [Binding]
    public sealed class ContactFormStepDefinitions
    {
        private readonly ContactFormPageObject _contactFormPageObject;

        public ContactFormStepDefinitions(BrowserDriver browserDriver)
        {
            _contactFormPageObject = new ContactFormPageObject(browserDriver.Current);
        }

        [Given("user opens application URL")]
        public void OpenContactURL()
        {
            _contactFormPageObject.OpenURL();
        }

        [When("user enters \"(.+?)\" text into Full Name input")]
        public void WhenEnterFullName(string fullname)
        {
            //delegate to Page Object
            if (fullname == "Null")
            {
                _contactFormPageObject.EnterFullName(string.Empty);
            }
            else
            {
                _contactFormPageObject.EnterFullName(fullname);
            }
        }

        [When("user enters \"(.+?)\" text into Email input")]
        public void WhenEnterEmail(string email)
        {
            if (email == "Null")
            {
                _contactFormPageObject.EnterEmail(string.Empty);
            }
            else
            {
                _contactFormPageObject.EnterEmail(email);
            }
         
        }

        [When("the user clicks on Agree checkbox")]
        public void WhenClickAgree()
        {
            //delegate to Page Object
            _contactFormPageObject.ClickAgree();
        }

        [When("the user clicks on Send button")]
        public void WhenClickSend()
        {
            //delegate to Page Object
            _contactFormPageObject.ClickSend();
        }

        [Then("Email input should contain \"(.*)\" text")]
        public void ThenEmailText(string expectedResult)
        {
            //delegate to Page Object
            var actualResult = _contactFormPageObject.WaitEmailError();

            actualResult.Should().Be(expectedResult);
        } 
        
        [Then("Full Name input should contain \"(.*)\" text")]
        public void ThenFullNameText(string expectedResult)
        {
            //delegate to Page Object
            var actualResult = _contactFormPageObject.WaitFullNameError();

            actualResult.Should().Be(expectedResult);
        }

        [Then("Contact form should contain \"(.*)\" text")]
        public void ThenFormText(string expectedResult)
        {
            //delegate to Page Object
            var actualResult = _contactFormPageObject.WaitContactFormError();

            actualResult.Should().Be(expectedResult);
        }
    }
}