targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location


resource serviceBusNamespace_VkKO9fgDH 'Microsoft.ServiceBus/namespaces@2021-11-01' = {
  name: toLower(take(concat('sb', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: 'Standard'
  }
  properties: {
    minimumTlsVersion: '1.2'
  }
}

resource serviceBusQueue_lEZynaDBV 'Microsoft.ServiceBus/namespaces/queues@2021-11-01' = {
  parent: serviceBusNamespace_VkKO9fgDH
  name: 'sbqueue'
  location: location
  properties: {
  }
}

resource serviceBusTopic_JIEBFxhva 'Microsoft.ServiceBus/namespaces/topics@2021-11-01' = {
  parent: serviceBusNamespace_VkKO9fgDH
  name: 'sbtopic'
  location: location
  properties: {
  }
}

resource serviceBusSubscription_UaHJX5i8p 'Microsoft.ServiceBus/namespaces/topics/subscriptions@2021-11-01' = {
  parent: serviceBusTopic_JIEBFxhva
  name: 'sbsubscription'
  location: location
  properties: {
  }
}
