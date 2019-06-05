@if not "%DevShellPath%"=="" @goto :devshellpath_ok

@echo ERROR: Environment variable DevShellPath is not set.
@exit /b 1

:devshellpath_ok

@if exist "%DevShellPath%\devshell.psm1" @goto :devshellcmd_ok

@echo ERROR: devshell.psm1 is not found at DevShellPath=%DevShellPath%
@exit /b 1

:devshellcmd_ok

@REM This customization adds an external library to DevShell.
@REM That would display commands from the module in DevShell's "info"
@REM Note that DevShell currently hardcodes each library it operates,
@REM so reloading devshell with "init" will lose our custom library.
@set DevShellCustomizations=ipmo %~dp0\Utils.psm1 -DisableNameChecking; Set-LibraryInfo -LibraryName Utils -LibraryVersion '1.0' -LibraryDisplayName StorageSyncSdkUtils -LibraryDescription StorageSyncSdkDevOps;
@set DevShellLoader=%DevShellPath%\devshell.psm1
@set PowerShellLoader=%windir%\system32\WindowsPowerShell\v1.0\powershell.exe

@if "%*"=="" @goto :runshell
%windir%\system32\WindowsPowerShell\v1.0\powershell.exe -Command ipmo %DevShellLoader% -DisableNameChecking;%DevShellCustomizations%;main -Quiet;%*
@exit /b 0

:runshell 
%windir%\system32\WindowsPowerShell\v1.0\powershell.exe -noexit -Command ipmo %DevShellLoader% -DisableNameChecking;%DevShellCustomizations%;main;