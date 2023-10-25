# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

Write-Host "New test recordings detected but the required test-proxy tool could not be found."
Write-Host "You must install it to push new recordings to the assets repository.`n"

Write-Host "This can be done manually by following the instructions at:"
Write-Host "https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md#installation`n"

$run = Read-Host "Would you like to install the test-proxy tool now? [y/n]"
if ($run -eq 'y')
{
    dotnet tool update azure.sdk.tools.testproxy --global --add-source https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json --version "1.0.0-dev*"
}
