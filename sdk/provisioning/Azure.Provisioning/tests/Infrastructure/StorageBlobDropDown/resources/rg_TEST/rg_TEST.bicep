
resource storageAccount_g16JGJUrY 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-6c337c3efac749'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_f8CmSjkLj 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_g16JGJUrY
  name: 'photos-TEST'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
