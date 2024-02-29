
resource storageAccount_8QqXaM2M1 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_oZmRpQk1D 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_8QqXaM2M1
  name: 'default'
  properties: {
  }
}
