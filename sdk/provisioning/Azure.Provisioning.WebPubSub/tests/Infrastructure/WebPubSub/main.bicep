targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource webPubSubService_ODEiZdnLK 'Microsoft.SignalRService/webPubSub@2021-10-01' = {
  name: toLower(take('WebPubSub${uniqueString(resourceGroup().id)}', 24))
  location: location
  sku: {
    name: 'Standard_S1'
  }
  properties: {
  }
}

resource roleAssignment_Jjm5975dM 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: webPubSubService_ODEiZdnLK
  name: guid(webPubSubService_ODEiZdnLK.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '12cf5a90-567b-43ae-8102-96cf46c7d9b4'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '12cf5a90-567b-43ae-8102-96cf46c7d9b4')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

resource webPubSubHub_0m6lmClrJ 'Microsoft.SignalRService/webPubSub/hubs@2021-10-01' = {
  parent: webPubSubService_ODEiZdnLK
  name: 'Hub'
  properties: {
    eventHandlers: [
      {
        urlTemplate: 'tunnel:///eventhandler'
        userEventPattern: '*'
      }
    ]
  }
}

output hostName string = webPubSubService_ODEiZdnLK.properties.hostName
