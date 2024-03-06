@description('')
param existingAppConfig string

@description('')
param existingSqlDatabase string


resource appConfigurationStore_4FWfd15sH 'Microsoft.AppConfiguration/configurationStores@2023-03-01' existing = {
  name: existingAppConfig
}

resource keyVault_78IwnSu6G 'Microsoft.KeyVault/vaults@2023-02-01' existing = {
  name: 'existingVault'
}

resource keyVaultSecret_ChWKOL5pG 'Microsoft.KeyVault/vaults/secrets@2023-02-01' existing = {
  name: '${keyVault_78IwnSu6G}/existingSecret'
}

resource storageAccount_LhqOcwcwC 'Microsoft.Storage/storageAccounts@2022-09-01' existing = {
  name: 'existingStorage'
}

resource blobService_KtyZZZEH1 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' existing = {
  name: '${storageAccount_LhqOcwcwC}/existingBlobService'
}

resource webSite_C2Aq73IJb 'Microsoft.Web/sites@2021-02-01' existing = {
  name: 'existingWebSite'
}

resource webSiteConfigLogs_7A7a8DHfx 'Microsoft.Web/sites/config@2021-02-01' existing = {
  name: '${webSite_C2Aq73IJb}/existingWebSiteConfigLogs'
}

resource webSitePublishingCredentialPolicy_thziHKVBm 'Microsoft.Web/sites/basicPublishingCredentialsPolicies@2021-02-01' existing = {
  name: '${webSite_C2Aq73IJb}/existingWebSitePublishingCredentialPolicy'
}

resource postgreSqlFlexibleServer_0TaJ8imA6 'Microsoft.DBforPostgreSQL/flexibleServers@2020-06-01' existing = {
  name: 'existingPostgreSql'
}

resource sqlServer_O1efuGmrm 'Microsoft.Sql/servers@2022-08-01-preview' existing = {
  name: 'existingSqlServer'
}

resource sqlDatabase_YeJoBPp10 'Microsoft.Sql/servers/databases@2022-08-01-preview' existing = {
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

resource appServicePlan_D5p3EVvRT 'Microsoft.Web/serverfarms@2021-02-01' existing = {
  name: 'existingAppServicePlan'
}

resource applicationSettingsResource_6DtpuGITF 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_C2Aq73IJb
  name: 'appsettings'
}
