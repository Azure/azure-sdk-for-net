
resource redisCache_SNGmiv7Zk 'Microsoft.Cache/Redis@2020-06-01' existing = {
  name: 'existingRedisCache'
}

resource redisFirewallRule_BAj7h82Ye 'Microsoft.Cache/Redis/firewallRules@2023-08-01' existing = {
  name: '${redisCache_SNGmiv7Zk}/existingRedisFirewallRule'
}
