
resource storageAccount_8m1yMfURD 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_9fYI6YA1d 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_8m1yMfURD
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
