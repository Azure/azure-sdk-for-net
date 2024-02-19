
resource storageAccount_C1jU1QLp9 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-9cc6fa9880e244'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_ZPAVRcajy 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_C1jU1QLp9
  name: 'default'
  properties: {
    cors: {
    }
  }
}
