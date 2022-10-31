@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The location of the resource group.')
param location string = resourceGroup().location

var servicebusNamespaceName = resourceGroup().name
var defaultSASKeyName = 'RootManageSharedAccessKey'
var serviceBusAuthRuleResourceId = resourceId('Microsoft.ServiceBus/namespaces/authorizationRules', servicebusNamespaceName, defaultSASKeyName)

var queueName = 'stresstestsb'

// Event Hubs Namespace Creation
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

// Shared Resource output
output AZURE_CLIENT_OID string = testApplicationOid
output RESOURCE_GROUP string = resourceGroup().name
output SERVICEBUS_NAMESPACE_CONNECTION_STRING string = listkeys(serviceBusAuthRuleResourceId, '2015-08-01').primaryConnectionString

// Outputs for the SendReceive scenario
output SERVICEBUS_QUEUE_SENDRECEIVE string = serviceBusQueue.name
