targetScope = 'resourceGroup'

param location string
param identities array
param tags object

resource managedIdentities 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = [for identity in identities: {
  name: identity.name
  location: location
  tags: union(tags, { 'sample-ci-identity': identity.target })
}]

output names array = [for (identity, i) in identities: managedIdentities[i].name]
output principalIds array = [for (identity, i) in identities: managedIdentities[i].properties.principalId]
output clientIds array = [for (identity, i) in identities: managedIdentities[i].properties.clientId]
