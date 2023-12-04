param([string]$ServiceDirectory, [string]$PackageName, [string]$ExpectedWarningsFilePath)

### Creating a test app ###

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
    <ProjectReference Include="..\..\..\sdk\$ServiceDirectory\$PackageName\src\$PackageName.csproj" />
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

$publishOutput = dotnet clean && dotnet restore && dotnet publish -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true

if ($LASTEXITCODE -ne 0)
{
    Write-Host "Publish failed."

    Write-Host $publishOutput

    Write-Host "Deleting test app files."

    Remove-Item -Path $csprojFile
    Remove-Item -Path $programFile

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

if (Test-Path $ExpectedWarningsFilePath -PathType Leaf) {
    # Read the contents of the file and store each line in an array
    $expectedWarnings = Get-Content -Path $ExpectedWarningsFilePath
} else {
    Write-Host "The specified file does not exist."
}

### Comparing expected warnings to the publish output ###

$numExpectedWarnings = Measure-Object $expectedWarnings -Line

Write-Host "Checking against the list of expected warnings. There are $numExpectedWarnings warnings expected."

$warnings = $publishOutput -split "`n" | select-string -pattern 'IL\d+' | select-string -pattern $expectedWarnings -notmatch -simplematch
if ($warnings.Count -gt 0) {
  Write-Host "Found additional warnings that were not expected:`n$warnings"
}

### Cleanup ###

Write-Host "Deleting test app files."

Remove-Item -Path $csprojFile
Remove-Item -Path $programFile

exit $warnings.Count