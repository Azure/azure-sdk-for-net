
resource storageAccount_9uo2memqT 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_1gFXR9AUz 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_9uo2memqT
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
