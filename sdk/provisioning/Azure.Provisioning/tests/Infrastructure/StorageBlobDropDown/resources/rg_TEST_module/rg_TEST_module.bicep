
resource storageAccount_PdjzkDDBx 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct1434f94e82d1418'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_uNPuvG8H2 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_PdjzkDDBx
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
