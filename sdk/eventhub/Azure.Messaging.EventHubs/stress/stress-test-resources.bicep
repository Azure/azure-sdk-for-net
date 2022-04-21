@description('The url suffix to use when creating storage connection strings.')
param storageEndpointSuffix string = environment().suffixes.storage

@description('The maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk for being hung.')
param perTestExecutionLimitMinutes string = '15'

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The location of the resource group.')
param location string = resourceGroup().location

var eventHubsNamespace_var = 'eh-${resourceGroup().name}'
var defaultSASKeyName = 'RootManageSharedAccessKey'
var eventHubsAuthRuleResourceId = resourceId('Microsoft.EventHub/namespaces/authorizationRules', eventHubsNamespace_var, defaultSASKeyName)

var ehBufferedProducer = 'bufferedproducertest'
var bufferproducerPartitions = 10

var ehEventProducer = 'eventproducertest'
var eventProducerPartitions = 10

var ehBurstBufferedProducer = 'burstbufferedproducertest'

var ehConcurrentBufferedProducer = 'concurrentbufferedproducertest'

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
resource eventHubBufferedProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehBufferedProducer
  properties: {
    messageRetentionInDays: 7
    partitionCount: bufferproducerPartitions
  }
}

resource eventHubEventProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehEventProducer
  properties: {
    messageRetentionInDays: 7
    partitionCount: eventProducerPartitions
  }
}

resource eventHubBurstBufferedProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehBurstBufferedProducer
  properties: {
    messageRetentionInDays: 7
    partitionCount: bufferproducerPartitions
  }
}

resource eventHubConcurrentBufferedProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: ehConcurrentBufferedProducer
  properties: {
    messageRetentionInDays: 7
    partitionCount: bufferproducerPartitions
  }
}

// Shared Resource output
output AZURE_CLIENT_OID string = testApplicationOid
output RESOURCE_GROUP string = resourceGroup().name
output EVENTHUB_STORAGE_ENDPOINT_SUFFIX string = storageEndpointSuffix
output EVENTHUB_PER_TEST_LIMIT_MINUTES string = perTestExecutionLimitMinutes
output EVENTHUB_NAMESPACE_CONNECTION_STRING string = listkeys(eventHubsAuthRuleResourceId, '2015-08-01').primaryConnectionString

// Outputs for the BufferedProducerTest scenario
output EVENTHUB_NAME_EBPT string = eventHubBufferedProducer.name
output EVENTHUB_PARTITIONS_EBPT int = bufferproducerPartitions

// Outputs for the EventProducerTest
output EVENTHUB_NAME_EPT string = eventHubEventProducer.name
output EVENTHUB_PARTITIONS_EPT int = eventProducerPartitions

// Outputs for the BurstBufferedProducerTest scenario
output EVENTHUB_NAME_BBPT string = eventHubBurstBufferedProducer.name
output EVENTHUB_PARTITIONS_BBPT int = bufferproducerPartitions

// Outputs for the ConcurrentBufferedProducerTest scenario
output EVENTHUB_NAME_CBPT string = eventHubConcurrentBufferedProducer.name
output EVENTHUB_PARTITIONS_CBPT int = bufferproducerPartitions
