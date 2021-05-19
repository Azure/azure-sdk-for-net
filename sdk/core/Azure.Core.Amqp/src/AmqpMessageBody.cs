// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents an AMQP message body.
    /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#section-message-format" />
    /// </summary>
    public class AmqpMessageBody
    {
        /// <summary>
        /// The data sections for the AMQP message body.
        /// </summary>
        private readonly IEnumerable<ReadOnlyMemory<byte>> _data;

        /// <summary>
        /// Gets the type of the message body.
        /// </summary>
        public AmqpMessageBodyType BodyType { get; }

        /// <summary>
        /// Initializes a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in data sections.
        /// </summary>
        /// <param name="data">The data sections.</param>
        public AmqpMessageBody(IEnumerable<ReadOnlyMemory<byte>> data)
        {
            Argument.AssertNotNull(data, nameof(data));
            _data = data;
            BodyType = AmqpMessageBodyType.Data;
        }

        /// <summary>
        /// Try to get the data sections for the AMQP message body.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool TryGetData(out IEnumerable<ReadOnlyMemory<byte>>? data)
        {
            if (BodyType == AmqpMessageBodyType.Data)
            {
                data = _data;
                return true;
            }
            data = null;
            return false;
        }
    }
}
