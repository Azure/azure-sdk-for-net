@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The location of the resource group.')
param location string = resourceGroup().location

var servicebusNamespaceName = resourceGroup().name
var defaultSASKeyName = 'RootManageSharedAccessKey'
var serviceBusAuthRuleResourceId = resourceId('Microsoft.ServiceBus/namespaces/authorizationRules', servicebusNamespaceName, defaultSASKeyName)

var queueName = 'stresstestsb-${uniqueString(resourceGroup().id)}'
var sessionQueueName = 'stresstestsbsess-${uniqueString(resourceGroup().id)}'

// Service Bus Namespace Creation
resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2022-01-01-preview' = {
  name: servicebusNamespaceName
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

resource serviceBusQueueWithSessions 'Microsoft.ServiceBus/namespaces/queues@2022-01-01-preview' = {
  parent: serviceBusNamespace
  name: sessionQueueName
  properties: {
    requiresSession: true
  }
}

// Shared Resource output
output STRESS_AZURE_CLIENT_OID string = testApplicationOid
output STRESS_RESOURCE_GROUP string = resourceGroup().name
output STRESS_SERVICEBUS_NAMESPACE_CONNECTION_STRING string = listkeys(serviceBusAuthRuleResourceId, '2015-08-01').primaryConnectionString

// Individual test outputs
output STRESS_SERVICEBUS_QUEUE string = serviceBusQueue.name
output STRESS_SERVICEBUS_SESSION_QUEUE string = serviceBusQueueWithSessions.name
