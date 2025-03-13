// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    /// <summary>
    /// CognitiveServicesCommitmentPlanPatch
    /// </summary>
    public partial class CognitiveServicesCommitmentPlanPatch : PatchResourceTagsAndSku
    {
        /// <summary>
        /// CognitiveServicesCommitmentPlanPatch
        /// </summary>
        public CognitiveServicesCommitmentPlanPatch() : base()
        {
        }
        internal CognitiveServicesCommitmentPlanPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData, CognitiveServicesSku sku): base(tags, serializedAdditionalRawData, sku)
        {
        }
    }
}
