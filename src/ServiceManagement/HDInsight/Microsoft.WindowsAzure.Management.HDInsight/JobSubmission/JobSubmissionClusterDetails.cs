namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Hadoop.Client;

    /// <summary>
    /// Holds key cluster details needed in JobSubmission.
    /// </summary>
    public class JobSubmissionClusterDetails
    {
        /// <summary>
        /// Gets or sets the credentials used to connect to the cluster.
        /// </summary>
        public BasicAuthCredential RemoteCredentials { get; set; }

        /// <summary>
        /// Gets or sets the details of the cluster.
        /// </summary>
        public ClusterDetails Cluster { get; set; }
    }
}
