
resource storageAccount_hOJq7fwUJ 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct98d7a228f178408'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_c88nS1we4 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_hOJq7fwUJ
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
