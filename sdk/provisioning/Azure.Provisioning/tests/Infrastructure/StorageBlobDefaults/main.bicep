targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_blTmfjwbK 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-4e4db487e2b643'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_BsPXWXWhN 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_blTmfjwbK
  name: 'photos-TEST'
  properties: {
    cors: {
    }
  }
}
