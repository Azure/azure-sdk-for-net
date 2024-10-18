// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

// The CognitiveServicesCommitmentPlanPatch class has been replaced by PatchResourceTagsAndSku.
// Therefore we suppress the generation of CognitiveServicesCommitmentPlanPatch to avoid redundancy.
[assembly: CodeGenSuppressType("CognitiveServicesCommitmentPlanPatch")]
namespace Azure.ResourceManager.CognitiveServices.Models
{
    /// <summary> The object being used to update tags and sku of a resource, in general used for PATCH operations. </summary>
    public partial class CognitiveServicesCommitmentPlanPatch : CognitiveServicesPatchResourceTags
    {
        /// <summary> Initializes a new instance of <see cref="CognitiveServicesCommitmentPlanPatch"/>. </summary>
        public CognitiveServicesCommitmentPlanPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CognitiveServicesCommitmentPlanPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="sku"> The resource model definition representing SKU. </param>
        internal CognitiveServicesCommitmentPlanPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData, CognitiveServicesSku sku) : base(tags, serializedAdditionalRawData)
        {
            Sku = sku;
        }

        /// <summary> The resource model definition representing SKU. </summary>
        [WirePath("sku")]
        public CognitiveServicesSku Sku { get; set; }
    }
}
