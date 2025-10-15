// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.FrontDoor.Tests;

public class BasicFrontDoorTests
{
    internal static Trycep CreateBasicFrontDoorTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:FrontDoorBasic
                Infrastructure infra = new();

                ProvisioningParameter frontDoorName =
                    new(nameof(frontDoorName), typeof(string))
                    {
                        Description = "The name of the frontdoor resource."
                    };
                infra.Add(frontDoorName);

                ProvisioningParameter backendAddress =
                    new(nameof(backendAddress), typeof(string))
                    {
                        Description = "The hostname of the backend. Must be an IP address or FQDN."
                    };
                infra.Add(backendAddress);

                ProvisioningVariable frontEndEndpointName =
                    new(nameof(frontEndEndpointName), typeof(string))
                    {
                        Value = "frontEndEndpoint"
                    };
                infra.Add(frontEndEndpointName);

                ProvisioningVariable loadBalancingSettingsName =
                    new(nameof(loadBalancingSettingsName), typeof(string))
                    {
                        Value = "loadBalancingSettings"
                    };
                infra.Add(loadBalancingSettingsName);

                ProvisioningVariable healthProbeSettingsName =
                    new(nameof(healthProbeSettingsName), typeof(string))
                    {
                        Value = "healthProbeSettings"
                    };
                infra.Add(healthProbeSettingsName);

                ProvisioningVariable routingRuleName =
                    new(nameof(routingRuleName), typeof(string))
                    {
                        Value = "routingRule"
                    };
                infra.Add(routingRuleName);

                ProvisioningVariable backendPoolName =
                    new(nameof(backendPoolName), typeof(string))
                    {
                        Value = "backendPool"
                    };
                infra.Add(backendPoolName);

                FrontDoorResource frontDoor =
                    new(nameof(frontDoor), FrontDoorResource.ResourceVersions.V2021_06_01)
                    {
                        Name = frontDoorName,
                        Location = new AzureLocation("global"),
                        EnabledState = FrontDoorEnabledState.Enabled,
                        FrontendEndpoints =
                        {
                            new FrontendEndpointData
                            {
                                Name = frontEndEndpointName,
                                HostName = BicepFunction.Interpolate($"{frontDoorName}.azurefd.net"),
                                SessionAffinityEnabledState = SessionAffinityEnabledState.Disabled
                            }
                        },
                        LoadBalancingSettings =
                        {
                            new FrontDoorLoadBalancingSettingsData
                            {
                                Name = loadBalancingSettingsName,
                                SampleSize = 4,
                                SuccessfulSamplesRequired = 2
                            }
                        },
                        HealthProbeSettings =
                        {
                            new FrontDoorHealthProbeSettingsData
                            {
                                Name = healthProbeSettingsName,
                                Path = "/",
                                Protocol = FrontDoorProtocol.Http,
                                IntervalInSeconds = 120
                            }
                        },
                        BackendPools =
                        {
                            new FrontDoorBackendPool
                            {
                                Name = backendPoolName,
                                Backends =
                                {
                                    new FrontDoorBackend
                                    {
                                        Address = backendAddress,
                                        BackendHostHeader = backendAddress,
                                        HttpPort = 80,
                                        HttpsPort = 443,
                                        Weight = 50,
                                        Priority = 1,
                                        EnabledState = BackendEnabledState.Enabled
                                    }
                                },
                                LoadBalancingSettingsId = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/loadBalancingSettings"), new IdentifierExpression(frontDoorName.BicepIdentifier), new IdentifierExpression(loadBalancingSettingsName.BicepIdentifier)),
                                HealthProbeSettingsId = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/healthProbeSettings"), new IdentifierExpression(frontDoorName.BicepIdentifier), new IdentifierExpression(healthProbeSettingsName.BicepIdentifier))
                            }
                        },
                        RoutingRules =
                        {
                            new RoutingRuleData
                            {
                                Name = routingRuleName,
                                FrontendEndpoints =
                                {
                                    new WritableSubResource
                                    {
                                        Id = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/frontEndEndpoints"), new IdentifierExpression(frontDoorName.BicepIdentifier), new IdentifierExpression(frontEndEndpointName.BicepIdentifier))
                                    }
                                },
                                AcceptedProtocols = { FrontDoorProtocol.Http, FrontDoorProtocol.Https },
                                PatternsToMatch = { "/*" },
                                RouteConfiguration = new ForwardingConfiguration
                                {
                                    ForwardingProtocol = FrontDoorForwardingProtocol.MatchRequest,
                                    BackendPoolId = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/backEndPools"), new IdentifierExpression(frontDoorName.BicepIdentifier), new IdentifierExpression(backendPoolName.BicepIdentifier))
                                },
                                EnabledState = RoutingRuleEnabledState.Enabled
                            }
                        }
                    };
                infra.Add(frontDoor);

                infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = new MemberExpression(new IdentifierExpression( frontDoor.BicepIdentifier), "name") }); // TODO -- update this to use the expression conversion
                infra.Add(new ProvisioningOutput("resourceGroupName", typeof(string)) { Value = BicepFunction.GetResourceGroup().Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = frontDoor.Id });
                #endregion

                return infra;
            });
    }

    internal static Trycep CreateFrontDoorRedirectTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:FrontDoorRedirect
                Infrastructure infra = new();

                ProvisioningParameter frontDoorName =
                    new(nameof(frontDoorName), typeof(string))
                    {
                        Description = "The name of the frontdoor resource."
                    };
                infra.Add(frontDoorName);

                ProvisioningParameter backendAddress =
                    new(nameof(backendAddress), typeof(string))
                    {
                        Description = "The hostname of the backend. Must be an IP address or FQDN."
                    };
                infra.Add(backendAddress);

                FrontDoorResource frontDoor =
                    new(nameof(frontDoor), FrontDoorResource.ResourceVersions.V2020_05_01)
                    {
                        Name = frontDoorName,
                        Location = new AzureLocation("global"),
                        EnabledState = FrontDoorEnabledState.Enabled,
                        FrontendEndpoints =
                        {
                            new FrontendEndpointData
                            {
                                Name = "frontendEndpoint1",
                                HostName = BicepFunction.Interpolate($"{frontDoorName}.azurefd.net"),
                                SessionAffinityEnabledState = SessionAffinityEnabledState.Disabled
                            }
                        },
                        LoadBalancingSettings =
                        {
                            new FrontDoorLoadBalancingSettingsData
                            {
                                Name = "loadBalancingSettings1",
                                SampleSize = 4,
                                SuccessfulSamplesRequired = 2
                            }
                        },
                        HealthProbeSettings =
                        {
                            new FrontDoorHealthProbeSettingsData
                            {
                                Name = "healthProbeSettings1",
                                Path = "/",
                                Protocol = FrontDoorProtocol.Http,
                                IntervalInSeconds = 120
                            }
                        },
                        BackendPools =
                        {
                            new FrontDoorBackendPool
                            {
                                Name = "backendPool1",
                                Backends =
                                {
                                    new FrontDoorBackend
                                    {
                                        Address = backendAddress,
                                        BackendHostHeader = backendAddress,
                                        HttpPort = 80,
                                        HttpsPort = 443,
                                        Weight = 50,
                                        Priority = 1,
                                        EnabledState = BackendEnabledState.Enabled
                                    }
                                },
                                LoadBalancingSettingsId = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/loadBalancingSettings"), new IdentifierExpression(frontDoorName.BicepIdentifier), new StringLiteralExpression("loadBalancingSettings1")),
                                HealthProbeSettingsId = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/healthProbeSettings"), new IdentifierExpression(frontDoorName.BicepIdentifier), new StringLiteralExpression("healthProbeSettings1"))
                            }
                        },
                        RoutingRules =
                        {
                            new RoutingRuleData
                            {
                                Name = "httptohttps",
                                FrontendEndpoints =
                                {
                                    new WritableSubResource
                                    {
                                        Id = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/frontendEndpoints"), new IdentifierExpression(frontDoorName.BicepIdentifier), new StringLiteralExpression("frontendEndpoint1"))
                                    }
                                },
                                AcceptedProtocols = { FrontDoorProtocol.Http },
                                PatternsToMatch = { "/*" },
                                RouteConfiguration = new RedirectConfiguration
                                {
                                    RedirectProtocol = FrontDoorRedirectProtocol.HttpsOnly,
                                    RedirectType = FrontDoorRedirectType.Moved
                                },
                                EnabledState = RoutingRuleEnabledState.Enabled
                            }
                        }
                    };
                infra.Add(frontDoor);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/front-door-create-basic/main.bicep")]
    public async Task CreateBasicFrontDoor()
    {
        await using Trycep test = CreateBasicFrontDoorTest();
        test.Compare(
            """
            @description('The name of the frontdoor resource.')
            param frontDoorName string

            @description('The hostname of the backend. Must be an IP address or FQDN.')
            param backendAddress string

            var frontEndEndpointName = 'frontEndEndpoint'

            var loadBalancingSettingsName = 'loadBalancingSettings'

            var healthProbeSettingsName = 'healthProbeSettings'

            var routingRuleName = 'routingRule'

            var backendPoolName = 'backendPool'

            resource frontDoor 'Microsoft.Network/frontDoors@2021-06-01' = {
              name: frontDoorName
              location: 'global'
              properties: {
                backendPools: [
                  {
                    properties: {
                      backends: [
                        {
                          address: backendAddress
                          httpPort: 80
                          httpsPort: 443
                          enabledState: 'Enabled'
                          priority: 1
                          weight: 50
                          backendHostHeader: backendAddress
                        }
                      ]
                      loadBalancingSettings: {
                        id: resourceId('Microsoft.Network/frontDoors/loadBalancingSettings', frontDoorName, loadBalancingSettingsName)
                      }
                      healthProbeSettings: {
                        id: resourceId('Microsoft.Network/frontDoors/healthProbeSettings', frontDoorName, healthProbeSettingsName)
                      }
                    }
                    name: backendPoolName
                  }
                ]
                enabledState: 'Enabled'
                frontendEndpoints: [
                  {
                    properties: {
                      hostName: '${frontDoorName}.azurefd.net'
                      sessionAffinityEnabledState: 'Disabled'
                    }
                    name: frontEndEndpointName
                  }
                ]
                healthProbeSettings: [
                  {
                    properties: {
                      path: '/'
                      protocol: 'Http'
                      intervalInSeconds: 120
                    }
                    name: healthProbeSettingsName
                  }
                ]
                loadBalancingSettings: [
                  {
                    properties: {
                      sampleSize: 4
                      successfulSamplesRequired: 2
                    }
                    name: loadBalancingSettingsName
                  }
                ]
                routingRules: [
                  {
                    properties: {
                      frontendEndpoints: [
                        {
                          id: resourceId('Microsoft.Network/frontDoors/frontEndEndpoints', frontDoorName, frontEndEndpointName)
                        }
                      ]
                      acceptedProtocols: [
                        'Http'
                        'Https'
                      ]
                      patternsToMatch: [
                        '/*'
                      ]
                      enabledState: 'Enabled'
                      routeConfiguration: {
                        '@odata.type': '#Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration'
                        forwardingProtocol: 'MatchRequest'
                        backendPool: {
                          id: resourceId('Microsoft.Network/frontDoors/backEndPools', frontDoorName, backendPoolName)
                        }
                      }
                    }
                    name: routingRuleName
                  }
                ]
              }
            }

            output name string = frontDoor.name

            output resourceGroupName string = resourceGroup().name

            output resourceId string = frontDoor.id
            """);
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/front-door-create-redirect/main.bicep")]
    public async Task CreateFrontDoorRedirect()
    {
        await using Trycep test = CreateFrontDoorRedirectTest();
        test.Compare(
            """
            @description('The name of the frontdoor resource.')
            param frontDoorName string

            @description('The hostname of the backend. Must be an IP address or FQDN.')
            param backendAddress string

            resource frontDoor 'Microsoft.Network/frontDoors@2020-05-01' = {
              name: frontDoorName
              location: 'global'
              properties: {
                backendPools: [
                  {
                    properties: {
                      backends: [
                        {
                          address: backendAddress
                          httpPort: 80
                          httpsPort: 443
                          enabledState: 'Enabled'
                          priority: 1
                          weight: 50
                          backendHostHeader: backendAddress
                        }
                      ]
                      loadBalancingSettings: {
                        id: resourceId('Microsoft.Network/frontDoors/loadBalancingSettings', frontDoorName, 'loadBalancingSettings1')
                      }
                      healthProbeSettings: {
                        id: resourceId('Microsoft.Network/frontDoors/healthProbeSettings', frontDoorName, 'healthProbeSettings1')
                      }
                    }
                    name: 'backendPool1'
                  }
                ]
                enabledState: 'Enabled'
                frontendEndpoints: [
                  {
                    properties: {
                      hostName: '${frontDoorName}.azurefd.net'
                      sessionAffinityEnabledState: 'Disabled'
                    }
                    name: 'frontendEndpoint1'
                  }
                ]
                healthProbeSettings: [
                  {
                    properties: {
                      path: '/'
                      protocol: 'Http'
                      intervalInSeconds: 120
                    }
                    name: 'healthProbeSettings1'
                  }
                ]
                loadBalancingSettings: [
                  {
                    properties: {
                      sampleSize: 4
                      successfulSamplesRequired: 2
                    }
                    name: 'loadBalancingSettings1'
                  }
                ]
                routingRules: [
                  {
                    properties: {
                      frontendEndpoints: [
                        {
                          id: resourceId('Microsoft.Network/frontDoors/frontendEndpoints', frontDoorName, 'frontendEndpoint1')
                        }
                      ]
                      acceptedProtocols: [
                        'Http'
                      ]
                      patternsToMatch: [
                        '/*'
                      ]
                      enabledState: 'Enabled'
                      routeConfiguration: {
                        '@odata.type': '#Microsoft.Azure.FrontDoor.Models.FrontdoorRedirectConfiguration'
                        redirectType: 'Moved'
                        redirectProtocol: 'HttpsOnly'
                      }
                    }
                    name: 'httptohttps'
                  }
                ]
              }
            }
            """);
    }
}
