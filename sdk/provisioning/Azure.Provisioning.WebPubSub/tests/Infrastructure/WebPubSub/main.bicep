targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource webPubSubService_EAdO6ICWi 'Microsoft.SignalRService/webPubSub@2021-10-01' = {
  name: toLower(take('webpubsub${uniqueString(resourceGroup().id)}', 24))
  location: location
  sku: {
    name: 'Standard_S1'
  }
  properties: {
  }
}

resource roleAssignment_eQVZzvRPP 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: webPubSubService_EAdO6ICWi
  name: guid(webPubSubService_EAdO6ICWi.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '12cf5a90-567b-43ae-8102-96cf46c7d9b4'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '12cf5a90-567b-43ae-8102-96cf46c7d9b4')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

resource webPubSubHub_tKhq1vFqb 'Microsoft.SignalRService/webPubSub/hubs@2021-10-01' = {
  parent: webPubSubService_EAdO6ICWi
  name: 'hub'
  properties: {
    eventHandlers: [
      {
        urlTemplate: 'tunnel:///eventhandler'
        userEventPattern: '*'
      }
    ]
  }
}

output hostName string = webPubSubService_EAdO6ICWi.properties.hostName
