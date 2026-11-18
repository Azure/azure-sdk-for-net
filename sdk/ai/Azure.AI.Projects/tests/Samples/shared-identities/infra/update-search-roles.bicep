// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// Administrator-only update for an existing permanent identity set, never a worker module.

targetScope = 'subscription'

@minLength(1)
param identityResourceGroupName string
@minLength(1)
param searchIdentityName string

resource searchIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' existing = {
  name: searchIdentityName
  scope: resourceGroup(identityResourceGroupName)
}

var configuration = loadJsonContent('./IdentityConfiguration.json')
var searchIdentityIndex = indexOf(map(configuration.managedIdentities, identity => identity.target), 'search')
var grants = filter(configuration.roleAssignments, grant => grant.target == 'search')

// Match the new-set bootstrap's GUID seeds so either entry point is idempotent.
resource roles 'Microsoft.Authorization/roleAssignments@2022-04-01' = [for grant in grants: {
  name: guid(subscription().id, identityResourceGroupName, string(searchIdentityIndex), grant.roleDefinitionId)
  properties: {
    principalId: searchIdentity.properties.principalId
    principalType: 'ServicePrincipal'
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', grant.roleDefinitionId)
  }
}]

output searchIdentityResourceId string = searchIdentity.id
