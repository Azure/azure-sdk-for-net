targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('')
param myLocationParam string


resource storageAccount_YRiDhR43q 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: myLocationParam
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
  }
}
