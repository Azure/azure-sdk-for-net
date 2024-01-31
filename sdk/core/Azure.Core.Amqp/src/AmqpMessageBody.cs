// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

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
        private readonly IEnumerable<IList<object>>? _sequence;

        /// <summary>
        /// Gets the type of the message body.
        /// </summary>
        public AmqpMessageBodyType BodyType { get; }

        /// <summary>
        /// Initializes a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in data sections.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data" />
        /// </summary>
        /// <param name="data">The data sections.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AmqpMessageBody(IEnumerable<ReadOnlyMemory<byte>> data)
        {
            Argument.AssertNotNull(data, nameof(data));
            _data = data;
            BodyType = AmqpMessageBodyType.Data;
        }

        /// <summary>
        /// Initializes a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in value.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-amqp-value" />
        /// </summary>
        /// <param name="value">The value section.</param>
        private AmqpMessageBody(object value)
        {
            ValidateAmqpPrimitive(value, nameof(value));
            _value = value;
            BodyType = AmqpMessageBodyType.Value;
        }

        /// <summary>
        /// Initializes a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in sequence sections.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-amqp-sequence" />
        /// </summary>
        /// <param name="sequence">The sequence sections.</param>
        private AmqpMessageBody(IEnumerable<IList<object>> sequence)
        {
            ValidateAmqpPrimitive(sequence, nameof(sequence));
            _sequence = sequence;
            BodyType = AmqpMessageBodyType.Sequence;
        }

        /// <summary>
        /// Creates a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in data sections.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-data" />
        /// </summary>
        /// <param name="data">The data sections.</param>
        public static AmqpMessageBody FromData(IEnumerable<ReadOnlyMemory<byte>> data) =>
            new AmqpMessageBody(data);

        /// <summary>
        /// Creates a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in value.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-amqp-value" />
        /// </summary>
        /// <param name="value">The value section.</param>
        public static AmqpMessageBody FromValue(object value) =>
            new AmqpMessageBody(value);

        /// <summary>
        /// Creates a new <see cref="AmqpMessageBody"/> instance with the
        /// passed in sequence.
        /// <seealso href="http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#type-amqp-value" />
        /// </summary>
        /// <param name="sequence">The sequence sections.</param>
        public static AmqpMessageBody FromSequence(IEnumerable<IList<object>> sequence) =>
            new AmqpMessageBody(sequence);

        /// <summary>
        /// Try to get the data sections for the AMQP message body.
        /// </summary>
        /// <param name="data">If the <see cref="AmqpMessageBody"/> instance is <see cref="AmqpMessageBodyType.Data"/>, this
        /// will be populated with the data sections for the message.</param>
        /// <returns>True if the <see cref="AmqpMessageBody"/> instance is <see cref="AmqpMessageBodyType.Data"/>.</returns>
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
        /// <param name="value">If the <see cref="AmqpMessageBody"/> instance is <see cref="AmqpMessageBodyType.Value"/>, this
        /// will be populated with the value section for the message.</param>
        /// <returns>True if the <see cref="AmqpMessageBody"/> instance is <see cref="AmqpMessageBodyType.Value"/>.</returns>
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
        /// <param name="sequence">If the <see cref="AmqpMessageBody"/> instance is <see cref="AmqpMessageBodyType.Sequence"/>, this
        /// will be populated with the sequence sections for the message.</param>
        /// <returns>True if the <see cref="AmqpMessageBody"/> instance is <see cref="AmqpMessageBodyType.Sequence"/>.</returns>
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

        private static void ValidateAmqpPrimitive(object value, string paramName)
        {
            Argument.AssertNotNull(value, paramName);
            switch (value)
            {
                case string:
                case byte:
                case sbyte:
                case char:
                case short:
                case ushort:
                case int:
                case uint:
                case long:
                case ulong:
                case float:
                case double:
                case decimal:
                case bool:
                case Guid:
                case DateTime:
                case DateTimeOffset:
                case TimeSpan:
                case Uri:
                case IEnumerable<string>:
                case IEnumerable<byte>:
                case IEnumerable<sbyte>:
                case IEnumerable<char>:
                case IEnumerable<short>:
                case IEnumerable<ushort>:
                case IEnumerable<int>:
                case IEnumerable<uint>:
                case IEnumerable<long>:
                case IEnumerable<ulong>:
                case IEnumerable<float>:
                case IEnumerable<double>:
                case IEnumerable<decimal>:
                case IEnumerable<bool>:
                case IEnumerable<Guid>:
                case IEnumerable<DateTime>:
                case IEnumerable<DateTimeOffset>:
                case IEnumerable<TimeSpan>:
                case IEnumerable<Uri>:
                case IEnumerable<KeyValuePair<string, string>>:
                case IEnumerable<KeyValuePair<string, byte>>:
                case IEnumerable<KeyValuePair<string, sbyte>>:
                case IEnumerable<KeyValuePair<string, char>>:
                case IEnumerable<KeyValuePair<string, short>>:
                case IEnumerable<KeyValuePair<string, ushort>>:
                case IEnumerable<KeyValuePair<string, int>>:
                case IEnumerable<KeyValuePair<string, uint>>:
                case IEnumerable<KeyValuePair<string, long>>:
                case IEnumerable<KeyValuePair<string, ulong>>:
                case IEnumerable<KeyValuePair<string, float>>:
                case IEnumerable<KeyValuePair<string, double>>:
                case IEnumerable<KeyValuePair<string, decimal>>:
                case IEnumerable<KeyValuePair<string, bool>>:
                case IEnumerable<KeyValuePair<string, Guid>>:
                case IEnumerable<KeyValuePair<string, DateTime>>:
                case IEnumerable<KeyValuePair<string, DateTimeOffset>>:
                case IEnumerable<KeyValuePair<string, TimeSpan>>:
                case IEnumerable<KeyValuePair<string, Uri>>:
                    return;
                case KeyValuePair<string, object> kvp:
                    ValidateAmqpPrimitive(kvp.Value, paramName);
                    break;
                case IEnumerable enumerable:
                    foreach (object val in enumerable)
                    {
                        ValidateAmqpPrimitive(val, paramName);
                    }
                    break;
                default:
                    throw new NotSupportedException($"Values of type {value.GetType()} are not supported. " +
                        $"Only the following types are supported: string, byte, char, short, int, long, float, double, decimal, bool, " +
                        $"Guid, DateTime, DateTimeOffset, Timespan, Uri.");
            }
        }
    }
}
