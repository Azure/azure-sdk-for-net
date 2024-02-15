targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_TDwXOzG67 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoAcct-7f1b0ebf61714c'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_JcufSwMPd 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_TDwXOzG67
  name: 'photos-TEST'
  properties: {
    cors: {
    }
  }
}
