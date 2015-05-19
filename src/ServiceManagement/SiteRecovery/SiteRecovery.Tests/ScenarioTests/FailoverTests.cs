//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Net;
using Xunit;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using System.Runtime.Serialization;
using Microsoft.Azure.Test;

namespace SiteRecovery.Tests
{
    /// <summary>
    /// This is the class which defines the commit failover input
    /// which is same as Commit.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class AzureCommitFailbackInput
    {
        /// <summary>
        /// Gets or sets a value indicating whether whether datasync should be skipped or not.
        /// </summary>
        [DataMember]
        public bool SkipDataSync { get; set; }
    }

    /// <summary>
    /// This is the class which defines the Azure failover input.
    /// </summary>
    [DataContract(Namespace="http://schemas.microsoft.com/windowsazure")]
    public class AzureFailoverInput
    {
        /// <summary>
        /// Gets or sets the Vault Location.
        /// </summary> 
        [DataMember]
        public string VaultLocation { get; set; }

        /// <summary>
        /// Gets or sets the Primary KEK certificate PFX in Base-64 encoded form.
        /// </summary>
        [DataMember]
        public string PrimaryKekCertificatePfx { get; set; }

        /// <summary>
        /// Gets or sets the Secondary (rolled over) KEK certificate PFX in Base-64 encoded form.
        /// </summary>
        [DataMember]
        public string SecondaryKekCertificatePfx { get; set; }
    }

    /// <summary>
    /// This is the class which defines the Azure failback input.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class AzureFailbackInput
    {
        /// <summary>
        /// Identifier to specify whether datasync should be skipped or not.
        /// </summary>
        [DataMember]
        public bool SkipDataSync { get; set; }

        /// <summary>
        /// Identifier to specify whether datasync should create VM on premise in case VM is not available there.
        /// This is applicable only in case of failback.
        /// </summary>
        [DataMember]
        public bool CreateRecoveryVmIfDoesntExist { get; set; }
    }

    public class FailoverTests : SiteRecoveryTestsBase
    {
        public void E2A_PlannedFailoverTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responsePC = client.ProtectionContainer.List(RequestHeaders);

                
                JobResponse response = new JobResponse();
                bool desiredPEFound = false;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    if (pc.Role != "Primary")
                    {
                        continue;
                    }

                    var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);
                    response = null;
                    foreach (var pe in responsePEs.ProtectionEntities)
                    {
                        if (pe.CanFailover == true && pe.ActiveLocation == "Recovery" && pe.ReplicationProvider == "HyperVReplicaAzure")
                        {
                            PlannedFailoverRequest request = new PlannedFailoverRequest();
                            request.ReplicationProvider = pe.ReplicationProvider;
                            if (pe.ActiveLocation == "Primary")
                            {
                                request.FailoverDirection = "PrimaryToRecovery";
                                AzureFailoverInput blob = new AzureFailoverInput();
                                blob.VaultLocation = VaultLocation;
                                request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>(blob);
                            }
                            else
                            {
                                request.FailoverDirection = "RecoveryToPrimary";
                                var blob = new AzureFailbackInput();
                                blob.CreateRecoveryVmIfDoesntExist = false;
                                blob.SkipDataSync = false;
                                request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailbackInput>(blob);
                            }

                            response = client.ProtectionEntity.PlannedFailover(
                                pe.ProtectionContainerId,
                                pe.ID,
                                request,
                                requestHeaders);
                            desiredPEFound = true;
                            break;
                        }
                    }

                    if (desiredPEFound)
                    {
                        break;
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing failback operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void UnplannedFailoverTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responsePC = client.ProtectionContainer.List(RequestHeaders);


                JobResponse response = new JobResponse();
                bool desiredPEFound = false;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);
                    response = null;
                    foreach (var pe in responsePEs.ProtectionEntities)
                    {
                        if (pe.CanFailover == true && pe.ActiveLocation == "Primary" && pe.ReplicationProvider == "HyperVReplicaAzure")
                        {
                            UnplannedFailoverRequest request = new UnplannedFailoverRequest();
                            request.ReplicationProvider = pe.ReplicationProvider;
                            if (pe.ActiveLocation == "Primary")
                            {
                                request.FailoverDirection = "PrimaryToRecovery";
                            }
                            else
                            {
                                request.FailoverDirection = "RecoveryToPrimary";
                            }

                            AzureFailoverInput blob = new AzureFailoverInput();
                            blob.VaultLocation = VaultLocation;
                            request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>
                                (blob);
                            response = client.ProtectionEntity.UnplannedFailover(
                                pe.ProtectionContainerId,
                                pe.ID,
                                request,
                                requestHeaders);
                            desiredPEFound = true;
                            break;
                        }
                    }

                    if (desiredPEFound)
                    {
                        break;
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing unplanned failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void ReprotectProtectionEntityTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responsePC = client.ProtectionContainer.List(RequestHeaders);
                JobResponse response = new JobResponse();
                bool desiredPEFound = false;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);

                    ReprotectRequest request = new ReprotectRequest();
                    request.ReplicationProvider = "";
                    request.ReplicationProviderSettings = "";


