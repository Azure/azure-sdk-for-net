targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_mDiJhgjUk 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-ef06a762-5946-'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_hf0583QKI 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_mDiJhgjUk
  name: 'photos-TEST'
  properties: {
    cors: {
    }
  }
}
