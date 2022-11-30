#!/usr/bin/env pwsh

# This script enables bypassing ARM template deployment in live tests in favor of a statically configured
# test configuration xml file stored in keyvault. The test configuration file is normally constructed
# dynamically from ARM template outputs via test-resources-post.ps1
[CmdletBinding()]
param (
    [ValidateNotNullOrEmpty()]
    [string] $TestConfigurationXmlContent
)

function getTestConfigurationPath() {
    $storageTestConfigurationTemplateName = 'TestConfigurationsTemplate.xml'
    $storageTestConfigurationName = 'TestConfigurations.xml'

    if(-not (Test-Path $env:BUILD_ARTIFACTSTAGINGDIRECTORY -ErrorAction Ignore) ) {
      Write-Verbose "Checking for '$storageTestConfigurationTemplateName' files under '$PSScriptRoot'"

      $foundFile = Get-ChildItem -Path $PSScriptRoot -Filter $storageTestConfigurationTemplateName -Recurse | Select-Object -First 1
      $storageTemplateDirName = $foundFile.Directory.FullName
      Write-Verbose "Found template dir '$storageTemplateDirName'"

    } else {
      $storageTemplateDirName = $env:BUILD_ARTIFACTSTAGINGDIRECTORY
      Write-Verbose "Found environment variable BUILD_ARTIFACTSTAGINGDIRECTORY '$storageTemplateDirName'"
    }

    # Construct the test configuration path to use based on the devops build variable for artifact staging directory
    $TestConfigurationPath = Join-Path -Path $storageTemplateDirName -ChildPath $storageTestConfigurationName
    return $TestConfigurationPath
}

$outfile = getTestConfigurationPath
Write-Host "Writing test configuration xml to $outfile"
$TestConfigurationXmlContent | Out-File $outfile

Write-Verbose "Setting AZ_STORAGE_CONFIG_PATH environment variable used by Storage Tests"
# https://github.com/microsoft/azure-pipelines-tasks/blob/master/docs/authoring/commands.md#logging-commands
Write-Host "##vso[task.setvariable variable=AZ_STORAGE_CONFIG_PATH]$outfile"
