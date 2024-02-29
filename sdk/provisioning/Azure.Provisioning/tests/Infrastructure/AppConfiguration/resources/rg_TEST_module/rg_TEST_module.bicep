
resource appConfigurationStore_2XW2ltqza 'Microsoft.AppConfiguration/configurationStores@2023-03-01' = {
  name: 'store-TEST'
  location: 'westus'
  sku: {
    name: 'free'
  }
  properties: {
  }
}

output appConfigurationStore_2XW2ltqza_endpoint string = appConfigurationStore_2XW2ltqza.properties.endpoint
