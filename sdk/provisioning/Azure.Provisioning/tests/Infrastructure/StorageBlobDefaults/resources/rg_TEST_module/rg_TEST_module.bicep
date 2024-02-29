
resource storageAccount_KJr92DLg3 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_brrSlGi3s 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_KJr92DLg3
  name: 'default'
  properties: {
  }
}
