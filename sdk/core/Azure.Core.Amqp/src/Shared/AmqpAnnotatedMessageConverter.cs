// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

#nullable enable

namespace Azure.Core.Amqp.Shared
{
    /// <summary>
    ///   Serves as a translator between AmqpAnnotatedMessage and AmqpMessage
    /// </summary>
    ///
    internal static class AmqpAnnotatedMessageConverter
    {
        /// <summary>The size, in bytes, to use as a buffer for stream operations.</summary>
        private const int StreamBufferSizeInBytes = 512;

        /// <summary>The set of mappings from CLR types to AMQP types for property values.</summary>
        private static readonly IReadOnlyDictionary<Type, AmqpType> AmqpPropertyTypeMap = new Dictionary<Type, AmqpType>
        {
            { typeof(byte), AmqpType.Byte },
            { typeof(sbyte), AmqpType.SByte },
            { typeof(char), AmqpType.Char },
            { typeof(short), AmqpType.Int16 },
            { typeof(ushort), AmqpType.UInt16 },
            { typeof(int), AmqpType.Int32 },
            { typeof(uint), AmqpType.UInt32 },
            { typeof(long), AmqpType.Int64 },
            { typeof(ulong), AmqpType.UInt64 },
            { typeof(float), AmqpType.Single },
            { typeof(double), AmqpType.Double },
            { typeof(decimal), AmqpType.Decimal },
            { typeof(bool), AmqpType.Boolean },
            { typeof(Guid), AmqpType.Guid },
            { typeof(string), AmqpType.String },
            { typeof(Uri), AmqpType.Uri },
            { typeof(DateTime), AmqpType.DateTime },
            { typeof(DateTimeOffset), AmqpType.DateTimeOffset },
            { typeof(TimeSpan), AmqpType.TimeSpan },
        };

        /// <summary>
        ///   Converts an <see cref="AmqpAnnotatedMessage" /> into an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="sourceMessage">The source message.</param>
        ///
        /// <returns>The <see cref="AmqpMessage" /> constructed from the source message.</returns>
        ///
        /// <remarks>
        ///   The caller is assumed to hold ownership over the message once it has been created, including
        ///   ensuring proper disposal.
        /// </remarks>
        ///
        public static AmqpMessage ToAmqpMessage(AmqpAnnotatedMessage sourceMessage)
        {
            var message = sourceMessage switch
            {
                _ when sourceMessage.Body.TryGetData(out var dataBody) => AmqpMessage.Create(TranslateDataBody(dataBody!)),
                _ when sourceMessage.Body.TryGetSequence(out var sequenceBody) => AmqpMessage.Create(TranslateSequenceBody(sequenceBody!)),
                _ when sourceMessage.Body.TryGetValue(out var valueBody) => AmqpMessage.Create(TranslateValueBody(valueBody!)),
                _ => AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(Array.Empty<byte>()) })
            };

            // Header

            if (sourceMessage.HasSection(AmqpMessageSection.Header))
            {
                if (sourceMessage.Header.DeliveryCount.HasValue)
                {
                    message.Header.DeliveryCount = sourceMessage.Header.DeliveryCount;
                }

                if (sourceMessage.Header.Durable.HasValue)
                {
                    message.Header.Durable = sourceMessage.Header.Durable;
                }

                if (sourceMessage.Header.Priority.HasValue)
                {
                    message.Header.Priority = sourceMessage.Header.Priority;
                }

                if (sourceMessage.Header.FirstAcquirer.HasValue)
                {
                    message.Header.FirstAcquirer = sourceMessage.Header.FirstAcquirer;
                }
            }

            // Properties

