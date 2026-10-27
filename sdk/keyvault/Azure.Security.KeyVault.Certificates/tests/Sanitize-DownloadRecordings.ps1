# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.SYNOPSIS
Replaces download-test cryptographic material with matching, already-public test fixtures.
.DESCRIPTION
Runs locally without starting a proxy, restoring assets, or contacting Key Vault.
Input recordings are never modified. The fixture revision must already exist in
the local assets repository. HTTP outcomes, policies, resource IDs, and variables
are preserved; only the linked certificate, CSR, thumbprint, secret, public-key
coordinates, and (where present) verification-request signature are substituted.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $InputDirectory,
    [Parameter(Mandatory)] [string] $OutputDirectory,
    [Parameter(Mandatory)] [string] $AssetsRepository,
    [Parameter(Mandatory)] [string] $TestProxyAssembly,
    [string] $FixtureRevision = 'e3e51bfaadcc380b94c3a0355c650e4572e8d8fc'
)

$ErrorActionPreference = 'Stop'
if ((Resolve-Path $InputDirectory).Path -eq [IO.Path]::GetFullPath($OutputDirectory)) {
    throw 'The output directory must be separate from the input recordings.'
}
if (Test-Path $OutputDirectory) {
    throw 'Use a new output directory; existing recordings must not be overwritten.'
}

$runtimeConfig = Get-Content ([IO.Path]::ChangeExtension($TestProxyAssembly, '.runtimeconfig.json')) -Raw | ConvertFrom-Json
$aspNetVersion = [version]($runtimeConfig.runtimeOptions.frameworks | Where-Object name -eq 'Microsoft.AspNetCore.App').version
$runtime = & dotnet --list-runtimes | ForEach-Object {
    if ($_ -match '^Microsoft.AspNetCore.App (\S+) \[(.+)\]$' -and ([version]$Matches[1]).Major -eq $aspNetVersion.Major) {
        @{ Version = [version]$Matches[1]; Path = Join-Path $Matches[2] $Matches[1] }
    }
} | Sort-Object Version -Descending | Select-Object -First 1
if (-not $runtime) {
    throw "The test proxy requires an installed ASP.NET Core $($aspNetVersion.Major) runtime."
}
foreach ($assembly in Get-ChildItem $runtime.Path -Filter 'Microsoft.*.dll') {
    $null = [Reflection.Assembly]::LoadFrom($assembly.FullName)
}
$null = [Reflection.Assembly]::LoadFrom((Resolve-Path $TestProxyAssembly).Path)
$null = New-Item -ItemType Directory -Path $OutputDirectory
$prefix = 'net/sdk/keyvault/Azure.Security.KeyVault.Certificates/tests/SessionRecords/CertificateClientLiveTests/'
$report = [Collections.Generic.List[object]]::new()

function Get-UniqueBodies($Record, [string] $Field) {
    $seen = [Collections.Generic.HashSet[string]]::new()
    foreach ($entry in $Record.Entries) {
        $body = $entry.ResponseBody
        if ($body -is [Collections.IDictionary] -and $body[$Field] -is [string] -and $seen.Add($body[$Field])) {
            $body
        }
    }
}

function Add-Replacement($Mappings, [string] $Path, [string] $Original, [string] $Fixture) {
    if ([string]::IsNullOrEmpty($Original) -or [string]::IsNullOrEmpty($Fixture)) {
        throw "Missing cryptographic fixture value for $Path."
    }
    $Mappings.Add(@{ Path = $Path; Original = $Original; Fixture = $Fixture })
}

