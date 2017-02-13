// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent;
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
        public void TestAppGatewaysPrivateMinimal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.ApplicationGateway.PrivateMinimal(
                    azure.Networks)
                    .RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestAppGatewaysPublicMinimal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.ApplicationGateway.PublicMinimal(
                    azure.Networks)
                    .RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestAppGatewaysPrivateComplex()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                new Network.ApplicationGateway.PrivateComplex(
                    azure.Networks,
                    azure.PublicIpAddresses)
                    .RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestAppGatewaysPublicComplex()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.ApplicationGateway.PublicComplex(azure.PublicIpAddresses)
                    .RunTest(azure.ApplicationGateways, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestLoadBalancersNatRules()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetWithNatRule(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks,
                    azure.AvailabilitySets)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestLoadBalancersNatPools()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetWithNatPool(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks,
                    azure.AvailabilitySets)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestLoadBalancersInternetMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetMinimal(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks,
                    azure.AvailabilitySets)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact]
        public void TestLoadBalancersInternalMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternalMinimal(
                    azure.VirtualMachines,
                    azure.Networks,
                    azure.AvailabilitySets)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }
    }
}