param([string]$serviceDirectory, [string]$packageName, [int]$numExpectedWarnings=0)

Write-Host "Creating a test app to publish."

$csprojFile = "aotcompatibility.csproj"

$csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <PublishAot>true</PublishAot>
    <TrimmerSingleWarn>false</TrimmerSingleWarn>
    <IsTestSupportProject>true</IsTestSupportProject>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\..\sdk\$serviceDirectory\$packageName\src\$packageName.csproj" />
      <TrimmerRootAssembly Include="$packageName" />
  </ItemGroup>

  <ItemGroup>
    <!-- Update this dependency to its latest, which has all the annotations -->
    <PackageReference Include="Microsoft.Extensions.Logging.Configuration" Version="8.0.0-preview.7.23375.6" />
  </ItemGroup>

</Project>
"@

$csprojContent | Set-Content -Path $csprojFile

$programFile = "Program.cs"

$programFileContent = @"
using $packageName;
using System;

namespace AotCompatibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");
        }
    }
}
"@

$programFileContent | Set-Content -Path $programFile

Write-Host "Validating the number of expected IL trimming warnings.\n"

$publishOutput = dotnet clean && dotnet restore && dotnet publish -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true

if ($LASTEXITCODE -ne 0)
{
    Write-Host "Publish failed."
    Write-Host $publishOutput
    Exit 2
}

$actualWarningCount = 0

foreach ($line in $($publishOutput -split "`r`n"))
{
    if ($line -like "*analysis warning IL*")
    {
        Write-Host $line

        $actualWarningCount += 1
    }
}

Write-Host "\nChecking against expected number of warnings"


$testPassed = 0
if ($actualWarningCount -ne $numExpectedWarnings)
{
    $testPassed = 1
    Write-Host "Actual warning count:", $actualWarningCount, "is not as expected. Expected warning count is:", $numExpectedWarnings
}
else 
{
    Write-Host "Warning count was:", $actualWarningCount
}

Write-Host "Deleting test app files."

Remove-Item -Path $csprojFile
Remove-Item -Path $programFile

Exit $testPassed