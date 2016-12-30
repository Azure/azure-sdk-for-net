// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Xunit;
using Xunit.Abstractions;
using static Microsoft.Azure.Management.Resource.Fluent.Core.HttpLoggingDelegatingHandler;
using System.Linq;

namespace Azure.Tests
{
    public class AzureTests
    {
        private ISubscriptions subscriptions;
        private IAzure azure;

        public AzureTests(ITestOutputHelper output)
        {
            TestHelper.TestLogger = output;

            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\automation\my.azureauth");
            
            // Authenticate based on credentials instance
            var azureAuthed = Microsoft.Azure.Management.Fluent.Azure.Configure()
                    .WithLogLevel(Level.NONE)
                    .WithUserAgent("AzureTests", "0.0.1-prerelease")
                    .Authenticate(credentials);

            subscriptions = azureAuthed.Subscriptions;
            this.azure = azureAuthed.WithDefaultSubscription();
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestAppGatewaysPrivateMinimal()
        {
            new Network.ApplicationGateway.PrivateMinimal(
                azure.Networks)
                .RunTest(azure.ApplicationGateways, azure.ResourceGroups);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestAppGatewaysPublicMinimal()
        {
            new Network.ApplicationGateway.PublicMinimal(
                azure.Networks)
                .RunTest(azure.ApplicationGateways, azure.ResourceGroups);
        }

        public class ExpandableStringEnumFoo : ExpandableStringEnum<ExpandableStringEnumFoo>
        {
            public static readonly ExpandableStringEnumFoo Foo1 = Parse("value1");
            public static readonly ExpandableStringEnumFoo Foo2 = Parse("value2");
        }

        public class ExpandableStringEnumBar : ExpandableStringEnum<ExpandableStringEnumBar>
        {
            public static readonly ExpandableStringEnumBar Bar1 = Parse("value1");
            public static readonly ExpandableStringEnumBar Bar2 = Parse("value3");
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestExpandableEnums()
        {
            ExpandableStringEnumFoo foo = ExpandableStringEnumFoo.Foo1;
            Assert.True(ExpandableStringEnumFoo.Foo1 == foo);

            Assert.True(ExpandableStringEnumFoo.Foo1 == ExpandableStringEnumFoo.Parse(ExpandableStringEnumFoo.Foo1.ToString()));
            Assert.True(ExpandableStringEnumFoo.Foo1 != ExpandableStringEnumFoo.Parse(ExpandableStringEnumFoo.Foo2.ToString()));
            Assert.True(ExpandableStringEnumBar.Bar1 == ExpandableStringEnumBar.Parse(ExpandableStringEnumBar.Bar1.ToString()));
            Assert.True(ExpandableStringEnumBar.Bar1 != ExpandableStringEnumBar.Parse(ExpandableStringEnumBar.Bar2.ToString()));
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestAppGatewaysPrivateComplex()
        {
            new Network.ApplicationGateway.PrivateComplex(
                azure.Networks,
                azure.PublicIpAddresses)
                .RunTest(azure.ApplicationGateways, azure.ResourceGroups);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestAppGatewaysPublicComplex()
        {
            new Network.ApplicationGateway.PublicComplex(azure.PublicIpAddresses)
                .RunTest(azure.ApplicationGateways, azure.ResourceGroups);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestLoadBalancersNatRules()
        {
            new Network.LoadBalancer.InternetWithNatRule(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestLoadBalancersNatPools()
        {
            new Network.LoadBalancer.InternetWithNatPool(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestLoadBalancersInternetMinimum()
        {
            new Network.LoadBalancer.InternetMinimal(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void TestLoadBalancersInternalMinimum()
        {
            new Network.LoadBalancer.InternalMinimal(
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
        }
    }
}
