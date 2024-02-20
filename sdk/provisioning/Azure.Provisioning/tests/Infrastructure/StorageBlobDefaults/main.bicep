targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    'azd-env-name': 'TEST'
  }
}

resource storageAccount_8fTaUIzOg 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoacct2af3506bedd4415'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_1iUqwyvnt 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_8fTaUIzOg
  name: 'default'
  properties: {
    cors: {
    }
  }
}
