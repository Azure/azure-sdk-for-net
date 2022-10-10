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
        /// For mocking
        /// </summary>
        internal DataTransfer()
        {
            _state = new DataTransferState();
        }
    }
}
