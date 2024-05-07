// "id": "/subscriptions/d12535ed-5958-4ce6-8350-b17b3af1d6b1/resourceGroups/oro-billing-exhaust-test/providers/Microsoft.HealthDataAIServices/DeidServices/deid-billing-test",
// "name": "deid-billing-test",
// "type": "microsoft.healthdataaiservices/deidservices",
// "location": "East US 2 EUAP",
// "tags": {},
@minLength(3)
param alias string

@minLength(10)
param testUserOid string

@minLength(6)
@maxLength(50)
@description('The base resource name.')
param deidServiceName string = 'deid-dev-sdk-${alias}'

@description('The location of the resource. By default, this is the same as the resource group.')
param deidLocation string = 'eastus2euap'

var realtimeDataUserRoleId = 'bb6577c4-ea0a-40b2-8962-ea18cb8ecd4e'
var batchDataOwnerRoleId = '8a90fa6b-6997-4a07-8a95-30633a7c97b9'

resource testDeidService 'microsoft.healthdataaiservices/deidservices@2023-06-01-preview' = {
  name: deidServiceName
  location: deidLocation
}

resource realtimeRole 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, testDeidService.id, testUserOid, alias, realtimeDataUserRoleId)
  scope: testDeidService
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', realtimeDataUserRoleId)
    principalId: testUserOid
    principalType: 'User'
  }
}

resource batchRole 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(resourceGroup().id, testDeidService.id, testUserOid, alias, batchDataOwnerRoleId)
  scope: testDeidService
  properties: {
    roleDefinitionId: resourceId('Microsoft.Authorization/roleDefinitions', batchDataOwnerRoleId)
    principalId: testUserOid
    principalType: 'User'
  }
}

output DEID_SERVICE_ENDPOINT string = testDeidService.properties.serviceUrl
