param baseName string
param location string = resourceGroup().location
param endpointSuffix string = '.core.windows.net'

var primaryAccountName = baseName
var pageBlobStorageAccountName = '${baseName}pageblob'

resource primaryAccount 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: primaryAccountName
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {}
}

resource pageBlobStorageAccount 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: pageBlobStorageAccountName
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {}
}

output STORAGE_ENDPOINT_STRING string = '"https://${primaryAccountName}.blob{endpointSuffix}"'
output PAGE_BLOB_STORAGE_ENDPOINT_STRING string = '"https://${pageBlobStorageAccountName}.blob{endpointSuffix}"'