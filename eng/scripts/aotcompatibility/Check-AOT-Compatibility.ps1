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

Write-Host "Collecting the set of trimming warnings.`n"

dotnet clean aotcompatibility.csproj | Out-Null
dotnet restore aotcompatibility.csproj | Out-Null
#$publishOutput = dotnet publish aotcompatibility.csproj -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true
#Write-Host $publishOutput

dotnet publish aotcompatibility.csproj -nodeReuse:false /p:UseSharedCompilation=false /p:ExposeExperimentalFeatures=true

Write-Host "Deleting test app files."

Set-Location -Path ..
Remove-Item -Path "./$folderPath" -Recurse -Force

exit 3