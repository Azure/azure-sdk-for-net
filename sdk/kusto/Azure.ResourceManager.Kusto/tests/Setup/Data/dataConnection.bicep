param id string
param location string

resource eventHubNamespace 'Microsoft.EventHub/namespaces@2021-11-01' = {
    name: 'sdkEventHubNamespace${id}'
    location: location
    sku: {
        name: 'Standard'
    }
}

resource eventHub 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' = {
    parent: eventHubNamespace
    name: 'sdkEventHub${id}'
}

resource iotHub 'Microsoft.Devices/IotHubs@2021-07-02' = {
    name: 'sdkIotHub${id}'
    location: location
    sku: {
        name: 'S1'
        capacity: 1
    }
}

output EVENT_HUB_ID string = eventHub.id
output IOT_HUB_ID string = iotHub.id
