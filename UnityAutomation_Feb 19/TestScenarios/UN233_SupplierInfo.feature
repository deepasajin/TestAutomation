Feature: UN233_SupplierInfo

@Demo
Scenario: TC003_SearchSupplier
#Given Enter username and password and launch Unity application
#Given Launch the Unity Application
Then in Unity main window click on 'Supplier' submenu from 'DataBank' main menu
Then in SearchSupplier window select the search filter radio button 'CompanyTitle'
Then in SearchSupplier window input the value 'Testing' in the edit field for 'CompanyTitle'
Then in SearchSupplier window click on 'Ok' button
Then in SupplierList window click on 'Close' button
Then in Unity main window click on 'Exit' icon in the toolbar
Then in the pop-up window click 'Yes' for the message 'Do you wish to log off?'
#Then in Unity main window close the application


@notcompleted
Scenario: TC002_CreateNewFile_X1_Icon
#Given Enter username and password and launch Unity application
Then in Unity main window click on 'File' icon in the toolbar

@notcompleted
Scenario: TC002_CreateNewFile_X1_Menu
#Given Enter username and password and launch Unity application
#Given Launch the Unity Application
Then in Unity main window click on 'File' flyout from 'New' submenu in the main menu 'File'
Then check 'New File' page is loaded successfully

