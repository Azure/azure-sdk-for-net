[CmdletBinding()]
Param (
  [ValidateNotNullOrEmpty()]
  [string] $PackagePath,
  [string] $ArtifactName,
  [string] $CertificateFingerPrint,
  [string] $WorkingDirectory
)

. (Join-Path ${PSScriptRoot} .. common scripts logging.ps1)
. (Join-Path ${PSScriptRoot} .. common scripts SemVer.ps1)

$WinKitsDir = (Join-Path C: "Program Files (x86)" "Windows Kits"  10 bin)
$WinVersion = (Get-ChildItem -Path (Join-Path $WinKitsDir 10.0*) | Sort-Object -Descending)[0]
$SignTool = Join-Path $WinKitsDir $WinVersion.Name x64 signtool.exe

New-Item -Path $WorkingDirectory -Name "Validation" -ItemType "directory"
$ValidationDirectory = (Join-Path $WorkingDirectory Validation)

Expand-Archive -LiteralPath $PackagePath (Join-Path $ValidationDirectory extracted)

$PackageName = Split-Path -Path $PackagePath -Leaf
$DllsAndScripts = Get-ChildItem -Path (Join-Path $ValidationDirectory extracted) -Include *.dll, *.ps1 -Recurse
$PackageDlls = Get-ChildItem -Path (Join-Path $ValidationDirectory extracted) -Include *.dll -Recurse
$NuspecFile = Get-ChildItem -Path (Join-Path $ValidationDirectory extracted ** *.nuspec) -Recurse

$NuspecContent = new-object xml
$NuspecContent.Load($NuspecFile[0].FullName)
$PackageId = $NuspecContent.package.metadata.id
$PackageVersion = $NuspecContent.package.metadata.version
$ProjectUrl = $NuspecContent.package.metadata.projectUrl
$Description = $NuspecContent.package.metadata.description
$Author = $NuspecContent.package.metadata.authors

$IsValidPackage = $true

LogDebug "Validating that the Package is Signed..."
nuget veriy -Signatures $PackagePath -CertificateFingerprint $CertificateFingerPrint
if ($LASTEXITCODE -ne 0) {
    LogError "Validation Failed. Package [$(Split-Path $PackagePath -Leaf)] is not signed."
    $IsValidPackage = $false
}

LogDebug "Validating that Binaries and Scripts are Signed..."
foreach ($file in $DllsAndScripts) {
    &$SignTool verify /pa $file.FullName
    if ($LASTEXITCODE -ne 0) {
        LogError "Validation Failed. Library [$($file.FullName)] is not signed."
        $IsValidPackage = $false
    }
}

LogDebug "Validating that PackageName and Version matches Guidelines..."
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

LogDebug "Validating Packages Id..."
if ([string]::IsNullOrWhiteSpace($PackageId) -or !($PackageId.StartsWith("Azure") -or $PackageId.StartsWith("Microsoft"))) {
    LogError "Validation Failed. Package Id is not valid"
    $IsValidPackage = $false
}

LogDebug "Validating Author..."
if ($Author -ne "Microsoft") {
    LogError "Validation Failed. Package Author is not valid."
    $IsValidPackage = $false
}

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
    if ((Invoke-WebRequest -method head -uri $ProjectUrl).StatusDescription -ne "OK") {
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