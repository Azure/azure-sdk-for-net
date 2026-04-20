# Run a specific .NET SDK sample for Azure AI Content Understanding
# This script extracts code from sample markdown files and builds a standalone console project.
# By default, it only builds the project. Use -Run to also execute it.
#
# Usage: .\run-sample.ps1 -SampleName Sample02_AnalyzeUrl
#        .\run-sample.ps1 -SampleName Sample02_AnalyzeUrl -Run
#        .\run-sample.ps1 -SampleName Sample01_AnalyzeBinary -FilePath C:\path\to\doc.pdf
#        .\run-sample.ps1 -List

param(
    [string]$SampleName = "",
    [switch]$List,
    [switch]$Run,
    [string]$FilePath = "",
    [switch]$Help
)

function Write-ColorOutput {
    param([string]$Message, [string]$Color = "White")
    Write-Host $Message -ForegroundColor $Color
}

# ─── Paths ─────────────────────────────────────────────────────────────────────
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$packageRoot = Resolve-Path (Join-Path $scriptDir "..\..\..\..") | Select-Object -ExpandProperty Path
$samplesDir = Join-Path $packageRoot "samples"
$runnerBase = Join-Path $packageRoot ".sample_runner"
$localSrcDir = Join-Path $packageRoot "src"
$appsettingsPath = Join-Path $packageRoot "appsettings.json"

# ─── Ensure .NET SDK is available ─────────────────────────────────────────────
function Ensure-DotnetSdk {
    # Determine which .NET versions we need
    $requiredChannels = @("10.0")  # Need 10.0 for sample runner and source builds

    # Check if repo's global.json requires a different version
    $repoGlobalJson = Join-Path $packageRoot ".." ".." ".." "global.json"
    if (Test-Path $repoGlobalJson) {
        try {
            $gj = Get-Content $repoGlobalJson -Raw | ConvertFrom-Json
            if ($gj.sdk.version) {
                $major = ($gj.sdk.version -split '\.')[0]
                if ($major -and [int]$major -gt 10) {
                    $requiredChannels += "$major.0"
                }
            }
        } catch { }
    }

    $dotnetCmd = Get-Command dotnet -ErrorAction SilentlyContinue
    if (-not $dotnetCmd) {
        # Check common install location
        $homeDotnet = Join-Path $env:HOME ".dotnet" "dotnet"
        if ($IsWindows) { $homeDotnet = Join-Path $env:USERPROFILE ".dotnet" "dotnet.exe" }
        if (Test-Path $homeDotnet) {
            $dotnetDir = Split-Path $homeDotnet
            $env:PATH = "$dotnetDir$([IO.Path]::PathSeparator)$env:PATH"
            $env:DOTNET_ROOT = $dotnetDir
            $dotnetCmd = Get-Command dotnet -ErrorAction SilentlyContinue
        }
    }

    if ($dotnetCmd) {
        Write-ColorOutput "dotnet found: $($dotnetCmd.Source)" "Blue"
        # Check installed SDKs
        $installedSdks = dotnet --list-sdks 2>$null
        $installedMajors = $installedSdks | ForEach-Object { ($_ -split '\.')[0] } | Select-Object -Unique

        $missingChannels = @()
        foreach ($ch in $requiredChannels) {
            $major = ($ch -split '\.')[0]
            if ($major -notin $installedMajors) {
                $missingChannels += $ch
            }
        }

        if ($missingChannels.Count -eq 0) {
            Write-ColorOutput "All required .NET SDKs are installed." "Blue"
            return
        }
    } else {
        $missingChannels = $requiredChannels
    }

    foreach ($channel in $missingChannels) {
        Write-ColorOutput "Installing .NET $channel SDK..." "Yellow"
        try {
            if ($IsWindows) {
                $installScript = Join-Path $env:TEMP "dotnet-install.ps1"
                Invoke-WebRequest -Uri "https://dot.net/v1/dotnet-install.ps1" -OutFile $installScript -UseBasicParsing
                & $installScript -Channel $channel
            } else {
                $installScript = Join-Path ([IO.Path]::GetTempPath()) "dotnet-install.sh"
                if (-not (Test-Path $installScript)) {
                    Invoke-WebRequest -Uri "https://dot.net/v1/dotnet-install.sh" -OutFile $installScript -UseBasicParsing
                }
                bash $installScript --channel $channel
            }
        } catch {
            Write-ColorOutput "Warning: Failed to install .NET $channel SDK: $_" "Yellow"
        }
    }

    $homeDir = if ($IsWindows) { $env:USERPROFILE } else { $env:HOME }
    $dotnetDir = Join-Path $homeDir ".dotnet"
    $env:PATH = "$dotnetDir$([IO.Path]::PathSeparator)$env:PATH"
    $env:DOTNET_ROOT = $dotnetDir
    Write-ColorOutput ".NET SDK setup complete." "Green"
}

