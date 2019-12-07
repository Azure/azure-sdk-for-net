#!/usr/bin/env pwsh

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

#Requires -Version 6.0
#Requires -PSEdition Core
#Requires -Modules @{ModuleName='Az.Resources'; ModuleVersion='1.8.0'}

[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $BaseName,

    [Parameter(Mandatory = $true)]
    [string] $ServiceDirectory,

    [Parameter()]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $ProvisionerTenantId,

    [Parameter()]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $ProvisionerClientId,

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string] $ProvisionerClientSecret,

    [Parameter()]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $TestApplicationOid,

    [Parameter()]
    [ValidateRange(0, [int]::MaxValue)]
    [int] $DeleteAfterHours,

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [hashtable] $AdditionalParameters,

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string] $Location = 'westus2',

    [Parameter()]
    [switch] $Force
)

# By default stop for any error.
if (!$PSBoundParameters.ContainsKey('ErrorAction')) {
    $ErrorActionPreference = 'Stop'
}

function Log($Message) {
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

$root = Resolve-Path -Path "$PSScriptRoot/../sdk/$ServiceDirectory"
$templateFileName = 'test-resources.json'
$templateFiles = @()

Write-Verbose "Checking for '$templateFileName' files under '$root'"
Get-ChildItem -Path $root -Filter $templateFileName -Recurse | ForEach-Object {
    $templateFile = $_.FullName

    Write-Verbose "Found template '$templateFile'"
    $templateFiles += $templateFile
}

if (!$templateFiles) {
    Write-Error -Message "No template files found under '$root'" -Category 'ObjectNotFound' -TargetObject $templateFileName
    exit 2
}

# Tag the resource group to be deleted after a certain number of hours if specified.
$tags = @{}
if ($PSBoundParameters.ContainsKey('DeleteAfterHours')) {
    $deleteAfter = [DateTime]::UtcNow.AddHours($DeleteAfterHours)
    $tags.Add('DeleteAfter', $deleteAfter.ToString('o'))
}

Log "Creating resource group '${BaseName}rg' in location '$Location'"
$resourceGroup = New-AzResourceGroup -Name "${BaseName}rg" -Location $Location -Tag $tags -Force:$Force
if ($resourceGroup.ProvisioningState -eq 'Succeeded') {
    # New-AzResourceGroup would've written an error and stopped the pipeline by default anyway.
    Write-Verbose "Successfully created resource group '$($resourceGroup.ResourceGroupName)'"
}

# Populate the template parameters and merge any additional specified.
$templateParameters = @{baseName = $BaseName}
if ($ProvisionerTenantId) {
    $templateParameters.Add('provisionerTenantId', $ProvisionerTenantId)
}
if ($ProvisionerClientId) {
    $templateParameters.Add('provisionerClientId', $ProvisionerClientId)
}
if ($ProvisionerClientSecret) {
    $templateParameters.Add('provisionerClientSecret', $ProvisionerClientSecret)
}
if ($TestApplicationOid) {
    $templateParameters.Add('testApplicationOid', $TestApplicationOid)
}
if ($AdditionalParameters) {
    $templateParameters += $AdditionalParameters
}

# Try to detect the shell based on the parent process name (e.g. launch via shebang).
$shell, $shellExportFormat = if (($parentProcessName = (Get-Process -Id $PID).Parent.ProcessName) -and $parentProcessName -eq 'cmd') {
    'cmd', 'set {0}={1}'
} elseif (@('bash', 'csh', 'tcsh', 'zsh') -contains $parentProcessName) {
    'shell', 'export {0}={1}'
} else {
    'PowerShell', '$env:{0} = ''{1}'''
}

foreach ($templateFile in $templateFiles) {
    # Deployment fails if we pass in more parameters than are defined.
    Write-Verbose "Removing unnecessary parameters from template '$templateFile'"
    $templateJson = Get-Content -LiteralPath $templateFile | ConvertFrom-Json
    $templateParameterNames = $templateJson.parameters.PSObject.Properties.Name

    $templateFileParameters = $templateParameters.Clone()
    foreach ($key in $templateParameters.Keys) {
        if ($templateParameterNames -notcontains $key) {
            Write-Verbose "Removing unnecessary parameter '$key'"
            $templateFileParameters.Remove($key)
        }
    }

    Log "Deploying template '$templateFile' to resource group '$($resourceGroup.ResourceGroupName)'"
    $deployment = New-AzResourceGroupDeployment -Name $BaseName -ResourceGroupName $resourceGroup.ResourceGroupName -TemplateFile $templateFile -TemplateParameterObject $templateFileParameters
    if ($deployment.ProvisioningState -eq 'Succeeded') {
        # New-AzResourceGroupDeployment would've written an error and stopped the pipeline by default anyway.
        Write-Verbose "Successfully deployed template '$templateFile' to resource group '$($resourceGroup.ResourceGroupName)'"
    }

    if ($deployment.Outputs.Count -and !$env:SYSTEM_TEAMPROJECTID) {
        # Write an extra new line to isolate the environment variables for easy reading.
        Log "Persist the following environment variables based on your detected shell ($shell):`n"
    }

    foreach ($key in $deployment.Outputs.Keys) {
        $variable = $deployment.Outputs[$key]

        # Work around bug that makes the first few characters of environment variables be lowercase.
        $key = $key.ToUpperInvariant()

        if ($variable.Type -eq 'String' -or $variable.Type -eq 'SecureString') {
            if ($env:SYSTEM_TEAMPROJECTID) {
                # Running in Azure Pipelines.
                Write-Host "##vso[task.setvariable variable=$key;]$($variable.Value)"
            } else {
                Write-Host ($shellExportFormat -f $key, $variable.Value)
            }
        }
    }

    if ($key) {
        # Isolate the environment variables for easy reading.
        Write-Host "`n"
        $key = $null
    }
}
