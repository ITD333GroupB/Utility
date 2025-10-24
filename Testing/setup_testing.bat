@echo off

REM Setup script for testing environment.
REM Ensure you have ran the main setup script first and that the database is creeated correctly.

sqlcmd -S localhost -d TaskHubDb -U User1 -P "Pass1!" -i .\seed_test_data.sql
pause