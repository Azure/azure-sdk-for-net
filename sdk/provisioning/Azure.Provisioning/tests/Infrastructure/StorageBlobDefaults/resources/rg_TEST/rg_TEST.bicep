
resource storageAccount_e0WVEoLUA 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-84ab8d2397fc43'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_srpkzSrZI 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_e0WVEoLUA
  name: 'default'
  properties: {
    cors: {
    }
  }
}
