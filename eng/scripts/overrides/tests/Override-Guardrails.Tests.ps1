#Requires -Version 7.0
<#
.How-To-Run
This test file uses Pester, a testing framework for PowerShell.
For more information about Pester, see: https://pester.dev/docs/quick-start

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./Override-Guardrails.Tests.ps1 -Tag UnitTest`
#>

try
{
    Import-Module Pester -MinimumVersion 5.3.3 -ErrorAction Stop | Out-Null
}
catch
{
    throw "Pester >= 5.3.3 is required to run these tests. Ensure Pester is available on the machine running CI."
}

$python = (Get-Command python -ErrorAction SilentlyContinue)
if (-not $python)
{
    throw "python executable not found on PATH. These tests require python."
}

function Initialize-GitRepo([string]$repoRoot)
{
    $git = (Get-Command git -ErrorAction SilentlyContinue)
    if (-not $git) { throw "git executable not found on PATH. These tests require git." }

    Push-Location $repoRoot
    try {
        & git init | Out-Null
        & git config user.email "test@example.com" | Out-Null
        & git config user.name "Override Guardrails Tests" | Out-Null
        & git config commit.gpgsign false | Out-Null
    }
    finally {
        Pop-Location
    }
}

function Git-CommitAll([string]$repoRoot, [string]$message)
{
    Push-Location $repoRoot
    try {
        & git add -A | Out-Null
        & git commit -m $message | Out-Null
    }
    finally {
        Pop-Location
    }
}

function New-TestRepoRoot
{
    $repoRoot = Join-Path $TestDrive "repo"
    New-Item -ItemType Directory -Force -Path $repoRoot | Out-Null
    New-Item -ItemType Directory -Force -Path (Join-Path $repoRoot "sdk") | Out-Null
    return $repoRoot
}

function Write-TextFile([string]$path, [string]$content)
{
    $dir = Split-Path -Parent $path
    if ($dir -and -not (Test-Path $dir)) { New-Item -ItemType Directory -Force -Path $dir | Out-Null }
    Set-Content -Path $path -Value $content -Encoding UTF8
}

Describe "Overrides guardrail checkers" -Tag "UnitTest" {
    It "check_version_overrides passes when allowlisted and fails when not allowlisted" {
        $repoRoot = New-TestRepoRoot

        $csprojPath = Join-Path $repoRoot "sdk/svc/pkg/src/pkg.csproj"
        Write-TextFile $csprojPath @"
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup Condition="'$(TargetFramework)' == 'net10.0'">
    <PackageReference Include="Example.A" VersionOverride="1.2.3" />
    <PackageReference Include="Example.B">
      <VersionOverride>4.5.6</VersionOverride>
    </PackageReference>
  </ItemGroup>
</Project>
"@

        $allowlistPath = Join-Path $repoRoot "eng/overrides/versionoverride.allowlist.json"
        Write-TextFile $allowlistPath @"
[
  { "project": "sdk/svc/pkg/src/pkg.csproj", "packageId": "Example.A", "versionOverride": "1.2.3", "referenceKind": "Include", "condition": "'$(TargetFramework)' == 'net10.0'", "tracking": "t", "justification": "j" },
  { "project": "sdk/svc/pkg/src/pkg.csproj", "packageId": "Example.B", "versionOverride": "4.5.6", "referenceKind": "Include", "condition": "'$(TargetFramework)' == 'net10.0'", "tracking": "t", "justification": "j" }
]
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_version_overrides.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --searchPath sdk --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output | Should -Match "OK: 2 VersionOverride entries found"

        # Remove one allowlisted entry -> should fail.
        Write-TextFile $allowlistPath @"
[
  { "project": "sdk/svc/pkg/src/pkg.csproj", "packageId": "Example.A", "versionOverride": "1.2.3", "referenceKind": "Include", "condition": "'$(TargetFramework)' == 'net10.0'", "tracking": "t", "justification": "j" }
]
"@
        $output2 = & $python.Source $scriptPath --repoRoot $repoRoot --searchPath sdk --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 1
        $output2 | Should -Match "not present in allowlist"
        $output2 | Should -Match "Example.B"
    }

    It "check_projectrefconversion_exclusions detects ItemGroup Condition inheritance" {
        $repoRoot = New-TestRepoRoot

        $csprojPath = Join-Path $repoRoot "sdk/svc/pkg/src/pkg.csproj"
        Write-TextFile $csprojPath @"
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup Condition="'$(IsTestProject)' == 'true'">
    <ExcludeFromProjectReferenceToConversion Include="Azure.Storage.Blobs" />
  </ItemGroup>
</Project>
"@

        $allowlistPath = Join-Path $repoRoot "eng/overrides/projectrefconversion-exclusions.allowlist.json"
        Write-TextFile $allowlistPath @"
[
  { "project": "sdk/svc/pkg/src/pkg.csproj", "excludedPackageId": "Azure.Storage.Blobs", "condition": "'$(IsTestProject)' == 'true'", "tracking": "t", "justification": "j" }
]
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_projectrefconversion_exclusions.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --searchPath sdk --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output | Should -Match "OK: 1 ExcludeFromProjectReferenceToConversion entry"
    }

    It "check_aot_optouts supports compact allowlist object shape" {
        $repoRoot = New-TestRepoRoot

        $propsPath = Join-Path $repoRoot "sdk/svc/Directory.Build.props"
        Write-TextFile $propsPath @"
<Project>
  <PropertyGroup>
    <AotCompatOptOut>true</AotCompatOptOut>
  </PropertyGroup>
</Project>
"@

        $allowlistPath = Join-Path $repoRoot "eng/overrides/aot-optouts.allowlist.json"
        Write-TextFile $allowlistPath @"
{ "trackingDefault": "t", "justificationDefault": "j", "entries": [ { "file": "sdk/svc/Directory.Build.props", "property": "AotCompatOptOut", "condition": null } ] }
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_aot_optouts.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --searchPath sdk --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output | Should -Match "OK: 1 AOT opt-out entry"
    }

    It "check_apicompat_baselines allowlists ApiCompatBaseline.txt presence" {
        $repoRoot = New-TestRepoRoot
        $baselinePath = Join-Path $repoRoot "sdk/svc/pkg/src/ApiCompatBaseline.txt"
        Write-TextFile $baselinePath "baseline"

        $allowlistPath = Join-Path $repoRoot "eng/overrides/apicompat-baselines.allowlist.json"
        Write-TextFile $allowlistPath @"
[
  { "file": "sdk/svc/pkg/src/ApiCompatBaseline.txt", "tracking": "t", "justification": "j" }
]
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_apicompat_baselines.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --searchPath sdk --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output | Should -Match "OK: 1 ApiCompatBaseline.txt entry"
    }

    It "check_global_suppressions allowlists GlobalSuppressions.cs presence" {
        $repoRoot = New-TestRepoRoot
        $gsPath = Join-Path $repoRoot "sdk/svc/pkg/src/GlobalSuppressions.cs"
        Write-TextFile $gsPath "// suppressions"

        $allowlistPath = Join-Path $repoRoot "eng/overrides/global-suppressions.allowlist.json"
        Write-TextFile $allowlistPath @"
[
  { "file": "sdk/svc/pkg/src/GlobalSuppressions.cs", "tracking": "t", "justification": "j" }
]
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_global_suppressions.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --searchPath sdk --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output | Should -Match "OK: 1 GlobalSuppressions.cs file"
    }

    It "check_nowarn_directory_overrides parses multiple AZC rules and conditions" {
        $repoRoot = New-TestRepoRoot
        $propsPath = Join-Path $repoRoot "sdk/svc/Directory.Build.props"
        Write-TextFile $propsPath @"
<Project>
  <PropertyGroup Condition="'$(HasReleaseVersion)' != 'true'">
    <NoWarn>AZC0010; AZC0011; AZC0011</NoWarn>
  </PropertyGroup>
</Project>
"@

        $allowlistPath = Join-Path $repoRoot "eng/overrides/nowarn-directory-overrides.allowlist.json"
        Write-TextFile $allowlistPath @"
[
  { "file": "sdk/svc/Directory.Build.props", "ruleId": "AZC0010", "condition": "'$(HasReleaseVersion)' != 'true'", "tracking": "t", "justification": "j" },
  { "file": "sdk/svc/Directory.Build.props", "ruleId": "AZC0011", "condition": "'$(HasReleaseVersion)' != 'true'", "tracking": "t", "justification": "j" }
]
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_nowarn_directory_overrides.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --searchPath sdk --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output | Should -Match "OK: 2 NoWarn\\(AZC\\) entries found"
    }

    It "check_nowarn_changes fails when NoWarn is changed without allowlisting" {
        $repoRoot = New-TestRepoRoot
        Initialize-GitRepo $repoRoot

        $csprojPath = Join-Path $repoRoot "sdk/svc/pkg/src/pkg.csproj"
        Write-TextFile $csprojPath @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
</Project>
"@

        Git-CommitAll $repoRoot "baseline"
        Push-Location $repoRoot
        try {
            $baseRef = (& git rev-parse HEAD).Trim()
        }
        finally {
            Pop-Location
        }

        # Change NoWarn.
        Write-TextFile $csprojPath @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <NoWarn>$(NoWarn);CA1812</NoWarn>
  </PropertyGroup>
</Project>
"@
        Git-CommitAll $repoRoot "add nowarn"

        $allowlistPath = Join-Path $repoRoot "eng/overrides/nowarn-changes.allowlist.json"
        Write-TextFile $allowlistPath @"
{ "trackingDefault": "t", "justificationDefault": "j", "entries": [] }
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_nowarn_changes.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --baseRef $baseRef --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 1
        $output | Should -Match "NoWarn changes"
        $output | Should -Match "sdk/svc/pkg/src/pkg.csproj"

        # Allowlist the file -> should pass.
        Write-TextFile $allowlistPath @"
{ "trackingDefault": "t", "justificationDefault": "j", "entries": [ { "file": "sdk/svc/pkg/src/pkg.csproj", "tracking": "t", "justification": "j" } ] }
"@
        $output2 = & $python.Source $scriptPath --repoRoot $repoRoot --baseRef $baseRef --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output2 | Should -Match "OK:"
    }

    It "check_hardcoded_tfms_changes fails when hardcoded TargetFramework is introduced without allowlisting" {
        $repoRoot = New-TestRepoRoot
        Initialize-GitRepo $repoRoot

        $csprojPath = Join-Path $repoRoot "sdk/svc/pkg/src/pkg.csproj"
        Write-TextFile $csprojPath @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>$(RequiredTargetFrameworks)</TargetFrameworks>
  </PropertyGroup>
</Project>
"@
        Git-CommitAll $repoRoot "baseline"

        Push-Location $repoRoot
        try { $baseRef = (& git rev-parse HEAD).Trim() }
        finally { Pop-Location }

        # Introduce hardcoded TFM.
        Write-TextFile $csprojPath @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
</Project>
"@
        Git-CommitAll $repoRoot "introduce hardcoded tfm"

        $allowlistPath = Join-Path $repoRoot "eng/overrides/hardcoded-tfms.allowlist.json"
        Write-TextFile $allowlistPath @"
{ "trackingDefault": "t", "justificationDefault": "j", "entries": [] }
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_hardcoded_tfms_changes.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --baseRef $baseRef --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 1
        $output | Should -Match "hardcoded TargetFramework"
        $output | Should -Match "net10.0"

        # Allowlist exact tuple -> should pass.
        Write-TextFile $allowlistPath @"
{ "trackingDefault": "t", "justificationDefault": "j", "entries": [ { "file": "sdk/svc/pkg/src/pkg.csproj", "property": "TargetFramework", "value": "net10.0", "tracking": "t", "justification": "j" } ] }
"@
        $output2 = & $python.Source $scriptPath --repoRoot $repoRoot --baseRef $baseRef --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output2 | Should -Match "OK:"
    }

    It "check_added_assets fails when a new SessionRecords file is added without allowlisting" {
        $repoRoot = New-TestRepoRoot
        Initialize-GitRepo $repoRoot

        # baseline commit
        $baselineFile = Join-Path $repoRoot "sdk/svc/pkg/README.md"
        Write-TextFile $baselineFile "baseline"
        Git-CommitAll $repoRoot "baseline"

        Push-Location $repoRoot
        try { $baseRef = (& git rev-parse HEAD).Trim() }
        finally { Pop-Location }

        # add a new recording asset under SessionRecords
        $assetPath = Join-Path $repoRoot "sdk/svc/pkg/SessionRecords/test.json"
        Write-TextFile $assetPath "{ ""recording"": true }"
        Git-CommitAll $repoRoot "add asset"

        $allowlistPath = Join-Path $repoRoot "eng/overrides/added-assets.allowlist.json"
        Write-TextFile $allowlistPath @"
{ "trackingDefault": "t", "justificationDefault": "j", "entries": [] }
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_added_assets.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --baseRef $baseRef --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 1
        $output | Should -Match "SessionRecords"

        # allowlist file -> should pass
        Write-TextFile $allowlistPath @"
{ "trackingDefault": "t", "justificationDefault": "j", "entries": [ { "file": "sdk/svc/pkg/SessionRecords/test.json", "tracking": "t", "justification": "j" } ] }
"@
        $output2 = & $python.Source $scriptPath --repoRoot $repoRoot --baseRef $baseRef --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output2 | Should -Match "OK:"
    }

    It "check_matrix_overrides detects MatrixConfigs and Name entries" {
        $repoRoot = New-TestRepoRoot
        $ymlPath = Join-Path $repoRoot "sdk/svc/tests.yml"
        Write-TextFile $ymlPath @"
MatrixConfigs:
  - Name: MyMatrix
    Path: some.json
"@

        $allowlistPath = Join-Path $repoRoot "eng/overrides/matrix-overrides.allowlist.json"
        Write-TextFile $allowlistPath @"
[
  { "file": "sdk/svc/tests.yml", "key": "MatrixConfigs", "name": null, "tracking": "t", "justification": "j" },
  { "file": "sdk/svc/tests.yml", "key": "MatrixConfigs", "name": "MyMatrix", "tracking": "t", "justification": "j" }
]
"@

        $scriptPath = Join-Path $PSScriptRoot ".." "check_matrix_overrides.py"
        $output = & $python.Source $scriptPath --repoRoot $repoRoot --searchPath sdk --allowlist $allowlistPath 2>&1 | Out-String
        $LASTEXITCODE | Should -Be 0
        $output | Should -Match "OK: 2 matrix override entries found"
    }
}

