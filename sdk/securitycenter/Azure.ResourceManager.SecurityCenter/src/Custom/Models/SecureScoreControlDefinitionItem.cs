// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using ResourceSubResource = Azure.ResourceManager.Resources.Models.SubResource;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    public partial class SecureScoreControlDefinitionItem
    {
        /// <summary> Initializes a new instance of <see cref="SecureScoreControlDefinitionItem"/>. </summary>
        public SecureScoreControlDefinitionItem() { }

        /// <summary> The Azure resource links of the assessment definitions. </summary>
        public IReadOnlyList<ResourceSubResource> AssessmentDefinitions { get; } = new List<ResourceSubResource>();
    }
}