            if (sourceMessage.HasSection(AmqpMessageSection.Properties))
            {
                if (sourceMessage.Properties.AbsoluteExpiryTime.HasValue)
                {
                    message.Properties.AbsoluteExpiryTime = sourceMessage.Properties.AbsoluteExpiryTime.Value.UtcDateTime;
                }

                if (!string.IsNullOrEmpty(sourceMessage.Properties.ContentEncoding))
                {
                    message.Properties.ContentEncoding = sourceMessage.Properties.ContentEncoding;
                }

                if (!string.IsNullOrEmpty(sourceMessage.Properties.ContentType))
                {
                    message.Properties.ContentType = sourceMessage.Properties.ContentType;
                }

                if (sourceMessage.Properties.CorrelationId.HasValue)
                {
                    message.Properties.CorrelationId = sourceMessage.Properties.CorrelationId.Value.ToString();
                }

                if (sourceMessage.Properties.CreationTime.HasValue)
                {
                    message.Properties.CreationTime = sourceMessage.Properties.CreationTime.Value.UtcDateTime;
                }

                if (!string.IsNullOrEmpty(sourceMessage.Properties.GroupId))
                {
                    message.Properties.GroupId = sourceMessage.Properties.GroupId;
                }

                if (sourceMessage.Properties.GroupSequence.HasValue)
                {
                    message.Properties.GroupSequence = sourceMessage.Properties.GroupSequence;
                }

                if (sourceMessage.Properties.MessageId.HasValue)
                {
                    message.Properties.MessageId = sourceMessage.Properties.MessageId.Value.ToString();
                }

                if (sourceMessage.Properties.ReplyTo.HasValue)
                {
                    message.Properties.ReplyTo = sourceMessage.Properties.ReplyTo.Value.ToString();
                }

                if (!string.IsNullOrEmpty(sourceMessage.Properties.ReplyToGroupId))
                {
                    message.Properties.ReplyToGroupId = sourceMessage.Properties.ReplyToGroupId;
                }

                if (!string.IsNullOrEmpty(sourceMessage.Properties.Subject))
                {
                    message.Properties.Subject = sourceMessage.Properties.Subject;
                }

                if (sourceMessage.Properties.To.HasValue)
                {
                    message.Properties.To = sourceMessage.Properties.To.Value.ToString();
                }

                if (sourceMessage.Properties.UserId.HasValue)
                {
                    if (MemoryMarshal.TryGetArray(sourceMessage.Properties.UserId.Value, out var segment))
                    {
                        message.Properties.UserId = segment;
                    }
                    else
                    {
                        message.Properties.UserId = new ArraySegment<byte>(sourceMessage.Properties.UserId.Value.ToArray());
                    }
                }
            }

            // Application Properties

            if ((sourceMessage.HasSection(AmqpMessageSection.ApplicationProperties)) && (sourceMessage.ApplicationProperties.Count > 0))
            {
                message.ApplicationProperties ??= new ApplicationProperties();

                foreach (var pair in sourceMessage.ApplicationProperties)
                {
                    if (TryCreateAmqpPropertyValueFromNetProperty(pair.Value, out var amqpValue))
                    {
                        message.ApplicationProperties.Map[pair.Key] = amqpValue;
                    }
                    else
                    {
                        ThrowSerializationFailed(nameof(sourceMessage.ApplicationProperties), pair);
                    }
                }
            }

            // Message Annotations

            if (sourceMessage.HasSection(AmqpMessageSection.MessageAnnotations))
            {
                foreach (var pair in sourceMessage.MessageAnnotations)
                {
                    if (TryCreateAmqpPropertyValueFromNetProperty(pair.Value, out var amqpValue))
                    {
                        message.MessageAnnotations.Map[pair.Key] = amqpValue;
                    }
                    else
                    {
                        ThrowSerializationFailed(nameof(sourceMessage.MessageAnnotations), pair);
                    }
                }
            }

            // Delivery Annotations

            if (sourceMessage.HasSection(AmqpMessageSection.DeliveryAnnotations))
            {
                foreach (var pair in sourceMessage.DeliveryAnnotations)
                {
                    if (TryCreateAmqpPropertyValueFromNetProperty(pair.Value, out var amqpValue))
                    {
                        message.DeliveryAnnotations.Map[pair.Key] = amqpValue;
                    }
                    else
                    {
                        ThrowSerializationFailed(nameof(sourceMessage.DeliveryAnnotations), pair);
                    }
                }
            }

