
resource storageAccount_xlURFCc5A 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoaccte6de904bc2d5415'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_AhHMDPJzw 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_xlURFCc5A
  name: 'default'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
