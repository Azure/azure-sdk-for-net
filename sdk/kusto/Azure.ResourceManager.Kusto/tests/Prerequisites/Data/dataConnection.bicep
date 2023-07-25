param id string
param location string
param user_assigned_identity_principal_id string

var eventHubNamespaceName = 'sdkEventHubNamespace${id}'
var eventHubName = 'sdkEventHub${id}'

resource eventHubNamespace 'Microsoft.EventHub/namespaces@2021-11-01' = {
    name: eventHubNamespaceName
    location: location
    sku: {
        name: 'Standard'
    }

    resource eventHub 'eventhubs' = {
        name: eventHubName
    }
}

output EVENT_HUB_ID string = eventHubNamespace::eventHub.id

var iotHubName = 'sdkIotHub${id}'

resource iotHub 'Microsoft.Devices/IotHubs@2021-07-02' = {
    name: iotHubName
    location: location
    sku: {
        name: 'S1'
        capacity: 1
    }
}

output IOT_HUB_ID string = iotHub.id

var cosmosDbAccountName = 'sdkcosmosdbaccount${id}'
var cosmosDbDatabaseName = 'mydb'
var cosmosDbContainerName = 'mycontainer'

resource cosmosDbAccount 'Microsoft.DocumentDB/databaseAccounts@2022-08-15' = {
    name: cosmosDbAccountName
    location: location
    kind: 'GlobalDocumentDB'
    properties: {
        databaseAccountOfferType: 'Standard'
    }

    resource cosmosDbDatabase 'sqlDatabases' = {
        name: cosmosDbDatabaseName
        properties: {
            resource: {
                id: cosmosDbDatabaseName
            }
        }
        resource cosmosDbContainer 'containers' = {
            name: cosmosDbContainerName
            properties: {
                throughput: 400
                resource: {
                    id: cosmosDbContainerName
                    partitionKey: {
                        kind: 'Hash'
                        paths: [
                            '/part'
                        ]
                    }
                }
            }
        }
    }
}

output COSMOSDB_ACCOUNT_ID string = cosmosDbAccount.id
output COSMOSDB_DATABASE_NAME string = cosmosDbDatabaseName
output COSMOSDB_CONTAINER_NAME string = cosmosDbContainerName

resource cosmosDBAccountReaderRoleDefinition 'Microsoft.Authorization/roleDefinitions@2018-01-01-preview' existing = {
  scope: cosmosDbAccount
  name: 'fbdf93bf-df7d-467e-a4d2-9458aa1360c8'
}

resource roleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  scope: cosmosDbAccount
  name: guid(cosmosDbAccountName, user_assigned_identity_principal_id, cosmosDBAccountReaderRoleDefinition.id)
  properties: {
    roleDefinitionId: cosmosDBAccountReaderRoleDefinition.id
    principalId: user_assigned_identity_principal_id
    principalType: 'ServicePrincipal'
  }
}
