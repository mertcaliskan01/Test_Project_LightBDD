using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.Threading;
using Translate_Management_System_Test.Pages;

namespace Translate_Management_System_Test
{
    public partial class TranslateManagementSystem : FeatureFixture
    {
        IWebDriver driver = new ChromeDriver(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        private Login_Page loginPage;

        private Web_Front_End_Page web_Front_End_Page;

        public void the_user_is_navigate_to_login_page()
        {
            driver.Navigate().GoToUrl("https://staging-translate.mynextmatch.com/auth/login");
            loginPage = new Login_Page(driver);
        }

        public void the_user_write_userInformation_and_click_login(string email, string Password)
        {
            loginPage.PerformLogin(email, Password);
        }

        public void user_see_the_login_page_fully_loaded_and_return_message()
        {
            loginPage.user_see_the_login_page_fully_loaded();
        }

        public void user_name_should_be_returned()
        {
            loginPage.Succesful_Login_Control();
        }

        public void view_error_message()
        {
            loginPage.Unsuccesful_Login_Control();
        }

        public void the_user_click_logout_button()
        {
            loginPage.PerformLogout_and_control();
        }

        public void the_user_navigate_to_search_page()
        {
            web_Front_End_Page = new Web_Front_End_Page(driver);
            web_Front_End_Page.GoTranslation();
        }

        public void the_user_enter_turkish_that_word_and_save(string searchWord, string word)
        {
            web_Front_End_Page.Search(searchWord, "approved");
            web_Front_End_Page.Change_Translation(word, "Save");
        }

        public void the_user_enter_turkish_that_word_and_cancel(string searchWord, string word)
        {
            web_Front_End_Page.Search(searchWord, "approved");
            web_Front_End_Page.Change_Translation(word, "Cancel");
        }

        public void the_user_just_write_turkish_this_word(string searchWord, string word)
        {
            web_Front_End_Page.Search(searchWord, "approved");
            web_Front_End_Page.Change_Translation(word, "");
        }

        public void the_user_approve_new_word()
        {
            web_Front_End_Page.Search("Welcome", "edited");
            web_Front_End_Page.Approve_or_Disaprove("Yes", "Approve");
        }

        public void the_user_cancel_approve_new_word()
        {
            web_Front_End_Page.Search("Welcome", "edited");
            web_Front_End_Page.Approve_or_Disaprove("Yes", "Cancel");
        }

        public void the_user_disapprove_new_word()
        {
            web_Front_End_Page.Search("Welcome", "edited");
            web_Front_End_Page.Approve_or_Disaprove("No", "Disapprove");
        }

        public void the_word_written_by_the_user_should_not_be_changed(string search_word, string writed_word)
        {
            Thread.Sleep(1000);
            web_Front_End_Page.Search("Welcome", "edited");
            web_Front_End_Page.return_approved_word(search_word, writed_word);
        }

        public void written_word_should_be_returned(string search_word, string writed_word)
        {
            web_Front_End_Page.Search("Welcome", "edited");
            web_Front_End_Page.return_approved_word(search_word, writed_word);
        }

        public void the_word_is_waiting_to_be_approved_in_the_edited_part()
        {
            web_Front_End_Page.Status_edited_control("Welcome");
        }
    }
}