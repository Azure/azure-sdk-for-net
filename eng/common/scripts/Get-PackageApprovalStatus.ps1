<#
.SYNOPSIS
Checks whether a package is approved for release.

.DESCRIPTION
Invokes the centralized Azure SDK CLI API review release gate and fails unless its structured result approves the package.

.PARAMETER PackageInfoFiles
Package-info JSON files containing the package name, version, and optional API hash.

.PARAMETER RepoOwner
The optional GitHub repository owner to query in API Review Hub.

.PARAMETER AzSdkExePath
The path to the azsdk executable.
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [array] $PackageInfoFiles,

    [string] $RepoOwner = "",

    [ValidateNotNullOrEmpty()]
    [string] $AzSdkExePath = "azsdk"
)

Set-StrictMode -Version 4
$ErrorActionPreference = "Stop"

. (Join-Path $PSScriptRoot common.ps1)

function Write-BackendStatus([string] $Name, [object] $Status) {
    if ($null -eq $Status) {
        return
    }

    $approval = if ($Status.isApproved) { "APPROVED" } else { "NOT APPROVED" }
    Write-Host $Name
    Write-Host "  Status: $approval"
    if ($Status.PSObject.Properties["reason"]) {
        Write-Host "  Reason: $($Status.reason)"
    }
    if ($Status.PSObject.Properties["statusCode"]) {
        Write-Host "  HTTP status: $($Status.statusCode)"
    }

    if ($Status.PSObject.Properties["details"]) {
        foreach ($detail in @($Status.details)) {
            Write-Host "  Detail: $detail"
        }
    }
}

function Write-ApprovalSummary([object] $Response) {
    $result = $Response.result
    $source = if ($result.PSObject.Properties["finalSource"]) { $result.finalSource } else { "unknown" }
    $reason = if ($result.PSObject.Properties["reason"]) { $result.reason } else { "none" }

    Write-Host ""
    Write-Host "Approval results"
    Write-Host "----------------"
    if ($result.PSObject.Properties["reviewHub"]) {
        Write-BackendStatus "API Review Hub" $result.reviewHub
    }
    if ($result.PSObject.Properties["apiView"]) {
        Write-Host ""
        Write-BackendStatus "APIView" $result.apiView
    }

    $approval = if ($result.isApproved) { "APPROVED" } else { "NOT APPROVED" }
    Write-Host ""
    Write-Host "Overall"
    Write-Host "  Status: $approval"
    Write-Host "  Source: $source"
    Write-Host "  Reason: $reason"
}

function Test-PackageApproval([string] $PackageName, [string] $PackageVersion, [string] $ApiHash) {
    $arguments = @(
        "package",
        "get-approval-status",
        "--language", $LanguageShort,
        "--package-name", $PackageName,
        "--package-version", $PackageVersion,
        "--output", "json"
    )

    if (-not [string]::IsNullOrWhiteSpace($ApiHash)) {
        $arguments += @("--api-hash", $ApiHash)
    }

    if (-not [string]::IsNullOrWhiteSpace($RepoOwner)) {
        $arguments += @("--repo-owner", $RepoOwner)
    }

    $hashDescription = if ([string]::IsNullOrWhiteSpace($ApiHash)) { "not provided" } else { $ApiHash }
    Write-Host "Checking package approval: language=$LanguageShort, package=$PackageName, version=$PackageVersion, apiHash=$hashDescription"
    $formattedArguments = @($arguments | ForEach-Object { Format-CommandArgument $_ })
    Write-Host "Command: azsdk $($formattedArguments -join ' ')"

    $commandResult = Invoke-AzSdkCliCommand $AzSdkExePath $arguments
    $exitCode = $commandResult.ExitCode

    try {
        $response = $commandResult.Output | ConvertFrom-Json -ErrorAction Stop
    }
    catch {
        $capturedOutput = "stdout:`n$($commandResult.Stdout)`nstderr:`n$($commandResult.Stderr)"
        throw "Package approval check returned malformed JSON for $PackageName $PackageVersion (azsdk exit code $exitCode). Captured output:`n$capturedOutput"
    }

    if ($response.PSObject.Properties["result"] -and
        $null -ne $response.result -and
        $response.result.PSObject.Properties["isApproved"] -and
        $response.result.isApproved -is [bool]) {
        Write-ApprovalSummary $response
    }

    if ($exitCode -ne 0) {
        $failureMessage = if ($response.PSObject.Properties["response_error"] -and
            -not [string]::IsNullOrWhiteSpace($response.response_error)) {
            $response.response_error
        } else {
            "azsdk exited with code $exitCode."
        }
        throw "Package approval check failed: $failureMessage"
    }

    if (-not $response.PSObject.Properties["result"] -or
        $null -eq $response.result -or
        -not $response.result.PSObject.Properties["isApproved"] -or
        $response.result.isApproved -isnot [bool]) {
        throw "Package approval check returned an invalid response for $PackageName $PackageVersion."
    }

    if (-not $response.result.isApproved) {
        throw "Package $PackageName $PackageVersion is not approved for release."
    }
}

$packageInfoPaths = @($PackageInfoFiles | Where-Object { -not [string]::IsNullOrWhiteSpace($_) })
if ($packageInfoPaths.Count -eq 0) {
    throw "At least one package-info file is required."
}

Confirm-AzSdkCliMinimumVersion $AzSdkExePath ([version] "0.6.37")
$failures = @()
foreach ($packageInfoFile in $packageInfoPaths) {
    try {
        if (-not (Test-Path $packageInfoFile -PathType Leaf)) {
            throw "Package-info file does not exist."
        }

        $packageInfo = Get-Content $packageInfoFile -Raw | ConvertFrom-Json -ErrorAction Stop
        $packageName = if ($packageInfo.PSObject.Properties["Name"]) { [string] $packageInfo.Name } else { "" }
        $packageVersion = if ($packageInfo.PSObject.Properties["Version"]) { [string] $packageInfo.Version } else { "" }
        $apiHash = if ($packageInfo.PSObject.Properties["ApiHash"]) { [string] $packageInfo.ApiHash } else { "" }
        $releaseStatus = if ($packageInfo.PSObject.Properties["ReleaseStatus"]) { [string] $packageInfo.ReleaseStatus } else { "" }

        if ([string]::IsNullOrWhiteSpace($packageName)) {
            throw "Package-info file does not contain a package Name."
        }
        if ([string]::IsNullOrWhiteSpace($packageVersion)) {
            throw "Package-info file does not contain a package Version."
        }

        try {
            Test-PackageApproval $packageName $packageVersion $apiHash
        }
        catch {
            if ($releaseStatus -eq "Unreleased") {
                Write-Host "$packageName $packageVersion is not marked for release. Ignoring approval check failure: $($_.Exception.Message)"
            }
            else {
                throw
            }
        }
    }
    catch {
        Write-Error "Package approval failed for ${packageInfoFile}: $($_.Exception.Message)" -ErrorAction Continue
        $failures += "${packageInfoFile}: $($_.Exception.Message)"
    }
}

if ($failures.Count -gt 0) {
    throw "Package approval failed for $($failures.Count) package(s):`n$($failures -join "`n")"
}