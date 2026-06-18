// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    public partial class SecureScoreControlDefinitionItem
    {
        /// <summary> Initializes a new instance of <see cref="SecureScoreControlDefinitionItem"/>. </summary>
        public SecureScoreControlDefinitionItem() { }

        /// <summary> The Azure resource links of the assessment definitions. </summary>
        public IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> AssessmentDefinitions => throw new NotSupportedException("This API is no longer supported by the service.");
    }
}
