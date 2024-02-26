
resource storageAccount_0socNL5dP 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct74fc8bcc792b429'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_atCEUE42D 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_0socNL5dP
  name: 'default'
  properties: {
  }
}
