// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.WebPubSub.Tests;

public class BasicWebPubSubTests
{
    internal static Trycep CreateSimpleWebPubSubTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:WebPubSubBasic
                Infrastructure infra = new();

                WebPubSubService webpubsub =
                    new(nameof(webpubsub), "2021-10-01")
                    {
                        Sku =
                            new BillingInfoSku
                            {
                                Name = "Free_F1",
                                Tier = WebPubSubSkuTier.Free,
                                Capacity = 1
                            },
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.None },
                        IsAadAuthDisabled = false,
                        IsLocalAuthDisabled = false,
                        LiveTraceConfiguration =
                            new LiveTraceConfiguration
                            {
                                IsEnabled = "false",
                                Categories =
                                {
                                    new LiveTraceCategory { Name = "ConnectivityLogs", IsEnabled = "false" },
                                    new LiveTraceCategory { Name = "MessagingLogs", IsEnabled = "false" },
                                }
                            },
                        NetworkAcls =
                            new WebPubSubNetworkAcls
                            {
                                DefaultAction = AclAction.Deny,
                                PublicNetwork =
                                    new PublicNetworkAcls
                                    {
                                        Allow =
                                        {
                                            WebPubSubRequestType.ServerConnection,
                                            WebPubSubRequestType.ClientConnection,
                                            WebPubSubRequestType.RestApi,
                                            WebPubSubRequestType.Trace
                                        }
                                    }
                            },
                        PublicNetworkAccess = "Enabled",
                        ResourceLogCategories =
                        {
                            new ResourceLogCategory { Enabled = "true", Name = "ConnectivityLogs" },
                            new ResourceLogCategory { Enabled = "true", Name = "MessagingLogs" },
                        },
                        IsClientCertEnabled = false
                    };

                infra.Add(webpubsub);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.web/azure-web-pubsub/main.bicep")]
    public async Task CreateSimpleWebPubSub()
    {
        await using Trycep test = CreateSimpleWebPubSubTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource webpubsub 'Microsoft.SignalRService/webPubSub@2021-10-01' = {
              name: take('webpubsub-${uniqueString(resourceGroup().id)}', 63)
              location: location
              identity: {
                type: 'None'
              }
              properties: {
                disableAadAuth: false
                tls: {
                  clientCertEnabled: false
                }
                disableLocalAuth: false
                liveTraceConfiguration: {
                  enabled: 'false'
                  categories: [
                    {
                      name: 'ConnectivityLogs'
                      enabled: 'false'
                    }
                    {
                      name: 'MessagingLogs'
                      enabled: 'false'
                    }
                  ]
                }
                networkACLs: {
                  defaultAction: 'Deny'
                  publicNetwork: {
                    allow: [
                      'ServerConnection'
                      'ClientConnection'
                      'RESTAPI'
                      'Trace'
                    ]
                  }
                }
                publicNetworkAccess: 'Enabled'
                resourceLogConfiguration: {
                  categories: [
                    {
                      name: 'ConnectivityLogs'
                      enabled: 'true'
                    }
                    {
                      name: 'MessagingLogs'
                      enabled: 'true'
                    }
                  ]
                }
              }
              sku: {
                name: 'Free_F1'
                tier: 'Free'
                capacity: 1
              }
            }
            """);
    }
}
