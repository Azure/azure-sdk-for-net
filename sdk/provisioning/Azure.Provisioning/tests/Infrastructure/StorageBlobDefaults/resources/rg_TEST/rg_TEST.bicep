
resource storageAccount_HZVm6r0ff 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-ef79af70b9ff4a'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_kHNZCivIP 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_HZVm6r0ff
  name: 'default'
  properties: {
    cors: {
    }
  }
}
