// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Delete Hold Group Request.
    /// </summary>
    public class DeleteHoldGroupOptions
    {
        /// <summary>
        /// Creates a new DeleteHoldGroupOptions object.
        /// </summary>
        /// <param name="holdGroupId">The ID of the hold group to delete.</param>
        public DeleteHoldGroupOptions(string holdGroupId)
        {
            HoldGroupId = holdGroupId;
        }

        /// <summary>
        /// The ID of the hold group to delete.
        /// </summary>
        public string HoldGroupId { get; }

        /// <summary>
        /// The operation context to correlate the request to the response event.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
