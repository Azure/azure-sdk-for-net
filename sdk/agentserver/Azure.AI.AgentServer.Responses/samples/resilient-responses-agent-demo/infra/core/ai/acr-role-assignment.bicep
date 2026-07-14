targetScope = 'resourceGroup'

@description('Name of the existing container registry')
param acrName string

@description('Principal ID to grant AcrPull role')
param principalId string

@description('Full resource ID of the ACR (for generating unique GUID)')
param acrResourceId string

// Reference the existing ACR in this resource group
resource acr 'Microsoft.ContainerRegistry/registries@2023-07-01' existing = {
  name: acrName
}

// Grant AcrPull role to the AI project's managed identity
resource acrPullRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: acr
  name: guid(acrResourceId, principalId, '7f951dda-4ed3-4680-a7ca-43fe172d538d')
  properties: {
    principalId: principalId
    principalType: 'ServicePrincipal'
    // AcrPull role
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d')
  }
}
