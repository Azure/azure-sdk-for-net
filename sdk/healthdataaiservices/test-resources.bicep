// "id": "/subscriptions/d12535ed-5958-4ce6-8350-b17b3af1d6b1/resourceGroups/oro-billing-exhaust-test/providers/Microsoft.HealthDataAIServices/DeidServices/deid-billing-test",
// "name": "deid-billing-test",
// "type": "microsoft.healthdataaiservices/deidservices",
// "location": "East US 2 EUAP",
// "tags": {},

@minLength(10)
param testApplicationOid string

@minLength(6)
@maxLength(50)
@description('The base resource name.')
param baseName string

param location string = resourceGroup().location

@description('The location of the resource. By default, this is the same as the resource group.')
param deidLocation string = 'canadacentral'

param deploymentTime string = utcNow('u')

var realtimeDataUserRoleId = 'bb6577c4-ea0a-40b2-8962-ea18cb8ecd4e'
var batchDataOwnerRoleId = '8a90fa6b-6997-4a07-8a95-30633a7c97b9'
var storageBlobDataContributor = 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'

var blobStorageName = take(toLower(replace('blob-${baseName}', '-', '')), 24)
var blobContainerName = 'container-${baseName}'
var deidServiceName = 'deid-${baseName}'

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
  name: blobStorageName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    minimumTlsVersion: 'TLS1_2'
  }
}

resource blobService 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' = {
  parent: storageAccount
  name: 'default'
}

resource container 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  parent: blobService
  name: blobContainerName
}

resource storageRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = {
  name: guid(resourceGroup().id, storageAccount.id, testApplicationOid, storageBlobDataContributor)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', storageBlobDataContributor)
    principalId: testApplicationOid
  }
  scope: storageAccount
}

resource testDeidService 'microsoft.healthdataaiservices/deidservices@2023-06-01-preview' = {
  name: deidServiceName
  location: deidLocation
}

resource realtimeRole 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, testDeidService.id, testApplicationOid, realtimeDataUserRoleId)
  scope: testDeidService
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', realtimeDataUserRoleId)
    principalId: testApplicationOid
  }
}

resource batchRole 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, testDeidService.id, testApplicationOid, batchDataOwnerRoleId)
  scope: testDeidService
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', batchDataOwnerRoleId)
    principalId: testApplicationOid
  }
}

// https://learn.microsoft.com/en-us/rest/api/storagerp/storage-accounts/list-account-sas?view=rest-storagerp-2023-01-01&tabs=HTTP
var blobStorageSASUri = listAccountSAS(storageAccount.name, '2023-01-01', {
  signedProtocol: 'https'
  signedResourceTypes: 'sco'
  signedPermission: 'rwlca'
  signedServices: 'b'
  signedExpiry: dateTimeAdd(deploymentTime, 'PT4H')
}).accountSasToken

var blobStorageConnectionString = 'DefaultEndpointsProtocol=https;AccountName=${storageAccount.name};EndpointSuffix=${environment().suffixes.storage};AccountKey=${storageAccount.listKeys().keys[0].value}'

output DEID_SERVICE_ENDPOINT string = testDeidService.properties.serviceUrl
output STORAGE_ACCOUNT_CONNECTION_STRING string = blobStorageConnectionString
output STORAGE_ACCOUNT_SAS_URI string = '${storageAccount.properties.primaryEndpoints.blob}${blobContainerName}?${blobStorageSASUri}'
output STORAGE_CONTAINER_NAME string = container.name
