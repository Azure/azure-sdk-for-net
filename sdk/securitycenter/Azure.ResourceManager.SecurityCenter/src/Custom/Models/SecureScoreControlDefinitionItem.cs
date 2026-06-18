// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    public partial class SecureScoreControlDefinitionItem
    {
        /// <summary> Initializes a new instance of <see cref="SecureScoreControlDefinitionItem"/>. </summary>
        public SecureScoreControlDefinitionItem() { }

        /// <summary> The Azure resource links of the assessment definitions. </summary>
        public IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> AssessmentDefinitions => throw new NotSupportedException("This API is no longer supported by the service.");
    }
}
