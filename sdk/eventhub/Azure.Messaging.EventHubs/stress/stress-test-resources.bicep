@description('The url suffix to use when creating storage connection strings.')
param storageEndpointSuffix string = environment().suffixes.storage

@description('The maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk for being hung.')
param perTestExecutionLimitMinutes string = '15'

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The location of the resource group.')
param location string = resourceGroup().location

var eventHubsNamespace_var = resourceGroup().name
var defaultSASKeyName = 'RootManageSharedAccessKey'
var eventHubsAuthRuleResourceId = resourceId('Microsoft.EventHub/namespaces/authorizationRules', eventHubsNamespace_var, defaultSASKeyName)

var bufferedProducerEventHubName = 'bufferedproducertest'
var bufferproducerEventHubPartitions = 10

var eventProducerEventHubName = 'eventproducertest'
var eventProducerEventHubPartitions = 10

var burstBufferedProducerEventHubName = 'burstbufferedproducertest'
var burstBufferedProducerEventHubPartitions = 10

var concurrentBufferedProducerEventHubName = 'concurrentbufferedproducertest'
var concurrentBufferedProducerEventHubPartitions = 10

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
  name: bufferedProducerEventHubName
  properties: {
    messageRetentionInDays: 7
    partitionCount: bufferproducerEventHubPartitions
  }
}

resource eventHubEventProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: eventProducerEventHubName
  properties: {
    messageRetentionInDays: 7
    partitionCount: eventProducerEventHubPartitions
  }
}

resource eventHubBurstBufferedProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: burstBufferedProducerEventHubName
  properties: {
    messageRetentionInDays: 7
    partitionCount: burstBufferedProducerEventHubPartitions
  }
}

resource eventHubConcurrentBufferedProducer 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: concurrentBufferedProducerEventHubName
  properties: {
    messageRetentionInDays: 7
    partitionCount: concurrentBufferedProducerEventHubPartitions
  }
}

// Shared Resource output
output AZURE_CLIENT_OID string = testApplicationOid
output RESOURCE_GROUP string = resourceGroup().name
output EVENTHUB_STORAGE_ENDPOINT_SUFFIX string = storageEndpointSuffix
output EVENTHUB_PER_TEST_LIMIT_MINUTES string = perTestExecutionLimitMinutes
output EVENTHUB_NAMESPACE_CONNECTION_STRING string = listkeys(eventHubsAuthRuleResourceId, '2015-08-01').primaryConnectionString

// Outputs for the BufferedProducerTest scenario
output EVENTHUB_NAME_BUFFERED_PRODUCER_TEST string = eventHubBufferedProducer.name

// Outputs for the EventProducerTest
output EVENTHUB_NAME_EVENT_PRODUCER_TEST string = eventHubEventProducer.name

// Outputs for the BurstBufferedProducerTest scenario
output EVENTHUB_NAME_BURST_BUFFERED_PRODUCER_TEST string = eventHubBurstBufferedProducer.name

// Outputs for the ConcurrentBufferedProducerTest scenario
output EVENTHUB_NAME_CONCURRENT_BUFFERED_PRODUCER_TEST string = eventHubConcurrentBufferedProducer.name
