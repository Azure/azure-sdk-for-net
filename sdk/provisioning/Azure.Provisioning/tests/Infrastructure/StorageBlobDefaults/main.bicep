targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_Ye9LJb6pI 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-81ca1b490dc845'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_jQ0GJbw9F 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_Ye9LJb6pI
  name: 'photos-TEST'
  properties: {
    cors: {
    }
  }
}
