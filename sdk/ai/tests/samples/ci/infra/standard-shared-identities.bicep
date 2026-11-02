// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

// Reviewed local variant of microsoft-foundry/foundry-samples at
// fbbe89b701c758e871922adaceea0ac0e4dae40f:
// infrastructure/infrastructure-setup-bicep/43-standard-agent-setup-with-customization.
// Keep the 14 hash-pinned official sources unchanged and compile them separately.
// This MCP-only variant creates fresh dependencies, attaches pre-existing shared
// identities, and relies on the six project service roles pregranted by bootstrap.
// The pipeline's Foundry User grant is also bootstrap-owned. No ARM IAM writes,
// new identities, Application Insights, Function integration, or models belong here.

targetScope = 'resourceGroup'

@description('Region bound to the selected shared MI set and verified by live preflight; no regional fallback.')
@minLength(1)
param location string

@description('Foundry account prefix, followed by the pinned four-character suffix.')
@minLength(1)
@maxLength(9)
param accountPrefix string = 'foundy'

@description('Foundry project prefix, followed by the same four-character suffix.')
@minLength(1)
param projectPrefix string = 'project'

@description('Explicit run timestamp, preserved on retry. Never generate a new value inside this template.')
@minLength(1)
param deploymentTimestamp string

@description('Full resource ID of the existing, bootstrap-owned project UAMI. The caller must verify its binding to sharedProjectPrincipalId.')
@minLength(1)
param sharedProjectIdentityResourceId string

@description('Full resource ID of the existing, bootstrap-owned Foundry account UAMI.')
@minLength(1)
param sharedAccountIdentityResourceId string

@description('Full resource ID of the existing, bootstrap-owned Search UAMI.')
@minLength(1)
param sharedSearchIdentityResourceId string

@description('Nonzero project UAMI OBJECT/principal GUID in canonical 8-4-4-4-12 form, not its client/application ID.')
@minLength(36)
@maxLength(36)
param sharedProjectPrincipalId string

// Bicep has no regex parameter decorator. Check every GUID position, then make
// malformed or zero GUIDs fail expression evaluation rather than reach a grant.
var invalidPrincipalPositions = filter(range(0, 36), position => contains([8, 13, 18, 23], position)
  ? substring(sharedProjectPrincipalId, position, 1) != '-'
  : !contains('0123456789abcdef', toLower(substring(sharedProjectPrincipalId, position, 1))))
var principalValidationIndex = length(invalidPrincipalPositions) + (sharedProjectPrincipalId == '00000000-0000-0000-0000-000000000000' ? 1 : 0)
var validatedProjectPrincipalId = [sharedProjectPrincipalId][principalValidationIndex]

// Preserve the official uniqueString seed, suffix length, and dependent names.
var uniqueSuffix = substring(uniqueString('${resourceGroup().id}-${deploymentTimestamp}'), 0, 4)
var accountName = toLower('${accountPrefix}${uniqueSuffix}')
var projectName = toLower('${projectPrefix}${uniqueSuffix}')
var cosmosDBName = toLower('${uniqueSuffix}cosmosdb')
var aiSearchName = toLower('${uniqueSuffix}search')
var azureStorageName = toLower('${uniqueSuffix}storage')

resource storage 'Microsoft.Storage/storageAccounts@2023-05-01' = {
  name: azureStorageName
  location: location
  kind: 'StorageV2'
  sku: {
    name: 'Standard_ZRS'
  }
  properties: {
    minimumTlsVersion: 'TLS1_2'
    allowBlobPublicAccess: false
    publicNetworkAccess: 'Enabled'
    networkAcls: {
      bypass: 'AzureServices'
      defaultAction: 'Allow'
      virtualNetworkRules: []
    }
    allowSharedKeyAccess: false
  }
}

resource aiSearch 'Microsoft.Search/searchServices@2024-06-01-preview' = {
  name: aiSearchName
  location: location
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${sharedSearchIdentityResourceId}': {}
    }
  }
  sku: {
    name: 'standard'
  }
  properties: {
    disableLocalAuth: false
    authOptions: {
      aadOrApiKey: {
        aadAuthFailureMode: 'http401WithBearerChallenge'
      }
    }
    encryptionWithCmk: {
      enforcement: 'Unspecified'
    }
    hostingMode: 'default'
    partitionCount: 1
    publicNetworkAccess: 'enabled'
    replicaCount: 1
    semanticSearch: 'disabled'
  }
}

resource cosmosDB 'Microsoft.DocumentDB/databaseAccounts@2024-11-15' = {
  name: cosmosDBName
  location: location
  kind: 'GlobalDocumentDB'
  properties: {
    consistencyPolicy: {
      defaultConsistencyLevel: 'Session'
    }
    disableLocalAuth: true
    enableAutomaticFailover: false
    enableMultipleWriteLocations: false
    enableFreeTier: false
    publicNetworkAccess: 'Enabled'
    locations: [
      {
        locationName: location
        failoverPriority: 0
        isZoneRedundant: false
      }
    ]
    databaseAccountOfferType: 'Standard'
  }
}

