targetScope = 'resourceGroup'


resource storageAccount_bx3kggbgi 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: resourceGroup().location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_WhrH1thCS 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_bx3kggbgi
  name: 'default'
  properties: {
  }
}
