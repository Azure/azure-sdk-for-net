
resource storageAccount_aGAXQLBaz 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-61b2effa884d46'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_kKgWTY9gk 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_aGAXQLBaz
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
