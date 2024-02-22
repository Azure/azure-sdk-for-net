
resource storageAccount_uVkMHo5HI 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacctedca28ca81d643d'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_z01YdOOpK 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_uVkMHo5HI
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
