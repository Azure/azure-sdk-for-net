// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Trafficmanager.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Azure.Tests.TrafficManager
{
    public class TrafficManagerTests
    {
        [Fact]
        public void CanCreateUpdateTrafficManagerProfile()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.US_EAST;
                var externalEndpointName21 = "external-ep-1";
                var externalEndpointName22 = "external-ep-2";
                var externalEndpointName23 = "external-ep-3";

                var externalFqdn21 = "www.azure.microsoft.com";
                var externalFqdn22 = "www.bing.com";
                var externalFqdn23 = "www.github.com";

                var azureEndpointName = "azure-ep-1";
                var nestedProfileEndpointName = "nested-profile-ep-1";

                var groupName = TestUtilities.GenerateName("rgchashtm");
                var pipName = TestUtilities.GenerateName("pip");
                var pipDnsLabel = TestUtilities.GenerateName("contoso");

                var tmProfileName = TestUtilities.GenerateName("tm");
                var nestedTmProfileName = "nested" + tmProfileName;

                var tmProfileDnsLabel = TestUtilities.GenerateName("tmdns");
                var nestedTmProfileDnsLabel = "nested" + tmProfileDnsLabel;

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    var rgCreatable = azure.ResourceGroups.Define(groupName)
                            .WithRegion(region);

                    // Creates a TM profile that will be used as a nested profile endpoint in parent TM profile
                    //
                    var nestedProfile = azure.TrafficManagerProfiles.Define(nestedTmProfileName)
                            .WithNewResourceGroup(rgCreatable)
                            .WithLeafDomainLabel(nestedTmProfileDnsLabel)
                            .WithPriorityBasedRouting()
                            .DefineExternalTargetEndpoint("external-ep-1")
                                .ToFqdn("www.gitbook.com")
                                .FromRegion(Region.INDIA_CENTRAL)
                                .Attach()
                            .WithHttpsMonitoring()
                            .WithTimeToLive(500)
                            .Create();

                    Assert.True(nestedProfile.IsEnabled);
                    Assert.NotNull(nestedProfile.MonitorStatus);
                    Assert.Equal(443, nestedProfile.MonitoringPort);
                    Assert.Equal("/", nestedProfile.MonitoringPath);
                    Assert.Equal(0, nestedProfile.AzureEndpoints.Count());
                    Assert.Equal(0, nestedProfile.NestedProfileEndpoints.Count());
                    Assert.Equal(1, nestedProfile.ExternalEndpoints.Count());
                    Assert.Equal(nestedTmProfileDnsLabel + ".trafficmanager.net", nestedProfile.Fqdn);
                    Assert.Equal(500, nestedProfile.TimeToLive);

                    // Creates a public ip to be used as an Azure endpoint
                    //
                    var publicIpAddress = azure.PublicIpAddresses.Define(pipName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgCreatable)
                            .WithLeafDomainLabel(pipDnsLabel)
                            .Create();

                    Assert.NotNull(publicIpAddress.Fqdn);
                    // Creates a TM profile
                    //

                    var profile = azure.TrafficManagerProfiles.Define(tmProfileName)
                            .WithNewResourceGroup(rgCreatable)
                            .WithLeafDomainLabel(tmProfileDnsLabel)
                            .WithWeightBasedRouting()
                            .DefineExternalTargetEndpoint(externalEndpointName21)
                                .ToFqdn(externalFqdn21)
                                .FromRegion(Region.US_EAST)
                                .WithRoutingPriority(1)
                                .WithRoutingWeight(1)
                                .Attach()
                            .DefineExternalTargetEndpoint(externalEndpointName22)
                                .ToFqdn(externalFqdn22)
                                .FromRegion(Region.US_EAST2)
                                .WithRoutingPriority(2)
                                .WithRoutingWeight(1)
                                .WithTrafficDisabled()
                                .Attach()
                            .DefineAzureTargetEndpoint(azureEndpointName)
                                .ToResourceId(publicIpAddress.Id)
                                .WithRoutingPriority(3)
                                .Attach()
                            .DefineNestedTargetEndpoint(nestedProfileEndpointName)
                                .ToProfile(nestedProfile)
                                .FromRegion(Region.INDIA_CENTRAL)
                                .WithMinimumEndpointsToEnableTraffic(1)
                                .WithRoutingPriority(4)
                            .Attach()
                            .WithHttpMonitoring()
                            .Create();

                    Assert.True(profile.IsEnabled);
                    Assert.NotNull(profile.MonitorStatus);
                    Assert.Equal(80, profile.MonitoringPort);
                    Assert.Equal("/", profile.MonitoringPath);
                    Assert.Equal(1, profile.AzureEndpoints.Count());
                    Assert.Equal(1, profile.NestedProfileEndpoints.Count());
                    Assert.Equal(2, profile.ExternalEndpoints.Count());
                    Assert.Equal(tmProfileDnsLabel + ".trafficmanager.net", profile.Fqdn);
                    Assert.Equal(300, profile.TimeToLive); // Default

                    profile = profile.Refresh();
                    Assert.Equal(1, profile.AzureEndpoints.Count());
                    Assert.Equal(1, profile.NestedProfileEndpoints.Count());
                    Assert.Equal(2, profile.ExternalEndpoints.Count());

                    int c = 0;
                    foreach (var endpoint in profile.ExternalEndpoints.Values)
                    {
                        Assert.Equal(EndpointType.External, endpoint.EndpointType);
                        if (endpoint.Name.Equals(externalEndpointName21, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(1, endpoint.RoutingPriority);
                            Assert.Equal(externalFqdn21, endpoint.Fqdn);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(Region.US_EAST, endpoint.SourceTrafficLocation);
                            c++;
                        }
                        else if (endpoint.Name.Equals(externalEndpointName22, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(2, endpoint.RoutingPriority);
                            Assert.Equal(externalFqdn22, endpoint.Fqdn);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(Region.US_EAST2, endpoint.SourceTrafficLocation);
                            c++;
                        }
                    }
                    Assert.Equal(2, c);

                    c = 0;
                    foreach (var endpoint in profile.AzureEndpoints.Values)
                    {
                        Assert.Equal(EndpointType.Azure, endpoint.EndpointType);
                        if (endpoint.Name.Equals(azureEndpointName, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(3, endpoint.RoutingPriority);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(publicIpAddress.Id, endpoint.TargetAzureResourceId);
                            Assert.Equal(TargetAzureResourceType.PublicIP, endpoint.TargetResourceType);
                            c++;
                        }
                    }
                    Assert.Equal(1, c);

                    c = 0;
                    foreach (var endpoint in profile.NestedProfileEndpoints.Values)
                    {
                        Assert.Equal(EndpointType.NestedProfile, endpoint.EndpointType);
                        if (endpoint.Name.Equals(nestedProfileEndpointName, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(4, endpoint.RoutingPriority);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(1, endpoint.MinimumChildEndpointCount);
                            Assert.Equal(nestedProfile.Id, endpoint.NestedProfileId);
                            Assert.Equal(Region.INDIA_CENTRAL, endpoint.SourceTrafficLocation);
                            c++;
                        }
                    }
                    Assert.Equal(1, c);

                    // Remove an endpoint, update two endpoints and add new one
                    //
                    profile.Update()
                            .WithTimeToLive(600)
                            .WithHttpMonitoring(8080, "/")
                            .WithPerformanceBasedRouting()
                            .WithoutEndpoint(externalEndpointName21)
                            .UpdateAzureTargetEndpoint(azureEndpointName)
                                .WithRoutingPriority(5)
                                .WithRoutingWeight(2)
                                .Parent()
                            .UpdateNestedProfileTargetEndpoint(nestedProfileEndpointName)
                                .WithTrafficDisabled()
                                .Parent()
                            .DefineExternalTargetEndpoint(externalEndpointName23)
                                .ToFqdn(externalFqdn23)
                                .FromRegion(Region.US_CENTRAL)
                                .WithRoutingPriority(6)
                                .Attach()
                            .Apply();

                    Assert.Equal(8080, profile.MonitoringPort);
                    Assert.Equal("/", profile.MonitoringPath);
                    Assert.Equal(1, profile.AzureEndpoints.Count());
                    Assert.Equal(1, profile.NestedProfileEndpoints.Count());
                    Assert.Equal(2, profile.ExternalEndpoints.Count());
                    Assert.Equal(600, profile.TimeToLive);

                    c = 0;
                    foreach (var endpoint in profile.ExternalEndpoints.Values)
                    {
                        Assert.Equal(endpoint.EndpointType, EndpointType.External);
                        if (endpoint.Name.Equals(externalEndpointName22, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(2, endpoint.RoutingPriority);
                            Assert.Equal(externalFqdn22, endpoint.Fqdn);
                            Assert.Equal(Region.US_EAST2, endpoint.SourceTrafficLocation);
                            Assert.NotNull(endpoint.MonitorStatus);
                            c++;
                        }
                        else if (endpoint.Name.Equals(externalEndpointName23, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Equal(6, endpoint.RoutingPriority);
                            Assert.Equal(externalFqdn23, endpoint.Fqdn);
                            Assert.NotNull(endpoint.MonitorStatus);
                            Assert.Equal(Region.US_CENTRAL, endpoint.SourceTrafficLocation);
                            c++;
                        }
                        else
                        {
                            c++;
                        }
                    }
                    Assert.Equal(2, c);

                    c = 0;
                    foreach (var endpoint in profile.AzureEndpoints.Values)
                    {
                        Assert.Equal(endpoint.EndpointType, EndpointType.Azure);
                        if (endpoint.Name.Equals(azureEndpointName))
                        {
                            Assert.Equal(5, endpoint.RoutingPriority);
                            Assert.Equal(2, endpoint.RoutingWeight);
                            Assert.Equal(TargetAzureResourceType.PublicIP, endpoint.TargetResourceType);
                            c++;
                        }
                    }
                    Assert.Equal(1, c);
                }
                catch (Exception exception)
                {
                    Assert.True(false, exception.Message);
                }
                finally
                {
                    azure.ResourceGroups.DeleteByName(groupName);
                }
            }
        }
    }
}
