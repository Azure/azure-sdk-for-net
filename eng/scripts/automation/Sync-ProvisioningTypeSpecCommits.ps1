#Requires -Version 7.0

[CmdletBinding()]
param(
    [string]$SdkRoot = (Join-Path $PSScriptRoot ".." ".." ".." "sdk"),
    [switch]$Update
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version 3

function Get-TypeSpecLocationValue {
    param(
        [Parameter(Mandatory)]
        [string]$Content,

        [Parameter(Mandatory)]
        [string]$Name
    )

    $escapedName = [regex]::Escape($Name)
    $pattern = "(?m)^[ \t]*$escapedName[ \t]*:[ \t]*(?:""(?<double>[^""]*)""|'(?<single>[^']*)'|(?<plain>[^\s#]+))[ \t]*(?:#.*)?\r?$"
    $match = [regex]::Match($Content, $pattern)

    if (-not $match.Success) {
        throw "Required '$Name' value was not found in tsp-location.yaml."
    }

    if ($match.Groups["double"].Success) {
        return $match.Groups["double"].Value
    }

    if ($match.Groups["single"].Success) {
        return $match.Groups["single"].Value
    }

    return $match.Groups["plain"].Value
}

function Get-TypeSpecProject {
    param(
        [Parameter(Mandatory)]
        [System.IO.FileInfo]$TspLocationFile,

        [Parameter(Mandatory)]
        [ValidateSet("Provisioning", "Management")]
        [string]$Kind
    )

    $content = [System.IO.File]::ReadAllText($TspLocationFile.FullName)
    $emitterName = if ($Kind -eq "Provisioning") {
        "azure-typespec-http-client-csharp-provisioning-emitter-package"
    }
    else {
        "azure-typespec-http-client-csharp-mgmt-emitter-package"
    }

    if ($content -notmatch [regex]::Escape($emitterName)) {
        return $null
    }

    $packageDirectory = $TspLocationFile.Directory
    $metadataPath = Join-Path $packageDirectory.FullName "metadata.json"
    $apiVersions = $null

    if (Test-Path -LiteralPath $metadataPath -PathType Leaf) {
        $metadata = Get-Content -LiteralPath $metadataPath -Raw | ConvertFrom-Json
        $apiVersions = @{}
        if ($null -ne $metadata.apiVersions) {
            foreach ($property in $metadata.apiVersions.PSObject.Properties) {
                $apiVersions[$property.Name] = [string]$property.Value
            }
        }
    }

    [pscustomobject]@{
        Kind = $Kind
        LibraryName = $packageDirectory.Name
        ServiceDirectory = $packageDirectory.Parent.Name
        PackageDirectory = $packageDirectory.FullName
        TspLocationPath = $TspLocationFile.FullName
        MetadataPath = $metadataPath
        Directory = Get-TypeSpecLocationValue -Content $content -Name "directory"
        Commit = Get-TypeSpecLocationValue -Content $content -Name "commit"
        Repo = Get-TypeSpecLocationValue -Content $content -Name "repo"
        ApiVersions = $apiVersions
    }
}

function Get-TypeSpecProjects {
    param(
        [Parameter(Mandatory)]
        [string]$SdkRoot
    )

    $resolvedSdkRoot = (Resolve-Path -LiteralPath $SdkRoot).Path
    $projects = @()

    foreach ($tspLocationFile in Get-ChildItem -LiteralPath $resolvedSdkRoot -Recurse -File -Filter "tsp-location.yaml") {
        $content = [System.IO.File]::ReadAllText($tspLocationFile.FullName)

        if ($content -match "azure-typespec-http-client-csharp-provisioning-emitter-package") {
            $projects += Get-TypeSpecProject -TspLocationFile $tspLocationFile -Kind Provisioning
        }
        elseif ($content -match "azure-typespec-http-client-csharp-mgmt-emitter-package") {
            $projects += Get-TypeSpecProject -TspLocationFile $tspLocationFile -Kind Management
        }
    }

    return $projects
}

function Get-ApiVersionDifferences {
    param(
        [Parameter(Mandatory)]
        [System.Collections.IDictionary]$ProvisioningApiVersions,

        [Parameter(Mandatory)]
        [System.Collections.IDictionary]$ManagementApiVersions
    )

    $keys = @($ProvisioningApiVersions.Keys + $ManagementApiVersions.Keys | Sort-Object -Unique)
    $differences = @()

    foreach ($key in $keys) {
        $provisioningVersion = if ($ProvisioningApiVersions.Contains($key)) {
            [string]$ProvisioningApiVersions[$key]
        }
        else {
            $null
        }

        $managementVersion = if ($ManagementApiVersions.Contains($key)) {
            [string]$ManagementApiVersions[$key]
        }
        else {
            $null
        }

        if ($provisioningVersion -ne $managementVersion) {
            $differences += [pscustomobject]@{
                Provider = [string]$key
                ProvisioningApiVersion = $provisioningVersion
                ManagementApiVersion = $managementVersion
            }
        }
    }

    return $differences
}

function Get-ProvisioningTypeSpecSynchronizationPlan {
    param(
        [Parameter(Mandatory = $false)]
        [string]$SdkRoot,

        [Parameter(Mandatory = $false)]
        [object[]]$TypeSpecProjects
    )

    if ($null -eq $TypeSpecProjects) {
        if ([string]::IsNullOrWhiteSpace($SdkRoot)) {
            throw "Either SdkRoot or TypeSpecProjects must be provided."
        }

        $TypeSpecProjects = @(Get-TypeSpecProjects -SdkRoot $SdkRoot)
    }

    $provisioningProjects = @($TypeSpecProjects | Where-Object Kind -eq "Provisioning")
    $managementProjects = @($TypeSpecProjects | Where-Object Kind -eq "Management")
    $updates = @()
    $mismatches = @()
    $errors = @()

    foreach ($provisioningProject in $provisioningProjects | Sort-Object LibraryName) {
        $managementLibraryName = $provisioningProject.LibraryName -replace "^Azure\.Provisioning\.", "Azure.ResourceManager."
        $managementMatches = @(
            $managementProjects |
                Where-Object {
                    $_.ServiceDirectory -eq $provisioningProject.ServiceDirectory -and
                    $_.LibraryName -eq $managementLibraryName
                }
        )

        if ($managementMatches.Count -eq 0) {
            $errors += "No management library was found for $($provisioningProject.LibraryName). Expected '$managementLibraryName' under service directory '$($provisioningProject.ServiceDirectory)'."
            continue
        }

        if ($managementMatches.Count -gt 1) {
            $errors += "Multiple management libraries were found for $($provisioningProject.LibraryName): $($managementMatches.LibraryName -join ', ')."
            continue
        }

        $managementProject = $managementMatches[0]
        if ($null -eq $provisioningProject.ApiVersions) {
            $errors += "Missing metadata.json for $($provisioningProject.LibraryName): $($provisioningProject.MetadataPath)."
            continue
        }

        if ($null -eq $managementProject.ApiVersions) {
            $errors += "Missing metadata.json for $($managementProject.LibraryName): $($managementProject.MetadataPath)."
            continue
        }

        $apiVersionDifferences = @(Get-ApiVersionDifferences `
            -ProvisioningApiVersions $provisioningProject.ApiVersions `
            -ManagementApiVersions $managementProject.ApiVersions)

        foreach ($difference in $apiVersionDifferences) {
            $mismatches += [pscustomobject]@{
                ProvisioningLibrary = $provisioningProject.LibraryName
                ManagementLibrary = $managementProject.LibraryName
                Provider = $difference.Provider
                ProvisioningApiVersion = $difference.ProvisioningApiVersion
                ManagementApiVersion = $difference.ManagementApiVersion
            }
        }

        if ($apiVersionDifferences.Count -eq 0 -and $provisioningProject.Commit -ne $managementProject.Commit) {
            $updates += [pscustomobject]@{
                ProvisioningLibrary = $provisioningProject.LibraryName
                ManagementLibrary = $managementProject.LibraryName
                ProvisioningTspLocationPath = $provisioningProject.TspLocationPath
                CurrentCommit = $provisioningProject.Commit
                TargetCommit = $managementProject.Commit
            }
        }
    }

    [pscustomobject]@{
        Updates = $updates
        Mismatches = $mismatches
        Errors = $errors
    }
}

function Update-TypeSpecLocationCommitContent {
    param(
        [Parameter(Mandatory)]
        [string]$Content,

        [Parameter(Mandatory)]
        [string]$Commit
    )

    if ($Commit -notmatch "^[0-9a-fA-F]{40}$") {
        throw "Invalid TypeSpec commit '$Commit'. Expected a 40-character hexadecimal commit ID."
    }

    $pattern = '(?m)^(?<prefix>[ \t]*commit:[ \t]*)(?<quote>["'']?)[0-9a-fA-F]{40}(?<quoteEnd>["'']?)[ \t]*(?<lineEnd>\r?)$'
    $match = [regex]::Match($Content, $pattern)
    if (-not $match.Success) {
        throw "A single 40-character commit value was not found in tsp-location.yaml."
    }

    $updatedContent = [regex]::Replace(
        $Content,
        $pattern,
        {
            param($valueMatch)
            "$($valueMatch.Groups["prefix"].Value)$($valueMatch.Groups["quote"].Value)$Commit$($valueMatch.Groups["quoteEnd"].Value)$($valueMatch.Groups["lineEnd"].Value)"
        },
        1
    )

    return $updatedContent
}

function Update-TypeSpecLocationCommitFile {
    param(
        [Parameter(Mandatory)]
        [string]$Path,

        [Parameter(Mandatory)]
        [string]$Commit
    )

    $bytes = [System.IO.File]::ReadAllBytes($Path)
    $hasUtf8Bom = $bytes.Length -ge 3 -and
        $bytes[0] -eq 0xEF -and
        $bytes[1] -eq 0xBB -and
        $bytes[2] -eq 0xBF
    $encoding = [System.Text.UTF8Encoding]::new($hasUtf8Bom)
    $content = $encoding.GetString($bytes)
    $updatedContent = Update-TypeSpecLocationCommitContent -Content $content -Commit $Commit

    if ($updatedContent -ne $content) {
        [System.IO.File]::WriteAllText($Path, $updatedContent, $encoding)
        return $true
    }

    return $false
}

function Invoke-ProvisioningTypeSpecSynchronization {
    param(
        [Parameter(Mandatory)]
        [string]$SdkRoot,

        [switch]$Update
    )

    $plan = Get-ProvisioningTypeSpecSynchronizationPlan -SdkRoot $SdkRoot

    if ($plan.Errors.Count -gt 0) {
        throw "Provisioning TypeSpec synchronization cannot continue:`n - $($plan.Errors -join "`n - ")"
    }

    if ($plan.Mismatches.Count -gt 0) {
        $diagnostics = foreach ($mismatch in $plan.Mismatches) {
            $provisioningVersion = if ($null -eq $mismatch.ProvisioningApiVersion) { "<missing>" } else { $mismatch.ProvisioningApiVersion }
            $managementVersion = if ($null -eq $mismatch.ManagementApiVersion) { "<missing>" } else { $mismatch.ManagementApiVersion }
            "API version mismatch for $($mismatch.ProvisioningLibrary) (management library $($mismatch.ManagementLibrary)), provider $($mismatch.Provider): management=$managementVersion, provisioning=$provisioningVersion. Open a PR in Azure/azure-rest-api-specs to align the provisioning spec API version with the management library, then rerun this synchronization."
        }

        throw "Provisioning TypeSpec synchronization cannot continue because API versions differ:`n - $($diagnostics -join "`n - ")"
    }

    if (-not $Update) {
        Write-Host "Validated $($plan.Updates.Count) provisioning TypeSpec commit update(s); no files were changed."
        return $plan
    }

    foreach ($update in $plan.Updates) {
        if (Update-TypeSpecLocationCommitFile -Path $update.ProvisioningTspLocationPath -Commit $update.TargetCommit) {
            Write-Host "Updated $($update.ProvisioningLibrary) commit $($update.CurrentCommit) -> $($update.TargetCommit)."
        }
    }

    Write-Host "Synchronized $($plan.Updates.Count) provisioning TypeSpec commit(s)."
    return $plan
}

if ($MyInvocation.InvocationName -ne ".") {
    Invoke-ProvisioningTypeSpecSynchronization -SdkRoot $SdkRoot -Update:$Update | Out-Null
}
