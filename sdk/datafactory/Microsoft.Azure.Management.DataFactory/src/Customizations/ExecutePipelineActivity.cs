using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class ExecutePipelineActivity : ControlActivity
    {
        /// <summary>
        /// Initializes a new instance of the ExecutePipelineActivity class.
        /// </summary>
        /// <param name="name">Activity name.</param>
        /// <param name="pipeline">Pipeline reference.</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="description">Activity description.</param>
        /// <param name="dependsOn">Activity depends on condition.</param>
        /// <param name="userProperties">Activity user properties.</param>
        /// <param name="parameters">Pipeline parameters.</param>
        /// <param name="waitOnCompletion">Defines whether activity execution
        /// will wait for the dependent pipeline execution to finish. Default
        /// is false.</param>
        public ExecutePipelineActivity(string name, PipelineReference pipeline, IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string description = default(string), IList<ActivityDependency> dependsOn = default(IList<ActivityDependency>), IList<UserProperty> userProperties = default(IList<UserProperty>), IDictionary<string, object> parameters = default(IDictionary<string, object>), bool? waitOnCompletion = default(bool?))
            : base(name, additionalProperties, description, dependsOn, userProperties)
        {
            Pipeline = pipeline;
            Parameters = parameters;
            WaitOnCompletion = waitOnCompletion;
            CustomInit();
        }
    }
}
