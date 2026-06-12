// ============================================================================
// Azure Content Understanding SDK Test Resources
// ============================================================================
// This Bicep template creates the following Azure resources for testing:
//
// Resources Created:
//   1. Primary Microsoft Foundry resource (Microsoft.CognitiveServices/accounts)
//      - Primary resource for testing Content Understanding functionality
//      - Kind: AIServices, SKU: S0
//   2. Secondary Microsoft Foundry resource (Microsoft.CognitiveServices/accounts)
//      - Used as target for cross-resource copying operations (e.g., Sample15)
//      - Kind: AIServices, SKU: S0
//   3. Role assignments (Microsoft.Authorization/roleAssignments)
//      - Grants test application/service principal "Cognitive Services User" role
//      - One for primary resource, one for secondary resource
//   4. Model deployments (Microsoft.CognitiveServices/accounts/deployments)
//      - Deployed via test-resources-post.ps1 script after resource creation
//      - Creates deployments for: gpt-4.1, gpt-4.1-mini, text-embedding-3-large
//
// Environment Variables Generated (outputs):
//   Primary Resource:
//     - CONTENTUNDERSTANDING_ENDPOINT: Primary Foundry API endpoint
//
//   Primary Resource (used as source for cross-resource copy):
//     - CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID: Primary Foundry resource ID
//     - CONTENTUNDERSTANDING_SOURCE_REGION: Primary resource region
//
//   Secondary Resource (used as target for cross-resource copy):
//     - CONTENTUNDERSTANDING_TARGET_ENDPOINT: Secondary Foundry API endpoint
//     - CONTENTUNDERSTANDING_TARGET_RESOURCE_ID: Secondary Foundry resource ID
//     - CONTENTUNDERSTANDING_TARGET_REGION: Secondary resource region
//
//   Model Deployment Names:
//     - GPT_4_1_DEPLOYMENT: Deployment name for gpt-4.1 model
//     - GPT_4_1_MINI_DEPLOYMENT: Deployment name for gpt-4.1-mini model
//     - TEXT_EMBEDDING_3_LARGE_DEPLOYMENT: Deployment name for text-embedding-3-large model
//
// Authentication:
//   - Uses DefaultAzureCredential (no API keys needed)
//   - Role assignments grant access via "Cognitive Services User" role
// ============================================================================

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@minLength(6)
@maxLength(50)
@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

// Role definition ID for "Cognitive Services User" role
var cognitiveServicesUserRoleId = subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a97b65f3-24c7-4388-baec-2e87135dc908')

// Resource names
var testFoundryName = '${baseName}-foundry'
var targetFoundryName = '${baseName}-copy-target'

// Source Microsoft Foundry resource (primary resource for most tests)
resource sourceFoundry 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' = {
  name: testFoundryName
  location: location
  kind: 'AIServices'
  sku: {
    name: 'S0'
  }
  properties: {
    customSubDomainName: toLower(testFoundryName)
    publicNetworkAccess: 'Enabled'
  }
}

// Role assignment for source resource - grants test application access
// Note: principalType is omitted to allow Azure to infer it automatically (works for both User and ServicePrincipal)
resource sourceRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, sourceFoundry.id, cognitiveServicesUserRoleId)
  scope: sourceFoundry
  properties: {
    roleDefinitionId: cognitiveServicesUserRoleId
    principalId: testApplicationOid
  }
}

// Target Microsoft Foundry resource (for cross-resource copy tests, e.g., Sample15)
resource targetFoundry 'Microsoft.CognitiveServices/accounts@2025-04-01-preview' = {
  name: targetFoundryName
  location: location
  kind: 'AIServices'
  sku: {
    name: 'S0'
  }
  properties: {
    customSubDomainName: toLower(targetFoundryName)
    publicNetworkAccess: 'Enabled'
  }
}

// Role assignment for target resource - grants test application access
// Note: principalType is omitted to allow Azure to infer it automatically (works for both User and ServicePrincipal)
resource targetRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, targetFoundry.id, cognitiveServicesUserRoleId)
  scope: targetFoundry
  properties: {
    roleDefinitionId: cognitiveServicesUserRoleId
    principalId: testApplicationOid
  }
}

// Model deployments are handled by test-resources-post.ps1 script after resource creation.
// This allows models to be deployed even if they're not available during initial Bicep deployment.
// Deployments can take 5-15 minutes to complete.

// Outputs - these become environment variables for tests
// Variable names match what ContentUnderstandingClientTestEnvironment expects
// Note: We use DefaultAzureCredential for authentication, so API keys are not needed
// Role assignments grant the test application/service principal access via the 'Cognitive Services User' role
// Construct endpoint from variable (endpoint format: https://{customSubDomainName}.services.ai.azure.com/)
// Using toLower(testFoundryName) which matches the customSubDomainName set in the resource
output CONTENTUNDERSTANDING_ENDPOINT string = 'https://${toLower(testFoundryName)}.services.ai.azure.com/'

// Primary resource outputs (used as source for cross-resource copy)
output CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID string = sourceFoundry.id
output CONTENTUNDERSTANDING_SOURCE_REGION string = location

// Target resource outputs (for cross-resource copy)
// Construct endpoint from variable (endpoint format: https://{customSubDomainName}.services.ai.azure.com/)
// Using toLower(targetFoundryName) which matches the customSubDomainName set in the resource
output CONTENTUNDERSTANDING_TARGET_ENDPOINT string = 'https://${toLower(targetFoundryName)}.services.ai.azure.com/'
output CONTENTUNDERSTANDING_TARGET_RESOURCE_ID string = targetFoundry.id
output CONTENTUNDERSTANDING_TARGET_REGION string = location

// Model deployment outputs - deployment names for tests
// These match what ContentUnderstandingClientTestEnvironment expects
output GPT_4_1_DEPLOYMENT string = 'gpt-4.1'
output GPT_4_1_MINI_DEPLOYMENT string = 'gpt-4.1-mini'
output TEXT_EMBEDDING_3_LARGE_DEPLOYMENT string = 'text-embedding-3-large'

