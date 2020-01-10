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

    [Parameter()]
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
    [switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID),

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
        Write-Verbose 'Running registered exit actions'
    }
})

trap {
    # Like using try..finally in PowerShell, but without keeping track of more braces or tabbing content.
    $exitActions.Invoke()
}

# Enumerate test resources to deploy. Fail if none found.
$root = [System.IO.Path]::Combine("$PSScriptRoot/../sdk", $ServiceDirectory) | Resolve-Path
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
$resourceGroupName = if ($CI) {
    $BaseName = 't' + (New-Guid).ToString('n').Substring(0, 16)
    Write-Verbose "Generated base name '$BaseName' for CI build"

    "rg-{0}-$BaseName" -f ($ServiceDirectory -replace '[\\\/]', '-').Substring(0, [Math]::Min($ServiceDirectory.Length, 90 - $BaseName.Length - 4)).Trim('-')
} else {
    "rg-$BaseName"
}

# Tag the resource group to be deleted after a certain number of hours if specified.
$tags = @{
    Creator = if ($env:USER) { $env:USER } else { "${env:USERNAME}" }
    ServiceDirectory = $ServiceDirectory
}

if ($PSBoundParameters.ContainsKey('DeleteAfterHours')) {
    $deleteAfter = [DateTime]::UtcNow.AddHours($DeleteAfterHours)
    $tags.Add('DeleteAfter', $deleteAfter.ToString('o'))
}

if ($CI) {
    # Add tags for the current CI job.
    $tags += @{
        BuildId = "${env:BUILD_BUILDID}"
        BuildJob = "${env:AGENT_JOBNAME}"
        BuildNumber = "${env:BUILD_BUILDNUMBER}"
        BuildReason = "${env:BUILD_REASON}"
    }

    # Set the resource group name variable.
    Write-Host "Setting variable 'AZURE_RESOURCEGROUP_NAME': $resourceGroupName"
    Write-Host "##vso[task.setvariable variable=AZURE_RESOURCEGROUP_NAME;]$resourceGroupName"
}

Log "Creating resource group '$resourceGroupName' in location '$Location'"
$resourceGroup = New-AzResourceGroup -Name "$resourceGroupName" -Location $Location -Tag $tags -Force:$Force
if ($resourceGroup.ProvisioningState -eq 'Succeeded') {
    # New-AzResourceGroup would've written an error and stopped the pipeline by default anyway.
    Write-Verbose "Successfully created resource group '$($resourceGroup.ResourceGroupName)'"
}

# Populate the template parameters and merge any additional specified.
$templateParameters = @{
    baseName = $BaseName
    testApplicationId = $TestApplicationId
    testApplicationOid = "$TestApplicationOid"
}

