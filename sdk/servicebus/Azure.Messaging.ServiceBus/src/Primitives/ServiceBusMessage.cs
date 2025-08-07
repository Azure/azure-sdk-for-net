// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Azure.Core;
using Azure.Core.Amqp;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusMessage"/> is used to send data to Service Bus Queues and Topics.
    /// When receiving messages, the <see cref="ServiceBusReceivedMessage"/> is used.
    /// </summary>
    /// <remarks>
    /// The message structure is discussed in detail in the
    /// <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads">product documentation</see>.
    /// </remarks>
    public class ServiceBusMessage
    {
        /// <summary>
        /// Creates a new message.
        /// </summary>
        public ServiceBusMessage() :
            this(default(ReadOnlyMemory<byte>))
        {
        }

        /// <summary>
        /// Creates a new message from the specified string, using UTF-8 encoding.
        /// </summary>
        /// <param name="body">The payload of the message as a string.</param>
        public ServiceBusMessage(string body) :
            this(Encoding.UTF8.GetBytes(body))
        {
        }

        /// <summary>
        /// Creates a new message from the specified payload.
        /// </summary>
        /// <param name="body">The payload of the message in bytes.</param>
        public ServiceBusMessage(ReadOnlyMemory<byte> body)
        {
            AmqpMessageBody amqpBody = new AmqpMessageBody(MessageBody.FromReadOnlyMemorySegment(body));
            AmqpMessage = new AmqpAnnotatedMessage(amqpBody);
        }

        /// <summary>
        /// Creates a new message from the specified <see cref="BinaryData"/> instance.
        /// </summary>
        /// <param name="body">The payload of the message.</param>
        public ServiceBusMessage(BinaryData body) : this(body?.ToMemory() ?? default)
        {
        }

        /// <summary>
        /// Creates a new message from the specified received message by copying the properties.
        /// </summary>
        /// <param name="receivedMessage">The received message to copy the data from.</param>
        public ServiceBusMessage(ServiceBusReceivedMessage receivedMessage)
        {
            Argument.AssertNotNull(receivedMessage, nameof(receivedMessage));

            AmqpMessageBody body;
            if (receivedMessage.AmqpMessage.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> dataBody))
            {
                body = AmqpMessageBody.FromData(MessageBody.FromReadOnlyMemorySegments(dataBody));
            }
            else if (receivedMessage.AmqpMessage.Body.TryGetValue(out object valueBody))
            {
                body = AmqpMessageBody.FromValue(valueBody);
            }
            else if (receivedMessage.AmqpMessage.Body.TryGetSequence(out IEnumerable<IList<object>> sequenceBody))
            {
                body = AmqpMessageBody.FromSequence(sequenceBody);
            }
            else
            {
                throw new NotSupportedException($"{receivedMessage.AmqpMessage.Body.BodyType} is not a supported message body type.");
            }

            AmqpMessage = new AmqpAnnotatedMessage(body);

            // copy properties
            AmqpMessageProperties properties = AmqpMessage.Properties;
            AmqpMessageProperties receivedProperties = receivedMessage.AmqpMessage.Properties;
            properties.MessageId = receivedProperties.MessageId;
            properties.UserId = receivedProperties.UserId;
            properties.To = receivedProperties.To;
            properties.Subject = receivedProperties.Subject;
            properties.ReplyTo = receivedProperties.ReplyTo;
            properties.CorrelationId = receivedProperties.CorrelationId;
            properties.ContentType = receivedProperties.ContentType;
            properties.ContentEncoding = receivedProperties.ContentEncoding;
            properties.AbsoluteExpiryTime = receivedProperties.AbsoluteExpiryTime;
            properties.CreationTime = receivedProperties.CreationTime;
            properties.GroupId = receivedProperties.GroupId;
            properties.GroupSequence = receivedProperties.GroupSequence;
            properties.ReplyToGroupId = receivedProperties.ReplyToGroupId;

            // copy header except for delivery count which should be set to null
            AmqpMessageHeader header = AmqpMessage.Header;
            AmqpMessageHeader receivedHeader = receivedMessage.AmqpMessage.Header;
            header.DeliveryCount = null;
            header.Durable = receivedHeader.Durable;
            header.Priority = receivedHeader.Priority;
            header.TimeToLive = receivedHeader.TimeToLive;
            header.FirstAcquirer = receivedHeader.FirstAcquirer;

            // copy message annotations except for broker set ones
            foreach (KeyValuePair<string, object> kvp in receivedMessage.AmqpMessage.MessageAnnotations)
            {
                if (kvp.Key == AmqpMessageConstants.LockedUntilName ||
                    kvp.Key == AmqpMessageConstants.SequenceNumberName ||
                    kvp.Key == AmqpMessageConstants.DeadLetterSourceName ||
                    kvp.Key == AmqpMessageConstants.EnqueueSequenceNumberName ||
                    kvp.Key == AmqpMessageConstants.EnqueuedTimeUtcName ||
                    kvp.Key == AmqpMessageConstants.ScheduledEnqueueTimeUtcName ||
                    kvp.Key == AmqpMessageConstants.MessageStateName ||
                    kvp.Key == AmqpMessageConstants.PartitionIdName)
                {
                    continue;
                }
                AmqpMessage.MessageAnnotations.Add(kvp.Key, kvp.Value);
            }

            // delivery annotations should not be copied as they only apply to a single hop

            // copy footer
            foreach (KeyValuePair<string, object> kvp in receivedMessage.AmqpMessage.Footer)
            {
                AmqpMessage.Footer.Add(kvp.Key, kvp.Value);
            }

            // copy application properties except for broker set ones
            foreach (KeyValuePair<string, object> kvp in receivedMessage.AmqpMessage.ApplicationProperties)
            {
                if (kvp.Key == AmqpMessageConstants.DeadLetterReasonHeader
                    || kvp.Key == AmqpMessageConstants.DeadLetterErrorDescriptionHeader
                    || kvp.Key == MessagingClientDiagnostics.DiagnosticIdAttribute)
                {
                    continue;
                }
                AmqpMessage.ApplicationProperties.Add(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Creates a new message from the specified <see cref="AmqpAnnotatedMessage"/> instance.
        /// </summary>
        /// <param name="message">The AMQP message.</param>
        public ServiceBusMessage(AmqpAnnotatedMessage message)
        {
            AmqpMessage = message;
        }

        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        public BinaryData Body
        {
            get => AmqpMessage.GetBody();
            set
            {
                AmqpMessage.Body = new AmqpMessageBody(MessageBody.FromReadOnlyMemorySegment(value));
            }
        }

        /// <summary>
        /// Gets or sets the MessageId to identify the message.
        /// </summary>
        /// <remarks>
        /// The message identifier is an application-defined value that uniquely identifies the
        /// message and its payload. The identifier is a free-form string and can reflect a GUID
        /// or an identifier derived from the application context. If enabled, the
        /// <see href="https://learn.microsoft.com/azure/service-bus-messaging/duplicate-detection">duplicate detection</see>
        /// feature identifies and removes second and further submissions of messages with the
        /// same MessageId.
        /// </remarks>
        public string MessageId
        {
            get => AmqpMessage.Properties.MessageId?.ToString();

            set
            {
                Argument.AssertNotNullOrEmpty(value, nameof(value));
                Argument.AssertNotTooLong(value, Constants.MaxMessageIdLength, nameof(value));
                AmqpMessage.Properties.MessageId = new AmqpMessageId(value);
            }
        }

        /// <summary>Gets or sets a partition key for sending a message to a partitioned entity.</summary>
        /// <value>The partition key. Maximum length is 128 characters.</value>
        /// <remarks>
        /// For <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-partitioning">partitioned entities</see>,
        /// setting this value enables assigning related messages to the same internal partition, so that submission sequence
        /// order is correctly recorded. The partition is chosen by a hash function over this value and cannot be chosen
        /// directly. For session-aware entities, the <see cref="SessionId"/> property overrides this value.
        /// </remarks>
        public string PartitionKey
        {
            get
            {
                return AmqpMessage.GetPartitionKey();
            }
            set
            {
                Argument.AssertNotTooLong(value, Constants.MaxPartitionKeyLength, nameof(value));
                if (SessionId != null && SessionId != value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"PartitionKey:{value} cannot be set to a different value than SessionId:{SessionId}.");
                }
                AmqpMessage.MessageAnnotations[AmqpMessageConstants.PartitionKeyName] = value;
            }
        }

        /// <summary>Gets or sets a partition key for sending a message into an entity via a partitioned transfer queue.</summary>
        /// <value>The partition key. Maximum length is 128 characters. </value>
        /// <remarks>
        /// If a message is sent via a transfer queue in the scope of a transaction, this value selects the
        /// transfer queue partition: This is functionally equivalent to <see cref="PartitionKey"/> and ensures that
        /// messages are kept together and in order as they are transferred.
        /// See <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-transactions#transfers-and-send-via">Transfers and Send Via</see>.
        /// </remarks>
        public string TransactionPartitionKey
        {
            get
            {
                return AmqpMessage.GetViaPartitionKey();
            }
            set
            {
                Argument.AssertNotTooLong(value, Constants.MaxPartitionKeyLength, nameof(value));
                AmqpMessage.MessageAnnotations[AmqpMessageConstants.ViaPartitionKeyName] = value;
            }
        }

        /// <summary>Gets or sets the session identifier for a session-aware entity.</summary>
        /// <value>The session identifier. Maximum length is 128 characters.</value>
        /// <remarks>
        /// For session-aware entities, this application-defined value specifies the session
        /// affiliation of the message. Messages with the same session identifier are subject
        /// to summary locking and enable exact in-order processing and demultiplexing.
        /// For session-unaware entities, this value is ignored.
        /// See <see href="https://learn.microsoft.com/azure/service-bus-messaging/message-sessions">Message Sessions</see>.
        /// </remarks>
        public string SessionId
        {
            get => AmqpMessage.Properties.GroupId;

            set
            {
                Argument.AssertNotTooLong(value, Constants.MaxSessionIdLength, nameof(value));
                AmqpMessage.Properties.GroupId = value;

                // If the PartitionKey was already set to a different value, override it with the SessionId, as the SessionId takes precedence.
                if (PartitionKey != null && PartitionKey != value)
                {
                    ServiceBusEventSource.Log.PartitionKeyOverwritten(PartitionKey, value, MessageId);
                    PartitionKey = value;
                }
            }
        }

        /// <summary>Gets or sets a session identifier augmenting the <see cref="ReplyTo"/> address.</summary>
        /// <value>Session identifier. Maximum length is 128 characters.</value>
        /// <remarks>
        /// This value augments the ReplyTo information and specifies which SessionId should be set
        /// for the reply when sent to the reply entity.
        /// See <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</see>
        /// </remarks>
        public string ReplyToSessionId
        {
            get => AmqpMessage.Properties.ReplyToGroupId;

            set
            {
                Argument.AssertNotTooLong(value, Constants.MaxSessionIdLength, nameof(value));
                AmqpMessage.Properties.ReplyToGroupId = value;
            }
        }

        /// <summary>
        /// Gets or sets the message’s "time to live" value.
        /// </summary>
        /// <value>The message’s time to live value.</value>
        /// <remarks>
        /// This value is the relative duration after which the message expires.
        /// When not set explicitly, the assumed value is the DefaultTimeToLive for the respective queue or topic.
        /// A message-level <see cref="TimeToLive"/> value cannot be longer than the entity's DefaultTimeToLive
        /// setting and it is silently adjusted if it does.
        /// See <see href="https://learn.microsoft.com/azure/service-bus-messaging/message-expiration">Expiration</see>.
        /// </remarks>
        public TimeSpan TimeToLive
        {
            get
            {
                return AmqpMessage.GetTimeToLive();
            }
            set
            {
                Argument.AssertPositive(value, nameof(value));
                AmqpMessage.Header.TimeToLive = value;
            }
        }

        /// <summary>Gets or sets the correlation identifier.</summary>
        /// <value>Correlation identifier.</value>
        /// <remarks>
        /// Allows an application to specify a context for the message for the purposes of correlation,
        /// for example reflecting the MessageId of a message that is being replied to.
        /// See <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</see>.
        /// </remarks>
        public string CorrelationId
        {
            get => AmqpMessage.Properties.CorrelationId?.ToString();
            set
            {
                AmqpMessage.Properties.CorrelationId = value == null ? null : new AmqpMessageId(value);
            }
        }

        /// <summary>Gets or sets an application specific subject.</summary>
        /// <value>The application specific subject.</value>
        /// <remarks>
        /// This property enables the application to indicate the purpose of the message to the receiver in a standardized
        /// fashion, similar to an email subject line. The mapped AMQP property is "subject".
        /// </remarks>
        public string Subject
        {
            get
            {
                return AmqpMessage.Properties.Subject;
            }
            set
            {
                AmqpMessage.Properties.Subject = value;
            }
        }

        /// <summary>Gets or sets the "to" address.</summary>
        /// <value>The "to" address.</value>
        /// <remarks>
        /// This property is reserved for future use in routing scenarios and presently ignored by the broker itself.
        /// Applications can use this value in rule-driven
        /// <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-auto-forwarding">auto-forward chaining</see> scenarios to indicate the
        /// intended logical destination of the message.
        /// </remarks>
        public string To
        {
            get => AmqpMessage.Properties.To?.ToString();
            set
            {
                AmqpMessage.Properties.To = value == null ? null : new AmqpAddress(value);
            }
        }

        /// <summary>Gets or sets the content type descriptor.</summary>
        /// <value>RFC2045 Content-Type descriptor.</value>
        /// <remarks>
        /// Optionally describes the payload of the message, with a descriptor following the format of
        /// RFC2045, Section 5, for example "application/json".
        /// </remarks>
        public string ContentType
        {
            get
            {
                return AmqpMessage.Properties.ContentType;
            }
            set
            {
                AmqpMessage.Properties.ContentType = value;
            }
        }

        /// <summary>Gets or sets the address of an entity to send replies to.</summary>
        /// <value>The reply entity address.</value>
        /// <remarks>
        /// This optional and application-defined value is a standard way to express a reply path
        /// to the receiver of the message. When a sender expects a reply, it sets the value to the
        /// absolute or relative path of the queue or topic it expects the reply to be sent to.
        /// See <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-messages-payloads?#message-routing-and-correlation">Message Routing and Correlation</see>.
        /// </remarks>
        public string ReplyTo
        {
            get => AmqpMessage.Properties.ReplyTo?.ToString();
            set
            {
                AmqpMessage.Properties.ReplyTo = value == null ? null : new AmqpAddress(value);
            }
        }

        /// <summary>
        /// Gets or sets the date and time, in UTC, at which the message should be made available to receivers. This property does not control when a message is sent by the
        /// client. Sending happens immediately when `SendAsync` is called.  Service Bus will hide the message from receivers until the the requested time.
        /// </summary>
        /// <value>
        /// The date and time, in UTC, at which the message should be available to receivers. This time may not be exact; the actual time depends on the entity's workload and state.
        /// </value>
        /// <seealso href="https://learn.microsoft.com/azure/service-bus-messaging/message-sequencing#scheduled-messages">Scheduled messages</seealso>
        public DateTimeOffset ScheduledEnqueueTime
        {
            get
            {
                return AmqpMessage.GetScheduledEnqueueTime();
            }
            set
            {
                AmqpMessage.MessageAnnotations[AmqpMessageConstants.ScheduledEnqueueTimeUtcName] = value.UtcDateTime;
            }
        }

        /// <summary>
        /// Gets the raw Amqp message data that will be transmitted over the wire.
        /// This can be used to enable scenarios that require setting AMQP header, footer, property, or annotation
        /// data that is not exposed as top level properties in the <see cref="ServiceBusMessage"/>.
        /// </summary>
        internal AmqpAnnotatedMessage AmqpMessage { get; set; }

        /// <summary>
        /// Gets the raw AMQP message data that will be transmitted over the wire.
        /// This can be used to enable scenarios that require setting AMQP header, footer, property, or annotation
        /// data that is not exposed as top level properties in the <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <returns>The raw Amqp message.</returns>
        public AmqpAnnotatedMessage GetRawAmqpMessage() => AmqpMessage;

        /// <summary>
        /// Gets the application properties bag, which can be used for custom message metadata.
        /// </summary>
        /// <remarks>
        ///   <list type="bullet">
        ///     <listheader><description>The following types are supported:</description></listheader>
        ///     <item><description>string</description></item>
        ///     <item><description>bool</description></item>
        ///     <item><description>byte</description></item>
        ///     <item><description>sbyte</description></item>
        ///     <item><description>short</description></item>
        ///     <item><description>ushort</description></item>
        ///     <item><description>int</description></item>
        ///     <item><description>uint</description></item>
        ///     <item><description>long</description></item>
        ///     <item><description>ulong</description></item>
        ///     <item><description>float</description></item>
        ///     <item><description>decimal</description></item>
        ///     <item><description>double</description></item>
        ///     <item><description>char</description></item>
        ///     <item><description>Guid</description></item>
        ///     <item><description>DateTime</description></item>
        ///     <item><description>DateTimeOffset</description></item>
        ///     <item><description>Stream</description></item>
        ///     <item><description>Uri</description></item>
        ///     <item><description>TimeSpan</description></item>
        ///   </list>
        /// </remarks>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        ///   Occurs when the <see cref="ServiceBusMessage" /> is serialized for transport when an unsupported type is used as a property.
        /// </exception>
        /// <exception cref="ServiceBusException">
        ///   <para>Occurs when the <see cref="ServiceBusMessage" /> is serialized for transport when a value of type <see cref="T:byte[]"/> or
        ///   <see cref="T:ArraySegment{byte}"/> is used as a property.  The <see cref="ServiceBusException.Reason" /> will be set to
        ///   <see cref="ServiceBusFailureReason.MessageSizeExceeded"/> in this case.</para>
        ///
        ///   <para>This is due to a known bug in the Service Bus service, where an application property encoded as binary cannot be
        ///   handled by the service and is incorrectly rejected for being too large.  A fix is planned, but the time line is
        ///   currently unknown.  The recommended workaround is to encode the binary data as a Base64 string.</para>
        /// </exception>
        public IDictionary<string, object> ApplicationProperties
        {
            get
            {
                return AmqpMessage.ApplicationProperties;
            }
        }

        /// <summary>Returns a string that represents the current message.</summary>
        /// <returns>The string representation of the current message.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{MessageId:{0}}}", MessageId);
        }
    }
}
