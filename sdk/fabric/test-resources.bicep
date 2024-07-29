@description('The base resource name.')
param baseName string = resourceGroup().name

@description('The location of the resource. By default, this is the same as the resource group.')
param location string = resourceGroup().location

@description('The location of the resource. By default, this is the same as the resource group.')
param skuTier string = 'Fabric'

resource fabricCapacity 'Microsoft.Fabric/capacities@2023-11-01' = {
  name: baseName
  location: location
  sku: {
      name: 'F2'
      tier: skuTier
  }
  properties: {
    administration: {
        members: [
            'VsavTest@pbiotest.onmicrosoft.com'
        ]
    }
  }
  tags: {
    'azd-env-name': 'TEST'
  }
}

output FABRIC_CAPACITY_ID string = fabricCapacity.id
output FABRIC_CAPACITY_NAME string = fabricCapacity.name

