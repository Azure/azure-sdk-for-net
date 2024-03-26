targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource serviceBusNamespace_VkKO9fgDH 'Microsoft.ServiceBus/namespaces@2021-11-01' = {
  name: toLower(take(concat('sb', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Standard'
  }
  properties: {
  }
}

resource serviceBusQueue_uYoIiE5UI 'Microsoft.ServiceBus/namespaces/queues@2021-11-01' = {
  parent: serviceBusNamespace_VkKO9fgDH
  name: 'queue'
  location: location
  properties: {
  }
}

resource serviceBusTopic_tFhNONTR4 'Microsoft.ServiceBus/namespaces/topics@2021-11-01' = {
  parent: serviceBusNamespace_VkKO9fgDH
  name: 'topic'
  location: location
  properties: {
  }
}

resource serviceBusSubscription_7i3B7P44X 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' = {
  parent: serviceBusTopic_tFhNONTR4
  name: 'subscription'
  location: location
  properties: {
  }
}

resource roleAssignment_hjlGLL4Xr 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: serviceBusNamespace_VkKO9fgDH
  name: guid(serviceBusNamespace_VkKO9fgDH.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

output endpoint string = 'Endpoint=${serviceBusNamespace_VkKO9fgDH.properties.serviceBusEndpoint}'
output expression string = uniqueString(serviceBusNamespace_VkKO9fgDH.properties.serviceBusEndpoint)
