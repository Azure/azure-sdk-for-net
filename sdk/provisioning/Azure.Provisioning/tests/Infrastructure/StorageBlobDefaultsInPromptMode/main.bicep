targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource storageAccount_cU8v6cAqM 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_QhDlnWma3 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_cU8v6cAqM
  name: 'default'
  properties: {
  }
}
