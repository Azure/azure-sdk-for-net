// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SignalR.Tests;

public class BasicSignalRTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [RecordedTest]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.signalrservice/signalr/main.bicep")]
    public async Task CreateSignalRService()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "The SignalR service location.";

                BicepParameter endpointName = BicepParameter.Create<string>(nameof(endpointName), "mySignalRService.55e432ab-7428-3695-b637-de57b20d40e5");

                SignalRService signalr =
                    new(nameof(signalr), "2022-02-01")
                    {
                        Location = location,
                        Sku = new SignalRResourceSku { Name = "Standard_S1", Capacity = 1 },
                        Kind = SignalRServiceKind.SignalR,
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                        IsClientCertEnabled = false,
                        Features =
                        {
                            new SignalRFeature
                            {
                                Flag = SignalRFeatureFlag.ServiceMode,
                                Value = "Default"
                            },
                            new SignalRFeature
                            {
                                Flag = SignalRFeatureFlag.EnableConnectivityLogs,
                                Value = "true"
                            },
                            new SignalRFeature
                            {
                                Flag = SignalRFeatureFlag.EnableLiveTrace,
                                Value = "true"
                            },
                        },
                        CorsAllowedOrigins = { "*" },
                        NetworkACLs =
                            new SignalRNetworkAcls
                            {
                                DefaultAction = SignalRNetworkAclAction.Deny,
                                PublicNetwork =
                                    new SignalRNetworkAcl
                                    {
                                        Allow = { SignalRRequestType.ClientConnection }
                                    },
                                PrivateEndpoints =
                                {
                                    new SignalRPrivateEndpointAcl
                                    {
                                        Name = endpointName,
                                        Allow = { SignalRRequestType.ServerConnection }
                                    }
                                },
                            },
                        UpstreamTemplates =
                        {
                            new SignalRUpstreamTemplate
                            {
                                CategoryPattern = "*",
                                EventPattern = "connect,disconnect",
                                HubPattern = "*",
                                UrlTemplate = "https://example.com/chat/api/connect"
                            }
                        }
                    };
            })
        .Compare(
            """
            @description('The SignalR service location.')
            param location string = resourceGroup().location

            param endpointName string = 'mySignalRService.55e432ab-7428-3695-b637-de57b20d40e5'

            resource signalr 'Microsoft.SignalRService/signalR@2022-02-01' = {
                name: take('signalr-${uniqueString(resourceGroup().id)}', 63)
                location: location
                properties: {
                    cors: {
                        allowedOrigins: [
                            '*'
                        ]
                    }
                    features: [
                        {
                            flag: 'ServiceMode'
                            value: 'Default'
                        }
                        {
                            flag: 'EnableConnectivityLogs'
                            value: 'true'
                        }
                        {
                            flag: 'EnableLiveTrace'
                            value: 'true'
                        }
                    ]
                    tls: {
                        clientCertEnabled: false
                    }
                    networkACLs: {
                        defaultAction: 'Deny'
                        publicNetwork: {
                            allow: [
                                'ClientConnection'
                            ]
                        }
                        privateEndpoints: [
                            {
                                allow: [
                                    'ServerConnection'
                                ]
                                name: endpointName
                            }
                        ]
                    }
                    upstream: {
                        templates: [
                            {
                                hubPattern: '*'
                                eventPattern: 'connect,disconnect'
                                categoryPattern: '*'
                                urlTemplate: 'https://example.com/chat/api/connect'
                            }
                        ]
                    }
                }
                identity: {
                    type: 'SystemAssigned'
                }
                kind: 'SignalR'
                sku: {
                    name: 'Standard_S1'
                    capacity: 1
                }
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
