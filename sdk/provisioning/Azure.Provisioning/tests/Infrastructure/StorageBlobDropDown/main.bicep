targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_hEAJzZrZs 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-1b8d4004b0984b'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_0wStUCho1 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_hEAJzZrZs
  name: 'photos-TEST'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
