
resource storageAccount_0KMvPm04J 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_pCgUv484K 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_0KMvPm04J
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
