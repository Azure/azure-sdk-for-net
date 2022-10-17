// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models
{
    internal class TransferEventsInternal
    {
        public delegate Task InvokeTransferStatusEvent(TransferStatusEventArgs arg);
        public delegate Task InvokeFailedEvent(TransferFailedEventArgs arg);

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public InvokeTransferStatusEvent InvokeTransferStatus { get; set; }

        /// <summary>
        /// If the transfer has any failed events that occur the event will get added to this handler.
        /// </summary>
        public InvokeFailedEvent InvokeFailedArg { get; set; }
    }
}
