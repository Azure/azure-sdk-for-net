targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource eventHubsNamespace_LmeDkjUWO 'Microsoft.EventHub/namespaces@2021-11-01' = {
  name: toLower(take(concat('eh', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Standard'
  }
  properties: {
    minimumTlsVersion: '1.2'
  }
}

resource eventHub_ELtptvi1s 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
  parent: eventHubsNamespace_LmeDkjUWO
  name: 'hub'
  location: location
  properties: {
  }
}

resource eventHubsConsumerGroup_rQSsNNay3 'Microsoft.EventHub/namespaces/eventhubs/consumergroups@2021-11-01' = {
  parent: eventHub_ELtptvi1s
  name: 'cg'
  location: location
  properties: {
  }
}

resource roleAssignment_oj7e7rOUf 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: eventHubsNamespace_LmeDkjUWO
  name: guid(eventHubsNamespace_LmeDkjUWO.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'f526a384-b230-433a-b45c-95f59c4a2dec'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'f526a384-b230-433a-b45c-95f59c4a2dec')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}
