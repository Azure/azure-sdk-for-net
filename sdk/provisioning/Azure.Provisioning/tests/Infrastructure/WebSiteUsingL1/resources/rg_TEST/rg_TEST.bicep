@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string = 'password'

@secure()
@description('Application user password')
param appUserPassword string = 'password'


resource appServicePlan_kjMZSF1FP 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: 'appServicePlan-TEST'
  location: 'westus'
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource webSite_W5EweSXEq 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-TEST'
  location: 'westus'
  identity: {
  }
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
    siteConfig: {
      linuxFxVersion: 'node|18-lts'
      alwaysOn: true
      appCommandLine: './entrypoint.sh -o ./env-config.js && pm2 serve /home/site/wwwroot --no-daemon --spa'
      experiments: {
      }
      cors: {
        allowedOrigins: [
          'https://portal.azure.com'
          'https://ms.portal.azure.com'
        ]
      }
      minTlsVersion: '1.2'
      ftpsState: 'FtpsOnly'
    }
    httpsOnly: true
  }
}

resource applicationSettingsResource_9BG7vUQd2 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_W5EweSXEq
  name: 'appsettings'
}

resource webSiteConfigLogs_giqxapQs0 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_W5EweSXEq
  name: 'logs'
  properties: {
    applicationLogs: {
      fileSystem: {
        level: 'Verbose'
      }
    }
    httpLogs: {
      fileSystem: {
        retentionInMb: 35
        retentionInDays: 1
        enabled: true
      }
    }
    failedRequestsTracing: {
      enabled: true
    }
    detailedErrorMessages: {
      enabled: true
    }
  }
}

resource keyVault_CRoMbemLF 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: 'kv-TEST'
  location: 'westus'
  properties: {
    tenantId: '00000000-0000-0000-0000-000000000000'
    sku: {
      name: 'standard'
      family: 'A'
    }
    enableRbacAuthorization: true
  }
}

resource keyVaultAddAccessPolicy_NWCGclP20 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'add'
  properties: {
    accessPolicies: [
      {
        tenantId: '00000000-0000-0000-0000-000000000000'
        objectId: webSite_W5EweSXEq.identity.principalId
        permissions: {
          secrets: [
            'get'
            'list'
          ]
        }
      }
    ]
  }
}

resource keyVaultSecret_NmXfhaHvM 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'sqlAdminPassword-TEST'
  properties: {
    value: sqlAdminPassword
  }
}

resource keyVaultSecret_QRsiyFBMe 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'appUserPassword-TEST'
  properties: {
    value: appUserPassword
  }
}

resource keyVaultSecret_7eiFxkj0r 'Microsoft.KeyVault/vaults/secrets@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'connectionString-TEST'
  properties: {
    value: 'Server=${sqlServer_zjdvvB2wl.properties.fullyQualifiedDomainName}; Database=${sqlDatabase_U7NzorRJT.name}; User=appUser; Password=${appUserPassword}'
  }
}

resource sqlServer_zjdvvB2wl 'Microsoft.Sql/servers@2022-08-01-preview' = {
  name: 'sqlserver-TEST'
  location: 'westus'
  properties: {
    administratorLogin: 'sqladmin'
    administratorLoginPassword: sqlAdminPassword
    version: '12.0'
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDatabase_U7NzorRJT 'Microsoft.Sql/servers/databases@2022-08-01-preview' = {
  parent: sqlServer_zjdvvB2wl
  name: 'db-TEST'
  location: 'westus'
  properties: {
  }
}

resource sqlFirewallRule_eS4m8st65 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  parent: sqlServer_zjdvvB2wl
  name: 'firewallRule-TEST'
  properties: {
    startIpAddress: '0.0.0.1'
    endIpAddress: '255.255.255.254'
  }
}

resource deploymentScript_3Zq2Pl8xa 'Microsoft.Resources/deploymentScripts@2020-10-01' = {
  name: 'cliScript-TEST'
  location: 'westus'
  kind: 'AzureCLI'
  properties: {
    cleanupPreference: 'OnSuccess'
    scriptContent: '''
wget https://github.com/microsoft/go-sqlcmd/releases/download/v0.8.1/sqlcmd-v0.8.1-linux-x64.tar.bz2
tar x -f sqlcmd-v0.8.1-linux-x64.tar.bz2 -C .
cat <<SCRIPT_END > ./initDb.sql
drop user ${APPUSERNAME}
go
create user ${APPUSERNAME} with password = '${APPUSERPASSWORD}'
go
alter role db_owner add member ${APPUSERNAME}
go
SCRIPT_END
./sqlcmd -S ${DBSERVER} -d ${DBNAME} -U ${SQLADMIN} -i ./initDb.sql'''
    environmentVariables: [
      {
        name: 'APPUSERNAME'
        value: 'appUser'
      }
      {
        name: 'APPUSERPASSWORD'
        secureValue: '_p_.appUserPassword'
      }
      {
        name: 'DBNAME'
        value: '_p_.sqlDatabase_U7NzorRJT.name'
      }
      {
        name: 'DBSERVER'
        value: '_p_.sqlServer_zjdvvB2wl.properties.fullyQualifiedDomainName'
      }
      {
        name: 'SQLCMDPASSWORD'
        secureValue: '_p_.sqlAdminPassword'
      }
      {
        name: 'SQLADMIN'
        value: 'sqlAdmin'
      }
    ]
    retentionInterval: 'PT1H'
    timeout: 'PT5M'
    azCliVersion: '2.37.0'
  }
}

resource webSite_4pzZqR2OO 'Microsoft.Web/sites@2021-02-01' = {
  name: 'backEnd-TEST'
  location: 'westus'
  identity: {
  }
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
    siteConfig: {
      linuxFxVersion: 'dotnetcore|6.0'
      alwaysOn: true
      appCommandLine: ''
      experiments: {
      }
      cors: {
        allowedOrigins: [
          'https://portal.azure.com'
          'https://ms.portal.azure.com'
        ]
      }
      minTlsVersion: '1.2'
      ftpsState: 'FtpsOnly'
    }
    httpsOnly: true
  }
}

resource applicationSettingsResource_vEe46o8Zn 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_4pzZqR2OO
  name: 'appsettings'
  properties: {
    'SCM_DO_BUILD_DURING_DEPLOYMENT': 'False'
    'ENABLE_ORYX_BUILD': 'True'
  }
}

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_W5EweSXEq.identity.principalId
output vaultUri string = keyVault_CRoMbemLF.properties.vaultUri
