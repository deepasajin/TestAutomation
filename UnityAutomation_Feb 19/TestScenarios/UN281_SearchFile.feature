Feature: UN281_SearchFile
	Search existing file sin Unity using Search File feature 

@completed
Scenario: TC001_MenuOptions_SearchFile_EndCustomer_LastName_FirstName
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'End Customer' tab
Then in End Customer tab enter value 'Chandran' in the field 'LastName'
Then in End Customer tab enter value 'Deepa' in the field 'FirstName'
Then in Search window click on 'Search' button
Then in End Customer tab click on 'Chandran' value in search result table
Then in Search window click on 'Ok' button
Then in the pop-up window click 'Ok' for the message 'The dossier X120000206THA is opened by'
Then in File Management window verify the value in the field 'Last' is 'Chandran'
Then in File Management window verify the value in the field 'First' is 'Deepa'
Then in Unity main window click on 'Release' submenu from 'File' main menu

@completed
Scenario: TC002_Icon_SearchFile_EndCustomer_LicencePlate
#Given Launch the Unity Application
Then in Unity main window click on 'Search' icon in the toolbar
Then in Search window click on 'End Customer' tab
Then in End Customer tab enter value '12345' in the field 'LicencePlate'
Then in Search window click on 'Search' button
Then in End Customer tab click on '12345' value in search result table
Then in Search window click on 'Ok' button
Then in File Management window verify the value in the field 'First' is 'Deepa'
Then in Unity main window click on 'Release' submenu from 'File' main menu

@completed
Scenario: TC003_DatePicker
Given Launch the Unity Application
Then in Unity main window click on 'Search' icon in the toolbar
#Then in Search window click on 'Open' tab
Then in window select date '01/01/2021'

Scenario: TC004_MenuOptions_SearchFile_Country_LastName_FirstName_Country
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'Country' tab
Then in Country tab enter value 'Test' in the field 'LastName'
Then in Country tab enter value 'Country' in the field 'FirstName'
Then in Country tab select value 'Turkey' from the Country dropdown
Then in Search window click on 'Search' button
Then in Country tab click on 'Test Country' value in the column 'Surname and Name' in search result table
Then in Search window click on 'Ok' button
Then in the pop-up window click 'Ok' for the message 'The dossier X120000206THA is opened by'
Then in File Management window verify the value in the field 'Last' is 'Test'
Then in File Management window verify the value in the field 'First' is 'Country'
Then in File Management window verify the value in the field 'Country' is 'Turkey'
Then in Unity main window click on 'Release' submenu from 'File' main menu

@need to verify why File tab is not getting clicked
Scenario: TC005_Icon_SearchFile_File_Code
Given Launch the Unity Application
Then in Unity main window click on 'Search' icon in the toolbar
Then in Search window click on 'File' tab
#Then in File tab click on 'Code' radiobutton
Then in Search window enter the value 'X121000003THA' in the field 'code'
Then in Search window click on 'Search' button
Then in File Management window verify the value in the field 'File' is 'X121000003THA'
Then in Unity main window click on 'Release' submenu from 'File' main menu


@Executed in E1 successfully completed
Scenario: TC006_SearchFile_Claims_Search_ClaimNr_EndCustomer
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'Claims' tab
Then in Claims tab enter the value 'Rojanasiri' in the field 'endcustomerlastname'
Then in Claims tab enter the value 'Aey' in the field 'endcustomerfirstname'
Then in Claims tab enter the value '101' in the field 'Comp'
Then in Claims tab enter the value '7' in the field 'Progressive'
Then in Claims tab enter the value '12' in the field 'Branch'
Then in Search window click on 'Search' button
Then in Claims tab click on 'Rojanasiri Aey' value in the column 'Surname and Name' in search result table
Then in Search window click on 'Ok' button
Then in File Management window click on 'Claims' tab
Then in File Management window verify the value in the field 'Com' is '101'
Then in File Management window verify the value in the field 'Prog' is '7'
Then in File Management window verify the value in the field 'Bran' is '12'
Then in File Management window verify the value in the field 'Last' is 'Rojanasiri'
Then in File Management window verify the value in the field 'First' is 'Aey'
Then in Unity main window click on 'Release' submenu from 'File' main menu

@Execution in DWRemoval failed to identify the claim nr fields both in search window as well as in FileManagement window
Scenario: TC007_SearchFile_Claims_Search_ClaimNr_EndCustomer
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'Claims' tab
Then in Claims tab enter the value 'ambe' in the field 'endcustomerlastname'
Then in Claims tab enter the value 'rash' in the field 'endcustomerfirstname'
Then in Claims tab enter the value '12' in the field 'Comp'
Then in Claims tab enter the value '9' in the field 'Progressive'
Then in Claims tab enter the value '130' in the field 'Branch'
Then in Search window click on 'Search' button
Then in Claims tab click on 'ambe rash' value in the column 'Surname and Name' in search result table
Then in Search window click on 'Ok' button
Then in File Management window click on 'Claims' tab
Then in File Management window verify the value in the field 'Com' is '12'
Then in File Management window verify the value in the field 'Prog' is '9'
Then in File Management window verify the value in the field 'Bran' is '130'
Then in File Management window verify the value in the field 'Last' is 'ambe'
Then in File Management window verify the value in the field 'First' is 'rash'
Then in Unity main window click on 'Release' submenu from 'File' main menu

@Completed
Scenario: TC008_SearchFile_Claims_Search_EndCustomer
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'Claims' tab
Then in Claims tab enter the value 'ambe' in the field 'endcustomerlastname'
Then in Claims tab enter the value 'rash' in the field 'endcustomerfirstname'
Then in Search window click on 'Search' button
Then in Claims tab click on 'ambe rash' value in the column 'Surname and Name' in search result table
Then in Search window click on 'Ok' button
Then in File Management window verify the value in the field 'Last' is 'ambe'
Then in File Management window verify the value in the field 'First' is 'rash'
Then in Unity main window click on 'Release' submenu from 'File' main menu

Scenario: TC009_SearchFile_MenuOptions_Merging_Tabs
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then check if 'Search' window is opened
Then in Search window click on 'End Customer' tab
Then in End Customer tab enter value 'testing' in the field 'LastName'
Then in Search window click on 'Include this tab in merged search' checkbox
Then in Search window click on 'Claims' tab
Then in Claims tab enter the value 'con' in the field 'endcustomerfirstname'
Then in Search window click on 'Include this tab in merged search' checkbox
Then in Search window click on 'Search' button
Then in Claims tab verify if the values in the column 'Surname and Name' contains 'testing con'
Then in Search window click on 'Cancel' button



