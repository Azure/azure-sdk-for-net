// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming Mark data.
    /// </summary>
    public class MarkData : StreamingData
    {
        /// <summary>
        /// The mark data
        /// </summary>
        public MarkData()
        {
        }

        /// <summary>
        /// The id of this mark data
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The status of this mark data
        /// </summary>
        public MarkStatus Status { get; set; }
    }
}
