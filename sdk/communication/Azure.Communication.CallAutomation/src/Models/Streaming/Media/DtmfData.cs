// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming dtmf data.
    /// </summary>
    public class DtmfData : StreamingData
    {
        /// <summary>
        /// The dtmf data, encoded as a base64 string
        /// </summary>
        /// <param name="data"></param>
        public DtmfData(string data)
        {
            Data = data;
        }

        internal DtmfData(string data, DateTime timestamp, string participantId)
        {
            Data = !string.IsNullOrWhiteSpace(data) ? data : default;
        }

        /// <summary>
        /// The dtmf data in base64 string.
        /// </summary>
        public string Data { get; }
    }
}
