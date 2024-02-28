
resource storageAccount_NHn0GuaqX 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct84d98ba67edc4e3'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_58OA4T8kA 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_NHn0GuaqX
  name: 'default'
  properties: {
  }
}
