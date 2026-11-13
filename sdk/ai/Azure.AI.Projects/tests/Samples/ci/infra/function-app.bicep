targetScope = 'resourceGroup'

@description('Region of the existing storage account and shared Function identity.')
@minLength(1)
param location string

@minLength(2)
@maxLength(60)
param functionAppName string

@description('Linux Elastic Premium plan name, stable across redeployments.')
param planName string = 'plan-${uniqueString(resourceGroup().id, functionAppName)}'

@allowed([
  'EP1'
  'EP2'
  'EP3'
])
param planSku string = 'EP1'

@description('Python runtime version used by the separately deployed function code.')
@minLength(1)
param runtimeVersion string = '3.11'

@description('Existing storage account in this resource group. Shared-key access is not required.')
@minLength(3)
@maxLength(24)
param storageAccountName string

@description('Full resource ID of the existing Function UAMI with preconfigured storage permissions. No IAM grants are created.')
@minLength(1)
param sharedFunctionIdentityResourceId string

@minLength(3)
@maxLength(63)
param inputQueueName string = 'weather-input-queue'

@minLength(3)
@maxLength(63)
param outputQueueName string = 'weather-output-queue'

var identityParts = split(sharedFunctionIdentityResourceId, '/')

resource identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' existing = {
  scope: resourceGroup(identityParts[2], identityParts[4])
  name: identityParts[8]
}

resource storage 'Microsoft.Storage/storageAccounts@2023-05-01' existing = {
  name: storageAccountName
}

resource queueService 'Microsoft.Storage/storageAccounts/queueServices@2023-05-01' existing = {
  parent: storage
  name: 'default'
}

resource queues 'Microsoft.Storage/storageAccounts/queueServices/queues@2023-05-01' = [for queueName in union([inputQueueName, outputQueueName], []): {
  parent: queueService
  name: queueName
}]

var queueEndpoint = storage.properties.primaryEndpoints.queue
var queueServiceUri = endsWith(queueEndpoint, '/') ? substring(queueEndpoint, 0, max(0, length(queueEndpoint) - 1)) : queueEndpoint

resource plan 'Microsoft.Web/serverfarms@2023-12-01' = {
  name: planName
  location: location
  kind: 'linux'
  sku: {
    name: planSku
    tier: 'ElasticPremium'
  }
  properties: {
    reserved: true
  }
}

resource functionApp 'Microsoft.Web/sites@2023-12-01' = {
  name: functionAppName
  location: location
  kind: 'functionapp,linux'
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${sharedFunctionIdentityResourceId}': {}
    }
  }
  properties: {
    serverFarmId: plan.id
    httpsOnly: true
    reserved: true
    keyVaultReferenceIdentity: sharedFunctionIdentityResourceId
    siteConfig: {
      linuxFxVersion: 'Python|${runtimeVersion}'
      minTlsVersion: '1.2'
      ftpsState: 'Disabled'
      http20Enabled: true
      alwaysOn: true
    }
  }
}

resource appSettings 'Microsoft.Web/sites/config@2023-12-01' = {
  parent: functionApp
  name: 'appsettings'
  properties: {
    AzureWebJobsStorage__accountName: storage.name
    AzureWebJobsStorage__credential: 'managedidentity'
    AzureWebJobsStorage__clientId: identity.properties.clientId
    FUNCTIONS_EXTENSION_VERSION: '~4'
    FUNCTIONS_WORKER_RUNTIME: 'python'
    SCM_DO_BUILD_DURING_DEPLOYMENT: 'true'
    ENABLE_ORYX_BUILD: 'true'
    STORAGE_INPUT_QUEUE_NAME: inputQueueName
    STORAGE_OUTPUT_QUEUE_NAME: outputQueueName
    STORAGE_CONNECTION__queueServiceUri: queueServiceUri
    STORAGE_CONNECTION__credential: 'managedidentity'
    STORAGE_CONNECTION__clientId: identity.properties.clientId
  }
}

output functionAppResourceId string = functionApp.id
output environment object = {
  FUNCTION_APP_NAME: functionApp.name
  FUNCTION_APP_URL: 'https://${functionApp.properties.defaultHostName}'
  STORAGE_INPUT_QUEUE_NAME: inputQueueName
  STORAGE_OUTPUT_QUEUE_NAME: outputQueueName
  STORAGE_QUEUE_SERVICE_ENDPOINT: queueServiceUri
}