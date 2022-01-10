Feature: UN323_Actions
With Action, the further actions to be done during the management of a file. Such actions can be assigned to the file creator itself, as an agenda or to different departments and agents

@mytag
Scenario: TC001_Action_ViewAction_Detail_Verify_Values
Given Launch the Unity Application
Then in Unity main window click on 'Option' submenu from 'Tools' main menu
Then in Options window select radio button 'ShowDefault'
Then in Options window click 'Ok' button
Then in Unity main window click on 'Action' submenu from 'View' main menu
Then in Action Summary window click 'Search' button
Then in Search Action window click the filter option 'Product' and select the drop down value 'ABC Product - 181'
Then in Search Action window click the filter option 'Departments' and select the drop down value 'Back Office - Back Office'
Then in Search Action window click the filter option 'FileType' and select the drop down value 'X1'
Then in Search Action window click 'Ok' button
Then in Action Summary window select row with value 'Chandran Deepa' in 'Name' and value 'test' in 'Department'
Then in Action Summary window click 'Detail' button

Scenario: TC002_Action_CreateAction_StandardAction
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'End Customer' tab
Then in End Customer tab enter value 'test' in the field 'LastName'
Then in End Customer tab enter value 'naradp' in the field 'FirstName'
Then in Search window click on 'Search' button
Then in End Customer tab click on 'test' value in search result table
Then in Search window click on 'Ok' button
Then in Unity main window click on 'Action' flyout from 'New' submenu in the main menu 'File'
Then in New Action window select the drop down value 'Admin Action' in the field 'Standard Action'
Then in New Action window select the value 'Back Office' from Receiver panel
Then in New Action window click 'Finish' button

Scenario: TC003_Action_CreateAction_StandardAction_Edit
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'End Customer' tab
Then in End Customer tab enter value 'test' in the field 'LastName'
Then in End Customer tab enter value 'new' in the field 'FirstName'
Then in Search window click on 'Search' button
Then in End Customer tab click on 'test' value in search result table
Then in Search window click on 'Ok' button
Then in Unity main window click on 'Action' flyout from 'New' submenu in the main menu 'File'
Then in New Action window insert value 'Test Action Defect' in the field 'Standard Action' in the action 'Section1'
Then in New Action window insert value 'High' in the field 'Priority' in the action 'Section1'
Then in New Action window insert value 'Create Action Test Automation section 1' in the field 'Remark' in the action 'Section1'
Then in New Action window insert value 'Back Office' in the field 'Receiver' in the action 'Section1'
Then in New Action window insert value 'Standard Action Test' in the field 'Standard Action' in the action 'Section2'
Then in New Action window insert value 'High' in the field 'Priority' in the action 'Section2'
Then in New Action window insert value 'Create Action Test Automation section 2' in the field 'Remark' in the action 'Section2'
Then in New Action window insert value 'Admin' in the field 'Receiver' in the action 'Section2'
#Then in New Action window enter the value '01/30/2021' in the field 'Deadline'
Then in New Action window click 'Next' button
Then in New Action window insert value 'Action test' in the field 'Standard Action' in the action 'Section1'
Then in New Action window insert value 'ARE Technical' in the field 'Receiver' in the action 'Section1'
Then in New Action window click 'Finish' button
Then in the pop-up window click 'Yes' for the message 'Do you want to save the actions?'
#Then wait for the File Managamenet page to open
Then in File Management window verify if value 'Create Action Test Automation section 1' is added in 'Remarks' field on Actions on files
Then in File Management window verify if value 'Create Action Test Automation section 2' is added in 'Remarks' field on Actions on files
Then in Unity main window click on 'Exit' submenu from 'Tools' main menu
Then in the pop-up window click 'Yes' for the message 'Do you wish to log off?'

@target feb 9 
Scenario: TC004_Action_ActionAgenda_Open_Detail
Given Launch the Unity Application
Then in Unity main window click on 'Option' submenu from 'Tools' main menu
Then check if 'Options' window is opened
Then in Options window select radio button 'Custom show actions'
Then in Options window click on 'Department' checkbox
Then in Options window select value 'Dispatch - Dispatch' from the 'Department' dropdown
Then in Options window click 'Ok' button
Then in Unity main window click on 'Action' submenu from 'View' main menu
Then check if 'Actions of department Dispatch' window is opened
Then in Action Summary window verify all the actions listed are of Department 'Dispatch'
Then in Action Summary window select row with value 'X119000094THA' in 'FileNumber' and value 'Test Test' in 'Name'
Then in Action Summary window click 'Detail' button
Then check if 'Action details' window is opened
Then in Action Details window verify if the value is 'X119000094THA' in the field 'File'
Then in Action Details window verify if the value is 'Test Test' in the field 'End Customer'
Then in Action Details window verify if the value is 'Volkswagen Emergency Assistance' in the field 'Product'
Then in Action Details window verify if the value is 'Dispatch' in the field 'Department'
Then in Action Details window verify if the value is 'Thailand' in the field 'Country'
Then in Action Details window verify if the value is '5/16/2019' in the field 'Deadline'
Then in Action Details window verify if the value is '3:32:00 PM' in the field 'Time'
Then in Action Details window verify if the value is 'ExpenditureID : K519000141 - Hexalite not able to dispatch the job to provider due to prover rejection. Please dispatch manually' in the field 'Action description'
Then in Action Details window click 'Close' button
Then in Action Summary window click 'Open' button
#Then check if Product alert window is displayed
Then check if 'Unity 2.0 - Build 2020.2.0 - [File management]' window is opened
Then in File Management window verify the value in the field 'File' is 'X119000094THA'
Then in File Management window verify if value 'ExpenditureID : K519000141 - Hexalite not able to dispatch the job to provider due to prover rejection. Please dispatch manually' is added in 'Remarks' field on Actions on files
Then in Unity main window click on 'Release' submenu from 'File' main menu

Scenario: TC005_Action_AgendaSettings_Tools_Options
Given Launch the Unity Application
Then in Unity main window click on 'Option' submenu from 'Tools' main menu
Then check if 'Options' window is opened
Then in Options window select radio button 'Custom show actions'
Then in Options window click on 'Operator' checkbox
Then in Options window select value 'asamala - ajay samala' from the 'Operator' dropdown
Then in Options window click 'Ok' button
Then in Unity main window click on 'Action' submenu from 'View' main menu
Then check if 'Actions of department Admin for asamala' window is opened
Then in Action Summary window verify all the actions listed are of 'operator' 'Asamala'
Then in Action Summary window click 'Close list' button
Then in Unity main window click on 'Option' submenu from 'Tools' main menu
Then check if 'Options' window is opened
Then in Options window select radio button 'Show today actions'
Then in Options window click 'Ok' button
Then in Unity main window click on 'Action' submenu from 'View' main menu
#Then check if Actions on today's date window is opened
Then in Action Summary window verify all the actions listed as per current date in format 'dd/MM/yyyy'
Then in Action Summary window click 'Close list' button
Then in Unity main window click on 'Option' submenu from 'Tools' main menu
Then check if 'Options' window is opened
Then in Options window select radio button 'Custom show actions'
Then in Options window click on 'Department' checkbox
Then in Options window select value 'Dispatch - Dispatch' from the 'Department' dropdown
Then in Options window click 'Ok' button
Then in Unity main window click on 'Action' submenu from 'View' main menu
Then check if 'Actions of department Dispatch' window is opened
Then in Action Summary window verify all the actions listed are of 'department' 'Dispatch'
Then in Action Summary window click 'Close list' button

