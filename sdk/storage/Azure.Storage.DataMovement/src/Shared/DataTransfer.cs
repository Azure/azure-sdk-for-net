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
        private DataTransferState _state;

        /// <summary>
        /// For mocking
        /// </summary>
        protected DataTransfer()
        { }

        /// <summary>
        /// Constructing intial DataTransfer
        /// </summary>
        /// <param name="id"></param>
        protected DataTransfer(string id)
        {
            _state = new DataTransferState()
            {
                IsCompleted = false,
                Id = id,
                TransferredBytes = 0,
            };
        }
    }
}
