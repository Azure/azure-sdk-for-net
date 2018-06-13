// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// Policy violation error details
    /// </summary>
    public class PolicyViolationErrorInfo
    {
        /// <summary>
        /// Gets or sets the policy definition id.
        /// </summary>
        public string PolicyDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition id.
        /// </summary>
        public string PolicySetDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the policy definition instance id inside a policy set.
        /// </summary>
        public string PolicyDefinitionReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition name.
        /// </summary>
        public string PolicySetDefinitionName { get; set; }

        /// <summary>
        /// Gets or sets the policy definition name.
        /// </summary>
        public string PolicyDefinitionName { get; set; }

        /// <summary>
        /// Gets or sets the policy definition action.
        /// </summary>
        public string PolicyDefinitionEffect { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment id.
        /// </summary>
        public string PolicyAssignmentId { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment name.
        /// </summary>
        public string PolicyAssignmentName { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment display name.
        /// </summary>
        public string PolicyAssignmentDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment scope.
        /// </summary>
        public string PolicyAssignmentScope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment parameters.
        /// </summary>
        public Dictionary<string, PolicyParameter> PolicyAssignmentParameters { get; set; }

        /// <summary>
        /// Gets or sets the policy definition display name.
        /// </summary>
        public string PolicyDefinitionDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy set definition display name.
        /// </summary>
        public string PolicySetDefinitionDisplayName { get; set; }

        /// <summary>
        /// Policy parameter
        /// </summary>
        public class PolicyParameter
        {
            /// <summary>
            /// Gets or sets the policy parameter value
            /// </summary>
            public JToken Value { get; set; }
        }
    }
}