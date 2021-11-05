@description('The name of the source IoT hub.')
param iotHubName string = az.resourceGroup().name

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The region of the resource. By default, this is the same as the resource group.')
param region string = az.resourceGroup().location

@maxLength(90)
@description('Name of the environment. The name cannot include: \'<\', \'>\', \'%\', \'&\', \':\', \'\\\', \'?\', \'/\' and any control characters. All other characters are allowed.')
param environmentName string = '${az.resourceGroup().name}-TSI'

@description('The name of the consumer group that the Time Series Insights service will use to read the data from the event hub. NOTE: To avoid resource contention, this consumer group must be dedicated to the Time Series Insights service and not shared with other readers.')
param consumerGroupName string = '${environmentName}CG'

@maxLength(3)
@description('Time Series ID acts as a partition key for your data and as a primary key for your time series model. It is important that you specify the appropriate Time Series Property ID during environment creation, since you cannot change it later. Note that the Property ID is case sensitive. You can use 1-3 keys: one is required, but up to three can be used to create a composite.')
param environmentTimeSeriesIdProperties array = [
    {
        'name': 'building'
        'type': 'string'
    }
    {
        'name': 'floor'
        'type': 'string'
    }
    {
        'name': 'room'
        'type': 'string'
    }
]

@maxLength(90)
@description('Name of the event source child resource. The name cannot include: \'<\', \'>\', \'%\', \'&\', \':\', \'\\\', \'?\', \'/\' and any control characters. All other characters are allowed.')
param eventSourceName string = '${environmentName}EventSourceName'

@description('If you have an existing IotHub provide the name here. Defaults to the same resource group as the TSI environnment.')
param resourceGroup string = az.resourceGroup().name

@maxLength(90)
@description('The event property that will be used as the event source\'s timestamp. If a value is not specified for timestampPropertyName, or if null or empty-string is specified, the event creation time will be used.')
param eventSourceTimestampPropertyName string = '${eventSourceName}TimestampPropertyName'

@description('The name of the shared access key that the Time Series Insights service will use to connect to the event hub.')
param eventSourceKeyName string = 'service'

var storageAccountName = 'tsi${uniqueString(az.resourceGroup().id)}'
var eventSourceResourceId = resourceId(resourceGroup, 'Microsoft.Devices/IotHubs', iotHubName)

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
    name: '${iotHubName}/events/${consumerGroupName}'
    dependsOn: [
        iotHub
    ]
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
    name: '${environmentName}/${eventSourceName}'
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
    name: '${environmentName}/contributorAccessPolicy0'
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

var hubKeysId = resourceId('Microsoft.Devices/IotHubs/Iothubkeys', iotHubName, 'iothubowner')

output TIMESERIESINSIGHTS_URL string = '${environment.properties.dataAccessFqdn}'
output IOTHUB_CONNECTION_STRING string = 'HostName=${iotHubName}.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=${listkeys(hubKeysId, '2019-11-04').primaryKey}'
