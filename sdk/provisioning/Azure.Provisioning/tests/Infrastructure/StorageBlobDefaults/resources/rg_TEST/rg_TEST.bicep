
resource storageAccount_lhz250vzx 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct0be0d45f98a343c'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_JBIiUqDdA 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_lhz250vzx
  name: 'default'
  properties: {
  }
}
