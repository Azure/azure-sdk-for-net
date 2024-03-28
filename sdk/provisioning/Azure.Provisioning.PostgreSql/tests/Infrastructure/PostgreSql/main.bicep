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


resource postgreSqlFlexibleServer_StT5lUao4 'Microsoft.DBforPostgreSQL/flexibleServers@2023-03-01-preview' = {
  name: toLower(take('postgres${uniqueString(resourceGroup().id)}', 24))
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

resource postgreSqlFlexibleServerDatabase_Obq44YE42 'Microsoft.DBforPostgreSQL/flexibleServers/databases@2023-03-01-preview' = {
  parent: postgreSqlFlexibleServer_StT5lUao4
  name: 'db'
  properties: {
  }
}

resource postgreSqlFirewallRule_bEwXDlaQZ 'Microsoft.DBforPostgreSQL/flexibleServers/firewallRules@2023-03-01-preview' = {
  parent: postgreSqlFlexibleServer_StT5lUao4
  name: 'fw'
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '255.255.255.255'
  }
}

resource keyVault_NEuaN7OeP 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: p
  location: location
  properties: {
    tenantId: tenant().tenantId
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableRbacAuthorization: true
  }
}

resource keyVaultSecret_ztMuSEPLk 'Microsoft.KeyVault/vaults/secrets@2022-07-01' = {
  parent: keyVault_NEuaN7OeP
  name: 'connectionString'
  location: location
  properties: {
    value: 'Host=${postgreSqlFlexibleServer_StT5lUao4.properties.fullyQualifiedDomainName};Username=${adminLogin};Password=${adminPassword}'
  }
}
