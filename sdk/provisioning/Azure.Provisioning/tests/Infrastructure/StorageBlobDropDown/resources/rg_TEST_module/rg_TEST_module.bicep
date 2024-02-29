
resource storageAccount_YAoH3Axuc 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacctaf787d83c5ae451'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_ufi8ybl7h 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_YAoH3Axuc
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