            // Footer

            if (sourceMessage.HasSection(AmqpMessageSection.Footer))
            {
                foreach (var pair in sourceMessage.Footer)
                {
                    if (TryCreateAmqpPropertyValueFromNetProperty(pair.Value, out var amqpValue))
                    {
                        message.Footer.Map[pair.Key] = amqpValue;
                    }
                    else
                    {
                        ThrowSerializationFailed(nameof(sourceMessage.Footer), pair);
                    }
                }
            }

            // There is a loss of fidelity in the TTL header if larger than uint.MaxValue. As a workaround
            // we set the AbsoluteExpiryTime and CreationTime on the message based on the TTL. These
            // values are then used to reconstruct the accurate TTL for received messages.
            if (sourceMessage.Header.TimeToLive.HasValue)
            {
                var ttl = sourceMessage.Header.TimeToLive.Value;

                message.Header.Ttl = ttl.TotalMilliseconds > uint.MaxValue
                    ? uint.MaxValue
                    : (uint) ttl.TotalMilliseconds;

                message.Properties.CreationTime = DateTime.UtcNow;

                if (AmqpConstants.MaxAbsoluteExpiryTime - message.Properties.CreationTime.Value > ttl)
                {
                    message.Properties.AbsoluteExpiryTime = message.Properties.CreationTime.Value + ttl;
                }
                else
                {
                    message.Properties.AbsoluteExpiryTime = AmqpConstants.MaxAbsoluteExpiryTime;
                }
            }

