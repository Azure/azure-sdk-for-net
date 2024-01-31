@description('The url suffix to use when creating storage connection strings.')
param storageEndpointSuffix string = environment().suffixes.storage

@description('The maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk for being hung.')
param perTestExecutionLimitMinutes string = '15'

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The location of the resource group.')
param location string = resourceGroup().location

var namespaceName = resourceGroup().name
var storageAccountName = 'storage${uniqueString(namespaceName)}'
var defaultSASKeyName = 'RootManageSharedAccessKey'
var eventHubsAuthRuleResourceId = resourceId('Microsoft.EventHub/namespaces/authorizationRules', namespaceName, defaultSASKeyName)

var eventHubName = 'stresstesteh'
var eventHubPartitions = 8

var processorTestName = 'processortest'

// Storage Account Creation
resource sa 'Microsoft.Storage/storageAccounts@2021-06-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
  }
}

var blobStorageConnectionString = 'DefaultEndpointsProtocol=https;AccountName=${sa.name};EndpointSuffix=${environment().suffixes.storage};AccountKey=${listKeys(sa.id, sa.apiVersion).keys[0].value}'

// Creating a storage blob for the processor test
resource processorContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-06-01' = {
  name: '${sa.name}/default/${processorTestName}'
}

// Event Hubs Namespace Creation
resource eventHubsNamespace 'Microsoft.EventHub/Namespaces@2015-08-01' = {
  name: namespaceName
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
}

// Event Hubs Creation
resource eventHub 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace
  name: eventHubName
  properties: {
    messageRetentionInDays: 7
    partitionCount: eventHubPartitions
  }
}

// Shared Resource output
output AZURE_CLIENT_OID string = testApplicationOid
output RESOURCE_GROUP string = resourceGroup().name
output EVENTHUB_STORAGE_ENDPOINT_SUFFIX string = storageEndpointSuffix
output EVENTHUB_PER_TEST_LIMIT_MINUTES string = perTestExecutionLimitMinutes
output EVENTHUB_NAMESPACE_CONNECTION_STRING string = listkeys(eventHubsAuthRuleResourceId, '2015-08-01').primaryConnectionString

// Outputs for the BufferedProducerTest scenario
output EVENTHUB_NAME_BUFFERED_PRODUCER_TEST string = eventHub.name

// Outputs for the EventProducerTest
output EVENTHUB_NAME_EVENT_PRODUCER_TEST string = eventHub.name

// Outputs for the BurstBufferedProducerTest scenario
output EVENTHUB_NAME_BURST_BUFFERED_PRODUCER_TEST string = eventHub.name

// Outputs for the ProcessorTest scenario
output EVENTHUB_NAME_PROCESSOR_TEST string = eventHub.name
output STORAGE_BLOB_PROCESSOR_TEST string = processorTestName
output STORAGE_ACCOUNT_PROCESSOR_TEST string = blobStorageConnectionString
