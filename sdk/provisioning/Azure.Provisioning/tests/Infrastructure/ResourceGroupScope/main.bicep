targetScope = 'resourceGroup'


resource storageAccount_47DEQpj8H 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoaccte9deeef3b663494'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_8PVvmwCOI 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_47DEQpj8H
  name: 'default'
  properties: {
  }
}
