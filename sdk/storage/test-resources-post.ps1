param (
    [hashtable] $DeploymentOutputs,
    [string] $TenantId,
    [string] $TestApplicationId,
    [string] $TestApplicationSecret
)

$TestConfigurationPath = Join-Path $env:Build_ArtifactStagingDirectory 'TestConfiguration.xml'

[System.Environment]::SetEnvironmentVariable('AZ_STORAGE_CONFIG_PATH',$TestConfigurationPath,[System.EnvironmentVariableTarget]::Machine)

Write-Host "ARGS $($args[0])"
# outputs from the ARM deployment
$outputs = $PSBoundParameters['DeploymentOutputs']
$PrimaryAccountName = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_NAME']
Write-Host $PrimaryAccountName
$PrimaryAccountKey = $DeploymentOutputs['PRIMARY_STORAGE_ACCOUNT_KEY']
$SecondaryAccountName = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_NAME']
$SecondaryAccountKey = $DeploymentOutputs['SECONDARY_STORAGE_ACCOUNT_KEY']
$PremiumAccountName = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_NAME']
$PremiumAccountKey = $DeploymentOutputs['PREMIUM_STORAGE_ACCOUNT_KEY']
$DataLakeAccountName = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_NAME']
$DataLakeAccountKey = $DeploymentOutputs['DATALAKE_STORAGE_ACCOUNT_KEY']

$AAdTenantId = $PSBoundParameters['TenantId']
$AadApplicationId = $PSBoundParameters['TestApplicationId']
$AadApplicationSecret = $PSBoundParameters['TestApplicationSecret']

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
      <AccountKey>PrimaryAccountKey</AccountKey>
      <ActiveDirectoryApplicationId>$AadApplicationId</ActiveDirectoryApplicationId>
      <ActiveDirectoryApplicationSecret>$AadApplicationSecret</ActiveDirectoryApplicationSecret>
      <ActiveDirectoryTenantId>$AadTenantId</ActiveDirectoryTenantId>
      <ActiveDirectoryAuthEndpoint>https://login.microsoftonline.com/</ActiveDirectoryAuthEndpoint>
      <BlobServiceEndpoint>https://$PrimaryAccountName.blob.core.windows.net</BlobServiceEndpoint>
      <QueueServiceEndpoint>https://$PrimaryAccountName.queue.core.windows.net</QueueServiceEndpoint>
      <TableServiceEndpoint>https://$PrimaryAccountName.table.core.windows.net</TableServiceEndpoint>
      <FileServiceEndpoint>https://$PrimaryAccountName.file.core.windows.net</FileServiceEndpoint>
      <BlobServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.blob.core.windows.net</BlobServiceSecondaryEndpoint>
      <QueueServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.queue.core.windows.net</QueueServiceSecondaryEndpoint>
      <FileServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.file.core.windows.net</FileServiceSecondaryEndpoint>
      <TableServiceSecondaryEndpoint>https://$PrimaryAccountName-secondary.table.core.windows.net</TableServiceSecondaryEndpoint>
      <ConnectionString>DefaultEndpointsProtocol=https;AccountName=$PrimaryAccountName;AccountKey=PrimaryAccountKey;EndpointSuffix=core.windows.net</ConnectionString>
    </TenantConfiguration>
    <TenantConfiguration>
      <TenantName>NamespaceTenant</TenantName>
      <TenantType>Cloud</TenantType>
      <AccountName>$DataLakeAccountName</AccountName>
      <AccountKey>UkWDC69WPeB5JmX/AcPenKtCX4MrEvxC96y2n88uNJ7Vvft4zAP5QHEukK0C++qqOM611LhjaASVwkRUfSlqNw==</AccountKey>
      <ActiveDirectoryApplicationId>$AadApplicationId</ActiveDirectoryApplicationId>
      <ActiveDirectoryApplicationSecret>$AadApplicationSecret</ActiveDirectoryApplicationSecret>
      <ActiveDirectoryTenantId>$AadTenantId</ActiveDirectoryTenantId>
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
  </TenantConfigurations>
</TestConfigurations>"

Write-Host $TestConfigurationPath
$content | Set-Content $TestConfigurationPath

