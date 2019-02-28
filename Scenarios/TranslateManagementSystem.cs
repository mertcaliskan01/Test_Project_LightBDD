using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Translate_Management_System_Test
{
    [Label("FEAT-1")]
    [FeatureDescription(
@"In order to 
As a
I want to ")]
    [TestClass]
    public partial class TranslateManagementSystem
    {
        [Label("SCENARIO-1")]
        [Scenario]
        public void Success_Translator_Login()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               and => user_see_the_login_page_fully_loaded_and_return_message(),
               when => the_user_write_userInformation_and_click_login("translator@mynextmatch.com", "Mert123?.com"),
               then => user_name_should_be_returned());
        }

        [Label("SCENARIO-2")]
        [Scenario]
        public void Success_Moderator_Login()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               and => user_see_the_login_page_fully_loaded_and_return_message(),
               when => the_user_write_userInformation_and_click_login("moderator@mynextmatch.com", "Mert123?.com"),
               then => user_name_should_be_returned());
        }

        [Label("SCENARIO-3")]
        [Scenario]
        public void TryLogin_With_Wrong_Email()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               and => user_see_the_login_page_fully_loaded_and_return_message(),
               when => the_user_write_userInformation_and_click_login("wrong@mynextmatch.com", "Mert123?.com"),
               then => view_error_message());
        }

        [Label("SCENARIO-4")]
        [Scenario]
        public void TryLogin_With_Wrong_Password()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               and => user_see_the_login_page_fully_loaded_and_return_message(),
               when => the_user_write_userInformation_and_click_login("moderator@mynextmatch.com", "treM321?.moc"),
               then => view_error_message());
        }

        [Label("SCENARIO-5")]
        [Scenario]
        public void Success_Translator_Logout()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               and => user_see_the_login_page_fully_loaded_and_return_message(),
               and => the_user_write_userInformation_and_click_login("moderator@mynextmatch.com", "Mert123?.com"),
               when => the_user_click_logout_button(),
               then => user_see_the_login_page_fully_loaded_and_return_message());
        }

        [Label("SCENARIO-6")]
        [Scenario]
        public void Success_Moderator_Approve_sentence()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               given => the_user_write_userInformation_and_click_login("moderator@mynextmatch.com", "Mert123?.com"),
               and => the_user_navigate_to_search_page(),
               and => the_user_enter_turkish_that_word_and_save("Welcome", "Hoşgeldiniz"),
               when => the_user_approve_new_word(),
               then => written_word_should_be_returned("Welcome", "Hoşgeldiniz")
               );
        }

        [Label("SCENARIO-7")]
        [Scenario]
        public void Success_Moderator_Disapprove_Sentence()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               given => the_user_write_userInformation_and_click_login("moderator@mynextmatch.com", "Mert123?.com"),
               and => the_user_navigate_to_search_page(),
               and => the_user_enter_turkish_that_word_and_save("Welcome", "AAAAA"),
               when => the_user_disapprove_new_word(),
               then => the_word_written_by_the_user_should_not_be_changed("Welcome", "AAAAA")
               );
        }

        [Label("SCENARIO-8")]
        [Scenario]
        public void Success_Translator_Cancel_Saving_Sentence()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               given => the_user_write_userInformation_and_click_login("translator@mynextmatch.com", "Mert123?.com"),
               and => the_user_navigate_to_search_page(),
               when => the_user_enter_turkish_that_word_and_cancel("Welcome", "Hoşgeldiniz"),
               then => the_word_written_by_the_user_should_not_be_changed("Welcome", "Hoşgeldiniz")
               );
        }

        [Label("SCENARIO-9")]
        [Scenario]
        public void Success_Translator_Save_Sentence()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               given => the_user_write_userInformation_and_click_login("translator@mynextmatch.com", "Mert123?.com"),
               and => the_user_navigate_to_search_page(),
               and => the_user_enter_turkish_that_word_and_save("Welcome", "Hoşgeldiniz"),
               then => the_word_is_waiting_to_be_approved_in_the_edited_part()
               );
        }

        [Label("SCENARIO-10")]
        [Scenario]
        public void Success_Moderator_Approve_Edited_Sentence()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               given => the_user_write_userInformation_and_click_login("moderator@mynextmatch.com", "Mert123?.com"),
               and => the_user_navigate_to_search_page(),
               and => the_user_enter_turkish_that_word_and_save("Welcome", "Hoşgeldiniz"),
               when => the_user_approve_new_word(),
               then => written_word_should_be_returned("Welcome", "Hoşgeldiniz")
               );
        }

        [Label("SCENARIO-11")]
        [Scenario]
        public void Success_Moderator_Cancel_Approving_Sentence()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               given => the_user_write_userInformation_and_click_login("moderator@mynextmatch.com", "Mert123?.com"),
               and => the_user_navigate_to_search_page(),
               and => the_user_enter_turkish_that_word_and_save("Welcome", "Hoşgeldiniz"),
               when => the_user_cancel_approve_new_word(),
               then => the_word_is_waiting_to_be_approved_in_the_edited_part()
               );
        }

        [Label("SCENARIO-11")]
        [Scenario]
        public void Success_Tanslator_Edit_Approved_Sentence()
        {
            Runner.RunScenario(
               given => the_user_is_navigate_to_login_page(),
               given => the_user_write_userInformation_and_click_login("translator@mynextmatch.com", "Mert123?.com"),
               and => the_user_navigate_to_search_page(),
               when => the_user_just_write_turkish_this_word("Welcome", "AAAAA"),
               then => the_word_written_by_the_user_should_not_be_changed("Welcome", "AAAAA"));
        }
    }
}