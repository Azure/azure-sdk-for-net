#!/usr/bin/env pwsh
[CmdletBinding()]
param(
    [string]$ScannerPath = (Join-Path $PSScriptRoot '..' 'Check-MgmtNamingRules.ps1')
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$ScannerPath = (Resolve-Path $ScannerPath).Path
$failures = [System.Collections.Generic.List[string]]::new()

function Assert([bool]$condition, [string]$message) {
    if ($condition) {
        Write-Host "  [PASS] $message"
    } else {
        Write-Host "  [FAIL] $message" -ForegroundColor Red
        $script:failures.Add($message)
    }
}

function Invoke-Scanner([string[]]$baselineMembers, [string[]]$currentMembers) {
    $caseDirectory = Join-Path $script:tempRoot ([guid]::NewGuid().ToString('N'))
    New-Item -ItemType Directory -Path $caseDirectory | Out-Null

    $baselinePath = Join-Path $caseDirectory 'baseline.cs'
    $currentPath = Join-Path $caseDirectory 'current.cs'
    $prefix = @(
        'namespace Azure.ResourceManager.Example',
        '{',
        '    public partial class ExampleClient',
        '    {'
    )
    $suffix = @(
        '    }',
        '}'
    )

    Set-Content -Path $baselinePath -Value ($prefix + $baselineMembers + $suffix)
    Set-Content -Path $currentPath -Value ($prefix + $currentMembers + $suffix)

    return (& pwsh -NoLogo -NoProfile -File $ScannerPath `
        -ApiFilePath $currentPath `
        -BaselineApiFilePath $baselinePath `
        -BaselineVersion '1.2.3' 6>&1 | Out-String)
}

$tempRoot = Join-Path ([System.IO.Path]::GetTempPath()) ("mgmt-review-tests-" + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $tempRoot | Out-Null

try {
    Write-Host 'Case: exact GA signature'
    $output = Invoke-Scanner `
        @('        public ExampleClient(long count, string mode, string name, string vmSkuName) { }') `
        @('        public ExampleClient(long count, string mode, string name, string vmSkuName) { }')
    Assert ($output -notmatch '\[PARAM(?:NAME|ORDER)001\]') 'does not flag a signature that exactly matches GA'

    Write-Host 'Case: same-typed parameters reordered'
    $output = Invoke-Scanner `
        @('        public ExampleClient(long count, string mode, string vmSkuName, string name) { }') `
        @('        public ExampleClient(long count, string mode, string name, string vmSkuName) { }')
    Assert ($output -match '\[PARAMORDER001\]') 'flags positional order changes with identical parameter types'
    Assert ($output -match 'GA baseline 1\.2\.3') 'reports the compared GA version'
    Assert ($output -match 'ExampleClient\(long count, string mode, string vmSkuName, string name\)') 'reports the exact GA signature'

    Write-Host 'Case: named parameter changed'
    $output = Invoke-Scanner `
        @('        public void GetAll(string kind = null) { }') `
        @('        public void GetAll(string skip = null) { }')
    Assert ($output -match '\[PARAMNAME001\]') 'flags a named-argument compatibility change'
    Assert ($output -match "'kind'.*'skip'") 'reports GA and current parameter names'

    Write-Host 'Case: case-only named parameter change'
    $output = Invoke-Scanner `
        @('        public void Get(string resourceId) { }') `
        @('        public void Get(string resourceID) { }')
    Assert ($output -match '\[PARAMNAME001\]') 'treats C# named arguments as case-sensitive'

    Write-Host 'Case: optional parameter became required'
    $output = Invoke-Scanner `
        @('        public void GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default) { }') `
        @('        public void GetAll(string filter, System.Threading.CancellationToken cancellationToken) { }')
    Assert ($output -match '\[OPTPARAM001\]') 'emits an optional-to-required candidate'
    Assert ($output -match 'Source Compatibility Candidate') 'labels textual optionality differences as candidates'
    Assert ($output -match 'Baseline signature: GetAll\(string filter = null, System\.Threading\.CancellationToken cancellationToken = default\)') 'includes the exact GA signature'
    Assert ($output -match 'not a blocking finding until the complete overload sets are compiled') 'requires compiler confirmation before blocking'

    Write-Host 'Case: required parameter became optional'
    $output = Invoke-Scanner `
        @('        public void Create(string name) { }') `
        @('        public void Create(string name = null) { }')
    Assert ($output -match '\[OPTPARAM002\]') 'emits a required-to-optional candidate'
    Assert ($output -match 'block only for demonstrated ambiguity or changed binding') 'requires a demonstrated binding break'
} finally {
    Remove-Item -Recurse -Force $tempRoot
}

if ($failures.Count -gt 0) {
    Write-Host "`n$($failures.Count) assertion(s) failed." -ForegroundColor Red
    exit 1
}

Write-Host "`nAll management review scanner tests passed." -ForegroundColor Green
