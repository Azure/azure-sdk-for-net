targetScope = subscription


resource resourceGroup_I6QNkoPsb 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-TEST'
  location: 'westus'
  tags: {
    azd-env-name: 'TEST'
  }
}

resource storageAccount_nbANO4pT1 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  scope: resourceGroup_I6QNkoPsb
  name: 'photoaccta09d08a0f66849a'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_QtazDF1cv 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_nbANO4pT1
  name: 'default'
  properties: {
    cors: {
    }
  }
}
