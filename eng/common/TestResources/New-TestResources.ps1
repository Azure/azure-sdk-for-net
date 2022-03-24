#!/usr/bin/env pwsh

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

#Requires -Version 6.0
#Requires -PSEdition Core
#Requires -Modules @{ModuleName='Az.Accounts'; ModuleVersion='1.6.4'}
#Requires -Modules @{ModuleName='Az.Resources'; ModuleVersion='1.8.0'}

[CmdletBinding(DefaultParameterSetName = 'Default', SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    # Limit $BaseName to enough characters to be under limit plus prefixes, and https://docs.microsoft.com/azure/architecture/best-practices/resource-naming
    [Parameter()]
    [ValidatePattern('^[-a-zA-Z0-9\.\(\)_]{0,80}(?<=[a-zA-Z0-9\(\)])$')]
    [string] $BaseName,

    [ValidatePattern('^[-\w\._\(\)]+$')]
    [string] $ResourceGroupName,

    [Parameter(Mandatory = $true, Position = 0)]
    [string] $ServiceDirectory,

    [Parameter()]
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

    # Azure SDK Developer Playground subscription is assumed if not set
    [Parameter()]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $SubscriptionId,

    [Parameter(ParameterSetName = 'Provisioner', Mandatory = $true)]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $ProvisionerApplicationId,

    [Parameter(ParameterSetName = 'Provisioner', Mandatory = $false)]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $ProvisionerApplicationOid,

    [Parameter(ParameterSetName = 'Provisioner', Mandatory = $true)]
    [string] $ProvisionerApplicationSecret,

    [Parameter()]
    [ValidateRange(1, 7*24)]
    [int] $DeleteAfterHours = 120,

    [Parameter()]
    [string] $Location = '',

    [Parameter()]
    [ValidateSet('AzureCloud', 'AzureUSGovernment', 'AzureChinaCloud', 'Dogfood')]
    [string] $Environment = 'AzureCloud',

    [Parameter()]
    [hashtable] $ArmTemplateParameters,

    [Parameter()]
    [hashtable] $AdditionalParameters,

    [Parameter()]
    [ValidateNotNull()]
    [hashtable] $EnvironmentVariables = @{},

    [Parameter()]
    [switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID),

    [Parameter()]
    [switch] $Force,

    [Parameter()]
    [switch] $OutFile,

    [Parameter()]
    [switch] $SuppressVsoCommands = ($null -eq $env:SYSTEM_TEAMPROJECTID),

    # Captures any arguments not declared here (no parameter errors)
    # This enables backwards compatibility with old script versions in
    # hotfix branches if and when the dynamic subscription configuration
    # secrets get updated to add new parameters.
    [Parameter(ValueFromRemainingArguments = $true)]
    $NewTestResourcesRemainingArguments
)

. $PSScriptRoot/SubConfig-Helpers.ps1

# By default stop for any error.
if (!$PSBoundParameters.ContainsKey('ErrorAction')) {
    $ErrorActionPreference = 'Stop'
}

function Log($Message)
{
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

# vso commands are specially formatted log lines that are parsed by Azure Pipelines
# to perform additional actions, most commonly marking values as secrets.
# https://docs.microsoft.com/en-us/azure/devops/pipelines/scripts/logging-commands
function LogVsoCommand([string]$message)
{
    if (!$CI -or $SuppressVsoCommands) {
        return
    }
    Write-Host $message
}

function Retry([scriptblock] $Action, [int] $Attempts = 5)
{
    $attempt = 0
    $sleep = 5

    while ($attempt -lt $Attempts) {
        try {
            $attempt++
            return $Action.Invoke()
        } catch {
            if ($attempt -lt $Attempts) {
                $sleep *= 2

                Write-Warning "Attempt $attempt failed: $_. Trying again in $sleep seconds..."
                Start-Sleep -Seconds $sleep
            } else {
                Write-Error -ErrorRecord $_
            }
        }
    }
}

# NewServicePrincipalWrapper creates an object from an AAD graph or Microsoft Graph service principal object type.
# This is necessary to work around breaking changes introduced in Az version 7.0.0:
# https://azure.microsoft.com/en-us/updates/update-your-apps-to-use-microsoft-graph-before-30-june-2022/
function NewServicePrincipalWrapper([string]$subscription, [string]$resourceGroup, [string]$displayName)
{
    if ((Get-Module Az.Resources).Version -eq "5.3.0") {
        # https://github.com/Azure/azure-powershell/issues/17040
        # New-AzAdServicePrincipal calls will fail with:
        # "You cannot call a method on a null-valued expression."
        Write-Warning "Az.Resources version 5.3.0 is not supported. Please update to >= 5.3.1"
        Write-Warning "Update-Module Az.Resources -RequiredVersion 5.3.1"
        exit 1
    }
    $servicePrincipal = Retry {
        New-AzADServicePrincipal -Role "Owner" -Scope "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName" -DisplayName $displayName
    }
    $spPassword = ""
    $appId = ""
    if (Get-Member -Name "Secret" -InputObject $servicePrincipal -MemberType property) {
        Write-Verbose "Using legacy PSADServicePrincipal object type from AAD graph API"
        # Secret property exists on PSADServicePrincipal type from AAD graph in Az # module versions < 7.0.0
        $spPassword = $servicePrincipal.Secret
        $appId = $servicePrincipal.ApplicationId
    } else {
        if ((Get-Module Az.Resources).Version -eq "5.1.0") {
            Write-Verbose "Creating password and credential for service principal via MS Graph API"
            Write-Warning "Please update Az.Resources to >= 5.2.0 by running 'Update-Module Az'"
            # Microsoft graph objects (Az.Resources version == 5.1.0) do not provision a secret on creation so it must be added separately.
            # Submitting a password credential object without specifying a password will result in one being generated on the server side.
            $password = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential"
            $password.DisplayName = "Password for $displayName"
            $credential = Retry { New-AzADSpCredential -PasswordCredentials $password -ServicePrincipalObject $servicePrincipal }
            $spPassword = ConvertTo-SecureString $credential.SecretText -AsPlainText -Force
            $appId = $servicePrincipal.AppId
        } else {
            Write-Verbose "Creating service principal credential via MS Graph API"
            # In 5.2.0 the password credential issue was fixed (see https://github.com/Azure/azure-powershell/pull/16690) but the
            # parameter set was changed making the above call fail due to a missing ServicePrincipalId parameter.
            $credential = Retry { $servicePrincipal | New-AzADSpCredential }
            $spPassword = ConvertTo-SecureString $credential.SecretText -AsPlainText -Force
            $appId = $servicePrincipal.AppId
        }
    }

    return @{
        AppId = $appId
        ApplicationId = $appId
        # This is the ObjectId/OID but most return objects use .Id so keep it consistent to prevent confusion
        Id = $servicePrincipal.Id
        DisplayName = $servicePrincipal.DisplayName
        Secret = $spPassword
    }
}

function LoadCloudConfig([string] $env)
{
    $configPath = "$PSScriptRoot/clouds/$env.json"
    if (!(Test-Path $configPath)) {
        Write-Warning "Could not find cloud configuration for environment '$env'"
        return @{}
    }

    $config = Get-Content $configPath | ConvertFrom-Json -AsHashtable
    return $config
}

function MergeHashes([hashtable] $source, [psvariable] $dest)
{
    foreach ($key in $source.Keys) {
        if ($dest.Value.Contains($key) -and $dest.Value[$key] -ne $source[$key]) {
            Write-Warning ("Overwriting '$($dest.Name).$($key)' with value '$($dest.Value[$key])' " +
                          "to new value '$($source[$key])'")
        }
        $dest.Value[$key] = $source[$key]
    }
}

function BuildBicepFile([System.IO.FileSystemInfo] $file)
{
    if (!(Get-Command bicep -ErrorAction Ignore)) {
        Write-Error "A bicep file was found at '$($file.FullName)' but the Azure Bicep CLI is not installed. See https://aka.ms/install-bicep-pwsh"
        throw
    }

    $tmp = $env:TEMP ? $env:TEMP : [System.IO.Path]::GetTempPath()
    $templateFilePath = Join-Path $tmp "test-resources.$(New-Guid).compiled.json"

    # Az can deploy bicep files natively, but by compiling here it becomes easier to parse the
    # outputted json for mismatched parameter declarations.
    bicep build $file.FullName --outfile $templateFilePath
    if ($LASTEXITCODE) {
        Write-Error "Failure building bicep file '$($file.FullName)'"
        throw
    }

    return $templateFilePath
}

function BuildDeploymentOutputs([string]$serviceName, [object]$azContext, [object]$deployment) {
    $serviceDirectoryPrefix = BuildServiceDirectoryPrefix $serviceName
    # Add default values
    $deploymentOutputs = [Ordered]@{
        "${serviceDirectoryPrefix}CLIENT_ID" = $TestApplicationId;
        "${serviceDirectoryPrefix}CLIENT_SECRET" = $TestApplicationSecret;
        "${serviceDirectoryPrefix}TENANT_ID" = $azContext.Tenant.Id;
        "${serviceDirectoryPrefix}SUBSCRIPTION_ID" =  $azContext.Subscription.Id;
        "${serviceDirectoryPrefix}RESOURCE_GROUP" = $resourceGroup.ResourceGroupName;
        "${serviceDirectoryPrefix}LOCATION" = $resourceGroup.Location;
        "${serviceDirectoryPrefix}ENVIRONMENT" = $azContext.Environment.Name;
        "${serviceDirectoryPrefix}AZURE_AUTHORITY_HOST" = $azContext.Environment.ActiveDirectoryAuthority;
        "${serviceDirectoryPrefix}RESOURCE_MANAGER_URL" = $azContext.Environment.ResourceManagerUrl;
        "${serviceDirectoryPrefix}SERVICE_MANAGEMENT_URL" = $azContext.Environment.ServiceManagementUrl;
        "AZURE_SERVICE_DIRECTORY" = $serviceName.ToUpperInvariant();
    }

    MergeHashes $EnvironmentVariables $(Get-Variable deploymentOutputs)

    foreach ($key in $deployment.Outputs.Keys) {
        $variable = $deployment.Outputs[$key]

        # Work around bug that makes the first few characters of environment variables be lowercase.
        $key = $key.ToUpperInvariant()

        if ($variable.Type -eq 'String' -or $variable.Type -eq 'SecureString') {
            $deploymentOutputs[$key] = $variable.Value
        }
    }

    return $deploymentOutputs
}

function SetDeploymentOutputs([string]$serviceName, [object]$azContext, [object]$deployment, [object]$templateFile) {
    $deploymentOutputs = BuildDeploymentOutputs $serviceName $azContext $deployment

    if ($OutFile) {
        if (!$IsWindows) {
            Write-Host 'File option is supported only on Windows'
        }

        $outputFile = "$($templateFile.originalFilePath).env"

        $environmentText = $deploymentOutputs | ConvertTo-Json;
        $bytes = [System.Text.Encoding]::UTF8.GetBytes($environmentText)
        $protectedBytes = [Security.Cryptography.ProtectedData]::Protect($bytes, $null, [Security.Cryptography.DataProtectionScope]::CurrentUser)

        Set-Content $outputFile -Value $protectedBytes -AsByteStream -Force

        Write-Host "Test environment settings`n $environmentText`nstored into encrypted $outputFile"
    } else {
        if (!$CI) {
            # Write an extra new line to isolate the environment variables for easy reading.
            Log "Persist the following environment variables based on your detected shell ($shell):`n"
        }

        # Marking values as secret by allowed keys below is not sufficient, as there may be outputs set in the ARM/bicep
        # file that re-mark those values as secret (since all user-provided deployment outputs are treated as secret by default).
        # This variable supports a second check on not marking previously allowed keys/values as secret.
        $notSecretValues = @()
        foreach ($key in $deploymentOutputs.Keys) {
            $value = $deploymentOutputs[$key]
            $EnvironmentVariables[$key] = $value

            if ($CI) {
                if (ShouldMarkValueAsSecret $serviceName $key $value $notSecretValues) {
                    # Treat all ARM template output variables as secrets since "SecureString" variables do not set values.
                    # In order to mask secrets but set environment variables for any given ARM template, we set variables twice as shown below.
                    LogVsoCommand "##vso[task.setvariable variable=_$key;issecret=true;]$value"
                    Write-Host "Setting variable as secret '$key'"
                } else {
                    Write-Host "Setting variable '$key': $value"
                    $notSecretValues += $value
                }
                LogVsoCommand "##vso[task.setvariable variable=$key;]$value"
            } else {
                Write-Host ($shellExportFormat -f $key, $value)
            }
        }

        if ($key) {
            # Isolate the environment variables for easy reading.
            Write-Host "`n"
            $key = $null
        }
    }

    return $deploymentOutputs
}

# Support actions to invoke on exit.
$exitActions = @({
    if ($exitActions.Count -gt 1) {
        Write-Verbose 'Running registered exit actions'
    }
})

New-Variable -Name 'initialContext' -Value (Get-AzContext) -Option Constant
if ($initialContext) {
    $exitActions += {
        Write-Verbose "Restoring initial context: $($initialContext.Account)"
        $null = $initialContext | Select-AzContext
    }
}

# try..finally will also trap Ctrl+C.
try {

    # Enumerate test resources to deploy. Fail if none found.
    $repositoryRoot = "$PSScriptRoot/../../.." | Resolve-Path
    $root = [System.IO.Path]::Combine($repositoryRoot, "sdk", $ServiceDirectory) | Resolve-Path
    $templateFiles = @()

    'test-resources.json', 'test-resources.bicep' | ForEach-Object {
        Write-Verbose "Checking for '$_' files under '$root'"
        Get-ChildItem -Path $root -Filter "$_" -Recurse | ForEach-Object {
            Write-Verbose "Found template '$($_.FullName)'"
            if ($_.Extension -eq '.bicep') {
                $templateFile = @{originalFilePath = $_.FullName; jsonFilePath = (BuildBicepFile $_)}
                $templateFiles += $templateFile
            } else {
                $templateFile = @{originalFilePath = $_.FullName; jsonFilePath = $_.FullName}
                $templateFiles += $templateFile
            }
        }
    }

    if (!$templateFiles) {
        Write-Warning -Message "No template files found under '$root'"
        exit
    }

    $UserName =  if ($env:USER) { $env:USER } else { "${env:USERNAME}" }
    # Remove spaces, etc. that may be in $UserName
    $UserName = $UserName -replace '\W'

    # Make sure $BaseName is set.
    if ($CI) {
        $BaseName = 't' + (New-Guid).ToString('n').Substring(0, 16)
        Log "Generated base name '$BaseName' for CI build"
    } elseif (!$BaseName) {
        # Handle service directories in nested directories, e.g. `data/aztables`
        $serviceDirectorySafeName = $ServiceDirectory -replace '[/\\]', ''
        $BaseName = "$UserName$serviceDirectorySafeName"
        Log "BaseName was not set. Using default base name '$BaseName'"
    }

    # Make sure pre- and post-scripts are passed formerly required arguments.
    $PSBoundParameters['BaseName'] = $BaseName

    # Try detecting repos that support OutFile and defaulting to it
    if (!$CI -and !$PSBoundParameters.ContainsKey('OutFile') -and $IsWindows) {
        # TODO: find a better way to detect the language
        if (Test-Path "$repositoryRoot/eng/service.proj") {
            $OutFile = $true
            Log "Detected .NET repository. Defaulting OutFile to true. Test environment settings would be stored into the file so you don't need to set environment variables manually."
        }
    }

    # If no location is specified use safe default locations for the given
    # environment. If no matching environment is found $Location remains an empty
    # string.
    if (!$Location) {
        $Location = @{
            'AzureCloud' = 'westus2';
            'AzureUSGovernment' = 'usgovvirginia';
            'AzureChinaCloud' = 'chinaeast2';
            'Dogfood' = 'westus'
        }[$Environment]

        Write-Verbose "Location was not set. Using default location for environment: '$Location'"
    }

    if (!$CI -and $PSCmdlet.ParameterSetName -ne "Provisioner") {
        # Make sure the user is logged in to create a service principal.
        $context = Get-AzContext;
        if (!$context) {
            Log 'User not logged in. Logging in now...'
            $context = (Connect-AzAccount).Context
        }

        $currentSubcriptionId = $context.Subscription.Id

        # If no subscription was specified, try to select the Azure SDK Developer Playground subscription.
        # Ignore errors to leave the automatically selected subscription.
        if ($SubscriptionId) {
            if ($currentSubcriptionId -ne $SubscriptionId) {
                Log "Selecting subscription '$SubscriptionId'"
                $null = Select-AzSubscription -Subscription $SubscriptionId

                $exitActions += {
                    Log "Selecting previous subscription '$currentSubcriptionId'"
                    $null = Select-AzSubscription -Subscription $currentSubcriptionId
                }

                # Update the context.
                $context = Get-AzContext
            }
        } else {
            if ($currentSubcriptionId -ne 'faa080af-c1d8-40ad-9cce-e1a450ca5b57') {
                Log "Attempting to select subscription 'Azure SDK Developer Playground (faa080af-c1d8-40ad-9cce-e1a450ca5b57)'"
                $null = Select-AzSubscription -Subscription 'faa080af-c1d8-40ad-9cce-e1a450ca5b57' -ErrorAction Ignore

                # Update the context.
                $context = Get-AzContext
            }

            $SubscriptionId = $context.Subscription.Id
            $PSBoundParameters['SubscriptionId'] = $SubscriptionId
        }

        # Use cache of well-known team subs without having to be authenticated.
        $wellKnownSubscriptions = @{
            'faa080af-c1d8-40ad-9cce-e1a450ca5b57' = 'Azure SDK Developer Playground'
            'a18897a6-7e44-457d-9260-f2854c0aca42' = 'Azure SDK Engineering System'
            '2cd617ea-1866-46b1-90e3-fffb087ebf9b' = 'Azure SDK Test Resources'
        }

        # Print which subscription is currently selected.
        $subscriptionName = $context.Subscription.Id
        if ($wellKnownSubscriptions.ContainsKey($subscriptionName)) {
            $subscriptionName = '{0} ({1})' -f $wellKnownSubscriptions[$subscriptionName], $subscriptionName
        }

        Log "Using subscription '$subscriptionName'"

        # Make sure the TenantId is also updated from the current context.
        # PSBoundParameters is not updated to avoid confusing parameter sets.
        if (!$TenantId) {
            $TenantId = $context.Subscription.TenantId
        }
    }

    # If a provisioner service principal was provided, log into it to perform the pre- and post-scripts and deployments.
    if ($ProvisionerApplicationId) {
        $null = Disable-AzContextAutosave -Scope Process

        Log "Logging into service principal '$ProvisionerApplicationId'."
        $provisionerSecret = ConvertTo-SecureString -String $ProvisionerApplicationSecret -AsPlainText -Force
        $provisionerCredential = [System.Management.Automation.PSCredential]::new($ProvisionerApplicationId, $provisionerSecret)

        # Use the given subscription ID if provided.
        $subscriptionArgs = if ($SubscriptionId) {
            @{Subscription = $SubscriptionId}
        } else {
            @{}
        }

        $provisionerAccount = Retry {
            Connect-AzAccount -Force:$Force -Tenant $TenantId -Credential $provisionerCredential -ServicePrincipal -Environment $Environment @subscriptionArgs
        }

        $exitActions += {
            Write-Verbose "Logging out of service principal '$($provisionerAccount.Context.Account)'"

            # Only attempt to disconnect if the -WhatIf flag was not set. Otherwise, this call is not necessary and will fail.
            if ($PSCmdlet.ShouldProcess($ProvisionerApplicationId)) {
                $null = Disconnect-AzAccount -AzureContext $provisionerAccount.Context
            }
        }
    }

    # Determine the Azure context that the script is running in.
    $context = Get-AzContext;

    # Make sure the provisioner OID is set so we can pass it through to the deployment.
    if (!$ProvisionerApplicationId -and !$ProvisionerApplicationOid) {
        if ($context.Account.Type -eq 'User') {
            $user = Get-AzADUser -UserPrincipalName $context.Account.Id
            $ProvisionerApplicationOid = $user.Id
        } elseif ($context.Account.Type -eq 'ServicePrincipal') {
            $sp = Get-AzADServicePrincipal -ApplicationId $context.Account.Id
            $ProvisionerApplicationOid = $sp.Id
        } else {
            Write-Warning "Getting the OID for provisioner type '$($context.Account.Type)' is not supported and will not be passed to deployments (seldom required)."
        }
    } elseif (!$ProvisionerApplicationOid) {
        $sp = Get-AzADServicePrincipal -ApplicationId $ProvisionerApplicationId
        $ProvisionerApplicationOid = $sp.Id
    }

    # If the ServiceDirectory has multiple segments use the last directory name
    # e.g. D:\foo\bar -> bar or foo/bar -> bar
    $serviceName = if (Split-Path $ServiceDirectory) {
        Split-Path -Leaf $ServiceDirectory
    } else {
        $ServiceDirectory.Trim('/')
    }

    $ResourceGroupName = if ($ResourceGroupName) {
        $ResourceGroupName
    } elseif ($CI) {
        # Format the resource group name based on resource group naming recommendations and limitations.
        "rg-{0}-$BaseName" -f ($serviceName -replace '[\\\/:]', '-').Substring(0, [Math]::Min($serviceName.Length, 90 - $BaseName.Length - 4)).Trim('-')
    } else {
        "rg-$BaseName"
    }

    $tags = @{
        Owners = $UserName
        ServiceDirectory = $ServiceDirectory
    }

    # Tag the resource group to be deleted after a certain number of hours.
    Write-Warning "Any clean-up scripts running against subscription '$SubscriptionId' may delete resource group '$ResourceGroupName' after $DeleteAfterHours hours."
    $deleteAfter = [DateTime]::UtcNow.AddHours($DeleteAfterHours).ToString('o')
    $tags['DeleteAfter'] = $deleteAfter

    if ($CI) {
        # Add tags for the current CI job.
        $tags += @{
            BuildId = "${env:BUILD_BUILDID}"
            BuildJob = "${env:AGENT_JOBNAME}"
            BuildNumber = "${env:BUILD_BUILDNUMBER}"
            BuildReason = "${env:BUILD_REASON}"
        }

        # Set the resource group name variable.
        Write-Host "Setting variable 'AZURE_RESOURCEGROUP_NAME': $ResourceGroupName"
        LogVsoCommand "##vso[task.setvariable variable=AZURE_RESOURCEGROUP_NAME;]$ResourceGroupName"
        if ($EnvironmentVariables.ContainsKey('AZURE_RESOURCEGROUP_NAME') -and `
            $EnvironmentVariables['AZURE_RESOURCEGROUP_NAME'] -ne $ResourceGroupName)
        {
            Write-Warning ("Overwriting 'EnvironmentVariables.AZURE_RESOURCEGROUP_NAME' with value " +
                "'$($EnvironmentVariables['AZURE_RESOURCEGROUP_NAME'])' " + "to new value '$($ResourceGroupName)'")
        }
        $EnvironmentVariables['AZURE_RESOURCEGROUP_NAME'] = $ResourceGroupName
    }

    Log "Creating resource group '$ResourceGroupName' in location '$Location'"
    $resourceGroup = Retry {
        New-AzResourceGroup -Name "$ResourceGroupName" -Location $Location -Tag $tags -Force:$Force
    }

    if ($resourceGroup.ProvisioningState -eq 'Succeeded') {
        # New-AzResourceGroup would've written an error and stopped the pipeline by default anyway.
        Write-Verbose "Successfully created resource group '$($resourceGroup.ResourceGroupName)'"
    }
    elseif (!$resourceGroup) {
        if (!$PSCmdlet.ShouldProcess($resourceGroupName)) {
            # If the -WhatIf flag was passed, there will be no resource group created. Fake it.
            $resourceGroup = [PSCustomObject]@{
                ResourceGroupName = $resourceGroupName
                Location = $Location
            }
        } else {
            Write-Error "Resource group '$ResourceGroupName' already exists." -Category ResourceExists -RecommendedAction "Delete resource group '$ResourceGroupName', or overwrite it when redeploying."
        }
    }

    # If no test application ID was specified during an interactive session, create a new service principal.
    if (!$CI -and !$TestApplicationId) {
        # Cache the created service principal in this session for frequent reuse.
        $servicePrincipal = if ($AzureTestPrincipal -and (Get-AzADServicePrincipal -ApplicationId $AzureTestPrincipal.AppId) -and $AzureTestSubscription -eq $SubscriptionId) {
            Log "TestApplicationId was not specified; loading cached service principal '$($AzureTestPrincipal.AppId)'"
            $AzureTestPrincipal
        } else {
            Log "TestApplicationId was not specified; creating a new service principal in subscription '$SubscriptionId'"
            $suffix = (New-Guid).ToString('n').Substring(0, 4)

            # Service principals in the Microsoft AAD tenant must end with an @microsoft.com domain; those in other tenants
            # are not permitted to do so. Format the non-MS name so there's an assocation with the Azure SDK.
            if ($TenantId -eq '72f988bf-86f1-41af-91ab-2d7cd011db47') {
                $displayName = "test-resources-$($baseName)$suffix.microsoft.com"
            } else {
                $displayName = "$($baseName)$suffix.test-resources.azure.sdk"
            }

            $servicePrincipalWrapper = NewServicePrincipalWrapper -subscription $SubscriptionId -resourceGroup $ResourceGroupName -displayName $DisplayName

            $global:AzureTestPrincipal = $servicePrincipalWrapper
            $global:AzureTestSubscription = $SubscriptionId

            Log "Created service principal. AppId: '$($AzureTestPrincipal.AppId)' ObjectId: '$($AzureTestPrincipal.Id)'"
            $servicePrincipalWrapper
            $resourceGroupRoleAssigned = $true
        }

        $TestApplicationId = $servicePrincipal.AppId
        $TestApplicationOid = $servicePrincipal.Id
        $TestApplicationSecret = (ConvertFrom-SecureString $servicePrincipal.Secret -AsPlainText)
    }

    # Get test application OID from ID if not already provided. This may fail if the
    # provisioner is a service principal without permissions to query AAD. This is a
    # critical failure, but we should prompt with possible remediation.
    if ($TestApplicationId -and !$TestApplicationOid) {
        Log "Attempting to query the Object ID for the test service principal"

        try {
            $testServicePrincipal = Retry {
                Get-AzADServicePrincipal -ApplicationId $TestApplicationId
            }
        }
        catch {
            Write-Warning "The Object ID of the test application was unable to be queried. You may want to consider passing it explicitly with the 'TestApplicationOid` parameter."
            throw $_.Exception
        }

        if ($testServicePrincipal -and $testServicePrincipal.Id) {
            $script:TestApplicationOid = $testServicePrincipal.Id
        }
    }

    # Make sure pre- and post-scripts are passed formerly required arguments.
    $PSBoundParameters['TestApplicationId'] = $TestApplicationId
    $PSBoundParameters['TestApplicationOid'] = $TestApplicationOid
    $PSBoundParameters['TestApplicationSecret'] = $TestApplicationSecret

    # If the role hasn't been explicitly assigned to the resource group and a cached service principal is in use,
    # query to see if the grant is needed.
    if (!$resourceGroupRoleAssigned -and $AzureTestPrincipal) {
        $roleAssignment = Get-AzRoleAssignment -ObjectId $AzureTestPrincipal.Id -RoleDefinitionName 'Owner' -ResourceGroupName "$ResourceGroupName" -ErrorAction SilentlyContinue
        $resourceGroupRoleAssigned = ($roleAssignment.RoleDefinitionName -eq 'Owner')
    }

   # If needed, grant the test service principal ownership over the resource group. This may fail if the provisioner
   # is a service principal without permissions to grant RBAC roles to other service principals. That should not be
   # considered a critical failure, as the test application may have subscription-level permissions and not require
   # the explicit grant.
   if (!$resourceGroupRoleAssigned) {
        Log "Attempting to assigning the 'Owner' role for '$ResourceGroupName' to the Test Application '$TestApplicationId'"
        $principalOwnerAssignment = New-AzRoleAssignment -RoleDefinitionName "Owner" -ApplicationId "$TestApplicationId" -ResourceGroupName "$ResourceGroupName" -ErrorAction SilentlyContinue

        if ($principalOwnerAssignment.RoleDefinitionName -eq 'Owner') {
            Write-Verbose "Successfully assigned ownership of '$ResourceGroupName' to the Test Application '$TestApplicationId'"
        } else {
            Write-Warning "The 'Owner' role for '$ResourceGroupName' could not be assigned. You may need to manually grant 'Owner' for the resource group to the Test Application '$TestApplicationId' if it does not have subscription-level permissions."
        }
    }

    # Populate the template parameters and merge any additional specified.
    $templateParameters = @{
        baseName = $BaseName
        testApplicationId = $TestApplicationId
        testApplicationOid = "$TestApplicationOid"
    }
    if ($ProvisionerApplicationOid) {
        $templateParameters["provisionerApplicationOid"] = "$ProvisionerApplicationOid"
    }

    if ($TenantId) {
        $templateParameters.Add('tenantId', $TenantId)
    }
    if ($TestApplicationSecret) {
        $templateParameters.Add('testApplicationSecret', $TestApplicationSecret)
    }

    $defaultCloudParameters = LoadCloudConfig $Environment
    MergeHashes $defaultCloudParameters $(Get-Variable templateParameters)
    MergeHashes $ArmTemplateParameters $(Get-Variable templateParameters)
    MergeHashes $AdditionalParameters $(Get-Variable templateParameters)

    # Include environment-specific parameters only if not already provided as part of the "ArmTemplateParameters"
    if (($context.Environment.StorageEndpointSuffix) -and (-not ($templateParameters.ContainsKey('storageEndpointSuffix')))) {
        $templateParameters.Add('storageEndpointSuffix', $context.Environment.StorageEndpointSuffix)
    }

    # Try to detect the shell based on the parent process name (e.g. launch via shebang).
    $shell, $shellExportFormat = if (($parentProcessName = (Get-Process -Id $PID).Parent.ProcessName) -and $parentProcessName -eq 'cmd') {
        'cmd', 'set {0}={1}'
    } elseif (@('bash', 'csh', 'tcsh', 'zsh') -contains $parentProcessName) {
        'shell', 'export {0}={1}'
    } else {
        'PowerShell', '${{env:{0}}} = ''{1}'''
    }

    # Deploy the templates
    foreach ($templateFile in $templateFiles) {
        # Deployment fails if we pass in more parameters than are defined.
        Write-Verbose "Removing unnecessary parameters from template '$($templateFile.jsonFilePath)'"
        $templateJson = Get-Content -LiteralPath $templateFile.jsonFilePath | ConvertFrom-Json
        $templateParameterNames = $templateJson.parameters.PSObject.Properties.Name

        $templateFileParameters = $templateParameters.Clone()
        foreach ($key in $templateParameters.Keys) {
            if ($templateParameterNames -notcontains $key) {
                Write-Verbose "Removing unnecessary parameter '$key'"
                $templateFileParameters.Remove($key)
            }
        }

        $preDeploymentScript = $templateFile.originalFilePath | Split-Path | Join-Path -ChildPath 'test-resources-pre.ps1'
        if (Test-Path $preDeploymentScript) {
            Log "Invoking pre-deployment script '$preDeploymentScript'"
            &$preDeploymentScript -ResourceGroupName $ResourceGroupName @PSBoundParameters
        }

        $msg = if ($templateFile.jsonFilePath -ne $templateFile.originalFilePath) {
            "Deployment template $($templateFile.jsonFilePath) from $($templateFile.originalFilePath) to resource group $($resourceGroup.ResourceGroupName)"
        } else {
            "Deployment template $($templateFile.jsonFilePath) to resource group $($resourceGroup.ResourceGroupName)"
        }
        Log $msg

        $deployment = Retry {
            $lastDebugPreference = $DebugPreference
            try {
                if ($CI) {
                    $DebugPreference = 'Continue'
                }
                New-AzResourceGroupDeployment -Name $BaseName -ResourceGroupName $resourceGroup.ResourceGroupName -TemplateFile $templateFile.jsonFilePath -TemplateParameterObject $templateFileParameters -Force:$Force
            } catch {
                Write-Output @'
#####################################################
# For help debugging live test provisioning issues, #
# see http://aka.ms/azsdk/engsys/live-test-help,    #
#####################################################
'@
                throw
            } finally {
                $DebugPreference = $lastDebugPreference
            }
        }

        if ($deployment.ProvisioningState -eq 'Succeeded') {
            # New-AzResourceGroupDeployment would've written an error and stopped the pipeline by default anyway.
            Write-Verbose "Successfully deployed template '$($templateFile.jsonFilePath)' to resource group '$($resourceGroup.ResourceGroupName)'"
        }

        $deploymentOutputs = SetDeploymentOutputs $serviceName $context $deployment $templateFile

        $postDeploymentScript = $templateFile.originalFilePath | Split-Path | Join-Path -ChildPath 'test-resources-post.ps1'
        if (Test-Path $postDeploymentScript) {
            Log "Invoking post-deployment script '$postDeploymentScript'"
            &$postDeploymentScript -ResourceGroupName $ResourceGroupName -DeploymentOutputs $deploymentOutputs @PSBoundParameters
        }

        if ($templateFile.jsonFilePath.EndsWith('.compiled.json')) {
            Write-Verbose "Removing compiled bicep file $($templateFile.jsonFilePath)"
            Remove-Item $templateFile.jsonFilePath
        }
    }

} finally {
    $exitActions.Invoke()
}

# Suppress output locally
if ($CI) {
    return $EnvironmentVariables
}

<#
.SYNOPSIS
Deploys live test resources defined for a service directory to Azure.

.DESCRIPTION
Deploys live test resouces specified in test-resources.json or test-resources.bicep
files to a new resource group.

This script searches the directory specified in $ServiceDirectory recursively
for files named test-resources.json or test-resources.bicep. All found test-resources.json
and test-resources.bicep files will be deployed to the test resource group.

If no test-resources.json or test-resources.bicep files are located the script
exits without making changes to the Azure environment.

A service principal may optionally be passed to $TestApplicationId and $TestApplicationSecret.
Test resources will grant this service principal access to the created resources.
If no service principal is specified, a new one will be created and assigned the
'Owner' role for the resource group associated with the test resources.

This script runs in the context of credentials already specified in Connect-AzAccount
or those specified in $ProvisionerApplicationId and $ProvisionerApplicationSecret.

.PARAMETER BaseName
A name to use in the resource group and passed to the ARM template as 'baseName'.
Limit $BaseName to enough characters to be under limit plus prefixes specified in
the ARM template. See also https://docs.microsoft.com/azure/architecture/best-practices/resource-naming

Note: The value specified for this parameter will be overriden and generated
by New-TestResources.ps1 if $CI is specified.

.PARAMETER ResourceGroupName
Set this value to deploy directly to a Resource Group that has already been
created or to create a new resource group with this name.

If not specified, the $BaseName will be used to generate name for the resource
group that will be created.

.PARAMETER ServiceDirectory
A directory under 'sdk' in the repository root - optionally with subdirectories
specified - in which to discover ARM templates named 'test-resources.json' and
Bicep templates named 'test-resources.bicep'. This can also be an absolute path
or specify parent directories.

.PARAMETER TestApplicationId
Optional Azure Active Directory Application ID to authenticate the test runner
against deployed resources. Passed to the ARM template as 'testApplicationId'.

If not specified, a new AAD Application will be created and assigned the 'Owner'
role for the resource group associated with the test resources. No permissions
will be granted to the subscription or other resources.

For those specifying a Provisioner Application principal as 'ProvisionerApplicationId',
it will need the permission 'Application.ReadWrite.OwnedBy' for the Microsoft Graph API
in order to create the Test Application principal.

This application is used by the test runner to execute tests against the
live test resources.

.PARAMETER TestApplicationSecret
Optional service principal secret (password) to authenticate the test runner
against deployed resources. Passed to the ARM template as
'testApplicationSecret'.

This application is used by the test runner to execute tests against the
live test resources.

.PARAMETER TestApplicationOid
Service Principal Object ID of the AAD Test Application. This is used to assign
permissions to the AAD application so it can access tested features on the live
test resources (e.g. Role Assignments on resources). It is passed as to the ARM
template as 'testApplicationOid'

If not specified, an attempt will be made to query it from the Azure Active Directory
tenant. For those specifying a service principal as 'ProvisionerApplicationId',
it will need the permission 'Application.Read.All' for the Microsoft Graph API
in order to query AAD.

For more information on the relationship between AAD Applications and Service
Principals see: https://docs.microsoft.com/azure/active-directory/develop/app-objects-and-service-principals

.PARAMETER TenantId
The tenant ID of a service principal when a provisioner is specified. The same
Tenant ID is used for Test Application and Provisioner Application.

This value is passed to the ARM template as 'tenantId'.

.PARAMETER SubscriptionId
Optional subscription ID to use for new resources when logging in as a
provisioner. You can also use Set-AzContext if not provisioning.

If you do not specify a SubscriptionId and are not logged in, one will be
automatically selected for you by the Connect-AzAccount cmdlet.

Once you are logged in (or were previously), the selected SubscriptionId
will be used for subsequent operations that are specific to a subscription.

.PARAMETER ProvisionerApplicationId
Optional Application ID of the Azure Active Directory service principal to use for
provisioning the test resources. If not, specified New-TestResources.ps1 uses the
context of the caller to provision.

If specified, the Provisioner Application principal would benefit from the following
permissions to the Microsoft Graph API:

  - 'Application.Read.All' in order to query AAD to obtain the 'TestApplicaitonOid'

  - 'Application.ReadWrite.OwnedBy' in order to create the Test Application principal
     or grant an existing principal ownership of the resource group associated with
     the test resources.

If the provisioner does not have these permissions, it can still be used with
New-TestResources.ps1 by specifying an existing Test Application principal, including
its Object ID, and managing permissions to the resource group manually.

This value is not passed to the ARM template.

.PARAMETER ProvisionerApplicationSecret
A service principal secret (password) used to provision test resources when a
provisioner is specified.

This value is not passed to the ARM template.

.PARAMETER DeleteAfterHours
Positive integer number of hours from the current time to set the
'DeleteAfter' tag on the created resource group. The computed value is a
timestamp of the form "2020-03-04T09:07:04.3083910Z".

An optional cleanup process can delete resource groups whose "DeleteAfter"
timestamp is less than the current time.

This is used for CI automation.

.PARAMETER Location
Optional location where resources should be created. If left empty, the default
is based on the cloud to which the template is being deployed:

* AzureCloud -> 'westus2'
* AzureUSGovernment -> 'usgovvirginia'
* AzureChinaCloud -> 'chinaeast2'
* Dogfood -> 'westus'

.PARAMETER Environment
Optional name of the cloud environment. The default is the Azure Public Cloud
('AzureCloud')

.PARAMETER AdditionalParameters
Optional key-value pairs of parameters to pass to the ARM template(s) and pre-post scripts.

.PARAMETER ArmTemplateParameters
Optional key-value pairs of parameters to pass to the ARM template(s).

.PARAMETER EnvironmentVariables
Optional key-value pairs of parameters to set as environment variables to the shell.

.PARAMETER CI
Indicates the script is run as part of a Continuous Integration / Continuous
Deployment (CI/CD) build (only Azure Pipelines is currently supported).

.PARAMETER Force
Force creation of resources instead of being prompted.

.PARAMETER OutFile
Save test environment settings into a .env file next to test resources template.
The contents of the file are protected via the .NET Data Protection API (DPAPI).
This is supported only on Windows. The environment file is scoped to the current
service directory.

The environment file will be named for the test resources template that it was
generated for. For ARM templates, it will be test-resources.json.env. For
Bicep templates, test-resources.bicep.env.

.PARAMETER SuppressVsoCommands
By default, the -CI parameter will print out secrets to logs with Azure Pipelines log
commands that cause them to be redacted. For CI environments that don't support this (like
stress test clusters), this flag can be set to $false to avoid printing out these secrets to the logs.

.EXAMPLE
Connect-AzAccount -Subscription 'REPLACE_WITH_SUBSCRIPTION_ID'
New-TestResources.ps1 keyvault

Run this in a desktop environment to create a new AAD application and Service Principal
for running live tests against the test resources created. The principal will have ownership
rights to the resource group and the resources that it contains, but no other resources in
the subscription.

Requires PowerShell 7 to use ConvertFrom-SecureString -AsPlainText or convert
the SecureString to plaintext by another means.

.EXAMPLE
Connect-AzAccount -Subscription 'REPLACE_WITH_SUBSCRIPTION_ID'
New-TestResources.ps1 `
    -BaseName 'azsdk' `
    -ServiceDirectory 'keyvault' `
    -SubscriptionId 'REPLACE_WITH_SUBSCRIPTION_ID' `
    -ResourceGroupName 'REPLACE_WITH_NAME_FOR_RESOURCE_GROUP' `
    -Location 'eastus'

Run this in a desktop environment to specify the name and location of the resource
group that test resources are being deployed to. This will also create a new AAD
application and Service Principal for running live tests against the rest resources
created. The principal will have ownership rights to the resource group and the
resources that it contains, but no other resources in the subscription.

Requires PowerShell 7 to use ConvertFrom-SecureString -AsPlainText or convert
the SecureString to plaintext by another means.

.EXAMPLE
Connect-AzAccount -Subscription 'REPLACE_WITH_SUBSCRIPTION_ID'
New-TestResources.ps1 `
    -BaseName 'azsdk' `
    -ServiceDirectory 'keyvault' `
    -SubscriptionId 'REPLACE_WITH_SUBSCRIPTION_ID' `
    -ResourceGroupName 'REPLACE_WITH_NAME_FOR_RESOURCE_GROUP' `
    -Location 'eastus' `
    -TestApplicationId 'REPLACE_WITH_TEST_APPLICATION_ID' `
    -TestApplicationSecret 'REPLACE_WITH_TEST_APPLICATION_SECRET'

Run this in a desktop environment to specify the name and location of the resource
group that test resources are being deployed to. This will grant ownership rights
to the 'TestApplicationId' for the resource group and the resources that it contains,
without altering its existing permissions.

.EXAMPLE
New-TestResources.ps1 `
    -BaseName 'azsdk' `
    -ServiceDirectory 'keyvault' `
    -SubscriptionId 'REPLACE_WITH_SUBSCRIPTION_ID' `
    -ResourceGroupName 'REPLACE_WITH_NAME_FOR_RESOURCE_GROUP' `
    -Location 'eastus' `
    -ProvisionerApplicationId 'REPLACE_WITH_PROVISIONER_APPLICATION_ID' `
    -ProvisionerApplicationSecret 'REPLACE_WITH_PROVISIONER_APPLICATION_ID' `
    -TestApplicationId 'REPLACE_WITH_TEST_APPLICATION_ID' `
    -TestApplicationOid 'REPLACE_WITH_TEST_APPLICATION_OBJECT_ID' `
    -TestApplicationSecret 'REPLACE_WITH_TEST_APPLICATION_SECRET'

Run this in a desktop environment to specify the name and location of the resource
group that test resources are being deployed to. The script will be executed in the
context of the 'ProvisionerApplicationId' rather than the caller.

Depending on the permissions of the Provisioner Application principal, the script may
grant ownership rights 'TestApplicationId' for the resource group and the resources
that it contains, or may emit a message indicating that it was unable to perform the grant.

For the Provisioner Application principal to perform the grant, it will need the
permission 'Application.ReadWrite.OwnedBy' for the Microsoft Graph API.

Requires PowerShell 7 to use ConvertFrom-SecureString -AsPlainText or convert
the SecureString to plaintext by another means.

.EXAMPLE
New-TestResources.ps1 `
    -BaseName 'Generated' `
    -ServiceDirectory '$(ServiceDirectory)' `
    -TenantId '$(TenantId)' `
    -ProvisionerApplicationId '$(ProvisionerId)' `
    -ProvisionerApplicationSecret '$(ProvisionerSecret)' `
    -TestApplicationId '$(TestAppId)' `
    -TestApplicationSecret '$(TestAppSecret)' `
    -DeleteAfterHours 24 `
    -CI `
    -Force `
    -Verbose

Run this in an Azure DevOps CI (with approrpiate variables configured) before
executing live tests. The script will output variables as secrets (to enable
log redaction).

#>
