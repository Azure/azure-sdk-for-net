using System.Threading.Tasks;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    /// <summary>
    /// Action for submitting a new job request.
    /// </summary>
    public class HiveJobRequestPassthroughAction : JobRequestPassthroughAction
    {
        internal string Query { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        public HiveJobRequestPassthroughAction(DataAccess.Context.ClusterContainer container, string subscriptionId)
            : base(container, subscriptionId)
        {
        }

        /// <inheritdoc/>
        public override async Task<PassthroughResponse> Execute()
        {
            return await this.ExecuteAndHandleResponse(() =>
                {
                    var jobService = jobServiceProxyFactory.CreateClusterJobServiceProxy(Container);

                    this.JobFolder = CreateJobFolder(this.Container);

                    return jobService.CreateHiveJob(Query, Resources, Parameters, JobFolder);
                });
        }
    }
}