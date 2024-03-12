
resource appConfigurationStore_4WdTZ5u6X 'Microsoft.AppConfiguration/configurationStores@2023-03-01' = {
  name: toLower(take(concat('store', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'standard'
  }
  properties: {
  }
}

resource roleAssignment_S9dOTzUjk 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: appConfigurationStore_4WdTZ5u6X
  name: guid(appConfigurationStore_4WdTZ5u6X.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b'))
  properties: {
    roleDefinitionId: subscriptionResourceId('00000000-0000-0000-0000-000000000000', 'Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

output appConfigurationStore_4WdTZ5u6X_endpoint string = appConfigurationStore_4WdTZ5u6X.properties.endpoint
