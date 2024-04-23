
resource webPubSub_d95Jnanqk 'Microsoft.SignalRService/webPubSub@2021-10-01' existing = {
  name: 'existingWebPubSub'
}

resource webPubSubHub_da5Jnanqk 'Microsoft.SignalRService/webPubSub/hubs@2021-10-01' existing = {
  name: '${webPubSub_d95Jnanqk}/existingWebPubSubHub'
}
