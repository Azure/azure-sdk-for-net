using System.Threading.Tasks;
using Microsoft.ClusterServices.Common.Utils;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    /// <summary>
    /// Action for submitting a new job request.
    /// </summary>
    public class JobDetailsPassthroughAction : JobRequestPassthroughAction
    {
        internal string jobId = string.Empty;

        /// <summary>
        /// Ctor.
        /// </summary>
        public JobDetailsPassthroughAction(string jobId, DataAccess.Context.ClusterContainer container, string subscriptionId)
            : base(container, subscriptionId)
        {
            Contract.AssertArgNotNullOrEmpty(jobId, "jobId");
            this.jobId = jobId;
        }

        /// <inheritdoc/>
        public override async Task<PassthroughResponse> Execute()
        {
            return await this.ExecuteAndHandleResponse(() =>
                {
                    var jobService = jobServiceProxyFactory.CreateClusterJobServiceProxy(Container);

                    return jobService.GetJob(jobId);
                });
        }
    }
}