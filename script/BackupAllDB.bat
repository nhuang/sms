cd c:\web\script

@echo off

set DBList=FVTS
for %%a IN (%DBList%) DO (
    CALL BackupScript.bat %%a
)

echo ----------------
echo Completed Database backup process
echo ----------------
