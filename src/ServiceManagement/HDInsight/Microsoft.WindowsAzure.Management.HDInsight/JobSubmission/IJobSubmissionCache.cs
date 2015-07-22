namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission
{
    using System;
    using Microsoft.Hadoop.Client;

    /// <summary>
    /// Provides a cache of JobSubmission data needed to submit jobs.
    /// </summary>
    internal interface IJobSubmissionCache
    {
        /// <summary>
        /// Get's previous stored connection credentials.
        /// </summary>
        /// <param name="subscriptionId">
        /// The subscription Id.
        /// </param>
        /// <param name="cluster">
        /// The cluster.
        /// </param>
        /// <returns>
        /// The previously resolved connection credentials.
        /// </returns>
        JobSubmissionClusterDetails GetCredentails(Guid subscriptionId, string cluster);

        /// <summary>
        /// Stores a set of credentials for use later.
        /// </summary>
        /// <param name="subscriptionId">
        /// The subscription Id.
        /// </param>
        /// <param name="cluster">
        /// The cluster.
        /// </param>
        /// <param name="credential">
        /// The credentials.
        /// </param>
        void StoreCredentails(Guid subscriptionId, string cluster, JobSubmissionClusterDetails credential);
    }
}