resource account 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' = {
  name: accountName
  location: location
  sku: {
    name: 'S0'
  }
  kind: 'AIServices'
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${sharedAccountIdentityResourceId}': {}
    }
  }
  properties: {
    allowProjectManagement: true
    customSubDomainName: accountName
    networkAcls: {
      defaultAction: 'Allow'
      virtualNetworkRules: []
      ipRules: []
    }
    publicNetworkAccess: 'Enabled'
    disableLocalAuth: false
  }
  dependsOn: [
    storage
    aiSearch
    cosmosDB
  ]
}

resource project 'Microsoft.CognitiveServices/accounts/projects@2025-04-01-preview' = {
  parent: account
  name: projectName
  location: location
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${sharedProjectIdentityResourceId}': {}
    }
  }
  properties: {
    description: 'some description'
    displayName: 'project'
  }
}

resource cosmosConnection 'Microsoft.CognitiveServices/accounts/projects/connections@2025-04-01-preview' = {
  parent: project
  name: cosmosDB.name
  properties: {
    category: 'CosmosDB'
    target: cosmosDB.properties.documentEndpoint
    authType: 'AAD'
    metadata: {
      ApiType: 'Azure'
      ResourceId: cosmosDB.id
      location: cosmosDB.location
    }
  }
}

resource storageConnection 'Microsoft.CognitiveServices/accounts/projects/connections@2025-04-01-preview' = {
  parent: project
  name: storage.name
  properties: {
    category: 'AzureStorageAccount'
    target: storage.properties.primaryEndpoints.blob
    authType: 'AAD'
    metadata: {
      ApiType: 'Azure'
      ResourceId: storage.id
      location: storage.location
    }
  }
}

resource searchConnection 'Microsoft.CognitiveServices/accounts/projects/connections@2025-04-01-preview' = {
  parent: project
  name: aiSearch.name
  properties: {
    category: 'CognitiveSearch'
    target: 'https://${aiSearch.name}.search.windows.net'
    authType: 'AAD'
    metadata: {
      ApiType: 'Azure'
      ResourceId: aiSearch.id
      location: aiSearch.location
    }
  }
}

resource accountCapabilityHost 'Microsoft.CognitiveServices/accounts/capabilityHosts@2025-04-01-preview' = {
  parent: account
  name: 'caphostacc'
  properties: {
    capabilityHostKind: 'Agents'
  }
  // The official capability-host module starts only after project connections exist.
  dependsOn: [
    cosmosConnection
    storageConnection
    searchConnection
  ]
}

resource projectCapabilityHost 'Microsoft.CognitiveServices/accounts/projects/capabilityHosts@2025-04-01-preview' = {
  parent: project
  name: 'caphostproj'
  properties: {
    // Preserve the pinned service property omitted by the bundled project schema.
    #disable-next-line BCP037
    capabilityHostKind: 'Agents'
    vectorStoreConnections: [
      searchConnection.name
    ]
    storageConnections: [
      storageConnection.name
    ]
    threadStorageConnections: [
      cosmosConnection.name
    ]
  }
  dependsOn: [
    // This parent host already waits for all three project connections.
    accountCapabilityHost
  ]
}

var cosmosDataContributorRoleDefinitionId = '${cosmosDB.id}/sqlRoleDefinitions/00000000-0000-0000-0000-000000000002'

// Cosmos native data-plane RBAC is not Microsoft.Authorization/roleAssignments.
// Retain this per-new-account grant after the capability host creates enterprise_memory.
// project.id supplies the stable GUID seed without the undocumented internalId property.
resource cosmosDataContributor 'Microsoft.DocumentDB/databaseAccounts/sqlRoleAssignments@2022-05-15' = {
  parent: cosmosDB
  name: guid(project.id, cosmosDB.name, cosmosDataContributorRoleDefinitionId, validatedProjectPrincipalId)
  properties: {
    principalId: validatedProjectPrincipalId
    roleDefinitionId: cosmosDataContributorRoleDefinitionId
    scope: '${cosmosDB.id}/dbs/enterprise_memory'
  }
  dependsOn: [
    projectCapabilityHost
  ]
}

output accountName string = account.name
output projectName string = project.name
output projectResourceId string = project.id
output projectEndpoint string = 'https://${account.name}.services.ai.azure.com/api/projects/${project.name}'
output projectIdentityResourceId string = sharedProjectIdentityResourceId
output projectPrincipalId string = validatedProjectPrincipalId