Ensure-DotnetSdk

# ─── Help ──────────────────────────────────────────────────────────────────────
if ($Help) {
    Write-ColorOutput "Usage: .\run-sample.ps1 -SampleName <name> [options]" "Yellow"
    Write-Host ""
    Write-ColorOutput "Options:" "Yellow"
    Write-Host "  -SampleName <name>   Name of the sample (e.g., Sample02_AnalyzeUrl)"
    Write-Host "  -List                List available samples"
    Write-Host "  -Run                 Run the sample after building (default: build only)"
    Write-Host "  -FilePath <path>     Local file path (for samples that need a file)"
    Write-Host "  -Help                Show this help"
    Write-Host ""
    Write-ColorOutput "Examples:" "Yellow"
    Write-Host "  .\run-sample.ps1 -SampleName Sample02_AnalyzeUrl"
    Write-Host "  .\run-sample.ps1 -SampleName Sample02_AnalyzeUrl -Run"
    Write-Host "  .\run-sample.ps1 -SampleName Sample01_AnalyzeBinary -FilePath C:\docs\invoice.pdf"
    Write-Host "  .\run-sample.ps1 -List"
    exit 0
}

# ─── List samples ─────────────────────────────────────────────────────────────
if ($List) {
    Write-Host ""
    Write-ColorOutput "=== Available Samples ===" "Blue"
    Get-ChildItem -Path $samplesDir -Filter "Sample*.md" | Sort-Object Name | ForEach-Object {
        $name = $_.BaseName
        $firstLine = Get-Content $_.FullName -TotalCount 5 | Where-Object { $_ -match '^# ' } | Select-Object -First 1
        $desc = if ($firstLine) { $firstLine -replace '^# ', '' } else { "" }
        Write-Host ("  {0,-30} {1}" -f $name, $desc) -ForegroundColor Cyan
    }
    Write-Host ""
    exit 0
}

# ─── Validate input ───────────────────────────────────────────────────────────
if ([string]::IsNullOrEmpty($SampleName)) {
    Write-ColorOutput "Error: No sample name provided" "Red"
    Write-Host ""
    Write-Host "Usage: .\run-sample.ps1 -SampleName <name>"
    Write-Host "Run '.\run-sample.ps1 -List' to see available samples"
    exit 1
}

# Normalize
$SampleName = $SampleName -replace '\.md$', ''

$sampleFile = Join-Path $samplesDir "$SampleName.md"
if (-not (Test-Path $sampleFile)) {
    Write-ColorOutput "Error: Sample not found: $sampleFile" "Red"
    Write-Host ""
    Write-Host "Did you mean one of these?"
    Get-ChildItem -Path $samplesDir -Filter "Sample*.md" |
        Where-Object { $_.BaseName -match ($SampleName -replace 'Sample\d*_?', '') } |
        ForEach-Object { Write-Host "  $($_.BaseName)" -ForegroundColor Cyan }
    Write-Host ""
    Write-Host "Run '.\run-sample.ps1 -List' to see all available samples"
    exit 1
}

# ─── Load configuration ──────────────────────────────────────────────────────
$endpoint = $env:CONTENTUNDERSTANDING_ENDPOINT
$apiKeyVal = $env:AZURE_CONTENT_UNDERSTANDING_KEY
$targetEndpoint = $env:CONTENTUNDERSTANDING_TARGET_ENDPOINT
$targetResourceId = $env:AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID
$sourceEndpoint = $env:CONTENTUNDERSTANDING_SOURCE_ENDPOINT
$sourceResourceId = $env:AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID
$sourceRegion = $env:AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION
$targetRegion = $env:AZURE_CONTENT_UNDERSTANDING_TARGET_REGION
$gpt41Deployment = if ($env:GPT_4_1_DEPLOYMENT) { $env:GPT_4_1_DEPLOYMENT } else { "gpt-4.1" }
$gpt41MiniDeployment = if ($env:GPT_4_1_MINI_DEPLOYMENT) { $env:GPT_4_1_MINI_DEPLOYMENT } else { "gpt-4.1-mini" }
$embeddingDeployment = if ($env:TEXT_EMBEDDING_3_LARGE_DEPLOYMENT) { $env:TEXT_EMBEDDING_3_LARGE_DEPLOYMENT } else { "text-embedding-3-large" }

