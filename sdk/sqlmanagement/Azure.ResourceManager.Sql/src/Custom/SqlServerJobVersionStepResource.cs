// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sql
{
    // Suppressing the string type parameter overloads for job version related APIs, since the jobVersion is the name of the resource SqlServerJobVersion which should be string but the definition in the spec is int, MPG can not handle this scenario correctly.
    // To mitigate this, we alternate the type of the jobVersion paramater in the API spec to string, and add back the int overloads in the code as backward compatibility. And suppress the string overloads in the codegen since they are not expected to be used directly.
    // Open Github issue for MPG: https://github.com/Azure/azure-sdk-for-net/issues/60105, once the issue is resolved, we can remove the int overloads and the suppression attributes in the code.
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string))]
    public partial class SqlServerJobVersionStepResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="serverName"> The serverName. </param>
        /// <param name="jobAgentName"> The jobAgentName. </param>
        /// <param name="jobName"> The jobName. </param>
        /// <param name="jobVersion"> The jobVersion. </param>
        /// <param name="stepName"> The stepName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion, string stepName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/versions/{jobVersion}/steps/{stepName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
