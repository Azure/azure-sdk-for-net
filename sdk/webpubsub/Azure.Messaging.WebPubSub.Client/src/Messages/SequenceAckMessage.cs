// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The message representing SequenceAck.
    /// </summary>
    public class SequenceAckMessage : WebPubSubMessage
    {
        /// <summary>
        /// The sequenceId
        /// </summary>
        public long SequenceId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequenceAckMessage"/> class.
        /// </summary>
        /// <param name="sequenceId">The sequenceId</param>
        public SequenceAckMessage(long sequenceId)
        {
            SequenceId = sequenceId;
        }
    }
}
