
resource storageAccount_melvnlpF2 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_NVMDcYVF9 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_melvnlpF2
  name: 'default'
  properties: {
  }
}

resource roleAssignment_lDOSGTMrV 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_melvnlpF2
  name: guid('storageAccount_melvnlpF2', '00000000-0000-0000-0000-000000000000', subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    roleDefinitionId: subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: '00000000-0000-0000-0000-000000000000'
  }
}
