@minLength(6)
@maxLength(50)
@description('The base resource name.')
param resourceName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location


resource geoCatalog 'Microsoft.Orbital/geoCatalogs@2024-01-31-preview' = {
  name: resourceName
  location: location
  properties: {
    tier: 'Basic'
  }
}

output PLANETARYCOMPUTER_ENDPOINT string = geoCatalog.properties.catalogUri
