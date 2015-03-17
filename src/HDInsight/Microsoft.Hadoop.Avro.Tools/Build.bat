@echo off

rem *** This batch file invokes MS Build from .NET Framework 4.0 distribution
rem *** to build the Microsoft Avro Lirary Tools utility
rem *** Needs to be run in the directory containing Microsoft.Hadoop.Avro.Tools.csproj
rem *** Requies .NET Framework 4.0

rem Uncomment the line below to use MS Build from 32-bit Framework
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319

rem Uncomment the line below to use MS Build from 64-bit Framework
rem set msBuildDir=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319

@echo on
call %msBuildDir%\msbuild Microsoft.Hadoop.Avro.Tools.csproj /p:Configuration=Release;nowarn=1591;WarningLevel=0 

@echo off
echo. 
pause