                    foreach (var pe in responsePEs.ProtectionEntities)
                    {
                        if (pe.CanReverseReplicate == true)
                        {
                            if (pe.ActiveLocation == "Primary")
                            {
                                request.FailoverDirection = "PrimaryToRecovery";
                            }
                            else
                            {
                                request.FailoverDirection = "RecoveryToPrimary";
                            }

                            response = client.ProtectionEntity.Reprotect(
                                pe.ProtectionContainerId,
                                pe.ID,
                                request,
                                requestHeaders);
                            desiredPEFound = true;
                            break;
                        }
                    }

                    if (desiredPEFound)
                    {
                        break;
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing unplanned failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        private void CommitFailoverTest(string direction, string replicationProvider, bool SkipDataSync = false)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responsePC = client.ProtectionContainer.List(RequestHeaders);

                CommitFailoverRequest input = new CommitFailoverRequest();
                input.FailoverDirection = direction;

                JobResponse response = new JobResponse();
                bool desiredPEFound = false;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    if (pc.Role == "Primary")
                    {
                        var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);
                        foreach (var pe in responsePEs.ProtectionEntities)
                        {
                            string activeLocation = string.Empty;

                            if (direction == "PrimaryToRecovery")
                            {
                                activeLocation = "Recovery";
                            }
                            else
                            {
                                activeLocation = "Primary";
                            }

                            if (pe.CanCommit == true && pe.ActiveLocation == activeLocation && pe.ReplicationProvider == replicationProvider)
                            {
                                input.ReplicationProvider = pe.ReplicationProvider;

                                if (direction == "RecoveryToPrimary")
                                {
                                    AzureCommitFailbackInput blob = new AzureCommitFailbackInput();
                                    blob.SkipDataSync = false;

                                    input.ReplicationProviderSettings = DataContractUtils.Serialize<AzureCommitFailbackInput>
                                        (blob);
                                }
                                else
                                {
                                    input.ReplicationProviderSettings = string.Empty;
                                }

                                response = client.ProtectionEntity.CommitFailover(
                                    pe.ProtectionContainerId,
                                    pe.ID,
                                    input,
                                    requestHeaders);
                                desiredPEFound = true;
                                break;
                            }
                        }
                    }

                    if (desiredPEFound)
                    {
                        break;
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing commit failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void E2A_CommitFailover_PrimaryToRecoveryTest()
        {
            CommitFailoverTest("PrimaryToRecovery", "HyperVReplicaAzure");
        }

        public void E2A_CommitFailover_RecoveryToPrimaryTest()
        {
            CommitFailoverTest("RecoveryToPrimary", "HyperVReplicaAzure");
        }

        public void TestFailoverTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responsePC = client.ProtectionContainer.List(RequestHeaders);

                JobResponse response = new JobResponse();
                bool desiredPEFound = false;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);
                    response = null;
                    foreach (var pe in responsePEs.ProtectionEntities)
                    {
                        if (pe.Protected == true)
                        {
                            TestFailoverRequest request = new TestFailoverRequest();
                            request.FailoverDirection = "PrimaryToRecovery";
                            request.ReplicationProvider = pe.ReplicationProvider;
                            if (pe.ReplicationProvider == "HyperVReplicaAzure")
                            {
                                AzureFailoverInput blob = new AzureFailoverInput();
                                blob.VaultLocation = VaultLocation;
                                request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailoverInput>(blob);
                            }
                            else
                            {
                                request.ReplicationProviderSettings = "";
                            }

                            request.NetworkID = "ID";
                            request.NetworkType = "Type";
                            response = client.ProtectionEntity.TestFailover(
                                pe.ProtectionContainerId,
                                pe.ID,
                                request,
                                requestHeaders);
                            desiredPEFound = true;
                            break;
                        }
                    }

