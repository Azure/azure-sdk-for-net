// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.TrafficManager.Tests;

public class BasicTrafficManagerTests
{
    internal static Trycep CreateTrafficManagerProfileTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:TrafficManagerBasic
                Infrastructure infra = new();

                TrafficManagerProfile profile =
                    new(nameof(profile), TrafficManagerProfile.ResourceVersions.V2022_04_01)
                    {
                        Location = new AzureLocation("global"),
                        TrafficRoutingMethod = TrafficRoutingMethod.Weighted,
                        DnsConfig = new TrafficManagerDnsConfig
                        {
                            RelativeName = "contoso",
                            Ttl = 30,
                        },
                        MonitorConfig = new TrafficManagerMonitorConfig
                        {
                            Protocol = TrafficManagerMonitorProtocol.Https,
                            Port = 443,
                            Path = "/",
                            IntervalInSeconds = 30,
                            TimeoutInSeconds = 10,
                            ToleratedNumberOfFailures = 3,
                        },
                    };
                infra.Add(profile);

                AzureEndpointTrafficManagerEndpoint endpoint =
                    new(nameof(endpoint), AzureEndpointTrafficManagerEndpoint.ResourceVersions.V2022_04_01)
                    {
                        Parent = profile,
                        EndpointStatus = TrafficManagerEndpointStatus.Enabled,
                        TargetResourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRg/providers/Microsoft.Network/publicIPAddresses/myPublicIp"),
                        Weight = 1,
                    };
                infra.Add(endpoint);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateTrafficManagerProfile()
    {
        await using Trycep test = CreateTrafficManagerProfileTest();
        test.Compare(
            """
            resource profile 'Microsoft.Network/trafficmanagerprofiles@2022-04-01' = {
              name: take('profile${uniqueString(resourceGroup().id)}', 24)
              location: 'global'
              properties: {
                trafficRoutingMethod: 'Weighted'
                dnsConfig: {
                  relativeName: 'contoso'
                  ttl: 30
                }
                monitorConfig: {
                  protocol: 'HTTPS'
                  port: 443
                  path: '/'
                  intervalInSeconds: 30
                  timeoutInSeconds: 10
                  toleratedNumberOfFailures: 3
                }
              }
            }

            resource endpoint 'Microsoft.Network/trafficmanagerprofiles/AzureEndpoints@2022-04-01' = {
              name: take('endpoint${uniqueString(resourceGroup().id)}', 24)
              properties: {
                targetResourceId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRg/providers/Microsoft.Network/publicIPAddresses/myPublicIp'
                endpointStatus: 'Enabled'
                weight: 1
              }
              parent: profile
            }
            """);
    }
}
