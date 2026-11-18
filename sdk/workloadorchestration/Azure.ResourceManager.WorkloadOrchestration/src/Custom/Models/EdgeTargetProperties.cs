// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.WorkloadOrchestration.Models
{
    public partial class EdgeTargetProperties
    {
        // Preserve the constructor shipped in 1.0.1 now that targetSpecification is optional.
        /// <summary> Initializes a new instance of <see cref="EdgeTargetProperties"/>. </summary>
        /// <param name="description"> Description of target. </param>
        /// <param name="displayName"> Display name of target. </param>
        /// <param name="contextId"> ArmId of Context. </param>
        /// <param name="targetSpecification"> Target specification. </param>
        /// <param name="capabilities"> List of capabilities. </param>
        /// <param name="hierarchyLevel"> Hierarchy level. </param>
        /// <exception cref="ArgumentNullException"> One of the parameters is null. </exception>
        public EdgeTargetProperties(string description, string displayName, ResourceIdentifier contextId, IDictionary<string, BinaryData> targetSpecification, IEnumerable<string> capabilities, string hierarchyLevel)
            : this(description, displayName, contextId, capabilities, hierarchyLevel)
        {
            Argument.AssertNotNull(targetSpecification, nameof(targetSpecification));
            TargetSpecification = targetSpecification;
        }
    }
}
