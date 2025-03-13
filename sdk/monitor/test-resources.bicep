// PARAMETERS
@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The base resource name.')
param baseName string = resourceGroup().name

// VARIABLES
var streamName = 'Custom-MyTableRawData'
var tableName = 'MyTable_CL'

// REQUIRED PERMISSIONS
var metricPublisherRoleId = '3913510d-42f4-4e42-8a64-420c390055eb'

resource metricReaderRole 'Microsoft.Authorization/roleAssignments@2018-01-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, metricPublisherRoleId)
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', metricPublisherRoleId)
    principalId: testApplicationOid
  }
}

// PRIMARY RESOURCES
resource LogAnalyticsWorkspace1 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: '${baseName}-logs-1'
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

resource ApplicationInsightsResource1 'Microsoft.Insights/components@2020-02-02-preview' = {
  name: '${baseName}-ai-1'
  kind: 'other'
  location: location
  properties: {
    Application_Type: 'other'
    WorkspaceResourceId: LogAnalyticsWorkspace1.id
  }
}

resource dataCollectionRule1 'Microsoft.Insights/dataCollectionRules@2021-09-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, dataCollectionEndpoint1.id)
  location: location
  properties:{
    dataCollectionEndpointId: dataCollectionEndpoint1.id
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
          name: LogAnalyticsWorkspace1.name
          workspaceResourceId: LogAnalyticsWorkspace1.id
        }
      ]
    }
    dataFlows: [
      {
        destinations: [
          LogAnalyticsWorkspace1.name
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

resource dataCollectionRuleRoleAssignment1 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, dataCollectionRule1.name, dataCollectionRule1.id)
  scope: LogAnalyticsWorkspace1
  properties:{
    principalId: testApplicationOid
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', metricPublisherRoleId)
  }
}

resource table1 'Microsoft.OperationalInsights/workspaces/tables@2022-10-01' = {
  name: tableName
  parent: LogAnalyticsWorkspace1
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

resource dataCollectionEndpoint1 'Microsoft.Insights/dataCollectionEndpoints@2021-09-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, LogAnalyticsWorkspace1.id)
  location: location
  properties:{
    networkAcls:{
      publicNetworkAccess: 'Enabled'
    }
  }
}

// SECONDARY RESOURCES
resource LogAnalyticsWorkspace2 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: '${baseName}-logs-2'
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

resource ApplicationInsightsResource2 'Microsoft.Insights/components@2020-02-02-preview' = {
  name: '${baseName}-ai-2'
  kind: 'other'
  location: location
  properties: {
    Application_Type: 'other'
    WorkspaceResourceId: LogAnalyticsWorkspace2.id
  }
}

resource dataCollectionRule2 'Microsoft.Insights/dataCollectionRules@2021-09-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, dataCollectionEndpoint2.id)
  location: location
  properties:{
    dataCollectionEndpointId: dataCollectionEndpoint2.id
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
          name: LogAnalyticsWorkspace2.name
          workspaceResourceId: LogAnalyticsWorkspace2.id
        }
      ]
    }
    dataFlows: [
      {
        destinations: [
          LogAnalyticsWorkspace2.name
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

resource dataCollectionRuleRoleAssignment2 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(resourceGroup().id, dataCollectionRule2.name, dataCollectionRule2.id)
  scope: LogAnalyticsWorkspace2
  properties:{
    principalId: testApplicationOid
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', metricPublisherRoleId)
  }
}

resource table2 'Microsoft.OperationalInsights/workspaces/tables@2022-10-01' = {
  name: tableName
  parent: LogAnalyticsWorkspace2
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

resource dataCollectionEndpoint2 'Microsoft.Insights/dataCollectionEndpoints@2021-09-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, LogAnalyticsWorkspace2.id)
  location: location
  properties:{
    networkAcls:{
      publicNetworkAccess: 'Enabled'
    }
  }
}

//STORAGE ACCOUNT FOR METRICSCLIENT
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

// OUTPUT VALUES USED BY TEST ENVIRONMENT
output LOGS_ENDPOINT string =  'https://api.loganalytics.io'

output CONNECTION_STRING string = ApplicationInsightsResource1.properties.ConnectionString
output WORKSPACE_ID string = LogAnalyticsWorkspace1.properties.customerId

output SECONDARY_CONNECTION_STRING string = ApplicationInsightsResource2.properties.ConnectionString
output SECONDARY_WORKSPACE_ID string = LogAnalyticsWorkspace2.properties.customerId

// VALUES NEEDED FOR AZURE.MONITOR.QUERY
output WORKSPACE_PRIMARY_RESOURCE_ID string = LogAnalyticsWorkspace1.id
output WORKSPACE_SECONDARY_RESOURCE_ID string = LogAnalyticsWorkspace2.id
output STORAGE_NAME string = storageAccount.name
output STORAGE_ID string = storageAccount.id
output METRICS_RESOURCE_ID string = LogAnalyticsWorkspace1.id
output METRICS_RESOURCE_NAMESPACE string = 'Microsoft.OperationalInsights/workspaces'

// VALUES NEEDED FOR AZURE.MONITOR.INGESTION
output INGESTION_DATA_COLLECTION_RULE_ID string = dataCollectionRule1.id
output INGESTION_DATA_COLLECTION_RULE_IMMUTABLE_ID string = dataCollectionRule1.properties.immutableId
output MONITOR_INGESTION_DATA_COLLECTION_ENDPOINT string = dataCollectionEndpoint1.properties.logsIngestion.endpoint
output INGESTION_STREAM_NAME string = streamName
