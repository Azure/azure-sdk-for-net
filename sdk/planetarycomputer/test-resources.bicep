@minLength(6)
@maxLength(50)
@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

// Generate unique names based on baseName
var resourcePrefix = uniqueString(baseName, resourceGroup().id)
var storageAccountName = '${resourcePrefix}sa'
var identityName = '${resourcePrefix}mi'
var catalogName = '${resourcePrefix}gc'
var containerName = 'sample-container'

// Create storage account
resource storageAccount 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
    allowBlobPublicAccess: false
    allowSharedKeyAccess: false
    minimumTlsVersion: 'TLS1_2'
    publicNetworkAccess: 'SecuredByPerimeter'
  }
}

// Create blob service
resource blobService 'Microsoft.Storage/storageAccounts/blobServices@2023-01-01' = {
  name: 'default'
  parent: storageAccount
}

// Create container
resource container 'Microsoft.Storage/storageAccounts/blobServices/containers@2023-01-01' = {
  name: containerName
  parent: blobService
  properties: {
    publicAccess: 'None'
  }
}

// Create user-assigned managed identity
resource managedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: identityName
  location: location
}

// Assign Storage Blob Data Reader role to managed identity on storage account
resource storageBlobDataReaderRole 'Microsoft.Authorization/roleDefinitions@2022-04-01' existing = {
  scope: subscription()
  name: '2a2b9908-6ea1-4ae2-8e65-a410df84e7d1' // Storage Blob Data Reader
}

resource blobDataReaderRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(storageAccount.id, managedIdentity.id, storageBlobDataReaderRole.id)
  scope: storageAccount
  properties: {
    principalId: managedIdentity.properties.principalId
    roleDefinitionId: storageBlobDataReaderRole.id
    principalType: 'ServicePrincipal'
  }
}

// Create GeoCatalog with managed identity
resource geoCatalog 'Microsoft.Orbital/geoCatalogs@2024-01-31-preview' = {
  name: catalogName
  location: location
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${managedIdentity.id}': {}
    }
  }
  properties: {
    tier: 'Basic'
  }
}

// Outputs for test environment
output PLANETARYCOMPUTER_ENDPOINT string = geoCatalog.properties.catalogUri
output PLANETARYCOMPUTER_COLLECTION_ID string = 'naip-atl'
output PLANETARYCOMPUTER_ITEM_ID string = 'ga_m_3308421_se_16_060_20211114'
output PLANETARYCOMPUTER_INGESTION_CATALOG_URL string = 'https://raw.githubusercontent.com/chahibi/mpcpro-sample-datasets/refs/heads/main/datasets/planetary_computer/naip/atl/catalog.json'
output PLANETARYCOMPUTER_MANAGED_IDENTITY_OBJECT_ID string = managedIdentity.properties.principalId
output PLANETARYCOMPUTER_INGESTION_CONTAINER_URI string = '${storageAccount.properties.primaryEndpoints.blob}${containerName}'

// Additional outputs for reference
output PLANETARYCOMPUTER_MANAGED_IDENTITY_CLIENT_ID string = managedIdentity.properties.clientId
output PLANETARYCOMPUTER_STORAGE_ACCOUNT_NAME string = storageAccount.name
output PLANETARYCOMPUTER_CONTAINER_NAME string = containerName
