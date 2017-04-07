// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Tests
{
    public class AzureTests
    {
        public AzureTests(ITestOutputHelper output)
        {
            TestHelper.TestLogger = output;
        }

        [Fact]
        public void TestAppGatewaysInParallel()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                string rgName = SdkContext.RandomResourceName("rg", 13);
                Region region = Region.USEast;
                ICreatable<IResourceGroup> resourceGroup = azure.ResourceGroups.Define(rgName).WithRegion(region);
                List<ICreatable<IApplicationGateway>> agCreatables = new List<ICreatable<IApplicationGateway>>();

                agCreatables.Add(azure.ApplicationGateways.Define(SdkContext.RandomResourceName("ag", 13))
                    .WithRegion(Region.USEast)
                    .WithNewResourceGroup(resourceGroup)
                    .DefineRequestRoutingRule("rule1")
                        .FromPrivateFrontend()
                        .FromFrontendHttpPort(80)
                        .ToBackendHttpPort(8080)
                        .ToBackendIPAddress("10.0.0.1")
                        .ToBackendIPAddress("10.0.0.2")
                        .Attach());

                agCreatables.Add(azure.ApplicationGateways.Define(SdkContext.RandomResourceName("ag", 13))
                    .WithRegion(Region.USEast)
                    .WithNewResourceGroup(resourceGroup)
                    .DefineRequestRoutingRule("rule1")
                        .FromPrivateFrontend()
                        .FromFrontendHttpPort(80)
                        .ToBackendHttpPort(8080)
                        .ToBackendIPAddress("10.0.0.3")
                        .ToBackendIPAddress("10.0.0.4")
                        .Attach());

                var created = azure.ApplicationGateways.Create(agCreatables);
                var ags = new List<IApplicationGateway>();
                var agIds = new List<string>();
                foreach (var creatable in agCreatables)
                {
                    var ag = (IApplicationGateway)created.CreatedRelatedResource(creatable.Key);
                    Assert.NotNull(ag);
                    ags.Add(ag);
                    agIds.Add(ag.Id);
                }

                azure.ApplicationGateways.Stop(agIds);

                foreach (var ag in ags)
                {
                    Assert.Equal(ApplicationGatewayOperationalState.Stopped, ag.Refresh().OperationalState);
                }

                azure.ApplicationGateways.Start(agIds);

                foreach (var ag in ags)
                {
                    Assert.Equal(ApplicationGatewayOperationalState.Running, ag.Refresh().OperationalState);
                }

                azure.ApplicationGateways.DeleteByIds(agIds);
                foreach (var id in agIds)
                {
                    Assert.Null(azure.ApplicationGateways.GetById(id));
                }

                azure.ResourceGroups.DeleteByName(rgName);
            }
        }

        [Fact]
        public void TestAppGatewaysPrivateMinimal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.ApplicationGateway.PrivateMinimal().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestAppGatewaysPublicMinimal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.ApplicationGateway.PublicMinimal().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestAppGatewaysPrivateComplex()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                new Network.ApplicationGateway.PrivateComplex().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestAppGatewaysPublicComplex()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.ApplicationGateway.PublicComplex().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestLoadBalancersNatRules()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetWithNatRule(azure.VirtualMachines)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestLoadBalancersNatPools()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetWithNatPool(azure.VirtualMachines)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestLoadBalancersInternetMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetMinimal(azure.VirtualMachines)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestLoadBalancersInternalMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternalMinimal(azure.VirtualMachines)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }
    }
}