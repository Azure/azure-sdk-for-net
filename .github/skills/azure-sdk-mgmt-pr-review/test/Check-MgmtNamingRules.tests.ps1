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
    $suffix = @('    }', '}')

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
    Write-Host 'Case: single overload changed from optional to required'
    $output = Invoke-Scanner `
        @('        public void GetAll(string filter = null) { }') `
        @('        public void GetAll(string filter) { }')
    Assert ($output -match '\[OPTPARAM001\]') 'reports a directly broken omitted-argument call'
    Assert ($output -match 'GA baseline 1\.2\.3') 'identifies the compared baseline version'
    Assert ($output -match 'Baseline signature: GetAll\(string filter = null\)') 'includes the baseline signature'
    Assert ($output -match 'Current signature: GetAll\(string filter\)') 'includes the current signature'

    Write-Host 'Case: sibling overloads preserve possible GA calls'
    $output = Invoke-Scanner `
        @('        public void GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default) { }') `
        @(
            '        public void GetAll(string filter, System.Threading.CancellationToken cancellationToken) { }',
            '        public void GetAll(System.Threading.CancellationToken cancellationToken = default) { }'
        )
    Assert ($output -notmatch '\[OPTPARAM001\]') 'suppresses optionality findings when compiler evidence is required'

    Write-Host 'Case: required parameter changed to optional'
    $output = Invoke-Scanner `
        @('        public void Create(string name) { }') `
        @('        public void Create(string name = null) { }')
    Assert ($output -notmatch '\[OPTPARAM002\]') 'does not emit required-to-optional findings without compiler evidence'
    Assert ($output -notmatch 'Source Compatibility') 'does not surface the textual difference as a review finding'
} finally {
    Remove-Item -Recurse -Force $tempRoot
}

if ($failures.Count -gt 0) {
    Write-Host "`n$($failures.Count) assertion(s) failed." -ForegroundColor Red
    exit 1
}

Write-Host "`nAll management review scanner tests passed." -ForegroundColor Green
