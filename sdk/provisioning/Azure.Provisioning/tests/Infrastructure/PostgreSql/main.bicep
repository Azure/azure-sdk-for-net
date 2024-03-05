targetScope = 'resourceGroup'

@description('')
param location string = resourceGroup().location

@description('Administrator login')
param adminLogin string

@secure()
@description('Administrator password')
param adminPassword string

@description('')
param p string = 'name'


resource postgreSqlFlexibleServer_mZ8PC2Gce 'Microsoft.DBforPostgreSQL/flexibleServers@2020-06-01' = {
  name: toLower(take(concat('postgres', uniqueString(resourceGroup().id)), 24))
  location: location
  properties: {
    administratorLogin: adminLogin
    administratorLoginPassword: adminPassword
    backup: {
      backupRetentionDays: 7
      geoRedundantBackup: 'Disabled'
    }
    highAvailability: {
      mode: 'haMode'
    }
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
