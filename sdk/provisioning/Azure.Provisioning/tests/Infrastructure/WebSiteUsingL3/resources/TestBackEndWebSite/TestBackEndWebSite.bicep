
resource appServicePlan_zDVZJZSeJ 'Microsoft.Web/serverfarms@2021-02-01' existing = {
  name: 'appServicePlan_zDVZJZSeJ'
}

resource webSite_bbXnyuYEl 'Microsoft.Web/sites@2021-02-01' = {
  name: 'backEnd-mnash-cdk'
  location: 'westus'
  identity: {
  }
  kind: 'app,linux'
  properties: {
    serverFarmId: '/subscriptions/faa080af-c1d8-40ad-9cce-e1a450ca5b57/resourceGroups/rg-mnash-cdk/providers/Microsoft.Web/serverfarms/appServicePlan-mnash-cdk'
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

resource applicationSettingsResource_6U6Xi0A5f 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_bbXnyuYEl
  name: 'appsettings'
  properties: {
    SCM_DO_BUILD_DURING_DEPLOYMENT: 'False'
    ENABLE_ORYX_BUILD: 'True'
  }
}
