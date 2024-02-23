
resource storageAccount_96H1GOZhY 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct3d08551686934f0'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_lUTdsAAld 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_96H1GOZhY
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
