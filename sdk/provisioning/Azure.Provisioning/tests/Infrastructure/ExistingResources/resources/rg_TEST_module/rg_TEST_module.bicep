@description('')
param existingAppConfig string

@description('')
param existingSqlDatabase string


resource appConfigurationStore_4FWfd15sH 'Microsoft.AppConfiguration/configurationStores@2023-03-01' existing = {
  name: existingAppConfig
}

resource keyVault_78IwnSu6G 'Microsoft.KeyVault/vaults@2022-07-01' existing = {
  name: 'existingVault'
}

resource keyVaultSecret_ChWKOL5pG 'Microsoft.KeyVault/vaults/secrets@2022-07-01' existing = {
  name: '${keyVault_78IwnSu6G}/existingSecret'
}

resource storageAccount_LhqOcwcwC 'Microsoft.Storage/storageAccounts@2022-09-01' existing = {
  name: 'existingStorage'
}

resource blobService_KtyZZZEH1 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' existing = {
  name: '${storageAccount_LhqOcwcwC}/existingBlobService'
}

resource postgreSqlFlexibleServer_0TaJ8imA6 'Microsoft.DBforPostgreSQL/flexibleServers@2023-03-01-preview' existing = {
  name: 'existingPostgreSql'
}

resource sqlServer_O1efuGmrm 'Microsoft.Sql/servers@2020-11-01-preview' existing = {
  name: 'existingSqlServer'
}

resource sqlDatabase_YeJoBPp10 'Microsoft.Sql/servers/databases@2020-11-01-preview' existing = {
  name: '${sqlServer_O1efuGmrm}/${existingSqlDatabase}'
}

resource sqlFirewallRule_SFMW2DxVf 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' existing = {
  name: '${sqlServer_O1efuGmrm}/existingSqlFirewallRule'
}

resource redisCache_nxA8uMVGD 'Microsoft.Cache/Redis@2020-06-01' existing = {
  name: 'existingRedis'
}

resource cosmosDBAccount_YYHnVjsWQ 'Microsoft.DocumentDB/databaseAccounts@2023-04-15' existing = {
  name: 'cosmosDb'
}

resource cosmosDBSqlDatabase_HPAp4ft3Q 'Microsoft.DocumentDB/databaseAccounts/sqlDatabases@2023-04-15' existing = {
  name: '${cosmosDBAccount_YYHnVjsWQ}/cosmosDb'
}

resource deploymentScript_QqrJz7yzH 'Microsoft.Resources/deploymentScripts@2020-10-01' existing = {
  name: 'existingDeploymentScript'
}

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

resource searchService_Szsp3FYvd 'Microsoft.Search/searchServices@2023-11-01' existing = {
  name: 'existingSearch'
}

resource eventHubsNamespace_dQTmc5DUS 'Microsoft.EventHub/namespaces@2021-11-01' existing = {
  name: 'existingEhNamespace'
}

resource eventHub_H6DI0xDvi 'Microsoft.EventHub/namespaces/eventhubs@2021-11-01' existing = {
  name: '${eventHubsNamespace_dQTmc5DUS}/existingHub'
}

resource eventHubsConsumerGroup_YKe70TLwz 'Microsoft.EventHub/namespaces/eventhubs/consumergroups@2021-11-01' existing = {
  name: '${eventHub_H6DI0xDvi}/existingEhConsumerGroup'
}

resource signalRService_d95Jninqk 'Microsoft.SignalRService/signalR@2022-02-01' existing = {
  name: 'existingSignalR'
}

resource applicationInsightsComponent_OdiSCimF0 'Microsoft.Insights/components@2020-02-02' existing = {
  name: 'existingAppInsights'
}

resource operationalInsightsWorkspace_8Dwma7cn9 'Microsoft.OperationalInsights/workspaces@2022-10-01' existing = {
  name: 'existingOpInsights'
}

resource userAssignedIdentity_AHWXCnFeG 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' existing = {
  name: 'existingUserAssignedIdentity'
}
