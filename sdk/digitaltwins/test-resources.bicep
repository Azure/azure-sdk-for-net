param testApplicationOid string {
    metadata: {
        description: 'The client OID to grant access to test resources.'
    }
}

param baseName string {
    default : resourceGroup().name
    minLength: 6
    maxLength: 50
    metadata: {
        description: 'The base resource name.'
    }
}

param location string {
    default: resourceGroup().location
    metadata: {
        description: 'The location of the resource. By default, this is the same as the resource group.'
    }
} 

var rbacOwnerRoleDefinitionId = '/subscriptions/${subscription().subscriptionId}/providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635'
var adtOwnerRoleDefinitionId = '/subscriptions/${subscription().subscriptionId}/providers/Microsoft.Authorization/roleDefinitions/bcd981a7-7f74-457b-83e1-cceb9e632ffe'

resource roleAssignment 'Microsoft.Authorization/roleAssignments@2018-09-01-preview' = {
    name: guid(resourceGroup().id)
    properties: {
        roleDefinitionId: rbacOwnerRoleDefinitionId
        principalId: testApplicationOid
    }
}

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
    location: location
    properties: {
        messageRetentionInDays: 7
        partitionCount: 4
        status: 'Active'
    }
}

resource eventHubNamespaceAuthRules 'Microsoft.EventHub/namespaces/AuthorizationRules@2017-04-01' = {
    name: '${eventHubNamespace.name}/RootManageSharedAccessKey'
    location: location
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
    location: location
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