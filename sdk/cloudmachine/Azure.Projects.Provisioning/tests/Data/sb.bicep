@description('The location for the resource(s) to be deployed.')
param location string = resourceGroup().location

@description('The objectId of the current user principal.')
param principalId string

resource projectIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: 'cm0c420d2f21084cd'
  location: location
}

resource appConfiguration 'Microsoft.AppConfiguration/configurationStores@2024-05-01' = {
  name: 'cm0c420d2f21084cd'
  location: location
  sku: {
    name: 'Free'
  }
}

resource appConfiguration_admin_AppConfigurationDataOwner 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('appConfiguration', 'cm0c420d2f21084cd', principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b')
    principalType: 'User'
  }
  scope: appConfiguration
}

resource appConfiguration_projectIdentity_AppConfigurationDataOwner 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('appConfiguration', projectIdentity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b'))
  properties: {
    principalId: projectIdentity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b')
    principalType: 'ServicePrincipal'
  }
  scope: appConfiguration
}

resource cm_servicebus 'Microsoft.ServiceBus/namespaces@2024-01-01' = {
  name: 'cm0c420d2f21084cd'
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
}

resource cm_servicebus_admin_AzureServiceBusDataOwner 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('cm_servicebus', 'cm0c420d2f21084cd', principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419')
    principalType: 'User'
  }
  scope: cm_servicebus
}

resource cm_servicebus_projectIdentity_AzureServiceBusDataOwner 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('cm_servicebus', projectIdentity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419'))
  properties: {
    principalId: projectIdentity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '090c5cfd-751d-490a-894a-3ce6f1109419')
    principalType: 'ServicePrincipal'
  }
  scope: cm_servicebus
}

resource cm_servicebus_auth_rule 'Microsoft.ServiceBus/namespaces/AuthorizationRules@2021-11-01' = {
  name: take('cm_servicebus_auth_rule-${uniqueString(resourceGroup().id)}', 50)
  properties: {
    rights: [
      'Listen'
      'Send'
      'Manage'
    ]
  }
  parent: cm_servicebus
}

resource projectConnection 'Microsoft.AppConfiguration/configurationStores/keyValues@2024-05-01' = {
  name: 'Azure.Data.AppConfiguration.ConfigurationClient'
  properties: {
    value: 'https://cm0c420d2f21084cd.azconfig.io'
  }
  parent: appConfiguration
}

resource projectConnection2 'Microsoft.AppConfiguration/configurationStores/keyValues@2024-05-01' = {
  name: 'Azure.Messaging.ServiceBus.ServiceBusClient'
  properties: {
    value: 'https://cm0c420d2f21084cd.servicebus.windows.net/'
  }
  parent: appConfiguration
}

output project_identity_id string = projectIdentity.id