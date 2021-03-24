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
        private readonly IEnumerable<ReadOnlyMemory<byte>>? _data;

        /// <summary>
        /// The value section for the AMQP message body.
        /// </summary>
        private readonly object? _value;

        /// <summary>
        /// The sequence sections for the AMQP message body.
        /// </summary>
        private IEnumerable<IList<object>>? _sequence;

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
        /// Initializes a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in value.
        /// </summary>
        /// <param name="value">The data sections.</param>
        public AmqpMessageBody(object value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
            BodyType = AmqpMessageBodyType.Value;
        }

        /// <summary>
        /// Initializes a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in sequence sections.
        /// </summary>
        /// <param name="sequence">The sequence sections.</param>
        public AmqpMessageBody(IEnumerable<IList<object>> sequence)
        {
            Argument.AssertNotNull(sequence, nameof(sequence));
            _sequence = sequence;
            BodyType = AmqpMessageBodyType.Sequence;
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

        /// <summary>
        /// Try to get the value section for the AMQP message body.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(out object? value)
        {
            if (BodyType == AmqpMessageBodyType.Value)
            {
                value = _value;
                return true;
            }
            value = null;
            return false;
        }

        /// <summary>
        /// Try to get the sequence section for the AMQP message body.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public bool TryGetSequence(out IEnumerable<IList<object>>? sequence)
        {
            if (BodyType == AmqpMessageBodyType.Sequence)
            {
                sequence = _sequence;
                return true;
            }
            sequence = null;
            return false;
        }
    }
}
