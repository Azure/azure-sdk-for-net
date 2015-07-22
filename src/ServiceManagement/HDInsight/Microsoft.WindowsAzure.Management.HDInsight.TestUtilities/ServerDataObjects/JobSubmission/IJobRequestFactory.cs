using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    public interface IJobRequestFactory
    {
        /// <summary>
        /// Method to deserialize a client job request and create a strongly typed job request. 
        /// </summary>
        /// <param name="request">The raw data contract serialzied string of a ClientJobRequest object.</param>
        /// <returns>A strongly typed JobRequest object.</returns>
        JobRequest CreateJobRequest(string request);
    }
}