# Common Utility

## AutoInstall

A simple script setup for downloading the project's prerequisites for setup.

## Testing

Contains SQL, Batch, and Powershell scripts to automate testing of application.
For most basic startup as of 10/24/2025:
   1. Run `setup_testing.bat` from the command prompt terminal.
   2. Upon verifying the data was successfully added to the table, startup an instance of the backend ASP.Net REST application. This can be done from your Visual Studio IDE.
   3. Run `test_login.ps1` to test basic login authentication.

## CommonLib

A C# class library storing class files that represent a common schema for the project.