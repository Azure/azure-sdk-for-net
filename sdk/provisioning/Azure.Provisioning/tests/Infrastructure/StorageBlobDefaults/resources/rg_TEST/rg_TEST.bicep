
resource storageAccount_8fKO55BEa 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacctc69d56d11b224fe'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_UWDFk5mnH 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_8fKO55BEa
  name: 'default'
  properties: {
    cors: {
    }
  }
}
