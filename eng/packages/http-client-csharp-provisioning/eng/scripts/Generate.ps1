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

if ($null -eq $filter -or $filter -eq "Provisioning-TypeSpec") {
    Write-Host "Generating ProvisioningTypeSpec" -ForegroundColor Cyan
    $testProjectsLocalDir = Join-Path $provisioningPackageRoot 'generator' 'TestProjects' 'Local'

    $provisioningTypespecTestProject = Join-Path $testProjectsLocalDir "Provisioning-TypeSpec"

    Invoke (Get-Provisioning-TspCommand "$provisioningTypespecTestProject/main.tsp" $provisioningTypespecTestProject -debug:$Debug)

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    Write-Host "Building ProvisioningTypeSpec" -ForegroundColor Cyan
    $testCsproj = Get-ChildItem "$provisioningPackageRoot/generator/TestProjects/Local/Provisioning-TypeSpec/src" -Filter "*.csproj" | Select-Object -First 1
    Invoke "dotnet build $($testCsproj.FullName)"

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

# only write new launch settings if no filter was passed in
if ($null -eq $filter) {
    $provisioningSpec = "TestProjects/Local/Provisioning-TypeSpec"

    # Write the launch settings for Provisioning
    $launchSettings = @{}
    $launchSettings.Add("profiles", @{})
    $launchSettings["profiles"].Add("Provisioning-TypeSpec", @{})
    $launchSettings["profiles"]["Provisioning-TypeSpec"].Add("commandLineArgs", "`$(SolutionDir)/../dist/generator/Microsoft.TypeSpec.Generator.dll `$(SolutionDir)/$provisioningSpec -g ProvisioningGenerator")
    $launchSettings["profiles"]["Provisioning-TypeSpec"].Add("commandName", "Executable")
    $launchSettings["profiles"]["Provisioning-TypeSpec"].Add("executablePath", "dotnet")

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
