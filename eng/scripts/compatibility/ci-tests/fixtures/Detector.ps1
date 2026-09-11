[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string]$PackagePath,
    [Parameter(Mandatory = $true)][string]$SdkRepoPath,
    [Parameter(Mandatory = $true)][string]$OutputJsonFile
)

$ErrorActionPreference = 'Stop'
$name = Split-Path $PackagePath -Leaf
if ($name -eq 'Missing') { exit 0 }
if ($name -eq 'Stale') { [Console]::Error.WriteLine('Current assembly is stale.'); exit 12 }
if ($name -eq 'MissingAssembly') { [Console]::Error.WriteLine('Current assembly is missing.'); exit 14 }
if ($name -eq 'Timeout') { Start-Sleep -Seconds 30; exit 0 }
if ($name -eq 'Malformed') { [System.IO.File]::WriteAllText($OutputJsonFile, '{invalid'); exit 0 }
$breaking = $name -in @('Breaking', 'Partial')
$report = [ordered]@{
    changes = "### Breaking Changes`nNative fixture`n### Features Added`nNone."
    hasBreakingChange = $breaking
    details = [ordered]@{
        baselineVersion = $(if ($name -eq 'NoGa') { $null } else { '1.0.0' })
        apiChanges = @($(if ($breaking) {
            @{ kind = 'removed'; symbol = 'Fixture.Removed()'; description = 'Removed member'; isBreaking = $true; diagnosticId = 'CP0002'; targetFramework = 'net8.0' }
        }))
        diagnostics = @(
            "Configuration=$env:Configuration",
            "TargetFramework=$env:TargetFramework",
            "TargetFrameworks=$env:TargetFrameworks",
            "PackagePath=$PackagePath",
            "SdkRepoPath=$SdkRepoPath",
            "WorkingDirectory=$((Get-Location).Path)",
            "NuGetPackages=$env:NUGET_PACKAGES",
            "NuGetAuthenticationPresent=$(![string]::IsNullOrEmpty($env:VSS_NUGET_ACCESSTOKEN))"
        )
        limitations = @($(if ($name -eq 'NoGa') { 'No GA release exists; compatibility was not evaluated.' }))
    }
}
[System.IO.File]::WriteAllText($OutputJsonFile, ($report | ConvertTo-Json -Depth 10))
if ($name -eq 'Partial') { [Console]::Error.WriteLine('Native process failed after writing partial output.'); exit 13 }
