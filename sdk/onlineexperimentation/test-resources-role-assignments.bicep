param principalId string
param keyVaultName string
param storageAccountName string
param logAnalyticsName string
param appConfigName string

resource keyVault 'Microsoft.KeyVault/vaults@2023-02-01' existing = {
  name: keyVaultName
}

var keyVaultCryptoServiceEncryptionUserRoleId = resourceId('Microsoft.Authorization/roleDefinitions', 'e147488a-f6f5-4113-8e2d-b22465e65bf6')
resource keyVaultroleAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(keyVault.id, principalId, keyVaultCryptoServiceEncryptionUserRoleId)
  scope: keyVault
  properties: {
    principalId: principalId
    principalType: 'ServicePrincipal'
    roleDefinitionId: keyVaultCryptoServiceEncryptionUserRoleId
  }
}

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-09-01' existing = {
  name: storageAccountName
}

// Allow Online Experiment Workspace read access to logs storage account
var storageDataReaderRoleId = resourceId('Microsoft.Authorization/roleDefinitions', '2a2b9908-6ea1-4ae2-8e65-a410df84e7d1')
resource storageAccountExpAccess 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(storageAccount.id, principalId, storageDataReaderRoleId)
  scope: storageAccount
  properties: {
    principalId: principalId
    principalType: 'ServicePrincipal'
    roleDefinitionId: storageDataReaderRoleId
  }
}

// Create Azure Monitor resources: Log Analytics workspace, App Insights, Storage Account and Data Export Rule
resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' existing = {
  name: logAnalyticsName
}

// Allow Online Experiment Workspace read access to log analytics workspace
var logAnalyticsReaderRoleId = resourceId('Microsoft.Authorization/roleDefinitions', '73c42c96-874c-492b-b04d-ab87d138a893')
resource logAnalyticsExpAccess 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(logAnalytics.id, principalId, logAnalyticsReaderRoleId)
  scope: logAnalytics
  properties: {
    principalId: principalId
    principalType: 'ServicePrincipal'
    roleDefinitionId: logAnalyticsReaderRoleId
  }
}

// Create App Configuration Store
resource appConfig 'Microsoft.AppConfiguration/configurationStores@2022-05-01' existing = {
  name: appConfigName
}

// Allow input principal read/write access to app configuration
var appConfigDataOwnerRoleId = resourceId('Microsoft.Authorization/roleDefinitions', '5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b')
resource appConfigAccess 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: guid(appConfig.id, principalId, appConfigDataOwnerRoleId)
  scope: appConfig
  properties: {
    principalId: principalId
    principalType: 'ServicePrincipal'
    roleDefinitionId: appConfigDataOwnerRoleId
  }
}
