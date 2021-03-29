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
$PrimaryAccountZone = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_ZONE']
$SecondaryAccountName = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_NAME']
$SecondaryAccountKey = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_KEY']
$SecondaryAccountZone = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_ZONE']
$PremiumAccountName = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_NAME']
$PremiumAccountKey = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_KEY']
$PremiumAccountZone = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_ZONE']
$DataLakeAccountName = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_NAME']
$DataLakeAccountKey = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_KEY']
$DataLakeAccountZone = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_ZONE']
$SoftDeleteAccountName = $DeploymentOutputs['SOFT_DELETE_ACCOUNT_NAME']
$SoftDeleteAccountKey = $DeploymentOutputs['SOFT_DELETE_ACCOUNT_KEY']
$SoftDeleteAccountZone = $DeploymentOutputs['SOFT_DELETE_STORAGE_ACCOUNT_ZONE']
$PremiumFileAccountName = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_NAME']
$PremiumFileAccountKey = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_KEY']
$PremiumFileAccountZone = $DeploymentOutputs['PREMIUM_FILE_STORAGE_ACCOUNT_ZONE']
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
      <BlobServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountZone.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountZone.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountZone.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountZone.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountZone.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountZone.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountZone.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountZone.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;BlobEndpoint=https://$PrimaryAccountName.$PrimaryAccountZone.blob.$EndpointSuffix;FileEndpoint=https://$PrimaryAccountName.$PrimaryAccountZone.file.$EndpointSuffix;QueueEndpoint=https://$PrimaryAccountName.$PrimaryAccountZone.queue.$EndpointSuffix;TableEndpoint=https://$PrimaryAccountName.$PrimaryAccountZone.table.$EndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumAccountName</AccountName>
      <AccountKey>$PremiumAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PremiumAccountName.$PremiumAccountZone.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PremiumAccountName.$PremiumAccountZone.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PremiumAccountName.$PremiumAccountZone.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PremiumAccountName.$PremiumAccountZone.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.$PremiumAccountZone.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.$PremiumAccountZone.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.$PremiumAccountZone.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PremiumAccountName-secondary.$PremiumAccountZone.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PremiumAccountName;AccountKey=$PremiumAccountKey;BlobEndpoint=https://$PremiumAccountName.$PremiumAccountZone.blob.$EndpointSuffix;FileEndpoint=https://$PremiumAccountName.$PremiumAccountZone.file.$EndpointSuffix;QueueEndpoint=https://$PremiumAccountName.$PremiumAccountZone.queue.$EndpointSuffix;TableEndpoint=https://$PremiumAccountName.$PremiumAccountZone.table.$EndpointSuffix</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>ProductionTenant2</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SecondaryAccountName</AccountName>
      <AccountKey>$SecondaryAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SecondaryAccountName.$SecondaryAccountZone.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SecondaryAccountName.$SecondaryAccountZone.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$SecondaryAccountName.$SecondaryAccountZone.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$SecondaryAccountName.$SecondaryAccountZone.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.$SecondaryAccountZone.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.$SecondaryAccountZone.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.$SecondaryAccountZone.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SecondaryAccountName-secondary.$SecondaryAccountZone.$EndpointSuffix<TableServiceSecondaryEndpoint>
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
      <BlobServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountZone.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountZone.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountZone.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.$PrimaryAccountZone.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountZone.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountZone.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountZone.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.$PrimaryAccountZone.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=$PrimaryAccountKey;BlobEndpoint=https://$PrimaryAccountName.$PrimaryAccountZone.blob.$EndpointSuffix;FileEndpoint=https://$PrimaryAccountName.$PrimaryAccountZone.file.$EndpointSuffix;QueueEndpoint=https://$PrimaryAccountName.$PrimaryAccountZone.queue.$EndpointSuffix;TableEndpoint=https://$PrimaryAccountName.$PrimaryAccountZone.table.$EndpointSuffix</ConnectionString>
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
      <BlobServiceEndpoint>https://$DataLakeAccountName.$DataLakeAccountZone.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$DataLakeAccountName.$DataLakeAccountZone.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$DataLakeAccountName.$DataLakeAccountZone.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$DataLakeAccountName.$DataLakeAccountZone.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.$DataLakeAccountZone.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.$DataLakeAccountZone.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.$DataLakeAccountZone.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$DataLakeAccountName-secondary.$DataLakeAccountZone.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>SoftDeleteTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$SoftDeleteAccountName</AccountName>
      <AccountKey>$SoftDeleteAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$SoftDeleteAccountName.$SoftDeleteAccountZone.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$SoftDeleteAccountName.$SoftDeleteAccountZone.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$SoftDeleteAccountName.$SoftDeleteAccountZone.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$SoftDeleteAccountName.$SoftDeleteAccountZone.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.$SoftDeleteAccountZone.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.$SoftDeleteAccountZone.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.$SoftDeleteAccountZone.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$SoftDeleteAccountName-secondary.$SoftDeleteAccountZone.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>PremiumFileTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$PremiumFileAccountName</AccountName>
      <AccountKey>$PremiumFileAccountKey</AccountKey>
      <BlobServiceEndpoint>https://$PremiumFileAccountName.$PremiumFileAccountZone.blob.$EndpointSuffix</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PremiumFileAccountName.$PremiumFileAccountZone.queue.$EndpointSuffix</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PremiumFileAccountName.$PremiumFileAccountZone.table.$EndpointSuffix</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PremiumFileAccountName.$PremiumFileAccountZone.file.$EndpointSuffix</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.$PremiumFileAccountZone.blob.$EndpointSuffix</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.$PremiumFileAccountZone.queue.$EndpointSuffix</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.$PremiumFileAccountZone.file.$EndpointSuffix</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PremiumFileAccountName-secondary.$PremiumFileAccountZone.table.$EndpointSuffix</TableServiceSecondaryEndpoint>
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
