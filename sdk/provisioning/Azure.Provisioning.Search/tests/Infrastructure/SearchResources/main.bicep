targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource searchService_xRr8B27eB 'Microsoft.Search/searchServices@2023-11-01' = {
  name: toLower(take('search${uniqueString(resourceGroup().id)}', 24))
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

resource roleAssignment_QW8TtZFx6 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: searchService_xRr8B27eB
  name: guid(searchService_xRr8B27eB.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7ca78c08-252a-4471-8644-bb5ff32d4ba0'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7ca78c08-252a-4471-8644-bb5ff32d4ba0')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

resource roleAssignment_14nEicLnR 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: searchService_xRr8B27eB
  name: guid(searchService_xRr8B27eB.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '8ebe5a00-799e-43f5-93ac-243d3dce84a7'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '8ebe5a00-799e-43f5-93ac-243d3dce84a7')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

output connectionString string = 'Endpoint=https://${searchService_xRr8B27eB.name}.search.windows.net'
