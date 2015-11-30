//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.March2013
{
    public enum ClusterDeploymentState
    {
        /// <summary>
        /// The request has been accepted
        /// </summary>
        Accepted,

        /// <summary>
        /// The cluster storage is provisioned
        /// </summary>
        ClusterStorageProvisioned,
        
        /// <summary>
        /// The azure VM is in configuration
        /// </summary>
        AzureVMConfiguration,

        /// <summary>
        /// HDInsight is installing
        /// </summary>
        HdInsightConfiguration,

        /// <summary>
        /// A patch has been initiated.
        /// </summary>
        PatchQueued,

        /// <summary>
        /// The clusters is deleting
        /// </summary>
        Deleting,

        /// <summary>
        /// The cluster is queued for delete
        /// </summary>
        DeleteQueued,

        /// <summary>
        /// The cluster was deleted
        /// </summary>
        Deleted,
        
        /// <summary>
        /// The cluster was queued for delete before reaching operational or running state
        /// </summary>
        Aborted,
        
        /// <summary>
        /// The cluster did not move to operational or running within a specified time
        /// </summary>
        Timedout,

        /// <summary>
        /// The greater than 90% of the nodes are operational
        /// </summary>
        Operational,

        /// <summary>
        /// %100 of the cluster nodes are running
        /// </summary>
        Running,

        /// <summary>
        /// Cluster is in the  error state
        /// </summary>
        Error,

        /// <summary>
        /// A cluster cert rollover has been queued.
        /// </summary>
        CertRolloverQueued
    }
}
