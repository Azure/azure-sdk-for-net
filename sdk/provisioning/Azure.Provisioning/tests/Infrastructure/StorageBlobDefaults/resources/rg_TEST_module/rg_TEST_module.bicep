
resource storageAccount_nyqKj4fVa 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct783bf4edd65646e'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_CjbeMfMgo 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_nyqKj4fVa
  name: 'default'
  properties: {
  }
}
