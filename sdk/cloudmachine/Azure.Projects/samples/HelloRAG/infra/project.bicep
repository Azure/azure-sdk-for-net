@description('The location for the resource(s) to be deployed.')
param location string = resourceGroup().location

@description('The objectId of the current user principal.')
param principalId string

resource project_identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: 'cmbb6fd4658c1340c'
  location: location
}

resource openai 'Microsoft.CognitiveServices/accounts@2024-10-01' = {
  name: 'cmbb6fd4658c1340c'
  location: location
  kind: 'OpenAI'
  properties: {
    customSubDomainName: 'cmbb6fd4658c1340c'
    publicNetworkAccess: 'Enabled'
  }
  sku: {
    name: 'S0'
  }
}

resource openai_1_CognitiveServicesOpenAIContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('openai', 'cmbb6fd4658c1340c', principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442'))
  properties: {
    principalId: principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442')
    principalType: 'User'
  }
  scope: openai
}

resource openai_project_identity_CognitiveServicesOpenAIContributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid('openai', project_identity.id, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442'))
  properties: {
    principalId: project_identity.properties.principalId
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a001fd3d-188f-4b5d-821b-7da978bf7442')
    principalType: 'ServicePrincipal'
  }
  scope: openai
}

resource openai_cmbb6fd4658c1340c_chat 'Microsoft.CognitiveServices/accounts/deployments@2024-06-01-preview' = {
  name: 'cmbb6fd4658c1340c_chat'
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

resource openai_cmbb6fd4658c1340c_embedding 'Microsoft.CognitiveServices/accounts/deployments@2024-06-01-preview' = {
  name: 'cmbb6fd4658c1340c_embedding'
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
    openai_cmbb6fd4658c1340c_chat
  ]
}

output project_identity_id string = project_identity.id