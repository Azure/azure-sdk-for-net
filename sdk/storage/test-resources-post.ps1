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
$SoftDeleteAccountName = $DeploymentOutputs['SOFT_DELETE_ACCOUNT_NAME']
$SoftDeleteAccountKey = $DeploymentOutputs['SOFT_DELETE_ACCOUNT_KEY']
$PremiumFileAccountName = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_NAME']
$PremiumFileAccountKey = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_KEY']
$KeyVaultUri = $DeploymentOutputs['KEYVAULT_URI']

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
      <BlobServiceEndpoint>https://$PrimaryAccountName.blob.core.windows.net</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.queue.core.windows.net</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.table.core.windows.net</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.file.core.windows.net</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.blob.core.windows.net</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.queue.core.windows.net</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.file.core.windows.net</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.table.core.windows.net</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;EndpointSuffix=core.windows.net</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumAccountName</AccountName>
      <AccountKey>$PremiumAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PremiumAccountName.blob.core.windows.net</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PremiumAccountName.queue.core.windows.net</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PremiumAccountName.table.core.windows.net</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PremiumAccountName.file.core.windows.net</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.blob.core.windows.net</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.queue.core.windows.net</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.file.core.windows.net</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.table.core.windows.net</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PremiumAccountName;AccountKey=$PremiumAccountKey;EndpointSuffix=core.windows.net</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>ProductionTenant2</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SecondaryAccountName</AccountName>
      <AccountKey>$SecondaryAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SecondaryAccountName.blob.core.windows.net</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SecondaryAccountName.queue.core.windows.net</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$SecondaryAccountName.table.core.windows.net</TableServiceEndpoint>
      <FileServiceEndpoint>https://$SecondaryAccountName.file.core.windows.net</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.blob.core.windows.net</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.queue.core.windows.net</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.file.core.windows.net</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.table.core.windows.net</TableServiceSecondaryEndpoint>
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
      <BlobServiceEndpoint>https://$PrimaryAccountName.blob.core.windows.net</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.queue.core.windows.net</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.table.core.windows.net</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.file.core.windows.net</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.blob.core.windows.net</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.queue.core.windows.net</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.file.core.windows.net</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.table.core.windows.net</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;EndpointSuffix=core.windows.net</ConnectionString>
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
      <BlobServiceEndpoint>https://$DataLakeAccountName.blob.core.windows.net</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$DataLakeAccountName.queue.core.windows.net</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$DataLakeAccountName.table.core.windows.net</TableServiceEndpoint>
      <FileServiceEndpoint>https://$DataLakeAccountName.file.core.windows.net</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.blob.core.windows.net</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.queue.core.windows.net</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.file.core.windows.net</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.table.core.windows.net</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>SoftDeleteTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SoftDeleteAccountName</AccountName>
      <AccountKey>$SoftDeleteAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SoftDeleteAccountName.blob.core.windows.net</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SoftDeleteAccountName.queue.core.windows.net</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$SoftDeleteAccountName.table.core.windows.net</TableServiceEndpoint>
      <FileServiceEndpoint>https://$SoftDeleteAccountName.file.core.windows.net</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.blob.core.windows.net</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.queue.core.windows.net</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.file.core.windows.net</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.table.core.windows.net</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumFileTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumFileAccountName</AccountName>
      <AccountKey>$PremiumFileAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PremiumFileAccountName.blob.core.windows.net</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PremiumFileAccountName.queue.core.windows.net</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PremiumFileAccountName.table.core.windows.net</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PremiumFileAccountName.file.core.windows.net</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.blob.core.windows.net</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.queue.core.windows.net</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.file.core.windows.net</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.table.core.windows.net</TableServiceSecondaryEndpoint>
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
