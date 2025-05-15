#Requires -Version 7.0
param(
    $filter,
    [bool]$Stubbed = $true,
    [bool]$LaunchOnly = $false
)

Import-Module "$PSScriptRoot\Generation.psm1" -DisableNameChecking -Force;

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

function IsSpecDir {
    param (
        [string]$dir
    )
    $subdirs = Get-ChildItem -Path $dir -Directory
    return -not ($subdirs) -and (Test-Path "$dir/main.tsp")
}

$failingSpecs = @(
    Join-Path 'http' 'payload' 'pageable'
    Join-Path 'http' 'payload' 'xml'
    Join-Path 'http' 'server' 'path' 'multiple'
    Join-Path 'http' 'server' 'versions' 'versioned'
    Join-Path 'http' 'versioning' 'added'
    Join-Path 'http' 'versioning' 'madeOptional'
    Join-Path 'http' 'versioning' 'removed'
    Join-Path 'http' 'versioning' 'renamedFrom'
    Join-Path 'http' 'versioning' 'returnTypeChangedFrom'
    Join-Path 'http' 'versioning' 'typeChangedFrom'
    Join-Path 'http' 'client' 'naming'
    Join-Path 'http' 'resiliency' 'srv-driven'
    Join-Path 'http' 'client' 'structure' 'client-operation-group'
    Join-Path 'http' 'client' 'structure' 'renamed-operation'
    Join-Path 'http' 'client' 'structure' 'multi-client'
    Join-Path 'http' 'client' 'structure' 'two-operation-group'
    Join-Path 'http' 'response' 'status-code-range' # Response namespace conflicts with Azure.Response
    # Azure scenarios not yet buildable
    Join-Path 'http' 'client' 'namespace'
    Join-Path 'http' 'azure' 'client-generator-core' 'access'
    Join-Path 'http' 'azure' 'client-generator-core' 'client-initialization'
    Join-Path 'http' 'azure' 'client-generator-core' 'deserialize-empty-string-as-null'
    Join-Path 'http' 'azure' 'client-generator-core' 'api-version' 'header'
    Join-Path 'http' 'azure' 'client-generator-core' 'api-version' 'path'
    Join-Path 'http' 'azure' 'client-generator-core' 'api-version' 'query'
    Join-Path 'http' 'azure' 'core' 'basic'
    Join-Path 'http' 'azure' 'core' 'lro' 'rpc'
    Join-Path 'http' 'azure' 'core' 'lro' 'standard'
    Join-Path 'http' 'azure' 'core' 'model'
    Join-Path 'http' 'azure' 'core' 'page'
    Join-Path 'http' 'azure' 'core' 'scalar'
    Join-Path 'http' 'azure' 'core' 'traits'
    Join-Path 'http' 'azure' 'encode' 'duration'
    Join-Path 'http' 'azure' 'payload' 'pageable'
    # These scenarios will be covered in Azure.Generator.Management
    Join-Path 'http' 'azure' 'resource-manager' 'common-properties'
    Join-Path 'http' 'azure' 'resource-manager' 'non-resource'
    Join-Path 'http' 'azure' 'resource-manager' 'operation-templates'
    Join-Path 'http' 'azure' 'resource-manager' 'resources'

)

$spectorLaunchProjects = @{}

# Loop through all directories and subdirectories of the spector specs
$directories = @(Get-ChildItem -Path "$specsDirectory/specs" -Directory -Recurse)
$directories += @(Get-ChildItem -Path "$azureSpecsDirectory/specs" -Directory -Recurse)
foreach ($directory in $directories) {
    if (-not (IsSpecDir $directory.FullName)) {
        continue
    }

    $fromAzure = $directory.FullName.Contains("azure-http-specs")

    $specFile = Join-Path $directory.FullName "client.tsp"
    if (-not (Test-Path $specFile)) {
        $specFile = Join-Path $directory.FullName "main.tsp"
    }
    $subPath = if ($fromAzure) {$directory.FullName.Substring($azureSpecsDirectory.Length + 1)} else {$directory.FullName.Substring($specsDirectory.Length + 1)}
    $subPath = $subPath -replace '^specs', 'http' # Keep consistent with the previous folder name because 'http' makes more sense then current 'specs'
    $folders = $subPath.Split([System.IO.Path]::DirectorySeparatorChar)

    if (-not (Compare-Paths $subPath $filter)) {
        continue
    }

    if ($failingSpecs.Contains($subPath)) {
        Write-Host "Skipping $subPath" -ForegroundColor Yellow
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

    if ($folders.Contains("versioning")) {
        Generate-Versioning $directory.FullName $generationDir -generateStub $stubbed
        $spectorLaunchProjects.Add($($folders -join "-") + "-v1", $("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))") + "/v1")
        $spectorLaunchProjects.Add($($folders -join "-") + "-v2", $("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))") + "/v2")
        continue
    }

    # srv-driven contains two separate specs, for two separate clients. We need to generate both.
    if ($folders.Contains("srv-driven")) {
        Generate-Srv-Driven $directory.FullName $generationDir -generateStub $stubbed
        $spectorLaunchProjects.Add($($folders -join "-") + "-v1", $("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))") + "/v1")
        $spectorLaunchProjects.Add($($folders -join "-") + "-v2", $("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))") + "/v2")
        continue
    }

    $spectorLaunchProjects.Add(($folders -join "-"), ("TestProjects/Spector/$($subPath.Replace([System.IO.Path]::DirectorySeparatorChar, '/'))"))
    if ($LaunchOnly) {
        continue
    }

    Write-Host "Generating $subPath" -ForegroundColor Cyan
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
