param([string]$ServiceDirectory, [string]$PackageName, [string]$ExpectedWarningsFilePath)

### Creating a test app ###

Write-Host "Creating a test app to publish."

$expectedWarningsFullPath = Join-Path -Path "..\..\..\..\sdk\$ServiceDirectory\" -ChildPath $ExpectedWarningsFilePath

$folderPath = "\TempAotCompatFiles"
New-Item -ItemType Directory -Path "./$folderPath" | Out-Null
Set-Location "./$folderPath"

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
    <ProjectReference Include="..\..\..\..\sdk\$ServiceDirectory\$PackageName\src\$PackageName.csproj" />
      <TrimmerRootAssembly Include="$PackageName" />
  </ItemGroup>
  <ItemGroup>
    <!-- Update this dependency to its latest, which has all the annotations -->
    <PackageReference Include="Microsoft.Extensions.Logging.Configuration" Version="8.0.0" />
  </ItemGroup>
</Project>
"@

$csprojContent | Set-Content -Path $csprojFile

$programFile = "Program.cs"

$programFileContent = @"
using $PackageName;
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

### Publishing and collecting trimming warnings ###

Write-Host "Collecting the set of trimming warnings."

dotnet clean aotcompatibility.csproj | Out-Null
dotnet restore aotcompatibility.csproj | Out-Null
$publishOutput = dotnet publish aotcompatibility.csproj -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true

if ($LASTEXITCODE -ne 0)
{
    Write-Host "Publish failed."

    Write-Host $publishOutput

    Write-Host "Deleting test app files."

    Set-Location -Path ..
    Remove-Item -Path "./$folderPath" -Recurse -Force

    Write-Host "\nFor help with this check, please see https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/AotRegressionChecks.md"
    Exit 2
}

$actualWarningCount = 0

foreach ($line in $($publishOutput -split "`r`n"))
{
    if ($line -like "*analysis warning IL*")
    {
        $actualWarningCount += 1
    }
}

Write-Host "There were $actualWarningCount warnings reported."

### Reading the contents of the text file path ###

Write-Host "Reading the list of patterns that represent the list of expected warnings."

if (Test-Path $expectedWarningsFullPath -PathType Leaf) {
    # Read the contents of the file and store each line in an array
    $expectedWarnings = Get-Content -Path $expectedWarningsFullPath
} else {
    # If no correct expected warnings were provided, check that there are no warnings reported.

    Write-Host "The specified file does not exist. Assuming no warnings are expected."

    $warnings = $publishOutput -split "`n" | select-string -pattern 'IL\d+' | select-string -pattern '##' -notmatch
    $numWarnings = $warnings.Count

    if ($numWarnings -gt 0) {
      Write-Host "Found $numWarnings additional warnings that were not expected:`n$warnings"
    }

    Write-Host "Deleting test app files."

    Set-Location -Path ..
    Remove-Item -Path "./$folderPath" -Recurse -Force

    Write-Host "\nFor help with this check, please see https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/AotRegressionChecks.md"

    exit $warnings.Count
}

### Comparing expected warnings to the publish output ###

$numExpectedWarnings = $expectedWarnings.Count

Write-Host "Checking against the list of expected warnings. There are $numExpectedWarnings warnings expected."

$warnings = $publishOutput -split "`n" | select-string -pattern 'IL\d+' | select-string -pattern '##' -notmatch | select-string -pattern $expectedWarnings -notmatch
$numWarnings = $warnings.Count
if ($numWarnings -gt 0) {
  Write-Host "Found $numWarnings additional warnings that were not expected:`n$warnings"
}

### Cleanup ###

Write-Host "Deleting test app files."

Set-Location -Path ..
Remove-Item -Path "./$folderPath" -Recurse -Force

if ($numExpectedWarnings -ne $actualWarningCount) {
  Write-Host "The number of expected warnings ($numExpectedWarnings) was different than the actual warning count ($actualWarningCount)."
  Write-Host "\nFor help with this check, please see https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/AotRegressionChecks.md"
  exit 2
}

Write-Host "\nFor help with this check, please see https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/AotRegressionChecks.md"
exit $warnings.Count