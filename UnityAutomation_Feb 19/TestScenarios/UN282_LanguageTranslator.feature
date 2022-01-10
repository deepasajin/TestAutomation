Feature: UN282_LanguageTranslator
Feature is to chnage the Unity language to local language 

@Completed
Scenario: TC001_MainWindow_MenuOption_LanguageTranslation
Given Launch the Unity Application
Then in Unity main window click on 'Translation' submenu from 'Tools' main menu
Then in Translation window verify 'Current' language is 'English'
Then in Translation window verify 'Default' language is 'English'
Then in Translation window select the new language as 'French'
Then in Translation window click 'Ok' button
Then in Unity main window verify menu option is in 'French'
Then in Unity main window click on 'Translation' submenu from 'Tools' main menu
Then in Translation window select the new language as 'English'

@Completed
Scenario: TC001_ExistingFile_MenuOption_LanguageTranslation
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'End Customer' tab
Then in End Customer tab enter value 'Test' in the field 'LastName'
Then in End Customer tab enter value 'Medical' in the field 'FirstName'
Then in Search window click on 'Search' button
Then in End Customer tab click on 'Medical' value in search result table
Then in Search window click on 'Ok' button
Then in Unity main window click on 'Translation' submenu from 'Tools' main menu
Then in Translation window select the new language as 'Thai'
Then in Translation window click 'Ok' button
Then in the pop-up window click 'Ok' for the message 'To apply changes please reload this form.'
Then in Unity main window click on 'Reload File' icon in the toolbar
Then in Unity main window verify menu option is in 'Thai'
Then in Unity main window verify tab option is in 'Thai'