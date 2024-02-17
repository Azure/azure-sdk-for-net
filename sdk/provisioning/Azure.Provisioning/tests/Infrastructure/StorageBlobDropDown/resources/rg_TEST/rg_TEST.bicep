
resource storageAccount_cvRbpW6Kf 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoAcct-f05b13cb20c645'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_WE1CCaoav 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_cvRbpW6Kf
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