if (Test-Path $appsettingsPath) {
    Write-ColorOutput "Loading settings from appsettings.json..." "Blue"
    try {
        $settings = Get-Content $appsettingsPath -Raw | ConvertFrom-Json
        if ([string]::IsNullOrEmpty($endpoint) -and $settings.CONTENTUNDERSTANDING_ENDPOINT) {
            $endpoint = $settings.CONTENTUNDERSTANDING_ENDPOINT
        }
        if ([string]::IsNullOrEmpty($apiKeyVal) -and $settings.AZURE_CONTENT_UNDERSTANDING_KEY) {
            $apiKeyVal = $settings.AZURE_CONTENT_UNDERSTANDING_KEY
        }
        if ([string]::IsNullOrEmpty($targetEndpoint) -and $settings.CONTENTUNDERSTANDING_TARGET_ENDPOINT) {
            $targetEndpoint = $settings.CONTENTUNDERSTANDING_TARGET_ENDPOINT
        }
        if ([string]::IsNullOrEmpty($targetResourceId) -and $settings.AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID) {
            $targetResourceId = $settings.AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID
        }
        if ([string]::IsNullOrEmpty($sourceEndpoint) -and $settings.CONTENTUNDERSTANDING_SOURCE_ENDPOINT) {
            $sourceEndpoint = $settings.CONTENTUNDERSTANDING_SOURCE_ENDPOINT
        }
        if ([string]::IsNullOrEmpty($sourceResourceId) -and $settings.AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID) {
            $sourceResourceId = $settings.AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID
        }
        if ([string]::IsNullOrEmpty($sourceRegion) -and $settings.AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION) {
            $sourceRegion = $settings.AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION
        }
        if ([string]::IsNullOrEmpty($targetRegion) -and $settings.AZURE_CONTENT_UNDERSTANDING_TARGET_REGION) {
            $targetRegion = $settings.AZURE_CONTENT_UNDERSTANDING_TARGET_REGION
        }
        if ($settings.GPT_4_1_DEPLOYMENT) {
            $gpt41Deployment = $settings.GPT_4_1_DEPLOYMENT
        }
        if ($settings.GPT_4_1_MINI_DEPLOYMENT) {
            $gpt41MiniDeployment = $settings.GPT_4_1_MINI_DEPLOYMENT
        }
        if ($settings.TEXT_EMBEDDING_3_LARGE_DEPLOYMENT) {
            $embeddingDeployment = $settings.TEXT_EMBEDDING_3_LARGE_DEPLOYMENT
        }
    } catch {
        Write-ColorOutput "Warning: Could not parse appsettings.json: $_" "Yellow"
    }
} elseif ([string]::IsNullOrEmpty($endpoint)) {
    Write-ColorOutput "`n=== First-time Setup ===" "Cyan"
    Write-ColorOutput "No appsettings.json found and CONTENTUNDERSTANDING_ENDPOINT not set." "Yellow"
    Write-ColorOutput "Let's create appsettings.json in: $packageRoot`n" "Yellow"

    $inputEndpoint = Read-Host "Enter your Content Understanding endpoint URL (e.g. https://your-foundry.services.ai.azure.com/)"
    if ([string]::IsNullOrEmpty($inputEndpoint)) {
        Write-ColorOutput "Error: Endpoint is required." "Red"
        exit 1
    }
    $endpoint = $inputEndpoint

    $inputApiKey = Read-Host "Enter API key (leave blank to use DefaultAzureCredential - recommended)"
    $apiKeyVal = $inputApiKey

    # Build the settings object
    $newSettings = [ordered]@{
        CONTENTUNDERSTANDING_ENDPOINT = $endpoint
    }
    if (-not [string]::IsNullOrEmpty($apiKeyVal)) {
        $newSettings.AZURE_CONTENT_UNDERSTANDING_KEY = $apiKeyVal
    }

    $newSettings | ConvertTo-Json | Set-Content -Path $appsettingsPath
    Write-ColorOutput "`nCreated appsettings.json at: $appsettingsPath" "Green"
}

if ([string]::IsNullOrEmpty($endpoint)) {
    Write-ColorOutput "Error: CONTENTUNDERSTANDING_ENDPOINT is not configured." "Red"
    Write-ColorOutput "Set it in appsettings.json or as an environment variable." "Red"
    exit 1
}

Write-ColorOutput "Endpoint: $endpoint" "Blue"
if (-not [string]::IsNullOrEmpty($apiKeyVal)) {
    Write-ColorOutput "Auth: API Key" "Blue"
} else {
    Write-ColorOutput "Auth: DefaultAzureCredential" "Blue"
}

# ─── Extract code from markdown ──────────────────────────────────────────────
Write-ColorOutput "`n=== Extracting code from: $SampleName ===" "Blue"

$mdContent = Get-Content $sampleFile -Raw

# Extract C# code blocks
$codeBlocks = [regex]::Matches($mdContent, '```(?:C#\s+Snippet:\w+|csharp)\s*\n(.*?)```', [System.Text.RegularExpressions.RegexOptions]::Singleline)

if ($codeBlocks.Count -eq 0) {
    Write-ColorOutput "Error: No C# code blocks found in $sampleFile" "Red"
    exit 1
}

# Deduplicate client creation snippets
$seenDefaultClient = $false
$seenApiKeyClient = $false
$filteredBlocks = @()

