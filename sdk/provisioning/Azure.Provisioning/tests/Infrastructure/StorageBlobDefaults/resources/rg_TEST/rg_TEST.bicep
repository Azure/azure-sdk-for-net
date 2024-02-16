
resource storageAccount_S5qJniO7O 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-5fa1326a602c47'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_NVGSBDZv1 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_S5qJniO7O
  name: 'photos-TEST'
  properties: {
    cors: {
    }
  }
}
