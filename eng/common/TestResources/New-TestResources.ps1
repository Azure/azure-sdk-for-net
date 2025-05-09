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
    [string] $TestResourcesDirectory,

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

    [Parameter(ParameterSetName = 'Provisioner')]
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
    [ValidateSet('test', 'perf', 'stress-test')]
    [string] $ResourceType = 'test',

    [Parameter()]
    [hashtable] $ArmTemplateParameters,

    [Parameter()]
    [hashtable] $AdditionalParameters,

    [Parameter()]
    [ValidateNotNull()]
    [hashtable] $EnvironmentVariables = @{},

    # List of CIDR ranges to add to specific resource firewalls, e.g. @(10.100.0.0/16, 10.200.0.0/16)
    [Parameter()]
    [ValidateCount(0,399)]
    [Validatescript({
        foreach ($range in $PSItem) {
            if ($range -like '*/31' -or $range -like '*/32') {
                throw "Firewall IP Ranges cannot contain a /31 or /32 CIDR"
            }
        }
        return $true
    })]
    [array] $AllowIpRanges = @(),

    # Instead of running the post script, create a wrapped file to run it with parameters
    # so that CI can run it in a subsequent step with a refreshed azure login
    [Parameter()]
    [string] $SelfContainedPostScript,

    [Parameter()]
    [switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID),

    [Parameter()]
    [switch] $Force,

    [Parameter()]
    [switch] $OutFile,

    [Parameter()]
    [switch] $SuppressVsoCommands = ($null -eq $env:SYSTEM_TEAMPROJECTID),

    # Default behavior is to use logged in credentials
    [Parameter()]
    [switch] $ServicePrincipalAuth,

    # Captures any arguments not declared here (no parameter errors)
    # This enables backwards compatibility with old script versions in
    # hotfix branches if and when the dynamic subscription configuration
    # secrets get updated to add new parameters.
    [Parameter(ValueFromRemainingArguments = $true)]
    $NewTestResourcesRemainingArguments
)

. (Join-Path $PSScriptRoot .. scripts common.ps1)
. (Join-Path $PSScriptRoot .. scripts Helpers Resource-Helpers.ps1)
. $PSScriptRoot/TestResources-Helpers.ps1
. $PSScriptRoot/SubConfig-Helpers.ps1

$wellKnownTMETenants = @('70a036f6-8e4d-4615-bad6-149c02e7720d')

if (!$ServicePrincipalAuth) {
    # Clear secrets if not using Service Principal auth. This prevents secrets
    # from being passed to pre- and post-scripts.
    $PSBoundParameters['TestApplicationSecret'] = $TestApplicationSecret = ''
    $PSBoundParameters['ProvisionerApplicationSecret'] = $ProvisionerApplicationSecret = ''
}

