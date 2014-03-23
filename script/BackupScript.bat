set BackupDir=C:\web\backup
set DBName=%1
set DBHost=(local)
:: Setting environment variables with todoy's date values
for /f "tokens=1-4 delims=-/ " %%i IN ('date /t') DO (
set day=%%i
set month=%%j
set year=%%k
)

for /f "tokens=1-3 delims=:" %%i IN ('time /t') DO (
set hour=%%i
set minute=%%j
)

for /f "tokens=1 delims= " %%i IN ("%hour%") DO (
set hour=%%i
)

set BackupFile=%BackupDir%\%DBName%_%year%-%month%-%day%-%hour%-%minute%.bak

IF "%DBName%" NEQ "" goto ExecuteBackup
    echo ---------------------
    echo Please assign database name
    echo ---------------------
    pause
    exit 0

:ExecuteBackup

echo === backup %DBName% database
echo ---------------------------------------------------------------------------

echo backuoto %BackupDir%
::echo sqlcmd -S %DBHost% -E -Q "BACKUP DATABASE [%DBName%]  TO DISK='%BackupFile%'"
sqlcmd -S %DBHost% -E -Q "BACKUP DATABASE [%DBName%]  TO DISK='%BackupFile%'"