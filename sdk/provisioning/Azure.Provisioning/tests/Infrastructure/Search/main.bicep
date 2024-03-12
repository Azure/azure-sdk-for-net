targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource searchService_cwdgn2HGu 'Microsoft.Search/searchServices@2023-11-01' = {
  name: toLower(take(concat('search', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'standard'
  }
  properties: {
    replicaCount: 1
    partitionCount: 1
    hostingMode: 'default'
    disableLocalAuth: true
  }
}

resource roleAssignment_dcgUqp8kp 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: searchService_cwdgn2HGu
  name: guid(searchService_cwdgn2HGu.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7ca78c08-252a-4471-8644-bb5ff32d4ba0'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7ca78c08-252a-4471-8644-bb5ff32d4ba0')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

resource roleAssignment_1CP5SnX3w 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: searchService_cwdgn2HGu
  name: guid(searchService_cwdgn2HGu.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '8ebe5a00-799e-43f5-93ac-243d3dce84a7'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '8ebe5a00-799e-43f5-93ac-243d3dce84a7')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

output connectionString string = 'Endpoint=https://${searchService_cwdgn2HGu.name}.search.windows.net'
