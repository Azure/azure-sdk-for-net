
resource appConfigurationStore_4WdTZ5u6X 'Microsoft.AppConfiguration/configurationStores@2023-03-01' = {
  name: toLower(take(concat('store', uniqueString(resourceGroup().id)), 24))
  location: 'westus'
  sku: {
    name: 'free'
  }
  properties: {
  }
}

output appConfigurationStore_4WdTZ5u6X_endpoint string = appConfigurationStore_4WdTZ5u6X.properties.endpoint
