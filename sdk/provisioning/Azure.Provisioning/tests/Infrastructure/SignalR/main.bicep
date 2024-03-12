targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource signalR_MEdeBSjcP 'Microsoft.SignalRService/signalR@2020-06-01' = {
  name: toLower(take(concat('signalr', uniqueString(resourceGroup().id)), 24))
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

resource roleAssignment_Z6HaRqa0D 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: signalR_MEdeBSjcP
  name: guid(signalR_MEdeBSjcP.id, '00000000-0000-0000-0000-000000000000', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '420fcaa2-552c-430f-98ca-3264be4806c7'))
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '420fcaa2-552c-430f-98ca-3264be4806c7')
    principalId: '00000000-0000-0000-0000-000000000000'
    principalType: 'ServicePrincipal'
  }
}

output hostName string = signalR_MEdeBSjcP.properties.hostName
