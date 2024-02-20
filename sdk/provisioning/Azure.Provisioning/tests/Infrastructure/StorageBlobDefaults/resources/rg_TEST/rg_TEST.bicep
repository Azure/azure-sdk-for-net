
resource storageAccount_XyWBeAbL6 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct7909f77b383a447'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_SduEdkgbK 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_XyWBeAbL6
  name: 'default'
  properties: {
    cors: {
    }
  }
}
