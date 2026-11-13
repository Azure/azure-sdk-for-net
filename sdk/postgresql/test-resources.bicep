@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The principal to assign the role to. This is the application object id.')
param testApplicationOid string

@description('The display name or UPN of the test principal. Resolved by test-resources-pre.ps1.')
param principalName string = ''

@description('The type of the test principal. Resolved by test-resources-pre.ps1.')
@allowed([
  'User'
  'ServicePrincipal'
])
param principalType string = 'ServicePrincipal'

@description('The location of the resource group.')
param location string = resourceGroup().location

@description('The tenant ID.')
param tenantId string = subscription().tenantId

var serverName = '${baseName}-pg'
var databaseName = 'testdb'

resource postgresServer 'Microsoft.DBforPostgreSQL/flexibleServers@2022-12-01' = {
  name: serverName
  location: location
  sku: {
    name: 'Standard_B1ms'
    tier: 'Burstable'
  }
  properties: {
    version: '16'
    storage: {
      storageSizeGB: 32
    }
    backup: {
      backupRetentionDays: 7
      geoRedundantBackup: 'Disabled'
    }
    highAvailability: {
      mode: 'Disabled'
    }
    authConfig: {
      activeDirectoryAuth: 'Enabled'
      passwordAuth: 'Disabled'
      tenantId: tenantId
    }
  }
}

resource database 'Microsoft.DBforPostgreSQL/flexibleServers/databases@2022-12-01' = {
  name: databaseName
  parent: postgresServer
  properties: {}
}

resource entraAdmin 'Microsoft.DBforPostgreSQL/flexibleServers/administrators@2022-12-01' = {
  name: testApplicationOid
  parent: postgresServer
  properties: {
    principalName: principalName
    principalType: principalType
    tenantId: tenantId
  }
  dependsOn: [
    database
  ]
}

resource firewallAllowAzure 'Microsoft.DBforPostgreSQL/flexibleServers/firewallRules@2022-12-01' = {
  name: 'AllowAllAzureServicesAndResourcesWithinAzureIps'
  parent: postgresServer
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '0.0.0.0'
  }
}

resource firewallAllowAll 'Microsoft.DBforPostgreSQL/flexibleServers/firewallRules@2022-12-01' = {
  name: 'AllowAllForTesting'
  parent: postgresServer
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '255.255.255.255'
  }
}

output POSTGRESQL_HOST string = '${serverName}.postgres.database.azure.com'
output POSTGRESQL_DATABASE string = databaseName
output POSTGRESQL_PORT string = '5432'
