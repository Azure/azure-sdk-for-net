
resource storageAccount_ft4agpZKs 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-d486cf68eaf642'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_iyZCMCxIy 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_ft4agpZKs
  name: 'default'
  properties: {
    cors: {
    }
  }
}
