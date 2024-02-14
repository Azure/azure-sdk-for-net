targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_wGMcLf7GV 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-7d33c4f9e2094f'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_AKyY0JFhn 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_wGMcLf7GV
  name: 'photos-TEST'
  properties: {
    cors: {
    }
  }
}
