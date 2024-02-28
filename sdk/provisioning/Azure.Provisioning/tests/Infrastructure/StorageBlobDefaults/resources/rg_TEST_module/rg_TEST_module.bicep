
resource storageAccount_hWQR13jUf 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct71d9792260684fd'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_UnN8ydpj5 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_hWQR13jUf
  name: 'default'
  properties: {
  }
}