foreach ($block in $codeBlocks) {
    $code = $block.Groups[1].Value

    $isDefault = ($code -match '<endpoint>') -and ($code -match 'DefaultAzureCredential') -and ($code -notmatch 'AzureKeyCredential')
    $isApiKey = ($code -match '<apiKey>') -and ($code -match 'AzureKeyCredential')

    if ($isDefault) {
        if ($seenDefaultClient) { continue }
        $seenDefaultClient = $true
    }
    if ($isApiKey) {
        if ($seenApiKeyClient) { continue }
        $seenApiKeyClient = $true
        # Skip API key variant — we handle auth in the wrapper
        continue
    }

    $filteredBlocks += $code
}

# ─── Create temporary project ────────────────────────────────────────────────
Write-ColorOutput "=== Building sample project ===" "Blue"

$runnerDir = Join-Path $runnerBase $SampleName
if (Test-Path $runnerDir) { Remove-Item $runnerDir -Recurse -Force }
New-Item -ItemType Directory -Path $runnerDir -Force | Out-Null

# Initialize .sample_runner/ with all required scaffolding files
# (assumes the directory starts clean and creates everything at runtime)
if (-not (Test-Path $runnerBase)) {
    New-Item -ItemType Directory -Path $runnerBase -Force | Out-Null
}

# global.json: use net10.0 with latestMajor rollForward for sample projects
$runnerGlobalJson = Join-Path $runnerBase "global.json"
if (-not (Test-Path $runnerGlobalJson)) {
    @'
{
  "sdk": {
    "version": "10.0.0",
    "rollForward": "latestMajor"
  }
}
'@ | Set-Content -Path $runnerGlobalJson
}

# Isolate from repo's MSBuild central package management and NuGet feeds
if (-not (Test-Path (Join-Path $runnerBase "Directory.Build.props"))) {
    Set-Content -Path (Join-Path $runnerBase "Directory.Build.props") -Value '<Project />'
    Set-Content -Path (Join-Path $runnerBase "Directory.Build.targets") -Value '<Project />'
    Set-Content -Path (Join-Path $runnerBase "Directory.Packages.props") -Value '<Project />'
    Set-Content -Path (Join-Path $runnerBase "NuGet.Config") -Value @'
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
'@
}

# Resolve SDK reference: try NuGet first, fall back to local build
$localSrcCsproj = Join-Path $localSrcDir "Azure.AI.ContentUnderstanding.csproj"
$useLocalSrc = $false
$dllPath = ""

Write-ColorOutput "Checking if Azure.AI.ContentUnderstanding NuGet package is available..." "Blue"
$nugetAvailable = $false
$nugetCheckDir = Join-Path ([IO.Path]::GetTempPath()) "nuget_check_$(Get-Random)"
New-Item -ItemType Directory -Path $nugetCheckDir -Force | Out-Null

$checkCsproj = @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Azure.AI.ContentUnderstanding" Version="1.0.0-*" />
  </ItemGroup>
</Project>
'@
Set-Content -Path (Join-Path $nugetCheckDir "check.csproj") -Value $checkCsproj
# Copy isolation files so the check project uses nuget.org only
$runnerGlobalJsonPath = Join-Path $runnerBase "global.json"
if (Test-Path $runnerGlobalJsonPath) { Copy-Item $runnerGlobalJsonPath $nugetCheckDir }
Set-Content -Path (Join-Path $nugetCheckDir "Directory.Build.props") -Value '<Project />'
Set-Content -Path (Join-Path $nugetCheckDir "Directory.Build.targets") -Value '<Project />'
Set-Content -Path (Join-Path $nugetCheckDir "Directory.Packages.props") -Value '<Project />'
$runnerNugetConfig = Join-Path $runnerBase "NuGet.Config"
if (Test-Path $runnerNugetConfig) { Copy-Item $runnerNugetConfig $nugetCheckDir }

Push-Location $nugetCheckDir
try {
    $restoreOutput = dotnet restore check.csproj 2>&1
    if ($LASTEXITCODE -eq 0) {
        $nugetAvailable = $true
        Write-ColorOutput "NuGet package Azure.AI.ContentUnderstanding found. Using public NuGet." "Green"
    }
} finally {
    Pop-Location
}
Remove-Item -Recurse -Force $nugetCheckDir -ErrorAction SilentlyContinue

