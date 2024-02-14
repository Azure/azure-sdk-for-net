targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_9gvCV8M9t 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-464eb449-f1cd-'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_8xlkwSZNm 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_9gvCV8M9t
  name: 'photos-TEST'
  properties: {
    cors: {
    }
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}
