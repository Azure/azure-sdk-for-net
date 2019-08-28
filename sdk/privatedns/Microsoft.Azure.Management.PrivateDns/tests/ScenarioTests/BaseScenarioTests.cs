// ------------------------------------------------------------------------------------------------
// <copyright file="BaseScenarioTests.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace PrivateDns.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using FluentAssertions;
    using Microsoft.Azure.Management.PrivateDns;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using PrivateDns.Tests.Extensions;
    using PrivateDns.Tests.Helpers;
    using Xunit.Abstractions;

    public class BaseScenarioTests : IDisposable
    {
        public BaseScenarioTests(ITestOutputHelper output)
        {
            var testName = GetTestName(output);

            this.TestContext = MockContext.Start(this.GetType(), testName);
            this.ResourceHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            this.ResourceManagementClient = ClientFactory.GetResourcesClient(this.TestContext, this.ResourceHandler);
            this.PrivateDnsManagementClient = ClientFactory.GetPrivateDnsClient(this.TestContext, this.ResourceHandler);
            this.SubscriptionId = TestEnvironmentFactory.GetTestEnvironment().SubscriptionId;
        }

        protected MockContext TestContext { get; private set; }

        protected RecordedDelegatingHandler ResourceHandler { get; private set; }

        protected ResourceManagementClient ResourceManagementClient { get; private set; }

        protected PrivateDnsManagementClient PrivateDnsManagementClient { get; private set; }

        protected string SubscriptionId { get; private set; }

        public virtual void Dispose()
        {
            TestContext?.Dispose();
        }

        protected ResourceGroup CreateResourceGroup(string resourceGroupName = null)
        {
            return this.ResourceManagementClient.CreateResourceGroup(resourceGroupName: resourceGroupName);
        }

        protected PrivateZone CreatePrivateZone(string resourceGroupName, string privateZoneName = null, IDictionary<string, string> tags = null)
        {
            privateZoneName = privateZoneName ?? TestDataGenerator.GeneratePrivateZoneName();

            var createdPrivateZone = this.PrivateDnsManagementClient.PrivateZones.CreateOrUpdate(
                resourceGroupName: resourceGroupName,
                privateZoneName: privateZoneName,
                parameters: TestDataGenerator.GeneratePrivateZone(location: Constants.PrivateDnsZonesLocation, tags: tags));

            createdPrivateZone.Should().NotBeNull();
            return createdPrivateZone;
        }

        protected ICollection<PrivateZone> CreatePrivateZones(string resourceGroupName, int numPrivateZones = 2)
        {
            var createdPrivateZones = new List<PrivateZone>();
            for (var i = 0; i < numPrivateZones; i++)
            {
                createdPrivateZones.Add(this.CreatePrivateZone(resourceGroupName));
            }

            return createdPrivateZones;
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
