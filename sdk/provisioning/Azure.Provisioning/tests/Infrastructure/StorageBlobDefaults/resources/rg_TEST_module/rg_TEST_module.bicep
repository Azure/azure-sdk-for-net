
resource storageAccount_8m1yMfURD 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_9fYI6YA1d 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_8m1yMfURD
  name: 'default'
  properties: {
  }
}

resource roleAssignment_CitWhfa02 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_8m1yMfURD
  name: 'storageAccount8m1yMfURD0'
  properties: {
    roleDefinitionId: '/providers/Microsoft.Authorization/roleDefinitions/ba92f5b4-2d11-453d-a403-e96b0029c9fe'
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}
