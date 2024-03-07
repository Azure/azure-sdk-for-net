targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('Administrator login')
param adminLogin string

@secure()
@description('Administrator password')
param adminPassword string

@description('')
param dbInstanceType string

@description('')
param serverEdition string

@description('')
param p string = 'name'


resource postgreSqlFlexibleServer_mZ8PC2Gce 'Microsoft.DBforPostgreSQL/flexibleServers@2023-03-01-preview' = {
  name: toLower(take(concat('postgres', uniqueString(resourceGroup().id)), 24))
  location: location
  sku: {
    name: dbInstanceType
    tier: serverEdition
  }
  properties: {
    administratorLogin: adminLogin
    administratorLoginPassword: adminPassword
    version: ''
    backup: {
      backupRetentionDays: 7
      geoRedundantBackup: 'Disabled'
    }
    highAvailability: {
      mode: 'haMode'
    }
  }
}

resource postgreSqlFlexibleServerDatabase_GXcWWJhWh 'Microsoft.DBforPostgreSQL/flexibleServers/databases@2023-03-01-preview' = {
  parent: postgreSqlFlexibleServer_mZ8PC2Gce
  name: 'db'
  properties: {
  }
}

resource postgreSqlFirewallRule_wheM1oYbH 'Microsoft.DBforPostgreSQL/flexibleServers/firewallRules@2023-03-01-preview' = {
  parent: postgreSqlFlexibleServer_mZ8PC2Gce
  name: 'fw'
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '255.255.255.255'
  }
}

resource keyVault_5t0GshPLB 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: p
  location: location
  properties: {
    tenantId: tenant().tenantId
    sku: {
      name: 'standard'
      family: 'A'
    }
    enableRbacAuthorization: true
  }
}

resource keyVaultSecret_R6AWfDGcA 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_5t0GshPLB
  name: 'connectionString'
  location: location
  properties: {
    value: 'Host=${postgreSqlFlexibleServer_mZ8PC2Gce.properties.fullyQualifiedDomainName};Username=${adminLogin};Password=${adminPassword}'
  }
}
