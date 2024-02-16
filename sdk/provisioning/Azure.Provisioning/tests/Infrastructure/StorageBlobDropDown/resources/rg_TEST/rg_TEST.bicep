
resource storageAccount_2jsIm80wf 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-9848177a84ad43'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_6NwKBOBDn 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_2jsIm80wf
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