if ($TenantId) {
    $templateParameters.Add('tenantId', $TenantId)
}
if ($TestApplicationSecret) {
    $templateParameters.Add('testApplicationSecret', $TestApplicationSecret)
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

    $preDeploymentScript = $templateFile | Split-Path | Join-Path -ChildPath 'test-resources-pre.ps1'
    if (Test-Path $preDeploymentScript) {
        Log "Invoking pre-deployment script '$preDeploymentScript'"
        &$preDeploymentScript -ResourceGroupName $resourceGroupName @PSBoundParameters
    }

    Log "Deploying template '$templateFile' to resource group '$($resourceGroup.ResourceGroupName)'"
    $deployment = New-AzResourceGroupDeployment -Name $BaseName -ResourceGroupName $resourceGroup.ResourceGroupName -TemplateFile $templateFile -TemplateParameterObject $templateFileParameters
    if ($deployment.ProvisioningState -eq 'Succeeded') {
        # New-AzResourceGroupDeployment would've written an error and stopped the pipeline by default anyway.
        Write-Verbose "Successfully deployed template '$templateFile' to resource group '$($resourceGroup.ResourceGroupName)'"
    }

    if ($deployment.Outputs.Count -and !$CI) {
        # Write an extra new line to isolate the environment variables for easy reading.
        Log "Persist the following environment variables based on your detected shell ($shell):`n"
    }

    $deploymentOutputs = @{}
    foreach ($key in $deployment.Outputs.Keys) {
        $variable = $deployment.Outputs[$key]

        # Work around bug that makes the first few characters of environment variables be lowercase.
        $key = $key.ToUpperInvariant()

        if ($variable.Type -eq 'String' -or $variable.Type -eq 'SecureString') {
            $deploymentOutputs[$key] = $variable.Value

            if ($CI) {
                # Treat all ARM template output variables as secrets since "SecureString" variables do not set values.
                # In order to mask secrets but set environment variables for any given ARM template, we set variables twice as shown below.
                Write-Host "Setting variable '$key': ***"
                Write-Host "##vso[task.setvariable variable=_$key;issecret=true;]$($variable.Value)"
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

    $postDeploymentScript = $templateFile | Split-Path | Join-Path -ChildPath 'test-resources-post.ps1'
    if (Test-Path $postDeploymentScript) {
        Log "Invoking post-deployment script '$postDeploymentScript'"
        &$postDeploymentScript -ResourceGroupName $resourceGroupName -DeploymentOutputs $deploymentOutputs @PSBoundParameters
    }
}

$exitActions.Invoke()

<#
.SYNOPSIS
Deploys resources defined for a service directory to Azure.

.DESCRIPTION
If a service directory contains one or more ARM templates named test-resources.json, they will be deployed to Azure.

A service principal must first be created before this script is run and passed to $TestApplicationId and $TestApplicationSecret. Test resources will grant this service principal access.

If you are not currently logged into an account in the Az PowerShell module, you will be asked to log in with Connect-AzAccount. Alternatively, you (or a build pipeline) can pass $ProvisionerApplicationId and $ProvisionerApplicationSecret to authenticate a service principal with access to create resources.

.PARAMETER BaseName
A name to use in the resource group and passed to the ARM template as 'baseName'.

.PARAMETER ServiceDirectory
A directory under 'sdk' in the repository root - optionally with subdirectories specified - in which to discover ARM templates named 'test-resources.json'. This can also be an absolute path or specify parent directories.

.PARAMETER TestApplicationId
A service principal ID to authenticate the test runner against deployed resources.

.PARAMETER TestApplicationSecret
Optional service principal secret (password) to authenticate the test runner against deployed resources.

.PARAMETER TenantId
The tenant ID of a service principal when a provisioner is specified.

.PARAMETER ProvisionerApplicationId
A service principal ID to provision test resources when a provisioner is specified.

.PARAMETER ProvisionerApplicationSecret
A service principal secret (password) to provision test resources when a provisioner is specified.

.PARAMETER NoProvisionerAutoSave
Do not save credentials for the provisioner in the current process.

.PARAMETER DeleteAfterHours
Optional number of hours after which the resource group is deleted. By default, the resource group will persist until you delete it.

.PARAMETER Location
Optional location where resources should be created. By default this is 'westus2'.

.PARAMETER AdditionalParameters
Optional key-value pairs of parameters to pass to the ARM template(s).

.PARAMETER CI
Indicates the script is run as part of a Continuous Integration / Continuous Deployment (CI/CD) build (only Azure Pipelines is currently supported).

.PARAMETER Force
Force creation of resources instead of being prompted.

.EXAMPLE
./New-Template.ps1 -BaseName uuid123 -ServiceDirectory keyvault -TestApplicationId $env:AZURE_CLIENT_ID -TestApplicationSecret $env:AZURE_CLIENT_SECRET

Use the currently logged-in account to provision new resources in the sdk/keyvault/test-resources.json ARM template and allow the service principal ID in environment variable AZURE_CLIENT_ID to access it.

To create a service principal in your current subscription, run: New-AzADServicePrincipal. Save the returned Id as $env:AZURE_CLIENT_ID and Secret (piped to ConvertFrom-SecureString) as $env:AZURE_CLIENT_SECRET.

.LINK
Remove-TestResources.ps1
#>