if (-not $nugetAvailable) {
    Write-ColorOutput "NuGet package not available. Attempting local SDK build..." "Yellow"
    if (Test-Path $localSrcCsproj) {
        Write-ColorOutput "Building local SDK from: $localSrcDir" "Blue"
        Push-Location $runnerBase
        try {
            $buildOutput = dotnet build $localSrcCsproj -c Release 2>&1
            $sdkBuildExitCode = $LASTEXITCODE
        } finally {
            Pop-Location
        }
        if ($sdkBuildExitCode -ne 0) {
            Write-ColorOutput "Error: Failed to build local SDK and NuGet package is not available." "Red"
            $buildOutput | ForEach-Object { Write-Host $_ }
            exit 1
        } else {
            Write-ColorOutput "Local SDK build succeeded." "Green"
            $useLocalSrc = $true
            # Find the built DLL - repo uses artifacts/ output directory
            $repoRoot = Resolve-Path (Join-Path $packageRoot ".." ".." "..") | Select-Object -ExpandProperty Path
            $artifactsDir = Join-Path $repoRoot "artifacts" "bin" "Azure.AI.ContentUnderstanding"
            $builtDll = Get-ChildItem -Path $artifactsDir -Recurse -Filter "Azure.AI.ContentUnderstanding.dll" -ErrorAction SilentlyContinue |
                Where-Object { $_.FullName -match 'Release[\\/]net10\.0' -and $_.FullName -notmatch 'ref[\\/]' } |
                Sort-Object LastWriteTime -Descending |
                Select-Object -First 1
            if (-not $builtDll) {
                $builtDll = Get-ChildItem -Path $localSrcDir -Recurse -Filter "Azure.AI.ContentUnderstanding.dll" -ErrorAction SilentlyContinue |
                    Where-Object { $_.FullName -match 'bin[\\/]Release' -and $_.FullName -notmatch 'ref[\\/]' } |
                    Sort-Object LastWriteTime -Descending |
                    Select-Object -First 1
            }
            if (-not $builtDll) {
                Write-ColorOutput "Error: Could not find built DLL and NuGet package is not available." "Red"
                exit 1
            } else {
                $dllPath = $builtDll.FullName
                Write-ColorOutput "Using local SDK DLL: $dllPath" "Green"
            }
        }
    } else {
        Write-ColorOutput "Error: NuGet package not available and local SDK source not found at: $localSrcCsproj" "Red"
        exit 1
    }
}

# Create .csproj
if ($useLocalSrc) {
    $csproj = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <NoWarn>CS8600;CS8602;CS8604;CS0168;CS0219</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Azure.AI.ContentUnderstanding">
      <HintPath>$dllPath</HintPath>
    </Reference>
    <PackageReference Include="Azure.Core" Version="1.*" />
    <PackageReference Include="Azure.Identity" Version="1.*" />
    <PackageReference Include="System.Text.Json" Version="*" />
    <PackageReference Include="System.Memory.Data" Version="*" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="10.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="10.*" />
  </ItemGroup>
</Project>
"@
} else {
    $csproj = @'
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <NoWarn>CS8600;CS8602;CS8604;CS0168;CS0219</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Azure.AI.ContentUnderstanding" Version="1.0.0-*" />
    <PackageReference Include="Azure.Identity" Version="1.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="10.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.*" />
    <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="10.*" />
  </ItemGroup>
</Project>
'@
}
Set-Content -Path (Join-Path $runnerDir "$SampleName.csproj") -Value $csproj

# Generate Program.cs
$programHeader = @'
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using System.ClientModel.Primitives;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

// Load configuration
var _appConfig = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

string _endpoint = _appConfig["CONTENTUNDERSTANDING_ENDPOINT"] ?? Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_ENDPOINT") ?? "";
string _apiKey = _appConfig["AZURE_CONTENT_UNDERSTANDING_KEY"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_KEY") ?? "";
string _targetEndpoint = _appConfig["CONTENTUNDERSTANDING_TARGET_ENDPOINT"] ?? Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TARGET_ENDPOINT") ?? "";
string _targetResourceId = _appConfig["AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID") ?? "";
string _sourceEndpoint = _appConfig["CONTENTUNDERSTANDING_SOURCE_ENDPOINT"] ?? Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_SOURCE_ENDPOINT") ?? "";
string _sourceResourceId = _appConfig["AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID") ?? "";
string _sourceRegion = _appConfig["AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION") ?? "";
string _targetRegion = _appConfig["AZURE_CONTENT_UNDERSTANDING_TARGET_REGION"] ?? Environment.GetEnvironmentVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_REGION") ?? "";
string _gpt41Deployment = _appConfig["GPT_4_1_DEPLOYMENT"] ?? Environment.GetEnvironmentVariable("GPT_4_1_DEPLOYMENT") ?? "gpt-4.1";
string _gpt41MiniDeployment = _appConfig["GPT_4_1_MINI_DEPLOYMENT"] ?? Environment.GetEnvironmentVariable("GPT_4_1_MINI_DEPLOYMENT") ?? "gpt-4.1-mini";
string _embeddingDeployment = _appConfig["TEXT_EMBEDDING_3_LARGE_DEPLOYMENT"] ?? Environment.GetEnvironmentVariable("TEXT_EMBEDDING_3_LARGE_DEPLOYMENT") ?? "text-embedding-3-large";

if (string.IsNullOrEmpty(_endpoint))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Error: CONTENTUNDERSTANDING_ENDPOINT is not configured.");
    Console.WriteLine("Set it in appsettings.json or as an environment variable.");
    Console.ResetColor();
    return;
}

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"Endpoint: {_endpoint}");
Console.ResetColor();

