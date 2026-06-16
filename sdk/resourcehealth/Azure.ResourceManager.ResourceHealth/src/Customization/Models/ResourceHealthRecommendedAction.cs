// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth.Models
{
    public partial class ResourceHealthRecommendedAction
    {
        /// <summary> The comment for the action URI. </summary>
        [CodeGenMember("ActionUrlComment")]
        public string ActionUriComment { get; }

        /// <summary> Substring of action, it describes which text should host the action URI. </summary>
        [CodeGenMember("ActionUrlText")]
        public string ActionUriText { get; }
    }
}
