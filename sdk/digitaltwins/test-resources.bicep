@description('The client OID to grant access to test resources.')
param testApplicationOid string

@minLength(6)
@maxLength(50)
@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

var adtOwnerRoleDefinitionId = '/subscriptions/${subscription().subscriptionId}/providers/Microsoft.Authorization/roleDefinitions/bcd981a7-7f74-457b-83e1-cceb9e632ffe'

resource digitaltwin 'Microsoft.DigitalTwins/digitalTwinsInstances@2020-03-01-preview' = {
    name: baseName
    location: location
    sku: {
        name: 'S1'
    }
    properties: {}
}

resource digitaltwinRoleAssignment 'Microsoft.DigitalTwins/digitalTwinsInstances/providers/roleAssignments@2020-03-01-preview' = {
    name: '${digitaltwin.name}/Microsoft.Authorization/${guid(uniqueString(baseName))}'
    properties: {
        roleDefinitionId: adtOwnerRoleDefinitionId
        principalId: testApplicationOid
    }
}

resource eventHubNamespace 'Microsoft.EventHub/namespaces@2018-01-01-preview' = {
    name: baseName
    location: location
    sku: {
        name: 'Standard'
        tier: 'Standard'
        capacity: 1
    }
    properties: {
        zoneRedundant: false
        isAutoInflateEnabled: false
        maximumThroughputUnits: 0
        kafkaEnabled: false
    }
}

resource eventHubNamespaceEventHub 'Microsoft.EventHub/namespaces/eventhubs@2017-04-01' = {
    name: '${eventHubNamespace.name}/${baseName}'
    properties: {
        messageRetentionInDays: 7
        partitionCount: 4
        status: 'Active'
    }
}

resource eventHubNamespaceAuthRules 'Microsoft.EventHub/namespaces/AuthorizationRules@2017-04-01' = {
    name: '${eventHubNamespace.name}/RootManageSharedAccessKey'
    properties: {
        rights: [
            'Listen'
            'Manage'
            'Send'
        ]
    }
}
 
resource eventHubNamespaceEventHubAuthRules 'Microsoft.EventHub/namespaces/eventhubs/authorizationRules@2017-04-01' = {
    name: '${eventHubNamespaceEventHub.name}/owner'
    properties: {
        rights: [
            'Listen'
            'Manage'
            'Send'
        ]
    }
}

resource digitaltwinEndpoints 'Microsoft.DigitalTwins/digitalTwinsInstances/endpoints@2020-03-01-preview' = {
    name: '${digitaltwin.name}/someEventHubEndpoint'
    properties: {
        endpointType: 'EventHub'
        'connectionString-PrimaryKey': listKeys(eventHubNamespaceEventHubAuthRules.id, '2017-04-01').primaryConnectionString
        'connectionString-SecondaryKey': listKeys(eventHubNamespaceEventHubAuthRules.id, '2017-04-01').secondaryConnectionString
    }
}

output DIGITALTWINS_URL string = 'https://${digitaltwin.properties.hostName}'
