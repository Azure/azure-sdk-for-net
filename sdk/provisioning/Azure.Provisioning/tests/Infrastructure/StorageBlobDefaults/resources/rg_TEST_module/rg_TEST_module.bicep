
resource storageAccount_XILrw4Skb 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct758c880e1f9a497'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_MbIr6CaiQ 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_XILrw4Skb
  name: 'default'
  properties: {
  }
}
