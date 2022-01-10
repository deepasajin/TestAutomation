Feature: UN233_CreateNewFile
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: TC001_CreateNewFile_MenuBar_SearchByName
Given Launch the Unity Application
Then in Unity main window click on 'File' flyout from 'New' submenu in the main menu 'File'
Then in New File window in Assistance Type tab select the file type 'Medical file'
Then in New File window click 'Next' button
Then in New File window in the header verify if 'AssistType' value is 'Medical file'
Then in New File window click 'Next' button
Then in New File window in End Customer tab enter value 'Chandran' in the field 'LastName' in serach area
Then in New File window in End Customer tab enter value 'Deepa' in the field 'FirstName' in serach area
Then in New File window in End Customer tab click 'Search' button
Then in New File window in End Customer tab verify if value in 'Last' is 'Chandran'
Then in New File window in End Customer tab verify if value in 'First' is 'Deepa'
Then in New File window in End Customer tab select search result row with value 'Chandran'
Then in New File window verify if file 'X120000206 17/11/20' is already avaialble for the end customer

Scenario: TC002_CreateNewFile_MenuBar_EnterEndCustomerDetailsManually
Given Launch the Unity Application
Then in Unity main window click on 'File' flyout from 'New' submenu in the main menu 'File'
Then in New File window in Assistance Type tab select the file type 'Technical file'
Then in New File window click 'Next' button
Then in New File window in the header verify if 'AssistType' value is 'Technical file'
Then in New File window click 'Next' button
Then in New File window in End Customer tab enter value 'test' in the field 'LastName'
Then in New File window in End Customer tab enter value 'test1' in the field 'FirstName'
Then in New File window in End Customer tab enter value 'test2' in the field 'Company'
Then in New File window in End Customer tab enter value 'test3@test.com' in the field 'Email'
Then in New File window in End Customer tab select value 'F' from the 'Gender' dropdown
Then in New File window in End Customer tab enter value 'Ganeshkhind Road' in the field 'Street'
Then in New File window in End Customer tab enter value 'Maharashtra' in the field 'Province'
Then in New File window in End Customer tab enter value 'Narveer Tanaji Wadi' in the field 'Location'
Then in New File window in End Customer tab enter value '9443925656' in the field 'Mobile'
Then in New File window in End Customer tab enter value 'Pune' in the field 'Town'
#Then in the 'Search Address' pop-up window click 'No' for the message 'No matching address found! Do you want to search manually?'
Then in New File window in End Customer tab enter value '411005' in the field 'Zipcode'
Then in New File window in End Customer tab select value 'English' from the 'Language' dropdown
#Then in New File window in End Customer tab select value 'Yemen' from the 'Country' dropdown
##need to confirm if verification of values entered needs to be validated within the same page



Scenario: TC003_CreateNewFile_MenuBar_EndCustomerLocationDetailsByXYButtonClick
Given Launch the Unity Application
Then in Unity main window click on 'File' flyout from 'New' submenu in the main menu 'File'
Then in New File window in Assistance Type tab select the file type 'Medical file'
Then in New File window click 'Next' button
Then in New File window in the header verify if 'AssistType' value is 'Medical file'
Then in New File window click 'Next' button
Then in New File window in End Customer tab click 'XY' button
Then check if 'Retrieve Address' window is opened
#Then in Retrieve Address page click on 'XYformat' radiobutton
Then in Retrieve Address page enter value '73' in the field 'X(degree)'
Then in Retrieve Address page enter value '18.22' in the field 'Y(degree)'
Then in Retrieve Address page click 'Search' button
Then in Retrieve Address page verify if the search result table loaded successfully with data
Then in Retrieve Address page click on 'Kudki Road' value in the column 'Street' in search result table
Then in Retrieve Address page click 'Retrieve' button
#need to verify if NewFile window is displayed at present inorder to verify the autopopulated details since both are in different windows
Then in New File window in End Customer tab verify if value in 'Country' is 'India'
Then in New File window in End Customer tab verify if value in 'Location' is 'Kudki'
Then in New File window in End Customer tab verify if value in 'Town' is 'Raigad'
Then in New File window in End Customer tab verify if value in 'Street' is 'Kudki Road'
Then in New File window in End Customer tab verify if value in 'Province' is 'Maharashtra'
Then in New File window in End Customer tab verify if value in 'Zipcode' is '402403'




