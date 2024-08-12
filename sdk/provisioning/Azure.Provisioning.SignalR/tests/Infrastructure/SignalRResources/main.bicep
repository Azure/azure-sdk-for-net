targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource signalRService_TvD5y8AYq 'Microsoft.SignalRService/signalR@2022-02-01' = {
  name: toLower(take('signalr${uniqueString(resourceGroup().id)}', 24))
  location: location
  sku: {
    name: 'Standard_S1'
  }
  properties: {
    features: [
      {
        flag: 'ServiceMode'
        value: 'Serverless'
      }
    ]
    cors: {
      allowedOrigins: [
        '*'
      ]
    }
  }
}

resource roleAssignment_hFSNN5tl8 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: signalRService_TvD5y8AYq
  name: guid(signalRService_TvD5y8AYq.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '420fcaa2-552c-430f-98ca-3264be4806c7'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '420fcaa2-552c-430f-98ca-3264be4806c7')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

output hostName string = signalRService_TvD5y8AYq.properties.hostName
