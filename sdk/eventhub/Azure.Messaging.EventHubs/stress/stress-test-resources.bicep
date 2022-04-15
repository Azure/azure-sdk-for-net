// @description('The subscription ID to which the application and resources belong.')
// param subscriptionId string = subscription().subscriptionId

// @description('The tenant ID to which the application and resources belong.')
// param tenantId string = subscription().tenantId

// @description('The application client ID used to run tests.')
// param testApplicationId string

// @description('The application client secret used to run tests.')
// param testApplicationSecret string

@description('The url suffix to use when creating storage connection strings.')
// param storageEndpointSuffix string = 'core.windows.net'
param storageEndpointSuffix string = environment().suffixes.storage

@description('The maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk for being hung.')
param perTestExecutionLimitMinutes string = '15'

@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The location of the resource group.')
param location string = resourceGroup().location

var contributorRoleId = 'b24988ac-6180-42a0-ab88-20f7382dd24c'
var eventHubsDataOwnerRoleId = 'f526a384-b230-433a-b45c-95f59c4a2dec'
var storageDataOwnerRoleId = 'b7e6dc6d-f1e8-4753-8033-0f276bb0955b'
var eventHubsNamespace_var = 'eh-${baseName}'
var storageAccount_var = 'blb${baseName}'
var defaultSASKeyName = 'RootManageSharedAccessKey'
var eventHubsAuthRuleResourceId = resourceId('Microsoft.EventHub/namespaces/authorizationRules', eventHubsNamespace_var, defaultSASKeyName)
var storageAccountId = storageAccount.id

var ehBasicProcessor = 'basiceventprocessortest'
var ehBasicPublish = 'basicpublishreadtest'
var ehBufferedProducer = 'bufferedproducertest'
var ehEmptyProcessor = 'processoremptyreadtest'
var ehEventProducer = 'eventproducertest'
var ehTransportProducer = 'transportproducerpooltest'

// Event Hubs Namespace Creation
resource eventHubsNamespace 'Microsoft.EventHub/Namespaces@2015-08-01' = {
  name: eventHubsNamespace_var
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
}

// Event Hubs Creation
resource eventHubBasicProcessor 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehBasicProcessor
  properties: {
    messageRetentionInDays: 7
    partitionCount: 1
  }
}

resource eventHubBasicPublish 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehBasicPublish
  properties: {
    messageRetentionInDays: 7
    partitionCount: 1
  }
}

resource eventHubBufferedProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehBufferedProducer
  properties: {
    messageRetentionInDays: 7
    partitionCount: 1
  }
}

resource eventHubEmptyProcessor 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehEmptyProcessor
  properties: {
    messageRetentionInDays: 7
    partitionCount: 1
  }
}

resource eventHubEventProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehEventProducer
  properties: {
    messageRetentionInDays: 7
    partitionCount: 1
  }
}

resource eventHubTransportProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehTransportProducer
  properties: {
    messageRetentionInDays: 7
    partitionCount: 1
  }
}


// Storage Account Creation
resource storageAccount 'Microsoft.Storage/storageAccounts@2019-04-01' = {
  name: storageAccount_var
  location: location
  sku: {
    name: 'Standard_LRS'
    // tier: 'Standard'
  }
  kind: 'BlobStorage'
  properties: {
    networkAcls: {
      bypass: 'AzureServices'
      virtualNetworkRules: []
      ipRules: []
      defaultAction: 'Allow'
    }
    supportsHttpsTrafficOnly: true
    encryption: {
      services: {
        file: {
          enabled: true
        }
        blob: {
          enabled: true
        }
      }
      keySource: 'Microsoft.Storage'
    }
    accessTier: 'Hot'
  }
}

resource storageAccount_default 'Microsoft.Storage/storageAccounts/blobServices@2019-04-01' = {
  parent: storageAccount
  name: 'default'
  properties: {
    cors: {
      corsRules: []
    }
    deleteRetentionPolicy: {
      enabled: false
    }
  }
}

// Creating Blob containers
resource basic_processor_blob 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-06-01' = {
  name: '${storageAccount.name}/default/${ehBasicProcessor}log'
}

resource empty_processor_blob 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-06-01' = {
  name: '${storageAccount.name}/default/${ehEmptyProcessor}log'
}
 
resource id_testApplicationOid_eventHubsDataOwnerRoleId 'Microsoft.Authorization/roleAssignments@2019-04-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, eventHubsDataOwnerRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', eventHubsDataOwnerRoleId)
    principalId: testApplicationOid
    scope: resourceGroup().id
  }
  dependsOn: [
    eventHubsNamespace
    storageAccount
  ]
}

resource id_testApplicationOid_contributorRoleId 'Microsoft.Authorization/roleAssignments@2019-04-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, contributorRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', contributorRoleId)
    principalId: testApplicationOid
    scope: resourceGroup().id
  }
  dependsOn: [
    eventHubsNamespace
    storageAccount
  ]
}

resource id_testApplicationOid_storageDataOwnerRoleId 'Microsoft.Authorization/roleAssignments@2019-04-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, storageDataOwnerRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', storageDataOwnerRoleId)
    principalId: testApplicationOid
    scope: resourceGroup().id
  }
  dependsOn: [
    eventHubsNamespace
    storageAccount
  ]
}

var blobStorageConnectionString = 'DefaultEndpointsProtocol=https;AccountName=${storageAccount_var};EndpointSuffix=${environment().suffixes.storage};AccountKey=${listKeys(storageAccount.id, storageAccount.apiVersion).keys[0].value}'

// Shared Resource output
output AZURE_CLIENT_OID string = testApplicationOid
output RESOURCE_GROUP string = resourceGroup().name
output EVENTHUB_STORAGE_ENDPOINT_SUFFIX string = storageEndpointSuffix
output EVENTHUB_PER_TEST_LIMIT_MINUTES string = perTestExecutionLimitMinutes
output EVENTHUB_NAMESPACE_CONNECTION_STRING string = listkeys(eventHubsAuthRuleResourceId, '2015-08-01').primaryConnectionString
output STORAGE_CONNECTION_STRING string = blobStorageConnectionString
output EVENTHUB_PROCESSOR_STORAGE_CONNECTION_STRING string = 'DefaultEndpointsProtocol=https;AccountName=${storageAccount_var};AccountKey=${listKeys(storageAccountId, providers('Microsoft.Storage', 'storageAccounts').apiVersions[0]).keys[0].value};EndpointSuffix=${storageEndpointSuffix}'


// Outputs for the BasicEventProcessorTest scenario
output EVENTHUB_NAME_BEPT string = eventHubBasicProcessor.name
output BLOB_CONTAINER_BEPT string = basic_processor_blob.name

// Outputs for the BasicPublishReadTest scenario
output EVENTHUB_NAME_BPRT string = eventHubBasicPublish.name

// Outputs for the BufferedProducerTest scenario
output EVENTHUB_NAME_BPT string = eventHubBufferedProducer.name

// Outputs for the EventProducerTest
output EVENTHUB_NAME_EPT string = eventHubEventProducer.name

// Outputs for the ProcessorEmptyReadTest scenario
output EVENTHUB_NAME_PERT string = eventHubEmptyProcessor.name 
output BLOB_CONTAINER_PERT string = empty_processor_blob.name

// Outputs for the TransportProducerPoolTest scenario
output EVENTHUB_NAME_TPPT string = eventHubTransportProducer.name
