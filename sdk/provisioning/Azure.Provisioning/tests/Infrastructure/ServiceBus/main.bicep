targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource serviceBusNamespace_ZWLWzEXEq 'Microsoft.ServiceBus/namespaces@2021-11-01' = {
  name: toLower(take('sb${uniqueString(resourceGroup().id)}', 24))
  location: location
  sku: {
    name: 'Standard'
  }
  properties: {
  }
}

resource serviceBusQueue_rtLJIsxUz 'Microsoft.ServiceBus/namespaces/queues@2021-11-01' = {
  parent: serviceBusNamespace_ZWLWzEXEq
  name: 'queue'
  location: location
  properties: {
  }
}

resource serviceBusTopic_m8h7YH1KX 'Microsoft.ServiceBus/namespaces/topics@2021-11-01' = {
  parent: serviceBusNamespace_ZWLWzEXEq
  name: 'topic'
  location: location
  properties: {
  }
}

resource serviceBusSubscription_GrzC8nWoc 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' = {
  parent: serviceBusTopic_m8h7YH1KX
  name: 'subscription'
  location: location
  properties: {
  }
}

resource roleAssignment_ocuHD619b 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: serviceBusNamespace_ZWLWzEXEq
  name: guid(serviceBusNamespace_ZWLWzEXEq.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

output endpoint string = 'Endpoint=${serviceBusNamespace_ZWLWzEXEq.properties.serviceBusEndpoint}'
output expression string = uniqueString(serviceBusNamespace_ZWLWzEXEq.properties.serviceBusEndpoint)
