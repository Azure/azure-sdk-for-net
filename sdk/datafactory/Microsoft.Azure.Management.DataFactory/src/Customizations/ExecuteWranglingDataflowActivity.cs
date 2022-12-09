using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class ExecuteWranglingDataflowActivity : Activity
    {
        /// <summary>
        /// Initializes a new instance of the ExecuteWranglingDataflowActivity
        /// class.
        /// </summary>
        /// <param name="name">Activity name.</param>
        /// <param name="dataFlow">Data flow reference.</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="description">Activity description.</param>
        /// <param name="dependsOn">Activity depends on condition.</param>
        /// <param name="userProperties">Activity user properties.</param>
        /// <param name="staging">Staging info for execute data flow
        /// activity.</param>
        /// <param name="integrationRuntime">The integration runtime
        /// reference.</param>
        /// <param name="compute">Compute properties for data flow
        /// activity.</param>
        /// <param name="traceLevel">Trace level setting used for data flow
        /// monitoring output. Supported values are: 'coarse', 'fine', and
        /// 'none'. Type: string (or Expression with resultType string)</param>
        /// <param name="continueOnError">Continue on error setting used for
        /// data flow execution. Enables processing to continue if a sink
        /// fails. Type: boolean (or Expression with resultType
        /// boolean)</param>
        /// <param name="runConcurrently">Concurrent run setting used for data
        /// flow execution. Allows sinks with the same save order to be
        /// processed concurrently. Type: boolean (or Expression with
        /// resultType boolean)</param>
        /// <param name="sinks">(Deprecated. Please use Queries). List of Power
        /// Query activity sinks mapped to a queryName.</param>
        /// <param name="queries">List of mapping for Power Query mashup query
        /// to sink dataset(s).</param>
        /// <param name="policy">Activity policy.</param>
        public ExecuteWranglingDataflowActivity(string name, DataFlowReference dataFlow, IDictionary<string, object> additionalProperties, string description, IList<ActivityDependency> dependsOn, IList<UserProperty> userProperties, DataFlowStagingInfo staging, IntegrationRuntimeReference integrationRuntime, ExecuteDataFlowActivityTypePropertiesCompute compute, object traceLevel, object continueOnError, object runConcurrently, IDictionary<string, PowerQuerySink> sinks, IList<PowerQuerySinkMapping> queries = default(IList<PowerQuerySinkMapping>), ActivityPolicy policy = default(ActivityPolicy))
            : base(name, additionalProperties, description, dependsOn, userProperties)
        {
            DataFlow = dataFlow;
            Staging = staging;
            IntegrationRuntime = integrationRuntime;
            Compute = compute;
            TraceLevel = traceLevel;
            ContinueOnError = continueOnError;
            RunConcurrently = runConcurrently;
            Sinks = sinks;
            Queries = queries;
            Policy = policy;
            CustomInit();
        }
    }
}
