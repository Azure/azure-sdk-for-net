
resource appServicePlan_zDVZJZSeJ 'Microsoft.Web/serverfarms@2021-02-01' existing = {
  name: 'appServicePlan_zDVZJZSeJ'
}

resource keyVault_n6Xn70PzJ 'Microsoft.KeyVault/vaults@2023-02-01' existing = {
  name: 'keyVault_n6Xn70PzJ'
}

resource webSite_kwcoFVmFY 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-mnash-cdk'
  location: 'westus'
  identity: {
  }
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/rg-mnash-cdk/providers/Microsoft.Web/serverfarms/appServicePlan-mnash-cdk'
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

resource applicationSettingsResource_GTzB2G8tg 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_kwcoFVmFY
  name: 'appsettings'
}

resource webSiteConfigLogs_caWaXRSC1 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_kwcoFVmFY
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

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_kwcoFVmFY.identity.principalId
