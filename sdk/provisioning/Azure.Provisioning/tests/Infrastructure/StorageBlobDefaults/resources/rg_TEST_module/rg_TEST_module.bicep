
resource storageAccount_yIvt1zzus 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_ElroYO5Uz 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_yIvt1zzus
  name: 'default'
  properties: {
  }
}
