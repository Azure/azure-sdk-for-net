# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
  .SYNOPSIS
    This script handles creation of the principal and the resources needed to run identity samples.

  .DESCRIPTION
    It tries to retrieve a resource group, an Azure Event Hubs Namespace and an Azure Event Hub
    using the names passed in as arguments. It attempts the creation of the resources if not found.

    It always tries to create the named service principal.
    
    It assigns the 'Azure Event Hubs Data Owner' role to the namespace.

    Upon completion, the script will output the principal's sensitive information and the parameters
    needed to run the samples.
 
    For more detailed help, please use the -Help switch. 
#>

# =======================
# == Script Parameters ==
# =======================

[CmdletBinding(DefaultParameterSetName="Help")] 
[OutputType([String])] 
param
( 
  [Parameter(Mandatory=$true, ParameterSetName="Help", Position=0)]
  [Switch] $Help,

  [Parameter(Mandatory=$true, ParameterSetName="Execute", Position=0)]
  [ValidateNotNullOrEmpty()]
  [string] $SubscriptionName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [string] $ResourceGroupName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [string] $NamespaceName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [string] $EventHubName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [ValidateNotNullOrEmpty()]
  [ValidateScript({ $_.Length -ge 6})]
  [string] $ServicePrincipalName,

  [Parameter(Mandatory=$true, ParameterSetName="Execute")]
  [AllowNull()]  
  [string] $AzureRegion = $null
)

# =====================
# == Module Imports  ==
# =====================

Import-Module Az.Resources

# ==========================
# == Function Imports ==
# ==========================

. .\functions\azure-resource-functions.ps1

function DisplayHelp
{
  <#
    .SYNOPSIS
      Displays the usage help text.

    .DESCRIPTION
      Displays the help text for usage.

    .OUTPUTS
      Help text for usage to the console window.
  #>

  $indent = "    "

  Write-Host "`n"
  Write-Host "Creation of the Resources to Run Identity Samples"
  Write-Host ""
  Write-Host "$($indent)This script handles creation of the principal and the resources needed to run identity samples."
  Write-Host ""
  Write-Host "$($indent)It tries to retrieve a resource group, an Azure Event Hubs Namespace and an Azure Event Hub"
  Write-Host "$($indent)using the names passed in as arguments. It attempts the creation of the resources if not found."
  Write-Host ""
  Write-Host "$($indent)It always tries to create the named service principal."
  Write-Host ""
  Write-Host "$($indent)It assigns the 'Azure Event Hubs Data Owner' role to the created namespace."
  Write-Host ""
  Write-Host "$($indent)Upon completion, the script will output the principal's sensitive information and the parameters"
  Write-Host "$($indent)needed to invoke the samples."
  Write-Host ""
  Write-Host "$($indent)NOTE: Some of these values, such as the client secret, are difficult to recover; please copy them and keep in a"
  Write-Host "$($indent)safe place."
  Write-Host ""
  Write-Host ""
  Write-Host "$($indent)Available Parameters:"
  Write-Host ""
  Write-Host "$($indent)-Help`t`t`tDisplays this message."
  Write-Host ""

  Write-Host "$($indent)-SubscriptionName`t`tRequired.  The name of the Azure subscription used."
  Write-Host ""

  Write-Host "$($indent)-ResourceGroupName`t`tRequired.  The name of the Azure Resource Group that contains the resources."
  Write-Host ""

  Write-Host "$($indent)-NamespaceName`t`tRequired.  The name of the Azure Event Hubs Namespace."
  Write-Host ""

  Write-Host "$($indent)-EventHubName`t`tRequired.  The name of the Azure Event Hub."
  Write-Host ""

  Write-Host "$($indent)-ServicePrincipalName`tRequired.  The name to use for the service principal that will be created."
  Write-Host ""

  Write-Host "$($indent)-AzureRegion`t`tThe Azure region that resources should be created in.  This value should be"
  Write-Host "$($indent)`t`t`t`tthe name of the region, in lowercase, with no spaces.  For example: southcentralus"
  Write-Host ""
  Write-Host "$($indent)`t`t`t`tDefault: South Central US (southcentralus)"
  Write-Host ""  
}

# ====================
# == Script Actions ==
# ====================

if ($Help)
{
  DisplayHelp $Defaults
  exit 0
}

if ([string]::IsNullOrEmpty($azureRegion)) 
{
  $azureRegion = "southcentralus"
}

ValidateParameters -ServicePrincipalName "$($servicePrincipalName)" -AzureRegion "$($azureRegion)"
$subscription = GetSubscriptionAndSetAzureContext -SubscriptionName "$($subscriptionName)"
$wasResourceGroupCreated = CreateResourceGroupIfMissing -ResourceGroupName "$($resourceGroupName)" -AzureRegion "$($azureRegion)"

# At this point, we may have created a resource, so be safe and allow for removing any
# resources created should the script fail.

try
{
    Start-Sleep 1

    $wasNamespaceCreated = CreateNamespaceIfMissing -ResourceGroupName "$($resourceGroupName)" `
                                                    -NamespaceName "$($namespaceName)" `
                                                    -AzureRegion "$($azureRegion)"

    $namespaceInformation = GetNamespaceInformation -ResourceGroupName "$($resourceGroupName)" -NamespaceName "$($namespaceName)"

    $wasEventHubCreated = CreateEventHubIfMissing -ResourceGroupName "$($resourceGroupName)" `
                                                  -NamespaceName "$($namespaceName)" `
                                                  -EventHubName "$($eventHubName)"

    # Create the service principal and grant 'Azure Event Hubs Data Owner' access in the event hubs.
    
    $credentials = GenerateRandomCredentials           
    $principal = CreateServicePrincipalAndWait -ServicePrincipalName "$($servicePrincipalName)" -Credentials $credentials

    AssignRoleToNamespace -ApplicationId "$($principal.ApplicationId)" `
                          -RoleDefinitionName "Azure Event Hubs Data Owner" `
                          -ResourceGroupName "$($resourceGroupName)" `
                          -NamespaceName "$($namespaceName)"

    Write-Host "Done."
    Write-Host ""
    Write-Host ""
    Write-Host "After building the sample project, you can run it using the Azure resources that you just created with the following command."
    Write-Host "You can also launch the Samples project from within Visual Studio and enter the Azure information when prompted or set them in the project properties."
    Write-Host ""
    Write-Host "dotnet Azure.Messaging.EventHubs.Samples.dll ``"
    Write-Host "--ConnectionString ""$($namespaceInformation.PrimaryConnectionString)"" ``"
    Write-Host "--FullyQualifiedNamespace ""$($namespaceInformation.FullyQualifiedDomainName)"" ``"
    Write-Host "--EventHub ""$($EventHubName)"" ``"
    Write-Host "--Tenant ""$($subscription.TenantId)"" ``"
    Write-Host "--Client ""$($principal.ApplicationId)"" ``"
    Write-Host "--Secret ""$($credentials.Password)"""
    Write-Host ""
    Write-Host "After building the solution, you may find the executable under the following folder: ""artifacts\bin\Azure.Messaging.EventHubs.Samples\Debug\netcoreapp2.1"""
    Write-Host ""
}
catch 
{
    Write-Error $_.Exception.Message
    TearDownResources -ResourceGroupName "$($resourceGroupName)" `
                      -NamespaceName "$($namespaceName)" `
                      -EventHubName "$($eventHubName)" `
                      -WasResourceGroupCreated $wasResourceGroupCreated `
                      -WasNamespaceCreated $wasNamespaceCreated `
                      -WasEventHubCreated $wasEventHubCreated
    exit -1
}