// --- Authentication ---
ContentUnderstandingClient client;
if (!string.IsNullOrEmpty(_apiKey))
{
    client = new ContentUnderstandingClient(new Uri(_endpoint), new AzureKeyCredential(_apiKey));
    Console.WriteLine("Auth: API Key");
}
else
{
    client = new ContentUnderstandingClient(new Uri(_endpoint), new DefaultAzureCredential());
    Console.WriteLine("Auth: DefaultAzureCredential");
}

Console.WriteLine();

'@

# Detect if scoping is needed by checking for duplicate variable declarations across snippets.
# Samples like Sample02 have multiple independent snippets declaring the same variables (uriSource, result, etc.)
# and need { } scope blocks. Samples like Sample01 have sequential snippets that share variables and must NOT be scoped.
$declPattern = '\b(?:var|string|int|bool|byte\[\]|BinaryData|Uri|Operation<[^>]+>|AnalyzeResult|MediaContent|DocumentContent|AudioVisualContent|ContentUnderstandingClient|[A-Z]\w+)\s+(\w+)\s*='
$needsScoping = $false
$seenVars = @{}
foreach ($block in $filteredBlocks) {
    # Split block into lines and filter out C# 'using' statements before matching
    $blockLines = ($block -split "`n") | Where-Object { $_ -notmatch '^\s*using\b' }
    $blockText = $blockLines -join "`n"
    $declMatches = [regex]::Matches($blockText, $declPattern)
    foreach ($m in $declMatches) {
        $varName = $m.Groups[1].Value
        if ($seenVars.ContainsKey($varName)) {
            $needsScoping = $true
            break
        }
        $seenVars[$varName] = $true
    }
    if ($needsScoping) { break }
}

# Build code body from filtered snippets (skip client creation lines)
# When duplicate variable declarations exist across blocks, hoist duplicated variables
# to the top of the method as pre-declarations, then convert ALL occurrences to
# re-assignments. This avoids both CS0103 (undefined variable) and CS0136 (duplicate
# declaration in enclosing/nested scope) errors when snippets are concatenated.
$codeBody = ""
$hoistedVars = ""
if ($needsScoping) {
    # Collect all variable names that appear in multiple blocks and need hoisting
    $varFirstType = @{}   # varName -> first type string seen
    $varCount = @{}       # varName -> count of blocks declaring it
    foreach ($block in $filteredBlocks) {
        $blockVars = @{}
        # Filter out C# 'using' statements before matching declarations
        $blockLines = ($block -split "`n") | Where-Object { $_ -notmatch '^\s*using\b' }
        $blockText = $blockLines -join "`n"
        $declMatches = [regex]::Matches($blockText, $declPattern)
        foreach ($m in $declMatches) {
            $varName = $m.Groups[1].Value
            if (-not $blockVars.ContainsKey($varName)) {
                $blockVars[$varName] = $true
                if (-not $varCount.ContainsKey($varName)) {
                    $varCount[$varName] = 1
                    # Extract the type from the match (everything before the variable name)
                    $fullMatch = $m.Groups[0].Value
                    $typeStr = ($fullMatch -replace "\s+$varName\s*=.*$", '').Trim()
                    # Resolve 'var' to 'dynamic' for hoisted declarations
                    if ($typeStr -eq 'var') { $typeStr = 'dynamic' }
                    $varFirstType[$varName] = $typeStr
                } else {
                    $varCount[$varName]++
                }
            }
        }
    }
    # Build hoisted declarations for variables appearing in 2+ blocks
    foreach ($varName in $varCount.Keys) {
        if ($varCount[$varName] -ge 2) {
            $typeStr = $varFirstType[$varName]
            $hoistedVars += "$typeStr $varName = default;`n"
        }
    }
    # The set of variable names to convert from declaration to assignment
    $hoistedVarNames = $varCount.Keys | Where-Object { $varCount[$_] -ge 2 }
}

foreach ($block in $filteredBlocks) {
    $lines = $block -split "`n"
    foreach ($line in $lines) {
        # Skip client creation lines already handled
        if ($line -match '^\s*(string endpoint|string apiKey|var credential|var client)\s*=') { continue }
        if ($line -match '^\s*//.*Example:.*your-foundry') { continue }

        # For hoisted variables, strip the type prefix everywhere (all depths)
        # But skip C# 'using' statements (using var x = ... or using (Type x = ...)) 
        if ($needsScoping -and $hoistedVarNames -and $line -match $declPattern -and $line -notmatch '^\s*using\b') {
            $varName = ([regex]::Match($line, $declPattern)).Groups[1].Value
            if ($varName -in $hoistedVarNames) {
                $line = $line -replace '^\s*(?:var|string|int|bool|byte\[\]|BinaryData|Uri|Operation<[^>]+>|AnalyzeResult|MediaContent|DocumentContent|AudioVisualContent|ContentUnderstandingClient|[A-Z]\w+)\s+' , ''
            }
        }

        $codeBody += $line + "`n"
    }
    $codeBody += "`n"
}

