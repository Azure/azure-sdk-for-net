targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_64QAbICpM 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-47cc88f8-4ec0-'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_hzBGHAAO1 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_64QAbICpM
  name: 'photos-TEST'
  properties: {
    cors: {
    }
  }
}
