// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// AI options for the call.
    /// </summary>
    public class CallIntelligenceOptions
    {
        /// <summary>
        /// The endpoint URL of the Azure Cognitive Services resource attached
        /// </summary>
        public Uri CognitiveServicesEndpoint { get; set; }
    }
}
