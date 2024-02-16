
resource storageAccount_BCgLcttHF 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-d1811b9b1d194d'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_pYQLNFbTQ 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_BCgLcttHF
  name: 'default'
  properties: {
    cors: {
    }
  }
}
