
resource storageAccount_a2XGAMKBQ 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct325d55377d174df'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_kaX51HDAk 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_a2XGAMKBQ
  name: 'default'
  properties: {
  }
}
