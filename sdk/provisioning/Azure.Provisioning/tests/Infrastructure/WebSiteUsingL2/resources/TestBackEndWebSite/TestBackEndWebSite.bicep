
resource appServicePlan_kjMZSF1FP 'Microsoft.Web/serverfarms@2021-02-01' existing = {
  name: 'appServicePlan_kjMZSF1FP'
}

resource webSite_vYvIqKCDk 'Microsoft.Web/sites@2021-02-01' = {
  name: 'backEnd-mnash-cdk'
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

resource applicationSettingsResource_Ys2FlARU8 'Microsoft.Web/sites/config@2021-02-01' = {
  parent: webSite_vYvIqKCDk
  name: 'appsettings'
  properties: {
    SCM_DO_BUILD_DURING_DEPLOYMENT: 'False'
    ENABLE_ORYX_BUILD: 'True'
  }
}
