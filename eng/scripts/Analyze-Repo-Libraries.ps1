<#
.SYNOPSIS
    Analyzes the azure-sdk-for-net repository to categorize libraries.

.DESCRIPTION
    This script analyzes the SDK library structure to determine:
    - Whether each library is Data Plane or Management Plane
    - Whether each library contains only generated code or has custom code
    - The generation method used (AutoRest, TypeSpec, or Manual)
    - The type of customization (extending generated code vs. adding convenience methods)
    - Specific customization patterns used (CodeGen attributes, serialization hooks, etc.)
    - Counts of custom files, partial classes, and new classes
    
    The script distinguishes between:
    - Extended Generated: Partial classes that customize generated code using CodeGen attributes
    - Convenience Only: Completely new classes added (extensions, helpers, custom models)
    - Extended + Convenience: Libraries with both types of customization
    
    The script outputs tables with analysis results and detailed statistics.

.PARAMETER RepoRoot
    The root directory of the azure-sdk-for-net repository. Defaults to current directory.

.PARAMETER OutputFormat
    The output format: Table, CSV, or JSON. Defaults to Table.

.PARAMETER ExportPath
    Optional path to export the results (for CSV or JSON formats).

.EXAMPLE
    .\Analyze-Repo-Libraries.ps1
    Analyzes the repo and displays results as a table.

.EXAMPLE
    .\Analyze-Repo-Libraries.ps1 -OutputFormat CSV -ExportPath ".\library-analysis.csv"
    Exports results to a CSV file.
#>

param(
    [Parameter()]
    [string]$RepoRoot = (Get-Location),
    
    [Parameter()]
    [ValidateSet('Table', 'CSV', 'JSON')]
    [string]$OutputFormat = 'Table',
    
    [Parameter()]
    [string]$ExportPath
)

$ErrorActionPreference = 'Stop'

# Ensure we're at the repo root
$sdkPath = Join-Path $RepoRoot "sdk"
if (-not (Test-Path $sdkPath)) {
    Write-Error "SDK directory not found at: $sdkPath. Please specify the correct RepoRoot."
    exit 1
}

Write-Host "Analyzing libraries in: $sdkPath" -ForegroundColor Cyan
Write-Host ""

function Get-LibraryType {
    param (
        [string]$PackageName
    )
    
    # Management plane libraries typically have Azure.ResourceManager prefix
    if ($PackageName -like "Azure.ResourceManager.*" -or $PackageName -like "*.Management.*") {
        return "Management"
    }
    
    return "Data Plane"
}

function Get-GenerationMethod {
    param (
        [string]$LibraryPath
    )
    
    $srcPath = Join-Path $LibraryPath "src"
    
    if (-not (Test-Path $srcPath)) {
        return "Unknown"
    }
    
    # Check for TypeSpec generation
    $tspLocationFile = Join-Path $LibraryPath "tsp-location.yaml"
    if (Test-Path $tspLocationFile) {
        return "TypeSpec"
    }
    
    # Check for AutoRest generation
    $autorestFile = Join-Path $srcPath "autorest.md"
    if (Test-Path $autorestFile) {
        return "AutoRest"
    }
    
    # If no generation config found, likely manual
    return "Manual"
}

