// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ApiManagement.Tests;

public class BasicApiManagementTests
{
    internal static Trycep CreateApiManagementWithMsiTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ApiManagementBasic
                Infrastructure infra = new();

                ProvisioningParameter publisherEmail =
                    new(nameof(publisherEmail), typeof(string))
                    {
                        Description = "The email address of the owner of the service."
                    };
                infra.Add(publisherEmail);

                ProvisioningParameter publisherName =
                    new(nameof(publisherName), typeof(string))
                    {
                        Description = "The name of the owner of the service."
                    };
                infra.Add(publisherName);

                ApiManagementService apiService =
                    new(nameof(apiService), ApiManagementService.ResourceVersions.V2024_05_01)
                    {
                        Sku = new ApiManagementServiceSkuProperties
                        {
                            Name = ApiManagementServiceSkuType.Developer,
                            Capacity = 1
                        },
                        PublisherEmail = publisherEmail,
                        PublisherName = publisherName,
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                        }
                    };
                infra.Add(apiService);

                infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = apiService.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = apiService.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.apimanagement/api-management-create-with-msi/main.bicep")]
    public async Task CreateApiManagementWithMsi()
    {
        await using Trycep test = CreateApiManagementWithMsiTest();
        test.Compare(
            """
            @description('The email address of the owner of the service.')
            param publisherEmail string

            @description('The name of the owner of the service.')
            param publisherName string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource apiService 'Microsoft.ApiManagement/service@2024-05-01' = {
              name: take('apiservice${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                publisherEmail: publisherEmail
                publisherName: publisherName
              }
              sku: {
                name: 'Developer'
                capacity: 1
              }
              identity: {
                type: 'SystemAssigned'
              }
            }

            output name string = apiService.name

            output resourceId string = apiService.id
            """);
    }

    internal static Trycep CreateApiManagementWithAllResourcesTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ApiManagementWithApi
                Infrastructure infra = new();

                ProvisioningParameter publisherEmail =
                    new(nameof(publisherEmail), typeof(string))
                    {
                        Description = "The email address of the owner of the service."
                    };
                infra.Add(publisherEmail);

                ProvisioningParameter publisherName =
                    new(nameof(publisherName), typeof(string))
                    {
                        Description = "The name of the owner of the service."
                    };
                infra.Add(publisherName);

                ProvisioningParameter tenantPolicy =
                    new(nameof(tenantPolicy), typeof(string)) { Description = "Tenant policy XML." };
                infra.Add(tenantPolicy);

                ProvisioningParameter apiPolicy =
                    new(nameof(apiPolicy), typeof(string)) { Description = "API policy XML." };
                infra.Add(apiPolicy);

                ProvisioningParameter operationPolicy =
                    new(nameof(operationPolicy), typeof(string)) { Description = "Operation policy XML." };
                infra.Add(operationPolicy);

                ProvisioningParameter productPolicy =
                    new(nameof(productPolicy), typeof(string)) { Description = "Product policy XML." };
                infra.Add(productPolicy);

                // Service
                ApiManagementService apiService =
                    new(nameof(apiService), ApiManagementService.ResourceVersions.V2024_05_01)
                    {
                        Sku = new ApiManagementServiceSkuProperties
                        {
                            Name = ApiManagementServiceSkuType.Developer,
                            Capacity = 1
                        },
                        PublisherEmail = publisherEmail,
                        PublisherName = publisherName
                    };
                infra.Add(apiService);

                // Tenant policy
                ApiManagementPolicy tenantPolicyResource =
                    new("tenantPolicyResource", ApiManagementPolicy.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        Value = tenantPolicy
                    };
                infra.Add(tenantPolicyResource);

                // API
                ApiManagementApi exampleApi =
                    new("exampleApi", ApiManagementApi.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        DisplayName = "Example API Name",
                        Description = "Description for example API",
                        Path = "exampleapipath",
                        Protocols = { ApiOperationInvokableProtocol.Https }
                    };
                infra.Add(exampleApi);

                // Operations
                ApiOperation exampleOperationDelete =
                    new("exampleOperationDelete", ApiOperation.ResourceVersions.V2024_05_01)
                    {
                        Parent = exampleApi,
                        DisplayName = "DELETE resource",
                        Method = "DELETE",
                        UriTemplate = "/resource",
                        Description = "A demonstration of a DELETE call"
                    };
                infra.Add(exampleOperationDelete);

                ApiOperation exampleOperationGet =
                    new("exampleOperationGet", ApiOperation.ResourceVersions.V2024_05_01)
                    {
                        Parent = exampleApi,
                        DisplayName = "GET resource",
                        Method = "GET",
                        UriTemplate = "/resource",
                        Description = "A demonstration of a GET call"
                    };
                infra.Add(exampleOperationGet);

                // Operation policy
                ApiOperationPolicy exampleOperationGetPolicy =
                    new("exampleOperationGetPolicy", ApiOperationPolicy.ResourceVersions.V2024_05_01)
                    {
                        Parent = exampleOperationGet,
                        Value = operationPolicy
                    };
                infra.Add(exampleOperationGetPolicy);

                // API with policy
                ApiManagementApi exampleApiWithPolicy =
                    new("exampleApiWithPolicy", ApiManagementApi.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        DisplayName = "Example API Name with Policy",
                        Description = "Description for example API with policy",
                        Path = "exampleapiwithpolicypath",
                        Protocols = { ApiOperationInvokableProtocol.Https }
                    };
                infra.Add(exampleApiWithPolicy);

                ApiPolicy exampleApiWithPolicyPolicy =
                    new("exampleApiWithPolicyPolicy", ApiPolicy.ResourceVersions.V2024_05_01)
                    {
                        Parent = exampleApiWithPolicy,
                        Value = apiPolicy
                    };
                infra.Add(exampleApiWithPolicyPolicy);

                // Product with policy
                ApiManagementProduct exampleProduct =
                    new("exampleProduct", ApiManagementProduct.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        DisplayName = "Example Product Name",
                        Description = "Description for example product",
                        IsSubscriptionRequired = true,
                        IsApprovalRequired = false,
                        SubscriptionsLimit = 1,
                        State = ApiManagementProductState.Published
                    };
                infra.Add(exampleProduct);

                ApiManagementProductPolicy exampleProductPolicy =
                    new("exampleProductPolicy", ApiManagementProductPolicy.ResourceVersions.V2024_05_01)
                    {
                        Parent = exampleProduct,
                        Value = productPolicy
                    };
                infra.Add(exampleProductPolicy);

                // Users
                ApiManagementUser exampleUser1 =
                    new("exampleUser1", ApiManagementUser.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        FirstName = "ExampleFirstName1",
                        LastName = "ExampleLastName1",
                        Email = "examplefirst1@example.com",
                        State = ApiManagementUserState.Active,
                        Note = "note for example user 1"
                    };
                infra.Add(exampleUser1);

                ApiManagementUser exampleUser2 =
                    new("exampleUser2", ApiManagementUser.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        FirstName = "ExampleFirstName2",
                        LastName = "ExampleLastName2",
                        Email = "examplefirst2@example.com",
                        State = ApiManagementUserState.Active,
                        Note = "note for example user 2"
                    };
                infra.Add(exampleUser2);

                // Named value
                ApiManagementNamedValue exampleNamedValue =
                    new("exampleNamedValue", ApiManagementNamedValue.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        DisplayName = "propertyExampleName",
                        Value = "propertyExampleValue",
                        Tags = { "exampleTag" }
                    };
                infra.Add(exampleNamedValue);

                // Group
                ApiManagementGroup exampleGroup =
                    new("exampleGroup", ApiManagementGroup.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        DisplayName = "Example Group Name",
                        Description = "Example group description"
                    };
                infra.Add(exampleGroup);

                // OpenId Connect provider
                ApiManagementOpenIdConnectProvider exampleOpenIdConnectProvider =
                    new("exampleOpenIdConnectProvider", ApiManagementOpenIdConnectProvider.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        DisplayName = "exampleOpenIdConnectProviderName",
                        Description = "Description for example OpenId Connect provider",
                        MetadataEndpoint = "https://example-openIdConnect-url.net",
                        ClientId = "exampleClientId"
                    };
                infra.Add(exampleOpenIdConnectProvider);

                // Logger
                ApiManagementLogger exampleLogger =
                    new("exampleLogger", ApiManagementLogger.ResourceVersions.V2024_05_01)
                    {
                        Parent = apiService,
                        LoggerType = LoggerType.AzureEventHub,
                        Description = "Description for example logger"
                    };
                infra.Add(exampleLogger);

                infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = apiService.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = apiService.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.apimanagement/api-management-create-all-resources/azuredeploy.json")]
    public async Task CreateApiManagementWithAllResources()
    {
        await using Trycep test = CreateApiManagementWithAllResourcesTest();
        test.Compare(
            """
            @description('The email address of the owner of the service.')
            param publisherEmail string

            @description('The name of the owner of the service.')
            param publisherName string

            @description('Tenant policy XML.')
            param tenantPolicy string

            @description('API policy XML.')
            param apiPolicy string

            @description('Operation policy XML.')
            param operationPolicy string

            @description('Product policy XML.')
            param productPolicy string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource apiService 'Microsoft.ApiManagement/service@2024-05-01' = {
              name: take('apiservice${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                publisherEmail: publisherEmail
                publisherName: publisherName
              }
              sku: {
                name: 'Developer'
                capacity: 1
              }
            }

            resource tenantPolicyResource 'Microsoft.ApiManagement/service/policies@2024-05-01' = {
              name: take('tenantpolicyresource${uniqueString(resourceGroup().id)}', 24)
              properties: {
                value: tenantPolicy
              }
              parent: apiService
            }

            resource exampleApi 'Microsoft.ApiManagement/service/apis@2024-05-01' = {
              name: take('exampleapi${uniqueString(resourceGroup().id)}', 24)
              properties: {
                description: 'Description for example API'
                displayName: 'Example API Name'
                path: 'exampleapipath'
                protocols: [
                  'https'
                ]
              }
              parent: apiService
            }

            resource exampleOperationDelete 'Microsoft.ApiManagement/service/apis/operations@2024-05-01' = {
              name: take('exampleoperationdelete${uniqueString(resourceGroup().id)}', 24)
              properties: {
                description: 'A demonstration of a DELETE call'
                displayName: 'DELETE resource'
                method: 'DELETE'
                urlTemplate: '/resource'
              }
              parent: exampleApi
            }

            resource exampleOperationGet 'Microsoft.ApiManagement/service/apis/operations@2024-05-01' = {
              name: take('exampleoperationget${uniqueString(resourceGroup().id)}', 24)
              properties: {
                description: 'A demonstration of a GET call'
                displayName: 'GET resource'
                method: 'GET'
                urlTemplate: '/resource'
              }
              parent: exampleApi
            }

            resource exampleOperationGetPolicy 'Microsoft.ApiManagement/service/apis/operations/policies@2024-05-01' = {
              name: take('exampleoperationgetpolicy${uniqueString(resourceGroup().id)}', 24)
              properties: {
                value: operationPolicy
              }
              parent: exampleOperationGet
            }

            resource exampleApiWithPolicy 'Microsoft.ApiManagement/service/apis@2024-05-01' = {
              name: take('exampleapiwithpolicy${uniqueString(resourceGroup().id)}', 24)
              properties: {
                description: 'Description for example API with policy'
                displayName: 'Example API Name with Policy'
                path: 'exampleapiwithpolicypath'
                protocols: [
                  'https'
                ]
              }
              parent: apiService
            }

            resource exampleApiWithPolicyPolicy 'Microsoft.ApiManagement/service/apis/policies@2024-05-01' = {
              name: take('exampleapiwithpolicypolicy${uniqueString(resourceGroup().id)}', 24)
              properties: {
                value: apiPolicy
              }
              parent: exampleApiWithPolicy
            }

            resource exampleProduct 'Microsoft.ApiManagement/service/products@2024-05-01' = {
              name: take('exampleproduct${uniqueString(resourceGroup().id)}', 24)
              properties: {
                description: 'Description for example product'
                displayName: 'Example Product Name'
                approvalRequired: false
                subscriptionRequired: true
                state: 'published'
                subscriptionsLimit: 1
              }
              parent: apiService
            }

            resource exampleProductPolicy 'Microsoft.ApiManagement/service/products/policies@2024-05-01' = {
              name: take('exampleproductpolicy${uniqueString(resourceGroup().id)}', 24)
              properties: {
                value: productPolicy
              }
              parent: exampleProduct
            }

            resource exampleUser1 'Microsoft.ApiManagement/service/users@2024-05-01' = {
              name: take('exampleuser${uniqueString(resourceGroup().id)}', 24)
              properties: {
                email: 'examplefirst1@example.com'
                firstName: 'ExampleFirstName1'
                lastName: 'ExampleLastName1'
                note: 'note for example user 1'
                state: 'active'
              }
              parent: apiService
            }

            resource exampleUser2 'Microsoft.ApiManagement/service/users@2024-05-01' = {
              name: take('exampleuser${uniqueString(resourceGroup().id)}', 24)
              properties: {
                email: 'examplefirst2@example.com'
                firstName: 'ExampleFirstName2'
                lastName: 'ExampleLastName2'
                note: 'note for example user 2'
                state: 'active'
              }
              parent: apiService
            }

            resource exampleNamedValue 'Microsoft.ApiManagement/service/namedValues@2024-05-01' = {
              name: take('examplenamedvalue${uniqueString(resourceGroup().id)}', 24)
              properties: {
                displayName: 'propertyExampleName'
                tags: [
                  'exampleTag'
                ]
                value: 'propertyExampleValue'
              }
              parent: apiService
            }

            resource exampleGroup 'Microsoft.ApiManagement/service/groups@2024-05-01' = {
              name: take('examplegroup${uniqueString(resourceGroup().id)}', 24)
              properties: {
                description: 'Example group description'
                displayName: 'Example Group Name'
              }
              parent: apiService
            }

            resource exampleOpenIdConnectProvider 'Microsoft.ApiManagement/service/openidConnectProviders@2024-05-01' = {
              name: take('exampleopenidconnectprovider${uniqueString(resourceGroup().id)}', 24)
              properties: {
                clientId: 'exampleClientId'
                description: 'Description for example OpenId Connect provider'
                displayName: 'exampleOpenIdConnectProviderName'
                metadataEndpoint: 'https://example-openIdConnect-url.net'
              }
              parent: apiService
            }

            resource exampleLogger 'Microsoft.ApiManagement/service/loggers@2024-05-01' = {
              name: take('examplelogger${uniqueString(resourceGroup().id)}', 24)
              properties: {
                description: 'Description for example logger'
                loggerType: 'azureEventHub'
              }
              parent: apiService
            }

            output name string = apiService.name

            output resourceId string = apiService.id
            """);
    }
}
