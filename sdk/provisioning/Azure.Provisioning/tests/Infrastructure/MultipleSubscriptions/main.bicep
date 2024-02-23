targetScope = 'tenant'


resource subscription_O0vZNnri3 'Microsoft.Resources/subscriptions@2022-12-01' = {
  id: '/subscriptions/8286d046-9740-a3e4-95cf-ff46699c73c4'
  subscriptionId: '8286d046-9740-a3e4-95cf-ff46699c73c4'
  tenantId: '00000000-0000-0000-0000-000000000000'
}

resource subscription_i7MQMw1U7 'Microsoft.Resources/subscriptions@2022-12-01' = {
  id: '/subscriptions/3410cda1-5b13-a34e-6f84-a54adf7a0ea0'
  subscriptionId: '3410cda1-5b13-a34e-6f84-a54adf7a0ea0'
  tenantId: '00000000-0000-0000-0000-000000000000'
}

module subscription_O0vZNnri3_module './resources/subscription_O0vZNnri3_module/subscription_O0vZNnri3_module.bicep' = {
  name: 'subscription_O0vZNnri3_module'
  scope: subscription('subscription_O0vZNnri3')
}

module subscription_i7MQMw1U7_module './resources/subscription_i7MQMw1U7_module/subscription_i7MQMw1U7_module.bicep' = {
  name: 'subscription_i7MQMw1U7_module'
  scope: subscription('subscription_i7MQMw1U7')
}