# By default stop for any error.
if (!$PSBoundParameters.ContainsKey('ErrorAction')) {
    $ErrorActionPreference = 'Stop'
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
    if ($TestResourcesDirectory) {
        $root = $TestResourcesDirectory | Resolve-Path
        # Add an explicit check below in case ErrorActionPreference is overridden and Resolve-Path doesn't stop execution
        if (!$root) {
            throw "TestResourcesDirectory '$TestResourcesDirectory' does not exist."
        }
        Write-Verbose "Overriding test resources search directory to '$root'"
    }
    $templateFiles = @()

    "$ResourceType-resources.json", "$ResourceType-resources.bicep" | ForEach-Object {
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

    $serviceName = GetServiceLeafDirectoryName $ServiceDirectory
    $BaseName, $ResourceGroupName = GetBaseAndResourceGroupNames `
        -baseNameDefault $BaseName `
        -resourceGroupNameDefault $ResourceGroupName `
        -user (GetUserName) `
        -serviceDirectoryName $serviceName `
        -CI $CI

    # Make sure pre- and post-scripts are passed formerly required arguments.
    $PSBoundParameters['BaseName'] = $BaseName

    # Try detecting repos that support OutFile and defaulting to it
    if (!$CI -and !$PSBoundParameters.ContainsKey('OutFile')) {
        # TODO: find a better way to detect the language
        if ($IsWindows -and $Language -eq 'dotnet') {
            $OutFile = $true
            Log "Detected .NET repository. Defaulting OutFile to true. Test environment settings will be stored into a file so you don't need to set environment variables manually."
        } elseif ($SupportsTestResourcesDotenv) {
            $OutFile = $true
            Log "Repository supports reading .env files. Defaulting OutFile to true. Test environment settings may be stored in a .env file so they are read by tests automatically."
        }
    }

    # If no location is specified use safe default locations for the given
    # environment. If no matching environment is found $Location remains an empty
    # string.
    if (!$Location) {
        $Location = @{
            'AzureCloud' = 'westus';
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
            if ($context.Tenant.Name -like '*TME*') {
                if ($currentSubscriptionId -ne '4d042dc6-fe17-4698-a23f-ec6a8d1e98f4') {
                    Log "Attempting to select subscription 'Azure SDK Test Resources - TME (4d042dc6-fe17-4698-a23f-ec6a8d1e98f4)'"
                    $null = Select-AzSubscription -Subscription '4d042dc6-fe17-4698-a23f-ec6a8d1e98f4' -ErrorAction Ignore
                    # Update the context.
                    $context = Get-AzContext
                }
            } elseif ($currentSubcriptionId -ne 'faa080af-c1d8-40ad-9cce-e1a450ca5b57') {
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
            '4d042dc6-fe17-4698-a23f-ec6a8d1e98f4' = 'Azure SDK Test Resources - TME '
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

    # This needs to happen after we set the TenantId but before we use the ResourceGroupName
    if ($wellKnownTMETenants.Contains($TenantId)) {
        # Add a prefix to the resource group name to avoid flagging the usages of local auth
        # See details at https://eng.ms/docs/products/onecert-certificates-key-vault-and-dsms/key-vault-dsms/certandsecretmngmt/credfreefaqs#how-can-i-disable-s360-reporting-when-testing-customer-facing-3p-features-that-depend-on-use-of-unsafe-local-auth
        $ResourceGroupName = "SSS3PT_" + $ResourceGroupName
    }

    if ($ResourceGroupName.Length -gt 90) {
        # See limits at https://docs.microsoft.com/azure/architecture/best-practices/resource-naming
        Write-Warning -Message "Resource group name '$ResourceGroupName' is too long. So pruning it to be the first 90 characters."
        $ResourceGroupName = $ResourceGroupName.Substring(0, 90)
    }

    # If a provisioner service principal was provided log into it to perform the pre- and post-scripts and deployments.
    if ($ProvisionerApplicationId -and $ServicePrincipalAuth) {
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
            # Support corp tenant and TME tenant user id lookups
            $user = Get-AzADUser -Mail $context.Account.Id
            if ($null -eq $user -or !$user.Id) {
                $user = Get-AzADUser -UserPrincipalName $context.Account.Id
            }
            if ($null -eq $user -or !$user.Id) {
                throw "Failed to find entra object ID for the current user"
            }
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

    $tags = @{
        Owners = (GetUserName)
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

        # Set an environment variable marking that resources have been deployed
        # This variable can be consumed as a yaml condition in later stages of the pipeline
        # to determine whether resources should be removed.
        Write-Host "Setting variable 'CI_HAS_DEPLOYED_RESOURCES': 'true'"
        LogVsoCommand "##vso[task.setvariable variable=CI_HAS_DEPLOYED_RESOURCES;]true"
        # Set resource group env variable early in cases where deployment fails as we
        # still want to clean up the group. The Remove-TestResources.ps1 script consumes this var.
        $envVarName = (BuildServiceDirectoryPrefix $serviceName) + "RESOURCE_GROUP"
        LogVsoCommand "##vso[task.setvariable variable=$envVarName;]$ResourceGroupName"
    }

    Log "Creating resource group '$ResourceGroupName' in location '$Location'"
    $resourceGroup = Retry {
        New-AzResourceGroup -Name "$ResourceGroupName" -Location $Location -Tag $tags -Force:$Force
    }

    if ($resourceGroup.ProvisioningState -eq 'Succeeded') {
        # New-AzResourceGroup would've written an error and stopped the pipeline by default anyway.
        Write-Verbose "Successfully created resource group '$($resourceGroup.ResourceGroupName)'"
    } elseif (!$resourceGroup) {
        if (!$PSCmdlet.ShouldProcess($resourceGroupName)) {
            # If the -WhatIf flag was passed, there will be no resource group created. Fake it.
            $resourceGroup = [PSCustomObject]@{
                ResourceGroupName = $resourceGroupName
                Location = $Location
            }
        } else {
            Write-Error "Resource group '$ResourceGroupName' already exists." `
                            -Category ResourceExists `
                            -RecommendedAction "Delete resource group '$ResourceGroupName', or overwrite it when redeploying."
        }
    }

    if (!$CI -and !$ServicePrincipalAuth) {
        if ($TestApplicationId) {
            Write-Warning "The specified TestApplicationId '$TestApplicationId' will be ignored when -ServicePrincipalAutth is not set."
        }

        # Support corp tenant and TME tenant user id lookups
        $userAccount = (Get-AzADUser -Mail (Get-AzContext).Account.Id)
        if ($null -eq $userAccount -or !$userAccount.Id) {
            $userAccount = (Get-AzADUser -UserPrincipalName (Get-AzContext).Account)
        }
        if ($null -eq $userAccount -or !$userAccount.Id) {
            throw "Failed to find entra object ID for the current user"
        }
        $TestApplicationOid = $userAccount.Id
        $TestApplicationId = $testApplicationOid
        $userAccountName = $userAccount.UserPrincipalName
        Log "User authentication with user '$userAccountName' ('$TestApplicationId') will be used."
    }
    # If user has specified -ServicePrincipalAuth
    elseif (!$CI -and $ServicePrincipalAuth) {
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
                $displayName = "$ResourceType-resources-$($baseName)$suffix.microsoft.com"
            } else {
                $displayName = "$($baseName)$suffix.$ResourceType-resources.azure.sdk"
            }

            $servicePrincipalWrapper = NewServicePrincipalWrapper `
                                        -subscription $SubscriptionId `
                                        -resourceGroup $ResourceGroupName `
                                        -displayName $DisplayName

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
            Write-Warning ("The Object ID of the test application was unable to be queried. " +
                          "You may want to consider passing it explicitly with the 'TestApplicationOid` parameter.")
            throw $_.Exception
        }

        if ($testServicePrincipal -and $testServicePrincipal.Id) {
            $script:TestApplicationOid = $testServicePrincipal.Id
        }
    }

    # Make sure pre- and post-scripts are passed formerly required arguments.
    $PSBoundParameters['TestApplicationId'] = $TestApplicationId
    $PSBoundParameters['TestApplicationOid'] = $TestApplicationOid
    if ($ServicePrincipalAuth) {
        $PSBoundParameters['TestApplicationSecret'] = $TestApplicationSecret
    }

    # If the role hasn't been explicitly assigned to the resource group and a cached service principal or user authentication is in use,
    # query to see if the grant is needed.
    if (!$resourceGroupRoleAssigned -and $TestApplicationOid) {
        $roleAssignment = Get-AzRoleAssignment `
                            -ObjectId $TestApplicationOid `
                            -RoleDefinitionName 'Owner' `
                            -ResourceGroupName "$ResourceGroupName" `
                            -ErrorAction SilentlyContinue
        $resourceGroupRoleAssigned = ($roleAssignment.RoleDefinitionName -eq 'Owner')
    }

   # If needed, grant the test service principal ownership over the resource group. This may fail if the provisioner
   # is a service principal without permissions to grant RBAC roles to other service principals. That should not be
   # considered a critical failure, as the test application may have subscription-level permissions and not require
   # the explicit grant.
   if (!$resourceGroupRoleAssigned) {
        $idSlug = if (!$ServicePrincipalAuth) { "User '$userAccountName' ('$TestApplicationId')" } else { "Test Application '$TestApplicationId'"};
        Log "Attempting to assign the 'Owner' role for '$ResourceGroupName' to the $idSlug"
        $ownerAssignment = New-AzRoleAssignment `
                            -RoleDefinitionName "Owner" `
                            -ObjectId "$TestApplicationOId" `
                            -ResourceGroupName "$ResourceGroupName" `
                            -ErrorAction SilentlyContinue

        if ($ownerAssignment.RoleDefinitionName -eq 'Owner') {
            Write-Verbose "Successfully assigned ownership of '$ResourceGroupName' to the $idSlug"
        } else {
            Write-Warning ("The 'Owner' role for '$ResourceGroupName' could not be assigned. " +
                          "You may need to manually grant 'Owner' for the resource group to the " +
                          "$idSlug if it does not have subscription-level permissions.")
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
    if ($TestApplicationSecret -and $ServicePrincipalAuth) {
        $templateParameters.Add('testApplicationSecret', $TestApplicationSecret)
    }
    # Only add subnets when running in an azure pipeline context
    if ($CI -and $Environment -eq 'AzureCloud' -and $env:PoolSubnet) {
        $templateParameters.Add('azsdkPipelineSubnetList', @($env:PoolSubnet))
    }
    # The TME tenants are our place for local auth testing so we do not support safe secret standard there.
    # Some arm/bicep templates may want to change deployment settings like local auth in sandboxed TME tenants.
    # The pipeline account context does not have the .Tenant.Name property, so check against subscription via
    # naming convention instead.
    $templateParameters.Add('supportsSafeSecretStandard', (!$wellKnownTMETenants.Contains($TenantId)))
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
        'cmd', 'set {0}=''{1}'''
    } elseif (@('bash', 'csh', 'tcsh', 'zsh') -contains $parentProcessName) {
        'shell', 'export {0}=''{1}'''
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

        $preDeploymentScript = $templateFile.originalFilePath | Split-Path | Join-Path -ChildPath "$ResourceType-resources-pre.ps1"
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
            New-AzResourceGroupDeployment `
                    -Name $BaseName `
                    -ResourceGroupName $resourceGroup.ResourceGroupName `
                    -TemplateFile $templateFile.jsonFilePath `
                    -TemplateParameterObject $templateFileParameters `
                    -Force:$Force
        }
        if ($deployment.ProvisioningState -ne 'Succeeded') {
            Write-Host "Deployment '$($deployment.DeploymentName)' has state '$($deployment.ProvisioningState)' with CorrelationId '$($deployment.CorrelationId)'. Exiting..."
            Write-Host @'
#####################################################
# For help debugging live test provisioning issues, #
# see http://aka.ms/azsdk/engsys/live-test-help     #
#####################################################
'@
            exit 1
        }

        Write-Host "Deployment '$($deployment.DeploymentName)' has CorrelationId '$($deployment.CorrelationId)'"
        Write-Host "Successfully deployed template '$($templateFile.jsonFilePath)' to resource group '$($resourceGroup.ResourceGroupName)'"

        $deploymentEnvironmentVariables, $deploymentOutputs = SetDeploymentOutputs `
                                                                -serviceName $serviceName `
                                                                -azContext $context `
                                                                -deployment $deployment `
                                                                -templateFile $templateFile `
                                                                -environmentVariables $EnvironmentVariables

        SetResourceNetworkAccessRules -ResourceGroupName $ResourceGroupName -AllowIpRanges $AllowIpRanges -CI:$CI

        $postDeploymentScript = $templateFile.originalFilePath | Split-Path | Join-Path -ChildPath "$ResourceType-resources-post.ps1"

        if ($SelfContainedPostScript -and !(Test-Path $postDeploymentScript)) {
            throw "-SelfContainedPostScript is not supported if there is no 'test-resources-post.ps1' script in the deployment template directory"
        }

        if (Test-Path $postDeploymentScript) {
            if ($SelfContainedPostScript) {
                Log "Creating invokable post-deployment script '$SelfContainedPostScript' from '$postDeploymentScript'"

                $deserialized = @{}
                foreach ($parameter in $PSBoundParameters.GetEnumerator()) {
                    if ($parameter.Value -is [System.Management.Automation.SwitchParameter]) {
                        $deserialized[$parameter.Key] = $parameter.Value.ToBool()
                    } else {
                        $deserialized[$parameter.Key] = $parameter.Value
                    }
                }
                $deserialized['ResourceGroupName'] = $ResourceGroupName
                $deserialized['DeploymentOutputs'] = $deploymentOutputs
                $serialized = $deserialized | ConvertTo-Json

                $outScript = @"
`$parameters = `@'
$serialized
'`@ | ConvertFrom-Json -AsHashtable
# Set global variables that aren't always passed as parameters
`$ResourceGroupName = `$parameters.ResourceGroupName
`$AdditionalParameters = `$parameters.AdditionalParameters
`$DeploymentOutputs = `$parameters.DeploymentOutputs
$postDeploymentScript `@parameters
"@
                $outScript | Out-File $SelfContainedPostScript
            } else {
                Log "Invoking post-deployment script '$postDeploymentScript'"
                &$postDeploymentScript -ResourceGroupName $ResourceGroupName -DeploymentOutputs $deploymentOutputs @PSBoundParameters
            }
        }

        if ($templateFile.jsonFilePath.EndsWith('.compiled.json')) {
            Write-Verbose "Removing compiled bicep file $($templateFile.jsonFilePath)"
            Remove-Item $templateFile.jsonFilePath
        }

        Write-Host "Deleting ARM deployment as it may contain secrets. Deployed resources will not be affected."
        $null = $deployment | Remove-AzResourceGroupDeployment
    }
} finally {
    $exitActions.Invoke()
}

# Suppress output locally
if ($CI) {
    return $deploymentEnvironmentVariables
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
Bicep templates named 'test-resources.bicep'. This can be an absolute path
or specify parent directories. ServiceDirectory is also used for resource and
environment variable naming.

.PARAMETER TestResourcesDirectory
An override directory in which to discover ARM templates named 'test-resources.json' and
Bicep templates named 'test-resources.bicep'. This can be an absolute path
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

* AzureCloud -> 'westus'
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

.PARAMETER AllowIpRanges
Optional array of CIDR ranges to add to the network firewall for resource types like storage.
When running locally, if this parameter is not set then the client's IP will be queried and added to the firewall instead.

.PARAMETER CI
Indicates the script is run as part of a Continuous Integration / Continuous
Deployment (CI/CD) build (only Azure Pipelines is currently supported).

.PARAMETER Force
Force creation of resources instead of being prompted.

.PARAMETER OutFile
Save test environment settings into a .env file next to test resources template.

On Windows in the Azure/azure-sdk-for-net repository,
the contents of the file are protected via the .NET Data Protection API (DPAPI).
The environment file is scoped to the current service directory.
The environment file will be named for the test resources template that it was
generated for. For ARM templates, it will be test-resources.json.env. For
Bicep templates, test-resources.bicep.env.

If `$SupportsTestResourcesDotenv=$true` in language repos' `LanguageSettings.ps1`,
and if `.env` files are gitignore'd, and if a service directory's `test-resources.bicep`
file does not expose secrets based on `bicep lint`, a `.env` file is written next to
`test-resources.bicep` that can be loaded by a test harness to be used for recording tests.

.PARAMETER SuppressVsoCommands
By default, the -CI parameter will print out secrets to logs with Azure Pipelines log
commands that cause them to be redacted. For CI environments that don't support this (like
stress test clusters), this flag can be set to $false to avoid printing out these secrets to the logs.

.PARAMETER ServicePrincipalAuth
Use the provisioner SP credentials to deploy, and pass the test SP credentials
to tests. If provisioner and test SP are not set, provision an SP with user
credentials and pass the new SP to tests.

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
