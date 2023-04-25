# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

param(
    [string] $AssetsJsonPath
)

function AssertInstalled() {
    if (Get-Command test-proxy -ErrorAction Ignore) {
        return $true;
    }
    $run = Read-Host "The test-proxy tool could not be found.`nWould you like to install it? [y/n]"
    if ($run -eq 'y') {
        dotnet tool update azure.sdk.tools.testproxy --global --add-source https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json --version "1.0.0-dev*"
        return $true
    } else {
        return $false
    }
}

$run = Read-Host "New test recordings detected.`nWould you like to push them to the assets repository? [y/n]"
if (($run -eq 'y') -and (AssertInstalled))
{
    test-proxy push -a $AssetsJsonPath
}
