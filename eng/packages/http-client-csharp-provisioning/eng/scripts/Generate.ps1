#Requires -Version 7.0
param(
    $filter,
    [bool]$Stubbed = $true,
    [bool]$LaunchOnly = $false,
    [bool]$Debug = $false
)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

$provisioningPackageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
Write-Host "Provisioning Package root: $provisioningPackageRoot" -ForegroundColor Cyan
$provisioningSolutionDir = Join-Path $provisioningPackageRoot 'generator'

if (-not $LaunchOnly) {
    Refresh-Provisioning-Build
}

$testProjectsLocalDir = Join-Path $provisioningPackageRoot 'generator' 'TestProjects' 'Local'
$provisioningTypespecSpec = Join-Path $testProjectsLocalDir "Provisioning-TypeSpec" "main.tsp"
$provisioningTypespecProjects = @(
    @{
        Name = "Provisioning-TypeSpec"
        ApiVersion = "2024-05-01"
        OutputDirectory = Join-Path $testProjectsLocalDir "Provisioning-TypeSpec"
    },
    @{
        Name = "Provisioning-TypeSpec-Preview"
        ApiVersion = "2024-03-01-preview"
        OutputDirectory = Join-Path $testProjectsLocalDir "Provisioning-TypeSpec-Preview"
    }
)

foreach ($project in $provisioningTypespecProjects) {
    if ($null -ne $filter -and $filter -ne $project.Name) {
        continue
    }

    Write-Host "Generating $($project.Name)" -ForegroundColor Cyan
    Invoke (Get-Provisioning-TspCommand $provisioningTypespecSpec $project.OutputDirectory -apiVersion $project.ApiVersion -debug:$Debug -newProject:$false)

    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    Write-Host "Building $($project.Name)" -ForegroundColor Cyan
    $testSolution = Get-ChildItem $project.OutputDirectory -Filter "*.slnx" | Select-Object -First 1
    Invoke "dotnet build $($testSolution.FullName)"

    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

# only write new launch settings if no filter was passed in
if ($null -eq $filter) {
    $launchSettings = @{}
    $launchSettings.Add("profiles", @{})

    foreach ($project in $provisioningTypespecProjects) {
        $provisioningSpec = "TestProjects/Local/$($project.Name)"
        $launchSettings["profiles"].Add($project.Name, @{})
        $launchSettings["profiles"][$project.Name].Add("commandLineArgs", "`$(SolutionDir)/../dist/generator/Microsoft.TypeSpec.Generator.dll `$(SolutionDir)/$provisioningSpec -g ProvisioningGenerator")
        $launchSettings["profiles"][$project.Name].Add("commandName", "Executable")
        $launchSettings["profiles"][$project.Name].Add("executablePath", "dotnet")
    }

    $sortedLaunchSettings = @{}
    $sortedLaunchSettings.Add("profiles", [ordered]@{})
    $launchSettings["profiles"].Keys | Sort-Object | ForEach-Object {
        $profileKey = $_
        $originalProfile = $launchSettings["profiles"][$profileKey]

        # Sort the keys inside each profile
        # This is needed due to non deterministic ordering of json elements in powershell
        $sortedProfile = [ordered]@{}
        $originalProfile.GetEnumerator() | Sort-Object Key | ForEach-Object {
            $sortedProfile[$_.Key] = $_.Value
        }

        $sortedLaunchSettings["profiles"][$profileKey] = $sortedProfile
    }

    # Write the launch settings to the launchSettings.json file
    $launchSettingsPath = Join-Path $provisioningSolutionDir "Azure.Generator.Provisioning" "src" "Properties" "launchSettings.json"
    $launchSettingsDir = Split-Path $launchSettingsPath
    if (-not (Test-Path $launchSettingsDir)) {
        New-Item -ItemType Directory -Force -Path $launchSettingsDir | Out-Null
    }
    # Write the settings to JSON and normalize line endings to Unix style (LF)
    $sortedLaunchSettings | ConvertTo-Json | ForEach-Object { ($_ -replace "`r`n", "`n") + "`n" } | Set-Content -NoNewline $launchSettingsPath
}
