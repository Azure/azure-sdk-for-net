// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public DeleteHoldGroupOptions()
        {
        }

        /// <summary>
        /// The operation context to correlate the request to the response event.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
