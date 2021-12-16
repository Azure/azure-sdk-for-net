using System;
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
            Subscription subscription = await GlobalClient.GetSubscriptions().GetIfExistsAsync(SessionEnvironment.SubscriptionId);
            var op = InstrumentOperation(subscription.GetResourceGroups().Construct(_location).CreateOrUpdate(_rgName, waitForCompletion: false));
            op.WaitForCompletion();
            await StopSessionRecordingAsync();
        }

        [RecordedTest]
        [SyncOnly]
        public void GetUsedResourceApiVersion()
        {
            ProviderCounterPolicy policy = new ProviderCounterPolicy();
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            var client = GetArmClient(options);
            var version = client.GetResourceApiVersion(new ResourceType("Microsoft.Compute/virtualMachines"));
            Assert.NotNull(version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));

            version = client.GetResourceApiVersion(new ResourceType("Microsoft.Compute/availabilitySets"));
            Assert.NotNull(version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));
        }

        [RecordedTest]
        [SyncOnly]
        public void GetUsedResourceApiVersionWithOverride()
        {
            ProviderCounterPolicy policy = new ProviderCounterPolicy();
            ArmClientOptions options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);

            string expectedVersion = "myVersion";
            var computeResourceType = new ResourceType("Microsoft.Compute/virtualMachines");
            options.ResourceApiVersionOverrides.Add(computeResourceType, expectedVersion);

            var client = GetArmClient(options);
            var version = client.GetResourceApiVersion(computeResourceType);
            Assert.AreEqual(expectedVersion, version);
            Assert.AreEqual(0, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));

            policy = new ProviderCounterPolicy();
            options = new ArmClientOptions();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);

            client = GetArmClient(options);
            version = client.GetResourceApiVersion(computeResourceType);
            Assert.AreNotEqual(expectedVersion, version);
            Assert.AreEqual(1, policy.GetCount("Microsoft.Compute"));
            Assert.AreEqual(0, policy.GetCount("Microsoft.Network"));
        }

        [RecordedTest]
        [SyncOnly]
        public void GetUsedResourceApiVersionWithRpDefault()
        {
            string expectedVersion = FakeResourceApiVersions.Default;
            var fakeResourceType = new ResourceType("Microsoft.fakedService/fakedApi");

            var version = Client.GetResourceApiVersion(fakeResourceType);
            Assert.AreEqual(expectedVersion, version);
        }

        [RecordedTest]
        [SyncOnly]
        public void GetUsedResourceApiVersionInvalidResource()
        {
            Assert.Throws<InvalidOperationException>(() => { Client.GetResourceApiVersion(new ResourceType("Microsoft.Compute/fakeStuff")); });
        }

        [RecordedTest]
        [SyncOnly]
        public void GetUsedResourceApiVersionInvalidNamespace()
        {
            Assert.Throws<RequestFailedException>(() => { Client.GetResourceApiVersion(new ResourceType("Microsoft.Fake/fakeStuff")); });
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
                Assert.AreEqual(ids[index], operations.Id.StringValue);
                index++;
            }

            genericResourceOperationsList = Client.GetGenericResources(ids[0], ids[1], ids[2], ids[3]);

            index = 0;
            foreach (GenericResource operations in genericResourceOperationsList)
            {
                Assert.AreEqual(ids[index], operations.Id.StringValue);
                index++;
            }
        }

        [RecordedTest]
        public void GetGenericResourcesOperationsTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/providers/Microsoft.Compute/virtualMachines/myVm";
            Assert.AreEqual(id, Client.GetGenericResource(new ResourceIdentifier(id)).Id.StringValue);
        }

        [RecordedTest]
        public void GetGenericResourceOperationsSingleIDTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.AreEqual(id, Client.GetGenericResource(new ResourceIdentifier(id)).Id.StringValue);
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
