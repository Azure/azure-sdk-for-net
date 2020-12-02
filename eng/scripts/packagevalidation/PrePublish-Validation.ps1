[CmdletBinding()]
Param (
  [ValidateNotNullOrEmpty()]
  [string] $PackagePath,
  [string] $ArtifactName,
  [string] $WorkingDirectory
)

. "${PSScriptRoot}\..\common\scripts\logging.ps1"
. "${PSScriptRoot}\..\common\scripts\SemVer.ps1"

$WinVersion = (Get-ChildItem -Path "C:\Program Files (x86)\Windows Kits\10\bin\10.0*" | Sort-Object -Descending)[0]
$SignTool = "C:\Program Files (x86)\Windows Kits\10\bin\$($WinVersion.Name)\x64\signtool.exe"

New-Item -Path $WorkingDirectory -Name "Validation" -ItemType "directory"
$ValidationDirectory = "$WorkingDirectory\Validation"

Copy-Item -Path $PackagePath -Destination "$ValidationDirectory\package.zip"
Expand-Archive -LiteralPath "$ValidationDirectory\package.zip" "$ValidationDirectory\extracted"

$PackageName = Split-Path -Path $PackagePath -Leaf
$PackageDlls = Get-ChildItem -Path "$ValidationDirectory\extracted\**\*.dll" -Recurse
$NuspecFile = Get-ChildItem -Path "$ValidationDirectory\extracted\**\*.nuspec" -Recurse

$NuspecContent = new-object xml
$NuspecContent.Load($NuspecFile[0].FullName)
$PackageId = $NuspecContent.package.metadata.id
$PackageVersion = $NuspecContent.package.metadata.version
$ProjectUrl = $NuspecContent.package.metadata.projectUrl
$Description = $NuspecContent.package.metadata.description

$IsValidPackage = $true

LogDebug "Validating that Binaries and Packages are Signed..."
foreach ($file in $PackageDlls) {
    &$SignTool verify /pa $file.FullName
    if ($LASTEXITCODE -ne 0) {
        LogError "Validation Failed. Library [$($file.FullName)] is not signed."
        $IsValidPackage = $false
    }
}

LogDebug "Validating that Package Name matches Guidelines..."
try {
    $Version = ([AzureEngSemanticVersion]::ParseVersionString($PackageVersion)).ToString()
}
catch {
    LogError "Validation Failed. Invalid package version [ $Version ]."
    $IsValidPackage = $false
}

if (($ArtifactName -ne $PackageId) -or ($PackageName -ne "$PackageId.$PackageVersion.nupkg")) {
    LogError "Validation Failed. Wrong or invalid Package name"
    $IsValidPackage = $false
}

LogDebug "Validating Package Configuration..."
Push-Location $PSScriptRoot
dotnet tool install dotnet-script
foreach ($file in $PackageDlls) {
    dotnet script IsOptimizedAssembly.csx -- $file.FullName # Using dotnet script to ensure it runs on .NET 5
    if ($LASTEXITCODE -ne 0) {
        LogError "Validation Failed. Configuration for [$($file.FullName)] is not release."
        $IsValidPackage = $false
    }
}
Pop-Location

LogDebug "Validating Packages Descriptiion..."
if ([string]::IsNullOrWhiteSpace($Description)) {
    LogError "Validation Failed. Package Description is missing"
    $IsValidPackage = $false
}

LogDebug "Validating Project URL..."
if ([string]::IsNullOrWhiteSpace($ProjectUrl)) {
    LogError "Validation Failed. Project URL is missing"
    $IsValidPackage = $false
}

try {
    if ((Invoke-webrequest -method head -uri $ProjectUrl).StatusDescription -ne "OK") {
        LogError "Validation Failed. Project URL is not valid"
        $IsValidPackage = $false
    }
} catch {
    $IsValidPackage = $false
}

Remove-Item -Path "$ValidationDirectory"

if ($IsValidPackage) {
    LogDebug "Package [$PackagePath] is valid for release."
}
else {
    exit 1
}