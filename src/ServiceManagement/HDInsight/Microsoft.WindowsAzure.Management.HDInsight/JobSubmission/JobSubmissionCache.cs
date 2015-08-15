namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    
    /// <summary>
    /// Provides a cache for JobSubmission details needed by the system.
    /// </summary>
    internal class JobSubmissionCache : IJobSubmissionCache
    {
        private ConcurrentDictionary<Guid, Dictionary<string, JobSubmissionClusterDetails>> cache = new ConcurrentDictionary<Guid, Dictionary<string, JobSubmissionClusterDetails>>();

        /// <inheritdoc />
        public JobSubmissionClusterDetails GetCredentails(Guid subscriptionId, string cluster)
        {
            JobSubmissionClusterDetails retval = null;
            Dictionary<string, JobSubmissionClusterDetails> clusterCache;
            if (this.cache.TryGetValue(subscriptionId, out clusterCache))
            {
                clusterCache.TryGetValue(cluster, out retval);
            }
            return retval;
        }

        /// <inheritdoc />
        public void StoreCredentails(Guid subscriptionId, string cluster, JobSubmissionClusterDetails credential)
        {
            Dictionary<string, JobSubmissionClusterDetails> clusterCache;
            if (!this.cache.TryGetValue(subscriptionId, out clusterCache))
            {
                clusterCache = new Dictionary<string, JobSubmissionClusterDetails>();
                this.cache.TryAdd(subscriptionId, clusterCache);
            }
            clusterCache[cluster] = credential;
        }
    }
}
