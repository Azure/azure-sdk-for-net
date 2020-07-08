# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# This script is used to generate the Test Configuration file for Storage live tests.
# It is invoked by the https://github.com/Azure/azure-sdk-for-net/blob/master/eng/New-TestResources.ps1
# script after the ARM template, defined in https://github.com/Azure/azure-sdk-for-net/blob/arm-template-storage/sdk/storage/test-resources.json, 
# is finished being deployed. The ARM template is responsible for creating the Storage accounts needed for live tests.

param (
    [hashtable] $DeploymentOutputs,
    [string] $TenantId,
    [string] $TestApplicationId,
    [string] $TestApplicationSecret
)

# outputs from the ARM deployment passed in from New-TestResources
$PrimaryAccountName = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_NAME']
$PrimaryAccountKey = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_KEY']
$SecondaryAccountName = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_NAME']
$SecondaryAccountKey = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_KEY']
$PremiumAccountName = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_NAME']
$PremiumAccountKey = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_KEY']
$DataLakeAccountName = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_NAME']
$DataLakeAccountKey = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_KEY']
$StorageEndpointSuffix = $DeploymentOutputs['STORAGE_ENDPOINT_SUFFIX']
$AzureAuthorityHost = $DeploymentOutputs['AZURE_AUTHORITY_HOST']

# Construct the content of the configuration file that the Storage tests expect
$content = 
"<TestConfigurations>
  <TargetTestTenant>ProductionTenant</TargetTestTenant>
  <TargetPremiumBlobTenant>PremiumTenant</TargetPremiumBlobTenant>
  <TargetSecondaryTestTenant>ProductionTenant2</TargetSecondaryTestTenant>
  <TargetPreviewBlobTenant>NotInPreview</TargetPreviewBlobTenant>
  <TargetOAuthTenant>OAuthTenant</TargetOAuthTenant>
  <TargetHierarchicalNamespaceTenant>NamespaceTenant</TargetHierarchicalNamespaceTenant>
  <TenantConfigurations>
    <TenantConfiguration>
      <TenantName>ProductionTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PrimaryAccountName</AccountName>
      <AccountKey>$PrimaryAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PrimaryAccountName.blob.$StorageEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.queue.$StorageEndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.table.$StorageEndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.file.$StorageEndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.blob.$StorageEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.queue.$StorageEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.file.$StorageEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.table.$StorageEndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;EndpointSuffix=$StorageEndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumAccountName</AccountName>
      <AccountKey>$PremiumAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PremiumAccountName.blob.$StorageEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PremiumAccountName.queue.$StorageEndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PremiumAccountName.table.$StorageEndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PremiumAccountName.file.$StorageEndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.blob.$StorageEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.queue.$StorageEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.file.$StorageEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.table.$StorageEndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PremiumAccountName;AccountKey=$PremiumAccountKey;EndpointSuffix=$StorageEndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>ProductionTenant2</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SecondaryAccountName</AccountName>
      <AccountKey>$SecondaryAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SecondaryAccountName.blob.$StorageEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SecondaryAccountName.queue.$StorageEndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$SecondaryAccountName.table.$StorageEndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$SecondaryAccountName.file.$StorageEndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.blob.$StorageEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.queue.$StorageEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.file.$StorageEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.table.$StorageEndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>OAuthTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PrimaryAccountName</AccountName>
      <AccountKey>$PrimaryAccountKey</AccountKey>
      <ActiveDirectoryApplicationId>$TestApplicationId</ActiveDirectoryApplicationId>
      <ActiveDirectoryApplicationSecret>$TestApplicationSecret</ActiveDirectoryApplicationSecret>
      <ActiveDirectoryTenantId>$TenantId</ActiveDirectoryTenantId>
      <ActiveDirectoryAuthEndpoint>$AzureAuthorityHost</ActiveDirectoryAuthEndpoint>
      <BlobServiceEndpoint>https://$PrimaryAccountName.blob.$StorageEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.queue.$StorageEndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.table.$StorageEndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.file.$StorageEndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.blob.$StorageEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.queue.$StorageEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.file.$StorageEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.table.$StorageEndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;EndpointSuffix=$StorageEndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>NamespaceTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$DataLakeAccountName</AccountName>
      <AccountKey>$DataLakeAccountKey</AccountKey>
      <ActiveDirectoryApplicationId>$TestApplicationId</ActiveDirectoryApplicationId>
      <ActiveDirectoryApplicationSecret>$TestApplicationSecret</ActiveDirectoryApplicationSecret>
      <ActiveDirectoryTenantId>$TenantId</ActiveDirectoryTenantId>
      <ActiveDirectoryAuthEndpoint>$AzureAuthorityHost</ActiveDirectoryAuthEndpoint>
      <BlobServiceEndpoint>https://$DataLakeAccountName.blob.$StorageEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$DataLakeAccountName.queue.$StorageEndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$DataLakeAccountName.table.$StorageEndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$DataLakeAccountName.file.$StorageEndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.blob.$StorageEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.queue.$StorageEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.file.$StorageEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.table.$StorageEndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
  </TenantConfigurations>
</TestConfigurations>"

# Construct the test configuration path to use based on the devops build variable for artifact staging directory
$TestConfigurationPath = Join-Path -Path $env:BUILD_ARTIFACTSTAGINGDIRECTORY -ChildPath 'TestConfiguration.xml'

Write-Verbose "Writing test configuration file to $TestConfigurationPath"
$content | Set-Content $TestConfigurationPath

Write-Verbose "Setting AZ_STORAGE_CONFIG_PATH environment variable used by Storage Tests"
# https://github.com/microsoft/azure-pipelines-tasks/blob/master/docs/authoring/commands.md#logging-commands
Write-Host "##vso[task.setvariable variable=AZ_STORAGE_CONFIG_PATH]$TestConfigurationPath"

$filecontent = Get-Content -Path $TestConfigurationPath

Write-Output $filecontent