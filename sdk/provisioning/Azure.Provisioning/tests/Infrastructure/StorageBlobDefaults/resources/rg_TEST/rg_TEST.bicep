
resource storageAccount_GGbBhjSY6 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-805a47f9e27440'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_aH4lyE35l 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_GGbBhjSY6
  name: 'default'
  properties: {
    cors: {
    }
  }
}
