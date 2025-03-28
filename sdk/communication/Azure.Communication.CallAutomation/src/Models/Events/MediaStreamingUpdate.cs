// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("MediaStreamingUpdate", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class MediaStreamingUpdate
    {
        /// <summary> Gets the media streaming status. </summary>
        public MediaStreamingStatus MediaStreamingStatus { get; }
        /// <summary> Gets the media streaming status details. </summary>
        public MediaStreamingStatusDetails MediaStreamingStatusDetails { get; }
    }
}