function Get-CustomizationDetails {
    param (
        [string]$LibraryPath,
        [string]$GenerationMethod
    )
    
    $srcPath = Join-Path $LibraryPath "src"
    
    $result = [PSCustomObject]@{
        HasCustomCode = $false
        CustomFileCount = 0
        PartialClassCount = 0
        NewClassCount = 0
        CustomizationType = "None"
        CustomizationPatterns = @()
    }
    
    if (-not (Test-Path $srcPath)) {
        return $result
    }
    
    # Get all .cs files in src
    $allCsFiles = Get-ChildItem -Path $srcPath -Filter "*.cs" -Recurse -File
    
    if ($allCsFiles.Count -eq 0) {
        return $result
    }
    
    # Check for Generated folder
    $generatedPath = Join-Path $srcPath "Generated"
    $hasGeneratedFolder = Test-Path $generatedPath
    
    if ($GenerationMethod -eq "Manual") {
        # If manual, all code is custom
        $result.HasCustomCode = $true
        $result.CustomFileCount = $allCsFiles.Count
        $result.NewClassCount = $allCsFiles.Count
        $result.CustomizationType = "Custom Only"
        return $result
    }
    
    if (-not $hasGeneratedFolder) {
        # No Generated folder means all custom code (or old structure)
        $result.HasCustomCode = $true
        $result.CustomFileCount = $allCsFiles.Count
        $result.NewClassCount = $allCsFiles.Count
        $result.CustomizationType = "Custom Only"
        return $result
    }
    
    # Get files outside Generated folder (excluding obj/bin and build artifacts)
    $customFiles = $allCsFiles | Where-Object { 
        $_.FullName -notlike "*\Generated\*" -and 
        $_.FullName -notlike "*\obj\*" -and 
        $_.FullName -notlike "*\bin\*" -and
        $_.Name -ne "AssemblyInfo.cs"
    }
    
    if ($customFiles.Count -eq 0) {
        return $result
    }
    
    $result.HasCustomCode = $true
    $result.CustomFileCount = $customFiles.Count
    
    # Analyze each custom file to determine type of customization
    $partialClasses = @()
    $newClasses = @()
    $patterns = @{}
    
    foreach ($file in $customFiles) {
        $content = Get-Content -Path $file.FullName -Raw
        
        # Check if it's a partial class (extending generated code)
        if ($content -match '\bpartial\s+(class|struct|interface)') {
            $partialClasses += $file
            
            # Detect specific customization patterns
            if ($content -match '\[CodeGenType\(') { $patterns['TypeRename'] = $true }
            if ($content -match '\[CodeGenMember\(') { $patterns['MemberRename'] = $true }
            if ($content -match '\[CodeGenSuppress\(') { $patterns['MemberSuppression'] = $true }
            if ($content -match '\[CodeGenSerialization\(') { $patterns['SerializationCustom'] = $true }
            if ($content -match 'SerializationValueHook|DeserializationValueHook') { $patterns['SerializationHooks'] = $true }
        } else {
            $newClasses += $file
            
            # Categorize new classes by common patterns
            if ($file.Name -like "*Extensions.cs") { $patterns['ClientExtensions'] = $true }
            if ($file.Name -like "*Options.cs") { $patterns['CustomOptions'] = $true }
            if ($file.Name -like "*Builder.cs") { $patterns['Builders'] = $true }
            if ($file.DirectoryName -like "*\Models\*" -and $file.DirectoryName -notlike "*\Generated\*") { $patterns['CustomModels'] = $true }
            if ($file.DirectoryName -like "*\Sas\*") { $patterns['SasSupport'] = $true }
        }
    }
    
    $result.PartialClassCount = $partialClasses.Count
    $result.NewClassCount = $newClasses.Count
    $result.CustomizationPatterns = $patterns.Keys | Sort-Object
    
    # Determine overall customization type
    if ($partialClasses.Count -gt 0 -and $newClasses.Count -gt 0) {
        $result.CustomizationType = "Extended + Convenience"
    } elseif ($partialClasses.Count -gt 0) {
        $result.CustomizationType = "Extended Generated"
    } else {
        $result.CustomizationType = "Convenience Only"
    }
    
    return $result
}

function Get-CodeCompositionSummary {
    param (
        [PSCustomObject]$CustomizationDetails,
        [string]$GenerationMethod
    )
    
    if ($GenerationMethod -eq "Manual") {
        return "Custom Only"
    }
    
    if ($CustomizationDetails.HasCustomCode) {
        return "Generated + Custom"
    }
    
    return "Generated Only"
}

# Get all library directories
$libraries = Get-ChildItem -Path $sdkPath -Directory | ForEach-Object {
    $servicePath = $_.FullName
    
    # Find all library projects (directories with .csproj files in src folder)
    Get-ChildItem -Path $servicePath -Directory | Where-Object {
        $srcPath = Join-Path $_.FullName "src"
        if (Test-Path $srcPath) {
            $csprojFiles = Get-ChildItem -Path $srcPath -Filter "*.csproj" -File
            return $csprojFiles.Count -gt 0
        }
        return $false
    } | ForEach-Object {
        $libraryPath = $_.FullName
        $packageName = $_.Name
        
        Write-Verbose "Analyzing: $packageName"
        
        $libraryType = Get-LibraryType -PackageName $packageName
        $generationMethod = Get-GenerationMethod -LibraryPath $libraryPath
        $customization = Get-CustomizationDetails -LibraryPath $libraryPath -GenerationMethod $generationMethod
        $codeComposition = Get-CodeCompositionSummary -CustomizationDetails $customization -GenerationMethod $generationMethod
        
        [PSCustomObject]@{
            PackageName = $packageName
            ServiceFolder = Split-Path $servicePath -Leaf
            LibraryType = $libraryType
            GenerationMethod = $generationMethod
            CodeComposition = $codeComposition
            CustomizationType = $customization.CustomizationType
            CustomFileCount = $customization.CustomFileCount
            PartialClassCount = $customization.PartialClassCount
            NewClassCount = $customization.NewClassCount
            CustomizationPatterns = ($customization.CustomizationPatterns -join ', ')
            HasCustomCode = $customization.HasCustomCode
            Path = $libraryPath -replace [regex]::Escape($RepoRoot), '.' -replace '\\', '/'
        }
    }
}

