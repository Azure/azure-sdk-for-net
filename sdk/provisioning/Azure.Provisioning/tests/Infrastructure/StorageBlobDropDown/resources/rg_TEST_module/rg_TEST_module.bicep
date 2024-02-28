
resource storageAccount_OnxXGtuP6 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct2284361e3826417'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_iJRYUuaLf 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_OnxXGtuP6
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
