@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The tenant ID to which the application and resources belong.')
param tenantId string

@description('The client OID to grant access to test resources.')
param testApplicationOid string

@description('The client displayName to grant Azure AD admin permissions to databases')
param testApplicationServicePrincipal string

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('Current IP address of the client.')
param clientIpAddress string

@secure()
@description('MySQL password')
param mysqlPassword string

resource keyVault 'Microsoft.KeyVault/vaults@2019-09-01' = {
  name: baseName
  location: location
  properties: {
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: tenantId
    accessPolicies: [
      {
        tenantId: tenantId
        objectId: testApplicationOid
        permissions: {
          keys: [
            'get'
            'list'
            'update'
            'create'
            'import'
            'delete'
            'recover'
            'backup'
            'restore'
            'decrypt'
            'encrypt'
            'unwrapKey'
            'wrapKey'
            'verify'
            'sign'
            'purge'
          ]
          secrets: [
            'get'
            'list'
            'set'
            'delete'
            'recover'
            'backup'
            'restore'
            'purge'
          ]
          certificates: [
            'get'
            'list'
            'update'
            'create'
            'import'
            'delete'
            'recover'
            'backup'
            'restore'
            'managecontacts'
            'manageissuers'
            'getissuers'
            'listissuers'
            'setissuers'
            'deleteissuers'
            'purge'
          ]
        }
      }
    ]
    enabledForDeployment: false
    enabledForDiskEncryption: false
    enabledForTemplateDeployment: false
    enableSoftDelete: true
  }
}

resource blobAcount 'Microsoft.Storage/storageAccounts@2019-04-01' = {
  name: baseName
  location: location
  sku: {
    name: 'Standard_RAGRS'
  }
  kind: 'StorageV2'
  properties: {
    supportsHttpsTrafficOnly: true
    accessTier: 'Hot'
  }
}

var blobDataContributorRole = 'ba92f5b4-2d11-453d-a403-e96b0029c9fe'
resource blobContributorAssignment 'Microsoft.Authorization/roleAssignments@2018-09-01-preview' = {
  name: guid(resourceGroup().id, testApplicationOid, blobDataContributorRole)
  scope: resourceGroup()
  properties: {
    principalId: testApplicationOid
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', blobDataContributorRole)
  }
}

resource postgresServer 'Microsoft.DBforPostgreSQL/flexibleServers@2022-12-01' = {
  name: baseName
  location: location
  sku: {
    name: 'Standard_B1ms'
    tier: 'Burstable'
  }
  properties: {
    version: '14'
    authConfig: {
      activeDirectoryAuth: 'Enabled'
      passwordAuth: 'Disabled'
      tenantId: tenantId
    }

    storage: {
      storageSizeGB: 32
    }
    highAvailability: {
      mode: 'Disabled'
    }
  }

  resource database 'databases' = {
    name: 'passwordless'
  }
}

resource postgresAdmin 'Microsoft.DBforPostgreSQL/flexibleServers/administrators@2022-12-01' = {
  name: testApplicationOid
  parent: postgresServer
  properties: {
    principalType: 'SERVICEPRINCIPAL'
    principalName: testApplicationServicePrincipal
    tenantId: tenantId
  }
}

resource postgresFirewall 'Microsoft.DBforPostgreSQL/flexibleServers/firewallRules@2022-12-01' = {
  name: 'allow-tests-client-ip'
  parent: postgresServer
  properties: {
    startIpAddress: clientIpAddress
    endIpAddress: clientIpAddress
  }
}

resource mysqlIdentityService 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
  name: baseName
  location: location
}

resource mysqlServer 'Microsoft.DBforMySQL/flexibleServers@2021-12-01-preview' = {
  location: location
  name: baseName
  sku: {
    name: 'Standard_B1ms'
    tier: 'Burstable'
  }
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${mysqlIdentityService.id}': {}
    }
  }
  properties: {
    version: '8.0.21'
    administratorLogin: 'mydemoadmin'
    administratorLoginPassword: mysqlPassword
    availabilityZone: '1'
    highAvailability: {
      mode: 'Disabled'
      standbyAvailabilityZone: '2'
    }
    storage: {
      storageSizeGB: 32
      iops: 360
      autoGrow: 'Disabled'
    }
    backup: {
      backupRetentionDays: 7
      geoRedundantBackup: 'Disabled'
    }
  }
  resource database 'databases' = {
    name: 'passwordless'
  }
}

resource aad_auth_only 'Microsoft.DBforMySQL/flexibleServers/configurations@2021-12-01-preview' = {
  name: 'aad_auth_only'
  parent: mysqlServer
  properties: {
    value: 'ON'
    source: 'user-override'
  }
  dependsOn: [
    mysqladmin
  ]
}

resource mysqladmin 'Microsoft.DBforMySQL/flexibleServers/administrators@2021-12-01-preview' = {
  name: 'ActiveDirectory'
  parent: mysqlServer
  properties: {
    administratorType: 'ActiveDirectory'
    identityResourceId: mysqlIdentityService.id
    login: testApplicationServicePrincipal
    sid: testApplicationOid
    tenantId: tenantId
  }
}

resource mysqlFirewall 'Microsoft.DBforMySQL/flexibleServers/firewallRules@2022-01-01' = {
  name: 'allow-tests-client-ip'
  parent: mysqlServer
  properties: {
    startIpAddress: clientIpAddress
    endIpAddress: clientIpAddress
  }
}

output AZURE_KEYVAULT_URL string = keyVault.properties.vaultUri
output BLOB_STORAGE_ENDPOINT string = blobAcount.properties.primaryEndpoints.blob
output POSTGRES_FQDN string = postgresServer.properties.fullyQualifiedDomainName
output POSTGRES_NAME string = postgresServer.name
output POSTGRES_SERVER_ADMIN string = postgresAdmin.properties.principalName
output MYSQL_FQDN string = mysqlServer.properties.fullyQualifiedDomainName
output MYSQL_NAME string = mysqlServer.name
output MYSQL_SERVER_ADMIN string = mysqladmin.properties.login
