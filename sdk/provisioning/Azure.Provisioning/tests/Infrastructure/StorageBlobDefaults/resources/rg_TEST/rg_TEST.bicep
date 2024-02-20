
resource storageAccount_EeYr88hbi 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct23213e49bdeb4ac'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_Xk3xn7f19 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_EeYr88hbi
  name: 'default'
  properties: {
    cors: {
    }
  }
}
