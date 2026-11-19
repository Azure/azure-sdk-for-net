# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
$commit = '83c9c9881d7f72dfd0b6b167c4d05fbb69e4abdf'
$url = $null
if (-not [uri]::TryCreate($env:FOUNDRY_SDK_TEST_RESOURCES_URL, [UriKind]::Absolute, [ref] $url) -or
    $url.Scheme -cne 'https' -or -not $url.IsDefaultPort -or $url.UserInfo -or $url.Query -or $url.Fragment -or
    $url.Host -notmatch '^(dev\.azure\.com|[a-z0-9][a-z0-9-]*\.visualstudio\.com)$' -or
    $url.AbsolutePath -notmatch '/_git/[^/]+/?$') {
    throw 'Set FOUNDRY_SDK_TEST_RESOURCES_URL to a credential-free HTTPS Azure Repos Git URL.'
}

$destination = Join-Path $PSScriptRoot 'shared'
if (Test-Path -LiteralPath $destination) {
    throw 'ci/shared already exists. Use a clean workspace or remove the previous local download before fetching.'
}

$checkout = New-Item -ItemType Directory -Path (Join-Path ([IO.Path]::GetTempPath()) "foundry-ci-$([guid]::NewGuid())")
try {
    & git --no-pager -C $checkout.FullName init --quiet
    if ($LASTEXITCODE -ne 0) { throw 'Could not initialize the temporary Git checkout.' }

    $token = & az account get-access-token --resource '499b84ac-1321-427f-aa17-267ca6975798' `
        --query accessToken --output tsv --only-show-errors
    if ($LASTEXITCODE -ne 0 -or -not $token) {
        throw 'Could not obtain an Azure DevOps access token from the authenticated Azure CLI context.'
    }

    $previousHeader = $env:FOUNDRY_CI_GIT_HEADER
    $previousPrompt = $env:GIT_TERMINAL_PROMPT
    try {
        $env:FOUNDRY_CI_GIT_HEADER = "Authorization: Bearer $token"
        $env:GIT_TERMINAL_PROMPT = '0'
        # Git uses the header for this process only. Do not follow redirects or fall back to another identity.
        & git --no-pager -C $checkout.FullName -c http.followRedirects=false -c credential.helper= -c core.askPass= `
            -c http.extraHeader= --config-env=http.extraHeader=FOUNDRY_CI_GIT_HEADER `
            fetch --no-tags --depth=1 -- $url.AbsoluteUri $commit *> $null
        if ($LASTEXITCODE -ne 0) {
            throw 'Could not fetch the pinned shared assets. Verify agent connectivity and Azure Repos Read permission for the service connection identity in the target organization.'
        }
    } finally {
        $env:FOUNDRY_CI_GIT_HEADER = $previousHeader
        $env:GIT_TERMINAL_PROMPT = $previousPrompt
        $token = $null
    }

    $actualCommit = & git --no-pager -C $checkout.FullName rev-parse --verify FETCH_HEAD
    if ($LASTEXITCODE -ne 0 -or $actualCommit -cne $commit) {
        throw 'The downloaded commit does not match the reviewed shared assets revision.'
    }
    & git --no-pager -C $checkout.FullName checkout FETCH_HEAD -- ci/shared
    if ($LASTEXITCODE -ne 0) { throw 'The pinned commit does not provide ci/shared.' }

    $shared = Join-Path $checkout.FullName 'ci/shared'
    foreach ($required in @('SampleCiHelpers.ps1', 'New-ResourceDeploymentPlan.ps1',
            'Invoke-ResourceProvisioning.ps1', 'Remove-SampleResources.ps1', 'infra/main.bicep')) {
        if (-not (Test-Path -LiteralPath (Join-Path $shared $required) -PathType Leaf)) {
            throw "Downloaded ci/shared is missing $required."
        }
    }
    Move-Item -LiteralPath $shared -Destination $destination
    Write-Host "Fetched shared Foundry sample resources at commit $commit."
} finally {
    Remove-Item -LiteralPath $checkout.FullName -Recurse -Force
}