foreach ($file in Get-ChildItem $InputDirectory -File -Filter '*.json') {
    if ($file.Name -notmatch '^(DownloadLatestCertificate|DownloadVersionedCertificate|DownloadECDsaCertificateSignLocalVerifyRemote)\(') {
        continue
    }
    $original = Get-Content $file.FullName -Raw | ConvertFrom-Json -AsHashtable
    $fixtureText = & git -C $AssetsRepository show "$($FixtureRevision):$prefix$($file.Name)"
    if ($LASTEXITCODE -ne 0) {
        throw "The public fixture is missing for $($file.Name)."
    }
    $fixture = ($fixtureText -join "`n") | ConvertFrom-Json -AsHashtable
    $originalPolicies = @($original.Entries | Where-Object { $_.RequestBody -is [Collections.IDictionary] -and $_.RequestBody.policy } | ForEach-Object { $_.RequestBody.policy })
    $fixturePolicies = @($fixture.Entries | Where-Object { $_.RequestBody -is [Collections.IDictionary] -and $_.RequestBody.policy } | ForEach-Object { $_.RequestBody.policy })
    if (($originalPolicies | ConvertTo-Json -Depth 100 -Compress) -cne ($fixturePolicies | ConvertTo-Json -Depth 100 -Compress)) {
        throw "The fixture's requested policies do not match $($file.Name)."
    }

    $mappings = [Collections.Generic.List[object]]::new()
    foreach ($field in @('csr', 'cer')) {
        $actualBodies = @(Get-UniqueBodies $original $field)
        $fixtureBodies = @(Get-UniqueBodies $fixture $field)
        if ($actualBodies.Count -ne $fixtureBodies.Count -or $actualBodies.Count -eq 0) {
            throw "The fixture's $field identities do not match $($file.Name)."
        }
        for ($i = 0; $i -lt $actualBodies.Count; $i++) {
            Add-Replacement $mappings "$.$field" $actualBodies[$i][$field] $fixtureBodies[$i][$field]
            if ($field -eq 'cer') {
                Add-Replacement $mappings '$.x5t' $actualBodies[$i].x5t $fixtureBodies[$i].x5t
            }
        }
    }

    $secrets = @($original.Entries | Where-Object { $_.RequestUri -match '/secrets/' -and $_.ResponseBody.value -is [string] })
    $fixtureSecrets = @($fixture.Entries | Where-Object { $_.RequestUri -match '/secrets/' -and $_.ResponseBody.value -is [string] })
    if ($secrets.Count -ne 1 -or $fixtureSecrets.Count -ne 1 -or
        $secrets[0].ResponseBody.contentType -cne $fixtureSecrets[0].ResponseBody.contentType) {
        throw "The fixture's secret format does not match $($file.Name)."
    }
    Add-Replacement $mappings '$.value' $secrets[0].ResponseBody.value $fixtureSecrets[0].ResponseBody.value

    $keys = @($original.Entries | Where-Object { $_.ResponseBody.key })
    $fixtureKeys = @($fixture.Entries | Where-Object { $_.ResponseBody.key })
    if ($keys.Count -ne $fixtureKeys.Count) {
        throw "The fixture's public-key count does not match $($file.Name)."
    }
    for ($i = 0; $i -lt $keys.Count; $i++) {
        if ($keys[$i].ResponseBody.key.crv -cne $fixtureKeys[$i].ResponseBody.key.crv -or
            $keys[$i].ResponseBody.key.kty -cne $fixtureKeys[$i].ResponseBody.key.kty) {
            throw "The fixture's key type or curve does not match $($file.Name)."
        }
        foreach ($coordinate in @('x', 'y')) {
            Add-Replacement $mappings "$.key.$coordinate" $keys[$i].ResponseBody.key[$coordinate] $fixtureKeys[$i].ResponseBody.key[$coordinate]
        }
    }

    $verifications = @($original.Entries | Where-Object { $_.RequestUri -match '/verify\?' })
    $fixtureVerifications = @($fixture.Entries | Where-Object { $_.RequestUri -match '/verify\?' })
    if ($verifications.Count -ne $fixtureVerifications.Count) {
        throw "The fixture's verification flow does not match $($file.Name)."
    }
    for ($i = 0; $i -lt $verifications.Count; $i++) {
        $actual = $verifications[$i]
        $reference = $fixtureVerifications[$i]
        if ($actual.RequestBody.digest -cne $reference.RequestBody.digest -or
            $actual.RequestBody.alg -cne $reference.RequestBody.alg -or
            $actual.StatusCode -ne $reference.StatusCode -or
            $actual.ResponseBody.value -ne $reference.ResponseBody.value) {
            throw "The fixture's verification contract does not match $($file.Name)."
        }
        Add-Replacement $mappings '$.value' $actual.RequestBody.value $reference.RequestBody.value
    }

    # Exact-value regexes preserve distinct versions and cannot rewrite unrelated body fields.
    $sanitizers = @($mappings | ForEach-Object {
        [Azure.Sdk.Tools.TestProxy.Sanitizers.BodyKeySanitizer]::new(
            $_.Path, $_.Fixture, "\A$([Regex]::Escape($_.Original))\z")
    })
    foreach ($entry in $original.Entries) {
        foreach ($area in @('RequestBody', 'ResponseBody')) {
            if ($entry[$area] -is [Collections.IDictionary]) {
                $body = $entry[$area] | ConvertTo-Json -Depth 100 -Compress
                foreach ($sanitizer in $sanitizers) {
                    $body = $sanitizer.SanitizeTextBody('application/json', $body)
                }
                $entry[$area] = $body | ConvertFrom-Json -AsHashtable
            }
        }
    }
    $sanitizedSecrets = @($original.Entries | Where-Object { $_.RequestUri -match '/secrets/' -and $_.ResponseBody.value -is [string] })
    if ($sanitizedSecrets[0].ResponseBody.value -cne $fixtureSecrets[0].ResponseBody.value) {
        throw "The native sanitizer did not replace the private-key payload for $($file.Name)."
    }
    $destination = Join-Path $OutputDirectory $file.Name
    $original | ConvertTo-Json -Depth 100 | Set-Content $destination -Encoding utf8NoBOM
    $report.Add(@{
        path = "$prefix$($file.Name)"
        fixtureRevision = $FixtureRevision
        fixtureRepository = 'Azure/azure-sdk-assets'
        originalSha256 = (Get-FileHash $file.FullName -Algorithm SHA256).Hash.ToLowerInvariant()
        sanitizedSha256 = (Get-FileHash $destination -Algorithm SHA256).Hash.ToLowerInvariant()
        substitutions = $mappings.Count
    })
}
if ($report.Count -eq 0) {
    throw 'No supported download recordings were found.'
}
$report | ConvertTo-Json -Depth 100 | Set-Content (Join-Path $OutputDirectory 'fixture-provenance.json') -Encoding utf8NoBOM
Write-Output "Sanitized $($report.Count) download recordings with already-public fixtures using native BodyKeySanitizer."
