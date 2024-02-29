
resource storageAccount_9QJmTy7qm 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_Km5lqfZ5q 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_9QJmTy7qm
  name: 'default'
  properties: {
  }
}