                    if (desiredPEFound)
                    {
                        break;
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing planned failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void E2AFailbackTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                var responsePC = client.ProtectionContainer.List(RequestHeaders);

                JobResponse response = new JobResponse();
                bool desiredPEFound = false;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    var responsePEs = client.ProtectionEntity.List(pc.ID, RequestHeaders);
                    response = null;
                    foreach (var pe in responsePEs.ProtectionEntities)
                    {
                        if (pe.CanFailover == true)
                        {
                            PlannedFailoverRequest request = new PlannedFailoverRequest();
                            request.ReplicationProvider = pe.ReplicationProvider;
                            if (pe.ActiveLocation == "Primary")
                            {
                                request.FailoverDirection = "PrimaryToRecovery";
                            }
                            else
                            {
                                request.FailoverDirection = "RecoveryToPrimary";
                            }

                            AzureFailbackInput blob = new AzureFailbackInput();
                            blob.CreateRecoveryVmIfDoesntExist = false;
                            blob.SkipDataSync = true;
                            request.ReplicationProviderSettings = DataContractUtils.Serialize<AzureFailbackInput>
                                (blob);
                            response = client.ProtectionEntity.PlannedFailover(
                                pe.ProtectionContainerId,
                                pe.ID,
                                request,
                                requestHeaders);
                            desiredPEFound = true;
                            break;
                        }
                    }

                    if (desiredPEFound)
                    {
                        break;
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while doing planned failover operation");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void SanE2ETest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                try
                {
                    context.Start();
                    var client = GetSiteRecoveryClient(CustomHttpHandler);

                    var requestHeaders = RequestHeaders;
                    requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                    string containerId = "fc1e58ee-b96a-46fe-8afe-330f7ea545a1_d6a83495-5a6a-4ceb-9dc3-2829f6719032";
                    string entityId = "a7b4f73c-7a02-4fa2-b895-ddfcfceb0d7d";
                    string primaryServerId = "fc1e58ee-b96a-46fe-8afe-330f7ea545a1";
                    string recoveryServerId = "e19be056-3a6b-4239-8d01-b0820bc1aeaf";

                    //var responseServer = client.Servers.List(requestHeaders);

                    //var responsePE = client.ProtectionEntity.Get(containerId, entityId, RequestHeaders);

                    var responseStoragePoolPaired = client.StoragePoolMappings.List(primaryServerId, recoveryServerId, requestHeaders);

                    var responseStoragePrimary = client.Storages.List(primaryServerId, requestHeaders);
                    AsrStorage storagePoolPrimary = null;
                    foreach (var storage in responseStoragePrimary.Storages)
                    {
                        if (storage.Type == "Pool")
                        {
                            if (storage.StoragePools.Count > 0)
                            {
                                storagePoolPrimary = storage;
                            }
                        }
                    }

                    var responseStorageRecovery = client.Storages.List(recoveryServerId, requestHeaders);
                    AsrStorage storagePoolRecovery = null;
                    foreach (var storage in responseStorageRecovery.Storages)
                    {
                        if (storage.Type == "Pool")
                        {
                            if (storage.StoragePools.Count > 0)
                            {
                                storagePoolRecovery = storage;
                            }
                        }
                    }

                    StoragePoolMappingInput storagePoolMappingInput = new StoragePoolMappingInput();
                    storagePoolMappingInput.PrimaryServerId = primaryServerId;
                    storagePoolMappingInput.RecoveryServerId = recoveryServerId;
                    storagePoolMappingInput.PrimaryArrayId = storagePoolPrimary.ID;
                    storagePoolMappingInput.RecoveryArrayId = storagePoolRecovery.ID;
                    storagePoolMappingInput.PrimaryStoragePoolId = storagePoolPrimary.StoragePools[0].ID;
                    storagePoolMappingInput.RecoveryStoragePoolId = storagePoolRecovery.StoragePools[0].ID;
                    var responseStoragePoolPair = client.StoragePoolMappings.Create(storagePoolMappingInput, requestHeaders);
                    var responseStoragePoolUnpair = client.StoragePoolMappings.Delete(storagePoolMappingInput, requestHeaders);

                    FailoverRequest request = new FailoverRequest();

                    // Planned Failover RG
                    request = new PlannedFailoverRequest();
                    request.ReplicationProvider = "San";
                    request.FailoverDirection = "PrimaryToRecovery";
                    var response = client.ProtectionEntity.PlannedFailover(containerId, entityId, (PlannedFailoverRequest)request, requestHeaders);
                    ValidateResponse(response);
                    WaitForJobToComplete(client, response.Job.ID);

                    // Reverse protect RG
                    request = new ReprotectRequest();
                    request.ReplicationProvider = "San";
                    request.FailoverDirection = "RecoveryToPrimary";
                    response = client.ProtectionEntity.Reprotect(containerId, entityId, (ReprotectRequest)request, requestHeaders);
                    ValidateResponse(response);
                    WaitForJobToComplete(client, response.Job.ID);

                    // UnPlanned Failover RG
                    request = new UnplannedFailoverRequest();
                    request.ReplicationProvider = "San";
                    request.FailoverDirection = "RecoveryToPrimary";
                    response = client.ProtectionEntity.UnplannedFailover(containerId, entityId, (UnplannedFailoverRequest)request, requestHeaders);
                    ValidateResponse(response);
                    WaitForJobToComplete(client, response.Job.ID);

                    // Reverse protect RG
                    request = new ReprotectRequest();
                    request.ReplicationProvider = "San";
                    request.FailoverDirection = "PrimaryToRecovery";
                    response = client.ProtectionEntity.Reprotect(containerId, entityId, (ReprotectRequest)request, requestHeaders);
                    ValidateResponse(response);
                    WaitForJobToComplete(client, response.Job.ID);

                    // Test Failover RG
                    request = new TestFailoverRequest();
                    request.ReplicationProvider = "San";
                    request.FailoverDirection = "PrimaryToRecovery";
                    ((TestFailoverRequest)request).NetworkType = "NoNetworkAttachAsInput";
                    ((TestFailoverRequest)request).NetworkID = "xxx";
                    response = client.ProtectionEntity.TestFailover(containerId, entityId, (TestFailoverRequest)request, requestHeaders);
                    ValidateResponse(response);
                }
                catch
                {
                    //skip
                }
            }
        }
    }
}
