param iotHubName string {
    metadata: {
        description: 'The name of the source IoT hub.'
    }
    default: az.resourceGroup().name
}

param testApplicationOid string {
    metadata: {
        description: 'The client OID to grant access to test resources.'
    }
}

param region string {
    metadata: {
        description: 'The region of the resource. By default, this is the same as the resource group.'
    }
    default: az.resourceGroup().location
}

param environmentName string {
    metadata: {
        description: 'Name of the environment. The name cannot include: \'<\', \'>\', \'%\', \'&\', \':\', \'\\\', \'?\', \'/\' and any control characters. All other characters are allowed.'
    }
    maxLength: 90
    default: concat(az.resourceGroup().name, '-TSI')
}

param consumerGroupName string {
    metadata: {
        description: 'The name of the consumer group that the Time Series Insights service will use to read the data from the event hub. NOTE: To avoid resource contention, this consumer group must be dedicated to the Time Series Insights service and not shared with other readers.'
    }
    default: concat(environmentName, 'CG')
}

param environmentTimeSeriesIdProperties array {
    metadata: {
        description: 'Time Series ID acts as a partition key for your data and as a primary key for your time series model. It is important that you specify the appropriate Time Series Property ID during environment creation, since you cannot change it later. Note that the Property ID is case sensitive. You can use 1-3 keys: one is required, but up to three can be used to create a composite.'
    }
    maxLength: 3
    default: [
        {
            'name': 'timeseriesinsights.id'
            'type': 'string'
        }
        {
            'name': 'id'
            'type': 'string'
        }
    ]
}

param eventSourceName string {
    metadata: {
        description: 'Name of the event source child resource. The name cannot include: \'<\', \'>\', \'%\', \'&\', \':\', \'\\\', \'?\', \'/\' and any control characters. All other characters are allowed.'
    }
    maxLength: 90
    default: concat(environmentName, 'EventSourceName')
}

param resourceGroup string {
    metadata: {
        description: 'If you have an existing IotHub provide the name here. Defaults to the same resource group as the TSI environnment.'
    }
    default: az.resourceGroup().name
} 

param eventSourceTimestampPropertyName string {
    metadata: {
        description: 'The event property that will be used as the event source\'s timestamp. If a value is not specified for timestampPropertyName, or if null or empty-string is specified, the event creation time will be used.'
    }
    maxLength: 90
    default: concat(eventSourceName, 'TimestampPropertyName')
}

param eventSourceKeyName string {
    metadata: {
        description: 'The name of the shared access key that the Time Series Insights service will use to connect to the event hub.'
    }
    default : 'service'
}

var rbacOwnerRoleDefinitionId = '/subscriptions/${subscription().subscriptionId}/providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635'
var storageAccountName = concat('tsi', uniqueString(az.resourceGroup().id))
var eventSourceResourceId = resourceId(resourceGroup, 'Microsoft.Devices/IotHubs', iotHubName)

resource roleAssignment 'Microsoft.Authorization/roleAssignments@2018-09-01-preview' = {
    name: guid(az.resourceGroup().id)
    properties: {
        roleDefinitionId: rbacOwnerRoleDefinitionId
        principalId: testApplicationOid
    }
}

resource iotHub 'Microsoft.Devices/IotHubs@2020-03-01' = {
    name: iotHubName
    location: region
    properties: {}
    sku: {
      name: 'S1'
      capacity: 1
    }
}

resource consumerGroup 'Microsoft.Devices/IotHubs/eventHubEndpoints/ConsumerGroups@2020-03-01' = {
    name: concat(iotHubName, '/events/', consumerGroupName)
    dependsOn: [
        iotHub
    ]
    properties: {
      mode: 'Complete'
    }
}

resource environment 'Microsoft.TimeSeriesInsights/environments@2018-08-15-preview' = {
    name: environmentName
    location: region
    kind: 'LongTerm'
    properties: {
        storageConfiguration: {
            accountName: storageAccountName
            managementKey: listKeys(resourceId('Microsoft.Storage/storageAccounts', storageAccountName), '2019-06-01').keys[0].value
          }
          timeSeriesIdProperties: environmentTimeSeriesIdProperties
          warmStoreConfiguration: {
            dataRetention: 'P7D'
          }  
    }
    sku: {
        name: 'L1'
        capacity: 1
    }
}

resource eventSource 'Microsoft.TimeSeriesInsights/environments/eventsources@2018-08-15-preview' = {
    name: concat(environmentName,'/', eventSourceName)
    location: region
    kind: 'Microsoft.IoTHub'
    dependsOn: [
        environment
        iotHub
        consumerGroup
    ]
    properties: {
        eventSourceResourceId: eventSourceResourceId
        iotHubName: iotHubName
        consumerGroupName: consumerGroupName
        keyName: eventSourceKeyName
        sharedAccessKey: listkeys(resourceId('Microsoft.Devices/IoTHubs/IotHubKeys', iotHubName, eventSourceKeyName), '2020-03-01').primaryKey
        timestampPropertyName: eventSourceTimestampPropertyName
    }
}

resource accesspolicy 'Microsoft.TimeSeriesInsights/environments/accesspolicies@2018-08-15-preview' = {
    name: concat(environmentName, '/', 'contributorAccessPolicy0')
    dependsOn: [
        environment
    ]
    properties: {
        principalObjectId: testApplicationOid
        roles: [
            'Contributor'
        ]
    }
}

resource storageaccount 'Microsoft.Storage/storageAccounts@2018-11-01' = {
    name: storageAccountName
    location: region
    sku: {
        name: 'Standard_LRS'
    }
    kind: 'StorageV2'
    properties: {}
}

output TIMESERIESINSIGHTS_URL string = '${environment.properties.dataAccessFqdn}'