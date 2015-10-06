// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal enum ClusterState
    {
        /// <summary>
        /// Unable to read state. Check Error for details
        /// </summary>
        [EnumMember]
        Unknown,

        /// <summary>
        /// The DNS name has been successfully validated and a Azure HostedService has been created.
        /// </summary>
        [EnumMember]
        ReadyForDeployment,

        /// <summary>
        /// A create container was received but a HostService DNS name has not been created yet.
        /// </summary>
        [EnumMember]
        Accepted,

        /// <summary>
        /// The cluster storage is provisioned.
        /// </summary>
        [EnumMember]
        ClusterStorageProvisioned,

        /// <summary>
        /// The Azure compute fabric is provisioning VM's prior to HDInsight installation.
        /// </summary>
        [EnumMember]
        AzureVMConfiguration,

        /// <summary>
        /// VM provisioning is complete and the HDInsight components are installing.
        /// </summary>
        [EnumMember]
        HdInsightConfiguration,

        /// <summary>
        /// Greater than 90% of the nodes are operational.
        /// </summary>
        [EnumMember]
        Operational,

        /// <summary>
        /// 100% of the nodes are running.
        /// </summary>
        [EnumMember]
        Running,

        /// <summary>
        /// Deployment and or Container Delete request queued.
        /// </summary>
        [EnumMember]
        DeletePending,

        /// <summary>
        /// Deployment or Container is being deleted.
        /// </summary>
        [EnumMember]
        Deleting,

        /// <summary>
        /// Container is in error state.
        /// </summary>
        [EnumMember]
        Error,

        /// <summary>
        /// Deployment and or Container Delete request queued.
        /// </summary>
        [EnumMember]
        DeleteQueued,

        /// <summary>
        /// Cluster is deleted
        /// </summary>
        [EnumMember]
        Deleted,

        /// <summary>
        /// The deployment has been aborted by the user.
        /// </summary>
        [EnumMember]
        Aborted,

        /// <summary>
        /// The cluster creation has timed out.
        /// </summary>
        [EnumMember]
        Timedout,

        /// <summary>
        /// The cluster is being put into a suspended state. All nodes will be inaccessible.
        /// </summary>
        [EnumMember]
        Suspending,

        /// <summary>
        /// A suspend operation has been requested on the cluster.
        /// </summary>
        [EnumMember]
        SuspendQueued,

        /// <summary>
        /// The cluster is in a suspended state. All nodes will be inaccessible.
        /// </summary>
        [EnumMember]
        Suspended,

        /// <summary>
        /// A resume operation has been queued toward the cluster. The nodes will be coming back online in a few minutes.
        /// </summary>
        [EnumMember]
        ResumedQueued,

        /// <summary>
        /// The cluster is in process of deleting all the nodes associated with it.
        /// </summary>
        [EnumMember]
        Stopping,

        /// <summary>
        /// A stop operation has been requested.
        /// </summary>
        [EnumMember]
        StoppedQueued,

        /// <summary>
        /// The cluster is in a stopped state. There are no nodes associated with the cluster.
        /// </summary>
        [EnumMember]
        Stopped,

        /// <summary>
        /// A start operation has been queued on the cluster.
        /// </summary>
        [EnumMember]
        StartQueued,

        /// <summary>
        /// A patch operation for the cluster has been queued.
        /// </summary>
        [EnumMember]
        PatchQueued,

        /// <summary>
        /// A cert rollover for the cluster has been queued.
        /// </summary>
        [EnumMember]
        CertRolloverQueued,

        /// <summary>
        /// A resizing operation for the cluster has been queued.
        /// </summary>
        [EnumMember]
        ResizeQueued,

        /// <summary>
        /// Cluster is customizing.
        /// </summary>
        [EnumMember]
        ClusterCustomization
    }
}
