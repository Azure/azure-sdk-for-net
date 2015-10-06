using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    public enum ClusterState
    {
        /// <summary>
        /// The DNS name has been successfully validated and a Azure HostedService has been created
        /// </summary>
        ReadyForDeployment,

        /// <summary>
        /// A create container was received but a HostService DNS name has not been created yet
        /// </summary>
        Accepted,

        /// <summary>
        /// The cluster storage is provisioned
        /// </summary>
        ClusterStorageProvisioned,

        /// <summary>
        /// The Azure compute fabric is provisioning VM's prior to HDInsight installation
        /// </summary>
        AzureVMConfiguration,

        /// <summary>
        /// VM provisioning is complete and the HDInsight components are installing
        /// </summary>
        HdInsightConfiguration,

        /// <summary>
        /// Greater than 90% of the nodes are operational
        /// </summary>
        Operational,

        /// <summary>
        /// 100% of the nodes are running
        /// </summary>
        Running,

        /// <summary>
        /// A patch has been initiated.
        /// </summary>
        PatchQueued,

        /// <summary>
        /// Deployment and or Container Delete request queued
        /// </summary>
        DeletePending,

        /// <summary>
        /// Deployment or Container is being deleted
        /// </summary>
        Deleting,

        /// <summary>
        /// Container is in error state
        /// </summary>
        Error,

        /// <summary>
        /// Unable to read state. Check Error for details
        /// </summary>
        Unknown,
    }
}
