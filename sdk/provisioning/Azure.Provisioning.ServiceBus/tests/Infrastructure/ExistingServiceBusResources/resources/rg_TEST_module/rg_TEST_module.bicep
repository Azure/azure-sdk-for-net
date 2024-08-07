
resource serviceBusNamespace_0J6N7TWQp 'Microsoft.ServiceBus/namespaces@2021-11-01' existing = {
  name: 'existingSbNamespace'
}

resource serviceBusQueue_YWGfZ7Jp4 'Microsoft.ServiceBus/namespaces/queues@2021-11-01' existing = {
  name: '${serviceBusNamespace_0J6N7TWQp}/existingSbQueue'
}

resource serviceBusTopic_xubvxdBtk 'Microsoft.ServiceBus/namespaces/topics@2021-11-01' existing = {
  name: '${serviceBusNamespace_0J6N7TWQp}/existingSbTopic'
}

resource serviceBusSubscription_EnDkO3Vba 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' existing = {
  name: '${serviceBusTopic_xubvxdBtk}/existingSbSubscription'
}
