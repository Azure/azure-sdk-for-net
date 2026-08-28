<#
.SYNOPSIS
Marks a published package as released in API Review Hub and APIView.

.DESCRIPTION
Invokes the centralized Azure SDK CLI release-completion command and surfaces each backend result.

.PARAMETER PackageInfoFiles
Package-info JSON files containing the published package name, version, and API hash.

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

function Write-BackendResult([string] $Name, [object] $Result) {
    Write-Host $Name
    Write-Host "  Result: $($Result | ConvertTo-Json -Compress -Depth 20)"
}

function Set-PackageReleased([string] $PackageName, [string] $PackageVersion, [string] $ApiHash) {
    $arguments = @(
        "package",
        "mark-released",
        "--language", $LanguageShort,
        "--package-name", $PackageName,
        "--package-version", $PackageVersion
    )

    if (-not [string]::IsNullOrWhiteSpace($ApiHash)) {
        $arguments += @("--api-hash", $ApiHash)
    }

    $arguments += @("--output", "json")

    if (-not [string]::IsNullOrWhiteSpace($RepoOwner)) {
        $arguments += @("--repo-owner", $RepoOwner)
    }

    $hashDescription = if ([string]::IsNullOrWhiteSpace($ApiHash)) { "not provided" } else { $ApiHash }
    Write-Host "Marking package released: language=$LanguageShort, package=$PackageName, version=$PackageVersion, apiHash=$hashDescription"
    $formattedArguments = @($arguments | ForEach-Object { Format-CommandArgument $_ })
    Write-Host "Command: azsdk $($formattedArguments -join ' ')"

    $commandResult = Invoke-AzSdkCliCommand $AzSdkExePath $arguments
    $exitCode = $commandResult.ExitCode

    try {
        $response = $commandResult.Output | ConvertFrom-Json -ErrorAction Stop
    }
    catch {
        $capturedOutput = "stdout:`n$($commandResult.Stdout)`nstderr:`n$($commandResult.Stderr)"
        throw "Mark released returned malformed JSON for $PackageName $PackageVersion (azsdk exit code $exitCode). Captured output:`n$capturedOutput"
    }

    $hasReviewHubResult = $response.PSObject.Properties["api_review_hub"] -and $null -ne $response.api_review_hub
    $hasApiViewResult = $response.PSObject.Properties["api_view"] -and $null -ne $response.api_view
    if ($hasReviewHubResult) {
        Write-BackendResult "API Review Hub" $response.api_review_hub
    }
    if ($hasApiViewResult) {
        Write-BackendResult "APIView" $response.api_view
    }

    if ($exitCode -ne 0) {
        [array] $errors = if ($response.PSObject.Properties["response_errors"]) { @($response.response_errors) } else { @() }
        $failureMessage = if ($errors.Count -gt 0) { $errors -join "; " } else { "azsdk exited with code $exitCode." }
        throw "Mark released failed: $failureMessage"
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

        if ([string]::IsNullOrWhiteSpace($packageName)) {
            throw "Package-info file does not contain a package Name."
        }
        if ([string]::IsNullOrWhiteSpace($packageVersion)) {
            throw "Package-info file does not contain a package Version."
        }

        Set-PackageReleased $packageName $packageVersion $apiHash
    }
    catch {
        Write-Error "Mark released failed for ${packageInfoFile}: $($_.Exception.Message)" -ErrorAction Continue
        $failures += "${packageInfoFile}: $($_.Exception.Message)"
    }
}

if ($failures.Count -gt 0) {
    throw "Mark released failed for $($failures.Count) package(s):`n$($failures -join "`n")"
}
