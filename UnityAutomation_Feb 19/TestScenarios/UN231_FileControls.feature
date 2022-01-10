Feature: UN231_FileControls
To control the file craeted. Change/Save/Edit/Update

@completed
Scenario: TC001_MenuOptions_ChangeMode_UpdateFile_SaveFile_ReleaseFile
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'End Customer' tab
Then in End Customer tab enter value 'Chandran' in the field 'LastName'
Then in End Customer tab enter value 'Deepa' in the field 'FirstName'
Then in Search window click on 'Search' button
Then in End Customer tab click on 'Chandran' value in search result table
Then in Search window click on 'Ok' button
Then in the pop-up window click 'Ok' for the message 'The dossier X120000206THA is opened by'
Then in Unity main window click on 'Change' submenu from 'Edit' main menu
Then in File Management window edit the value in the field 'Mobile' to '9481331251'
Then in the pop-up window click 'Yes' for the message 'Do you want to save the modifications?'
Then in File Management window verify the value in the field 'Mobile' is '9481331251'
Then in Unity main window click on 'Release' submenu from 'File' main menu

@completed
Scenario: TC002_Icon_ChangeMode_UpdateFile_UndoFile_ReloadFile
Given Launch the Unity Application
Then in Unity main window click on 'Search' submenu from 'Tools' main menu
Then in Search window click on 'End Customer' tab
Then in End Customer tab enter value 'Chandran' in the field 'LastName'
Then in End Customer tab enter value 'Deepa' in the field 'FirstName'
Then in Search window click on 'Search' button
Then in End Customer tab click on 'Chandran' value in search result table
Then in Search window click on 'Ok' button
Then in the pop-up window click 'Ok' for the message 'The dossier X120000206THA is opened by'
Then in File Management window edit the value in the field 'Zipcode' to '695003'
Then in Unity main window click on 'Undo' submenu from 'Edit' main menu
Then in Unity main window click on 'Reload File' icon in the toolbar
Then in File Management window verify the value in the field 'Zipcode' is '695025'
