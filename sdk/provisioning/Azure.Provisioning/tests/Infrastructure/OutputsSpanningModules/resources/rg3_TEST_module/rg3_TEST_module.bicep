
resource webSite_Y34mQ7HgU 'Microsoft.Web/sites@2021-02-01' = {
  name: 'frontEnd-TEST'
  location: 'westus'
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1-TEST/providers/Microsoft.Web/serverfarms/appServicePlan-TEST'
    siteConfig: {
      linuxFxVersion: 'node|18-lts'
      alwaysOn: true
      appCommandLine: './entrypoint.sh -o ./env-config.js && pm2 serve /home/site/wwwroot --no-daemon --spa'
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

resource applicationSettingsResource_1XX3wQExf 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_Y34mQ7HgU
  name: 'appsettings'
}

resource webSiteConfigLogs_vhJa9LaNc 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_Y34mQ7HgU
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

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = webSite_Y34mQ7HgU.identity.principalId
