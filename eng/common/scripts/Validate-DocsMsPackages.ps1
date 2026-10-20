<#
.SYNOPSIS
Validates reference documentation using packages built by the current build.

.DESCRIPTION
Reads generated PackageInfo files and invokes the language-specific local package
validator without resolving the target package from a feed or updating a docs repo.
All package failures are reported before the script fails.

.PARAMETER PackageInfoDirectory
Directory containing the current build's PackageInfo JSON files.

.PARAMETER ArtifactRoot
Downloaded package artifact directory, including co-built dependencies.

.PARAMETER OutputDirectory
Directory for package-specific generator output and diagnostics.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$PackageInfoDirectory,

    [Parameter(Mandatory = $true)]
    [string]$ArtifactRoot,

    [Parameter(Mandatory = $true)]
    [string]$OutputDirectory
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'common.ps1')
Set-StrictMode -Version 4

foreach ($directory in @($ArtifactRoot, $PackageInfoDirectory)) {
    if (-not (Test-Path -LiteralPath $directory -PathType Container)) {
        throw "Documentation validation infrastructure error: required directory '$directory' does not exist."
    }
}

$ArtifactRoot = (Resolve-Path -LiteralPath $ArtifactRoot).ProviderPath
$packageInfoFiles = @(Get-ChildItem -LiteralPath $PackageInfoDirectory -Filter '*.json' -File | Sort-Object Name)
$failures = [System.Collections.Generic.List[string]]::new()
$passed = 0
$skipped = 0

foreach ($packageInfoFile in $packageInfoFiles) {
    $identity = $packageInfoFile.Name
    try {
        $packageInfo = Get-Content -LiteralPath $packageInfoFile.FullName -Raw | ConvertFrom-Json -NoEnumerate
        if ($packageInfo -isnot [pscustomobject] -or
            -not $packageInfo.PSObject.Properties['Name'] -or
            $packageInfo.Name -isnot [string] -or
            [string]::IsNullOrWhiteSpace($packageInfo.Name)) {
            throw 'PackageInfo must be an object with a nonempty Name string.'
        }

        $identity = $packageInfo.Name
        if ($packageInfo.PSObject.Properties['Group'] -and $packageInfo.Group) {
            $identity = "$($packageInfo.Group):$identity"
        }

        if ($packageInfo.PSObject.Properties['ArtifactDetails'] -and $null -ne $packageInfo.ArtifactDetails) {
            if ($packageInfo.ArtifactDetails -isnot [pscustomobject]) {
                throw 'ArtifactDetails must be an object or null.'
            }
            if ($packageInfo.ArtifactDetails.PSObject.Properties['skipPublishDocMs'] -and
                "$($packageInfo.ArtifactDetails.skipPublishDocMs)" -ieq 'true') {
                LogInfo "Skipping documentation validation for ${identity}: skipPublishDocMs."
                $skipped++
                continue
            }
        }

        if (-not $packageInfo.PSObject.Properties['Version'] -or
            $packageInfo.Version -isnot [string] -or
            [string]::IsNullOrWhiteSpace($packageInfo.Version)) {
            throw 'PackageInfo must contain a nonempty Version string.'
        }

        if (-not (Test-Path "Function:$ValidateLocalDocsMsPackageFn")) {
            throw "Language validator '$ValidateLocalDocsMsPackageFn' is not implemented."
        }

        $packageOutput = Join-Path $OutputDirectory $packageInfoFile.BaseName
        $null = New-Item -ItemType Directory -Path $packageOutput -Force
        $packageOutput = (Resolve-Path -LiteralPath $packageOutput).ProviderPath
        LogInfo "Validating documentation for $identity from '$ArtifactRoot'."
        $results = @(& $ValidateLocalDocsMsPackageFn `
            -PackageInfo $packageInfo `
            -ArtifactRoot $ArtifactRoot `
            -OutputDirectory $packageOutput)

        if ($results.Count -ne 1 -or
            $null -eq $results[0] -or
            -not $results[0].PSObject.Properties['Status'] -or
            -not $results[0].PSObject.Properties['Reason'] -or
            $results[0].Status -cnotin @('Passed', 'Skipped', 'Failed') -or
            $results[0].Reason -isnot [string]) {
            throw "Validator '$ValidateLocalDocsMsPackageFn' must return one object with Status (Passed, Skipped, Failed) and a Reason string."
        }

        $result = $results[0]
        if ($result.Status -ne 'Passed' -and [string]::IsNullOrWhiteSpace($result.Reason)) {
            throw "Validator '$ValidateLocalDocsMsPackageFn' must explain a $($result.Status) result."
        }

        switch ($result.Status) {
            'Passed' {
                $passed++
                LogInfo "Documentation validation passed for $identity."
            }
            'Skipped' {
                $skipped++
                LogInfo "Skipping documentation validation for ${identity}: $($result.Reason)"
            }
            'Failed' {
                $message = "Documentation validation failed for ${identity}: $($result.Reason)"
                LogError $message
                $failures.Add($message)
            }
        }
    }
    catch {
        $message = "Documentation validation infrastructure error for '$identity' ($($packageInfoFile.Name)): $($_.Exception.Message)"
        LogError $message
        $failures.Add($message)
    }
}

LogInfo "Documentation validation: $passed passed, $skipped skipped, $($failures.Count) failed."
if ($failures.Count -gt 0) {
    throw ($failures -join [Environment]::NewLine)
}
if ($passed -eq 0) {
    LogInfo 'No eligible packages required documentation validation.'
}
