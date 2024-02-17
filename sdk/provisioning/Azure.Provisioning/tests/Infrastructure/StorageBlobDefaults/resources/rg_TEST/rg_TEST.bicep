
resource storageAccount_KexecArjZ 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-ffa0e09008ef43'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_tgFa0LTtj 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_KexecArjZ
  name: 'default'
  properties: {
    cors: {
    }
  }
}
