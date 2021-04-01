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
$PrimaryAccountZoneWithPeriod = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_ZONE_WITH_PERIOD']
$SecondaryAccountName = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_NAME']
$SecondaryAccountKey = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_KEY']
$SecondaryAccountZoneWithPeriod = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_ZONE_WITH_PERIOD']
$PremiumAccountName = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_NAME']
$PremiumAccountKey = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_KEY']
$PremiumAccountZoneWithPeriod = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_ZONE_WITH_PERIOD']
$DataLakeAccountName = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_NAME']
$DataLakeAccountKey = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_KEY']
$DataLakeAccountZoneWithPeriod = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_ZONE_WITH_PERIOD']
$SoftDeleteAccountName = $DeploymentOutputs['SOFT_DELETE_ACCOUNT_NAME']
$SoftDeleteAccountKey = $DeploymentOutputs['SOFT_DELETE_ACCOUNT_KEY']
$SoftDeleteAccountZoneWithPeriod = $DeploymentOutputs['SOFT_DELETE_STORAGE_ACCOUNT_ZONE_WITH_PERIOD']
$PremiumFileAccountName = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_NAME']
$PremiumFileAccountKey = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_KEY']
$PremiumFileAccountZoneWithPeriod = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_ZONE_WITH_PERIOD']
$KeyVaultUri = $DeploymentOutputs['KEYVAULT_URI']
$EndpointSuffix = $DeploymentOutputs['ENDPOINT_SUFFIX']

