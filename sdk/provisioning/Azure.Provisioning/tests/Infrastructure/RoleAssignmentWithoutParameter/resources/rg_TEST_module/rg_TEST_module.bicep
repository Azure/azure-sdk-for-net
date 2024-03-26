
resource storageAccount_ZnnWSenAP 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take('photoAcct${uniqueString(resourceGroup().id)}', 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'BlockBlobStorage'
  properties: {
  }
}

resource blobService_wAcYakiP0 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_ZnnWSenAP
  name: 'default'
  properties: {
  }
}

resource roleAssignment_q3YvdxEC7 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: storageAccount_ZnnWSenAP
  name: guid(storageAccount_ZnnWSenAP.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    roleDefinitionId: subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

resource roleAssignment_c4BGrZguw 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: storageAccount_ZnnWSenAP
  name: guid(storageAccount_ZnnWSenAP.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', '974c5e8b-45b9-4653-ba55-5f855dd0fb88'))
  properties: {
    roleDefinitionId: subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', '974c5e8b-45b9-4653-ba55-5f855dd0fb88')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

resource roleAssignment_YUoGSZS0y 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: storageAccount_ZnnWSenAP
  name: guid(storageAccount_ZnnWSenAP.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3'))
  properties: {
    roleDefinitionId: subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', '0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'User'
  }
}
