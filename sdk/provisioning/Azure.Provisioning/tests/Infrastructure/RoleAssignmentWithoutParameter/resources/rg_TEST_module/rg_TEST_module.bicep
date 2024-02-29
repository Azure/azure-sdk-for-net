
resource storageAccount_sox2Wv7OW 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_hX2D4quIR 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_sox2Wv7OW
  name: 'default'
  properties: {
  }
}

resource roleAssignment_VB5BZKLW5 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_sox2Wv7OW
  name: guid('storageAccount_sox2Wv7OW', '00000000-0000-0000-0000-000000000000', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
  properties: {
    roleDefinitionId: '/providers/Microsoft.Authorization/roleDefinitions/ba92f5b4-2d11-453d-a403-e96b0029c9fe'
    principalId: '00000000-0000-0000-0000-000000000000'
  }
}