            return message;
        }

        /// <summary>
        ///   Constructs an <see cref="AmqpAnnotatedMessage" /> from an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The source message.</param>
        ///
        /// <returns>The <see cref="AmqpAnnotatedMessage" /> constructed from the source message.</returns>
        ///
        public static AmqpAnnotatedMessage FromAmqpMessage(AmqpMessage source)
        {
            var message = source switch
            {
                _ when TryGetDataBody(source, out var dataBody) => new AmqpAnnotatedMessage(dataBody!),
                _ when TryGetSequenceBody(source, out var sequenceBody) => new AmqpAnnotatedMessage(sequenceBody!),
                _ when TryGetValueBody(source, out var valueBody) => new AmqpAnnotatedMessage(valueBody!),
                _ => new AmqpAnnotatedMessage(AmqpMessageBody.FromData(MessageBody.FromReadOnlyMemorySegment(ReadOnlyMemory<byte>.Empty)))
            };

            // Header

            if ((source.Sections & SectionFlag.Header) > 0)
            {
                if (source.Header.DeliveryCount.HasValue)
                {
                    message.Header.DeliveryCount = source.Header.DeliveryCount;
                }

                if (source.Header.Durable.HasValue)
                {
                    message.Header.Durable = source.Header.Durable;
                }

                if (source.Header.Priority.HasValue)
                {
                    message.Header.Priority = source.Header.Priority;
                }

                if (source.Header.FirstAcquirer.HasValue)
                {
                    message.Header.FirstAcquirer = source.Header.FirstAcquirer;
                }

                if (source.Header.DeliveryCount.HasValue)
                {
                    message.Header.DeliveryCount = source.Header.DeliveryCount;
                }

                if (source.Header.Ttl.HasValue)
                {
                    message.Header.TimeToLive = TimeSpan.FromMilliseconds(source.Header.Ttl.Value);
                }
            }

            // Properties

            if ((source.Sections & SectionFlag.Properties) > 0)
            {
                if (source.Properties.AbsoluteExpiryTime.HasValue)
                {
                    DateTimeOffset absoluteExpiryTime = source.Properties.AbsoluteExpiryTime >= DateTimeOffset.MaxValue.UtcDateTime
                        ? DateTimeOffset.MaxValue
                        : source.Properties.AbsoluteExpiryTime.Value;

                    message.Properties.AbsoluteExpiryTime = absoluteExpiryTime;

                    // The TTL from the header can be at most approximately 49 days (Uint32.MaxValue milliseconds) due
                    // to the AMQP spec. In order to allow for larger TTLs set by the user, we take the difference of the AbsoluteExpiryTime
                    // and the CreationTime (if both are set). If either of those properties is not set, we fall back to the
                    // TTL from the header.

                    if (source.Properties.CreationTime.HasValue)
                    {
                        message.Header.TimeToLive = absoluteExpiryTime- source.Properties.CreationTime.Value;
                    }
                }

                if (!string.IsNullOrEmpty(source.Properties.ContentEncoding.Value))
                {
                    message.Properties.ContentEncoding = source.Properties.ContentEncoding.Value;
                }

                if (!string.IsNullOrEmpty(source.Properties.ContentType.Value))
                {
                    message.Properties.ContentType = source.Properties.ContentType.Value;
                }

                if (source.Properties.CorrelationId != null)
                {
                    message.Properties.CorrelationId = new AmqpMessageId(source.Properties.CorrelationId.ToString()!);
                }

                if (source.Properties.CreationTime.HasValue)
                {
                    message.Properties.CreationTime = source.Properties.CreationTime;
                }

                if (!string.IsNullOrEmpty(source.Properties.GroupId))
                {
                    message.Properties.GroupId = source.Properties.GroupId;
                }

                if (source.Properties.GroupSequence.HasValue)
                {
                    message.Properties.GroupSequence = source.Properties.GroupSequence;
                }

                if (source.Properties.MessageId != null)
                {
                    message.Properties.MessageId = new AmqpMessageId(source.Properties.MessageId.ToString()!);
                }

                if (source.Properties.ReplyTo != null)
                {
                    message.Properties.ReplyTo = new AmqpAddress(source.Properties.ReplyTo.ToString()!);
                }

                if (!string.IsNullOrEmpty(source.Properties.ReplyToGroupId))
                {
                    message.Properties.ReplyToGroupId = source.Properties.ReplyToGroupId;
                }

                if (!string.IsNullOrEmpty(source.Properties.Subject))
                {
                    message.Properties.Subject = source.Properties.Subject;
                }

                if (source.Properties.To != null)
                {
                    message.Properties.To = new AmqpAddress(source.Properties.To.ToString()!);
                }

                if (source.Properties.UserId != default)
                {
                    message.Properties.UserId = source.Properties.UserId;
                }
            }

            // Application Properties

            if ((source.Sections & SectionFlag.ApplicationProperties) > 0)
            {
                foreach (var pair in source.ApplicationProperties.Map)
                {
                    if (TryCreateNetPropertyFromAmqpProperty(pair.Value, out var propertyValue))
                    {
                        message.ApplicationProperties[pair.Key.ToString()] = propertyValue;
                    }
                }
            }

            // Message Annotations

            if ((source.Sections & SectionFlag.MessageAnnotations) > 0)
            {
                foreach (var pair in source.MessageAnnotations.Map)
                {
                    if (TryCreateNetPropertyFromAmqpProperty(pair.Value, out var propertyValue))
                    {
                        message.MessageAnnotations[pair.Key.ToString()] = propertyValue;
                    }
                }
            }

            // Delivery Annotations

            if ((source.Sections & SectionFlag.DeliveryAnnotations) > 0)
            {
                foreach (var pair in source.DeliveryAnnotations.Map)
                {
                    if (TryCreateNetPropertyFromAmqpProperty(pair.Value, out var eventValue))
                    {
                        message.DeliveryAnnotations[pair.Key.ToString()] = eventValue;
                    }
                }
            }

            // Footer

            if ((source.Sections & SectionFlag.Footer) > 0)
            {
                foreach (var pair in source.Footer.Map)
                {
                    if (TryCreateNetPropertyFromAmqpProperty(pair.Value, out var eventValue))
                    {
                        message.Footer[pair.Key.ToString()] = eventValue;
                    }
                }
            }

            return message;
        }

        /// <summary>
        ///   Attempts to create an AMQP property value for a given event property.
        /// </summary>
        ///
        /// <param name="propertyValue">The value of the event property to create an AMQP property value for.</param>
        /// <param name="amqpPropertyValue">The AMQP property value that was created.</param>
        /// <param name="allowBodyTypes"><c>true</c> to allow an AMQP map to be translated to additional types supported only by a message body; otherwise, <c>false</c>.</param>
        ///
        /// <returns><c>true</c> if an AMQP property value was able to be created; otherwise, <c>false</c>.</returns>
        ///
        public static bool TryCreateAmqpPropertyValueFromNetProperty(
            object? propertyValue,
            out object? amqpPropertyValue,
            bool allowBodyTypes = false)
        {
            amqpPropertyValue = null;

            if (propertyValue == null)
            {
                return true;
            }

            switch (GetTypeIdentifier(propertyValue))
            {
                case AmqpType.Byte:
                case AmqpType.SByte:
                case AmqpType.Int16:
                case AmqpType.Int32:
                case AmqpType.Int64:
                case AmqpType.UInt16:
                case AmqpType.UInt32:
                case AmqpType.UInt64:
                case AmqpType.Single:
                case AmqpType.Double:
                case AmqpType.Boolean:
                case AmqpType.Decimal:
                case AmqpType.Char:
                case AmqpType.Guid:
                case AmqpType.DateTime:
                case AmqpType.String:
                    amqpPropertyValue = propertyValue;
                    break;

                case AmqpType.Stream:
                case AmqpType.Unknown when propertyValue is Stream:
                    amqpPropertyValue = ReadStreamToArraySegment((Stream)propertyValue);
                    break;

                case AmqpType.Uri:
                    amqpPropertyValue = new DescribedType((AmqpSymbol)AmqpMessageConstants.Uri, ((Uri)propertyValue).AbsoluteUri);
                    break;

                case AmqpType.DateTimeOffset:
                    amqpPropertyValue = new DescribedType((AmqpSymbol)AmqpMessageConstants.DateTimeOffset, ((DateTimeOffset)propertyValue).UtcTicks);
                    break;

                case AmqpType.TimeSpan:
                    amqpPropertyValue = new DescribedType((AmqpSymbol)AmqpMessageConstants.TimeSpan, ((TimeSpan)propertyValue).Ticks);
                    break;

                case AmqpType.Unknown when allowBodyTypes && propertyValue is byte[] byteArray:
                    amqpPropertyValue = new ArraySegment<byte>(byteArray);
                    break;

                case AmqpType.Unknown when allowBodyTypes && propertyValue is IDictionary dict:
                    amqpPropertyValue = new AmqpMap(dict);
                    break;

                case AmqpType.Unknown when allowBodyTypes && propertyValue is IList:
                    amqpPropertyValue = propertyValue;
                    break;

                case AmqpType.Unknown:
                    var exception = new SerializationException(string.Format(CultureInfo.CurrentCulture, "Serialization failed due to an unsupported type, {0}.", propertyValue.GetType().FullName));
                    throw exception;
            }

            return (amqpPropertyValue != null);
        }

        /// <summary>
        ///   Attempts to create a message property value for a given AMQP property.
        /// </summary>
        ///
        /// <param name="amqpPropertyValue">The value of the AMQP property to create a message property value for.</param>
        /// <param name="convertedPropertyValue">The message property value that was created.</param>
        /// <param name="allowBodyTypes"><c>true</c> to allow an AMQP map to be translated to additional types supported only by a message body; otherwise, <c>false</c>.</param>
        ///
        /// <returns><c>true</c> if a message property value was able to be created; otherwise, <c>false</c>.</returns>
        ///
        public static bool TryCreateNetPropertyFromAmqpProperty(
            object? amqpPropertyValue,
            out object? convertedPropertyValue,
            bool allowBodyTypes = false)
        {
            convertedPropertyValue = null;

            if (amqpPropertyValue == null)
            {
                return true;
            }

            // If the property is a simple type, then use it directly.

            switch (GetTypeIdentifier(amqpPropertyValue))
            {
                case AmqpType.Byte:
                case AmqpType.SByte:
                case AmqpType.Int16:
                case AmqpType.Int32:
                case AmqpType.Int64:
                case AmqpType.UInt16:
                case AmqpType.UInt32:
                case AmqpType.UInt64:
                case AmqpType.Single:
                case AmqpType.Double:
                case AmqpType.Boolean:
                case AmqpType.Decimal:
                case AmqpType.Char:
                case AmqpType.Guid:
                case AmqpType.DateTime:
                case AmqpType.String:
                    convertedPropertyValue = amqpPropertyValue;
                    return true;

                case AmqpType.Unknown:
                    // An explicitly unknown type will be considered for additional
                    // scenarios below.
                    break;

                default:
                    return false;
            }

            // Attempt to parse the value against other well-known value scenarios.

            switch (amqpPropertyValue)
            {
                case AmqpSymbol symbol:
                    convertedPropertyValue = symbol.Value;
                    break;

                case IList listOrArray:
                    convertedPropertyValue = listOrArray;
                    break;

                case ArraySegment<byte> segment when segment.Count == segment.Array!.Length:
                    convertedPropertyValue = segment.Array;
                    break;

                case ArraySegment<byte> segment:
                    var buffer = new byte[segment.Count];
                    Buffer.BlockCopy(segment.Array!, segment.Offset, buffer, 0, segment.Count);
                    convertedPropertyValue = buffer;
                    break;

                case DescribedType described when (described.Descriptor is AmqpSymbol):
                    convertedPropertyValue = TranslateSymbol((AmqpSymbol)described.Descriptor, described.Value);
                    break;

                case AmqpMap map when allowBodyTypes:
                {
                    var dict = new Dictionary<string, object>(map.Count);

                    foreach (var pair in map)
                    {
                        dict.Add(pair.Key.ToString(), pair.Value);
                    }

                    convertedPropertyValue = dict;
                    break;
                }

                default:
                    var exception = new SerializationException(string.Format(CultureInfo.CurrentCulture, "Serialization operation failed due to unsupported type {0}.", amqpPropertyValue.GetType().FullName));
                    throw exception;
            }

            return (convertedPropertyValue != null);
        }

        /// <summary>
        ///   Translates the data body segments into the corresponding set of
        ///   <see cref="Data" /> instances.
        /// </summary>
        ///
        /// <param name="dataBody">The data body to translate.</param>
        ///
        /// <returns>The set of <see cref="Data" /> instances that represents the <paramref name="dataBody" />.</returns>
        ///
        private static IEnumerable<Data> TranslateDataBody(IEnumerable<ReadOnlyMemory<byte>> dataBody)
        {
            foreach (var bodySegment in dataBody)
            {
                if (!MemoryMarshal.TryGetArray(bodySegment, out ArraySegment<byte> dataSegment))
                {
                    dataSegment = new ArraySegment<byte>(bodySegment.ToArray());
                }

                yield return new Data
                {
                    Value = dataSegment
                };
            }
        }

        /// <summary>
        ///   Translates the data body elements into the corresponding set of
        ///   <see cref="AmqpSequence" /> instances.
        /// </summary>
        ///
        /// <param name="sequenceBody">The sequence body to translate.</param>
        ///
        /// <returns>The set of <see cref="AmqpSequence" /> instances that represents the <paramref name="sequenceBody" /> in AMQP format.</returns>
        ///
        private static IEnumerable<AmqpSequence> TranslateSequenceBody(IEnumerable<IList<object>> sequenceBody)
        {
            foreach (var item in sequenceBody)
            {
                yield return new AmqpSequence((IList)item);
            }
        }

        /// <summary>
        ///   Translates the data body into the corresponding set of
        ///   <see cref="AmqpValue" /> instance.
        /// </summary>
        ///
        /// <param name="valueBody">The sequence body to translate.</param>
        ///
        /// <returns>The <see cref="AmqpValue" /> instance that represents the <paramref name="valueBody" /> in AMQP format.</returns>
        ///
        private static AmqpValue TranslateValueBody(object valueBody)
        {
            if (TryCreateAmqpPropertyValueFromNetProperty(valueBody, out var amqpValue, allowBodyTypes: true))
            {
                return new AmqpValue { Value = amqpValue };
            }

            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, "{0} is not a supported value body type.", valueBody.GetType().Name));
        }

        /// <summary>
        ///   Attempts to read the data body of an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The <see cref="AmqpMessage" /> to read from.</param>
        /// <param name="dataBody">The value of the data body, if read.</param>
        ///
        /// <returns><c>true</c> if the body was successfully read; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryGetDataBody(AmqpMessage source, out AmqpMessageBody? dataBody)
        {
            if (((source.BodyType & SectionFlag.Data) == 0) || (source.DataBody == null))
            {
                dataBody = null;
                return false;
            }

            dataBody = AmqpMessageBody.FromData(MessageBody.FromDataSegments(source.DataBody));
            return true;
        }

        /// <summary>
        ///   Attempts to read the sequence body of an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The <see cref="AmqpMessage" /> to read from.</param>
        /// <param name="sequenceBody">The value of the sequence body, if read.</param>
        ///
        /// <returns><c>true</c> if the body was successfully read; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryGetSequenceBody(AmqpMessage source, out AmqpMessageBody? sequenceBody)
        {
            if ((source.BodyType & SectionFlag.AmqpSequence) == 0)
            {
                sequenceBody = null;
                return false;
            }

            var bodyContent = new List<IList<object>>();

            foreach (var item in source.SequenceBody)
            {
                bodyContent.Add((IList<object>)item.List);
            }

            sequenceBody = AmqpMessageBody.FromSequence(bodyContent);
            return true;
        }

        /// <summary>
        ///   Attempts to read the sequence body of an <see cref="AmqpMessage" />.
        /// </summary>
        ///
        /// <param name="source">The <see cref="AmqpMessage" /> to read from.</param>
        /// <param name="valueBody">The value body, if read.</param>
        ///
        /// <returns><c>true</c> if the body was successfully read; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryGetValueBody(AmqpMessage source, out AmqpMessageBody? valueBody)
        {
            if (((source.BodyType & SectionFlag.AmqpValue) == 0) || (source.ValueBody?.Value == null))
            {
                valueBody = null;
                return false;
            }

            if (TryCreateNetPropertyFromAmqpProperty(source.ValueBody.Value, out var translatedValue, allowBodyTypes: true))
            {
                valueBody = AmqpMessageBody.FromValue(translatedValue!);
                return true;
            }

            throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, "{0} is not a supported value body type.", source.ValueBody.Value.GetType().Name));
        }

        private static void ThrowSerializationFailed(string propertyName, KeyValuePair<string, object?> pair)
        {
            throw new NotSupportedException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    "The {0} key `{1}` has a value of type `{2}` which is not supported for AMQP transport.",
                    propertyName,
                    pair.Key,
                    pair.Value?.GetType().Name));
        }

        /// <summary>
        ///   Gets the AMQP property type identifier for a given
        ///   value.
        /// </summary>
        ///
        /// <param name="value">The value to determine the type identifier for.</param>
        ///
        /// <returns>The <see cref="Type"/> that was identified for the given <paramref name="value"/>.</returns>
        ///
        private static AmqpType GetTypeIdentifier(object? value) => ToAmqpPropertyType(value?.GetType());

        /// <summary>
        ///   Translates the AMQP symbol into its corresponding typed value, if it belongs to the
        ///   set of known types.
        /// </summary>
        ///
        /// <param name="symbol">The symbol to consider.</param>
        /// <param name="value">The value of the symbol to translate.</param>
        ///
        /// <returns>The typed value of the symbol, if it belongs to the well-known set; otherwise, <c>null</c>.</returns>
        ///
        private static object? TranslateSymbol(AmqpSymbol symbol,
                                              object value)
        {
            if (symbol.Equals(AmqpMessageConstants.Uri))
            {
                return new Uri((string)value);
            }

            if (symbol.Equals(AmqpMessageConstants.TimeSpan))
            {
                return new TimeSpan((long)value);
            }

            if (symbol.Equals(AmqpMessageConstants.DateTimeOffset))
            {
                return new DateTimeOffset((long)value, TimeSpan.Zero);
            }

            return null;
        }

        /// <summary>
        ///   Converts a stream to an <see cref="ArraySegment{T}" /> representation.
        /// </summary>
        ///
        /// <param name="stream">The stream to read and capture in memory.</param>
        ///
        /// <returns>The <see cref="ArraySegment{T}" /> containing the stream data.</returns>
        ///
        private static ArraySegment<byte> ReadStreamToArraySegment(Stream stream)
        {
            switch (stream)
            {
                case { Length: < 1 }:
                    return default;

                case BufferListStream bufferListStream:
                    return bufferListStream.ReadBytes((int)stream.Length);

                case MemoryStream memStreamSource:
                {
                    using var memStreamCopy = new MemoryStream((int)(memStreamSource.Length - memStreamSource.Position));
                    memStreamSource.CopyTo(memStreamCopy, StreamBufferSizeInBytes);
                    if (!memStreamCopy.TryGetBuffer(out ArraySegment<byte> segment))
                    {
                        segment = new ArraySegment<byte>(memStreamCopy.ToArray());
                    }
                    return segment;
                }

                default:
                {
                    using var memStreamCopy = new MemoryStream(StreamBufferSizeInBytes);
                    stream.CopyTo(memStreamCopy, StreamBufferSizeInBytes);
                    if (!memStreamCopy.TryGetBuffer(out ArraySegment<byte> segment))
                    {
                        segment = new ArraySegment<byte>(memStreamCopy.ToArray());
                    }
                    return segment;
                }
            }
        }

        /// <summary>
        ///   Translates the given <see cref="Type" /> to the corresponding
        ///   <see cref="AmqpType" />.
        /// </summary>
        ///
        /// <param name="type">The type to convert to an AMQP type.</param>
        ///
        /// <returns>The AMQP property type that best matches the specified <paramref name="type"/>.</returns>
        ///
        public static AmqpType ToAmqpPropertyType(Type? type)
        {
            if (type == null)
            {
                return AmqpType.Null;
            }

            if (AmqpPropertyTypeMap.TryGetValue(type, out AmqpType amqpType))
            {
                return amqpType;
            }

            return AmqpType.Unknown;
        }

        /// <summary>
        ///   Represents the supported AMQP property types.
        /// </summary>
        ///
        /// <remarks>
        ///   WARNING:
        ///     These values are synchronized between Azure services and the client
        ///     library.  You must consult with the Event Hubs/Service Bus service team before making
        ///     changes, including adding a new member.
        ///
        ///     When adding a new member, remember to always do so before the Unknown
        ///     member.
        /// </remarks>
        ///
        public enum AmqpType
        {
            Null,
            Byte,
            SByte,
            Char,
            Int16,
            UInt16,
            Int32,
            UInt32,
            Int64,
            UInt64,
            Single,
            Double,
            Decimal,
            Boolean,
            Guid,
            String,
            Uri,
            DateTime,
            DateTimeOffset,
            TimeSpan,
            Stream,
            Unknown
        }

        internal static class AmqpMessageConstants
        {
            public const string Vendor = "com.microsoft";
            public const string TimeSpan = Vendor + ":timespan";
            public const string Uri = Vendor + ":uri";
            public const string DateTimeOffset = Vendor + ":datetime-offset";
        }
    }
}
