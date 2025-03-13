param (
    [string] $ProjectNames,
    [string] $OutputPath,
    [string] $PackageInfoFolder,
    [bool] $SetOverrideFile
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

$changedProjects = $packageProperties | Where-Object { $packageSet -contains $_.ArtifactName }
| ForEach-Object { "$($_.DirectoryPath)/**/*.csproj"; }

$projectsForGeneration = ($changedProjects | ForEach-Object { "`$(RepoRoot)$_" } | Sort-Object)
$projectGroups = @()
$projectGroups += ,$projectsForGeneration

if ($SetOverrideFile) {
    $outputFile = (Write-Test-Dependency-Group-To-Files -ProjectFileConfigName "packages" -ProjectGroups $projectGroups -MatrixOutputFolder $OutputPath)[0]
    Get-ChildItem -Recurse $OutputPath | ForEach-Object { Write-Host "Dumping $($_.FullName)"; Get-Content -Raw -Path $_.FullName | Write-Host }
    # the projectlistoverride file must be provided as a relative path
    $relativeOutputPath = [System.IO.Path]::GetRelativePath($RepoRoot, "$OutputPath/$outputFile")
    Write-Host "##vso[task.setvariable variable=ProjectListOverrideFile;]$relativeOutputPath"
}

# Filter JSON files to only keep those matching package names in packageSet
Get-ChildItem -Recurse "$PackageInfoFolder" *.json | ForEach-Object {
    $fileContent = Get-Content -Raw -Path $_.FullName | ConvertFrom-Json
    if ($packageSet -notcontains $fileContent.Name) {
        Remove-Item $_.FullName -Force
        Write-Host "Removed $($_.FullName) as it doesn't belong to the package set that this batch is targeting."
    }
}

Write-Host "##vso[task.setvariable variable=ChangedServices;]$changedServices"
Write-Host "This run is targeting: $ProjectNames in [$changedServices]"