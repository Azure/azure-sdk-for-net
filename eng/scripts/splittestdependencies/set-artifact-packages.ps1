param (
    [string] $ProjectNames,
    [string] $OutputPath,
    [string] $PackageInfoFolder,
    [bool] $SetOverrideFile
)

. $PSScriptRoot/generate-dependency-functions.ps1

$RepoRoot = Resolve-Path (Join-Path "$PSScriptRoot" ".." ".." "..")
$packageSet = "$ProjectNames" -split ","

# retrieve the package info files
$packageProperties = Get-ChildItem -Recurse "$PackageInfoFolder" *.json `
| Foreach-Object { Get-Content -Raw -Path $_.FullName | ConvertFrom-Json }

# filter the package info files to only those that are part of the targeted batch (present in $ProjectNames arg)
# so that we can accurate determine the affected services for the current batch
$changedServicesArray = $packageProperties | Where-Object { $packageSet -contains $_.ArtifactName } `
    | ForEach-Object { $_.ServiceDirectory } | Get-Unique
$changedServices = $changedServicesArray -join ","

if ($SetOverrideFile) {
    $outputFile = Write-PkgInfoToDependencyGroupFile -OutputPath $OutputPath -PackageInfoFolder $PackageInfoFolder -ProjectNames $packageSet
    Get-ChildItem -Recurse $OutputPath | ForEach-Object { Write-Host "Dumping $($_.FullName)"; Get-Content -Raw -Path $_.FullName | Write-Host }
    # the projectlistoverride file must be provided as a relative path
    $relativeOutputPath = [System.IO.Path]::GetRelativePath($RepoRoot, "$OutputPath/$outputFile")
    Write-Host "##vso[task.setvariable variable=ProjectListOverrideFile;]$relativeOutputPath"
}

# remove any package.json files that are not part of the targeted batch
Get-ChildItem -Recurse "$PackageInfoFolder" *.json | ForEach-Object {
    $fileContent = Get-Content -Raw -Path $_.FullName | ConvertFrom-Json
    if ($packageSet -notcontains $fileContent.Name) {
        Remove-Item $_.FullName -Force
        Write-Host "Removed $($_.FullName) as it doesn't belong to the package set that this batch is targeting."
    }
}

Write-Host "##vso[task.setvariable variable=ChangedServices;]$changedServices"
Write-Host "This run is targeting: $ProjectNames in [$changedServices]"