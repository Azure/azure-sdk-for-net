#!/usr/bin/env pwsh

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

#Requires -Version 6.0
#Requires -PSEdition Core
#Requires -Modules @{ModuleName='Az.Accounts'; ModuleVersion='1.6.4'}
#Requires -Modules @{ModuleName='Az.Resources'; ModuleVersion='1.8.0'}

[CmdletBinding(DefaultParameterSetName = 'Default', SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    # Limit $BaseName to enough characters to be under limit plus prefixes, and https://docs.microsoft.com/azure/architecture/best-practices/resource-naming.
    [Parameter(Mandatory = $true, Position = 0)]
    [ValidatePattern('^[-a-zA-Z0-9\.\(\)_]{0,80}(?<=[a-zA-Z0-9\(\)])$')]
    [string] $BaseName,

    [Parameter(Mandatory = $true)]
    [string] $ServiceDirectory,

    [Parameter(Mandatory = $true)]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $TestApplicationId,

    [Parameter(Mandatory = $true)]
    [string] $TestApplicationSecret,

    [Parameter()]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $TestApplicationOid,

    [Parameter(ParameterSetName = 'Provisioner', Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $TenantId,

    [Parameter(ParameterSetName = 'Provisioner', Mandatory = $true)]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $ProvisionerApplicationId,

    [Parameter(ParameterSetName = 'Provisioner', Mandatory = $true)]
    [string] $ProvisionerApplicationSecret,

    [Parameter(ParameterSetName = 'Provisioner')]
    [switch] $NoProvisionerAutoSave,

    [Parameter()]
    [ValidateRange(0, [int]::MaxValue)]
    [int] $DeleteAfterHours,

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string] $Location = 'westus2',

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [hashtable] $AdditionalParameters,

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

# Support actions to invoke on exit.
$exitActions = @({
    if ($exitActions.Count -gt 1) {
        Write-Verbose 'Running registered exit actions.'
    }
})

trap {
    # Like using try..finally in PowerShell, but without keeping track of more braces or tabbing content.
    $exitActions.Invoke()
}

# Enumerate test resources to deploy. Fail if none found.
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
    Write-Warning -Message "No template files found under '$root'"
    exit
}

# Log in if requested; otherwise, the user is expected to already be authenticated via Connect-AzAccount.
if ($ProvisionerApplicationId) {
    $null = Disable-AzContextAutosave -Scope Process

    Log "Logging into service principal '$ProvisionerApplicationId'"
    $provisionerSecret = ConvertTo-SecureString -String $ProvisionerApplicationSecret -AsPlainText -Force
    $provisionerCredential = [System.Management.Automation.PSCredential]::new($ProvisionerApplicationId, $provisionerSecret)
    $provisionerAccount = Connect-AzAccount -Tenant $TenantId -Credential $provisionerCredential -ServicePrincipal

    $exitActions += {
        Write-Verbose "Logging out of service principal '$($provisionerAccount.Context.Account)'"
        $null = Disconnect-AzAccount -AzureContext $provisionerAccount.Context
    }
}

# Get test application OID from ID if not already provided.
if ($TestApplicationId -and !$TestApplicationOid) {
    $testServicePrincipal = Get-AzADServicePrincipal -ApplicationId $TestApplicationId
    if ($testServicePrincipal -and $testServicePrincipal.Id) {
        $script:TestApplicationOid = $testServicePrincipal.Id
    }
}

# Format the resource group name based on resource group naming recommendations and limitations.
$resourceGroupName = "rg-{0}-$baseName" -f ($ServiceDirectory -replace '[\\\/]', '-').Substring(0, [Math]::Min($ServiceDirectory.Length, 90 - $BaseName.Length - 4)).Trim('-')

# Tag the resource group to be deleted after a certain number of hours if specified.
$tags = @{
    ServiceDirectory = $ServiceDirectory
}

if ($PSBoundParameters.ContainsKey('DeleteAfterHours')) {
    $deleteAfter = [DateTime]::UtcNow.AddHours($DeleteAfterHours)
    $tags.Add('DeleteAfter', $deleteAfter.ToString('o'))
}

if ($env:SYSTEM_TEAMPROJECTID) {
    # Add tags for the current CI job.
    $tags += @{
        BuildId = "${env:BUILD_BUILDID}"
        BuildJob = "${env:AGENT_JOBNAME}"
        BuildNumber = "${env:BUILD_BUILDNUMBER}"
        BuildReason = "${env:BUILD_REASON}"
    }

    # Set the resource group name variable.
    Write-Host "##vso[task.setvariable variable=AZURE_RESOURCEGROUP_NAME;]$resourceGroupName"
}

Log "Creating resource group '${resourceGroupName}' in location '$Location'"
$resourceGroup = New-AzResourceGroup -Name "${resourceGroupName}" -Location $Location -Tag $tags -Force:$Force
if ($resourceGroup.ProvisioningState -eq 'Succeeded') {
    # New-AzResourceGroup would've written an error and stopped the pipeline by default anyway.
    Write-Verbose "Successfully created resource group '$($resourceGroup.ResourceGroupName)'"
}

# Populate the template parameters and merge any additional specified.
$templateParameters = @{baseName = $BaseName}
if ($TenantId) {
    $templateParameters.Add('tenantId', $TenantId)
}
if ($TestApplicationId) {
    $templateParameters.Add('testApplicationId', $TestApplicationId)
}
if ($TestApplicationSecret) {
    $templateParameters.Add('testApplicationSecret', $TestApplicationSecret)
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
                Write-Host "##vso[task.setvariable variable=$key;issecret=true;]$($variable.Value)"
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

$exitActions.Invoke()
