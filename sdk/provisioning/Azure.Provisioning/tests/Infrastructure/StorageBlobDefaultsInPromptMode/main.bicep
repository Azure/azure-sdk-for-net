targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource storageAccount_7EH24TZOS 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('photoAcct${uniqueString(resourceGroup().id)}', 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
  }
}

resource blobService_7QL3qUuBS 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_7EH24TZOS
  name: 'default'
  properties: {
  }
}