# Prepend hoisted declarations
if ($hoistedVars) { $codeBody = $hoistedVars + "`n" + $codeBody }

# Fix unmatched braces: some snippets include 'try {' without the closing '} catch/finally'.
# Count opens/closes and append missing closing braces so the program compiles.
# If the code has an unclosed 'try' block, append '} catch { }' instead of just '}'.
$openCount = ([regex]::Matches($codeBody, '\{')).Count
$closeCount = ([regex]::Matches($codeBody, '\}')).Count
if ($openCount -gt $closeCount) {
    $missing = $openCount - $closeCount
    # Check if there's an unclosed try block (try without matching catch/finally)
    $tryCount = ([regex]::Matches($codeBody, '\btry\s*\{')).Count
    $catchFinallyCount = ([regex]::Matches($codeBody, '\b(?:catch|finally)\s*(?:\([^)]*\))?\s*\{')).Count
    $unclosedTry = $tryCount - $catchFinallyCount
    if ($unclosedTry -gt 0) {
        # Close the try block(s) with catch
        for ($i = 0; $i -lt $unclosedTry; $i++) { $codeBody += "} catch (Exception ex) { Console.WriteLine(`$`"Cleanup error: {ex.Message}`"); }`n"; $missing -= 2 }
    }
    # Close any remaining unmatched braces
    for ($i = 0; $i -lt [Math]::Max(0, $missing); $i++) { $codeBody += "}`n" }
}

# Inject fallback variable declarations for variables that snippets reference but only
# define in test setup code outside the #region. These use sample-friendly default values.
$fallbackVars = @{
    'analyzerId' = 'string analyzerId = $"my_sample_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";'
    'sourceAnalyzerId' = 'string sourceAnalyzerId = $"copy_source_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";'
    'targetAnalyzerId' = 'string targetAnalyzerId = $"copy_target_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";'
}
foreach ($varName in $fallbackVars.Keys) {
    # Only inject if the variable is used but never declared in the code body
    if ($codeBody -match "\b$varName\b" -and $codeBody -notmatch "(?:string|var)\s+$varName\s*=") {
        $codeBody = $fallbackVars[$varName] + "`n" + $codeBody
    }
}

$fullProgram = $programHeader + $codeBody

# Replace placeholders
$fullProgram = $fullProgram -replace '"<endpoint>"', '_endpoint'
$fullProgram = $fullProgram -replace '"<apiKey>"', '_apiKey'
$fullProgram = $fullProgram -replace '"<document_url>"', '"https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf"'

# Sample00: Replace model deployment name placeholders
$fullProgram = $fullProgram -replace '<your-gpt-4.1-deployment-name>', $gpt41Deployment
$fullProgram = $fullProgram -replace '<your-gpt-4.1-mini-deployment-name>', $gpt41MiniDeployment
$fullProgram = $fullProgram -replace '<your-text-embedding-3-large-deployment-name>', $embeddingDeployment

# Sample05: Replace <file_path> placeholder (different from <filePath>)
if (-not [string]::IsNullOrEmpty($FilePath)) {
    $escaped = $FilePath -replace '\\', '\\\\'
    $fullProgram = $fullProgram -replace '<file_path>', $escaped
}

# Sample15: Replace cross-resource placeholders with config values
if (-not [string]::IsNullOrEmpty($sourceEndpoint)) {
    $fullProgram = $fullProgram -replace 'https://source-resource\.services\.ai\.azure\.com/', $sourceEndpoint
}
if (-not [string]::IsNullOrEmpty($targetEndpoint)) {
    $fullProgram = $fullProgram -replace 'https://target-resource\.services\.ai\.azure\.com/', $targetEndpoint
}
# Replace resource ID placeholders per-line so source and target get different values
if (-not [string]::IsNullOrEmpty($sourceResourceId) -or -not [string]::IsNullOrEmpty($targetResourceId)) {
    $lines = $fullProgram -split "`n"
    for ($i = 0; $i -lt $lines.Count; $i++) {
        if ($lines[$i] -match 'string sourceResourceId' -and -not [string]::IsNullOrEmpty($sourceResourceId)) {
            $lines[$i] = $lines[$i] -replace '/subscriptions/\{subscriptionId\}/resourceGroups/\{resourceGroupName\}/providers/Microsoft\.CognitiveServices/accounts/\{name\}', $sourceResourceId
        }
        if ($lines[$i] -match 'string targetResourceId' -and -not [string]::IsNullOrEmpty($targetResourceId)) {
            $lines[$i] = $lines[$i] -replace '/subscriptions/\{subscriptionId\}/resourceGroups/\{resourceGroupName\}/providers/Microsoft\.CognitiveServices/accounts/\{name\}', $targetResourceId
        }
    }
    $fullProgram = $lines -join "`n"
}
if (-not [string]::IsNullOrEmpty($sourceRegion)) {
    $fullProgram = $fullProgram -replace 'string sourceRegion = "eastus";', "string sourceRegion = `"$sourceRegion`";"
}
if (-not [string]::IsNullOrEmpty($targetRegion)) {
    $fullProgram = $fullProgram -replace 'string targetRegion = "westus";', "string targetRegion = `"$targetRegion`";"
}

# Handle local file paths
if (-not [string]::IsNullOrEmpty($FilePath)) {
    $escaped = $FilePath -replace '\\', '\\'
    $fullProgram = $fullProgram -replace '<localDocumentFilePath>', $escaped
    $fullProgram = $fullProgram -replace '<filePath>', $escaped
}

# If sample needs a local file but none provided, download test file
if ($fullProgram -match '<localDocumentFilePath>|<filePath>|<file_path>') {
    if ([string]::IsNullOrEmpty($FilePath)) {
        Write-ColorOutput "Warning: Sample requires a local file. Downloading a test PDF..." "Yellow"
        $testFile = Join-Path $runnerDir "test_document.pdf"
        try {
            Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf" -OutFile $testFile -UseBasicParsing
        } catch {
            Write-ColorOutput "Warning: Could not download test file: $_" "Yellow"
        }
        $escapedTest = $testFile -replace '\\', '\\'
        $fullProgram = $fullProgram -replace '<localDocumentFilePath>', $escapedTest
        $fullProgram = $fullProgram -replace '<filePath>', $escapedTest
        $fullProgram = $fullProgram -replace '<file_path>', $escapedTest
    }
}

Set-Content -Path (Join-Path $runnerDir "Program.cs") -Value $fullProgram

# Copy appsettings.json into the sample project folder
if (Test-Path $appsettingsPath) {
    Copy-Item $appsettingsPath -Destination (Join-Path $runnerDir "appsettings.json") -Force
    Write-ColorOutput "Copied appsettings.json to sample project folder" "Blue"
}

# ─── Build the project ────────────────────────────────────────────────────────
Write-Host ""
Write-ColorOutput "=== Building: $SampleName ===" "Blue"
Write-Host ""

Push-Location $runnerDir
try {
    dotnet build (Join-Path $runnerDir "$SampleName.csproj")
    $buildExitCode = $LASTEXITCODE
} finally {
    Pop-Location
}

if ($buildExitCode -ne 0) {
    Write-ColorOutput "Build failed with exit code: $buildExitCode" "Red"
    Write-Host ""
    Write-ColorOutput "Troubleshooting:" "Yellow"
    Write-Host "  - Review the generated code: $(Join-Path $runnerDir 'Program.cs')"
    Write-Host "  - Delete .sample_runner/ and re-run to regenerate"
    exit $buildExitCode
}

Write-ColorOutput "Build succeeded: $SampleName" "Green"

# ─── Run (if -Run flag) or print instructions ───────────────────────────────
if ($Run) {
    Write-Host ""
    Write-ColorOutput "=== Running: $SampleName ===" "Blue"
    Write-Host ""

    Push-Location $runnerDir
    try {
        dotnet run --project (Join-Path $runnerDir "$SampleName.csproj") --no-build
        $exitCode = $LASTEXITCODE
    } finally {
        Pop-Location
    }

    Write-Host ""
    if ($exitCode -eq 0) {
        Write-ColorOutput "Sample completed: $SampleName" "Green"
    } else {
        Write-ColorOutput "Sample failed with exit code: $exitCode" "Red"
        Write-Host ""
        Write-ColorOutput "Troubleshooting:" "Yellow"
        Write-Host "  - Check that your endpoint and credentials are correct"
        Write-Host "  - Ensure model deployments are configured (run Sample00_UpdateDefaults)"
        Write-Host "  - Verify the Cognitive Services User role is assigned"
        Write-Host "  - Review the generated code: $(Join-Path $runnerDir 'Program.cs')"
    }
    exit $exitCode
} else {
    Write-Host ""
    Write-ColorOutput "Sample project is ready! To run it:" "Green"
    Write-Host ""
    Write-ColorOutput "  cd $runnerDir" "Cyan"
    Write-ColorOutput "  dotnet run --project $SampleName.csproj" "Cyan"
    Write-Host ""
    Write-ColorOutput "Project location: $runnerDir" "Blue"
    Write-ColorOutput "Generated code:   $(Join-Path $runnerDir 'Program.cs')" "Blue"
    exit 0
}
