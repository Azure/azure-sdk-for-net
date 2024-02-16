
resource storageAccount_iyoTs4lhI 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-122b5075e14f4e'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_2AWlCCB4v 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_iyoTs4lhI
  name: 'default'
  properties: {
    cors: {
    }
  }
}
