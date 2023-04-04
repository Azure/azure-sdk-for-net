// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Base Checkpointer class to create the checkpointing logic
    /// to resume from.
    /// </summary>
    public class TransferCheckpointerMethod
    {
        internal TransferCheckpointer checkpointer;
        /// <summary>
        /// Sets the transfer checkpointer options.
        /// </summary>
        /// <param name="localCheckpointerPath"></param>
        public TransferCheckpointerMethod(string localCheckpointerPath)
        {
            checkpointer = new LocalTransferCheckpointer(localCheckpointerPath);
        }
    }
}
