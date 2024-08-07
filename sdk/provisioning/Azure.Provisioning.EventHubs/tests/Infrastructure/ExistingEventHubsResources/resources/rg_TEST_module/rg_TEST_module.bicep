
resource eventHubsNamespace_dQTmc5DUS 'Microsoft.EventHub/namespaces@2021-11-01' existing = {
  name: 'existingEhNamespace'
}

resource eventHub_H6DI0xDvi 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' existing = {
  name: '${eventHubsNamespace_dQTmc5DUS}/existingHub'
}

resource eventHubsConsumerGroup_YKe70TLwz 'Microsoft.EventHub/namespaces/eventhubs/consumergroups@2021-11-01' existing = {
  name: '${eventHub_H6DI0xDvi}/existingEhConsumerGroup'
}
