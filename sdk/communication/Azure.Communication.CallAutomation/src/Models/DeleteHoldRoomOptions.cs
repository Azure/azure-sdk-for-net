// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for deleting a hold room.
    /// </summary>
    public class DeleteHoldRoomOptions
    {
        /// <summary>
        /// Used by customers when calling mid-call actions to correlate the request to the response event.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
