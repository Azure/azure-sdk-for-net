
resource storageAccount_ndlcNKBxw 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-7a12b0a522d940'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_LdjAyjFPX 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_ndlcNKBxw
  name: 'default'
  properties: {
    cors: {
    }
  }
}
