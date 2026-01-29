#Requires -Version 7.0
param(
    $filter,
    [bool]$Stubbed = $true,
    [bool]$LaunchOnly = $false,
    [bool]$Debug = $false
)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;
Import-Module "$PSScriptRoot\Spector-Helper.psm1" -DisableNameChecking -Force;

$mgmtPackageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
Write-Host "Mgmt Package root: $mgmtPackageRoot" -ForegroundColor Cyan
$mgmtSolutionDir = Join-Path $mgmtPackageRoot 'generator'

if (-not $LaunchOnly) {
    Refresh-Mgmt-Build

    if ($null -eq $filter -or $filter -eq "Mgmt-TypeSpec") {
        Write-Host "Generating MgmtTypeSpec" -ForegroundColor Cyan
        $testProjectsLocalDir = Join-Path $mgmtPackageRoot 'generator' 'TestProjects' 'Local'

        $mgmtTypespecTestProject = Join-Path $testProjectsLocalDir "Mgmt-TypeSpec"

        Invoke (Get-Mgmt-TspCommand "$mgmtTypespecTestProject/main.tsp" $mgmtTypespecTestProject -debug:$Debug)

        # exit if the generation failed
        if ($LASTEXITCODE -ne 0) {
            exit $LASTEXITCODE
        }

        Write-Host "Building MgmtTypeSpec" -ForegroundColor Cyan
        Invoke "dotnet build $mgmtPackageRoot/generator/TestProjects/Local/Mgmt-TypeSpec/src/Azure.Generator.MgmtTypeSpec.Tests.csproj"

        # exit if the generation failed
        if ($LASTEXITCODE -ne 0) {
            exit $LASTEXITCODE
        }
    }
}

$spectorRoot = Join-Path $mgmtPackageRoot 'generator' 'TestProjects' 'Spector'

$spectorLaunchProjects = @{}

foreach ($specFile in Get-Sorted-Specs) {
    $subPath = Get-SubPath $specFile
    $folders = $subPath.Split([System.IO.Path]::DirectorySeparatorChar)

    if (-not (Compare-Paths $subPath $filter)) {
        continue
    }

    $generationDir = $spectorRoot
    foreach ($folder in $folders) {
        $generationDir = Join-Path $generationDir $folder
    }

    # create the directory if it doesn't exist
    if (-not (Test-Path $generationDir)) {
        New-Item -ItemType Directory -Path $generationDir | Out-Null
    }

    Write-Host "Generating $subPath" -ForegroundColor Cyan

    $spectorLaunchProjects.Add(($folders -join "-"), ("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))"))
    if ($LaunchOnly) {
        continue
    }

    Invoke (Get-Mgmt-TspCommand $specFile $generationDir -debug:$Debug)

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

# only write new launch settings if no filter was passed in
if ($null -eq $filter) {
    $mgmtSpec = "TestProjects/Local/Mgmt-TypeSpec"

    # Write the launch settings for Mgmt
    $mgmtLaunchSettings = @{}
    $mgmtLaunchSettings.Add("profiles", @{})
    $mgmtLaunchSettings["profiles"].Add("Mgmt-TypeSpec", @{})
    $mgmtLaunchSettings["profiles"]["Mgmt-TypeSpec"].Add("commandLineArgs", "`$(SolutionDir)/../dist/generator/Microsoft.TypeSpec.Generator.dll `$(SolutionDir)/$mgmtSpec -g MgmtClientGenerator")
    $mgmtLaunchSettings["profiles"]["Mgmt-TypeSpec"].Add("commandName", "Executable")
    $mgmtLaunchSettings["profiles"]["Mgmt-TypeSpec"].Add("executablePath", "dotnet")

    foreach ($kvp in $spectorLaunchProjects.GetEnumerator()) {
        $mgmtLaunchSettings["profiles"].Add($kvp.Key, @{})
        $mgmtLaunchSettings["profiles"][$kvp.Key].Add("commandLineArgs", "`$(SolutionDir)/../dist/generator/Microsoft.TypeSpec.Generator.dll `$(SolutionDir)/$($kvp.Value) -g AzureStubGenerator")
        $mgmtLaunchSettings["profiles"][$kvp.Key].Add("commandName", "Executable")
        $mgmtLaunchSettings["profiles"][$kvp.Key].Add("executablePath", "dotnet")
    }

    $mgmtSortedLaunchSettings = @{}
    $mgmtSortedLaunchSettings.Add("profiles", [ordered]@{})
    $mgmtLaunchSettings["profiles"].Keys | Sort-Object | ForEach-Object {
        $profileKey = $_
        $originalProfile = $mgmtLaunchSettings["profiles"][$profileKey]

        # Sort the keys inside each profile
        # This is needed due to non deterministic ordering of json elements in powershell
        $sortedProfile = [ordered]@{}
        $originalProfile.GetEnumerator() | Sort-Object Key | ForEach-Object {
            $sortedProfile[$_.Key] = $_.Value
        }

        $mgmtSortedLaunchSettings["profiles"][$profileKey] = $sortedProfile
    }

    # Write the launch settings to the launchSettings.json file
    $mgmtLaunchSettingsPath = Join-Path $mgmtSolutionDir "Azure.Generator.Management" "src" "Properties" "launchSettings.json"
    # Write the settings to JSON and normalize line endings to Unix style (LF)
    $mgmtSortedLaunchSettings | ConvertTo-Json | ForEach-Object { ($_ -replace "`r`n", "`n") + "`n" } | Set-Content -NoNewline $mgmtLaunchSettingsPath
}