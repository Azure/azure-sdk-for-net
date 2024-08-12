@description('')
param existingAppConfig string


resource appConfigurationStore_4FWfd15sH 'Microsoft.AppConfiguration/configurationStores@2023-03-01' existing = {
  name: existingAppConfig
}
