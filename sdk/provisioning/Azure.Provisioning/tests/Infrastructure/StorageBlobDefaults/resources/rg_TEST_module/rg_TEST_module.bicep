
resource storageAccount_jg6L4pK91 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct5287f60ab516425'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_nIjctIF1e 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_jg6L4pK91
  name: 'default'
  properties: {
  }
}

resource roleAssignment_VNneMsL48 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_jg6L4pK91
  name: 'storageAccountjg6L4pK91-'
  properties: {
    roleDefinitionId: '/providers/Microsoft.Authorization/roleDefinitions/b7e6dc6d-f1e8-4753-8033-0f276bb0955b'
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}
