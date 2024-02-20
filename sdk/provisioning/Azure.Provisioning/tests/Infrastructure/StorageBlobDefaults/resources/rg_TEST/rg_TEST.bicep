
resource storageAccount_jORbq022C 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacctbf68eaef19d0452'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_B90xkTXuz 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_jORbq022C
  name: 'default'
  properties: {
    cors: {
    }
  }
}
