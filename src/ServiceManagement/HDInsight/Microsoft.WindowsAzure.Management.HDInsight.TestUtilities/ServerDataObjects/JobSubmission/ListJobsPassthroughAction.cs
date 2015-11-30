using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models;
using Microsoft.ClusterServices.RDFEProvider.ResourceTypes;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    /// <summary>
    /// Action for submitting a new job request.
    /// </summary>
    public class ListJobsPassthroughAction : JobRequestPassthroughAction
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public ListJobsPassthroughAction(DataAccess.Context.ClusterContainer container, string subscriptionId)
            : base(container, subscriptionId)
        {
        }

        /// <inheritdoc/>
        public override async Task<PassthroughResponse> Execute()
        {
            return await this.ExecuteAndHandleResponse(() =>
                {
                    var jobService = jobServiceProxyFactory.CreateClusterJobServiceProxy(base.Container);

                    return jobService.GetJobs();
                });
        }
    }
}