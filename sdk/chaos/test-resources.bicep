param location string = resourceGroup().location

param baseName string = resourceGroup().name

@batchSize(1)
module createVmss './vmss.bicep' = [for i in range(0, 2): {
  name: 'createVmss${i}'
  params: {
    location: location
    baseName: baseName
    vmssId: '${i}'
  }
}]
