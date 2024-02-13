targetScope = subscription

@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource resourceGroup_IABVtvgDt 'Microsoft.Resources/resourceGroups@2023-07-01' = {
  name: 'rg-mnash-cdk'
  location: 'westus'
  tags: {
    azd-env-name: 'mnash-cdk'
    key: 'value'
  }
}

resource appServicePlan_zDVZJZSeJ 'Microsoft.Web/serverfarms@2021-02-01' = {
  scope: resourceGroup_IABVtvgDt
  name: 'appServicePlan-mnash-cdk'
  location: 'westus'
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource keyVault_n6Xn70PzJ 'Microsoft.KeyVault/vaults@2023-02-01' = {
  scope: resourceGroup_IABVtvgDt
  name: 'kv-mnash-cdk'
  location: 'westus'
  properties: {
    tenantId: '00000000-0000-0000-0000-000000000000'
    sku: {
      name: 'standard'
      family: 'A'
    }
  }
}

resource keyVaultAddAccessPolicy_pzaknyGaJ 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_n6Xn70PzJ
  name: 'add'
  properties: {
    accessPolicies: [
      {
        tenantId: '72f988bf-86f1-41af-91ab-2d7cd011db47'
        objectId: 'TestFrontEndWebSite.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID'
        permissions: {
          secrets: [
            'get'
            'list'
          ]
        }
      }
    ]
  }
}

module TestFrontEndWebSite './resources/TestFrontEndWebSite/TestFrontEndWebSite.bicep' = {
  name: 'TestFrontEndWebSite'
  scope: resourceGroup_IABVtvgDt
}

module TestCommonSqlDatabase './resources/TestCommonSqlDatabase/TestCommonSqlDatabase.bicep' = {
  name: 'TestCommonSqlDatabase'
  scope: resourceGroup_IABVtvgDt
  params: {
    sqlAdminPassword: sqlAdminPassword
    appUserPassword: appUserPassword
  }
}

module TestBackEndWebSite './resources/TestBackEndWebSite/TestBackEndWebSite.bicep' = {
  name: 'TestBackEndWebSite'
  scope: resourceGroup_IABVtvgDt
}

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = TestFrontEndWebSite.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
