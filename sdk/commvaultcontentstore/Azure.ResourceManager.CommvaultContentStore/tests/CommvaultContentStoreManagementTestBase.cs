// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CommvaultContentStore.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.CommvaultContentStore.Tests
{
    public class CommvaultContentStoreManagementTestBase : ManagementRecordedTestBase<CommvaultContentStoreManagementTestEnvironment>
    {
        public class ModelSerializationTests
        {
            private const string SaasResourcePath = "/subscriptions/123e4567-e89b-12d3-a456-426614174000/resourceGroups/test/providers/Microsoft.SaaS/resources/subscription";

            [Test]
            public void ActivationIdentifiersRoundTripWithOriginalWireNames()
            {
                Guid subscriptionGuid = Guid.Parse("123e4567-e89b-12d3-a456-426614174000");
                var content = new ActivateSaaSParameterContent(subscriptionGuid)
                {
                    ActivationDetails = new SaaSActivationDetails
                    {
                        SaasResourceId = new ResourceIdentifier(SaasResourcePath)
                    }
                };

                BinaryData data = ModelReaderWriter.Write(content, new ModelReaderWriterOptions("W"));
                using JsonDocument document = JsonDocument.Parse(data.ToString());
                Assert.That(document.RootElement.GetProperty("saasGuid").GetGuid(), Is.EqualTo(subscriptionGuid));
                Assert.That(document.RootElement.GetProperty("activateSaaSRequestParam").GetProperty("saasResourceId").GetString(), Is.EqualTo(SaasResourcePath));
                Assert.That(document.RootElement.TryGetProperty("activationDetails", out _), Is.False);

                ActivateSaaSParameterContent roundTrip = ModelReaderWriter.Read<ActivateSaaSParameterContent>(data, new ModelReaderWriterOptions("W"));
                Assert.That(roundTrip.SaasGuid, Is.EqualTo(subscriptionGuid));
                Assert.That(roundTrip.ActivationDetails.SaasResourceId.ToString(), Is.EqualTo(SaasResourcePath));
            }

            [Test]
            public void ActivationDetailsCanBeOmitted()
            {
                var content = new ActivateSaaSParameterContent(Guid.NewGuid());
                BinaryData data = ModelReaderWriter.Write(content, new ModelReaderWriterOptions("W"));
                using JsonDocument document = JsonDocument.Parse(data.ToString());
                Assert.That(document.RootElement.TryGetProperty("activateSaaSRequestParam", out _), Is.False);
                Assert.That(ModelReaderWriter.Read<ActivateSaaSParameterContent>(data).ActivationDetails, Is.Null);
            }

            [TestCase("{}")]
            [TestCase("{\"saasResourceId\":null}")]
            public void SaasResourceIdRemainsOptional(string json)
            {
                SaaSActivationDetails details = ModelReaderWriter.Read<SaaSActivationDetails>(BinaryData.FromString(json));
                Assert.That(details.SaasResourceId, Is.Null);

                BinaryData data = ModelReaderWriter.Write(details, new ModelReaderWriterOptions("W"));
                using JsonDocument document = JsonDocument.Parse(data.ToString());
                Assert.That(document.RootElement.TryGetProperty("saasResourceId", out _), Is.False);
            }

            [Test]
            public void ActivationRejectsOpaqueGuidValues()
            {
                BinaryData data = BinaryData.FromString("{\"saasGuid\":\"opaque-token\"}");
                Assert.Throws<FormatException>(() => ModelReaderWriter.Read<ActivateSaaSParameterContent>(data));
            }

            [Test]
            public void RoleAssignmentsRetainOriginalWireName()
            {
                CloudAccountProperties properties = ArmCommvaultContentStoreModelFactory.CloudAccountProperties();
                properties.RoleAssignmentsOnCreate.Add(new CommvaultRoleAssignment(
                    CommvaultRoleName.BackupAdmin,
                    new[] { new CommvaultEntityInfo() }));

                BinaryData data = ModelReaderWriter.Write(properties, new ModelReaderWriterOptions("W"));
                using JsonDocument document = JsonDocument.Parse(data.ToString());
                Assert.That(document.RootElement.GetProperty("roleAssignmentsOnCcaCreate").GetArrayLength(), Is.EqualTo(1));
                Assert.That(document.RootElement.TryGetProperty("roleAssignmentsOnCreate", out _), Is.False);
                Assert.That(ModelReaderWriter.Read<CloudAccountProperties>(data).RoleAssignmentsOnCreate.Count, Is.EqualTo(1));
            }

            [Test]
            public void ProtectionGroupBackupTimeRetainsIntegerWireValue()
            {
                const long backupTime = 1728000000123;
                ProtectionGroupProperties properties = ArmCommvaultContentStoreModelFactory.ProtectionGroupProperties(
                    plan: "testPlan",
                    resources: new ProtectionGroupResources(),
                    protectionStatus: CommvaultProtectionStatus.Protected,
                    numberOfProtectedItems: 1,
                    lastBackupTime: backupTime);
                BinaryData data = ModelReaderWriter.Write(properties);
                using JsonDocument document = JsonDocument.Parse(data.ToString());
                Assert.That(document.RootElement.GetProperty("lastBackUpTime").GetInt64(), Is.EqualTo(backupTime));
                Assert.That(ModelReaderWriter.Read<ProtectionGroupProperties>(data).LastBackupTime, Is.EqualTo(backupTime));
            }

            [Test]
            public void ProtectedItemBackupTimeRetainsIntegerWireValue()
            {
                const long backupTime = 1728000000123;
                ProtectedItemProperties properties = ArmCommvaultContentStoreModelFactory.ProtectedItemProperties(
                    resourceName: "testVm",
                    lastBackupTime: backupTime,
                    resourceGroup: "test",
                    location: AzureLocation.EastUS,
                    vmGuid: "123e4567-e89b-12d3-a456-426614174000");
                BinaryData data = ModelReaderWriter.Write(properties);
                using JsonDocument document = JsonDocument.Parse(data.ToString());
                Assert.That(document.RootElement.GetProperty("lastBackUpTime").GetInt64(), Is.EqualTo(backupTime));
                Assert.That(ModelReaderWriter.Read<ProtectedItemProperties>(data).LastBackupTime, Is.EqualTo(backupTime));
            }
        }

        public class CloudAccountPatchTests
        {
            private const string CloudAccountPath = "/subscriptions/123e4567-e89b-12d3-a456-426614174000/resourceGroups/test/providers/Commvault.ContentStore/cloudAccounts/test-account";

            [TestCase(false, "tags")]
            [TestCase(true, "tags")]
            [TestCase(false, "identity")]
            [TestCase(true, "identity")]
            [TestCase(false, "removeIdentity")]
            [TestCase(true, "removeIdentity")]
            [TestCase(false, "properties")]
            [TestCase(true, "properties")]
            [TestCase(false, "empty")]
            [TestCase(true, "empty")]
            public async Task UpdateSendsOnlySuppliedFields(bool isAsync, string scenario)
            {
                var patch = new CloudAccountPatch();
                string expectedBody;
                switch (scenario)
                {
                    case "tags":
                        patch.Tags.Add("environment", "test");
                        expectedBody = "{\"tags\":{\"environment\":\"test\"}}";
                        break;
                    case "identity":
                        patch.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
                        expectedBody = "{\"identity\":{\"type\":\"SystemAssigned\"}}";
                        break;
                    case "removeIdentity":
                        patch.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
                        expectedBody = "{\"identity\":{\"type\":\"None\"}}";
                        break;
                    case "properties":
                        patch.Properties = new CloudAccountPatchProperties
                        {
                            Company = new CompanyProfile { CompanyName = "Test Company" }
                        };
                        expectedBody = "{\"properties\":{\"company\":{\"companyName\":\"Test Company\"}}}";
                        break;
                    default:
                        expectedBody = "{}";
                        break;
                }

                string requestBody = null;
                var transport = MockTransport.FromMessageCallback(message =>
                {
                    using var stream = new MemoryStream();
                    message.Request.Content.WriteTo(stream, CancellationToken.None);
                    requestBody = Encoding.UTF8.GetString(stream.ToArray());
                    return new MockResponse(200).SetContent(
                        $"{{\"id\":\"{CloudAccountPath}\",\"name\":\"test-account\",\"type\":\"Commvault.ContentStore/cloudAccounts\",\"location\":\"eastus\"}}");
                });
                var resourceId = new ResourceIdentifier(CloudAccountPath);
                var client = new ArmClient(new MockCredential(), resourceId.SubscriptionId, new ArmClientOptions { Transport = transport });
                CloudAccountResource resource = client.GetCloudAccountResource(resourceId);

                ArmOperation<CloudAccountResource> operation = isAsync
                    ? await resource.UpdateAsync(WaitUntil.Completed, patch)
                    : resource.Update(WaitUntil.Completed, patch);

                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.Value.Id, Is.EqualTo(resourceId));
                Assert.That(transport.Requests, Has.Count.EqualTo(1));
                Assert.That(transport.SingleRequest.Method, Is.EqualTo(RequestMethod.Patch));
                Assert.That(transport.SingleRequest.Uri.ToUri().AbsolutePath, Is.EqualTo(CloudAccountPath));
                Assert.That(transport.SingleRequest.Uri.ToUri().Query, Is.EqualTo("?api-version=2026-09-30"));
                Assert.That(requestBody, Is.EqualTo(expectedBody));
            }
        }

        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected CommvaultContentStoreManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected CommvaultContentStoreManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
