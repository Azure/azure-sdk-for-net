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

using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace SiteRecovery.Tests
{
    /// <summary>
    /// Hyper-V Replica specific protection profile Input.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class HyperVReplicaProtectionProfileInput
    {
        /// <summary>
        /// Gets or sets a value indicating the replication interval.
        /// </summary>
        [DataMember]
        public ushort ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of recovery points.
        /// </summary>
        [DataMember]
        public int RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the application consistent frequency.
        /// </summary>
        [DataMember]
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether compression has to be enabled.
        /// </summary>
        [DataMember]
        public bool CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IR is online.
        /// </summary>
        [DataMember]
        public bool OnlineReplicationMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the online IR start time.
        /// </summary>
        [DataMember]
        public TimeSpan? OnlineReplicationStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the offline IR import path.
        /// </summary>
        [DataMember]
        public string OfflineReplicationImportPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the offline IR export path.
        /// </summary>
        [DataMember]
        public string OfflineReplicationExportPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the recovery HTTPS port.
        /// </summary>
        [DataMember]
        public ushort ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the authentication type.
        /// </summary>
        [DataMember]
        public ushort AllowedAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the VM has to be auto deleted.
        /// </summary>
        [DataMember]
        public bool AllowReplicaDeletion { get; set; }
    }

    /// <summary>
    /// Hyper-V Replica Azure specific input for creating a protection profile.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class HyperVReplicaAzureProtectionProfileInput
    {
        /// <summary>
        /// Gets or sets the duration (in hours) to which point the recovery history needs to be 
        /// maintained.
        /// </summary>
        [DataMember]
        public int RecoveryPointHistoryDuration { get; set; }

        /// <summary>
        /// Gets or sets the interval (in hours) at which Hyper-V Replica should create an
        /// application consistent snapshot within the VM.
        /// </summary>
        [DataMember]
        public int AppConsistencyFreq { get; set; }

        /// <summary>
        /// Gets or sets the replication interval.
        /// </summary>
        [DataMember]
        public int ReplicationInterval { get; set; }

        /// <summary>
        /// Gets or sets the scheduled start time for the initial replication. If this parameter 
        /// is Null, the initial replication starts immediately.
        /// </summary>
        [DataMember]
        public TimeSpan? OnlineIrStartTime { get; set; }

        /// <summary>
        /// Gets or sets the list of storage accounts to which the VMs in the primary cloud can 
        /// replicate to.
        /// </summary>
        [DataMember]
        public List<CustomerStorageAccount> StorageAccounts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether encryption needs to be enabled for Vms in this cloud. 
        /// </summary>
        [DataMember]
        public bool IsEncryptionEnabled { get; set; }
    }

    /// <summary>
    /// Hyper-V Replica specific protection profile Input.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class SanProtectionProfileInput
    {
        /// <summary>
        /// Gets or sets the primary cloud getting paired.
        /// </summary>
        [DataMember]
        public string CloudId { get; set; }

        /// <summary>
        /// Gets or sets the recovery cloud getting paired.
        /// </summary>
        [DataMember]
        public string RemoteCloudId { get; set; }

        /// <summary>
        /// Gets or sets the primary array unique Id getting paired. 
        /// </summary>
        [DataMember]
        public string ArrayUniqueId { get; set; }

        /// <summary>
        /// Gets or sets the recovery array unique Id getting paired.
        /// </summary>
        [DataMember]
        public string RemoteArrayUniqueId { get; set; }
    }

    //public class HyperVReplicaAzureProfileManagementInput
    //{
    //    public int RecoveryPointHistoryDuration { get; set; }

    //    public int AppConsistencyFreq { get; set; }

    //    public int ReplicationInterval { get; set; }

    //    public TimeSpan? OnlineIrStartTime { get; set; }

    //    public List<CustomerStorageAccount> StorageAccounts { get; set; }

    //    public bool IsEncryptionEnabled { get; set; }
    //}

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CustomerStorageAccount
    {
        [DataMember]
        public string StorageAccountName { get; set; }
        [DataMember]
        public string SubscriptionId { get; set; }
    }

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class HyperVReplicaAzureProtectionProfileDetails
    {
        /// <summary>
        /// Gets or sets the duration (in hours) to which point the recovery history needs to be 
        /// maintained.
        /// </summary>
        [DataMember]
        public int RecoveryPointHistoryDuration { get; set; }

        /// <summary>
        /// Gets or sets the interval (in hours) at which Hyper-V Replica should create an
        /// application consistent snapshot within the VM.
        /// </summary>
        [DataMember]
        public int AppConsistencyFreq { get; set; }

        /// <summary>
        /// Gets or sets the replication interval.
        /// </summary>
        [DataMember]
        public int ReplicationInterval { get; set; }

        /// <summary>
        /// Gets or sets the scheduled start time for the initial replication. If this parameter 
        /// is Null, the initial replication starts immediately.
        /// </summary>
        [DataMember]
        public TimeSpan? OnlineIrStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether encryption is enabled for virtual machines
        /// in this cloud.
        /// </summary>
        [DataMember]
        public bool IsEncryptionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the active storage accounts details.
        /// </summary>
        [DataMember]
        public CustomerStorageAccount ActiveStorageAccount { get; set; }
    }

    /// <summary>
    /// Hyper-V Replica specific protection profile details.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class HyperVReplicaProtectionProfileDetails
    {
        /// <summary>
        /// Gets or sets a value indicating the number of recovery points.
        /// </summary>
        [DataMember]
        public int NosOfRps { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the application consistent frequency.
        /// </summary>
        [DataMember]
        public int AppConsistencyFreq { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether compression has to be enabled.
        /// </summary>
        [DataMember]
        public bool IsCompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IR is online.
        /// </summary>
        [DataMember]
        public bool IsOnlineIr { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the online IR start time.
        /// </summary>
        [DataMember]
        public TimeSpan? OnlineIrStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the offline IR import path.
        /// </summary>
        [DataMember]
        public string OfflineIrImportPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the offline IR export path.
        /// </summary>
        [DataMember]
        public string OfflineIrExportPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the primary HTTP port.
        /// </summary>
        [DataMember]
        public ushort PrimaryHttpPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the primary HTTPS port.
        /// </summary>
        [DataMember]
        public ushort PrimaryHttpsPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the recovery HTTP port.
        /// </summary>
        [DataMember]
        public ushort RecoveryHttpPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the recovery HTTPS port.
        /// </summary>
        [DataMember]
        public ushort RecoveryHttpsPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the authentication type.
        /// </summary>
        [DataMember]
        public ushort AllowedAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the VM has to be auto deleted.
        /// Supported Values: String.Empty, None, OnRecoveryCloud
        /// </summary>
        [DataMember]
        public string VmAutoDeleteOption { get; set; }
    }

    /// <summary>
    /// Hyper-V Replica Blue specific protection profile details.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class HyperVReplicaBlueProtectionProfileDetails : HyperVReplicaProtectionProfileDetails
    {
        /// <summary>
        /// Gets or sets a value indicating the replication interval.
        /// </summary>
        [DataMember]
        public ushort ReplicationInterval { get; set; }
    }

    public class ProtectionProfileTests : SiteRecoveryTestsBase
    {
        public const string AzureProtectionContainerId = "21a9403c-6ec1-44f2-b744-b4e50b792387_d38048d4-b460-4791-8ece-108395ee8478";

        public void DissociateAndDelete()
        {
            using (UndoContext context = UndoContext.Current)
            {
                JobResponse response = null;
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                JobQueryParameter jqp = new JobQueryParameter();
                var responseRP = client.ProtectionProfile.List(RequestHeaders);

                foreach (var profile in responseRP.ProtectionProfiles)
                {
                    foreach (var associationDetail in profile.AssociationDetail)
                    {
                        if (associationDetail.AssociationStatus == "Paired")
                        {
                            var input = new CreateAndAssociateProtectionProfileInput();
                            input.AssociationInput.PrimaryProtectionContainerId = associationDetail.PrimaryProtectionContainerId;
                            input.AssociationInput.RecoveryProtectionContainerId = associationDetail.RecoveryProtectionContainerId;

                            response = client.ProtectionProfile.DissociateAndDelete(
                                profile.ID,
                                input,
                                requestHeaders);
                            break;
                        }
                    }
                }

                Assert.NotNull(response);
                Assert.NotNull(response.Job.ID);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void CreateAndAssociateE2E()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                string serializedHyperVReplicaAzureProfileManagementInput = null;
               
                var settings = new HyperVReplicaProtectionProfileInput();
                settings.AllowedAuthenticationType = 1;
                settings.AllowReplicaDeletion = false;
                settings.ApplicationConsistentSnapshotFrequencyInHours = 0;
                settings.CompressionEnabled = true;
                settings.OfflineReplicationExportPath = null;
                settings.OfflineReplicationImportPath = null;
                settings.OnlineReplicationMethod = true;
                settings.OnlineReplicationStartTime = null;
                settings.RecoveryPoints = 1;
                settings.ReplicationFrequencyInSeconds = 300;
                settings.ReplicationPort = 8083;

                serializedHyperVReplicaAzureProfileManagementInput =
                    DataContractUtils<HyperVReplicaProtectionProfileInput>.Serialize(settings);

                var responsePC = client.ProtectionContainer.List(RequestHeaders);

                string primaryPCId = null;
                string recoveryPCId = null;
                foreach (var pc in responsePC.ProtectionContainers)
                {
                    if (string.IsNullOrWhiteSpace(pc.Role))
                    {
                        if (primaryPCId == null)
                        {
                            primaryPCId = pc.ID;
                            continue;
                        }

                        if (recoveryPCId == null)
                        {
                            recoveryPCId = pc.ID;
                            break;
                        }
                    }
                }

                var input = new CreateAndAssociateProtectionProfileInput();

                input.ProtectionProfileInput = new CreateProtectionProfileInput();
                input.ProtectionProfileInput.Name = "E2E_Profile";
                input.ProtectionProfileInput.ReplicationProvider = "HyperVReplica";
                input.ProtectionProfileInput.ReplicationProviderSettings =
                    serializedHyperVReplicaAzureProfileManagementInput;

                input.AssociationInput = new ProtectionProfileAssociationInput();
                input.AssociationInput.PrimaryProtectionContainerId = primaryPCId;
                input.AssociationInput.RecoveryProtectionContainerId = recoveryPCId;

                JobResponse response = client.ProtectionProfile.CreateAndAssociate(input, requestHeaders);

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void CreateAndAssociateE2A(string provider)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                JobQueryParameter jqp = new JobQueryParameter();
                var responseRP = client.ProtectionProfile.List(RequestHeaders);

                string serializedHyperVReplicaAzureProfileManagementInput = null;
                foreach (var profile in responseRP.ProtectionProfiles)
                {
                    if (profile.AssociationDetail[0].AssociationStatus == "Paired")
                    {
                        // Instead of creating new set of values. Picking the values from already paired cloud.
                        var obj =
                        DataContractUtils<HyperVReplicaAzureProtectionProfileDetails>.Deserialize(
                        profile.ReplicationProviderSetting);

                        var settings = new HyperVReplicaAzureProtectionProfileInput();
                        settings.AppConsistencyFreq = obj.AppConsistencyFreq;
                        settings.IsEncryptionEnabled = obj.IsEncryptionEnabled;
                        settings.OnlineIrStartTime = obj.OnlineIrStartTime;
                        settings.RecoveryPointHistoryDuration = obj.RecoveryPointHistoryDuration;
                        settings.ReplicationInterval = obj.ReplicationInterval;
                        settings.StorageAccounts = new List<CustomerStorageAccount>();
                        var storageAccount = new CustomerStorageAccount();
                        storageAccount.StorageAccountName = obj.ActiveStorageAccount.StorageAccountName;
                        storageAccount.SubscriptionId = obj.ActiveStorageAccount.SubscriptionId;
                        settings.StorageAccounts.Add(storageAccount);

                        serializedHyperVReplicaAzureProfileManagementInput =
                            DataContractUtils<HyperVReplicaAzureProtectionProfileInput>.Serialize(settings);
                    }
                }

                var responsePC = client.ProtectionContainer.List(RequestHeaders);

                foreach (var pc in responsePC.ProtectionContainers)
                {
                    if (string.IsNullOrWhiteSpace(pc.Role))
                    {
                        var input = new CreateAndAssociateProtectionProfileInput();

                        input.ProtectionProfileInput = new CreateProtectionProfileInput();
                        input.ProtectionProfileInput.Name = "PP1";
                        input.ProtectionProfileInput.ReplicationProvider = "HyperVReplicaAzure";
                        input.ProtectionProfileInput.ReplicationProviderSettings =
                            serializedHyperVReplicaAzureProfileManagementInput;

                        input.AssociationInput = new ProtectionProfileAssociationInput();
                        input.AssociationInput.PrimaryProtectionContainerId = pc.ID;
                        input.AssociationInput.RecoveryProtectionContainerId = AzureProtectionContainerId;

                        client.ProtectionProfile.CreateAndAssociate(input, requestHeaders);
                    }
                }

                //Assert.NotNull(response.);
                //Assert.NotNull(response.RecoveryPlan.ID);
                //Assert.NotNull(response.RecoveryPlan.Name);
                //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void Update()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                JobQueryParameter jqp = new JobQueryParameter();
                var responseRP = client.ProtectionProfile.List(RequestHeaders);

                string serializedHyperVReplicaAzureProfileManagementInput = null;
                foreach (var profile in responseRP.ProtectionProfiles)
                {
                    if (profile.ReplicationProvider == "HyperVReplicaAzure")
                    {
                        string subsId = null;

                        var obj =
                        DataContractUtils<HyperVReplicaAzureProtectionProfileDetails>.Deserialize(
                        profile.ReplicationProviderSetting);

                        var settings = new HyperVReplicaAzureProtectionProfileInput();
                        settings.AppConsistencyFreq = obj.AppConsistencyFreq;
                        settings.IsEncryptionEnabled = obj.IsEncryptionEnabled;
                        settings.OnlineIrStartTime = obj.OnlineIrStartTime;
                        settings.RecoveryPointHistoryDuration = obj.RecoveryPointHistoryDuration;
                        settings.ReplicationInterval = obj.ReplicationInterval;
                        settings.StorageAccounts = new List<CustomerStorageAccount>();
                        var storageAccount = new CustomerStorageAccount();
                        storageAccount.StorageAccountName = obj.ActiveStorageAccount.StorageAccountName;
                        subsId = storageAccount.SubscriptionId;
                        storageAccount.SubscriptionId = "MySubscriptionId";
                        settings.StorageAccounts.Add(storageAccount);

                        serializedHyperVReplicaAzureProfileManagementInput =
                            DataContractUtils<HyperVReplicaAzureProtectionProfileInput>.Serialize(settings);

                        // update the profile object.
                        var input = new UpdateProtectionProfileInput();
                        input.ReplicationProviderSettings = serializedHyperVReplicaAzureProfileManagementInput;

                        var responseUpdate = client.ProtectionProfile.Update(input, profile.ID, RequestHeaders);
                        var responseGet = client.ProtectionProfile.Get(profile.ID, RequestHeaders);

                        // check for subsid.
                        Assert.NotNull(responseGet.ProtectionProfile);

                        // revert the temp changes.
                        storageAccount.SubscriptionId = subsId;
                        serializedHyperVReplicaAzureProfileManagementInput =
                            DataContractUtils<HyperVReplicaAzureProtectionProfileInput>.Serialize(settings);

                        input.ReplicationProviderSettings = serializedHyperVReplicaAzureProfileManagementInput;
                        responseUpdate = client.ProtectionProfile.Update(
                            input,
                            profile.ID,
                            requestHeaders);
                        return;
                    }
                }
            }
        }
    }
}
