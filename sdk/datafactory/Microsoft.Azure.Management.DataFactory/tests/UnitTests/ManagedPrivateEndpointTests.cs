// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.JsonSamples;
using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Serialization;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DataFactory.Tests.UnitTests
{
    public class ManagedPrivateEndpointTests : BaseUnitTest
    {
        // Enable Xunit test output logger.
        protected readonly ITestOutputHelper logger = new TestOutputHelper();

        public ManagedPrivateEndpointTests(ITestOutputHelper logger)
            : base()
        {
            this.logger = logger;
        }

        [Theory]
        [ClassData(typeof(ManagedPrivateEndpointJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void ManagedPrivateEndpoint_SerializationTest(JsonSampleInfo jsonSample)
        {
            TestJsonSample<ManagedPrivateEndpointResource>(jsonSample);
        }

        [Fact]
        public void ManagedPrivateEndpoint_BlobTest()
        {
            string groupId = "blob";
            ManagedPrivateEndpointResource managedPrivateEndpointResource = new ManagedPrivateEndpointResource
            {
                Properties = new ManagedPrivateEndpoint
                {
                    GroupId = groupId,
                    PrivateLinkResourceId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/sampleResourceGroup/providers/Microsoft.Storage/storageAccounts/sampleStorageAccount"
                }
            };

            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            var json = SafeJsonConvert.SerializeObject(managedPrivateEndpointResource, client.SerializationSettings);
            Assert.Contains(groupId, json);
        }
    }
}
