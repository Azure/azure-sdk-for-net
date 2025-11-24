// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.DocumentIntelligence
{
    [CodeGenType("AzureAIDocumentIntelligenceClientOptions")]
    public partial class DocumentIntelligenceClientOptions
    {
        // CUSTOM CODE NOTE: overwriting the behavior of the constructor
        // to enable logging of the apim-request-id header by default.

        /// <summary> Initializes new instance of DocumentIntelligenceClientOptions. </summary>
        public DocumentIntelligenceClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2024_11_30 => "2024-11-30",
                _ => throw new NotSupportedException()
            };

            Diagnostics.LoggedHeaderNames.Add("apim-request-id");
        }
    }
}
