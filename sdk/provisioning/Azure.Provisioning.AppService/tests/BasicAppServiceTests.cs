// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.ApplicationInsights;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppService.Tests;

public class BasicAppServiceTests
{
    internal static Trycep CreateBasicFunctionAppTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AppServiceBasic
                Infrastructure infra = new();

                StorageAccount storage =
                    new(nameof(storage))
                    {
                        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                        Kind = StorageKind.Storage,
                        EnableHttpsTrafficOnly = true,
                        IsDefaultToOAuthAuthentication = true
                    };
                infra.Add(storage);

                AppServicePlan hostingPlan =
                    new(nameof(hostingPlan), "2021-03-01")
                    {
                        Sku =
                            new AppServiceSkuDescription
                            {
                                Tier = "Dynamic",
                                Name = "Y1"
                            }
                    };
                infra.Add(hostingPlan);

                ApplicationInsightsComponent appInsights =
                    new(nameof(appInsights))
                    {
                        Kind = "web",
                        ApplicationType = ApplicationInsightsApplicationType.Web,
                        RequestSource = ComponentRequestSource.Rest
                    };
                infra.Add(appInsights);

                ProvisioningVariable funcAppName =
                    new(nameof(funcAppName), typeof(string))
                    {
                        Value = BicepFunction.Concat("functionApp-", BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id))
                    };
                infra.Add(funcAppName);

                WebSite functionApp =
                    new(nameof(functionApp), WebSite.ResourceVersions.V2023_12_01)
                    {
                        Name = funcAppName,
                        Kind = "functionapp",
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                        AppServicePlanId = hostingPlan.Id,
                        IsHttpsOnly = true,
                        SiteConfig =
                            new SiteConfigProperties
                            {
                                FtpsState = AppServiceFtpsState.FtpsOnly,
                                MinTlsVersion = AppServiceSupportedTlsVersion.Tls1_2,
                                AppSettings =
                                {
                                    new AppServiceNameValuePair
                                    {
                                        Name = "AzureWebJobsStorage",
                                        Value = BicepFunction.Interpolate($"DefaultEndpointsProtocol=https;AccountName={storage.Name};EndpointSuffix=core.windows.net;AccountKey={storage.GetKeys()[0].Unwrap().Value}")
                                    },
                                    new AppServiceNameValuePair
                                    {
                                        Name = "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING",
                                        Value = BicepFunction.Interpolate($"DefaultEndpointsProtocol=https;AccountName={storage.Name};EndpointSuffix=core.windows.net;AccountKey={storage.GetKeys()[0].Unwrap().Value}")
                                    },
                                    new AppServiceNameValuePair
                                    {
                                        Name = "WEBSITE_CONTENTSHARE",
                                        Value = BicepFunction.ToLower(funcAppName)
                                    },
                                    new AppServiceNameValuePair
                                    {
                                        Name = "FUNCTIONS_EXTENSION_VERSION",
                                        Value = "~4"
                                    },
                                    new AppServiceNameValuePair
                                    {
                                        Name = "WEBSITE_NODE_DEFAULT_VERSION",
                                        Value = "~14"
                                    },
                                    new AppServiceNameValuePair
                                    {
                                        Name = "FUNCTIONS_WORKER_RUNTIME",
                                        Value = "dotnet"
                                    },
                                    new AppServiceNameValuePair
                                    {
                                        Name = "APPINSIGHTS_INSTRUMENTATIONKEY",
                                        Value = appInsights.InstrumentationKey
                                    }
                                }
                            }
                    };
                infra.Add(functionApp);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.web/function-app-create-dynamic/main.bicep")]
    public async Task CreateBasicFunctionApp()
    {
        await using Trycep test = CreateBasicFunctionAppTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource storage 'Microsoft.Storage/storageAccounts@2024-01-01' = {
              name: take('storage${uniqueString(resourceGroup().id)}', 24)
              kind: 'Storage'
              location: location
              sku: {
                name: 'Standard_LRS'
              }
              properties: {
                supportsHttpsTrafficOnly: true
                defaultToOAuthAuthentication: true
              }
            }

            resource hostingPlan 'Microsoft.Web/serverfarms@2021-03-01' = {
              name: take('hostingPlan-${uniqueString(resourceGroup().id)}', 60)
              location: location
              sku: {
                name: 'Y1'
                tier: 'Dynamic'
              }
            }

            resource appInsights 'Microsoft.Insights/components@2020-02-02' = {
              name: take('appInsights-${uniqueString(resourceGroup().id)}', 260)
              kind: 'web'
              location: location
              properties: {
                Application_Type: 'web'
                Request_Source: 'rest'
              }
            }

            var funcAppName = concat('functionApp-', uniqueString(resourceGroup().id))

            resource functionApp 'Microsoft.Web/sites@2023-12-01' = {
              name: funcAppName
              location: location
              properties: {
                serverFarmId: hostingPlan.id
                httpsOnly: true
                siteConfig: {
                  appSettings: [
                    {
                      name: 'AzureWebJobsStorage'
                      value: 'DefaultEndpointsProtocol=https;AccountName=${storage.name};EndpointSuffix=core.windows.net;AccountKey=${storage.listKeys().keys[0].value}'
                    }
                    {
                      name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
                      value: 'DefaultEndpointsProtocol=https;AccountName=${storage.name};EndpointSuffix=core.windows.net;AccountKey=${storage.listKeys().keys[0].value}'
                    }
                    {
                      name: 'WEBSITE_CONTENTSHARE'
                      value: toLower(funcAppName)
                    }
                    {
                      name: 'FUNCTIONS_EXTENSION_VERSION'
                      value: '~4'
                    }
                    {
                      name: 'WEBSITE_NODE_DEFAULT_VERSION'
                      value: '~14'
                    }
                    {
                      name: 'FUNCTIONS_WORKER_RUNTIME'
                      value: 'dotnet'
                    }
                    {
                      name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
                      value: appInsights.properties.InstrumentationKey
                    }
                  ]
                  minTlsVersion: '1.2'
                  ftpsState: 'FtpsOnly'
                }
              }
              identity: {
                type: 'SystemAssigned'
              }
              kind: 'functionapp'
            }
            """);
    }
}
