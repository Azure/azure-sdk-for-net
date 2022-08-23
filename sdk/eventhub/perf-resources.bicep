param baseName string = resourceGroup().name
param location string = resourceGroup().location

var namespaceName = 'eh-${baseName}'
var eventHubsAuthRuleResourceId = resourceId('Microsoft.EventHub/namespaces/authorizationRules', namespaceName, 'RootManageSharedAccessKey')

resource eventHubNamespace 'Microsoft.EventHub/namespaces@2015-08-01' = {
  name: namespaceName
  location: location
  sku: {
    capacity: 40
    name: 'Standard'
    tier: 'Standard'
  }

  resource eventHub 'eventhubs' = {
    name: '32'
    properties: {
      partitionCount: 32
    }
  }
}

output EVENTHUB_NAMESPACE_CONNECTION_STRING string = listkeys(eventHubsAuthRuleResourceId, '2015-08-01').primaryConnectionString
