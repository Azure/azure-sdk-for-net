@secure()
@description('SQL Server administrator password')
param sqlAdminPassword string

@secure()
@description('Application user password')
param appUserPassword string


resource appServicePlan_kjMZSF1FP 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: 'appServicePlan-TEST'
  location: 'westus'
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
}

resource keyVault_CRoMbemLF 'Microsoft.KeyVault/vaults@2023-02-01' = {
  name: 'kv-TEST'
  location: 'westus'
  tags: {
    key: 'value'
  }
  properties: {
    tenantId: '00000000-0000-0000-0000-000000000000'
    sku: {
      name: 'standard'
      family: 'A'
    }
  }
}

resource keyVaultAddAccessPolicy_OttgS6uaT 'Microsoft.KeyVault/vaults/accessPolicies@2023-02-01' = {
  parent: keyVault_CRoMbemLF
  name: 'add'
  properties: {
    accessPolicies: [
      {
        tenantId: '00000000-0000-0000-0000-000000000000'
        objectId: TestFrontEndWebSite.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
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
  scope: resourceGroup_I6QNkoPsb
}

module TestCommonSqlDatabase './resources/TestCommonSqlDatabase/TestCommonSqlDatabase.bicep' = {
  name: 'TestCommonSqlDatabase'
  scope: resourceGroup_I6QNkoPsb
  params: {
    sqlAdminPassword: sqlAdminPassword
    appUserPassword: appUserPassword
  }
}

module TestBackEndWebSite './resources/TestBackEndWebSite/TestBackEndWebSite.bicep' = {
  name: 'TestBackEndWebSite'
  scope: resourceGroup_I6QNkoPsb
}

output SERVICE_API_IDENTITY_PRINCIPAL_ID string = TestFrontEndWebSite.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
