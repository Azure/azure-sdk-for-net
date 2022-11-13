// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Holds transfer information
    /// </summary>
    public class DataTransfer
    {
        /// <summary>
        /// Defines whether the DataTransfer has completed.
        /// </summary>
        public bool IsCompleted => _state.IsCompleted;

        /// <summary>
        /// DataTransfer Identification
        /// </summary>
        public string Id => _state.Id;

        /// <summary>
        /// Defines the current state of the transfer
        /// </summary>
        internal DataTransferState _state;

        /// <summary>
        /// Only to be created internally by the transfer manager
        /// </summary>
        internal DataTransfer()
        {
            _state = new DataTransferState();
        }

        /// <summary>
        /// Only to be created internally by the transfer manager when someone
        /// provides a valid job plan file to resume from.
        /// </summary>
        internal DataTransfer(string id, long bytesTransferred)
        {
            _state = new DataTransferState(id, bytesTransferred);
        }
    }
}
