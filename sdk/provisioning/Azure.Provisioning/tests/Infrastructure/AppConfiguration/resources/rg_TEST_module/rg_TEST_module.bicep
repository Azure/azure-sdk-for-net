
resource appConfigurationStore_6Q8NF0lPF 'Microsoft.AppConfiguration/configurationStores@2023-03-01' = {
  name: toLower(take('store${uniqueString(resourceGroup().id)}', 24))
  location: 'westus'
  sku: {
    name: 'standard'
  }
  properties: {
  }
}

resource roleAssignment_0VzBmi9om 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: appConfigurationStore_6Q8NF0lPF
  name: guid(appConfigurationStore_6Q8NF0lPF.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b'))
  properties: {
    roleDefinitionId: subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}
