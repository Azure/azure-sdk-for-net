
resource storageAccount_NyDpTNqSL 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'photoacct3b11f1b89643468'
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_oTZUNu7WB 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_NyDpTNqSL
  name: 'default'
  properties: {
    deleteRetentionPolicy: {
      enabled: true
    }
  }
}

resource roleAssignment_8RPwLRajz 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_NyDpTNqSL
  name: 'dsfphotoacct3b11f1b89643'
  properties: {
    roleDefinitionId: '/providers/Microsoft.Authorization/roleDefinitions/ba92f5b4-2d11-453d-a403-e96b0029c9fe'
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'User'
  }
}
