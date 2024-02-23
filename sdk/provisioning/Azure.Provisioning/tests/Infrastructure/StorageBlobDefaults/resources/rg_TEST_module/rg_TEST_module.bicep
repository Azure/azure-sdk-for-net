
resource storageAccount_HyirDMZoD 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct061c8f62f9864b9'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_7r8FxNxCI 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_HyirDMZoD
  name: 'default'
  properties: {
  }
}
