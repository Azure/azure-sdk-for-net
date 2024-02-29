
resource storageAccount_yIvt1zzus 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: toLower(take(concat('photoAcct', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'Premium_LRS'
  }
  kind: 'StorageV2'
  properties: {
  }
}

resource blobService_ElroYO5Uz 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' = {
  parent: storageAccount_yIvt1zzus
  name: 'default'
  properties: {
  }
}

resource roleAssignment_GXjDfh42Y 'Microsoft.Resources/roleAssignments@2022-04-01' = {
  scope: storageAccount_yIvt1zzus
  name: guid('storageAccount_yIvt1zzus', '00000000-0000-0000-0000-000000000000', subscriptionResourceId('faa080af-c1d8-40ad-9cce-e1a450ca5b57', 'Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'))
  properties: {
    roleDefinitionId: subscriptionResourceId('faa080af-c1d8-40ad-9cce-e1a450ca5b57', 'Microsoft.Authorization/roleDefinitions', 'ba92f5b4-2d11-453d-a403-e96b0029c9fe')
    principalId: '00000000-0000-0000-0000-000000000000'
  }
}
