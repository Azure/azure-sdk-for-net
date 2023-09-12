param([string]$serviceDirectory)
param([string]$packageName)
param([int]$numExpectedWarnings)

Write-Host "Creating a test app to publish."

$csprojFile = "aotcompatibility.csproj"

$csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\..\sdk\$serviceDirectory\$packageName\src\$packageName.csproj" />
    <TrimmerRootAssembly Include="$packageName" />
  </ItemGroup>

  <!-- Update this dependency to its latest, which has all the annotations -->
  <PackageReference Include="Microsoft.Extensions.Logging.Configuration" Version="8.0.0-preview.7.23375.6" />

</Project>
"@

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

$csprojContent | Set-Content -Path $csprojFile
$programFileContent | Set-Content -Path $programFile

Write-Host "Validating the number of expected IL trimming warnings."
Write-Host "Attempting to publish the console app located at: azure-sdk-for-net/sdk/", $serviceDirectory, "/" $artifact, "/aotcompatibility"

$publishOutput = dotnet publish -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true

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

Write-Host "Looking for expected number of warnings"


$testPassed = 0
if ($actualWarningCount -ne $numExpectedWarnings)
{
    $testPassed = 1
    Write-Host "Actual warning count:", actualWarningCount, "is not as expected. Expected warning count is:", $expectedWarningCount
}

Exit $testPassed