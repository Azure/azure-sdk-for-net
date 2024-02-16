
resource storageAccount_0S3JP33rx 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-7d403f703f2345'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_N4xqIZXcl 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_0S3JP33rx
  name: 'default'
  properties: {
    cors: {
    }
  }
}
