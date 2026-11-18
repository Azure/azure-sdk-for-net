targetScope = 'subscription'

param location string
param resourceGroupName string
param ownerToken string
param identities array
param grants array
param conditionalGrants array

var tags = {
  purpose: 'azsdk-sample-identities'
  'sample-ci-owner': ownerToken
  'sample-ci-retention': 'permanent'
}

resource rg 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: resourceGroupName
  location: location
  tags: tags
}

module identityModule 'identities.bicep' = {
  name: 'identities'
  scope: rg
  params: {
    location: location
    identities: identities
    tags: tags
  }
}

resource plainRoles 'Microsoft.Authorization/roleAssignments@2022-04-01' = [for grant in grants: {
  name: guid(subscription().id, resourceGroupName, string(grant.identityIndex), grant.roleDefinitionId)
  properties: {
    principalId: identityModule.outputs.principalIds[grant.identityIndex]
    principalType: 'ServicePrincipal'
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', grant.roleDefinitionId)
  }
}]

resource conditionalRoles 'Microsoft.Authorization/roleAssignments@2022-04-01' = [for grant in conditionalGrants: {
  name: guid(subscription().id, resourceGroupName, string(grant.identityIndex), grant.roleDefinitionId)
  properties: {
    principalId: identityModule.outputs.principalIds[grant.identityIndex]
    principalType: 'ServicePrincipal'
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', grant.roleDefinitionId)
    condition: grant.condition
    conditionVersion: grant.conditionVersion
  }
}]

output names array = identityModule.outputs.names
output principalIds array = identityModule.outputs.principalIds
output clientIds array = identityModule.outputs.clientIds
