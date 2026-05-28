#!/usr/bin/env pwsh
<#
.SYNOPSIS
  Scenario tests for eng/NoWarnValidation.targets and eng/AnalyzerAllowList.targets.

.DESCRIPTION
  Runs a small suite of synthetic scenarios that exercise the NoWarn validator end
  to end:
    * Project on the skip list: validator should NOT error.
    * Project NOT on the skip list, clean: validator should NOT error.
    * Project NOT on the skip list with a raw <NoWarn> in the csproj: validator
      MUST error (AZSDK0002), and the error MUST point at the csproj.
    * Project NOT on the skip list with a <NoWarn> coming from an imported props
      file: validator MUST error (AZSDK0002).
    * Allow-list parsing variants (case, whitespace around the prefix, blank lines,
      comments): every code MUST be recognized and the validator MUST NOT error.
    * Record mode: validator MUST emit a NoWarnAudit line and MUST NOT error.

  Each scenario creates an isolated temp directory containing a tiny csproj that
  imports the two .targets files directly. The validator is invoked via
  `dotnet msbuild /t:ValidateNoWarn` — we do not need a full SDK build.

  Exits 0 on success, 1 on any scenario failure. Intended to be run as a one-shot
  step in the .NET PR pipeline.

.PARAMETER RepoRoot
  Path to the repo root. Defaults to walking up from the script location.

.PARAMETER KeepTemp
  Keep the temp scenario directories on disk (for debugging).
#>
[CmdletBinding()]
param(
  [string] $RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..')).Path,
  [switch] $KeepTemp
)

$ErrorActionPreference = 'Stop'
$EngPath = Join-Path $RepoRoot 'eng'

$failures = New-Object System.Collections.Generic.List[string]
$passes   = 0

function New-ScenarioDir {
  param([string]$Name)
  $dir = Join-Path ([System.IO.Path]::GetTempPath()) ("nowarn-test-$Name-" + [Guid]::NewGuid().ToString('N').Substring(0,8))
  New-Item -ItemType Directory -Force -Path $dir | Out-Null
  return $dir
}

function Invoke-Validator {
  param(
    [string]$ProjectFile,
    [hashtable]$Properties = @{}
  )
  $args = @($ProjectFile, '/t:ValidateNoWarn', '/nologo', '/v:m')
  foreach ($k in $Properties.Keys) { $args += "/p:$k=$($Properties[$k])" }
  $output = & dotnet msbuild @args 2>&1
  return @{ ExitCode = $LASTEXITCODE; Output = ($output -join "`n") }
}

function Assert-Scenario {
  param(
    [string]$Name,
    [scriptblock]$Predicate,
    [hashtable]$Result
  )
  $ok = & $Predicate $Result
  if ($ok) {
    Write-Host "  PASS  $Name" -ForegroundColor Green
    $script:passes++
  } else {
    Write-Host "  FAIL  $Name" -ForegroundColor Red
    Write-Host "        exit=$($Result.ExitCode)" -ForegroundColor DarkGray
    Write-Host "        output:" -ForegroundColor DarkGray
    ($Result.Output -split "`n") | ForEach-Object { Write-Host "          $_" -ForegroundColor DarkGray }
    $script:failures.Add($Name)
  }
}

# NOTE on exit codes: with the .NET 10 SDK terminal logger, `dotnet msbuild /t:X`
# does not always propagate `Log.LogError` from an inline RoslynCodeTaskFactory
# task to a non-zero exit code (the error is logged correctly and pipelines treat
# it as a failure via log scanning, but the local exit code is 0). We therefore
# assert primarily on the presence/absence of AZSDK0002 in the output, which is
# what actually surfaces in CI and IDE error lists.

