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
        /// Creates a new CallIntelligenceOptions object.
        /// </summary>
        /// <param name="cognitiveServicesEndpoint">The endpoint URL of the Azure Cognitive Services resource attached.</param>
        public CallIntelligenceOptions(Uri cognitiveServicesEndpoint)
        {
            CognitiveServicesEndpoint = cognitiveServicesEndpoint;
        }

        /// <summary>
        /// The endpoint URL of the Azure Cognitive Services resource attached
        /// </summary>
        public Uri CognitiveServicesEndpoint { get; set; }
    }
}
