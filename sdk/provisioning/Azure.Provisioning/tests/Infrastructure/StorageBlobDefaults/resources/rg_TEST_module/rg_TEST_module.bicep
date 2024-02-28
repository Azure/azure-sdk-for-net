
resource storageAccount_dyozfjPDO 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct7847575b56384de'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_iHC2iPkLK 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_dyozfjPDO
  name: 'default'
  properties: {
  }
}