Write-Host "Found $($libraries.Count) libraries" -ForegroundColor Green
Write-Host ""

# Summary statistics
$mgmtCount = ($libraries | Where-Object LibraryType -eq "Management").Count
$dataPlaneCount = ($libraries | Where-Object LibraryType -eq "Data Plane").Count
$generatedOnlyCount = ($libraries | Where-Object CodeComposition -eq "Generated Only").Count
$generatedCustomCount = ($libraries | Where-Object CodeComposition -eq "Generated + Custom").Count
$customOnlyCount = ($libraries | Where-Object CodeComposition -eq "Custom Only").Count
$typeSpecCount = ($libraries | Where-Object GenerationMethod -eq "TypeSpec").Count
$autoRestCount = ($libraries | Where-Object GenerationMethod -eq "AutoRest").Count
$manualCount = ($libraries | Where-Object GenerationMethod -eq "Manual").Count

# Customization type statistics
$extendedAndConvenience = ($libraries | Where-Object CustomizationType -eq "Extended + Convenience").Count
$extendedGenerated = ($libraries | Where-Object CustomizationType -eq "Extended Generated").Count
$convenienceOnly = ($libraries | Where-Object CustomizationType -eq "Convenience Only").Count

Write-Host "Summary:" -ForegroundColor Yellow
Write-Host "  Library Types:"
Write-Host "    Management Plane: $mgmtCount"
Write-Host "    Data Plane: $dataPlaneCount"
Write-Host ""
Write-Host "  Code Composition:"
Write-Host "    Generated Only: $generatedOnlyCount"
Write-Host "    Generated + Custom: $generatedCustomCount"
Write-Host "    Custom Only: $customOnlyCount"
Write-Host ""
Write-Host "  Customization Types (for libraries with custom code):"
Write-Host "    Extended Generated + Convenience: $extendedAndConvenience"
Write-Host "    Extended Generated Only: $extendedGenerated"
Write-Host "    Convenience Only: $convenienceOnly"
Write-Host ""
Write-Host "  Generation Methods:"
Write-Host "    TypeSpec: $typeSpecCount"
Write-Host "    AutoRest: $autoRestCount"
Write-Host "    Manual: $manualCount"
Write-Host ""
Write-Host "    Generated + Custom: $generatedCustomCount"
Write-Host "    Custom Only: $customOnlyCount"
Write-HoWrite-Host "Library Overview:" -ForegroundColor Cyan
        $libraries | Sort-Object LibraryType, ServiceFolder | 
            Format-Table -Property PackageName, LibraryType, GenerationMethod, CodeComposition, CustomizationType -AutoSize
        
        Write-Host "`nLibraries with Customizations (showing details):" -ForegroundColor Cyan
        $libraries | Where-Object HasCustomCode | Sort-Object -Property CustomFileCount -Descending |
            Format-Table -Property PackageName, CustomizationType, CustomFileCount, PartialClassCount, NewClassCount, CustomizationPatterns
Write-Host "    TypeSpec: $typeSpecCount"
Write-Host "    AutoRest: $autoRestCount"
Write-Host "    Manual: $manualCount"
Write-Host ""

# Output results based on format
switch ($OutputFormat) {
    'Table' {
        $libraries | Sort-Object LibraryType, ServiceFolder | 
            Format-Table -Property PackageName, LibraryType, GenerationMethod, CodeComposition -AutoSize
    }
    'CSV' {
        if ($ExportPath) {
            $libraries | Export-Csv -Path $ExportPath -NoTypeInformation
            Write-Host "Results exported to: $ExportPath" -ForegroundColor Green
        } else {
            $libraries | ConvertTo-Csv -NoTypeInformation
        }
    }
    'JSON' {
        if ($ExportPath) {
            $libraries | ConvertTo-Json | Set-Content -Path $ExportPath
            Write-Host "Results exported to: $ExportPath" -ForegroundColor Green
        } else {
            $libraries | ConvertTo-Json
        }
    }
}

# Return the libraries object for pipeline usage
return $libraries
