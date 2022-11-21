param id string
param location string

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
