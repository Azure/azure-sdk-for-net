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

    internal static Trycep CreateApiManagementWithApiTest()
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

                infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = apiService.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = apiService.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.apimanagement/api-management-create-all-resources/azuredeploy.json")]
    public async Task CreateApiManagementWithApi()
    {
        await using Trycep test = CreateApiManagementWithApiTest();
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
            }

            resource exampleApi 'Microsoft.ApiManagement/service/apis@2024-05-01' = {
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

            resource exampleProduct 'Microsoft.ApiManagement/service/products@2024-05-01' = {
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

            output name string = apiService.name

            output resourceId string = apiService.id
            """);
    }
}
