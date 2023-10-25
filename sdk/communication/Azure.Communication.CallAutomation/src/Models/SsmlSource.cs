// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The SsmlSource. </summary>
    public class SsmlSource : PlaySource
    {
        /// <summary> Initializes a new instance of SsmlSourceInternal. </summary>
        /// <param name="ssmlText"> Ssml string for the cognitive service to be played. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ssmlText"/> is null. </exception>
        public SsmlSource(string ssmlText)
        {
            Argument.AssertNotNull(ssmlText, nameof(ssmlText));
            SsmlText = ssmlText;
        }

        /// <summary> Ssml string for the cognitive service to be played. </summary>
        public string SsmlText { get; }
        /// <summary> Endpoint where the custom voice was deployed. </summary>
        public string CustomVoiceEndpointId { get; set; }
    }
}
