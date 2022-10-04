// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines the state of the transfer
    /// </summary>
    internal class DataTransferState
    {
        private string _id;
        private bool _completed;
        private long _transferredBytes;

        /// <summary>
        /// constructor
        /// </summary>
        public DataTransferState()
        {
            _id = Guid.NewGuid().ToString();
            _completed = false;
            _transferredBytes = 0;
        }

        /// <summary>
        /// Gets the identifier of the transfer state
        /// </summary>
        public string Id
        {
            get { return _id; }
            internal set { }
        }

        /// <summary>
        /// Defines whether the transfer is completed
        /// </summary>
        public bool IsCompleted
        {
            get { return _completed; }
            internal set { }
        }

        /// <summary>
        /// Defines how many bytes are transferred to far
        /// </summary>
        public long TransferredBytes
        {
            get { return _transferredBytes; }
            internal set { }
        }

        /// <summary>
        /// Sets the id of the transfer
        /// </summary>
        /// <param name="id"></param>
        public void SetId(string id)
        {
            _id = id;
        }

        /// <summary>
        /// Sets the completion status
        /// </summary>
        /// <param name="completed"></param>
        public void SetCompleted(bool completed)
        {
            _completed = completed;
        }

        /// <summary>
        /// Sets the amount of bytes transferred
        /// </summary>
        /// <param name="transferredBytes"></param>\
        public void SetTransferBytes(long transferredBytes)
        {
            _transferredBytes = transferredBytes;
        }
    }
}
