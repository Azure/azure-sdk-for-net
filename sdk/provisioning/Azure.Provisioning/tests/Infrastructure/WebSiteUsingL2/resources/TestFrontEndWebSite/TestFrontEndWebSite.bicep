
resource appServicePlan_kjMZSF1FP 'Microsoft.Web/serverfarms@2021-02-01' existing = {
  name: 'appServicePlan_kjMZSF1FP'
}

resource keyVault_CRoMbemLF 'Microsoft.KeyVault/vaults@2023-02-01' existing = {
  name: 'keyVault_CRoMbemLF'
}

resource webSite_5n5qLSHlO 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-mnash-cdk'
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

resource applicationSettingsResource_0dS4jj7Cg 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_5n5qLSHlO
  name: 'appsettings'
}

resource webSiteConfigLogs_PBLecfGMJ 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_5n5qLSHlO
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

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_5n5qLSHlO.identity.principalId
