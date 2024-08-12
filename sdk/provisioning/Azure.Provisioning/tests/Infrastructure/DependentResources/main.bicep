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
    networkAcls: {
      defaultAction: 'Deny'
    }
  }
}

resource storageAccount_GoC2YPRJs 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  dependsOn: [
    storageAccount_7EH24TZOS
  ]
  name: toLower(take('photoAcct2${uniqueString(resourceGroup().id)}', 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
    networkAcls: {
      defaultAction: 'Deny'
    }
  }
}
