[CmdletBinding()]
Param (
  [ValidateNotNullOrEmpty()]
  [string] $PackagePath,
  [string] $ArtifactName,
  [string] $CertificateFingerPrint,
  [string] $WorkingDirectory
)

. (Join-Path ${PSScriptRoot} '..' '..' common scripts common.ps1)

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
nuget verify -Signatures $PackagePath -CertificateFingerprint $CertificateFingerPrint
if ($LASTEXITCODE -ne 0) {
    LogWarning "Signatures Validation Failed. Package [$(Split-Path $PackagePath -Leaf)] is not signed."
    $IsValidPackage = $false
}

LogDebug "Validating that Binaries and Scripts are Signed..."
foreach ($file in $DllsAndScripts) {
    &$SignTool verify /pa $file.FullName
    if ($LASTEXITCODE -ne 0) {
        LogWarning "Signatures Validation Failed. Library [$($file.FullName)] is not signed."
        $IsValidPackage = $false
    }
}

LogDebug "Validating that Version matches Guidelines..."
try {
    $Version = ([AzureEngSemanticVersion]::ParseVersionString($PackageVersion)).ToString()
}
catch {
    LogWarning "Version Validation Failed. Invalid package version [ $Version ]."
    $IsValidPackage = $false
}

LogDebug "Validating Package Configuration..."
Push-Location $PSScriptRoot
dotnet tool install dotnet-script
foreach ($file in $PackageDlls) {
    dotnet script IsOptimizedAssembly.csx -- $file.FullName # Using dotnet script to ensure it runs on .NET 5
    if ($LASTEXITCODE -ne 0) {
        LogWarning "Configuration Validation Failed. Configuration for [$($file.FullName)] is not release."
        $IsValidPackage = $false
    }
}
Pop-Location

LogDebug "Validating Packages Id..."
if ([string]::IsNullOrWhiteSpace($PackageId) -or !($PackageId.StartsWith("Azure") -or $PackageId.StartsWith("Microsoft"))) {
    LogWarning "PackageId Validation Failed. Package Id is not valid"
    $IsValidPackage = $false
}

if (($ArtifactName -ne $PackageId) -or ($PackageName -ne "$PackageId.$PackageVersion.nupkg")) {
    LogWarning "PackageId Validation Failed. Wrong or invalid Package name"
    $IsValidPackage = $false
}

LogDebug "Validating Author..."
if ($Author -ne "Microsoft") {
    LogWarning "Author Validation Failed. Package Author is not valid."
    $IsValidPackage = $false
}

LogDebug "Validating Packages Descriptiion..."
if ([string]::IsNullOrWhiteSpace($Description)) {
    LogWarning "Descriptiion Validation Failed. Package Description is missing"
    $IsValidPackage = $false
}

LogDebug "Validating Project URL..."
if ([string]::IsNullOrWhiteSpace($ProjectUrl)) {
    LogWarning "Project URL Validation Failed. Project URL is missing"
    $IsValidPackage = $false
}

try {
    if (($ProjectUrl -as [System.URI]).AbsoluteURI -eq $null) {
        LogWarning "Project URL Validation Failed. Project URL is not valid"
        $IsValidPackage = $false
    }
} catch {
    $IsValidPackage = $false
}

$packageProperties = Get-PkgProperties -PackageName $PackageId
if ($packageProperties.SdkType -eq "client" -and $packageProperties.IsNewSdk)
{
    LogDebug "Validating package dependencies for client libraries..."
    $packageDataPropsPath = Join-Path $EngDir Packages.Data.props
    $packageDataProps = new-object xml
    $packageDataProps.Load($packageDataPropsPath)
    $clientPkgDependencies = $packageDataProps.Project.ItemGroup.Where({$_.Condition -match "'\$\((IsClientLibrary|IsExtensionClientLibrary)\)' == 'true'"})

    $packageDependencies = $NuspecContent.package.metadata.dependencies.group.dependencies.dependency
    foreach($dep in $packageDependencies)
    {
        if (($clientPkgDependencies.PackageReference.Where({($_.Update -eq $dep.Id) -and ($_.Version -eq $dep.Version)})).Count -eq 0) 
        {
            LogWarning "Dependencies Validation Failed. Invalid package dependency"
            LogWarning "Name: $($dep.Id), Version: $($dep.Version)"
            $IsValidPackage = $false
        }
    }
}

Remove-Item -Path "$ValidationDirectory"  -Recurse -Force

if ($IsValidPackage) {
    LogDebug "Package [$(Split-Path $PackagePath -LeafBase)] is valid for release."
}
else {
    LogError "Package [$(Split-Path $PackagePath -LeafBase) ] is not valid for release."
    exit 1
}