using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class ScriptActivity : ExecutionActivity
    {
        /// <summary>
        /// Initializes a new instance of the ScriptActivity class.
        /// </summary>
        /// <param name="name">Activity name.</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="description">Activity description.</param>
        /// <param name="dependsOn">Activity depends on condition.</param>
        /// <param name="userProperties">Activity user properties.</param>
        /// <param name="linkedServiceName">Linked service reference.</param>
        /// <param name="policy">Activity policy.</param>
        /// <param name="scripts">Array of script blocks. Type: array.</param>
        /// <param name="logSettings">Log settings of script activity.</param>
        public ScriptActivity(string name, IDictionary<string, object> additionalProperties, string description, IList<ActivityDependency> dependsOn, IList<UserProperty> userProperties, LinkedServiceReference linkedServiceName, ActivityPolicy policy, IList<ScriptActivityScriptBlock> scripts, ScriptActivityTypePropertiesLogSettings logSettings = default(ScriptActivityTypePropertiesLogSettings))
            : base(name, additionalProperties, description, dependsOn, userProperties, linkedServiceName, policy)
        {
            Scripts = scripts;
            LogSettings = logSettings;
            CustomInit();
        }
    }
}
