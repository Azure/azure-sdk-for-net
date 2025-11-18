param(
  [string]$ServiceDirectory,
  [string]$PackageName,
  [string]$DirectoryName = "")

### Check if AOT compatibility is opted out ###

$RepoRoot = Resolve-Path (Join-Path $PSScriptRoot .. .. ..)

# Build the path to the actual project file (same logic as used later in the script)
if ([string]::IsNullOrEmpty($DirectoryName)) {
    $ProjectPath = Join-Path $RepoRoot "sdk" $ServiceDirectory $PackageName "src" "$PackageName.csproj"
} else {
    $ProjectPath = Join-Path $RepoRoot "sdk" $ServiceDirectory $DirectoryName "src" "$PackageName.csproj"
}

# Get the property directly from the project file - replicating what the target does
$output = dotnet msbuild -getProperty:AotCompatOptOut "$ProjectPath"

$aotOptOut = $output.Trim() -eq "true"

if ($aotOptOut) {
    Write-Host "AOT compatibility is opted out for $PackageName. Skipping AOT compatibility check."
        exit 0
}

### Creating a test app ###

Write-Host "Creating a test app to publish."

# Set the project reference path based on whether DirectoryName was provided
if ([string]::IsNullOrEmpty($DirectoryName)) {
    $projectRefFullPath = "..\..\..\..\sdk\$ServiceDirectory\$PackageName\src\$PackageName.csproj"
} else {
    $projectRefFullPath = "..\..\..\..\sdk\$ServiceDirectory\$DirectoryName\src\$PackageName.csproj"
}

$folderPath = "\TempAotCompatFiles"
New-Item -ItemType Directory -Path "./$folderPath" | Out-Null
Set-Location "./$folderPath"

$csprojFile = "aotcompatibility.csproj"

$csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <PublishAot>true</PublishAot>
    <EventSourceSupport>true</EventSourceSupport>
    <TrimmerSingleWarn>false</TrimmerSingleWarn>
    <IsTestSupportProject>true</IsTestSupportProject>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="$projectRefFullPath" />
      <TrimmerRootAssembly Include="$PackageName" />
  </ItemGroup>
  <ItemGroup>
    <!-- Update this dependency to its latest, which has all the annotations -->
    <PackageReference Include="Microsoft.Extensions.Logging.Configuration" Version="9.0.0" />
  </ItemGroup>
</Project>
"@

$csprojContent | Set-Content -Path $csprojFile

$programFile = "Program.cs"

$programFileContent = @"
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
    Write-Host "Publish failed." -ForegroundColor Red

    Write-Host ($publishOutput -join "`n")

    Write-Host "Deleting test app files."

    Set-Location -Path ..
    Remove-Item -Path "./$folderPath" -Recurse -Force

    Write-Host "`nFor help with this check, please see https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/AotCompatibility.md"
    Exit 2
}

$actualWarningCount = 0

foreach ($line in $($publishOutput -split "`r`n"))
{
    if ($line -like "*warning IL*")
    {
        $actualWarningCount += 1
    }
}

### Compare to baselined warnings ###

# Baselining warnings is only allowed for a couple of the Azure.Core.* packages, hard code the file path to the expected
# warnings as a backdoor for those packages.

$expectedWarningsPath = "..\..\..\..\sdk\$ServiceDirectory\$PackageName\tests\compatibility\ExpectedAotWarnings.txt"

if (Test-Path $expectedWarningsPath -PathType Leaf) {
    # Read the contents of the file and store each line in an array
    $expectedWarnings = Get-Content -Path $expectedWarningsPath
} else {
    # If no correct expected warnings were provided, check that there are no warnings reported.

    $warnings = $publishOutput -split "`n" | select-string -pattern 'IL\d+' | select-string -pattern '##' -notmatch
    $numWarnings = $warnings.Count

    if ($numWarnings -gt 0) {
      Write-Host "Found $numWarnings AOT warnings:" -ForegroundColor Red
      foreach ($warning in $warnings) {
        Write-Host $warning -ForegroundColor Yellow
      }
    }

    Write-Host "Deleting test app files."

    Set-Location -Path ..
    Remove-Item -Path "./$folderPath" -Recurse -Force

    Write-Host "`nFor help with this check, please see https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/AotCompatibility.md"
    Write-Host "To see this output locally, run 'eng/scripts/compatibility/Check-AOT-Compatibility.ps1 $ServiceDirectory $PackageName'"

    exit $warnings.Count
}

Write-Host "There were $actualWarningCount warnings reported from the publish."

$numExpectedWarnings = $expectedWarnings.Count

Write-Host "There are $numExpectedWarnings warnings expected."

$warnings = $publishOutput -split "`n" | select-string -pattern 'IL\d+' | select-string -pattern '##' -notmatch | select-string -pattern $expectedWarnings -notmatch
$numWarnings = $warnings.Count
if ($numWarnings -gt 0) {
  Write-Host "Found $numWarnings additional warnings that were not expected:" -ForegroundColor Red
  foreach ($warning in $warnings) {
    Write-Host $warning -ForegroundColor Yellow
  }
}

### Cleanup ###

Write-Host "Deleting test app files."

Set-Location -Path ..
Remove-Item -Path "./$folderPath" -Recurse -Force

if ($numExpectedWarnings -ne $actualWarningCount) {
  Write-Host "The number of expected warnings ($numExpectedWarnings) was different than the actual warning count ($actualWarningCount)."
  Write-Host "`nFor help with this check, please see https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/AotCompatibility.md"
  Write-Host "To run locally, run eng/scripts/compatibility/Check-AOT-Compatibility.ps1 $ServiceDirectory $PackageName"
  exit 2
}
  
Write-Host "`nFor help with this check, please see https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/AotCompatibility.md"
Write-Host "To see this output locally, run 'eng/scripts/compatibility/Check-AOT-Compatibility.ps1 $ServiceDirectory $PackageName'"
exit $warnings.Count