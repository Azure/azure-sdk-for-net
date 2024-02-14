targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_wIOls6qWR 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-b238b0e606ba44'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_gWmK7aIWs 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_wIOls6qWR
  name: 'photos-TEST'
  properties: {
    cors: {
    }
  }
}