function New-TestCsproj {
  param(
    [string]$Dir,
    [string]$ProjectName,
    [string]$ExtraPropertyXml = '',
    [string]$ExtraImportXml = '',
    [string]$AllowListDir = $null,
    [string]$SkipListFile = $null
  )
  # Property overrides for paths to test fixtures (so the targets file uses our temp dir, not the repo eng dir).
  $extraProps = @()
  if ($AllowListDir) {
    $normalized = ($AllowListDir.TrimEnd('\','/') + [IO.Path]::DirectorySeparatorChar)
    $extraProps += "    <_AnalyzerAllowListDir>$normalized</_AnalyzerAllowListDir>"
  }
  if ($SkipListFile) {
    $extraProps += "    <_NoWarnSkipListFile>$SkipListFile</_NoWarnSkipListFile>"
  }
  $extraPropsXml = $extraProps -join "`n"

  $csproj = @"
<Project>
  <PropertyGroup>
    <IsShippingClientLibrary>true</IsShippingClientLibrary>
    <RepoEngPath>$EngPath</RepoEngPath>
$extraPropsXml
$ExtraPropertyXml
  </PropertyGroup>
$ExtraImportXml
  <Import Project="`$(RepoEngPath)\AnalyzerAllowList.targets" />
  <Import Project="`$(RepoEngPath)\NoWarnValidation.targets" />
</Project>
"@
  $path = Join-Path $Dir "$ProjectName.csproj"
  Set-Content -Path $path -Value $csproj -Encoding UTF8
  return $path
}

# ----------------------------------------------------------------------------
# Scenario 1: skip-listed project with NoWarn -> no error
# ----------------------------------------------------------------------------
$dir = New-ScenarioDir 'skiplisted'
try {
  $skipFile = Join-Path $dir 'skip.txt'
  Set-Content -Path $skipFile -Value "TestSkipListed`n" -Encoding UTF8
  $proj = New-TestCsproj -Dir $dir -ProjectName 'TestSkipListed' `
    -ExtraPropertyXml '    <NoWarn>$(NoWarn);CA9999</NoWarn>' `
    -SkipListFile $skipFile
  $r = Invoke-Validator $proj
  Assert-Scenario 'skip-listed project with NoWarn does not error' { param($x) $x.ExitCode -eq 0 -and $x.Output -notmatch 'AZSDK0002' } $r
} finally { if (-not $KeepTemp) { Remove-Item -Recurse -Force $dir } }

# ----------------------------------------------------------------------------
# Scenario 2: non-skip-listed clean project -> no error
# ----------------------------------------------------------------------------
$dir = New-ScenarioDir 'clean'
try {
  $skipFile = Join-Path $dir 'skip.txt'
  Set-Content -Path $skipFile -Value '' -Encoding UTF8
  $proj = New-TestCsproj -Dir $dir -ProjectName 'TestClean' -SkipListFile $skipFile
  $r = Invoke-Validator $proj
  Assert-Scenario 'clean project without NoWarn does not error' { param($x) $x.ExitCode -eq 0 -and $x.Output -notmatch 'AZSDK0002' } $r
} finally { if (-not $KeepTemp) { Remove-Item -Recurse -Force $dir } }

# ----------------------------------------------------------------------------
# Scenario 3: raw NoWarn in csproj -> error (AZSDK0002) pointing at csproj
# ----------------------------------------------------------------------------
$dir = New-ScenarioDir 'badnowarn-csproj'
try {
  $skipFile = Join-Path $dir 'skip.txt'
  Set-Content -Path $skipFile -Value '' -Encoding UTF8
  $proj = New-TestCsproj -Dir $dir -ProjectName 'TestBadNoWarn' `
    -ExtraPropertyXml '    <NoWarn>$(NoWarn);CA9999</NoWarn>' `
    -SkipListFile $skipFile
  $r = Invoke-Validator $proj
  Assert-Scenario 'raw NoWarn in non-skip-listed csproj errors AZSDK0002' {
    param($x) $x.Output -match 'error AZSDK0002' -and $x.Output -match 'CA9999'
  } $r
  Assert-Scenario 'AZSDK0002 error points at the csproj file path' {
    param($x) $x.Output -match [regex]::Escape('TestBadNoWarn.csproj')
  } $r
} finally { if (-not $KeepTemp) { Remove-Item -Recurse -Force $dir } }

# ----------------------------------------------------------------------------
# Scenario 4: NoWarn coming from an imported props file -> error
# ----------------------------------------------------------------------------
$dir = New-ScenarioDir 'badnowarn-props'
try {
  $skipFile = Join-Path $dir 'skip.txt'
  Set-Content -Path $skipFile -Value '' -Encoding UTF8
  $propsFile = Join-Path $dir 'Custom.props'
  Set-Content -Path $propsFile -Value "<Project><PropertyGroup><NoWarn>`$(NoWarn);CA8888</NoWarn></PropertyGroup></Project>" -Encoding UTF8
  $proj = New-TestCsproj -Dir $dir -ProjectName 'TestPropsNoWarn' `
    -ExtraImportXml "  <Import Project=`"$propsFile`" />" `
    -SkipListFile $skipFile
  $r = Invoke-Validator $proj
  Assert-Scenario 'NoWarn from imported props file errors AZSDK0002' {
    param($x) $x.Output -match 'error AZSDK0002' -and $x.Output -match 'CA8888'
  } $r
} finally { if (-not $KeepTemp) { Remove-Item -Recurse -Force $dir } }

# ----------------------------------------------------------------------------
# Scenario 5: allow-list parsing variants -> all codes recognized, no error
# ----------------------------------------------------------------------------
$dir = New-ScenarioDir 'allowlist-variants'
try {
  $skipFile = Join-Path $dir 'skip.txt'
  Set-Content -Path $skipFile -Value '' -Encoding UTF8
  $allowDir = Join-Path $dir 'allow'
  New-Item -ItemType Directory -Force -Path $allowDir | Out-Null
  $allowFile = Join-Path $allowDir 'TestAllowList.txt'
  # Mix the parser is expected to tolerate.
  $allowContent = @(
    '# A comment line',
    '',
    'nowarn:CA1111',
    '  Nowarn:CA2222  ',
    'NOWARN: CA3333',
    '   # leading-whitespace comment',
    '   nowarn:CA4444   '
  ) -join "`n"
  Set-Content -Path $allowFile -Value $allowContent -Encoding UTF8

  $proj = New-TestCsproj -Dir $dir -ProjectName 'TestAllowList' `
    -ExtraPropertyXml '    <NoWarn>$(NoWarn);CA1111;CA2222;CA3333;CA4444</NoWarn>' `
    -AllowListDir $allowDir `
    -SkipListFile $skipFile
  $r = Invoke-Validator $proj
  Assert-Scenario 'allow-list tolerates whitespace, mixed case, and blanks' {
    param($x) $x.ExitCode -eq 0 -and $x.Output -notmatch 'AZSDK0002'
  } $r
} finally { if (-not $KeepTemp) { Remove-Item -Recurse -Force $dir } }

# ----------------------------------------------------------------------------
# Scenario 6: record mode -> NoWarnAudit emitted, no error
# ----------------------------------------------------------------------------
$dir = New-ScenarioDir 'record'
try {
  $skipFile = Join-Path $dir 'skip.txt'
  Set-Content -Path $skipFile -Value '' -Encoding UTF8
  $proj = New-TestCsproj -Dir $dir -ProjectName 'TestRecord' `
    -ExtraPropertyXml '    <NoWarn>$(NoWarn);CA7777</NoWarn>' `
    -SkipListFile $skipFile
  $r = Invoke-Validator $proj -Properties @{ NoWarnValidationMode = 'record' }
  Assert-Scenario 'record mode emits NoWarnAudit and does not error' {
    param($x) $x.ExitCode -eq 0 -and $x.Output -match 'NoWarnAudit:\s*TestRecord\|.*CA7777' -and $x.Output -notmatch 'AZSDK0002'
  } $r
} finally { if (-not $KeepTemp) { Remove-Item -Recurse -Force $dir } }

# ----------------------------------------------------------------------------
# Scenario 7: allow-list entries are auto-injected into $(NoWarn) so the
# project's csproj does not need to duplicate them. Confirm by emitting
# $(NoWarn) from a target that depends on ReadAnalyzerAllowList.
# ----------------------------------------------------------------------------
$dir = New-ScenarioDir 'autoinject'
try {
  $skipFile = Join-Path $dir 'skip.txt'
  Set-Content -Path $skipFile -Value '' -Encoding UTF8
  $allowDir = Join-Path $dir 'allow'
  New-Item -ItemType Directory -Force -Path $allowDir | Out-Null
  $allowFile = Join-Path $allowDir 'TestAutoInject.txt'
  Set-Content -Path $allowFile -Value "# justification`nnowarn:CA5555`n" -Encoding UTF8

  # Add a probe target that runs after ReadAnalyzerAllowList and echoes $(NoWarn).
  $probeXml = @'
  <Target Name="ProbeNoWarn" DependsOnTargets="ReadAnalyzerAllowList">
    <Message Importance="High" Text="NoWarnProbe:$(NoWarn)" />
  </Target>
'@
  $proj = New-TestCsproj -Dir $dir -ProjectName 'TestAutoInject' `
    -AllowListDir $allowDir `
    -SkipListFile $skipFile `
    -ExtraImportXml $probeXml

  $output = & dotnet msbuild $proj '/t:ProbeNoWarn' '/nologo' '/v:m' 2>&1
  $r = @{ ExitCode = $LASTEXITCODE; Output = ($output -join "`n") }
  Assert-Scenario 'allow-listed nowarn:CODE is auto-injected into $(NoWarn)' {
    param($x) $x.Output -match 'NoWarnProbe:[^\r\n]*\bCA5555\b'
  } $r

  # And confirm the validator does NOT flag the auto-injected code (since it came
  # from the approved list, it shouldn't trigger AZSDK0002 even though it's now
  # present in $(NoWarn)).
  $rv = Invoke-Validator $proj
  Assert-Scenario 'auto-injected allow-list code does not trigger AZSDK0002' {
    param($x) $x.Output -notmatch 'error AZSDK0002'
  } $rv
} finally { if (-not $KeepTemp) { Remove-Item -Recurse -Force $dir } }

# ----------------------------------------------------------------------------
# Summary
# ----------------------------------------------------------------------------
Write-Host ''
Write-Host "Passed: $passes" -ForegroundColor Green
Write-Host "Failed: $($failures.Count)" -ForegroundColor ($failures.Count -gt 0 ? 'Red' : 'Green')
if ($failures.Count -gt 0) {
  Write-Host ''
  Write-Host 'Failed scenarios:' -ForegroundColor Red
  $failures | ForEach-Object { Write-Host "  - $_" -ForegroundColor Red }
  exit 1
}
exit 0
