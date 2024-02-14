targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_3AMx4MnVN 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-e9ffc066-811e-'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_JVW2TmYYM 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_3AMx4MnVN
  name: 'photos-TEST'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
