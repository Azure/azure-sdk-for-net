@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('Random string to generate storage account name.')
param utc string = utcNow()

@description('The base resource name.')
param baseName string = resourceGroup().name

resource baseName_resource 'Microsoft.Insights/components@2020-02-02-preview' = {
  name: baseName
  kind: 'other'
  location: location
  properties: {
    Application_Type: 'other'
    WorkspaceResourceId: primaryWorkspace.id
  }
}

resource primaryWorkspace 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: '${baseName}-logs'
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    features: {
      searchVersion: 1
      legacy: 0
      enableLogAccessUsingOnlyResourcePermissions: 'true'
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
}

resource secondaryWorkspace 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: '${baseName}-logs2'
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    features: {
      searchVersion: 1
      legacy: 0
      enableLogAccessUsingOnlyResourcePermissions: 'true'
    }
  }
}

var logReaderRoleId = '73c42c96-874c-492b-b04d-ab87d138a893'

resource logsReaderRole 'Microsoft.Authorization/roleAssignments@2018-01-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, logReaderRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', logReaderRoleId)
    principalId: testApplicationOid
  }
}

var metricPublisherRoleId = '3913510d-42f4-4e42-8a64-420c390055eb'

resource metricReaderRole 'Microsoft.Authorization/roleAssignments@2018-01-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, metricPublisherRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', metricPublisherRoleId)
    principalId: testApplicationOid
  }
}

resource table 'Microsoft.OperationalInsights/workspaces/tables@2022-10-01' = {
  name: tableName
  parent: primaryWorkspace
  properties:{
    totalRetentionInDays: 30
    plan: 'Analytics'
    schema: {
      name: tableName
      displayName: tableName
      description: 'Table for Ingestion testing'
      columns:[
        {
          name: 'TimeGenerated'
          type: 'dateTime'
          description: 'The time at which the data was generated'
        }
        {
          name: 'AdditionalContext'
          type: 'dynamic'
          description: 'Additional message properties'
        }
        {
          name: 'ExtendedColumn'
          type: 'string'
          description: 'An additional column extended at ingestion time'
        }
      ]
    }
  }
}

resource dataCollectionEndpoint 'Microsoft.Insights/dataCollectionEndpoints@2021-09-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, primaryWorkspace.id)
  location: location
  properties:{
    networkAcls:{
      publicNetworkAccess: 'Enabled'
    }
  }
}

var streamName = 'Custom-MyTableRawData'
var tableName = 'MyTable_CL'
resource dataCollectionRule 'Microsoft.Insights/dataCollectionRules@2021-09-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, dataCollectionEndpoint.id)
  location: location
  properties:{
    dataCollectionEndpointId: dataCollectionEndpoint.id
    streamDeclarations:{
      'Custom-MyTableRawData': {
        columns: [
          {
            name: 'Time'
            type: 'datetime'
          }
          {
            name: 'Computer'
            type: 'string'
          }
          {
            name: 'AdditionalContext'
            type: 'string'
          }
        ]
      }
    }
    destinations:{
      logAnalytics: [
        {
          name: primaryWorkspace.name
          workspaceResourceId: primaryWorkspace.id
        }
      ]
    }
    dataFlows: [
      {
        destinations: [
          primaryWorkspace.name
        ]
        outputStream: 'Custom-${tableName}'
        streams: [
          streamName
        ]
        transformKql: 'source | extend jsonContext = parse_json(AdditionalContext) | project TimeGenerated = Time, Computer, AdditionalContext = jsonContext, ExtendedColumn=tostring(jsonContext.CounterName)'
      }
    ]
  }
}

resource dataCollectionRuleRoleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, dataCollectionRule.name, dataCollectionRule.id)
  scope: primaryWorkspace
  properties:{
    principalId: testApplicationOid
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', metricPublisherRoleId)
  }
}

@description('The base resource name.')
param storageAccountName string = uniqueString(baseName, 'storage')
@description('The base resource name.')
param storageAccountsku string = 'Standard_LRS'

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-08-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: storageAccountsku
  }
  kind: 'StorageV2'
  tags: {
    ObjectName: storageAccountName
  }
  properties: {}
}

output CONNECTION_STRING string = baseName_resource.properties.ConnectionString
output APPLICATION_ID string = baseName_resource.properties.AppId
output WORKSPACE_ID string = primaryWorkspace.properties.customerId
output SECONDARY_WORKSPACE_ID string = secondaryWorkspace.properties.customerId
output WORKSPACE_KEY string = listKeys(primaryWorkspace.id, '2020-10-01').primarySharedKey
output SECONDARY_WORKSPACE_KEY string = listKeys(secondaryWorkspace.id, '2020-10-01').primarySharedKey
output METRICS_RESOURCE_ID string = primaryWorkspace.id
output METRICS_RESOURCE_NAMESPACE string = 'Microsoft.OperationalInsights/workspaces'
output LOGS_ENDPOINT string =  'https://api.loganalytics.io'
output MONITOR_INGESTION_DATA_COLLECTION_ENDPOINT string = dataCollectionEndpoint.properties.logsIngestion.endpoint
output INGESTION_STREAM_NAME string = streamName
output INGESTION_TABLE_NAME string = table.name
output INGESTION_DATA_COLLECTION_RULE_ID string = dataCollectionRule.id
output INGESTION_DATA_COLLECTION_RULE_IMMUTABLE_ID string = dataCollectionRule.properties.immutableId
output RESOURCE_ID string = resourceGroup().id
output WORKSPACE_PRIMARY_RESOURCE_ID string = primaryWorkspace.id
output WORKSPACE_SECONDARY_RESOURCE_ID string = secondaryWorkspace.id
output DATAPLANE_ENDPOINT string = 'https://${location}.metrics.monitor.azure.com'
output STORAGE_NAME string = storageAccount.name
output STORAGE_ID string = storageAccount.id
output STORAGE_CONNECTION_STRING string = 'DefaultEndpointsProtocol=https;AccountName=${storageAccountName};AccountKey=${listKeys(storageAccount.id, storageAccount.apiVersion).keys[0].value};EndpointSuffix=${environment().suffixes.storage}'
