targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource storageAccount_YRiDhR43q 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
  }
}

resource blobService_mCwWns176 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_YRiDhR43q
  name: 'default'
  properties: {
  }
}
