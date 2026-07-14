// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class JobDefinitionJobRunTests : StorageMoverManagementTestBase
    {
        public JobDefinitionJobRunTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task JobDefinitionJobRunTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().GetAsync(StorageMoverName)).Value;
            StorageMoverProjectResource project = (await storageMover.GetStorageMoverProjects().GetAsync(ProjectName)).Value;
            JobDefinitionCollection jobDefinitions = project.GetJobDefinitions();

            string jobDefinitionName = Recording.GenerateAssetName("jobdef-");
            JobDefinitionData jobDefinitionData = new JobDefinitionData(Models.StorageMoverCopyMode.Additive, NfsEndpointName, ContainerEndpointName);
            JobDefinitionResource jobDefinition = (await jobDefinitions.CreateOrUpdateAsync(WaitUntil.Completed, jobDefinitionName, jobDefinitionData)).Value;
            Assert.AreEqual(jobDefinitionName, jobDefinition.Data.Name);
            Assert.AreEqual(ContainerEndpointName, jobDefinition.Data.TargetName);
            Assert.AreEqual(NfsEndpointName, jobDefinition.Data.SourceName);
            Assert.AreEqual("Additive", jobDefinition.Data.CopyMode.ToString());

            jobDefinition = (await jobDefinitions.GetAsync(JobDefinitionName)).Value;

            int counter = 0;
            await foreach (JobDefinitionResource _ in jobDefinitions.GetAllAsync())
            {
                counter++;
            }
            Assert.GreaterOrEqual(counter, 1);

            Assert.IsTrue((await jobDefinitions.ExistsAsync(JobDefinitionName)).Value);

            JobDefinitionResource jobDefinition2 = (await jobDefinition.GetAsync()).Value;
            Assert.AreEqual(jobDefinition.Id.Name, jobDefinition2.Id.Name);
            Assert.AreEqual(jobDefinition.Id.Location, jobDefinition2.Id.Location);
            Assert.AreEqual(jobDefinition.Data.Name, jobDefinition2.Data.Name);
            Assert.AreEqual(jobDefinition.Data.TargetName, jobDefinition2.Data.TargetName);
            Assert.AreEqual(jobDefinition.Data.AgentName, jobDefinition2.Data.AgentName);
            Assert.AreEqual(jobDefinition.Data.SourceName, jobDefinition2.Data.SourceName);
            Assert.AreEqual(jobDefinition.Data.Id, jobDefinition2.Data.Id);

            JobRunResourceId jobRunResourceId = (await jobDefinition.StartJobAsync()).Value;

            jobRunResourceId = (await jobDefinition.StopJobAsync()).Value;
        }

        // Row #31 in cross-language scenario-tests matrix. Mirrors the JS/Python/CLI ports of
        // StartC2CJobWithPrivateSourceTest. End-to-end cross-cloud copy from a private AWS S3
        // bucket (via Multi-Cloud Connector) to a Blob container, with Private Link Service
        // approval and MSI RBAC on the target endpoint.
        //
        // NOTE: Marked [Ignore] until a live recording is captured. Status in the cross-language
        // tracker is 🆗 (code green, recordings pending) — matches the JS port. Remove the Ignore
        // once assets.json is updated with a fresh tag containing this session's cassette.
        [Test]
        [Ignore("Temporarily skipped until the C2C private-source recording is refreshed for the current Network privateEndpointConnections API version.")]
        [RecordedTest]
        public async Task StartC2CJobWithPrivateSourceTest()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroup(DefaultSubscription, ResourceGroupNamePrefix, WestCentralUsLocation);

            // Resources created cross-subscription that need explicit cleanup in finally.
            // Hoisted to outer scope so the finally block can stop/delete the JobDefinition
            // before tearing down the Connection — required because both fixture variants
            // (Sync + Async) share the same PLS and an active JobRun on one pins the
            // Connection slot, breaking the second variant's StartJob with NoValidConnectionFound.
            RoleAssignmentResource roleAssignment = null;
            StorageMoverConnectionResource connection = null;
            BlobContainerResource container = null;
            JobDefinitionResource jobDefinition = null;
            string jobRunName = null;

            try
            {
                // 1. Self-provision storage mover + project in WCUS.
                string storageMoverName = Recording.GenerateAssetName(StorageMoverPrefix);
                StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    storageMoverName,
                    new StorageMoverData(WestCentralUsLocation))).Value;

                string projectName = Recording.GenerateAssetName("project-");
                StorageMoverProjectResource project = (await storageMover.GetStorageMoverProjects().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    projectName,
                    new StorageMoverProjectData())).Value;

                // 2. Create the Storage Mover Connection against the shared cross-sub PLS and capture
                //    the auto-provisioned private-endpoint resource id.
                string connectionName = Recording.GenerateAssetName("conn-");
                StorageMoverConnectionData connectionData = new StorageMoverConnectionData(
                    new StorageMoverConnectionProperties(new ResourceIdentifier(PrivateLinkServiceId))
                    {
                        Description = "scenario private-bucket E2E",
                    });
                connection = (await storageMover.GetStorageMoverConnections().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    connectionName,
                    connectionData)).Value;
                Assert.IsNotNull(connection.Data.Properties);
                Assert.IsNotNull(connection.Data.Properties.PrivateEndpointResourceId, "Connection did not return a PrivateEndpointResourceId.");
                ResourceIdentifier privateEndpointId = connection.Data.Properties.PrivateEndpointResourceId;

                // 3. Find the corresponding pending PE-connection on the PLS. The PE takes ~30–60s
                //    to surface after the Storage Mover Connection PUT; retry with 15s backoff.
                PrivateLinkServiceResource privateLinkService = Client.GetPrivateLinkServiceResource(new ResourceIdentifier(PrivateLinkServiceId));
                NetworkPrivateEndpointConnectionResource pendingPeConnection = null;
                for (int attempt = 0; attempt < 10 && pendingPeConnection is null; attempt++)
                {
                    try
                    {
                        await foreach (NetworkPrivateEndpointConnectionResource peConn in privateLinkService.GetNetworkPrivateEndpointConnections().GetAllAsync())
                        {
                            if (peConn.Data?.PrivateEndpoint?.Id == privateEndpointId)
                            {
                                pendingPeConnection = peConn;
                                break;
                            }
                        }
                    }
                    catch (RequestFailedException ex) when (ex.Status == 404)
                    {
                        // PE-connection list not yet populated — keep retrying.
                    }

                    if (pendingPeConnection is null)
                    {
                        await Delay(15_000);
                    }
                }
                Assert.IsNotNull(pendingPeConnection, $"Did not find pending PE-connection for {privateEndpointId} within ~150s.");

                // 4. Approve the PE-connection.
                NetworkPrivateEndpointConnectionData approvalData = new NetworkPrivateEndpointConnectionData
                {
                    Name = pendingPeConnection.Data.Name,
                    ConnectionState = new NetworkPrivateLinkServiceConnectionState
                    {
                        Status = "Approved",
                        Description = "",
                        ActionsRequired = "None",
                    },
                };
                await pendingPeConnection.UpdateAsync(WaitUntil.Completed, approvalData);

                // 5. Poll the Storage Mover Connection until the RP reflects Approved (up to ~5 min).
                bool approved = false;
                for (int attempt = 0; attempt < 10 && !approved; attempt++)
                {
                    StorageMoverConnectionResource refreshed = (await connection.GetAsync()).Value;
                    if (refreshed.Data.Properties?.ConnectionStatus == StorageMoverConnectionStatus.Approved)
                    {
                        approved = true;
                        connection = refreshed;
                        break;
                    }
                    await Delay(30_000);
                }
                Assert.IsTrue(approved, "Storage Mover Connection did not reach Approved status within ~5 minutes.");

                // 5b. Create a fresh blob container under the shared cpmoveraccount. Using a
                //     per-test container (rather than the static TestStorageBlobContainerName)
                //     mirrors the Python/JS ports and avoids stale RBAC / data-plane state from
                //     prior runs that triggers RP-side "NoValidConnectionFound" at StartJob.
                //     12 chars (tc + 10 hex) keeps us comfortably inside Azure's 3-63 char limit.
                string containerName = "tc" + Recording.Random.NewGuid().ToString("N").Substring(0, 10);
                ResourceIdentifier sharedStorageAccountId = new ResourceIdentifier(TestStorageAccountId);
                BlobServiceResource sharedBlobService = Client.GetStorageAccountResource(sharedStorageAccountId).GetBlobService();
                container = (await sharedBlobService.GetBlobContainers().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    containerName,
                    new BlobContainerData())).Value;

                // 6. Create the target Blob endpoint with a system-assigned MSI.
                string targetEndpointName = Recording.GenerateAssetName("blob-tgt-");
                AzureStorageBlobContainerEndpointProperties targetProperties = new AzureStorageBlobContainerEndpointProperties(
                    TestStorageAccountId,
                    containerName)
                {
                    Description = "Target blob endpoint with MSI",
                };
                StorageMoverEndpointData targetEndpointData = new StorageMoverEndpointData(targetProperties)
                {
                    Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                };
                StorageMoverEndpointResource targetEndpoint = (await storageMover.GetStorageMoverEndpoints().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    targetEndpointName,
                    targetEndpointData)).Value;
                Assert.IsNotNull(targetEndpoint.Data.Identity, "Target endpoint did not return any identity.");
                Assert.IsNotNull(targetEndpoint.Data.Identity.PrincipalId, "Target endpoint MSI did not return a principalId.");
                Guid principalId = targetEndpoint.Data.Identity.PrincipalId.Value;

                // 7. Assign Storage Blob Data Contributor to the endpoint MSI at the container scope.
                //    The role definition id must be the fully qualified ARM path. Use the storage
                //    account's subscription as the scope owner.
                ResourceIdentifier storageAccountId = new ResourceIdentifier(TestStorageAccountId);
                ResourceIdentifier containerScopeId = new ResourceIdentifier(
                    $"{TestStorageAccountId}/blobServices/default/containers/{containerName}");
                ResourceIdentifier roleDefinitionId = new ResourceIdentifier(
                    $"/subscriptions/{storageAccountId.SubscriptionId}/providers/Microsoft.Authorization/roleDefinitions/{StorageBlobDataContributorRoleId}");

                // One generated GUID, reused for retry attempts and final cleanup so playback stays
                // deterministic and we can definitively remove the assignment.
                string roleAssignmentName = Recording.Random.NewGuid().ToString();
                RoleAssignmentCreateOrUpdateContent assignmentContent = new RoleAssignmentCreateOrUpdateContent(roleDefinitionId, principalId)
                {
                    PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
                };

                RoleAssignmentCollection assignments = Client.GetRoleAssignments(containerScopeId);
                // MSI principal propagation can take 30–60s; retry on PrincipalNotFound up to ~5 min.
                for (int attempt = 0; attempt < 10 && roleAssignment is null; attempt++)
                {
                    try
                    {
                        roleAssignment = (await assignments.CreateOrUpdateAsync(WaitUntil.Completed, roleAssignmentName, assignmentContent)).Value;
                    }
                    catch (RequestFailedException ex) when (ex.Status == 400 && ex.ErrorCode == "PrincipalNotFound")
                    {
                        await Delay(30_000);
                    }
                    catch (RequestFailedException ex) when (ex.Status == 409 && ex.ErrorCode == "RoleAssignmentExists")
                    {
                        roleAssignment = (await assignments.GetAsync(roleAssignmentName)).Value;
                    }
                }
                Assert.IsNotNull(roleAssignment, "Role assignment for endpoint MSI was not created within ~5 minutes.");

                // 8. Create the source MCC endpoint pointing at the private AWS S3 bucket.
                string sourceEndpointName = Recording.GenerateAssetName("mcc-src-");
                AzureMultiCloudConnectorEndpointProperties sourceProperties = new AzureMultiCloudConnectorEndpointProperties(
                    new ResourceIdentifier(MultiCloudConnectorId),
                    new ResourceIdentifier(AwsPrivateS3BucketId))
                {
                    Description = "Private AWS S3 source via MCC",
                    EndpointKind = StorageMoverEndpointKind.Source,
                };
                StorageMoverEndpointResource sourceEndpoint = (await storageMover.GetStorageMoverEndpoints().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    sourceEndpointName,
                    new StorageMoverEndpointData(sourceProperties))).Value;

                // 9. Create the C2C job-definition referencing the (now-approved) Connection.
                string jobDefinitionName = Recording.GenerateAssetName("c2cjob-");
                JobDefinitionData jobDefinitionData = new JobDefinitionData(StorageMoverCopyMode.Additive, sourceEndpoint.Data.Name, targetEndpoint.Data.Name)
                {
                    Description = "C2C job with private bucket source",
                    JobType = JobType.CloudToCloud,
                    SourceSubpath = "/",
                    TargetSubpath = "/",
                };
                jobDefinitionData.Connections.Add(connection.Id);
                jobDefinition = (await project.GetJobDefinitions().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    jobDefinitionName,
                    jobDefinitionData)).Value;
                Assert.AreEqual(jobDefinitionName, jobDefinition.Data.Name);
                Assert.AreEqual(1, jobDefinition.Data.Connections.Count);

                // 10. Start the job and capture the resulting job-run id.
                //     Even after Connection.Status flips to Approved, the StorageMover RP
                //     may take additional time to propagate connection readiness to the
                //     data plane. StartJob can briefly return NoValidConnectionFound during
                //     that window. Retry up to ~5 min before giving up.
                JobRunResourceId jobRunResourceId = null;
                for (int attempt = 0; attempt < 10 && jobRunResourceId is null; attempt++)
                {
                    try
                    {
                        jobRunResourceId = (await jobDefinition.StartJobAsync()).Value;
                    }
                    catch (RequestFailedException ex) when (ex.Status == 400 && ex.ErrorCode == "NoValidConnectionFound")
                    {
                        await Delay(30_000);
                    }
                }
                Assert.IsNotNull(jobRunResourceId, "StartJob did not succeed within ~5 minutes (NoValidConnectionFound).");
                Assert.IsFalse(string.IsNullOrEmpty(jobRunResourceId.JobRunResourceIdValue));

                // 11. Poll the job-run until it reaches a terminal state (Succeeded / Failed /
                //     Canceled). Fixed-iteration loop keeps playback deterministic; 30s cadence
                //     × 60 attempts = ~30 minutes wall-clock cap in live mode.
                jobRunName = new ResourceIdentifier(jobRunResourceId.JobRunResourceIdValue).Name;
                JobRunResource jobRun = null;
                bool terminal = false;
                for (int attempt = 0; attempt < 60 && !terminal; attempt++)
                {
                    jobRun = (await jobDefinition.GetJobRunAsync(jobRunName)).Value;
                    JobRunStatus? status = jobRun.Data.Status;
                    if (status == JobRunStatus.Succeeded
                        || status == JobRunStatus.Failed
                        || status == JobRunStatus.Canceled)
                    {
                        terminal = true;
                        break;
                    }
                    await Delay(30_000);
                }
                Assert.IsTrue(terminal, "Job run did not reach a terminal state within ~30 minutes.");
                Assert.AreEqual(JobRunStatus.Succeeded, jobRun.Data.Status);
            }
            finally
            {
                // True best-effort teardown: each step is independently try/caught so a
                // single failure can't abort the rest of the cleanup chain. Ordering matters:
                //  1) Stop the active JobRun  — frees the Connection slot on the shared PLS.
                //  2) Delete JobDefinition    — releases the Connection reference.
                //  3) Delete RoleAssignment   — releases the principal pin at container scope.
                //  4) Delete the container    — must come after RBAC removal.
                //  5) Delete the Connection   — now unblocked.
                //  6) Delete the ResourceGroup — catches anything residual.
                //
                // Without this ordering, the Sync fixture variant's cleanup throws at
                // connection.Delete (ConnectionInUseByActiveJob), the RG is never deleted,
                // and the Async variant then sees a stale Connection on the shared PLS and
                // fails StartJob with NoValidConnectionFound.

                if (jobDefinition is not null && jobRunName is not null)
                {
                    try
                    {
                        await jobDefinition.StopJobAsync();
                    }
                    catch (Exception ex)
                    {
                        TestContext.WriteLine($"Cleanup StopJob failed (continuing): {ex.Message}");
                    }
                }

                if (jobDefinition is not null)
                {
                    try
                    {
                        await jobDefinition.DeleteAsync(WaitUntil.Completed);
                    }
                    catch (Exception ex)
                    {
                        TestContext.WriteLine($"Cleanup JobDefinition.Delete failed (continuing): {ex.Message}");
                    }
                }

                if (roleAssignment is not null)
                {
                    try
                    {
                        await roleAssignment.DeleteAsync(WaitUntil.Completed);
                    }
                    catch (Exception ex)
                    {
                        TestContext.WriteLine($"Cleanup RoleAssignment.Delete failed (continuing): {ex.Message}");
                    }
                }

                if (container is not null)
                {
                    try
                    {
                        await container.DeleteAsync(WaitUntil.Completed);
                    }
                    catch (Exception ex)
                    {
                        TestContext.WriteLine($"Cleanup Container.Delete failed (continuing): {ex.Message}");
                    }
                }

                if (connection is not null)
                {
                    try
                    {
                        await connection.DeleteAsync(WaitUntil.Completed);
                        // Connection.Delete returns when the LRO completes, but the shared PLS
                        // takes additional time to release the slot on its side. Without this
                        // delay the second fixture variant's StartJob fails with
                        // NoValidConnectionFound. 60s was sometimes insufficient (observed
                        // under Storage RM 1.7.0 timings); 180s is the conservative margin.
                        // Delay() is recorded into the cassette so it collapses to a no-op in Playback.
                        await Delay(180_000);
                    }
                    catch (Exception ex)
                    {
                        TestContext.WriteLine($"Cleanup Connection.Delete failed (continuing): {ex.Message}");
                    }
                }

                try
                {
                    await resourceGroup.DeleteAsync(WaitUntil.Completed);
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine($"Cleanup ResourceGroup.Delete failed: {ex.Message}");
                }
            }
        }
    }
}
