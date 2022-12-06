// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> This is a set of request parameters for LUIS Generally Available projects. </summary>
    public partial class LuisParameters : AnalysisParameters
    {
        /// <summary> Initializes a new instance of LuisParameters. </summary>
        public LuisParameters()
        {
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
            TargetProjectKind = TargetProjectKind.Luis;
        }

        /// <summary> The utterance to predict. </summary>
        public string Query { get; set; }
        /// <summary> This customizes how the service calls LUIS Generally Available projects. </summary>
        public LuisCallingOptions CallingOptions { get; set; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, object> AdditionalProperties { get; }
    }
}
