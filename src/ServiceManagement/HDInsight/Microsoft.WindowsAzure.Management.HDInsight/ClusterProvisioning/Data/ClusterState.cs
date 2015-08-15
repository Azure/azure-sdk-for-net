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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    /// <summary>
    /// Possible states of an HDInsight cluster.
    /// </summary>
    public enum ClusterState
    {
        /// <summary>
        /// The DNS name has been successfully validated and a Azure HostedService has been created.
        /// </summary>
        ReadyForDeployment,

        /// <summary>
        /// A create container was received but a HostService DNS name has not been created yet.
        /// </summary>
        Accepted,

        /// <summary>
        /// The cluster storage is provisioned.
        /// </summary>
        ClusterStorageProvisioned,

        /// <summary>
        /// The Azure compute fabric is provisioning VM's prior to HDInsight installation.
        /// </summary>
        AzureVMConfiguration,

        /// <summary>
        /// VM provisioning is complete and the HDInsight components are installing.
        /// </summary>
        HDInsightConfiguration,

        /// <summary>
        /// Greater than 90% of the nodes are operational.
        /// </summary>
        Operational,

        /// <summary>
        /// 100% of the nodes are running.
        /// </summary>
        Running,

        /// <summary>
        /// A patch has been initiated.
        /// </summary>
        PatchQueued,

        /// <summary>
        /// A resize has been initialized.
        /// </summary>
        ResizeQueued,

        /// <summary>
        /// Deployment and or Container Delete request queued.
        /// </summary>
        DeletePending,

        /// <summary>
        /// Deployment or Container is being deleted.
        /// </summary>
        Deleting,

        /// <summary>
        /// Container is in error state.
        /// </summary>
        Error,

        /// <summary>
        /// Cluster provisioning has timed out.
        /// </summary>
        TimedOut,

        /// <summary>
        /// A cluster cert rollover queued.
        /// </summary>
        CertRolloverQueued,

        /// <summary>
        /// Container is in unkown state.
        /// </summary>
        Unknown,

        /// <summary>
        /// Cluster is customizing.
        /// </summary>
        ClusterCustomization
    }
}