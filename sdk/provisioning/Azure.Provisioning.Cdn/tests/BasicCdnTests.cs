// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Cdn.Tests;

public class BasicCdnTests
{
    internal static Trycep CreateCdnWithCustomOriginTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:CdnWithCustomOrigin
                Infrastructure infra = new();

                ProvisioningParameter profileName = new(nameof(profileName), typeof(string))
                {
                    Description = "Name of the CDN Profile."
                };
                infra.Add(profileName);

                ProvisioningParameter endpointName = new(nameof(endpointName), typeof(string))
                {
                    Description = "Name of the CDN Endpoint, must be unique."
                };
                infra.Add(endpointName);

                ProvisioningParameter originUrl = new(nameof(originUrl), typeof(string))
                {
                    Description = "Url of the origin."
                };
                infra.Add(originUrl);

                CdnProfile profile = new(nameof(profile), CdnProfile.ResourceVersions.V2025_06_01)
                {
                    Name = profileName,
                    Location = new AzureLocation("global"),
                    SkuName = CdnSkuName.StandardMicrosoft
                };
                infra.Add(profile);

                CdnEndpoint endpoint = new(nameof(endpoint), CdnEndpoint.ResourceVersions.V2025_06_01)
                {
                    Parent = profile,
                    Name = endpointName,
                    Location = new AzureLocation("global"),
                    OriginHostHeader = originUrl,
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    QueryStringCachingBehavior = QueryStringCachingBehavior.IgnoreQueryString,
                    IsCompressionEnabled = true,
                    ContentTypesToCompress =
                    {
                        "application/javascript",
                        "application/json",
                        "application/xml",
                        "text/css",
                        "text/html",
                        "text/plain"
                    },
                    Origins =
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin1",
                            HostName = originUrl
                        }
                    }
                };
                infra.Add(endpoint);

                infra.Add(new ProvisioningOutput("endpointHostName", typeof(string)) { Value = endpoint.HostName });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cdn/cdn-with-custom-origin/main.bicep")]
    public async Task CreateCdnWithCustomOrigin()
    {
        await using Trycep test = CreateCdnWithCustomOriginTest();
        test.Compare(
            """
            @description('Name of the CDN Profile.')
            param profileName string

            @description('Name of the CDN Endpoint, must be unique.')
            param endpointName string

            @description('Url of the origin.')
            param originUrl string

            resource profile 'Microsoft.Cdn/profiles@2025-06-01' = {
              name: profileName
              location: 'global'
              sku: {
                name: 'Standard_Microsoft'
              }
            }

            resource endpoint 'Microsoft.Cdn/profiles/endpoints@2025-06-01' = {
              name: endpointName
              location: 'global'
              properties: {
                contentTypesToCompress: [
                  'application/javascript'
                  'application/json'
                  'application/xml'
                  'text/css'
                  'text/html'
                  'text/plain'
                ]
                isCompressionEnabled: true
                isHttpAllowed: true
                isHttpsAllowed: true
                originHostHeader: originUrl
                origins: [
                  {
                    name: 'origin1'
                    properties: {
                      hostName: originUrl
                    }
                  }
                ]
                queryStringCachingBehavior: 'IgnoreQueryString'
              }
              parent: profile
            }

            output endpointHostName string = endpoint.properties.hostName
            """);
    }

    internal static Trycep CreateFrontDoorStandardPremiumTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:FrontDoorStandardPremium
                Infrastructure infra = new();

                ProvisioningParameter originHostName = new(nameof(originHostName), typeof(string))
                {
                    Description = "The host name that should be used when connecting from Front Door to the origin."
                };
                infra.Add(originHostName);

                CdnProfile profile = new(nameof(profile), CdnProfile.ResourceVersions.V2025_06_01)
                {
                    Name = "MyFrontDoor",
                    Location = new AzureLocation("global"),
                    SkuName = CdnSkuName.StandardAzureFrontDoor
                };
                infra.Add(profile);

                FrontDoorEndpoint endpoint = new(nameof(endpoint), FrontDoorEndpoint.ResourceVersions.V2025_06_01)
                {
                    Parent = profile,
                    Name = "MyEndpoint",
                    Location = new AzureLocation("global"),
                    EnabledState = EnabledState.Enabled
                };
                infra.Add(endpoint);

                FrontDoorOriginGroup originGroup = new(nameof(originGroup), FrontDoorOriginGroup.ResourceVersions.V2025_06_01)
                {
                    Parent = profile,
                    Name = "MyOriginGroup",
                    LoadBalancingSettings = new LoadBalancingSettings
                    {
                        SampleSize = 4,
                        SuccessfulSamplesRequired = 3
                    },
                    HealthProbeSettings = new HealthProbeSettings
                    {
                        ProbePath = "/",
                        ProbeRequestType = HealthProbeRequestType.Head,
                        ProbeProtocol = HealthProbeProtocol.Http,
                        ProbeIntervalInSeconds = 100
                    }
                };
                infra.Add(originGroup);

                FrontDoorOrigin origin = new(nameof(origin), FrontDoorOrigin.ResourceVersions.V2025_06_01)
                {
                    Parent = originGroup,
                    Name = "MyOrigin",
                    HostName = originHostName,
                    HttpPort = 80,
                    HttpsPort = 443,
                    OriginHostHeader = originHostName,
                    Priority = 1,
                    Weight = 1000
                };
                infra.Add(origin);

                FrontDoorRoute route = new(nameof(route), FrontDoorRoute.ResourceVersions.V2025_06_01)
                {
                    Parent = endpoint,
                    Name = "MyRoute",
                    OriginGroupId = originGroup.Id,
                    SupportedProtocols =
                    {
                        FrontDoorEndpointProtocol.Http,
                        FrontDoorEndpointProtocol.Https
                    },
                    PatternsToMatch =
                    {
                        "/*"
                    },
                    ForwardingProtocol = ForwardingProtocol.HttpsOnly,
                    LinkToDefaultDomain = LinkToDefaultDomain.Enabled,
                    HttpsRedirect = HttpsRedirect.Enabled
                };
                infra.Add(route);

                infra.Add(new ProvisioningOutput("frontDoorEndpointHostName", typeof(string)) { Value = endpoint.HostName });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cdn/front-door-standard-premium/main.bicep")]
    public async Task CreateFrontDoorStandardPremium()
    {
        await using Trycep test = CreateFrontDoorStandardPremiumTest();
        test.Compare(
            """
            @description('The host name that should be used when connecting from Front Door to the origin.')
            param originHostName string

            resource profile 'Microsoft.Cdn/profiles@2025-06-01' = {
              name: 'MyFrontDoor'
              location: 'global'
              sku: {
                name: 'Standard_AzureFrontDoor'
              }
            }

            resource endpoint 'Microsoft.Cdn/profiles/afdEndpoints@2025-06-01' = {
              name: 'MyEndpoint'
              location: 'global'
              properties: {
                enabledState: 'Enabled'
              }
              parent: profile
            }

            resource originGroup 'Microsoft.Cdn/profiles/originGroups@2025-06-01' = {
              name: 'MyOriginGroup'
              properties: {
                healthProbeSettings: {
                  probePath: '/'
                  probeRequestType: 'HEAD'
                  probeProtocol: 'Http'
                  probeIntervalInSeconds: 100
                }
                loadBalancingSettings: {
                  sampleSize: 4
                  successfulSamplesRequired: 3
                }
              }
              parent: profile
            }

            resource origin 'Microsoft.Cdn/profiles/originGroups/origins@2025-06-01' = {
              name: 'MyOrigin'
              properties: {
                hostName: originHostName
                httpPort: 80
                httpsPort: 443
                originHostHeader: originHostName
                priority: 1
                weight: 1000
              }
              parent: originGroup
            }

            resource route 'Microsoft.Cdn/profiles/afdEndpoints/routes@2025-06-01' = {
              name: 'MyRoute'
              properties: {
                forwardingProtocol: 'HttpsOnly'
                httpsRedirect: 'Enabled'
                linkToDefaultDomain: 'Enabled'
                originGroup: {
                  id: originGroup.id
                }
                patternsToMatch: [
                  '/*'
                ]
                supportedProtocols: [
                  'Http'
                  'Https'
                ]
              }
              parent: endpoint
            }

            output frontDoorEndpointHostName string = endpoint.properties.hostName
            """);
    }
}
