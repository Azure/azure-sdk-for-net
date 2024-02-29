
resource storageAccount_yf7XmHSXv 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_KtI9ejh0g 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_yf7XmHSXv
  name: 'default'
  properties: {
  }
}

resource roleAssignment_m0SeNoTiU 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_yf7XmHSXv
  name: guid('storageAccount_yf7XmHSXv', '00000000-0000-0000-0000-000000000000', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: '00000000-0000-0000-0000-000000000000'
  }
}
