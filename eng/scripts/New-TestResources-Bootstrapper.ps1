# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

param(
[string] $ServiceDirectory
)
$run = Read-Host "The test resources needed to run the live tests could not be located.`nWould you like to run the resource creation script? [y/n]"
if ($run -eq 'y'){
    & "$PSScriptRoot\..\common\TestResources\New-TestResources.ps1" $ServiceDirectory

    Read-Host "If you are not running on Windows, you will need to store the outputted environment variables manually and close and reopen your IDE.`nPress enter to close this window and resume your test run."
}