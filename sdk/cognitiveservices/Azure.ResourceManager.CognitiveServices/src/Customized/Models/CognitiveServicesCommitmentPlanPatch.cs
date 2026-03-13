// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    // Backward compatibility: CognitiveServicesCommitmentPlanPatch was the update model
    // for commitment plans in the autorest-generated SDK. Now PatchResourceTagsAndSku
    // is used directly, but this type is kept for API backward compat.
    /// <summary> Backward-compatible patch model for commitment plan tag and SKU updates. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CognitiveServicesCommitmentPlanPatch : PatchResourceTagsAndSku
    {
        /// <summary> Initializes a new instance of <see cref="CognitiveServicesCommitmentPlanPatch"/>. </summary>
        public CognitiveServicesCommitmentPlanPatch() : base()
        {
        }

        internal CognitiveServicesCommitmentPlanPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, CognitiveServicesSku sku) : base(tags, additionalBinaryDataProperties, sku)
        {
        }
    }
}
