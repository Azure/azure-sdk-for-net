// PARAMETERS
@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('The base resource name.')
param baseName string = resourceGroup().name

param testApplicationOid string

param keyVaultIsSoftDeleted bool = false

param storageAccountName string = uniqueString(baseName, 'storage')

var experimentationWorkspaceLocations = [
  'eastus2'
  'sweedencentral'
]

// The default location is typically westus, but Online Experimentation Workspaces are only available in a limited set of regions for now.
var experimentationWorkspaceLocation = contains(experimentationWorkspaceLocations, location) ? location : experimentationWorkspaceLocations[0]

// Create Azure Monitor resources: Log Analytics workspace, App Insights, Storage Account and Data Export Rule
resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: '${baseName}-loganalytics'
  location: location
  properties: any({
    retentionInDays: 30
    features: {
      searchVersion: 1
    }
    sku: {
      name: 'PerGB2018'
    }
  })

  // resource dataExportRule 'dataExports' = {
  //   name: 'AppEvents'
  //   properties: {
  //     destination: {
  //       resourceId: storageAccount.id
  //     }
  //     enable: true
  //     tableNames: [
  //       'AppEvents'
  //       'AppEvents_CL'
  //     ]
  //   }
  // }
}

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    allowSharedKeyAccess: false
  }
}

resource keyVault 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: '${baseName}-kv'
  location: location
  properties: {
    createMode: keyVaultIsSoftDeleted ? 'recover' : 'default'
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: subscription().tenantId
    enablePurgeProtection: true // required for CMK use
    enableSoftDelete: true // required for CMK use
    enableRbacAuthorization: true
  }

  resource onlineExperimentationWorkspaceKey 'keys' = {
    name: 'exp-workspace-key'
    properties: {
      keySize: 2048
      kty: 'RSA'
      keyOps: [ 'wrapKey', 'unwrapKey' ]
      attributes: {
        enabled: true
        exportable: false
      }
    }
  }
}

resource applicationInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: '${baseName}-appinsights'
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    WorkspaceResourceId: logAnalytics.id
  }
}

// Create App Configuration Store
resource appConfig 'Microsoft.AppConfiguration/configurationStores@2023-09-01-preview' = {
  name: '${baseName}-appconfig'
  location: location
  sku: {
    name: 'standard'
  }
  properties: {
    encryption: {}
    disableLocalAuth: true
    enablePurgeProtection: false
    experimentation:{}
    dataPlaneProxy:{
      authenticationMode: 'Pass-through'
      privateLinkDelegation: 'Disabled'
    }
    telemetry: {
      resourceId: applicationInsights.id
    }
  }
}

#disable-next-line BCP081
resource onlineExperimentationWorkspace 'Microsoft.OnlineExperimentation/workspaces@2025-05-31-preview' = {
  name: '${baseName}-exp'
  location: experimentationWorkspaceLocation
  sku: {
    name: 'S0'
  }
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    logAnalyticsWorkspaceResourceId: logAnalytics.id
    logsExporterStorageAccountResourceId: storageAccount.id
    appConfigurationResourceId: appConfig.id
  }
}

resource onlineExperimentationWorkspaceAssignments 'Microsoft.Authorization/roleAssignments@2022-04-01' = [for roleDefinitionId in [
  '2c7a01fe-5518-4a42-93c2-658e45441691' // Online Experimentation Contributor
  '53747cdd-e97c-477a-948c-b587d0e514b2' // Online Experimentation Data Owner
]: {
  name: guid(onlineExperimentationWorkspace.id, testApplicationOid, resourceId('Microsoft.Authorization/roleDefinitions', roleDefinitionId))
  scope: onlineExperimentationWorkspace
  properties: {
    principalId: testApplicationOid
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', roleDefinitionId)
  }
}]

module roleAssignments './test-resources-role-assignments.bicep' = {
  name: '${deployment().name}-ra'
  params: {
    principalId: onlineExperimentationWorkspace.identity.principalId
    keyVaultName: keyVault.name
    storageAccountName: storageAccount.name
    logAnalyticsName: logAnalytics.name
    appConfigName: appConfig.name
  }
}

output APPCONFIGURATION_RESOURCEID string = appConfig.id
output APPINSIGHTS_RESOURCEID string = applicationInsights.id
output LOGANALYTICS_RESOURCEID string = logAnalytics.id
output STORAGE_APPEVENTS_RESOURCEID string = storageAccount.id
output ONLINEEXPERIMENTATION_RESOURCEID string = onlineExperimentationWorkspace.id
output ONLINEEXPERIMENTATION_ENDPOINT string = onlineExperimentationWorkspace.properties.endpoint
output ONLINEEXPERIMENTATION_LOCATION string = experimentationWorkspaceLocation
output CUSTOMER_MANAGED_KEY_URI string = keyVault::onlineExperimentationWorkspaceKey.properties.keyUri
