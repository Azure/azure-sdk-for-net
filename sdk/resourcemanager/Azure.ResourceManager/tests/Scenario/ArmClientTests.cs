﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    class ArmClientTests : ResourceManagerTestBase
    {
        class ProviderCounterPolicy : HttpPipelineSynchronousPolicy
        {
            //"https://management.azure.com/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute?api-version=2019-10-01"
            private ConcurrentDictionary<string, int> counter = new ConcurrentDictionary<string, int>();
            private Regex _resourceGroupPattern = new Regex(@"/subscriptions/[^/]+/providers/([^?/]+)\?api-version");

            public int GetCount(string nameSpace)
            {
                return counter.TryGetValue(nameSpace, out var count) ? count : 0;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                if (message.Request.Method == RequestMethod.Get)
                {
                    var match = _resourceGroupPattern.Match(message.Request.Uri.ToString());
                    if (match.Success)
                    {
                        var nameSpace = match.Groups[1].Value;
                        if (!counter.TryGetValue(nameSpace, out var current))
                        {
                            counter.TryAdd(nameSpace, 1);
                        }
                        else
                        {
                            counter[nameSpace] = current + 1;
                        }
                    }
                }
            }
        }

        class ResourceGroupVersionTracker : HttpPipelineSynchronousPolicy
        {
            //"https://management.azure.com/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute?api-version=2019-10-01"
            private Regex _resourceGroupPattern = new Regex(@"/resourcegroups/.*\?api-version=(\d\d\d\d-\d\d-\d\d)");

            public string VersionUsed { get; private set; }

            public override void OnSendingRequest(HttpMessage message)
            {
                var match = _resourceGroupPattern.Match(message.Request.Uri.ToString());
                if (match.Success)
                {
                    VersionUsed = match.Groups[1].Value;
                }
            }
        }

        private string _rgName;
        private readonly string _location = "southcentralus";

        public ArmClientTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task LocalOneTimeSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("testRg-");
            Subscription subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            var op = InstrumentOperation(rgCollection.CreateOrUpdate(_rgName, new ResourceGroupData(_location), waitForCompletion: false));
            op.WaitForCompletion();
            await StopSessionRecordingAsync();
        }

        [RecordedTest]
        public async Task VerifyDefaultEnumVersionUsed()
        {
            ResourceGroupVersionTracker tracker = new ResourceGroupVersionTracker();
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(tracker, HttpPipelinePosition.PerCall);
            var client = GetArmClient(options);
            var subscription = await client.GetDefaultSubscriptionAsync();
            var rgCollection = subscription.GetResourceGroups();
            _ = await rgCollection.CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"), new ResourceGroupData(AzureLocation.WestUS));

            Assert.AreEqual(GetDefaultResourceGroupVersion(rgCollection), tracker.VersionUsed);
        }

        private static string GetDefaultResourceGroupVersion(ResourceGroupCollection rgCollection)
        {
            var restClient = rgCollection.GetType().GetField("_restClient", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rgCollection) as ResourceGroupsRestOperations;
            return restClient.GetType().GetField("apiVersion", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(restClient) as string;
        }

        [RecordedTest]
        public async Task VerifyOverrideEnumVersionUsed()
        {
            ResourceGroupVersionTracker tracker1 = new ResourceGroupVersionTracker();
            ResourceGroupVersionTracker tracker2 = new ResourceGroupVersionTracker();
            ArmClientOptions options1 = new ArmClientOptions();
            string versionOverride = "2021-01-01";
            options1.SetApiVersion(ResourceGroup.ResourceType, versionOverride);
            ArmClientOptions options2 = new ArmClientOptions();
            options1.AddPolicy(tracker1, HttpPipelinePosition.PerCall);
            options2.AddPolicy(tracker2, HttpPipelinePosition.PerCall);
            var client1 = GetArmClient(options1);
            var client2 = GetArmClient(options2);
            var subscription1 = await client1.GetDefaultSubscriptionAsync();
            var subscription2 = await client2.GetDefaultSubscriptionAsync();
            var rgCollection1 = subscription1.GetResourceGroups();
            var rgCollection2 = subscription2.GetResourceGroups();
            _ = await rgCollection1.CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"), new ResourceGroupData(AzureLocation.WestUS));
            _ = await rgCollection2.CreateOrUpdateAsync(Recording.GenerateAssetName("testRg-"), new ResourceGroupData(AzureLocation.WestUS));

            Assert.AreEqual(versionOverride, tracker1.VersionUsed);
            Assert.AreEqual(GetDefaultResourceGroupVersion(rgCollection2), tracker2.VersionUsed);
        }

        [RecordedTest]
        public async Task GetUsedResourceApiVersion()
        {
            ProviderCounterPolicy policy = new ProviderCounterPolicy();
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            var client = GetArmClient(options);
            var subscription = await client.GetDefaultSubscriptionAsync();
            var version = await subscription.GetProviders().TryGetApiVersionAsync(new ResourceType("Microsoft.Compute/virtualMachines"));
            Assert.NotNull(version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));

            version = await subscription.GetProviders().TryGetApiVersionAsync(new ResourceType("Microsoft.Compute/availabilitySets"));
            Assert.NotNull(version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));
        }

        [RecordedTest]
        public async Task GetUsedResourceApiVersionWithOverride()
        {
            ProviderCounterPolicy policy = new ProviderCounterPolicy();
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);

            string expectedVersion = "myVersion";
            var computeResourceType = new ResourceType("Microsoft.Compute/virtualMachines");
            options.SetApiVersion(computeResourceType, expectedVersion);

            var client = GetArmClient(options);
            var subscription = await client.GetDefaultSubscriptionAsync();
            var version = await subscription.GetProviders().TryGetApiVersionAsync(computeResourceType);
            Assert.AreEqual(expectedVersion, version);
            Assert.AreEqual(0, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));

            policy = new ProviderCounterPolicy();
            options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);

            client = GetArmClient(options);
            subscription = await client.GetDefaultSubscriptionAsync();
            version = await subscription.GetProviders().TryGetApiVersionAsync(computeResourceType);
            Assert.AreNotEqual(expectedVersion, version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));
        }

        [RecordedTest]
        public void GetUsedResourceApiVersionInvalidResource()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                var subscription = await Client.GetDefaultSubscriptionAsync();
                await subscription.GetProviders().TryGetApiVersionAsync(new ResourceType("Microsoft.Compute/fakeStuff"));
            });
        }

        [RecordedTest]
        public void GetUsedResourceApiVersionInvalidNamespace()
        {
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                var subscription = await Client.GetDefaultSubscriptionAsync();
                await subscription.GetProviders().TryGetApiVersionAsync(new ResourceType("Microsoft.Fake/fakeStuff"));
            });
        }

        [RecordedTest]
        [SyncOnly]
        public void ConstructWithInvalidSubscription()
        {
            var client = new ArmClient(Guid.NewGuid().ToString(), TestEnvironment.Credential);
            var ex = Assert.Throws<RequestFailedException>(() => client.GetDefaultSubscription());
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public void TestArmClientParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(null, null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(baseUri: null, null, null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(defaultSubscriptionId: null, null, null); });
        }

        [RecordedTest]
        public void GetGenericOperationsTests()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-2",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-3",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-4"
            };

            var genericResourceOperationsList = Client.GetGenericResources(ids);

            int index = 0;
            foreach (GenericResource operations in genericResourceOperationsList)
            {
                Assert.AreEqual(ids[index], operations.Id.ToString());
                index++;
            }

            genericResourceOperationsList = Client.GetGenericResources(ids[0], ids[1], ids[2], ids[3]);

            index = 0;
            foreach (GenericResource operations in genericResourceOperationsList)
            {
                Assert.AreEqual(ids[index], operations.Id.ToString());
                index++;
            }
        }

        [RecordedTest]
        public void GetGenericResourcesOperationsTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/providers/Microsoft.Compute/virtualMachines/myVm";
            Assert.AreEqual(id, Client.GetGenericResource(new ResourceIdentifier(id)).Id.ToString());
        }

        [RecordedTest]
        public void GetGenericResourceOperationsSingleIDTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.AreEqual(id, Client.GetGenericResource(new ResourceIdentifier(id)).Id.ToString());
        }

        [RecordedTest]
        public async Task GetGenericResourceOperationsWithSingleValidResource()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            var genericResourceOperations = Client.GetGenericResource(new ResourceIdentifier(id));
            var genericResource = await genericResourceOperations.GetAsync();
            Assert.AreEqual(200, genericResource.GetRawResponse().Status);
        }

        [RecordedTest]
        public void GetGenericResourceOperationsWithSingleInvalidResource()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            var genericResourceOperations = Client.GetGenericResource(new ResourceIdentifier(id));
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task GetGenericOperationsWithListOfValidResource()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}"
            };

            var genericResourceOperationsList = Client.GetGenericResources(ids);

            foreach (GenericResource operations in genericResourceOperationsList)
            {
                var genericResource = await operations.GetAsync();
                Assert.AreEqual(200, genericResource.GetRawResponse().Status);
            }
        }

        [RecordedTest]
        public void GetGenericOperationsWithListOfInvalidResource()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/non-existent"
            };

            var genericResourceOperationsList = Client.GetGenericResources(ids);

            foreach (GenericResource operations in genericResourceOperationsList)
            {
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operations.GetAsync());
                Assert.AreEqual(404, exception.Status);
            }
        }

        [RecordedTest]
        public void GetGenericResourceOperationWithNullSetOfIds()
        {
            string[] x = null;
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResources(x); });
        }

        [RecordedTest]
        public void GetGenericResourceOperationWithNullId()
        {
            ResourceIdentifier x = null;
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResource(x); });
        }

        [RecordedTest]
        public void GetGenericResourceOperationEmptyTest()
        {
            var ids = new List<string>();
            Assert.AreEqual(new List<string>(), Client.GetGenericResources(ids));
        }

        [RecordedTest]
        [SyncOnly]
        public void ValidateMgmtTelemetry()
        {
            var options = new ArmClientOptions();
            var pipeline = ManagementPipelineBuilder.Build(new MockCredential(), new Uri("http://foo.com"), options);
            Assert.IsNull(GetPolicyFromPipeline(pipeline, nameof(MgmtTelemetryPolicy)));

            var client = GetArmClient(options);
            Assert.IsNotNull(GetPolicyFromPipeline(GetPipelineFromClient(client), nameof(MgmtTelemetryPolicy)));

            options = new ArmClientOptions();
            options.Diagnostics.IsTelemetryEnabled = false;
            client = GetArmClient(options);
            Assert.IsNull(GetPolicyFromPipeline(GetPipelineFromClient(client), nameof(MgmtTelemetryPolicy)));
            Assert.IsNull(GetPolicyFromPipeline(GetPipelineFromClient(client), "TelemetryPolicy"));
        }

        [RecordedTest]
        [SyncOnly]
        public void ValidateMgmtTelemetryComesAfterTelemetry()
        {
            var client = GetArmClient();
            var pipeline = GetPipelineFromClient(client);
            bool foundTelemetry = false;
            foreach (var policy in GetPoliciesFromPipeline(pipeline).ToArray())
            {
                foundTelemetry |= policy.GetType().Name == "TelemetryPolicy";
                if (policy.GetType() == typeof(MgmtTelemetryPolicy))
                {
                    Assert.IsTrue(foundTelemetry);
                    break;
                }
            }
        }

        private static HttpPipeline GetPipelineFromClient(ArmClient client)
        {
            var pipelineProperty = client.GetType().GetProperty("Pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty);
            return pipelineProperty.GetValue(client) as HttpPipeline;
        }

        private object GetPolicyFromPipeline(HttpPipeline pipeline, string policyType)
        {
            ReadOnlyMemory<HttpPipelinePolicy> policies = GetPoliciesFromPipeline(pipeline);
            return policies.ToArray().FirstOrDefault(p => p.GetType().Name == policyType);
        }

        private static ReadOnlyMemory<HttpPipelinePolicy> GetPoliciesFromPipeline(HttpPipeline pipeline)
        {
            var policyField = pipeline.GetType().GetField("_pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            policyField ??= pipeline.GetType().BaseType.GetField("_pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            return (ReadOnlyMemory<HttpPipelinePolicy>)policyField.GetValue(pipeline);
        }
    }
}
