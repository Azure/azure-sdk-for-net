@description('The client OID to grant access to test resources.')
param testApplicationOid string

@minLength(6)
@maxLength(50)
@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('A new GUID used to identify the role assignment')
param roleNameGuid string = newGuid()
param storageRoleNameGuid string = newGuid()

var adtOwnerRoleDefinitionId = '/subscriptions/${subscription().subscriptionId}/providers/Microsoft.Authorization/roleDefinitions/bcd981a7-7f74-457b-83e1-cceb9e632ffe'
var storageBlobDataContributor = '/subscriptions/${subscription().subscriptionId}/providers/Microsoft.Authorization/roleDefinitions/ba92f5b4-2d11-453d-a403-e96b0029c9fe'

resource digitaltwin 'Microsoft.DigitalTwins/digitalTwinsInstances@2020-12-01' = {
    name: baseName
    location: location
    identity: {
        type: 'SystemAssigned'
    }
    properties: {}
}

resource digitaltwinRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = {
    name: roleNameGuid
    properties: {
        roleDefinitionId: adtOwnerRoleDefinitionId
        principalId: testApplicationOid
    }
    scope: digitaltwin
}

resource eventHubNamespace 'Microsoft.EventHub/namespaces@2022-01-01-preview' = {
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
        minimumTlsVersion: 'TLS1_2'
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

resource digitaltwinEndpoints 'Microsoft.DigitalTwins/digitalTwinsInstances/endpoints@2020-12-01' = {
    name: '${digitaltwin.name}/someEventHubEndpoint'
    properties: {
        endpointType: 'EventHub'
        authenticationType: 'KeyBased'
        connectionStringPrimaryKey: listKeys(eventHubNamespaceEventHubAuthRules.id, '2017-04-01').primaryConnectionString
        connectionStringSecondaryKey: listKeys(eventHubNamespaceEventHubAuthRules.id, '2017-04-01').secondaryConnectionString
    }
}

output DIGITALTWINS_URL string = 'https://${digitaltwin.properties.hostName}'


var containerName = baseName

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
    name: baseName
    location: location
    sku: {
        name: 'Standard_LRS'
    }
    kind: 'StorageV2'
    properties: {
        minimumTlsVersion: 'TLS1_2'
    }

    resource blobService 'blobServices' = {
        name: 'default'

        resource container 'containers' = {
            name: containerName
        }
    }
}

resource storageRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = {
    name: storageRoleNameGuid
    properties: {
        roleDefinitionId: storageBlobDataContributor
        principalId: digitaltwin.identity.principalId
    }
    scope: storageAccount
}

output STORAGE_CONTAINER_URI string = 'https://${storageAccount.name}.blob.${environment().suffixes.storage}/${containerName}'

var deploymentScriptName = 'importJobSdkDeploymentScript'
var blobName = 'importJobInputBlobSdkTest.ndjson'
var storageAccountKey = storageAccount.listKeys().keys[0].value

resource deploymentScript 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
    name: deploymentScriptName
    location: location
    kind: 'AzureCLI'
    properties: {
        azCliVersion: '2.40.0'
        retentionInterval: 'P1D'
        environmentVariables: [
            {
                name: 'INPUT_FILE'
                value: loadFileAsBase64('./Azure.DigitalTwins.Core/tests/resources/importJobInputBlobSdkTest.ndjson')
            }
            {
                name: 'CONTAINER_NAME'
                value: containerName
            }
            {
                name: 'BLOB_NAME'
                value: blobName
            }
            {
                name: 'AZURE_STORAGE_ACCOUNT'
                value: storageAccount.name
            }
            {
                name: 'AZURE_STORAGE_KEY'
                secureValue: storageAccountKey
            }
        ]
        scriptContent: '''
            echo $INPUT_FILE | base64 -d > /tmp/$BLOB_NAME
            az storage blob upload -f /tmp/$BLOB_NAME -c $CONTAINER_NAME -n $BLOB_NAME --overwrite
        '''
    }
}

output INPUT_BLOB_URI string = 'https://${storageAccount.name}.blob.${environment().suffixes.storage}/${containerName}/${blobName}'