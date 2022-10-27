@description('The maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk for being hung.')
param perTestExecutionLimitMinutes string = '15'

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The location of the resource group.')
param location string = resourceGroup().location

var namespaceName = resourceGroup().name
var defaultSASKeyName = 'RootManageSharedAccessKey'
var serviceBusAuthRuleResourceId = resourceId('Microsoft.ServiceBus/namespaces/authorizationRules', namespaceName, defaultSASKeyName)

var queueName = 'stresstestsb'

// Event Hubs Namespace Creation
resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2022-01-01-preview' = {
  name: namespaceName
  location: location
  sku: {
    name: 'Standard'
  }
  properties: {}
}

resource serviceBusQueue 'Microsoft.ServiceBus/namespaces/queues@2022-01-01-preview' = {
  parent: serviceBusNamespace
  name: queueName
}

resource eventHubsNamespace 'Microsoft.EventHub/Namespaces@2015-08-01' = {
  name: namespaceName
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
}

// Shared Resource output
output AZURE_CLIENT_OID string = testApplicationOid
output RESOURCE_GROUP string = resourceGroup().name
output EVENTHUB_PER_TEST_LIMIT_MINUTES string = perTestExecutionLimitMinutes
output EVENTHUB_NAMESPACE_CONNECTION_STRING string = listkeys(serviceBusAuthRuleResourceId, '2015-08-01').primaryConnectionString

// Outputs for the SendReceive scenario
output SERVICEBUS_QUEUE_SENDRECEIVE string = serviceBusQueue.name
