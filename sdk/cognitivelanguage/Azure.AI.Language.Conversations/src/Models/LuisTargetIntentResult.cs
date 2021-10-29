// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations.Models
{
    /// <summary> It is a wrap up of LUIS Generally Available response. </summary>
    [CodeGenModel("LuisTargetIntentResult")]
    public partial class LuisTargetIntentResult : TargetIntentResult
    {
        /// <summary> The actual response from a LUIS Generally Available application. </summary>
        [CodeGenMember("Result")]
        internal object InternalResult { get; }

        /// <summary> Binary Data wrapper for the response from a LUIS Generally Available application. </summary>
        public BinaryData Result { get => BinaryData.FromObjectAsJson(InternalResult); }
    }
}
