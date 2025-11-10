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
        /// <param name="id"></param>
        /// <param name="status"></param>
        public MarkData(string id, MarkStatus status)
        {
            Id = id;
            Status = status;
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
