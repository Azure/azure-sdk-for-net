using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    /// <summary>
    /// Action for submitting a new job request.
    /// </summary>
    public class MapReduceJobRequestPassthroughAction : JobRequestPassthroughAction
    {
        internal string JarFile { get; set; }
        internal string ClassName { get; set; }
        internal IEnumerable<string> Arguments { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        public MapReduceJobRequestPassthroughAction(DataAccess.Context.ClusterContainer container, string subscriptionId)
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

                    return jobService.CreateMapReduceJob(JarFile, ClassName, Resources, Arguments, Parameters,
                                                              JobFolder);
                });
        }
    }
}