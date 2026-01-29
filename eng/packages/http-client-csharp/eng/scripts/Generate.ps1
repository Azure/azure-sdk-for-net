#Requires -Version 7.0
param(
    $filter,
    [bool]$Stubbed = $true,
    [bool]$LaunchOnly = $false
)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;
Import-Module "$PSScriptRoot\Spector-Helper.psm1" -DisableNameChecking -Force;

# Start overall timer
$totalStopwatch = [System.Diagnostics.Stopwatch]::StartNew()

Write-Host "Script root: $PSScriptRoot" -ForegroundColor Cyan
$packageRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')
Write-Host "Package root: $packageRoot" -ForegroundColor Cyan
$solutionDir = Join-Path $packageRoot 'generator'

if (-not $LaunchOnly) {
    Refresh-Build

    if ($null -eq $filter -or $filter -eq "Basic-TypeSpec") {
        Write-Host "Generating BasicTypeSpec" -ForegroundColor Cyan
        $testProjectsLocalDir = Join-Path $packageRoot 'generator' 'TestProjects' 'Local'

        $basicTypespecTestProject = Join-Path $testProjectsLocalDir "Basic-TypeSpec"

        Invoke (Get-TspCommand "$basicTypespecTestProject/Basic-TypeSpec.tsp" $basicTypespecTestProject)

        # exit if the generation failed
        if ($LASTEXITCODE -ne 0) {
            exit $LASTEXITCODE
        }

        Write-Host "Building BasicTypeSpec" -ForegroundColor Cyan
        Invoke "dotnet build $packageRoot/generator/TestProjects/Local/Basic-TypeSpec/src/BasicTypeSpec.csproj"

        # exit if the generation failed
        if ($LASTEXITCODE -ne 0) {
            exit $LASTEXITCODE
        }
    }
}

$specsDirectory = "$packageRoot/node_modules/@typespec/http-specs"
$azureSpecsDirectory = "$packageRoot/node_modules/@azure-tools/azure-http-specs"
$spectorRoot = Join-Path $packageRoot 'generator' 'TestProjects' 'Spector'

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

    if ($folders.Contains("versioning")) {
        Generate-Versioning (Split-Path $specFile) $generationDir -generateStub $stubbed
        $spectorLaunchProjects.Add($($folders -join "-") + "-v1", $("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))") + "/v1")
        $spectorLaunchProjects.Add($($folders -join "-") + "-v2", $("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))") + "/v2")
        continue
    }

    # srv-driven contains two separate specs, for two separate clients. We need to generate both.
    if ($folders.Contains("srv-driven")) {
        Generate-Srv-Driven (Split-Path $specFile) $generationDir -generateStub $stubbed
        $spectorLaunchProjects.Add($($folders -join "-") + "-v1", $("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))") + "/v1")
        $spectorLaunchProjects.Add($($folders -join "-") + "-v2", $("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))") + "/v2")
        continue
    }

    $spectorLaunchProjects.Add(($folders -join "-"), ("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))"))
    if ($LaunchOnly) {
        continue
    }

    Invoke (Get-TspCommand $specFile $generationDir $stubbed)

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

# only write new launch settings if no filter was passed in
if ($null -eq $filter) {
    Write-Host "Writing new launch settings" -ForegroundColor Cyan
    $mgcExe = "`$(SolutionDir)/../dist/generator/Microsoft.Generator.CSharp.exe"
    $basicSpec = "TestProjects/Local/Basic-TypeSpec"

    $launchSettings = @{}
    $launchSettings.Add("profiles", @{})
    $launchSettings["profiles"].Add("Basic-TypeSpec", @{})
    $launchSettings["profiles"]["Basic-TypeSpec"].Add("commandLineArgs", "`$(SolutionDir)/../dist/generator/Microsoft.TypeSpec.Generator.dll `$(SolutionDir)/$basicSpec -g AzureClientGenerator")
    $launchSettings["profiles"]["Basic-TypeSpec"].Add("commandName", "Executable")
    $launchSettings["profiles"]["Basic-TypeSpec"].Add("executablePath", "dotnet")

    foreach ($kvp in $spectorLaunchProjects.GetEnumerator()) {
        $launchSettings["profiles"].Add($kvp.Key, @{})
        $launchSettings["profiles"][$kvp.Key].Add("commandLineArgs", "`$(SolutionDir)/../dist/generator/Microsoft.TypeSpec.Generator.dll `$(SolutionDir)/$($kvp.Value) -g AzureStubGenerator")
        $launchSettings["profiles"][$kvp.Key].Add("commandName", "Executable")
        $launchSettings["profiles"][$kvp.Key].Add("executablePath", "dotnet")
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
    $launchSettingsPath = Join-Path $solutionDir "Azure.Generator" "src" "Properties" "launchSettings.json"
    # Write the settings to JSON and normalize line endings to Unix style (LF)
    $sortedLaunchSettings | ConvertTo-Json | ForEach-Object { ($_ -replace "`r`n", "`n") + "`n" } | Set-Content -NoNewline $launchSettingsPath
}

# Stop total timer
$totalStopwatch.Stop()

# Display timing summary
Write-Host "`n==================== TIMING SUMMARY ====================" -ForegroundColor Cyan
Write-Host "Total execution time: $($totalStopwatch.Elapsed.ToString('hh\:mm\:ss\.ff'))" -ForegroundColor Yellow