# Construct the content of the configuration file that the Storage tests expect
$content = 
"<TestConfigurations>
  <TargetTestTenant>ProductionTenant</TargetTestTenant>
  <TargetPremiumBlobTenant>PremiumTenant</TargetPremiumBlobTenant>
  <TargetSecondaryTestTenant>ProductionTenant2</TargetSecondaryTestTenant>
  <TargetPreviewBlobTenant>NotInPreview</TargetPreviewBlobTenant>
  <TargetOAuthTenant>OAuthTenant</TargetOAuthTenant>
  <TargetHierarchicalNamespaceTenant>NamespaceTenant</TargetHierarchicalNamespaceTenant>
  <TargetBlobAndContainerSoftDeleteTenant>SoftDeleteTenant</TargetBlobAndContainerSoftDeleteTenant>
  <TargetPremiumFileTenant>PremiumFileTenant</TargetPremiumFileTenant>
  <TargetKeyVault>ClientsideEncryptionKeyvault</TargetKeyVault>
  <TenantConfigurations>
    <TenantConfiguration>
      <TenantName>ProductionTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PrimaryAccountName</AccountName>
      <AccountKey>$PrimaryAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary$PrimaryAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary$PrimaryAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary$PrimaryAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary$PrimaryAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;BlobEndpoint=https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.blob.$EndpointSuffix;FileEndpoint=https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.file.$EndpointSuffix;QueueEndpoint=https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.queue.$EndpointSuffix;TableEndpoint=https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.table.$EndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumAccountName</AccountName>
      <AccountKey>$PremiumAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PremiumAccountName$PremiumAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PremiumAccountName$PremiumAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PremiumAccountName$PremiumAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PremiumAccountName$PremiumAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PremiumAccountName-secondary$PremiumAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PremiumAccountName-secondary$PremiumAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PremiumAccountName-secondary$PremiumAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PremiumAccountName-secondary$PremiumAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PremiumAccountName;AccountKey=$PremiumAccountKey;BlobEndpoint=https://$PremiumAccountName$PremiumAccountZoneWithPeriod.blob.$EndpointSuffix;FileEndpoint=https://$PremiumAccountName$PremiumAccountZoneWithPeriod.file.$EndpointSuffix;QueueEndpoint=https://$PremiumAccountName$PremiumAccountZoneWithPeriod.queue.$EndpointSuffix;TableEndpoint=https://$PremiumAccountName$PremiumAccountZoneWithPeriod.table.$EndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>ProductionTenant2</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SecondaryAccountName</AccountName>
      <AccountKey>$SecondaryAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SecondaryAccountName$SecondaryAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SecondaryAccountName$SecondaryAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$SecondaryAccountName$SecondaryAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$SecondaryAccountName$SecondaryAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary$SecondaryAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary$SecondaryAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary$SecondaryAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary$SecondaryAccountZoneWithPeriod.table.$EndpointSuffix<TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>OAuthTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PrimaryAccountName</AccountName>
      <AccountKey>$PrimaryAccountKey</AccountKey>
      <ActiveDirectoryApplicationId>$TestApplicationId</ActiveDirectoryApplicationId>
      <ActiveDirectoryApplicationSecret>$TestApplicationSecret</ActiveDirectoryApplicationSecret>
      <ActiveDirectoryTenantId>$TenantId</ActiveDirectoryTenantId>
      <ActiveDirectoryAuthEndpoint>https://login.microsoftonline.com/</ActiveDirectoryAuthEndpoint>
      <BlobServiceEndpoint>https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary$PrimaryAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary$PrimaryAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary$PrimaryAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary$PrimaryAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;BlobEndpoint=https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.blob.$EndpointSuffix;FileEndpoint=https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.file.$EndpointSuffix;QueueEndpoint=https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.queue.$EndpointSuffix;TableEndpoint=https://$PrimaryAccountName$PrimaryAccountZoneWithPeriod.table.$EndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>NamespaceTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$DataLakeAccountName</AccountName>
      <AccountKey>$DataLakeAccountKey</AccountKey>
      <ActiveDirectoryApplicationId>$TestApplicationId</ActiveDirectoryApplicationId>
      <ActiveDirectoryApplicationSecret>$TestApplicationSecret</ActiveDirectoryApplicationSecret>
      <ActiveDirectoryTenantId>$TenantId</ActiveDirectoryTenantId>
      <ActiveDirectoryAuthEndpoint>https://login.microsoftonline.com/</ActiveDirectoryAuthEndpoint>
      <BlobServiceEndpoint>https://$DataLakeAccountName$DataLakeAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$DataLakeAccountName$DataLakeAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$DataLakeAccountName$DataLakeAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$DataLakeAccountName$DataLakeAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary$DataLakeAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary$DataLakeAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary$DataLakeAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary$DataLakeAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>SoftDeleteTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SoftDeleteAccountName</AccountName>
      <AccountKey>$SoftDeleteAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SoftDeleteAccountName$SoftDeleteAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SoftDeleteAccountName$SoftDeleteAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$SoftDeleteAccountName$SoftDeleteAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$SoftDeleteAccountName$SoftDeleteAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary$SoftDeleteAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary$SoftDeleteAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary$SoftDeleteAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary$SoftDeleteAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumFileTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumFileAccountName</AccountName>
      <AccountKey>$PremiumFileAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PremiumFileAccountName$PremiumFileAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PremiumFileAccountName$PremiumFileAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PremiumFileAccountName$PremiumFileAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PremiumFileAccountName$PremiumFileAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary$PremiumFileAccountZoneWithPeriod.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary$PremiumFileAccountZoneWithPeriod.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary$PremiumFileAccountZoneWithPeriod.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary$PremiumFileAccountZoneWithPeriod.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
  </TenantConfigurations>
  <KeyVaultConfigurations>
    <KeyVaultConfiguration>
      <VaultName>ClientsideEncryptionKeyvault</VaultName>
      <VaultEndpoint>$KeyVaultUri</VaultEndpoint>
      <ActiveDirectoryApplicationId>$TestApplicationId</ActiveDirectoryApplicationId>
      <ActiveDirectoryApplicationSecret>$TestApplicationSecret</ActiveDirectoryApplicationSecret>
      <ActiveDirectoryTenantId>$TenantId</ActiveDirectoryTenantId>
      <ActiveDirectoryAuthEndpoint>https://login.microsoftonline.com/</ActiveDirectoryAuthEndpoint>
    </KeyVaultConfiguration>
  </KeyVaultConfigurations>
</TestConfigurations>"

# Construct the test configuration path to use based on the devops build variable for artifact staging directory
$TestConfigurationPath = Join-Path -Path $env:BUILD_ARTIFACTSTAGINGDIRECTORY -ChildPath 'TestConfiguration.xml'

Write-Verbose "Writing test configuration file to $TestConfigurationPath"
$content | Set-Content $TestConfigurationPath

Write-Verbose "Setting AZ_STORAGE_CONFIG_PATH environment variable used by Storage Tests"
# https://github.com/microsoft/azure-pipelines-tasks/blob/master/docs/authoring/commands.md#logging-commands
Write-Host "##vso[task.setvariable variable=AZ_STORAGE_CONFIG_PATH]$TestConfigurationPath"

# Wait until RBAC replicates. It has 5min SLA. https://github.com/Azure/azure-sdk-for-net/issues/17384 to find better solution.
Write-Verbose "Sleeping for 90 seconds to let RBAC replicate"
Start-Sleep -s 90
