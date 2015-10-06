//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.March2013
{
    public enum ClusterContainerState
    {
        /// <summary>
        /// A create container was received but a HostService DNS name has not been created yet
        /// </summary>
        Accepted,

        /// <summary>
        /// The DNS name has been successfully validated and a Azure HostedService has been created
        /// </summary>
        ReadyForDeployment,

        /// <summary>
        /// A valid azure cloud service deployment/Cluster is running in the container
        /// </summary>
        ClusterConfigured,

        /// <summary>
        /// Deployment and or Container Delete request queued
        /// </summary>
        DeleteQueued,

        /// <summary>
        /// Deployment or Container is being deleted
        /// </summary>
        Deleting,

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
        /// Container is in error state
        /// </summary>
        Error
    }
}
