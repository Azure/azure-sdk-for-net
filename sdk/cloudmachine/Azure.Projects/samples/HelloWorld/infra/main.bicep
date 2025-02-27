targetScope = 'subscription'

param location string

param principalId string

resource rg 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: 'cmbb6fd4658c1340c'
  location: location
}

module project 'project.bicep' = {
  name: 'cm'
  scope: rg
  params: {
    location: location
    principalId: principalId
  }
}