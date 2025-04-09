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

resource openai 'Microsoft.CognitiveServices/accounts@2024-10-01' = {
  name: 'cm0c420d2f21084cd'
  location: location
  kind: 'OpenAI'
  properties: {
    customSubDomainName: 'cm0c420d2f21084cd'
    publicNetworkAccess: 'Enabled'
  }
  sku: {
    name: 'S0'
  }
}

resource openai_admin_CognitiveServicesOpenAIContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('openai', 'cm0c420d2f21084cd', principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442')
    principalType: 'User'
  }
  scope: openai
}

resource openai_projectIdentity_CognitiveServicesOpenAIContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('openai', projectIdentity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442'))
  properties: {
    principalId: projectIdentity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442')
    principalType: 'ServicePrincipal'
  }
  scope: openai
}

resource openai_chat 'Microsoft.CognitiveServices/accounts/deployments@2024-06-01-preview' = {
  name: 'cm0c420d2f21084cd_chat'
  properties: {
    model: {
      format: 'OpenAI'
      name: 'gpt-35-turbo'
      version: '0125'
    }
    raiPolicyName: 'Microsoft.DefaultV2'
    versionUpgradeOption: 'OnceNewDefaultVersionAvailable'
  }
  sku: {
    name: 'Standard'
    capacity: 10
  }
  parent: openai
}

resource openai_embedding 'Microsoft.CognitiveServices/accounts/deployments@2024-06-01-preview' = {
  name: 'cm0c420d2f21084cd_embedding'
  properties: {
    model: {
      format: 'OpenAI'
      name: 'text-embedding-ada-002'
      version: '2'
    }
    raiPolicyName: 'Microsoft.DefaultV2'
    versionUpgradeOption: 'OnceNewDefaultVersionAvailable'
  }
  sku: {
    name: 'Standard'
    capacity: 10
  }
  parent: openai
  dependsOn: [
    openai_chat
  ]
}

resource projectConnection 'Microsoft.AppConfiguration/configurationStores/keyValues@2024-05-01' = {
  name: 'Azure.Data.AppConfiguration.ConfigurationClient'
  properties: {
    value: 'https://cm0c420d2f21084cd.azconfig.io'
  }
  parent: appConfiguration
}

resource projectConnection2 'Microsoft.AppConfiguration/configurationStores/keyValues@2024-05-01' = {
  name: 'Azure.AI.OpenAI.AzureOpenAIClient'
  properties: {
    value: 'https://cm0c420d2f21084cd.openai.azure.com'
  }
  parent: appConfiguration
}

resource projectConnection3 'Microsoft.AppConfiguration/configurationStores/keyValues@2024-05-01' = {
  name: 'OpenAI.Chat.ChatClient'
  properties: {
    value: 'cm0c420d2f21084cd_chat'
  }
  parent: appConfiguration
}

resource projectConnection4 'Microsoft.AppConfiguration/configurationStores/keyValues@2024-05-01' = {
  name: 'OpenAI.Embeddings.EmbeddingClient'
  properties: {
    value: 'cm0c420d2f21084cd_embedding'
  }
  parent: appConfiguration
}

output project_identity_id string = projectIdentity.id