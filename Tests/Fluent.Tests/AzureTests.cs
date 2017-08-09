// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Fluent.Tests.Network
{
    public class AppGateway
    {
        public AppGateway(ITestOutputHelper output)
        {
            TestHelper.TestLogger = output;
        }

        [Fact]
        public void InParallel()
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

                try
                {
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                }
                catch { }
            }
        }

        [Fact]
        public void PrivateMinimal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new ApplicationGateway.PrivateMinimal().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void PublicMinimal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new ApplicationGateway.PublicMinimal().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void PrivateComplex()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                new ApplicationGateway.PrivateComplex().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void PublicComplex()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new ApplicationGateway.PublicComplex().RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }
    }

    public partial class LoadBalancer
    {
        public LoadBalancer(ITestOutputHelper output)
        {
            TestHelper.TestLogger = output;
        }

        [Fact]
        public void NatOnly()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternetNatOnly(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void NatRules()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternetWithNatRule(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void NatPools()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternetWithNatPool(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void InternetMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternetMinimal(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void InternalMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new LoadBalancerHelpers.InternalMinimal(azure.VirtualMachines.Manager)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }
    }
}