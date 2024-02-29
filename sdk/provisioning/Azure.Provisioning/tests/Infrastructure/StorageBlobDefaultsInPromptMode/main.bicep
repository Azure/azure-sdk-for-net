targetScope = 'resourceGroup'


resource storageAccount_Ls2Cd9uGu 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: resourceGroup().location
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_OdYIZd2T2 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_Ls2Cd9uGu
  name: 'default'
  properties: {
  }
}
