targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('')
param myLocationParam string


resource storageAccount_7EH24TZOS 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('photoAcct${uniqueString(resourceGroup().id)}', 24))
  location: myLocationParam
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
  }
}
