
resource storageAccount_bDSMW1Uqt 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct47d801d6b2b9430'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_Gsxn3oU28 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_bDSMW1Uqt
  name: 'default'
  properties: {
  }
}

resource roleAssignment_fhBkYPCMm 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_bDSMW1Uqt
  name: 'photoacct47d801d6b2b9430'
  properties: {
    roleDefinitionId: '/providers/Microsoft.Authorization/roleDefinitions/b7e6dc6d-f1e8-4753-8033-0f276bb0955b'
    principalType: 'ServicePrincipal'
  }
}
