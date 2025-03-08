param (
    [string] $ProjectNames,
    [string] $OutputPath,
    [string] $PackageInfoFolder
)

. $PSScriptRoot/generate-dependency-functions.ps1

$RepoRoot = Resolve-Path (Join-Path "$PSScriptRoot" ".." ".." "..")

# set changed services given the set of changed packages, this will mean that
# ChangedServices will be appropriate for the batched set of packages if that is indeed how
# we set the targeted artifacts
$packageProperties = Get-ChildItem -Recurse "$PackageInfoFolder" *.json `
| Foreach-Object { Get-Content -Raw -Path $_.FullName | ConvertFrom-Json }

$packageSet = "$ProjectNames" -split ","

$changedServicesArray = $packageProperties | Where-Object { $packageSet -contains $_.ArtifactName }
| ForEach-Object { $_.ServiceDirectory } | Get-Unique
$changedServices = $changedServicesArray -join ","

$outputFile = Write-PkgInfoToDependencyGroupFile -OutputPath $OutputPath -PackageInfoFolder $PackageInfoFolder -ProjectNames $ProjectNames

Get-ChildItem -Recurse $OutputPath | ForEach-Object { Write-Host "Dumping $($_.FullName)"; Get-Content -Raw -Path $_.FullName | Write-Host }

# the projectlistoverride file must be provided as a relative path
$relativeOutputPath = [System.IO.Path]::GetRelativePath($RepoRoot, "$OutputPath/$outputFile")

Write-Host "##vso[task.setvariable variable=ProjectListOverrideFile;]$relativeOutputPath"
Write-Host "##vso[task.setvariable variable=ChangedServices;]$changedServices"
Write-Host "This run is targeting: $ProjectNames in [$changedServices]"