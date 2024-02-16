
resource storageAccount_bMTglVxrj 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-1d1f34e6a3be44'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_NXFUDK0Bk 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_bMTglVxrj
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
