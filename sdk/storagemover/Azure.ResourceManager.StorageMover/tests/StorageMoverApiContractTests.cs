// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests
{
    public class StorageMoverApiContractTests : ClientTestBase
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string StorageMoverId = "/subscriptions/" + SubscriptionId + "/resourceGroups/resource-group/providers/Microsoft.StorageMover/storageMovers/mover";
        private const string StorageAccountId = "/subscriptions/" + SubscriptionId + "/resourceGroups/resource-group/providers/Microsoft.Storage/storageAccounts/account";
        private const string PartnerStorageAccountId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/partner/providers/Microsoft.Storage/storageAccounts/partneraccount";
        private const string PartnerEndpointId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/partner/providers/Microsoft.StorageMover/storageMovers/partner/endpoints/target";
        private const string ConnectionId = StorageMoverId + "/connections/connection";
        private const string ProjectId = StorageMoverId + "/projects/project";
        private const string JobDefinitionId = ProjectId + "/jobDefinitions/job";

        public StorageMoverApiContractTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase("blob-cross-tenant")]
        [TestCase("smb-cross-tenant")]
        [TestCase("nfs-fsx")]
        [TestCase("smb-fsx")]
        public async Task EndpointRequestsMatchPythonApi(string endpointName)
        {
            EndpointBaseProperties properties;
            string expectedProperties;
            switch (endpointName)
            {
                case "blob-cross-tenant":
                    properties = new AzureStorageBlobContainerEndpointProperties(StorageAccountId, "container")
                    {
                        EndpointKind = StorageMoverEndpointKind.Target,
                        EnableCrossTenantTransfer = true,
                        AllowedStorageAccounts = { PartnerStorageAccountId },
                    };
                    expectedProperties = $$"""
                        {
                          "endpointType": "AzureStorageBlobContainer",
                          "storageAccountResourceId": "{{StorageAccountId}}",
                          "blobContainerName": "container",
                          "endpointKind": "Target",
                          "enableCrossTenantTransfer": true,
                          "allowedStorageAccounts": ["{{PartnerStorageAccountId}}"]
                        }
                        """;
                    break;
                case "smb-cross-tenant":
                    properties = new AzureStorageSmbFileShareEndpointProperties(new ResourceIdentifier(StorageAccountId), "share")
                    {
                        EndpointKind = StorageMoverEndpointKind.Target,
                        EnableCrossTenantTransfer = true,
                        AllowedStorageAccounts = { PartnerStorageAccountId },
                    };
                    expectedProperties = $$"""
                        {
                          "endpointType": "AzureStorageSmbFileShare",
                          "storageAccountResourceId": "{{StorageAccountId}}",
                          "fileShareName": "share",
                          "endpointKind": "Target",
                          "enableCrossTenantTransfer": true,
                          "allowedStorageAccounts": ["{{PartnerStorageAccountId}}"]
                        }
                        """;
                    break;
                case "nfs-fsx":
                    properties = new NfsMountEndpointProperties("10.0.0.5", "/export")
                    {
                        EndpointKind = StorageMoverEndpointKind.Source,
                        NfsVersion = NfsVersion.NFSv41,
                        SourceType = NfsMountSourceType.FSXEFS,
                    };
                    expectedProperties = """
                        {
                          "endpointType": "NfsMount",
                          "host": "10.0.0.5",
                          "export": "/export",
                          "endpointKind": "Source",
                          "nfsVersion": "NFSv4_1",
                          "sourceType": "FSX-EFS"
                        }
                        """;
                    break;
                default:
                    properties = new SmbMountEndpointProperties("10.0.0.6", "share")
                    {
                        EndpointKind = StorageMoverEndpointKind.Source,
                        SourceType = SmbMountSourceType.FSXSMB,
                        Credentials = new AzureKeyVaultSmbCredentials
                        {
                            UsernameUriString = "https://vault.vault.azure.net/secrets/username",
                            PasswordUriString = "https://vault.vault.azure.net/secrets/password",
                        },
                    };
                    expectedProperties = """
                        {
                          "endpointType": "SmbMount",
                          "host": "10.0.0.6",
                          "shareName": "share",
                          "endpointKind": "Source",
                          "sourceType": "FSX-SMB",
                          "credentials": {
                            "type": "AzureKeyVaultSmb",
                            "usernameUri": "https://vault.vault.azure.net/secrets/username",
                            "passwordUri": "https://vault.vault.azure.net/secrets/password"
                          }
                        }
                        """;
                    break;
            }

            string endpointId = StorageMoverId + "/endpoints/" + endpointName;
            MockTransport transport = CreateTransport(endpointId, expectedProperties);
            ArmClient client = CreateArmClient(transport);
            StorageMoverEndpointCollection endpoints = client.GetStorageMoverResource(new ResourceIdentifier(StorageMoverId)).GetStorageMoverEndpoints();

            await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, new StorageMoverEndpointData(properties));

            AssertRequest(transport.SingleRequest, RequestMethod.Put, endpointId, $$"""{"properties": {{expectedProperties}}}""");
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task JobDefinitionCreateRequestsMatchPythonApi(bool agentless)
        {
            JobDefinitionData data = new JobDefinitionData(StorageMoverCopyMode.Additive, "source", "target");
            string expectedProperties;
            if (agentless)
            {
                data.JobType = JobType.OnPremToCloudAgentLess;
                data.Connections.Add(new ResourceIdentifier(ConnectionId));
                expectedProperties = $$"""
                    {
                      "copyMode": "Additive",
                      "sourceName": "source",
                      "targetName": "target",
                      "jobType": "OnPremToCloudAgentLess",
                      "connections": ["{{ConnectionId}}"]
                    }
                    """;
            }
            else
            {
                data.JobType = JobType.CloudToCloud;
                data.IsCrossTenantJob = true;
                data.CrossTenantEndpointTenantId = "22222222-2222-2222-2222-222222222222";
                data.CrossTenantEndpointResourceId = new ResourceIdentifier(PartnerEndpointId);
                data.SyncMode = "SnapshotBased";
                data.MoverSyncedUntil = new DateTimeOffset(2026, 5, 1, 0, 0, 0, TimeSpan.Zero);
                data.Schedule = new StorageMoverScheduleInfo
                {
                    Frequency = StorageMoverScheduleFrequency.Hourly,
                    RepeatInterval = "PT1H",
                    IsActive = true,
                };
                expectedProperties = $$"""
                    {
                      "copyMode": "Additive",
                      "sourceName": "source",
                      "targetName": "target",
                      "jobType": "CloudToCloud",
                      "isCrossTenantJob": true,
                      "crossTenantEndpointTenantId": "22222222-2222-2222-2222-222222222222",
                      "crossTenantEndpointResourceId": "{{PartnerEndpointId}}",
                      "syncMode": "SnapshotBased",
                      "moverSyncedUntil": "2026-05-01T00:00:00.0000000Z",
                      "schedule": {"frequency": "Hourly", "repeatInterval": "PT1H", "isActive": true}
                    }
                    """;
            }

            MockTransport transport = CreateTransport(JobDefinitionId, expectedProperties);
            ArmClient client = CreateArmClient(transport);
            JobDefinitionCollection jobs = client.GetStorageMoverProjectResource(new ResourceIdentifier(ProjectId)).GetJobDefinitions();

            await jobs.CreateOrUpdateAsync(WaitUntil.Completed, "job", data);

            AssertRequest(transport.SingleRequest, RequestMethod.Put, JobDefinitionId, $$"""{"properties": {{expectedProperties}}}""");
        }

        [Test]
        public async Task JobDefinitionUpdateRequestMatchesPythonApi()
        {
            JobDefinitionPatch patch = new JobDefinitionPatch
            {
                Connections = { new ResourceIdentifier(ConnectionId) },
                SyncMode = "FullScan",
                MoverSyncedUntil = new DateTimeOffset(2026, 5, 2, 0, 0, 0, TimeSpan.Zero),
                Schedule = new StorageMoverScheduleInfo
                {
                    Frequency = StorageMoverScheduleFrequency.Hourly,
                    RepeatInterval = "PT2H",
                    IsActive = false,
                },
            };
            string expectedProperties = $$"""
                {
                  "connections": ["{{ConnectionId}}"],
                  "syncMode": "FullScan",
                  "moverSyncedUntil": "2026-05-02T00:00:00.0000000Z",
                  "schedule": {"frequency": "Hourly", "repeatInterval": "PT2H", "isActive": false}
                }
                """;
            MockTransport transport = CreateTransport(JobDefinitionId, expectedProperties);
            JobDefinitionResource job = CreateArmClient(transport).GetJobDefinitionResource(new ResourceIdentifier(JobDefinitionId));

            await job.UpdateAsync(patch);

            AssertRequest(transport.SingleRequest, RequestMethod.Patch, JobDefinitionId, $$"""{"properties": {{expectedProperties}}}""");
        }

        [Test]
        public async Task ReconcileJobRequestMatchesPythonApi()
        {
            MockResponse response = new MockResponse(200);
            response.SetContent($$"""{"jobRunResourceId": "{{JobDefinitionId}}/jobRuns/run"}""");
            MockTransport transport = new MockTransport(response);
            JobDefinitionResource job = CreateArmClient(transport).GetJobDefinitionResource(new ResourceIdentifier(JobDefinitionId));

            await job.ReconcileJobAsync();

            AssertRequest(transport.SingleRequest, RequestMethod.Post, JobDefinitionId + "/reconcileJob", null);
        }

        private ArmClient CreateArmClient(MockTransport transport)
        {
            return InstrumentClient(new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport }));
        }

        private static MockTransport CreateTransport(string resourceId, string properties)
        {
            MockResponse response = new MockResponse(200);
            response.SetContent($$"""{"id": "{{resourceId}}", "properties": {{properties}}}""");
            return new MockTransport(response);
        }

        private static void AssertRequest(MockRequest request, RequestMethod method, string path, string expectedBody)
        {
            Assert.AreEqual(method, request.Method);
            Assert.AreEqual(path, request.Uri.ToUri().AbsolutePath);
            Assert.AreEqual("?api-version=2026-05-01", request.Uri.ToUri().Query);
            if (expectedBody is null)
            {
                Assert.IsNull(request.Content);
                return;
            }

            using MemoryStream stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            string body = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(JsonNode.DeepEquals(JsonNode.Parse(expectedBody), JsonNode.Parse(body)), body);
        }
    }
}
