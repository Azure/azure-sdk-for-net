// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Xunit;
using Xunit.Abstractions;
using static Microsoft.Azure.Management.Fluent.Resource.Core.HttpLoggingDelegatingHandler;

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
                    // TODO: Currently hangs
                    //.WithUserAgent("AzureTests", "0.0.1-prerelease")
                    .Authenticate(credentials);

            subscriptions = azureAuthed.Subscriptions;
            this.azure = azureAuthed.WithDefaultSubscription();
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
        public void testLoadBalancersNatPools()
        {
            new Network.LoadBalancer.InternetWithNatPool(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void testLoadBalancersInternetMinimum()
        {
            new Network.LoadBalancer.InternetMinimal(
                    azure.PublicIpAddresses,
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void testLoadBalancersInternalMinimum()
        {
            new Network.LoadBalancer.InternalMinimal(
                    azure.VirtualMachines,
                    azure.Networks)
                .RunTest(azure.LoadBalancers, azure.ResourceGroups);
        }
    }
}
