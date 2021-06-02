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
$PrimaryAccountBlobEndpointSuffix = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_BLOB_ENDPOINT_SUFFIX']
$PrimaryAccountQueueEndpointSuffix = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_QUEUE_ENDPOINT_SUFFIX']
$PrimaryAccountFileEndpointSuffix = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_FILE_ENDPOINT_SUFFIX']
$PrimaryAccountTableEndpointSuffix = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_TABLE_ENDPOINT_SUFFIX']
$SecondaryAccountName = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_NAME']
$SecondaryAccountKey = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_KEY']
$SecondaryAccountBlobEndpointSuffix = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_BLOB_ENDPOINT_SUFFIX']
$SecondaryAccountQueueEndpointSuffix = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_QUEUE_ENDPOINT_SUFFIX']
$SecondaryAccountFileEndpointSuffix = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_FILE_ENDPOINT_SUFFIX']
$SecondaryAccountTableEndpointSuffix = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_TABLE_ENDPOINT_SUFFIX']
$PremiumAccountName = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_NAME']
$PremiumAccountKey = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_KEY']
$PremiumAccountBlobEndpointSuffix = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_BLOB_ENDPOINT_SUFFIX']
$DataLakeAccountName = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_NAME']
$DataLakeAccountKey = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_KEY']
$DataLakeAccountBlobEndpointSuffix = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_BLOB_ENDPOINT_SUFFIX']
$DataLakeAccountQueueEndpointSuffix = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_QUEUE_ENDPOINT_SUFFIX']
$DataLakeAccountFileEndpointSuffix = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_FILE_ENDPOINT_SUFFIX']
$DataLakeAccountTableEndpointSuffix = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_TABLE_ENDPOINT_SUFFIX']
$SoftDeleteAccountName = $DeploymentOutputs['SOFT_DELETE_ACCOUNT_NAME']
$SoftDeleteAccountKey = $DeploymentOutputs['SOFT_DELETE_ACCOUNT_KEY']
$SoftDeleteAccountBlobEndpointSuffix = $DeploymentOutputs['SOFT_DELETE_STORAGE_ACCOUNT_BLOB_ENDPOINT_SUFFIX']
$SoftDeleteAccountQueueEndpointSuffix = $DeploymentOutputs['SOFT_DELETE_STORAGE_ACCOUNT_QUEUE_ENDPOINT_SUFFIX']
$SoftDeleteAccountFileEndpointSuffix = $DeploymentOutputs['SOFT_DELETE_STORAGE_ACCOUNT_FILE_ENDPOINT_SUFFIX']
$SoftDeleteAccountTableEndpointSuffix = $DeploymentOutputs['SOFT_DELETE_STORAGE_ACCOUNT_TABLE_ENDPOINT_SUFFIX']
$PremiumFileAccountName = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_NAME']
$PremiumFileAccountKey = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_KEY']
$PremiumFileAccountEndpointSuffix = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_FILE_ENDPOINT_SUFFIX']
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
      <BlobServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountBlobEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountQueueEndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountTableEndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountFileEndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountBlobEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountQueueEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountFileEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountTableEndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;BlobEndpoint=https://$PrimaryAccountName.$PrimaryAccountBlobEndpointSuffix;FileEndpoint=https://$PrimaryAccountName.$PrimaryAccountFileEndpointSuffix;QueueEndpoint=https://$PrimaryAccountName.$PrimaryAccountQueueEndpointSuffix;TableEndpoint=https://$PrimaryAccountName.$PrimaryAccountTableEndpointSuffix</ConnectionString>
      <EncryptionScope>encryptionScope</EncryptionScope>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumAccountName</AccountName>
      <AccountKey>$PremiumAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PremiumAccountName.$PremiumAccountBlobEndpointSuffix</BlobServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.$PremiumAccountBlobEndpointSuffix</BlobServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PremiumAccountName;AccountKey=$PremiumAccountKey;BlobEndpoint=https://$PremiumAccountName.$PremiumAccountBlobEndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>ProductionTenant2</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SecondaryAccountName</AccountName>
      <AccountKey>$SecondaryAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SecondaryAccountName.$SecondaryAccountBlobEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SecondaryAccountName.$SecondaryAccountQueueEndpointSuffix</QueueServiceEndpoint>
      <FileServiceEndpoint>https://$SecondaryAccountName.$SecondaryAccountFileEndpointSuffix</FileServiceEndpoint>
      <TableServiceEndpoint>https://$SecondaryAccountName.$SecondaryAccountTableEndpointSuffix</TableServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.$SecondaryAccountBlobEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.$SecondaryAccountQueueEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.$SecondaryAccountFileEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.$SecondaryAccountTableEndpointSuffix</TableServiceSecondaryEndpoint>
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
      <BlobServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountBlobEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountQueueEndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountTableEndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountFileEndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountBlobEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountQueueEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountFileEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountTableEndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;BlobEndpoint=https://$PrimaryAccountName.$PrimaryAccountBlobEndpointSuffix;FileEndpoint=https://$PrimaryAccountName.$PrimaryAccountFileEndpointSuffix;QueueEndpoint=https://$PrimaryAccountName.$PrimaryAccountQueueEndpointSuffix;TableEndpoint=https://$PrimaryAccountName.$PrimaryAccountTableEndpointSuffix</ConnectionString>
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
      <BlobServiceEndpoint>https://$DataLakeAccountName.$DataLakeAccountBlobEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$DataLakeAccountName.$DataLakeAccountQueueEndpointSuffix</QueueServiceEndpoint>
      <FileServiceEndpoint>https://$DataLakeAccountName.$DataLakeAccountFileEndpointSuffix</FileServiceEndpoint>
      <TableServiceEndpoint>https://$DataLakeAccountName.$DataLakeAccountTableEndpointSuffix</TableServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.$DataLakeAccountBlobEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.$DataLakeAccountQueueEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.$DataLakeAccountFileEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.$DataLakeAccountTableEndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>SoftDeleteTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SoftDeleteAccountName</AccountName>
      <AccountKey>$SoftDeleteAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SoftDeleteAccountName.$SoftDeleteAccountBlobEndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SoftDeleteAccountName.$SoftDeleteAccountQueueEndpointSuffix</QueueServiceEndpoint>
      <FileServiceEndpoint>https://$SoftDeleteAccountName.$SoftDeleteAccountFileEndpointSuffix</FileServiceEndpoint>
      <TableServiceEndpoint>https://$SoftDeleteAccountName.$SoftDeleteAccountTableEndpointSuffix</TableServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.$SoftDeleteAccountBlobEndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.$SoftDeleteAccountQueueEndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.$SoftDeleteAccountFileEndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.$SoftDeleteAccountTableEndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumFileTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumFileAccountName</AccountName>
      <AccountKey>$PremiumFileAccountKey</AccountKey>
      <FileServiceEndpoint>https://$PremiumFileAccountName.$PremiumFileAccountEndpointSuffix</FileServiceEndpoint>
      <FileServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.$PremiumFileAccountEndpointSuffix</FileServiceSecondaryEndpoint>
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
