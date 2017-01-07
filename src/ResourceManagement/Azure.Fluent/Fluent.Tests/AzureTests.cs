// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;
using Xunit.Abstractions;
using static Microsoft.Azure.Management.Resource.Fluent.Core.HttpLoggingDelegatingHandler;

namespace Azure.Tests
{
    public class AzureTests
    {
        private ISubscriptions subscriptions;

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

        [Fact(Skip ="Enable once Martin's changes are in")]
        public void TestLoadBalancersNatRules()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetWithNatRule(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact(Skip = "Enable once Martin's changes are in")]
        public void TestLoadBalancersNatPools()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetWithNatPool(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact(Skip = "Enable once Martin's changes are in")]
        public void TestLoadBalancersInternetMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternetMinimal(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }

        [Fact(Skip = "Enable once Martin's changes are in")]
        public void TestLoadBalancersInternalMinimum()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();

                new Network.LoadBalancer.InternalMinimal(
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
            }
        }
    }
}
