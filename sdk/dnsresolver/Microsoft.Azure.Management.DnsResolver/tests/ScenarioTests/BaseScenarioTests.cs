// ------------------------------------------------------------------------------------------------
// <copyright file="BaseScenarioTests.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace DnsResolver.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using Microsoft.Azure.Management.DnsResolver;
    using Microsoft.Azure.Management.DnsResolver.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using DnsResolver.Tests.Extensions;
    using DnsResolver.Tests.Helpers;
    using Xunit.Abstractions;

    public class BaseScenarioTests : IDisposable
    {
        public BaseScenarioTests(ITestOutputHelper output)
        {
            var testName = GetTestName(output);

            this.TestContext = MockContext.Start(this.GetType().Name, testName);
            this.ResourceHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            this.ResourceManagementClient = ClientFactory.GetResourcesClient(this.TestContext, this.ResourceHandler);
            this.DnsResolverManagementClient = ClientFactory.GetDnsResolverClient(this.TestContext, this.ResourceHandler);
            this.SubscriptionId = TestEnvironmentFactory.GetTestEnvironment().SubscriptionId;
        }

        protected MockContext TestContext { get; private set; }

        protected RecordedDelegatingHandler ResourceHandler { get; private set; }

        protected ResourceManagementClient ResourceManagementClient { get; private set; }

        protected DnsResolverManagementClient DnsResolverManagementClient { get; private set; }

        protected string SubscriptionId { get; private set; }

        public virtual void Dispose()
        {
            TestContext?.Dispose();
        }

        protected ResourceGroup CreateResourceGroup(string resourceGroupName = null)
        {
            return this.ResourceManagementClient.CreateResourceGroup(resourceGroupName: resourceGroupName);
        }

        protected DnsResolverModel CreateDnsResolver(string location = null, string subscriptionId = null, string resourceGroupName = null, IDictionary<string, string> tags = null) 
        {
            location = location ?? Constants.DnsResolverLocation;
            subscriptionId = subscriptionId ?? this.SubscriptionId;
            resourceGroupName = resourceGroupName ?? TestDataGenerator.GenerateResourceGroup().Name;

            return this.DnsResolverManagementClient.DnsResolvers.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                dnsResolverName: TestDataGenerator.GenerateDnsResolverName(),
                parameters: TestDataGenerator.GenerateDnsResolver(location: location, subscriptionId: subscriptionId, resourceGroupName: resourceGroupName, tags: tags));
        }

        protected ICollection<DnsResolverModel> CreateDnsResolvers( string resourceGroupName = null, int numDnsResolvers = 3)
        {
            resourceGroupName = resourceGroupName ?? TestDataGenerator.GenerateResourceGroup().Name;

            var createdDnsResolvers = new List<DnsResolverModel>();
            for (var i = 0; i < numDnsResolvers; i++)
            {
                createdDnsResolvers.Add(this.CreateDnsResolver(resourceGroupName: resourceGroupName));
            }

            return createdDnsResolvers;
        }

        private static string GetTestName(ITestOutputHelper output)
        {
            // Reference: https://github.com/xunit/xunit/issues/416
            var type = output.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var test = (ITest)testMember.GetValue(output);
            var fullyQualifiedTestName = test.DisplayName;
            return fullyQualifiedTestName.Split('.').Last();
        }
    }
}
