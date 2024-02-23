
resource storageAccount_AWAf1i775 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct03a34cbffeba423'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_hbrFFOTsM 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_AWAf1i775
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
