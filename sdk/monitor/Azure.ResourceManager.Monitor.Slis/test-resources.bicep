// test-resources.bicep for Microsoft.Monitor/slis live tests
// Provisions:
//   - Azure Monitor Workspace (destination for SLI metrics)
//   - User-Assigned Managed Identity (used by SLI signal sources)
//   - Role assignment for the test application SP

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The base resource name.')
param baseName string = resourceGroup().name

// Azure Monitor Workspace (destination AMW account for the SLI)
resource monitorWorkspace 'Microsoft.Monitor/accounts@2023-04-03' = {
  name: '${baseName}-amw'
  location: location
  properties: {}
}

// User-Assigned Managed Identity (used as signal source identity)
resource managedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: '${baseName}-sli-id'
  location: location
}

// Monitoring Reader role (43d0d8ad-25c7-4714-9337-8ba259a9fe05)
// Grants the test SP read access needed for SLI operations
var monitoringReaderRoleId = '43d0d8ad-25c7-4714-9337-8ba259a9fe05'

resource monitoringReaderAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, testApplicationOid, monitoringReaderRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', monitoringReaderRoleId)
    principalId: testApplicationOid
    principalType: 'ServicePrincipal'
  }
}

// Monitoring Contributor role (749f88d5-cbae-40b8-bcfc-e573ddc772fa)
// Grants the test SP write access for SLI CRUD operations
var monitoringContributorRoleId = '749f88d5-cbae-40b8-bcfc-e573ddc772fa'

resource monitoringContributorAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, testApplicationOid, monitoringContributorRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', monitoringContributorRoleId)
    principalId: testApplicationOid
    principalType: 'ServicePrincipal'
  }
}

// OUTPUTS - these become environment variables for the test runner
output AMW_RESOURCE_ID string = monitorWorkspace.id
output MANAGED_IDENTITY_RESOURCE_ID string = managedIdentity.id
output SOURCE_AMW_RESOURCE_ID string = monitorWorkspace.id
output SOURCE_MANAGED_IDENTITY_RESOURCE_ID string = managedIdentity.id
output SERVICE_GROUP_NAME string = 'testSG'

