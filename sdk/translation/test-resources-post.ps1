# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# It is invoked by the https://github.com/Azure/azure-sdk-for-net/blob/main/eng/New-TestResources.ps1
# script after the ARM template, defined in https://github.com/hamshavathimunibyraiah/azure-sdk-for-net/blob/main/sdk/translation/test-resources.json,
# is finished being deployed. The ARM template is responsible for creating the Storage accounts needed for live tests.

param (
    [hashtable] $DeploymentOutputs,
	[string] $ResourceGroupName, # this is the resourceGroup name where the Translator resource is created
	[string] $BaseName, # this is the Translator resource name
	[string] $TestApplicationId, # this is the TestApplicationId
	[string] $TenantId, # this is the TenantId
	[string] $ProvisionerApplicationOid # this is the ProvisionerApplicationOid
)

if($DeploymentOutputs.ContainsKey('DOCUMENT_TRANSLATION_STORAGE_NAME')){
  Write-Host "DOCUMENT_TRANSLATION_STORAGE_NAME exists, proceeding."
}else{
  Write-Host "DOCUMENT_TRANSLATION_STORAGE_NAME does not exist, ending."
exit
}
$storageAccountName = $DeploymentOutputs["DOCUMENT_TRANSLATION_STORAGE_NAME"]

function Log($Message) {
  Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

Log 'Starting sdk\translation\test-resources-post.ps1'

#Log 'Login to azure'
# PowerShell cmd : az login --service-principal -u $TestApplicationId --tenant $TenantId --allow-no-subscriptions --federated-token $env:ARM_OIDC_TOKEN
# az login --service-principal -u $TestApplicationId --tenant $TenantId --allow-no-subscriptions # --federated-token $env:ARM_OIDC_TOKEN
# Connect-AzAccount -ServicePrincipal -Tenant $TenantId -ApplicationId $TestApplicationId -FederatedToken $env:ARM_OIDC_TOKEN -Environment AzureCloud -Scope Process

#Log 'Enable Managed identity on the Translator resource'
# PowerShell cmd : az cognitiveservices account identity assign --name <TranslatorResourceName> --resource-group <ResourceGroupName>
# az cognitiveservices account identity assign --name $BaseName --resource-group $ResourceGroupName

Log 'Logging in if the user is not logged, running Connect-AzAccount'
Connect-AzAccount
Log "Application ID of the logged account is $($ProvisionerApplicationOid)"

Log 'In the storage account, assign Storage-Blob-Data-Contributor role access to translator resource'
Log 'Step 1: Get the Resource ID of the storage account'
Log "Executing Azure PoweShell cmd: $storageAccount = Get-AzStorageAccount -ResourceGroupName $($ResourceGroupName) -Name $($storageAccountName)"
$storageAccount = Get-AzStorageAccount -ResourceGroupName $ResourceGroupName -Name $storageAccountName
$resourceId = $storageAccount.Id
Log "Resource ID of the storage account is $($resourceId)"

#Log 'Step 2: Get the objectId or the principalId of the translator resource that needs to be added'
#Log "Executing Azure PowerShell cmd : $identityObjectId = (Get-AzADServicePrincipal -DisplayName $($BaseName)).Id"
#Log "BaseName is $($BaseName)"
#$identityObject = Get-AzADServicePrincipal -DisplayName $BaseName
#Log "IdentityObject is $($identityObject)"
#$identityObjectId = $identityObject.Id
#Log "Object ID or the principalId is $($identityObjectId)"

Log 'Step 3: Assign Storage-Blob-Data-Contributor role' 
#Log 'Executing Azure PowerShell cmd : New-AzRoleAssignment -RoleDefinitionName $($roleName) -ObjectId $($identityObjectId) -Scope $($storageAccountId)'
$roleName = "Storage Blob Data Contributor"
Log 'Executing New-AzRoleAssignment -RoleDefinitionName $($roleName) -UserPrincipalName $($userId) -Scope $($resourceId)'
New-AzRoleAssignment -RoleDefinitionName $roleName -UserPrincipalName $ProvisionerApplicationOid -Scope $resourceId
# New-AzRoleAssignment -RoleDefinitionName $roleName -ObjectId $identityObjectId -Scope $storageAccountId

Log 'Finishing sdk\translation\test-resources-post.ps1'