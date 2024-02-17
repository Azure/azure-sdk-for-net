
resource storageAccount_09oO2xkqI 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-bfa7580cfd5449'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_fWKBSsxJN 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_09oO2xkqI
  name: 'default'
  properties: {
    cors: {
    }
  }
}
