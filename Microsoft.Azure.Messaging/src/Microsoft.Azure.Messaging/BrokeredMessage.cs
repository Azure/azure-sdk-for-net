// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.Messaging.Primitives;

namespace Microsoft.Azure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Threading;
    using Microsoft.Azure.Messaging.Amqp;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>Represents the unit of communication between AppFabric ServiceBus clients.</summary>
    [XmlRoot("BrokeredMessage", Namespace = Constants.Namespace)]
    public sealed class BrokeredMessage : IXmlSerializable, IDisposable
    {
        internal const string MessageIdHeaderName = "MessageId";
        internal const string CorrelationIdHeaderName = "CorrelationId";
        internal const string ToHeaderName = "To";
        internal const string ReplyToHeaderName = "ReplyTo";
        internal const string SessionIdHeaderName = "SessionId";
        internal const string LabelHeaderName = "Label";
        internal const string ContentTypeHeaderName = "ContentType";
        internal const string ReplyToSessionIdHeaderName = "ReplyToSessionId";
        internal const string TimeToLiveHeaderName = "TimeToLive";
        internal const string ScheduledEnqueueTimeUtcHeaderName = "ScheduledEnqueueTimeUtc";
        internal const string PartitionKeyHeaderName = "PartitionKey";
        internal const string EnqueuedTimeUtcHeaderName = "EnqueuedTimeUtc";
        internal const string SequenceNumberHeaderName = "SequenceNumber";
        internal const string LockTokenHeaderName = "LockToken";
        internal const string LockedUntilUtcHeaderName = "LockedUntilUtc";
        internal const string DeliveryCountHeaderName = "DeliveryCount";
        internal const string EnqueuedSequenceNumberHeaderName = "EnqueuedSequenceNumber";
        internal const string ViaPartitionKeyHeaderName = "ViaPartitionKey";
        internal const string DestinationHeaderName = "Destination";
        internal const string ForcePersistenceHeaderName = "ForcePersistence";
        internal const string PublisherHeaderName = "Publisher";
        internal const int MinMessageBufferSize = 1024;

        static BrokeredMessageMode mode = BrokeredMessageMode.Client;
        static BinarySerializationItem[] binarySerializationItems = BuildBinarySerializationItems(mode);
        static readonly Dictionary<string, Func<BrokeredMessage, object>> SystemPropertyAccessorDictionary =
            new Dictionary<string, Func<BrokeredMessage, object>>(StringComparer.OrdinalIgnoreCase)
            {
                { MessageIdHeaderName, message => message.MessageId },
                { CorrelationIdHeaderName, message => message.CorrelationId },
                { ToHeaderName, message => message.To },
                { ReplyToHeaderName, message => message.ReplyTo },
                { SessionIdHeaderName, message => message.SessionId },
                { LabelHeaderName, message => message.Label },
                { ContentTypeHeaderName, message => message.ContentType },
                { ReplyToSessionIdHeaderName, message => message.ReplyToSessionId },
                { TimeToLiveHeaderName, message => message.TimeToLive },
                { ScheduledEnqueueTimeUtcHeaderName, message => message.ScheduledEnqueueTimeUtc },
                { PartitionKeyHeaderName, message => message.PartitionKey },
                { EnqueuedTimeUtcHeaderName, message => message.EnqueuedTimeUtc },
                { SequenceNumberHeaderName, message => message.SequenceNumber },
                { LockTokenHeaderName, message => message.LockToken },
                { LockedUntilUtcHeaderName, message => message.LockedUntilUtc },
                { DeliveryCountHeaderName, message => message.DeliveryCount },
                { EnqueuedSequenceNumberHeaderName, message => message.EnqueuedSequenceNumber },
                { ViaPartitionKeyHeaderName, message => message.ViaPartitionKey },
                { DestinationHeaderName, message => message.Destination },
                { ForcePersistenceHeaderName, message => message.ForcePersistence },
                { PublisherHeaderName, message => message.Publisher }
            };

        static BinarySerializationItem CreateBinarySerializationItem<TProp>(FieldId fieldId, MessageMembers messageMember, PropertyValueType propertyValueType,
            Func<BrokeredMessage, TProp> propertyAccessor, Func<TProp, int> calculateSizeFunc)
        {
            return new BinarySerializationItem()
            {
                FieldId = fieldId,
                ShouldSerialize = (msg, serializationTarget) => (msg.initializedMembers & messageMember) != 0,
                Extractor = (messageArg, serializationTarget) => SerializationUtilities.ConvertNativeValueToByteArray(messageArg.version, propertyValueType, propertyAccessor(messageArg)),
                CalculateSize = (messageArg) => calculateSizeFunc(propertyAccessor(messageArg))
            };
        }

        static BinarySerializationItem[] BuildBinarySerializationItems(BrokeredMessageMode type)
        {
            BinarySerializationItem[] serializationItems = new BinarySerializationItem[]
            {
                CreateBinarySerializationItem<string>(FieldId.MessageId, MessageMembers.MessageId, PropertyValueType.String, msg => msg.MessageId, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.CorrelationId, MessageMembers.CorrelationId, PropertyValueType.String, msg => msg.CorrelationId, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.SessionId, MessageMembers.SessionId, PropertyValueType.String, msg => msg.SessionId, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<TimeSpan>(FieldId.TimeToLive, MessageMembers.TimeToLive, PropertyValueType.TimeSpan, msg => msg.TimeToLive, SerializationUtilities.GetTimeSpanSize),
                CreateBinarySerializationItem<string>(FieldId.ReplyTo, MessageMembers.ReplyTo, PropertyValueType.String, msg => msg.ReplyTo, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.To, MessageMembers.To, PropertyValueType.String, msg => msg.To, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.ReplyToSessionId, MessageMembers.ReplyToSessionId, PropertyValueType.String, msg => msg.ReplyToSessionId, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<DateTime>(FieldId.EnqueuedTimeUtc, MessageMembers.EnqueuedTimeUtc, PropertyValueType.DateTime, msg => msg.EnqueuedTimeUtc, SerializationUtilities.GetDateTimeSize),
                CreateBinarySerializationItem<DateTime>(FieldId.ScheduledEnqueueTimeUtc, MessageMembers.ScheduledEnqueueTimeUtc, PropertyValueType.DateTime, msg => msg.ScheduledEnqueueTimeUtc, SerializationUtilities.GetDateTimeSize),
                    type == BrokeredMessageMode.Broker ?
                        new BinarySerializationItem
                        {
                            FieldId = FieldId.SequenceNumber,
                            ShouldSerialize = (msg, serializationTarget) => (msg.initializedMembers & MessageMembers.SequenceNumber) != 0,
                            Extractor = (messageArg, serializationTarget) =>
                            {
                                long sequenceNumber = messageArg.SequenceNumber;
                                if (serializationTarget == SerializationTarget.Communication && messageArg.HasHeader(MessageMembers.PartitionId))
                                {
                                    sequenceNumber = (((long)messageArg.PartitionId) << 48) + messageArg.SequenceNumber;
                                }

                                return SerializationUtilities.ConvertNativeValueToByteArray(messageArg.version, PropertyValueType.Int64, sequenceNumber);
                            },
                            CalculateSize = (messageArg) => SerializationUtilities.GetLongSize(messageArg.SequenceNumber)
                        }
                    : // else
                        CreateBinarySerializationItem<long>(FieldId.SequenceNumber, MessageMembers.SequenceNumber, PropertyValueType.Int64, msg => msg.SequenceNumber, SerializationUtilities.GetLongSize)
                ,
                CreateBinarySerializationItem<Guid>(FieldId.LockToken, MessageMembers.LockToken, PropertyValueType.Guid, msg => msg.LockToken, SerializationUtilities.GetGuidSize),
                CreateBinarySerializationItem<DateTime>(FieldId.LockedUntilUtc, MessageMembers.LockedUntilUtc, PropertyValueType.DateTime, msg => msg.LockedUntilUtc, SerializationUtilities.GetDateTimeSize),
                CreateBinarySerializationItem<int>(FieldId.DeliveryCount, MessageMembers.DeliveryCount, PropertyValueType.Int32, msg => msg.DeliveryCount, SerializationUtilities.GetIntSize),
                CreateBinarySerializationItem<string>(FieldId.PartitionKey, MessageMembers.PartitionKey, PropertyValueType.String, msg => msg.PartitionKey, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.Label, MessageMembers.Label, PropertyValueType.String, msg => msg.Label, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.ContentType, MessageMembers.ContentType, PropertyValueType.String, msg => msg.ContentType, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<Stream>(FieldId.PrefilteredMessageHeaders, MessageMembers.PrefilteredHeaders, PropertyValueType.Stream, msg => msg.PrefilteredHeaders, SerializationUtilities.GetStreamSize),
                CreateBinarySerializationItem<Stream>(FieldId.PrefilteredMessageProperties, MessageMembers.PrefilteredProperties, PropertyValueType.Stream, msg => msg.PrefilteredProperties, SerializationUtilities.GetStreamSize),
                CreateBinarySerializationItem<string>(FieldId.TransferDestination, MessageMembers.TransferDestination, PropertyValueType.String, msg => msg.TransferDestination, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<long>(FieldId.TransferDestinationResourceId, MessageMembers.TransferDestinationEntityId, PropertyValueType.Int64, msg => msg.TransferDestinationResourceId, SerializationUtilities.GetLongSize),
                CreateBinarySerializationItem<short>(FieldId.PartitionId, MessageMembers.PartitionId, PropertyValueType.Int16, msg => msg.PartitionId, SerializationUtilities.GetShortSize),
                CreateBinarySerializationItem<string>(FieldId.TransferSessionId, MessageMembers.TransferSessionId, PropertyValueType.String, msg => msg.TransferSessionId, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.TransferSource, MessageMembers.TransferSource, PropertyValueType.String, msg => msg.TransferSource, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<long>(FieldId.TransferSequenceNumber, MessageMembers.TransferSequenceNumber, PropertyValueType.Int64, msg => msg.TransferSequenceNumber, SerializationUtilities.GetLongSize),
                CreateBinarySerializationItem<int>(FieldId.TransferHopCount, MessageMembers.TransferHopCount, PropertyValueType.Int32, msg => msg.TransferHopCount, SerializationUtilities.GetIntSize),
                CreateBinarySerializationItem<int>(FieldId.MessageState, MessageMembers.MessageState, PropertyValueType.Int32, msg => (int)msg.State, SerializationUtilities.GetIntSize),
                CreateBinarySerializationItem<long>(FieldId.EnqueuedSequenceNumber, MessageMembers.EnqueuedSequenceNumber, PropertyValueType.Int64, msg => msg.EnqueuedSequenceNumber, SerializationUtilities.GetLongSize),
                CreateBinarySerializationItem<string>(FieldId.ViaPartitionKey, MessageMembers.ViaPartitionKey, PropertyValueType.String, msg => msg.ViaPartitionKey, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.Destination, MessageMembers.Destination, PropertyValueType.String, msg => msg.Destination, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<bool>(FieldId.ForcePersistence, MessageMembers.ForcePersistence, PropertyValueType.Boolean, msg => msg.ForcePersistence, SerializationUtilities.GetBooleanSize),
                CreateBinarySerializationItem<string>(FieldId.Publisher, MessageMembers.Publisher, PropertyValueType.String, msg => msg.Publisher, SerializationUtilities.GetStringSize),
                CreateBinarySerializationItem<string>(FieldId.DeadLetterSource, MessageMembers.DeadLetterSource, PropertyValueType.String, msg => msg.DeadLetterSource, SerializationUtilities.GetStringSize),
            };

            return serializationItems;
        }

        readonly int headerStreamInitialSize = 512; // 0.5K
        readonly static int headerStreamMaxSize = 65536; // 64K        
        readonly static int deadLetterheaderStreamMaxSize = headerStreamMaxSize + 2048; // 66K

        /// <summary> The message flags </summary>
        static byte[] messageFlags = new byte[] { 0x00, 0x00 };

        /// <summary> The message version </summary>
        internal static readonly int MessageVersion1 = 1;
        internal static readonly int MessageVersion2 = 2;
        internal static readonly int MessageVersion3 = 3;
        internal static readonly int MessageVersion4 = 4;
        internal static readonly int MessageVersion5 = 5;
        internal static readonly int MessageVersion6 = 6;
        internal static readonly int MessageVersion7 = 7;
        internal static readonly int MessageVersion8 = 8;
        internal static readonly int MessageVersion9 = 9;
        internal static readonly int MessageVersion10 = 10;
        internal static readonly int MessageVersion11 = 11;
        internal static int MessageVersion = MessageVersion11; // non-readonly for testing purposes
        const MessageMembers V1MessageMembers =
            MessageMembers.MessageId |
            MessageMembers.CorrelationId |
            MessageMembers.To |
            MessageMembers.ReplyTo |
            MessageMembers.TimeToLive |
            MessageMembers.SessionId |
            MessageMembers.Label |
            MessageMembers.ContentType |
            MessageMembers.ScheduledEnqueueTimeUtc |
            MessageMembers.PartitionKey |
            MessageMembers.ReplyToSessionId |
            MessageMembers.EnqueuedTimeUtc |
            MessageMembers.SequenceNumber |
            MessageMembers.LockToken |
            MessageMembers.LockedUntilUtc |
            MessageMembers.DeliveryCount;

        // These are used for null header optimization (subscription)
        bool supportsEmptySerializedHeader;
        int? originalDeliveryCount;
        const MessageMembers RegularTopicHeaders = MessageMembers.MessageId |
            MessageMembers.EnqueuedTimeUtc |
            MessageMembers.SequenceNumber |
            MessageMembers.DeliveryCount |
            MessageMembers.EnqueuedSequenceNumber;

        const MessageMembers RegularTopicHeadersInFileStore = MessageMembers.MessageId |
            MessageMembers.EnqueuedTimeUtc |
            MessageMembers.SequenceNumber |
            MessageMembers.DeliveryCount |
            MessageMembers.EnqueuedSequenceNumber |
            MessageMembers.MessageState;

        int version;
        Stream bodyStream;
        string correlationId;
        string sessionId;
        string publisher;
        string deadLetterSource;
        MessageState state;
        string replyToSessionId;
        bool disposed;
        bool headersDeserialized;
        object headerSerializationSyncObject = new object();
        BufferedInputStream headerStream;
        Stream rawHeaderStream;
        Stream prefilteredHeaders;
        Stream prefilteredProperties;

        MessageMembers initializedMembers;

        string messageId;
        //TODO: ReceiveContext receiveContext;
        long bodyId;
        short partitionId;
        string transferSource;
        string transferSessionId;
        string transferDestination;
        long transferDestinationResourceId;
        long transferSequenceNumber;
        int transferHopCount;

        IDictionary<string, object> properties;
        ReceiverHeaders receiverHeaders;
        string replyTo;
        string to;
        DateTime enqueuedTimeUtc;
        DateTime scheduledEnqueueTimeUtc = DateTime.MinValue;
        TimeSpan timeToLive;
        string partitionKey;
        string viaPartitionKey;
        string destination;
        string label;
        string contentType;
        bool isBodyLoaded = true;
        bool ownsBodyStream;
        bool ownsRawHeaderStream;
        object bodyObject;
        bool bodyObjectDecoded;
        long headerSize;
        long bodySize;
        int getBodyCalled;
        int messageConsumed;
        bool forcePersistence;

        bool isFromCache;
        long persistedMessageSize;

        BrokeredMessageFormat messageFormat;
        IBrokeredMessageEncoder messageEncoder;
        volatile List<IDisposable> attachedDisposables;
        object disposablesSyncObject = new object();

        bool arePropertiesModifiedByBroker;

        /// <summary>Initializes a new instance of the <see cref="BrokeredMessage" /> class.</summary>
        public BrokeredMessage() :
            this(BrokeredMessage.NewMessageId())
        {
        }

        /// <summary>Initializes a new instance of the 
        /// <see cref="BrokeredMessage" /> class from a given object by using DataContractSerializer with a binary XmlDictionaryWriter.</summary> 
        ///<param name="serializableObject">The serializable object.</param>
        /// TODO: 
        public BrokeredMessage(object serializableObject)
            : this(serializableObject, serializableObject == null ? null : new DataContractBinarySerializer(GetObjectType(serializableObject)))
        {
            this.bodyObject = serializableObject;
        }

        /// <summary> Constructor that creates a BrokeredMessage from a given object using the provided XmlObjectSerializer </summary>
        /// <remarks> You should be aware of the exceptions that their provided Serializer can throw and take appropriate
        /// actions. Please refer to <see href="http://msdn.microsoft.com/en-us/library/ms574055.aspx"/> for 
        /// a possible list of exceptions and their cause. </remarks>
        /// <param name="serializableObject"> The serializable object. </param>
        /// <param name="serializer">         The serializer object. </param>
        /// <exception cref="ArgumentNullException">Thrown when null serializer is passed to the method 
        /// TODO: 
        /// with a non-null serializableObject</exception>
        public BrokeredMessage(object serializableObject, XmlObjectSerializer serializer)
            : this(BrokeredMessage.NewMessageId())
        {
            if (serializableObject != null)
            {
                if (serializer == null)
                {
                    //throw FxTrace.Exception.AsError(new ArgumentNullException("serializer"));
                    throw new ArgumentNullException("serializer");
                }

                MemoryStream stream = new MemoryStream(256);
                serializer.WriteObject(stream, serializableObject);
                stream.Flush();
                stream.Position = 0;
                this.BodyStream = stream;
                this.ownsBodyStream = true;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="BrokeredMessage" /> class.</summary>
        /// <param name="messageBodyStream">The message body stream.</param>
        public BrokeredMessage(Stream messageBodyStream)
            : this(messageBodyStream, false)
        {
        }

        /// <summary>Initializes a new instance of the 
        /// <see cref="BrokeredMessage" /> class using the supplied stream as its body.</summary> 
        /// <param name="messageBodyStream">The message body stream.</param>
        /// <param name="ownsStream">true to indicate that the stream will be closed when the message is 
        /// closed; false to indicate that the stream will not be closed when the message is closed.</param> 
        public BrokeredMessage(Stream messageBodyStream, bool ownsStream)
            : this(BrokeredMessage.NewMessageId())
        {
            this.ownsBodyStream = ownsStream;
            this.BodyStream = messageBodyStream;
        }

        internal BrokeredMessage(Stream rawHeaderStream, bool ownsRawHeaderStream, Stream messageBodyStream, bool ownsStream, BrokeredMessageFormat format)
            : this(BrokeredMessage.NewMessageId())
        {
            this.rawHeaderStream = rawHeaderStream;
            this.ownsRawHeaderStream = ownsRawHeaderStream;
            this.ownsBodyStream = ownsStream;
            this.BodyStream = messageBodyStream;
            this.messageFormat = format;
            this.messageEncoder = BrokeredMessageEncoder.GetEncoder(this.messageFormat);
        }

        /// <summary> Creates the message. </summary>
        /// <param name="headerStream"> The header stream. </param>
        /// <param name="bodyStream">   The body stream. </param>
        /// <returns> . </returns>
        internal BrokeredMessage(BufferedInputStream headerStream, Stream bodyStream)
        {
            Fx.Assert(headerStream != null, "headerStream is not expected to be null.");
            this.headerStream = headerStream;
            this.BodyStream = bodyStream;
            this.isBodyLoaded = true;
            this.ownsBodyStream = true;
            this.InternalBrokeredMessageState = BrokeredMessageState.Active;
            this.isFromCache = false;
            if (this.headerStream.CanSeek)
            {
                this.headerSize = this.headerStream.Length;
            }
        }

        internal BrokeredMessage(object bodyObject, Stream bodyStream)
            : this()
        {
            this.bodyObject = bodyObject;
            this.bodyObjectDecoded = true;
            this.bodyStream = bodyStream;
            this.ownsBodyStream = true;
        }

        BrokeredMessage(string messageId)
        {
            BrokeredMessage.ValidateMessageId(messageId);
            this.MessageId = messageId;
            this.headersDeserialized = true;
            this.InternalBrokeredMessageState = BrokeredMessageState.Active;
            this.isFromCache = false;
            this.version = BrokeredMessage.MessageVersion;
        }

        BrokeredMessage(BrokeredMessage originalMessage, bool clientSideCloning)
        {
            this.version = originalMessage.version;
            this.messageFormat = originalMessage.messageFormat;
            this.messageEncoder = originalMessage.messageEncoder;
            this.arePropertiesModifiedByBroker = originalMessage.arePropertiesModifiedByBroker;
            this.CopyMessageHeaders(originalMessage, clientSideCloning);

            if (originalMessage.rawHeaderStream != null)
            {
                this.rawHeaderStream = BrokeredMessage.CloneStream(originalMessage.rawHeaderStream, clientSideCloning);
                this.ownsRawHeaderStream = true;
            }

            this.bodyObject = originalMessage.bodyObject;
            this.bodyObjectDecoded = originalMessage.bodyObjectDecoded;
            Stream originalStream = originalMessage.BodyStream;
            if (originalStream != null)
            {
                this.BodyStream = BrokeredMessage.CloneStream(originalMessage.BodyStream, clientSideCloning);
                this.ownsBodyStream = true;
            }

            this.AttachDisposables(BrokeredMessage.CloneDisposables(originalMessage.attachedDisposables));

            this.InternalId = originalMessage.InternalId;
            this.InternalBrokeredMessageState = originalMessage.InternalBrokeredMessageState;
            this.SubqueueType = originalMessage.SubqueueType;
            this.IsActivatingScheduledMessage = originalMessage.IsActivatingScheduledMessage;
            this.isFromCache = originalMessage.isFromCache;
            this.IsBodyLoaded = originalMessage.isBodyLoaded;
            this.persistedMessageSize = originalMessage.persistedMessageSize;
            this.AllowOverflowOnPersist = originalMessage.AllowOverflowOnPersist;
            this.RecordInfoAsGuid = originalMessage.RecordInfoAsGuid;

            if (originalMessage.receiverHeaders != null)
            {
                this.originalDeliveryCount = originalMessage.receiverHeaders.DeliveryCount;
            }
        }

        //event EventHandler Abandoning;

        //event EventHandler Completing;

        internal static IEnumerable<IDisposable> CloneDisposables(IEnumerable<IDisposable> disposables)
        {
            // clone the disposables if they support it
            if (disposables == null)
            {
                return null;
            }

            List<IDisposable> clonedDisposables = new List<IDisposable>();
            foreach (IDisposable obj in disposables)
            {
                ICloneable cloneable = obj as ICloneable;
                if (cloneable != null)
                {
                    object clone = cloneable.Clone();
                    Fx.Assert(clone is IDisposable, "cloned object must also implement IDisposable");
                    clonedDisposables.Add((IDisposable)clone);
                }
            }
            return clonedDisposables.Count > 0 ? clonedDisposables : null;
        }

        internal static Stream CloneStream(Stream originalStream, bool canThrowException = false)
        {
            Stream clonedStream = null;

            if (originalStream != null)
            {
                MemoryStream memoryStream;
                ICloneable cloneable;

                if ((memoryStream = originalStream as MemoryStream) != null)
                {
                    // Note: memoryStream.GetBuffer() doesn't work
                    clonedStream = new MemoryStream(memoryStream.ToArray(), 0, (int)memoryStream.Length, false, true);
                }
                else if ((cloneable = originalStream as ICloneable) != null)
                {
                    clonedStream = (Stream)cloneable.Clone();
                }
                else if (canThrowException)
                {
                    //TODO: throw Fx.Exception.AsError(new InvalidOperationException(SRClient.BrokeredMessageStreamNotCloneable(originalStream.GetType().FullName)));
                    throw new InvalidOperationException("BrokeredMessageStreamNotCloneable");
                }
            }

            return clonedStream;
        }

        [Flags]
        internal enum MessageMembers : int
        {
            // public get/set members
            MessageId = 1,
            CorrelationId = 1 << 1,
            To = 1 << 2,
            ReplyTo = 1 << 3,
            TimeToLive = 1 << 4,
            SessionId = 1 << 5,
            Label = 1 << 6,
            ContentType = 1 << 7,
            ScheduledEnqueueTimeUtc = 1 << 8,
            PartitionKey = 1 << 9,
            ReplyToSessionId = 1 << 10,
            ViaPartitionKey = 1 << 11,
            Destination = 1 << 12,
            ForcePersistence = 1 << 13,

            // public read-only members
            DeadLetterSource = 1 << 14,
            Publisher = 1 << 15,
            EnqueuedTimeUtc = 1 << 16,
            SequenceNumber = 1 << 17,
            LockToken = 1 << 18,
            LockedUntilUtc = 1 << 19,
            DeliveryCount = 1 << 20,
            MessageState = 1 << 21,
            EnqueuedSequenceNumber = 1 << 22,

            // internal
            PartitionId = 1 << 23,
            TransferSessionId = 1 << 24,
            PrefilteredHeaders = 1 << 25,
            PrefilteredProperties = 1 << 26,
            TransferDestination = 1 << 27,
            TransferSource = 1 << 28,
            TransferSequenceNumber = 1 << 29,
            TransferHopCount = 1 << 30,
            TransferDestinationEntityId = 1 << 31
        }

        enum FieldId : byte
        {
            // public get/set members
            MessageId = 1,
            CorrelationId = 2,
            To = 3,
            ReplyTo = 4,
            TimeToLive = 5,
            SessionId = 6,
            Label = 7,
            ContentType = 8,
            ScheduledEnqueueTimeUtc = 9,
            PartitionKey = 10,
            ReplyToSessionId = 11,
            ViaPartitionKey = 12,
            Destination = 13,
            ForcePersistence = 14,

            // public read-only members
            DeadLetterSource = 15,
            Publisher = 19,
            EnqueuedTimeUtc = 20,
            SequenceNumber = 21,
            LockToken = 22,
            LockedUntilUtc = 23,
            DeliveryCount = 24,
            MessageState = 25,
            EnqueuedSequenceNumber = 26,

            Properties = 30,
            BodyStream = 31,

            // internal
            PrefilteredMessageHeaders = 40,
            PrefilteredMessageProperties = 41,
            TransferDestination = 42,
            TransferSource = 43,
            TransferSequenceNumber = 44,
            TransferHopCount = 45,
            TransferDestinationResourceId = 46,
            TransferSessionId = 47,
            PartitionId = 48
        }

        static string NewMessageId()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>Gets or sets the identifier of the correlation.</summary>
        /// <value>The identifier of the correlation.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public string CorrelationId
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.correlationId;
            }

            set
            {
                this.ThrowIfDisposed();
                this.correlationId = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.CorrelationId);
                }
                else
                {

                    this.initializedMembers |= MessageMembers.CorrelationId;
                }
            }
        }

        /// <summary>Gets or sets the identifier of the session.</summary>
        /// <value>The identifier of the session.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public string SessionId
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.sessionId;
            }

            set
            {
                this.ThrowIfDisposed();
                this.CopySessionId(value);

                if (this.version >= BrokeredMessage.MessageVersion8)
                {
                    this.PartitionKey = value;
                }
            }
        }

        /// <summary> Gets or sets the the Publisher. </summary>
        /// <value> Identifies the Publisher Sending the Message. </value>
        /// <exception cref="ObjectDisposedException">Thrown if message is in disposed state.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <seealso cref="PartitionKey"/> or <seealso cref="SessionId"/> are set to different values.</exception>
        internal string Publisher
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.publisher;
            }

            set
            {
                this.ThrowIfDisposed();
                BrokeredMessage.ValidatePartitionKey("Publisher", value);
                if (value != null)
                {
                    this.ThrowIfDominatingPropertyIsNotEqualToNonNullDormantProperty(MessageMembers.Publisher, MessageMembers.PartitionKey, value, this.partitionKey);
                }

                if (string.IsNullOrEmpty(value))
                {
                    this.ClearInitializedMember(MessageMembers.Publisher);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.Publisher;
                }

                if (this.version < BrokeredMessage.MessageVersion10)
                {
                    this.version = BrokeredMessage.MessageVersion10;
                }

                this.publisher = value;
            }
        }

        /// <summary>Gets or sets the session identifier to reply to.</summary>
        /// <value>The session identifier to reply to.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public string ReplyToSessionId
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.replyToSessionId;
            }

            set
            {
                this.ThrowIfDisposed();
                BrokeredMessage.ValidateSessionId(value);
                this.replyToSessionId = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.ReplyToSessionId);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.ReplyToSessionId;
                }
            }
        }

        /// <summary>Gets the number of deliveries.</summary>
        /// <value>The number of deliveries.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown if the message has not been delivered by ServiceBus.</exception>
        public int DeliveryCount
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                this.ThrowIfNotReceived();
                return this.receiverHeaders.DeliveryCount;
            }

            internal set
            {
                this.ThrowIfDisposed();
                this.EnsureReceiverHeaders();
                this.initializedMembers |= MessageMembers.DeliveryCount;
                this.receiverHeaders.DeliveryCount = value;
            }
        }

        /// <summary />
        public string DeadLetterSource
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.deadLetterSource;
            }

            internal set
            {
                this.ThrowIfDisposed();
                this.deadLetterSource = value;

                if (string.IsNullOrEmpty(value))
                {
                    this.ClearInitializedMember(MessageMembers.DeadLetterSource);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.DeadLetterSource;
                }

                if (this.version < BrokeredMessage.MessageVersion11)
                {
                    this.version = BrokeredMessage.MessageVersion11;
                }
            }
        }

        /// <summary>Gets the date and time in UTC at which the message is set to expire.</summary>
        /// <value>The message expiration time in UTC.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        /// <exception cref="System.InvalidOperationException">If the message has not been delivered by ServerBus.</exception>
        public DateTime ExpiresAtUtc
        {
            get
            {
                this.ThrowIfDisposed();
                this.ThrowIfNotReceived();
                if (this.RecordedExpiredAtUtc.HasValue)
                {
                    return this.RecordedExpiredAtUtc.Value;
                }

                if (this.TimeToLive >= DateTime.MaxValue.Subtract(this.enqueuedTimeUtc))
                {
                    return DateTime.MaxValue;
                }

                return this.EnqueuedTimeUtc.Add(this.TimeToLive);
            }
        }

        /// <summary>
        /// This property is used on the Broker side only when we perform
        /// a deep group search for sessionful messages. in those cases we
        /// only do a partial message fetch, and so this property is used 
        /// to store the ExpiredAtUtc in that scenario.
        /// This property is also being set during Send to identify the effective message TTL
        /// </summary>
        internal DateTime? RecordedExpiredAtUtc { get; set; }

        //TODO: Fix expected exception list once CSDMain 220699 is fixed

        /// <summary>Gets the date and time in UTC until which the message will be locked in the queue/subscription.</summary>
        /// <value>The date and time until which the message will be locked in the queue/subscription.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown if the message was not received from the ServiceBus.</exception>
        public DateTime LockedUntilUtc
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                //this.ThrowIfNotLocked(); TODO
                return this.receiverHeaders.LockedUntilUtc;
            }

            internal set
            {
                this.ThrowIfDisposed();
                this.EnsureReceiverHeaders();

                this.initializedMembers |= MessageMembers.LockedUntilUtc;
                this.receiverHeaders.LockedUntilUtc = value;
            }
        }

        //TODO:Fix expected exception list once CSDMain# 220699 is fixed

        /// <summary>Gets the lock token assigned by Service Bus to this message.</summary>
        /// <value>The lock token assigned by Service Bus to this message.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown if the message was not received from the ServiceBus.</exception>
        public Guid LockToken
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                //this.ThrowIfNotLocked(); TODO
                return this.receiverHeaders.LockToken;
            }

            internal set
            {
                this.ThrowIfDisposed();
                this.EnsureReceiverHeaders();

                this.receiverHeaders.LockToken = value;
                if (value != Guid.Empty)
                {
                    this.initializedMembers |= MessageMembers.LockToken;
                }
                else
                {
                    this.ClearInitializedMember(MessageMembers.LockToken);
                }
            }
        }

        //TODO:Fix expected exception list once CSDMain# 220704 is fixed 

        /// <summary>Gets or sets the identifier of the message. This is a 
        /// user-defined value that Service Bus can use to identify duplicate messages, if enabled.</summary> 
        /// <value>The identifier of the message.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in a disposed state.</exception>
        /// <exception cref="System.ArgumentException">Thrown if the message identifier is null or exceeds 128 characters in length.</exception>
        public string MessageId
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.messageId;
            }

            set
            {
                this.ThrowIfDisposed();
                BrokeredMessage.ValidateMessageId(value);
                this.initializedMembers |= MessageMembers.MessageId;
                this.messageId = value;
            }
        }

        //TODO:Fix Expected exception list once CSDMain#220699 is fixed.

        internal int Version
        {
            get
            {
                return this.version;
            }
        }

        /// <summary> Gets or sets a context for the receive. </summary>
        /// <value> The receive context. </value>
        /// TODO
        //internal ReceiveContext ReceiveContext
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.receiveContext;
        //    }

        //    set
        //    {
        //        this.ThrowIfDisposed();
        //        this.receiveContext = value;
        //    }
        //}

        /// <summary>Gets or sets the type of the content.</summary>
        /// <value>The type of the content of the message body. This is a 
        /// content type identifier utilized by the sender and receiver for application specific logic.</value> 
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public string ContentType
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.contentType;
            }

            set
            {
                this.ThrowIfDisposed();
                this.contentType = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.ContentType);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.ContentType;
                }
            }
        }

        /// <summary>Gets or sets a partition key for sending a transactional message to a queue or topic that is not session-aware.</summary>
        /// <value>The partition key for sending a transactional message.</value>
        public string PartitionKey
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.partitionKey;
            }

            set
            {
                this.ThrowIfDisposed();
                this.ThrowIfDominatingPropertyIsNotEqualToNonNullDormantProperty(MessageMembers.PartitionKey, MessageMembers.SessionId, value, this.sessionId);
                this.CopyPartitionKey(value);

                if (this.version < BrokeredMessage.MessageVersion8)
                {
                    this.version = BrokeredMessage.MessageVersion8;
                }
            }
        }

        /// <summary>Gets or sets a partition key value when a transaction is to be used to send messages via a transfer queue.</summary>
        /// <value>The partition key value when a transaction is to be used to send messages via a transfer queue.</value>
        public string ViaPartitionKey
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.viaPartitionKey;
            }

            set
            {
                this.ThrowIfDisposed();
                BrokeredMessage.ValidatePartitionKey("ViaPartitionKey", value);
                this.viaPartitionKey = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.ViaPartitionKey);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.ViaPartitionKey;
                }

                if (this.version < BrokeredMessage.MessageVersion8)
                {
                    this.version = BrokeredMessage.MessageVersion8;
                }
            }
        }

        internal short PartitionId
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.partitionId;
            }

            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.AsError(new ArgumentOutOfRangeException("PartitionId"));
                }

                this.ThrowIfDisposed();
                this.initializedMembers |= MessageMembers.PartitionId;
                this.partitionId = value;

                if (this.version < BrokeredMessage.MessageVersion6)
                {
                    this.version = BrokeredMessage.MessageVersion6;
                }
            }
        }

        /// <summary>Gets or sets the application specific label.</summary>
        /// <value>The application specific label.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public string Label
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.label;
            }

            set
            {
                this.ThrowIfDisposed();
                this.label = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.Label);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.Label;
                }
            }
        }

        /// <summary> Gets or sets the destination. </summary>
        /// <value> The destination. </value>
        internal string Destination
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.destination;
            }

            set
            {
                this.ThrowIfDisposed();
                BrokeredMessage.ValidateDestination(value);
                this.destination = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.Destination);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.Destination;
                }

                if (this.version < BrokeredMessage.MessageVersion9)
                {
                    this.version = BrokeredMessage.MessageVersion9;
                }
            }
        }

        /// <summary>Gets the application specific message properties.</summary>
        /// <value>The application specific message properties.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public IDictionary<string, object> Properties
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.InternalProperties;
            }
        }

        /// <summary>Gets or sets the address of the queue to reply to.</summary>
        /// <value>The reply to queue address.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public string ReplyTo
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.replyTo;
            }

            set
            {
                this.ThrowIfDisposed();
                this.replyTo = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.ReplyTo);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.ReplyTo;
                }
            }
        }

        /// <summary>Gets or sets the date and time of the sent time in UTC.</summary>
        /// <value>The enqueue time in UTC. This value represents the actual time of enqueuing the message.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public DateTime EnqueuedTimeUtc
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                this.ThrowIfNotReceived();
                return this.enqueuedTimeUtc;
            }

            internal set
            {
                this.ThrowIfDisposed();
                this.EnsureReceiverHeaders();
                this.initializedMembers |= MessageMembers.EnqueuedTimeUtc;
                this.enqueuedTimeUtc = value;
            }
        }

        /// <summary>Gets or sets the date and time in UTC at which the message will be enqueued. This 
        /// property returns the time in UTC; when setting the property, the supplied DateTime value must also be in UTC.</summary> 
        /// <value>The scheduled enqueue time in UTC. This value is for delayed message sending. 
        /// It is utilized to delay messages sending to a specific time in the future.</value> 
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if the passed in value is DateTime.MaxValue.</exception>
        public DateTime ScheduledEnqueueTimeUtc
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.scheduledEnqueueTimeUtc;
            }

            set
            {
                this.ThrowIfDisposed();

                if (value == DateTime.MaxValue)
                {
                    throw Fx.Exception.AsError(new ArgumentOutOfRangeException("ScheduledEnqueueTimeUtc"));
                }

                this.initializedMembers |= MessageMembers.ScheduledEnqueueTimeUtc;
                this.scheduledEnqueueTimeUtc = value;
            }
        }

        /// <summary>Gets the unique number assigned to a message by the Service Bus.</summary>
        /// <value>The unique number assigned to a message by the Service Bus.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown if the message was not received from the message server.</exception>
        public long SequenceNumber
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                this.ThrowIfNotReceived();
                return this.receiverHeaders.SequenceNumber;
            }

            internal set
            {
                this.ThrowIfDisposed();
                this.EnsureReceiverHeaders();
                this.initializedMembers |= MessageMembers.SequenceNumber;
                this.receiverHeaders.SequenceNumber = value;
            }
        }

        /// <summary>Gets or sets the enqueued sequence number of the message.</summary>
        /// <value>The enqueued sequence number of the message.</value>
        public long EnqueuedSequenceNumber
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                this.ThrowIfNotReceived();
                return this.receiverHeaders.EnqueuedSequenceNumber;
            }

            internal set
            {
                this.ThrowIfDisposed();
                this.EnsureReceiverHeaders();

                this.initializedMembers |= MessageMembers.EnqueuedSequenceNumber;
                this.receiverHeaders.EnqueuedSequenceNumber = value;
                if (this.version < BrokeredMessage.MessageVersion5)
                {
                    this.version = BrokeredMessage.MessageVersion5;
                }
            }
        }

        /// <summary>Gets the size of the message in bytes.</summary>
        /// <value>The message size in bytes.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public long Size
        {
            get
            {
                this.ThrowIfDisposed();
                return this.HeaderSize + this.BodySize;
            }
        }

        /// <summary> Gets the size of the message header in bytes. </summary>
        /// <value> The size of the message header. </value>
        /// <exception cref="ObjectDisposedException">Thrown if message is in disposed state</exception>
        internal long HeaderSize
        {
            get
            {
                this.ThrowIfDisposed();
                return this.headerSize;
            }
        }

        internal long BodySize
        {
            get
            {
                this.ThrowIfDisposed();
                if (this.bodyStream != null && this.bodyStream.CanSeek)
                {
                    this.bodySize = this.bodyStream.Length;
                }

                return this.bodySize;
            }
        }

        internal int HeaderStreamMaxSize
        {
            get
            {
                if (this.SubqueueType == Messaging.SubqueueType.DeadLettered)
                {
                    return BrokeredMessage.deadLetterheaderStreamMaxSize;
                }
                else
                {
                    return BrokeredMessage.headerStreamMaxSize;
                }
            }
        }

        /// <summary>Gets or sets the state of the message.</summary>
        /// <value>The state of the message.</value>
        public MessageState State
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.state;
            }

            internal set
            {
                this.ThrowIfDisposed();
                this.state = value;
                this.initializedMembers |= MessageMembers.MessageState;
                if (this.version < BrokeredMessage.MessageVersion4)
                {
                    this.version = BrokeredMessage.MessageVersion4;
                }
            }
        }

        /// <summary>Gets or sets the message’s time to live value. This is the duration after which the message expires, starting from when the message is sent to the Service Bus. Messages older than their TimeToLive value will expire and no longer be retained in the message store. Subscribers will be unable to receive expired messages.TimeToLive is the maximum lifetime that a message can receive, but its value cannot exceed the entity specified the 
        /// <see cref="Microsoft.ServiceBus.Messaging.QueueDescription.DefaultMessageTimeToLive" /> value on the destination queue or subscription. If a lower TimeToLive value is specified, it will be applied to the individual message. However, a larger value specified on the message will be overridden by the entity’s DefaultMessageTimeToLive value.</summary> 
        /// <value>The message’s time to live value.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if the passed in value is less than or equal to TimeSpan.Zero.</exception>
        public TimeSpan TimeToLive
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                if (this.timeToLive == TimeSpan.Zero)
                {
                    return TimeSpan.MaxValue;
                }
                else
                {
                    return this.timeToLive;
                }
            }

            set
            {
                TimeoutHelper.ThrowIfNonPositiveArgument(value);

                this.ThrowIfDisposed();
                this.initializedMembers |= MessageMembers.TimeToLive;
                this.timeToLive = value;
            }
        }

        /// <summary>Gets or sets the send to address.</summary>
        /// <value>The send to address.</value>
        /// <exception cref="System.ObjectDisposedException">Thrown if the message is in disposed state.</exception>
        public string To
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.to;
            }

            set
            {
                this.ThrowIfDisposed();
                this.to = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.To);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.To;
                }
            }
        }

        /// <summary>Specifies whether the message has been consumed.</summary>
        /// <value>true if the message has been consumed; otherwise, false.</value>
        public bool IsBodyConsumed
        {
            get
            {
                // Body is consumed in 2 cases.
                // - Someone called GetBody() - this happens in both send and receive.
                // - Send operation "considered" a message been sent.
                // Note: this is not a thread safe boolean. IsBodyConsumed == false
                // can still lead to Send/GetBody() throwing exception saying body is consumed
                // in a multi-threaded scenario.
                this.ThrowIfDisposed();
                return this.getBodyCalled == 1 || this.messageConsumed == 1;
            }
        }

        /// <summary>Gets or sets a value that indicates whether the message is to be persisted to the database immediately, instead of being 
        /// held in memory for a short time. This property is ignored if the message is sent to a non-express queue or topic.</summary> 
        /// <value>true if the message is to be persisted to the database 
        /// immediately, instead of being held in memory for a short time; otherwise, false.</value> 
        public bool ForcePersistence
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.forcePersistence;
            }

            set
            {
                this.ThrowIfDisposed();

                this.initializedMembers |= MessageMembers.ForcePersistence;
                this.forcePersistence = value;

                if (this.version < BrokeredMessage.MessageVersion9)
                {
                    this.version = BrokeredMessage.MessageVersion9;
                }
            }
        }

        /// <summary> Gets or sets the flag for whether the message is a scheduled message that's being activated. </summary>
        /// <value> The boolean value </value>
        internal bool IsActivatingScheduledMessage
        {
            get;
            set;
        }

        /// <summary> Gets or sets the body stream. </summary>
        /// <value> The message body stream. </value>
        /// <exception cref="ObjectDisposedException">Thrown if message is in disposed state</exception>
        internal Stream BodyStream
        {
            get
            {
                this.ThrowIfDisposed();
                return this.bodyStream;
            }

            set
            {
                this.ThrowIfDisposed();

                if (this.bodyStream != null && this.ownsBodyStream)
                {
                    this.bodyStream.Dispose();
                }

                this.bodyStream = value;
            }
        }

        internal Stream RawHeaderStream
        {
            get
            {
                this.ThrowIfDisposed();
                return this.rawHeaderStream;
            }

            set
            {
                this.ThrowIfDisposed();

                if (this.rawHeaderStream != null && this.ownsRawHeaderStream)
                {
                    this.rawHeaderStream.Dispose();
                }

                this.rawHeaderStream = value;
            }
        }

        internal BrokeredMessageFormat MessageFormat
        {
            get
            {
                this.ThrowIfDisposed();
                return this.messageFormat;
            }

            set
            {
                this.ThrowIfDisposed();
                this.messageFormat = value;
            }
        }

        internal IBrokeredMessageEncoder MessageEncoder
        {
            get
            {
                this.ThrowIfDisposed();
                return this.messageEncoder;
            }

            set
            {
                this.ThrowIfDisposed();
                this.messageEncoder = value;
            }
        }

        internal bool ArePropertiesModifiedByBroker
        {
            get
            {
                this.ThrowIfDisposed();
                return this.arePropertiesModifiedByBroker;
            }
        }

        /// <summary> Gets or sets the initialized members. </summary>
        /// <value> The initialized members. </value>
        internal MessageMembers InitializedMembers
        {
            get
            {
                return this.initializedMembers;
            }

            set
            {
                this.initializedMembers = value;
            }
        }

        /// <summary> Gets a value indicating whether this object is lock token set. </summary>
        /// <value> true if this object is lock token set, false if not. </value>
        internal bool IsLockTokenSet
        {
            get
            {
                this.EnsureHeaderDeserialized();
                return (this.initializedMembers & MessageMembers.LockToken) != 0;
            }
        }

        /// <summary> Gets or sets a value indicating whether this object is body loaded. </summary>
        /// <value> true if this object is body loaded, false if not. </value>
        internal bool IsBodyLoaded
        {
            get
            {
                this.ThrowIfDisposed();
                return this.isBodyLoaded;
            }
            set
            {
                this.ThrowIfDisposed();
                this.isBodyLoaded = value;
            }
        }

        /// <summary> Gets the identifier of the body. </summary>
        /// <value> The identifier of the body. </value>
        internal long BodyId
        {
            get
            {
                this.EnsureHeaderDeserialized();
                return this.bodyId;
            }

            set
            {
                this.bodyId = value;
            }
        }

        /// <summary> Gets or sets the InternalId. </summary>
        /// <value> The InternalId. </value>
        internal Guid InternalId
        {
            get;
            set;
        }

        /// <summary> Gets or sets the PrefilteredHeaders. </summary>
        /// <value> The prefiltered message headers. </value>
        internal Stream PrefilteredHeaders
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.prefilteredHeaders;
            }

            set
            {
                this.ThrowIfDisposed();
                if (this.prefilteredHeaders != null)
                {
                    this.prefilteredHeaders.Dispose();
                }
                this.prefilteredHeaders = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.PrefilteredHeaders);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.PrefilteredHeaders;
                }
            }
        }

        /// <summary> Gets or sets the PrefilteredProperties. </summary>
        /// <value> The prefiltered message properties. </value>
        internal Stream PrefilteredProperties
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.prefilteredProperties;
            }

            set
            {
                this.ThrowIfDisposed();
                if (this.prefilteredProperties != null)
                {
                    this.prefilteredProperties.Dispose();
                }
                this.prefilteredProperties = value;
                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.PrefilteredProperties);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.PrefilteredProperties;
                }
            }
        }

        /// <summary> Gets or sets the state. </summary>
        /// <value> The state. </value>
        internal BrokeredMessageState InternalBrokeredMessageState
        {
            get;
            set;
        }

        /// <summary> Gets or sets the subqueue type. </summary>
        /// <value> The subqueue type. </value>
        internal SubqueueType SubqueueType
        {
            get;
            set;
        }

        internal Guid RecordInfoAsGuid
        {
            get;
            set;
        }

        /// <summary> EventHub only property. </summary>
        internal long Offset
        {
            get { return this.EnqueuedSequenceNumber; }
        }

        internal string TransferDestination
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.transferDestination;
            }

            set
            {
                this.ThrowIfDisposed();
                this.transferDestination = value;

                if (string.IsNullOrEmpty(value))
                {
                    this.ClearInitializedMember(MessageMembers.TransferDestination);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.TransferDestination;
                }
            }
        }

        internal long TransferDestinationResourceId
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.transferDestinationResourceId;
            }

            set
            {
                this.ThrowIfDisposed();
                this.transferDestinationResourceId = value;

                this.initializedMembers |= MessageMembers.TransferDestinationEntityId;
            }
        }

        internal string TransferSessionId
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.transferSessionId;
            }

            set
            {
                this.ThrowIfDisposed();
                this.transferSessionId = value;

                if (value == null)
                {
                    this.ClearInitializedMember(MessageMembers.TransferSessionId);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.TransferSessionId;
                }
            }
        }

        internal string TransferSource
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.transferSource;
            }

            set
            {
                this.ThrowIfDisposed();
                this.transferSource = value;

                if (string.IsNullOrEmpty(value))
                {
                    this.ClearInitializedMember(MessageMembers.TransferSource);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.TransferSource;
                }
            }
        }

        internal long TransferSequenceNumber
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.transferSequenceNumber;
            }

            set
            {
                this.ThrowIfDisposed();
                this.transferSequenceNumber = value;
                this.initializedMembers |= MessageMembers.TransferSequenceNumber;
            }
        }

        internal int TransferHopCount
        {
            get
            {
                this.ThrowIfDisposed();
                this.EnsureHeaderDeserialized();
                return this.transferHopCount;
            }

            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.AsError(new ArgumentOutOfRangeException("TransferHopCount"));
                }

                this.ThrowIfDisposed();
                this.transferHopCount = value;
                if (value == 0)
                {
                    this.ClearInitializedMember(MessageMembers.TransferHopCount);
                }
                else
                {
                    this.initializedMembers |= MessageMembers.TransferHopCount;
                }
            }
        }

        internal BufferedInputStream HeaderStream
        {
            get { return headerStream; }
            set
            {
                if (this.headerStream != null)
                {
                    this.headerStream.Dispose();
                }
                this.headerStream = value;
            }
        }

        /// <summary> Gets or sets a value indicating the persisted size of the message in the store </summary>
        /// <value> the persisted message size </value>
        /// <remarks> The header size of the message changes as it travels through the various layers which
        /// can affect quota calculation. To avoid this we need a consistent message size property. </remarks>
        internal long PersistedMessageSize
        {
            get
            {
                return this.persistedMessageSize;
            }
            set
            {
                this.persistedMessageSize = value;
            }
        }

        /// <summary> Gets the internal properties. </summary>
        /// <value> The internal properties. </value>
        internal IDictionary<string, object> InternalProperties
        {
            get
            {
                if (this.properties == null)
                {
                    Interlocked.CompareExchange(ref this.properties, new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase), null);
                }

                return this.properties;
            }
        }

        /// <summary> Gets or sets a value indicating whether the message came from cache or not. </summary>
        /// <value> true if came from cache, false if not. </value>
        /// <remarks> Used in Tests only </remarks>
        internal bool IsFromCache
        {
            get
            {
                return this.isFromCache;
            }

            set
            {
                this.isFromCache = value;
            }
        }

        /// <summary>
        /// Indicate if the BorkeredMessage has been accessed (or marked) as consumed.
        /// </summary>
        /// <remarks>Initially IsConsumed is false. First read of this property will also
        /// marked the IsConsumed to be true (atomically). Subsequence will be false. 
        /// 
        /// Also note that this does not take transaction into account, so if a message 
        /// is marked as consumed but then transaction is aborted, this property will 
        /// continue to indicate false.</remarks>
        internal bool IsConsumed
        {
            get
            {
                // First get will be 0, with subsequence get being 1 (true)
                return 1 == Interlocked.Exchange(ref this.messageConsumed, 1);
            }

            set
            {
                int intValue = value ? 1 : 0;
                Interlocked.Exchange(ref this.messageConsumed, intValue);
            }
        }

        // This field is set when we establish that the message header can be recreated
        // without having to be serialized. This is only the case for subscriptions that
        // can recreate the header based on it's Topic Header.
        internal bool SupportsEmptySerializedHeader
        {
            get
            {
                if (!this.supportsEmptySerializedHeader)
                {
                    return false;
                }

                if (this.originalDeliveryCount.HasValue && this.receiverHeaders != null && this.DeliveryCount != this.originalDeliveryCount)
                {
                    return false;
                }

                if (this.ArePropertiesModifiedByBroker)
                {
                    return false;
                }

                // If it has more than these then it cannot safely use the topic header
                var combined = (this.InitializedMembers | RegularTopicHeaders);
                bool supportsEmptySerializedHeader = combined == RegularTopicHeaders;
                return supportsEmptySerializedHeader;
            }

            set
            {
                this.supportsEmptySerializedHeader = value;
            }
        }

        // This field is set when we establish that the message header can be recreated
        // without having to be serialized. This is only the case for subscriptions that
        // can recreate the header based on it's Topic Header.
        internal bool SupportsEmptySerializedHeaderInFileStore
        {
            get
            {
                if (!this.supportsEmptySerializedHeader)
                {
                    return false;
                }

                if (this.originalDeliveryCount.HasValue && this.receiverHeaders != null && this.DeliveryCount != this.originalDeliveryCount)
                {
                    return false;
                }

                if (this.ArePropertiesModifiedByBroker)
                {
                    return false;
                }

                // If it has more than these then it cannot safely use the topic header
                var combined = (this.InitializedMembers | RegularTopicHeadersInFileStore);
                bool supportsEmptySerializedHeaderInFileStore = combined == RegularTopicHeadersInFileStore;
                return supportsEmptySerializedHeaderInFileStore;
            }

            set
            {
                this.supportsEmptySerializedHeader = value;
            }
        }

        internal bool IsPingMessage
        {
            get
            {
                //TODO: return string.Equals(Constants.BacklogPingMessageContentType, this.ContentType, StringComparison.OrdinalIgnoreCase);
                return false;
            }
        }

        internal bool IsTransferMessage
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.TransferDestination);
            }
        }

        internal bool AllowOverflowOnPersist { get; set; }

        /// <summary> Creates the empty message. </summary>
        /// <returns> . </returns>
        /// TODO: 
        //internal static BrokeredMessage CreateEmptyMessage()
        //{
        //    return new BrokeredMessage((object)null);
        //}

        /// <summary>Deserializes the brokered message body into an object of the specified type by using the 
        /// <see cref="System.Runtime.Serialization.DataContractSerializer" /> with a binary 
        /// <see cref="System.Xml.XmlDictionaryReader" />.</summary> 
        /// <typeparam name="T">The type to which the message body will be deserialized.</typeparam>
        /// <returns>The deserialized object or graph.</returns>
        /// <exception cref="System.ObjectDisposedException">If the message is in disposed state or the message body stream is already disposed.</exception>
        /// <exception cref="System.InvalidOperationException">If the message contains a null body stream or the 
        /// body stream contains no data or the message body has already been consumed.</exception> 
        public T GetBody<T>()
        {
            if (typeof(T) == typeof(Stream))
            {
                this.SetGetBodyCalled();
                return (T)(object)this.BodyStream;
            }
            else if (this.bodyObjectDecoded && this.bodyObject != null)
            {
                this.SetGetBodyCalled();
                return (T)this.bodyObject;
            }

            throw new InvalidOperationException("No DataContractBinarySerializer");
            //TODO:
            //else
            //{
            //    return this.GetBody<T>(new DataContractBinarySerializer(typeof(T)));
            //}
        }

        /// <summary>Deserializes the BrokeredMessage body into an object of the specified type using 
        /// DataContractSerializer with a Binary XmlObjectSerializer. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="serializer"> The serializer object. </param>
        /// <returns> The deserialized object/graph</returns>
        /// <exception cref="ObjectDisposedException"> Thrown if the message is in disposed state. </exception>
        /// <exception cref="ArgumentNullException"> Thrown when invoked with a Null serializer object. </exception>
        /// <exception cref="InvalidOperationException"> Thrown if the message contains a Null body stream, contains no data, 
        /// or if the stream has been read once (through any GetBody() calls). </exception>
        // TODO:
        //public T GetBody<T>(XmlObjectSerializer serializer)
        //{
        //    if (serializer == null)
        //    {
        //        //TODO: throw FxTrace.Exception.AsError(new ArgumentNullException("serializer"));
        //        throw new ArgumentNullException("serializer");
        //    }

        //    this.ThrowIfDisposed();
        //    this.SetGetBodyCalled();

        //    if (this.BodyStream == null)
        //    {
        //        // BodyStream is null only if 
        //        // (a) user create message with null object or
        //        // (b) internal code set BodyStream to null
        //        // We assume case (b) is treated like case (a).
        //        if (typeof(T).IsValueType)
        //        {
        //            //TODO: throw FxTrace.Exception.AsError(new InvalidOperationException(SRClient.MessageBodyNull));
        //            throw new InvalidOperationException("MessageBodyNull");
        //        }

        //        return default(T);
        //    }
        //    else if (this.BodyStream.CanSeek)
        //    {
        //        if (this.BodyStream.Length == 0)
        //        {
        //            // There are 2 cases where there is a stream in the first place:
        //            // (a) user called Message.CreateMessage(object/stream)
        //            // (b) internal code set Message.BodyStream to non-null stream
        //            // Either case, someone now force stream to be empty. We should always throw
        //            // in these cases.
        //            throw FxTrace.Exception.AsError(new InvalidOperationException(SRClient.MessageBodyNull));
        //        }

        //        this.BodyStream.Position = 0;
        //    }

        //    return (T)serializer.ReadObject(this.BodyStream);
        //}

        //TODO:
        /// <summary>Abandons the lock on a peek-locked message.</summary>
        /// <exception cref="System.ObjectDisposedException">Thrown when the message is in the disposed state or 
        /// the receiver with which the message was received is in disposed state.</exception> 
        /// <exception cref="System.InvalidOperationException">Thrown when invoked on a message that has not been received from the 
        /// message server or invoked on a message that has not been received in peek-lock mode.</exception> 
        /// <exception cref="System.TimeoutException">Thrown when operation times out. The timeout period is initialized through the 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings" />. You may need to increase the value of 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout" /> to avoid this exception if the timeout value is relatively low.</exception> 
        /// <exception cref="MessagingCommunicationException">Thrown when the queue or subscription that receives 
        /// the message is no longer present in the message server.</exception> 
        /// <exception cref="ServerBusyException">When service bus service is 
        /// busy and is unable process the request.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessagingEntityNotFoundException">When messaging entity the 
        /// message was received from has been deleted.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessageLockLostException">When the lock associated with this message 
        /// was lost or the lock token was not found.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.SessionLockLostException">When this message was received from a 
        /// Session and the lock associated with the session was lost.</exception> 
        /// <exception cref="System.UnauthorizedAccessException">When the security token provided by the 
        /// TokenProvider does not contain the claims to perform this operation.</exception> 
        /// <exception cref="System.ServiceModel.QuotaExceededException">When the number of concurrent connections 
        /// to an entity exceed the maximum allowed value.</exception> 
        //public void Abandon()
        //{
        //    this.Abandon(null);
        //}

        /// <summary>Abandons the lock on a peek-locked message.</summary>
        /// <param name="propertiesToModify">The key-value pair collection of properties to modify.</param>
        /// TODO
        //public void Abandon(IDictionary<string, object> propertiesToModify)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    this.EndAbandon(this.BeginAbandon(propertiesToModify, this.ReceiveContext.OperationTimeout, null, null));
        //}

        /// <summary>Asynchronously abandons the lock on a peek-locked message.</summary>
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task AbandonAsync()
        //{
        //    return TaskHelpers.FromAsync(
        //        this.BeginAbandon,
        //        this.EndAbandon);
        //}

        /// <summary>Asynchronously abandons the lock on a peek-locked message.</summary>
        /// <param name="propertiesToModify">The key-value pair collection of properties to modify.</param>
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task AbandonAsync(IDictionary<string, object> propertiesToModify)
        //{
        //    return TaskHelpers.FromAsync(
        //        (c, s) => this.BeginAbandon(propertiesToModify, c, s),
        //        this.EndAbandon);
        //}

        //TODO:Fix XML comments on all BeginXXX() and EndXXX() once CSDMain#220699 is fixed

        //TODO:
        /// <summary> Begins an asynchronous operation to abandon the lock on a peek-locked message. </summary>
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
        /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to 
        ///                     the <see cref="EndAbandon"/> delegate when the operation is complete. </param>
        /// <returns> An <see cref="IAsyncResult"/> that references the asynchronous request to abandon the lock on a peek-locked message. </returns>
        /// <exception cref="ObjectDisposedException">Thrown when
        ///                                      <list type="bullet">
        ///                                                           <item>message is in disposed state.</item>
        ///                                                          <item>the receiver with which the messsage was received is in disposed state</item>
        ///                                      </list></exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received from the message server.</exception>
        //internal IAsyncResult BeginAbandon(AsyncCallback callback, object state)
        //{
        //    return this.BeginAbandon(null, callback, state);
        //}

        //TODO:
        /// <summary> Begins an asynchronous operation to abandon the lock on a peek-locked message. </summary>
        /// <param name="propertiesToModify">  updates properties on the message being abandoned. </param>     
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
        /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to 
        ///                     the <see cref="EndAbandon"/> delegate when the operation is complete. </param>
        /// <returns> An <see cref="IAsyncResult"/> that references the asynchronous request to abandon the lock on a peek-locked message. </returns>
        /// <exception cref="ObjectDisposedException">Thrown when
        ///                                      <list type="bullet">
        ///                                                           <item>message is in disposed state.</item>
        ///                                                          <item>the receiver with which the messsage was received is in disposed state</item>
        ///                                      </list></exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received from the message server.</exception>
        //internal IAsyncResult BeginAbandon(IDictionary<string, object> propertiesToModify, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.BeginAbandon(propertiesToModify, this.ReceiveContext.OperationTimeout, callback, state);
        //}

        //TODO:
        //internal IAsyncResult BeginAbandon(IDictionary<string, object> propertiesToModify, TimeSpan timeout, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfDisposed();
        //    this.ThrowIfNotLocked();
        //    this.ThrowIfReceiveContextIsNull();

        //    this.RaiseEvent(this.Abandoning);
        //    return this.ReceiveContext.BeginAbandon(propertiesToModify, timeout, callback, state);
        //}

        //TODO:
        /// <summary> Ends an asynchronous request to abandon the lock on a peek-locked message. </summary>
        /// <param name="result"> An <see cref="IAsyncResult"/> that references the <see cref="Abandon()"/>.  </param>
        /// <exception cref="ArgumentException">Thrown if an incorrect IAsyncResult is provided. The IAsyncResult object passed to 'End' must be the one returned from the matching 'Begin' or 
        ///                                     passed to the callback provided to 'Begin'.</exception>
        /// <exception cref="ArgumentNullException">Thrown if invoked with a Null result.</exception>
        /// <exception cref="TimeoutException">Thrown when operation times out. Timeout period is initialized through the <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings"/>. You
        ///                                 may need to increase the value of <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout"/> to avoid this exception if timeout value
        ///                                 is relatively low.
        ///                                 <seealso cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout"/></exception>
        /// <exception cref="System.ServiceModel.CommunicationException">Thrown when the queue or subscription that the message was received from is no longer present in the message server.</exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received in peek-lock mode</exception>
        //internal void EndAbandon(IAsyncResult result)
        //{
        //    this.ReceiveContext.EndAbandon(result);
        //}

        //TODO:
        /// <summary>Renews the lock on a message.</summary>
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessagingException">If 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingException.IsTransient" /> is true, you can retry the operation immediately.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessagingCommunicationException">You can retry the operation immediately.</exception>
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessageLockLostException">Thrown if you have called 
        /// <see cref="BrokeredMessage.RenewLock" /> too late. In a session, this is never thrown.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.SessionLockLostException">Thrown instead of 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessageLockLostException" /> if the message is from a 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessageSession" />.</exception> 
        //public void RenewLock()
        //{
        //    // BeginRenewLock will check for disposed/locked condition.
        //    //TODO: this.ThrowIfReceiveContextIsNull(SRClient.InvalidMethodWhilePeeking("RenewLock"));
        //    this.ThrowIfReceiveContextIsNull("InvalidMethodWhilePeeking");
        //    this.EndRenewLock(this.BeginRenewLock(this.ReceiveContext.OperationTimeout, null, null));
        //}

        //TODO:
        /// <summary>Asynchronously renews the lock on a message.</summary>
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task RenewLockAsync()
        //{
        //    return TaskHelpers.FromAsync(
        //        this.BeginRenewLock,
        //        this.EndRenewLock);
        //}

        //TODO:
        //internal IAsyncResult BeginRenewLock(AsyncCallback callback, object state)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.BeginRenewLock(this.ReceiveContext.OperationTimeout, callback, state);
        //}

        //TODO:
        //internal IAsyncResult BeginRenewLock(TimeSpan timeout, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfDisposed();
        //    this.ThrowIfNotLocked();
        //    //TODO: this.ThrowIfReceiveContextIsNull(SRClient.InvalidMethodWhilePeeking("RenewLock"));
        //    this.ThrowIfReceiveContextIsNull("InvalidMethodWhilePeeking");
        //    return this.ReceiveContext.BeginRenewLock(timeout, callback, state);
        //}

        //TODO:
        //internal void EndRenewLock(IAsyncResult result)
        //{
        //    IEnumerable<DateTime> newLockList = this.ReceiveContext.EndRenewLock(result);

        //    if (newLockList != null && newLockList.Any())
        //    {
        //        this.LockedUntilUtc = newLockList.First();
        //    }
        //}

        //TODO:
        /// <summary>Completes the receive operation of a message and indicates that the message should be marked as processed and deleted.</summary>
        /// <exception cref="System.ObjectDisposedException">Thrown when the message is in disposed state or 
        /// the receiver with which the message was received is in disposed state.</exception> 
        /// <exception cref="System.InvalidOperationException">Thrown when invoked on a message that has not been received from the 
        /// message server or invoked on a message that has not been received in peek-lock mode.</exception> 
        /// <exception cref="MessagingCommunicationException">Thrown when the queue or subscription that receives 
        /// the message is no longer present in the message server.</exception> 
        /// <exception cref="System.TimeoutException">Thrown when the operation times out. The timeout period is initialized through the 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings" />. You may need to increase the value of 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout" /> to avoid this exception if the timeout value is relatively low.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessageLockLostException">Thrown if the lock on the message has expired. LockDuration is an entity-wide setting and can be initialized through 
        /// <see cref="Microsoft.ServiceBus.Messaging.QueueDescription.LockDuration" /> and 
        /// <see cref="Microsoft.ServiceBus.Messaging.SubscriptionDescription.LockDuration" /> for queues and subscriptions respectively.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.SessionLockLostException">Thrown if the lock on the session has expired. The session lock duration is the same as the message LockDuration and is an entity-wide setting. It can be initialized through 
        /// <see cref="Microsoft.ServiceBus.Messaging.QueueDescription.LockDuration" /> and 
        /// <see cref="Microsoft.ServiceBus.Messaging.SubscriptionDescription.LockDuration" /> for queues and subscriptions respectively.</exception> 
        /// <exception cref="ServerBusyException">When service bus service is 
        /// busy and is unable process the request.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessagingEntityNotFoundException">When messaging entity the 
        /// message was received from has been deleted.</exception> 
        /// <exception cref="System.UnauthorizedAccessException">When the security token provided by the 
        /// TokenProvider does not contain the claims to perform this operation.</exception> 
        /// <exception cref="System.ServiceModel.QuotaExceededException">When the number of concurrent connections 
        /// to an entity exceed the maximum allowed value.</exception> 
        //public void Complete()
        //{
        //    this.ThrowIfDisposed();
        //    this.ThrowIfNotLocked();
        //    this.ThrowIfReceiveContextIsNull();

        //    this.RaiseEvent(this.Completing);
        //    this.ReceiveContext.Complete();
        //}

        //TODO:
        /// <summary>Asynchronously completes the receive operation of a message and 
        /// indicates that the message should be marked as processed and deleted.</summary> 
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task CompleteAsync()
        //{
        //    return TaskHelpers.FromAsync(
        //        this.BeginComplete,
        //        this.EndComplete);
        //}

        //TODO:
        /// <summary> Begins an asynchronous operation to complete a message </summary>
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
        /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to 
        ///                     the <see cref="EndComplete"/> delegate when the operation is complete. </param>
        /// <returns> An <see cref="IAsyncResult"/> that references the asynchronous request to complete a message. </returns>
        /// <exception cref="ObjectDisposedException">Thrown when
        ///                                      <list type="bullet">
        ///                                                           <item>message is in disposed state.</item>
        ///                                                          <item>the receiver with which the messsage was received is in disposed state</item>
        ///                                      </list></exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received from the message server.</exception>
        //internal IAsyncResult BeginComplete(AsyncCallback callback, object state)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.BeginComplete(this.ReceiveContext.OperationTimeout, callback, state);
        //}

        //TODO:
        //internal IAsyncResult BeginComplete(TimeSpan timeout, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfDisposed();
        //    this.ThrowIfNotLocked();
        //    this.ThrowIfReceiveContextIsNull();

        //    this.RaiseEvent(this.Completing);
        //    return this.ReceiveContext.BeginComplete(timeout, callback, state);
        //}

        //TODO:
        /// <summary> Ends an asynchronous operation to complete a message. </summary>
        /// <param name="result"> An <see cref="IAsyncResult"/> that references the Complete.  </param>
        /// <exception cref="ArgumentException">Thrown if an incorrect IAsyncResult is provided. The IAsyncResult object passed to 'End' must be the one returned from the matching 'Begin' or 
        ///                                     passed to the callback provided to 'Begin'.</exception>
        /// <exception cref="ArgumentNullException">Thrown if invoked with a Null result.</exception>
        /// <exception cref="System.ServiceModel.CommunicationObjectFaultedException">Thrown when the queue or subscription that the message was received from is no longer present in the message server.</exception>
        /// <exception cref="TimeoutException">Thrown when operation times out. Timeout period is initialized through the <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings"/>. You
        ///                                 may need to increase the value of <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout"/> to avoid this exception if timeout value
        ///                                 is relatively low.
        ///                                 <seealso cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout"/></exception>
        /// <exception cref="MessageLockLostException">Thrown if the lock on the message has expired. LockDuration is an entity wide setting and can be initialized through
        ///                                 <see cref="QueueDescription.LockDuration"/> and <see cref="SubscriptionDescription.LockDuration"/> for Queues and Subscriptions respectively.</exception>
        /// <exception cref="SessionLockLostException">Thrown if the lock on the session has expired. Session lock durations are same as messge LockDuration and is an entity wide setting.
        ///                                 It can be initialized throgh <see cref="QueueDescription.LockDuration"/> and <see cref="SubscriptionDescription.LockDuration"/> 
        ///                                 for Queues and Subscriptions respectively.</exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received in peek-lock mode.</exception>
        //internal void EndComplete(IAsyncResult result)
        //{
        //    this.ReceiveContext.EndComplete(result);
        //}

        //TODO:
        /// <summary>Indicates that the receiver wants to defer the processing for this message.</summary>
        /// <exception cref="System.ObjectDisposedException">Thrown when the message is in the disposed state or 
        /// the receiver with which the message was received is in the disposed state.</exception> 
        /// <exception cref="System.InvalidOperationException">Thrown when invoked on a message that has not been received from the 
        /// message server or invoked on a message that has not been received in peek-lock mode.</exception> 
        /// <exception cref="MessagingCommunicationException">Thrown when the queue or subscription that receives 
        /// the message is no longer present in the message server.</exception> 
        /// <exception cref="System.TimeoutException">Thrown when the operation times out. The timeout period is initialized through the 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings" />. You may need to increase the value of 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout" /> to avoid this exception if the timeout value is relatively low.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessageLockLostException">Thrown if the lock on the message has expired. LockDuration is an entity-wide setting and can be initialized through 
        /// <see cref="Microsoft.ServiceBus.Messaging.QueueDescription.LockDuration" /> and 
        /// <see cref="Microsoft.ServiceBus.Messaging.SubscriptionDescription.LockDuration" /> for queues and subscriptions respectively.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.SessionLockLostException">Thrown if the lock on the session has expired. The session lock duration is the same as the message LockDuration and is an entity-wide setting. It can be initialized through 
        /// <see cref="Microsoft.ServiceBus.Messaging.QueueDescription.LockDuration" /> and 
        /// <see cref="Microsoft.ServiceBus.Messaging.SubscriptionDescription.LockDuration" /> for queues and subscriptions respectively.</exception> 
        /// <exception cref="ServerBusyException">When service bus service is 
        /// busy and is unable process the request.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessagingEntityNotFoundException">When messaging entity the 
        /// message was received from has been deleted.</exception> 
        /// <exception cref="System.UnauthorizedAccessException">When the security token provided by the 
        /// TokenProvider does not contain the claims to perform this operation.</exception> 
        /// <exception cref="System.ServiceModel.QuotaExceededException">When the number of concurrent connections 
        /// to an entity exceed the maximum allowed value.</exception> 
        //public void Defer()
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    this.EndDefer(this.BeginDefer(null, this.ReceiveContext.OperationTimeout, null, null));
        //}

        //TODO:
        /// <summary>Indicates that the receiver wants to defer the processing for this message.</summary>
        /// <param name="propertiesToModify">The key-value pair collection of properties to modify.</param>
        //public void Defer(IDictionary<string, object> propertiesToModify)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    this.EndDefer(this.BeginDefer(propertiesToModify, this.ReceiveContext.OperationTimeout, null, null));
        //}

        //TODO:
        /// <summary>Asynchronously indicates that the receiver wants to defer the processing for this message.</summary>
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task DeferAsync()
        //{
        //    return TaskHelpers.FromAsync(
        //        this.BeginDefer,
        //        this.EndDefer);
        //}

        //TODO:
        /// <summary>Asynchronously indicates that the receiver wants to defer the processing for this message.</summary>
        /// <param name="propertiesToModify">The key-value pair collection of properties to modify.</param>
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task DeferAsync(IDictionary<string, object> propertiesToModify)
        //{
        //    return TaskHelpers.FromAsync(
        //        (c, s) => this.BeginDefer(propertiesToModify, c, s),
        //        this.EndDefer);
        //}

        //TODO:
        /// <summary> Begins an asynchronous operation to defer a message. </summary>
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
        /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to 
        ///                     the <see cref="EndDefer"/> delegate when the operation is complete. </param>
        /// <returns> An <see cref="IAsyncResult"/> that references the asynchronous request to defer a message. </returns>
        /// <exception cref="ObjectDisposedException">Thrown when
        ///                                      <list type="bullet">
        ///                                                           <item>message is in disposed state.</item>
        ///                                                          <item>the receiver with which the messsage was received is in disposed state</item>
        ///                                      </list></exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received from the message server.</exception>
        //internal IAsyncResult BeginDefer(AsyncCallback callback, object state)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.BeginDefer(null, callback, state);
        //}

        //TODO:
        /// <summary> Begins an asynchronous operation to defer a message. </summary>
        /// <param name="propertiesToModify">  updates properties on the message being deadlettered. </param>     
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
        /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to 
        ///                     the <see cref="EndDefer"/> delegate when the operation is complete. </param>
        /// <returns> An <see cref="IAsyncResult"/> that references the asynchronous request to defer a message. </returns>
        /// <exception cref="ObjectDisposedException">Thrown when
        ///                                      <list type="bullet">
        ///                                                           <item>message is in disposed state.</item>
        ///                                                          <item>the receiver with which the messsage was received is in disposed state</item>
        ///                                      </list></exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received from the message server.</exception>
        //internal IAsyncResult BeginDefer(IDictionary<string, object> propertiesToModify, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.BeginDefer(propertiesToModify, this.ReceiveContext.OperationTimeout, callback, state);
        //}


        //TODO:
        /// <summary> Begins a defer. </summary>
        /// <param name="propertiesToModify"> </param>
        /// <param name="timeout">  The timeout. </param>
        /// <param name="callback"> The callback. </param>
        /// <param name="state">    The state. </param>
        /// <returns> . </returns>
        //internal IAsyncResult BeginDefer(IDictionary<string, object> propertiesToModify, TimeSpan timeout, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfDisposed();
        //    this.ThrowIfNotLocked();
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.ReceiveContext.BeginDefer(propertiesToModify, timeout, callback, state);
        //}

        /// <summary> Ends an asynchronous request to defer a message. </summary>
        /// <param name="result"> An <see cref="IAsyncResult"/> that references the Defer.  </param>
        /// <exception cref="ArgumentException">Thrown if an incorrect IAsyncResult is provided. The IAsyncResult object passed to 'End' must be the one returned from the matching 'Begin' or 
        ///                                     passed to the callback provided to 'Begin'.</exception>
        /// <exception cref="ArgumentNullException">Thrown if invoked with a Null result.</exception>
        /// <exception cref="System.ServiceModel.CommunicationException">Thrown when the queue or subscription that the message was received from is no longer present in the message server.</exception>
        /// <exception cref="TimeoutException">Thrown when operation times out. Timeout period is initialized through the <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings"/>. You
        ///                                 may need to increase the value of <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout"/> to avoid this exception if timeout value
        ///                                 is relatively low.
        ///                                 <seealso cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout"/></exception>
        /// <exception cref="MessageLockLostException">Thrown if the lock on the message has expired. LockDuration is an entity wide setting and can be initialized through
        ///                                 <see cref="QueueDescription.LockDuration"/> and <see cref="SubscriptionDescription.LockDuration"/> for Queues and Subscriptions respectively.</exception>
        /// <exception cref="SessionLockLostException">Thrown if the lock on the session has expired. Session lock durations are same as messge LockDuration and is an entity wide setting.
        ///                                 It can be initiailized throgh <see cref="QueueDescription.LockDuration"/> and <see cref="SubscriptionDescription.LockDuration"/> 
        ///                                 for Queues and Subscriptions respectively.</exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received in peek-lock mode.</exception>
        //internal void EndDefer(IAsyncResult result)
        //{
        //    this.ReceiveContext.EndDefer(result);
        //}

        /// <summary>Moves the message to the dead letter queue.</summary>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The description information for deadlettering the message.</param>
        /// <exception cref="System.ObjectDisposedException">Thrown when the message is in disposed state or 
        /// the receiver with which the message was received is in disposed state.</exception> 
        /// <exception cref="System.InvalidOperationException">Thrown when invoked on a message that has not been received from the 
        /// message server or invoked on a message that has not been received in peek-lock mode.</exception> 
        /// <exception cref="System.ServiceModel.CommunicationException">Thrown when the queue or subscription that receives 
        /// the message is no longer present in the message server.</exception> 
        /// <exception cref="System.TimeoutException">Thrown when operation times out. Timeout period is initialized through the 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings" />. You may need to increase the value of 
        /// <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout" /> to avoid this exception if timeout value is relatively low.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.MessageLockLostException">Thrown if the lock on the message has expired. LockDuration is an entity-wide setting and can be initialized through 
        /// <see cref="Microsoft.ServiceBus.Messaging.QueueDescription.LockDuration" /> and 
        /// <see cref="Microsoft.ServiceBus.Messaging.SubscriptionDescription.LockDuration" /> for Queues and Subscriptions respectively.</exception> 
        /// <exception cref="Microsoft.ServiceBus.Messaging.SessionLockLostException">Thrown if the lock on the session has expired. Session lock duration is the same as message LockDuration and is an entity-wide setting. It can be initialized through 
        /// <see cref="Microsoft.ServiceBus.Messaging.QueueDescription.LockDuration" /> and 
        /// <see cref="Microsoft.ServiceBus.Messaging.SubscriptionDescription.LockDuration" /> for Queues and Subscriptions respectively.</exception> 
        //public void DeadLetter(string deadLetterReason, string deadLetterErrorDescription)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    this.EndDeadLetter(this.BeginDeadLetter(null, deadLetterReason, deadLetterErrorDescription, this.ReceiveContext.OperationTimeout, null, null));
        //}

        /// <summary>Asynchronously moves the message to the dead letter queue.</summary>
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task DeadLetterAsync()
        //{
        //    return TaskHelpers.FromAsync(
        //        this.BeginDeadLetter,
        //        this.EndDeadLetter);
        //}

        /// <summary>Asynchronously moves the message to the dead letter queue.</summary>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The description information for deadlettering the message.</param>
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task DeadLetterAsync(string deadLetterReason, string deadLetterErrorDescription)
        //{
        //    return TaskHelpers.FromAsync(
        //        (c, s) => this.BeginDeadLetter(deadLetterReason, deadLetterErrorDescription, c, s),
        //        this.EndDeadLetter);
        //}

        /// <summary>Asynchronously moves the message to the dead letter queue.</summary>
        /// <param name="propertiesToModify">The key-value pair collection of properties to modify.</param>
        /// <returns>The asynchronous result of the operation.</returns>
        //public Task DeadLetterAsync(IDictionary<string, object> propertiesToModify)
        //{
        //    return TaskHelpers.FromAsync(
        //        (c, s) => this.BeginDeadLetter(propertiesToModify, c, s),
        //        this.EndDeadLetter);
        //}

        /// <summary>Moves the message to the dead letter queue.</summary>
        /// <param name="propertiesToModify">The key-value pair collection of properties to modify.</param>
        //public void DeadLetter(IDictionary<string, object> propertiesToModify)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    this.EndDeadLetter(this.BeginDeadLetter(propertiesToModify, null, null, this.ReceiveContext.OperationTimeout, null, null));
        //}

        /// <summary>Moves the message to the dead letter queue.</summary>
        /// <exception cref="System.ObjectDisposedException">Thrown when the message is in disposed state or 
        /// the receiver with which the message was received is in disposed state.</exception> 
        /// <exception cref="System.InvalidOperationException">Thrown when invoked on a message that has not been received from the 
        /// message server or invoked on a message that has not been received in peek-lock mode.</exception> 
        //public void DeadLetter()
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    this.EndDeadLetter(this.BeginDeadLetter(null, null, null, this.ReceiveContext.OperationTimeout, null, null));
        //}

        /// <summary> Begins an asynchronous operation to move the message to the dead letter queue. </summary>
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
        /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to 
        ///                     the EndDeadLetter delegate when the operation is complete. </param>
        /// <returns> An <see cref="IAsyncResult"/> that references the asynchronous request to dead letter the message. </returns>
        /// <exception cref="ObjectDisposedException">Thrown when
        ///                                      <list type="bullet">
        ///                                                           <item>message is in disposed state.</item>
        ///                                                          <item>the receiver with which the messsage was received is in disposed state</item>
        ///                                      </list></exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received from the message server.</exception>
        //internal IAsyncResult BeginDeadLetter(AsyncCallback callback, object state)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.BeginDeadLetter(null, null, null, this.ReceiveContext.OperationTimeout, callback, state);
        //}

        /// <summary> Begins an asynchronous operation to move the message to the dead letter queue. </summary>
        /// <param name="deadLetterReason">  The reason for deadlettering the message. </param>
        /// <param name="deadLetterErrorDescription">  The description information for deadlettering the message. </param>
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
        /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to 
        ///                     the EndDeadLetter delegate when the operation is complete. </param>
        /// <returns> An <see cref="IAsyncResult"/> that references the asynchronous request to dead letter the message. </returns>
        /// <exception cref="ObjectDisposedException">Thrown when
        ///                                      <list type="bullet">
        ///                                                           <item>message is in disposed state.</item>
        ///                                                          <item>the receiver with which the messsage was received is in disposed state</item>
        ///                                      </list></exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received from the message server.</exception>
        //internal IAsyncResult BeginDeadLetter(string deadLetterReason, string deadLetterErrorDescription, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.BeginDeadLetter(null, deadLetterReason, deadLetterErrorDescription, this.ReceiveContext.OperationTimeout, callback, state);
        //}

        /// <summary> Begins an asynchronous operation to move the message to the dead letter queue. </summary>
        /// <param name="propertiesToModify">  updates properties on the message being deadlettered. </param>        
        /// <param name="callback">An <see cref="AsyncCallback"/> delegate that references the method to invoke when the operation is complete.</param>
        /// <param name="state">A user-defined object that contains information about the receive operation. This object is passed to 
        ///                     the EndDeadLetter delegate when the operation is complete. </param>
        /// <returns> An <see cref="IAsyncResult"/> that references the asynchronous request to dead letter the message. </returns>
        /// <exception cref="ObjectDisposedException">Thrown when
        ///                                      <list type="bullet">
        ///                                                           <item>message is in disposed state.</item>
        ///                                                          <item>the receiver with which the messsage was received is in disposed state</item>
        ///                                      </list></exception>
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received from the message server.</exception>
        //internal IAsyncResult BeginDeadLetter(IDictionary<string, object> propertiesToModify, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.BeginDeadLetter(propertiesToModify, null, null, this.ReceiveContext.OperationTimeout, callback, state);
        //}

        //internal IAsyncResult BeginDeadLetter(IDictionary<string, object> propertiesToModify, string deadLetterReason, string deadLetterErrorDescription, TimeSpan timeout, AsyncCallback callback, object state)
        //{
        //    this.ThrowIfDisposed();
        //    this.ThrowIfNotLocked();
        //    this.ThrowIfReceiveContextIsNull();
        //    return this.ReceiveContext.BeginDeadLetter(propertiesToModify, deadLetterReason, deadLetterErrorDescription, timeout, callback, state);
        //}

        /// <summary> Ends an asynchronous request to move the message to the dead letter queue. </summary>
        /// <param name="result"> An <see cref="IAsyncResult"/> that references the asynchronous request to dead letter the message.  </param>
        /// <exception cref="ArgumentException">Thrown if an incorrect IAsyncResult is provided. The IAsyncResult object passed to 'End' must be the one returned from the matching 'Begin' or 
        ///                                     passed to the callback provided to 'Begin'.</exception>
        /// <exception cref="ArgumentNullException">Thrown if invoked with a Null result.</exception>
        /// <exception cref="System.ServiceModel.CommunicationException">Thrown when the queue or subscription that the message was received from is no longer present in the message server.</exception>
        /// <exception cref="TimeoutException">Thrown when operation times out. Timeout period is initialized through the <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings"/>. You
        ///                                 may need to increase the value of <see cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout"/> to avoid this exception if timeout value
        ///                                 is relatively low.
        ///                                 <seealso cref="Microsoft.ServiceBus.Messaging.MessagingFactorySettings.OperationTimeout"/></exception>
        /// <exception cref="MessageLockLostException">Thrown if the lock on the message has expired. LockDuration is an entity wide setting and can be initialized through
        ///                                 <see cref="QueueDescription.LockDuration"/> and <see cref="SubscriptionDescription.LockDuration"/> for Queues and Subscriptions respectively.</exception>
        /// <exception cref="SessionLockLostException">Thrown if the lock on the session has expired. Session lock durations are same as messge LockDuration and is an entity wide setting.
        ///                                 It can be initiailized throgh <see cref="QueueDescription.LockDuration"/> and <see cref="SubscriptionDescription.LockDuration"/> 
        ///                                 for Queues and Subscriptions respectively.</exception>        
        /// <exception cref="InvalidOperationException">Thrown when invoked on a message that has not been received in peek-lock mode.</exception>
        //internal void EndDeadLetter(IAsyncResult result)
        //{
        //    this.ReceiveContext.EndDeadLetter(result);
        //}

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>Returns a string that represents the current message.</summary>
        /// <returns>The string representation of the current message.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}{{MessageId:{1}}}", base.ToString(), this.MessageId);
        }

        internal bool HasHeader(MessageMembers headerMember)
        {
            return (this.initializedMembers & headerMember) != 0;
        }

        /// <summary> Validate message identifier. </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when messageId is null, or empty or greater than the maximum message length.
        /// </exception>
        /// <param name="messageId"> Identifier for the message. </param>
        static void ValidateMessageId(string messageId)
        {
            if (string.IsNullOrEmpty(messageId) ||
                messageId.Length > Constants.MaxMessageIdLength)
            {
                //TODO: throw FxTrace.Exception.Argument("messageId", SRClient.MessageIdIsNullOrEmptyOrOverMaxValue(Constants.MaxMessageIdLength));
                throw new ArgumentException("MessageIdIsNullOrEmptyOrOverMaxValue");
            }
        }

        /// <summary> Validate session identifier. </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when sessionId is greater than the maximum session ID length.
        /// </exception>
        /// <param name="sessionId"> Identifier for the session. </param>
        static void ValidateSessionId(string sessionId)
        {
            if (sessionId != null && sessionId.Length > Constants.MaxSessionIdLength)
            {
                //TODO: throw FxTrace.Exception.Argument("sessionId", SRClient.SessionIdIsOverMaxValue(Constants.MaxSessionIdLength));
                throw new ArgumentException("SessionIdIsOverMaxValue");
            }
        }

        static void ValidatePartitionKey(string partitionKeyPropertyName, string partitionKey)
        {
            if (partitionKey != null && partitionKey.Length > Constants.MaxPartitionKeyLength)
            {
                //TODO: throw FxTrace.Exception.Argument(partitionKeyPropertyName, SRClient.PropertyOverMaxValue(partitionKeyPropertyName, Constants.MaxPartitionKeyLength));
                throw new ArgumentException("PropertyValueOverMaxValue");
            }
        }

        static void ValidateDestination(string destination)
        {
            if (destination != null && destination.Length > Constants.MaxDestinationLength)
            {
                //TODO: throw FxTrace.Exception.Argument("Destination", SRClient.PropertyOverMaxValue("Destination", Constants.MaxDestinationLength));
                throw new ArgumentException("DestinationOverMaxValue");
            }
        }

        /// <summary>This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing 
        /// in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the XmlSchemaProviderAttribute to the class.</summary> 
        /// <returns>An XmlSchema that describes the XML representation of the object that 
        /// is produced by the WriteXml method and consumed by the ReadXml method.</returns> 
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        /// <summary>Generates an object from its XML representation. This method is reserved for internal use 
        /// and should not be used directly or indirectly (for example, using a serializer or a formatter).</summary> 
        /// <param name="reader">The XmlReader stream from which the object is deserialized.</param>
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            long deserializedHeaderSize = 0;
            reader.Read();
            reader.ReadStartElement();

            deserializedHeaderSize += this.ReadHeader(reader, SerializationTarget.Communication);
            this.bodySize = BrokeredMessage.DeserializeBodyStream(this, reader);

            reader.ReadEndElement();
            this.headerSize = deserializedHeaderSize;
        }

        /// <summary>Converts an object into its XML representation. This method is reserved for internal use 
        /// and should not be used directly or indirectly (e.g. using a serializer or a formatter).</summary> 
        /// <param name="writer">The XmlWriter stream to which the object is serialized.</param>
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            long serializedHeaderSize = 8;
            writer.WriteStartElement("Message");

            serializedHeaderSize += this.WriteHeader(writer, SerializationTarget.Communication);
            this.bodySize = BrokeredMessage.SerializeBodyStream(this, writer);

            writer.WriteEndElement();
            this.headerSize = serializedHeaderSize;
        }

        /// <summary>Clones a message, so that it is possible to send a clone of a message as a new message.</summary>
        /// <returns>The <see cref="BrokeredMessage" /> that contains the cloned message.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "Safe here. Any future behavior change is easy to detect")]
        public BrokeredMessage Clone()
        {
            this.ThrowIfDisposed();

            return new BrokeredMessage(this, clientSideCloning: true);
        }

        /// <summary> Gets a header stream. </summary>
        /// <param name="bufferManager"> Manager for buffer. </param>    
        /// <param name="serializationTarget"></param>    
        /// <returns> The header stream. </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "Safe here. Any future behavior change is easy to detect")]
        internal BufferedInputStream GetHeaderStream(InternalBufferManager bufferManager, SerializationTarget serializationTarget)
        {
            if (this.headerStream == null)
            {
                lock (this.headerSerializationSyncObject)
                {
                    if (this.headerStream == null)
                    {
                        try
                        {
                            using (BufferedOutputStream stream = new BufferedOutputStream(headerStreamInitialSize, this.HeaderStreamMaxSize, bufferManager))
                            {
                                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(stream))
                                {
                                    writer.WriteStartElement("MessageHeaders");
                                    this.WriteHeader(writer, serializationTarget);
                                    writer.WriteEndElement();
                                    writer.Flush();
                                    int bytesSize;
                                    byte[] data = stream.ToArray(out bytesSize);
                                    this.headerStream = new BufferedInputStream(data, bytesSize, bufferManager);
                                    this.headerSize = this.headerStream.Length;
                                }

                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            throw Fx.Exception.AsError(
                                new SerializationException(e.Message, e));
                        }
                    }
                }
            }

            return this.headerStream;
        }

        // TODO: 219361 - Get rid of this.
        // This is a temporary method that is used to set the HeaderSize
        // instance member of the BrokeredMessage. This HeaderSize represents
        // the "official" quota usage of the header for the lifetime of the message.
        // In M4, we want to avoid serializing the set of header properties twice.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "Safe here. Any future behavior change is easy to detect")]
        internal void SetHeaderStreamSize(SerializationTarget serializationTarget)
        {
            if (this.headerStream == null)
            {
                lock (this.headerSerializationSyncObject)
                {
                    if (this.headerStream == null)
                    {
                        using (MemoryStream stream = new MemoryStream(headerStreamInitialSize))
                        {
                            using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(stream, null, null, false))
                            {
                                writer.WriteStartElement("MessageHeaders");
                                this.WriteHeader(writer, serializationTarget);
                                writer.WriteEndElement();
                            }

                            this.headerSize = stream.Length;
                        }
                    }
                }
            }
        }

        internal long GetSerializedSize(SerializationTarget serializationTarget)
        {
            if (this.headerSize == 0)
            {
                lock (this.headerSerializationSyncObject)
                {
                    if (this.headerSize == 0)
                    {
                        this.headerSize = BrokeredMessage.CalculateSerializedHeadersSize(this, serializationTarget) +
                            BrokeredMessage.CalculateSerializedPropertiesSize(this);
                    }
                }
            }

            return this.headerSize + this.BodySize;
        }

        internal object ClearBodyObject()
        {
            object obj = this.bodyObject;
            this.bodyObject = null;
            return obj;
        }

        internal void ClearPartitionId()
        {
            this.partitionId = default(short);
            this.ClearInitializedMember(MessageMembers.PartitionId);
        }

        /// <summary>
        /// Attached an IDisposable object to the BrokeredMessage which should be disposed when the message itself is disposed
        /// </summary>
        /// <param name="disposables"></param>
        internal void AttachDisposables(IEnumerable<IDisposable> disposables)
        {
            if (disposables == null)
            {
                return;
            }

            if (this.attachedDisposables == null)
            {
                lock (this.disposablesSyncObject)
                {
                    if (this.attachedDisposables == null)
                    {
                        this.attachedDisposables = new List<IDisposable>(4);
                    }

                    this.attachedDisposables.AddRange(disposables);
                    return;
                }
            }

            lock (this.disposablesSyncObject)
            {
                this.attachedDisposables.AddRange(disposables);
            }
        }

        /// <summary> Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources. </summary>
        /// <param name="disposing"> true if resources should be disposed, false if not. </param>
        void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.PrefilteredHeaders != null)
                    {
                        this.PrefilteredHeaders.Dispose();
                        this.PrefilteredHeaders = null;
                    }

                    if (this.PrefilteredProperties != null)
                    {
                        this.PrefilteredProperties.Dispose();
                        this.PrefilteredProperties = null;
                    }

                    if (this.headerStream != null)
                    {
                        this.headerStream.Dispose();
                        this.headerStream = null;
                    }

                    if (this.rawHeaderStream != null && this.ownsRawHeaderStream)
                    {
                        this.rawHeaderStream.Dispose();
                        this.rawHeaderStream = null;
                    }

                    if (this.BodyStream != null && this.ownsBodyStream)
                    {
                        this.BodyStream.Dispose();
                        this.BodyStream = null;
                    }

                    this.bodyObject = null;

                    if (this.attachedDisposables != null)
                    {
                        foreach (IDisposable disposable in this.attachedDisposables)
                        {
                            disposable.Dispose();
                        }
                    }
                }

                this.disposed = true;
            }
        }

        static Type GetObjectType(object value)
        {
            return (value == null) ? typeof(object) : value.GetType();
        }

        /// <summary> Deserialize body stream. </summary>
        /// <exception cref="Exception"> Thrown when as error. </exception>
        /// <param name="message"> The message. </param>
        /// <param name="reader">
        /// The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.
        /// </param>
        /// <returns>return the size of the body stream in bytes</returns>
        static long DeserializeBodyStream(BrokeredMessage message, XmlReader reader)
        {
            byte[] fieldIdLengthBytes = BrokeredMessage.ReadBytes(reader, 9);

            long streamSize = BitConverter.ToInt64(fieldIdLengthBytes, 1);
            if (streamSize == 0)
            {
                return streamSize;
            }

            int bufferSize = MinMessageBufferSize;

            while (streamSize > bufferSize)
            {
                bufferSize *= 2;
            }

            InternalBufferManager bufferManager = ThrottledBufferManager.GetBufferManager();
            using (BufferedOutputStream outputStream = new BufferedOutputStream(bufferSize, Int32.MaxValue, bufferManager))
            {
                byte[] bodyBytes = bufferManager.TakeBuffer(bufferSize);
                long bytesRead = 0;

                try
                {
                    while (true)
                    {
                        int lastReadCount = reader.ReadContentAsBase64(bodyBytes, 0, bodyBytes.Length);

                        if (lastReadCount == 0)
                        {
                            break;
                        }

                        bytesRead += lastReadCount;
                        outputStream.Write(bodyBytes, 0, lastReadCount);
                    }
                }
                finally
                {
                    bufferManager.ReturnBuffer(bodyBytes);
                }

                int bytesSize;
                byte[] data = outputStream.ToArray(out bytesSize);
                message.BodyStream = new BufferedInputStream(data, bytesSize, bufferManager);
                message.ownsBodyStream = true;

                if (streamSize > 0 && bytesRead != streamSize)
                {
                    //TODO: throw Fx.Exception.AsError(new InvalidOperationException(SRClient.FailedToDeSerializeEntireBodyStream));
                    throw new InvalidOperationException("FailedToDeSerializeEntireBodyStream");
                }

                return bytesRead;
            }
        }

        static long DeserializeVersionAndFlagsFromBinary(BrokeredMessage message, XmlReader reader)
        {
            //Read the first four bytes that are messageVersion flags of the incoming message
            int version = BitConverter.ToInt32(BrokeredMessage.ReadBytes(reader, 4), 0);

            // Read off the next two bytes that are message flags.
            byte[] flags = BrokeredMessage.ReadBytes(reader, 2);

            if (message != null)
            {
                message.version = version;
                message.messageFormat = (BrokeredMessageFormat)flags[0];
            }

            return 6; // Version and flags
        }

        /// <summary> Deserialize headers from binary. </summary>
        /// <param name="message"> The message. </param>
        /// <param name="reader">
        /// The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.
        /// </param>
        internal static long DeserializeHeadersFromBinary(BrokeredMessage message, XmlReader reader)
        {
            long headerSizeInBytes = 2; // Header count

            int headerCount = BitConverter.ToInt16(BrokeredMessage.ReadBytes(reader, 2), 0);
            for (int i = 0; i < headerCount; i++)
            {
                byte[] fieldIdLength = BrokeredMessage.ReadBytes(reader, 3);

                int memberLength = BitConverter.ToInt16(fieldIdLength, 1);
                byte[] value = BrokeredMessage.ReadBytes(reader, memberLength);

                if (message != null)
                {
                    message.SetMessageHeader(fieldIdLength[0], value, message.version > BrokeredMessage.MessageVersion);
                }

                headerSizeInBytes += fieldIdLength.Length + value.Length;
            }

            return headerSizeInBytes;
        }

        /// <summary> Deserialize properties from binary. </summary>
        /// <param name="message"> The message. </param>
        /// <param name="reader">
        /// The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.
        /// </param>
        internal static long DeserializePropertiesFromBinary(BrokeredMessage message, XmlReader reader)
        {
            long propertiesSizeInBytes = 4;
            byte[] propertyHeaders = BrokeredMessage.ReadBytes(reader, 3);

            short propertyCount = BitConverter.ToInt16(propertyHeaders, 1);

            if (propertyCount > 0)
            {
                bool ignoreUnknown = message.version > BrokeredMessage.MessageVersion;
                for (short i = 0; i < propertyCount; i++)
                {
                    byte[] lengthBytes = BrokeredMessage.ReadBytes(reader, 2);
                    int nameLength = BitConverter.ToInt16(lengthBytes, 0);

                    byte[] nameBytes = BrokeredMessage.ReadBytes(reader, nameLength);
                    string key = Encoding.UTF8.GetString(nameBytes);

                    int valueType = BrokeredMessage.ReadBytes(reader, 1)[0];
                    propertiesSizeInBytes += 2 + nameLength + 1;
                    object value = null;
                    int valueLength = 0;

                    if (valueType != (int)PropertyValueType.Null)
                    {
                        lengthBytes = BrokeredMessage.ReadBytes(reader, 2);
                        valueLength = BitConverter.ToInt16(lengthBytes, 0);
                        byte[] valueBytes = BrokeredMessage.ReadBytes(reader, valueLength);
                        propertiesSizeInBytes += valueLength + 2;
                        if (valueType < (int)PropertyValueType.Unknown || !ignoreUnknown)
                        {
                            value = SerializationUtilities.ConvertByteArrayToNativeValue(message.version, (PropertyValueType)valueType, valueBytes);
                        }
                    }

                    if (valueType == (int)PropertyValueType.Null || value != null)
                    {
                        message.InternalProperties.Add(key, value);
                    }
                }
            }

            return propertiesSizeInBytes;
        }

        /// <summary> Reads the bytes. </summary>
        /// <exception cref="Exception"> Thrown when as error. </exception>
        /// <param name="reader">
        /// The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.
        /// </param>
        /// <param name="bytesToRead"> The bytes to read. </param>
        /// <returns> The bytes. </returns>
        static byte[] ReadBytes(XmlReader reader, int bytesToRead)
        {
            byte[] bytes = SerializationUtilities.ReadBytes(reader, bytesToRead);
            return bytes;
        }

        /// <summary> Serialize body stream. </summary>
        /// <exception cref="Exception"> Thrown when as error. </exception>
        /// <param name="message"> The message. </param>
        /// <param name="writer">
        /// The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.
        /// </param>
        internal static long SerializeBodyStream(BrokeredMessage message, XmlWriter writer)
        {
            // BodyStream: Field-code, body-length(-1), body-bytes
            writer.WriteBase64(new byte[] { (byte)FieldId.BodyStream }, 0, 1);

            long streamLength = 0;
            if (message.BodyStream != null)
            {
                streamLength = message.BodyStream.CanSeek ? message.BodyStream.Length : -1;
            }

            writer.WriteBase64(BitConverter.GetBytes(streamLength), 0, 8);

            if (streamLength != 0)
            {
                if (message.BodyStream.CanSeek)
                {
                    if (message.BodyStream.Position != 0)
                    {
                        //TODO: throw Fx.Exception.AsError(new InvalidOperationException(SRClient.CannotSerializeMessageWithPartiallyConsumedBodyStream));
                        throw new InvalidOperationException("CannotSerializeMessageWithPartiallyConsumedBodyStream");
                    }
                }

                byte[] bodyBytes = new byte[1024];
                long totalBytesRead = 0;

                while (true)
                {
                    int bytesRead = message.BodyStream.Read(bodyBytes, 0, bodyBytes.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    totalBytesRead += bytesRead;
                    writer.WriteBase64(bodyBytes, 0, bytesRead);
                }

                if (streamLength > 0 && totalBytesRead != streamLength)
                {
                    //TODO: throw Fx.Exception.AsError(new InvalidOperationException(SRClient.FailedToSerializeEntireBodyStream));
                    throw new InvalidOperationException("FailedToSerializeEntireBodyStream");
                }

                return totalBytesRead;
            }

            return 0;
        }

        static long SerializeVersionAndFlagsAsBinary(BrokeredMessage message, XmlWriter writer)
        {
            long headerSizeInBytes = 6; // Version: 4-bytes, flags: 2-bytes

            writer.WriteBase64(BitConverter.GetBytes(message.version), 0, 4);
            writer.WriteBase64(new byte[] { (byte)message.messageFormat, 0 }, 0, 2);

            return headerSizeInBytes;
        }

        /// <summary> Serialize headers as binary. </summary>
        /// <exception cref="Exception"> Thrown when as error. </exception>
        /// <param name="message"> The message. </param>
        /// <param name="writer">
        /// The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.
        /// </param>
        /// <param name="serializationTarget"></param>
        internal static long SerializeHeadersAsBinary(BrokeredMessage message, XmlWriter writer, SerializationTarget serializationTarget)
        {
            long headerSizeInBytes = 2; // header count

            writer.WriteBase64(BitConverter.GetBytes(message.GetHeaderCount()), 0, 2);

            // Message headers: Field-code, Length-in-bytes, bytes
            byte[] fieldIdLengthBytes = new byte[3];
            foreach (BinarySerializationItem item in BrokeredMessage.binarySerializationItems)
            {
                if (item.ShouldSerialize(message, serializationTarget))
                {
                    fieldIdLengthBytes[0] = (byte)item.FieldId;

                    // Length
                    byte[] valueBytes = item.Extractor(message, serializationTarget);
                    if (valueBytes.Length > Constants.MaximumMessageHeaderPropertySize)
                    {
                        //TODO:  throw Fx.Exception.AsError(new SerializationException(SRClient.ExceededMessagePropertySizeLimit(item.FieldId.ToString(), Constants.MaximumMessageHeaderPropertySize)));
                        throw new SerializationException("ExceededMessagePropertySizeLimit");
                    }

                    fieldIdLengthBytes[1] = (byte)(valueBytes.Length & 0xFF);
                    fieldIdLengthBytes[2] = (byte)((valueBytes.Length & 0xFF00) >> 8);

                    headerSizeInBytes += valueBytes.Length + 3;
                    writer.WriteBase64(fieldIdLengthBytes, 0, 3);
                    writer.WriteBase64(valueBytes, 0, valueBytes.Length);
                }
            }

            writer.Flush();
            return headerSizeInBytes;
        }

        /// <summary> Serialize properties as binary. </summary>
        /// <exception cref="Exception"> Thrown when as error. </exception>
        /// <param name="message"> The message. </param>
        /// <param name="writer">
        /// The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.
        /// </param>
        internal static long SerializePropertiesAsBinary(BrokeredMessage message, XmlWriter writer)
        {
            long propertySizeInBytes = 1;
            // Properties: Field-code, property-count, {<name-length><name>, <type-id>, <value-length><value>}*
            writer.WriteBase64(new byte[] { (byte)FieldId.Properties }, 0, 1);

            if (message.Properties.Count > short.MaxValue)
            {
                //TODO: throw Fx.Exception.AsError(new SerializationException(SRClient.TooManyMessageProperties(short.MaxValue, message.Properties.Count)));
                throw new SerializationException("TooManyMessageProperties");
            }

            propertySizeInBytes += 2;
            writer.WriteBase64(BitConverter.GetBytes((short)message.Properties.Count), 0, 2);

            byte[] propTypeLength = new byte[3];
            if (message.Properties.Count > 0)
            {
                foreach (KeyValuePair<string, object> entry in message.Properties)
                {
                    byte[] nameBytes = Encoding.UTF8.GetBytes(entry.Key);

                    if (nameBytes.Length > Int16.MaxValue)
                    {
                        //TODO: throw Fx.Exception.AsError(new SerializationException(SRClient.ExceededMessagePropertySizeLimit(entry.Key, Int16.MaxValue)));
                        throw new SerializationException("ExceededMessagePropertySizeLimit");
                    }

                    propertySizeInBytes += nameBytes.Length + 2;
                    writer.WriteBase64(BitConverter.GetBytes((short)nameBytes.Length), 0, 2);
                    writer.WriteBase64(nameBytes, 0, nameBytes.Length);

                    PropertyValueType typeId = SerializationUtilities.GetTypeId(entry.Value);
                    propTypeLength[0] = (byte)typeId;

                    if (typeId != PropertyValueType.Null)
                    {
                        byte[] valueBytes = SerializationUtilities.ConvertNativeValueToByteArray(message.version, typeId, entry.Value);

                        if (valueBytes.Length > Int16.MaxValue)
                        {
                            //TODO: throw Fx.Exception.AsError(new SerializationException(SRClient.ExceededMessagePropertySizeLimit(entry.Key, Int16.MaxValue)));
                            throw new SerializationException("ExceededMessagePropertySizeLimit");
                        }

                        propTypeLength[1] = (byte)(valueBytes.Length & 0xFF);
                        propTypeLength[2] = (byte)((valueBytes.Length & 0xFF00) >> 8);
                        propertySizeInBytes += valueBytes.Length + 3;
                        writer.WriteBase64(propTypeLength, 0, 3);
                        writer.WriteBase64(valueBytes, 0, valueBytes.Length);
                    }
                    else
                    {
                        // Just write: PropertyTypeId.Null
                        propertySizeInBytes += 1;
                        writer.WriteBase64(propTypeLength, 0, 1);
                    }
                }

                writer.Flush();
            }

            return propertySizeInBytes;
        }

        static long CalculateSerializedHeadersSize(BrokeredMessage message, SerializationTarget serializationTarget)
        {
            long headerSizeInBytes = 0;

            // Version: 4-bytes, flags: 2-bytes
            headerSizeInBytes += 4 + BrokeredMessage.messageFlags.Length + 2;

            // Message headers: Field-code, Length-in-bytes, bytes
            foreach (BinarySerializationItem item in BrokeredMessage.binarySerializationItems)
            {
                if (item.ShouldSerialize(message, serializationTarget))
                {
                    headerSizeInBytes += 1 + 2 + item.CalculateSize(message);
                }
            }

            return headerSizeInBytes;
        }

        static long CalculateSerializedPropertiesSize(BrokeredMessage message)
        {
            // Properties: Field-code, property-count, {<name-length><name>, <type-id>, <value-length><value>}*
            long propertySizeInBytes = 1 + 2;

            if (message.Properties.Count > 0)
            {
                foreach (KeyValuePair<string, object> entry in message.Properties)
                {
                    propertySizeInBytes += 2 + SerializationUtilities.GetStringSize(entry.Key);
                    propertySizeInBytes++;  // type-id

                    PropertyValueType typeId = SerializationUtilities.GetTypeId(entry.Value);
                    if (typeId != PropertyValueType.Null)
                    {
                        byte[] valueBytes = SerializationUtilities.ConvertNativeValueToByteArray(message.version, typeId, entry.Value);
                        propertySizeInBytes += 2 + valueBytes.Length;
                    }
                }
            }

            return propertySizeInBytes;
        }

        void ClearInitializedMember(MessageMembers memberToClear)
        {
            this.initializedMembers &= ~memberToClear;
        }

        void SetGetBodyCalled()
        {
            if (1 == Interlocked.Exchange(ref this.getBodyCalled, 1))
            {
                //TODO: throw Fx.Exception.AsError(new InvalidOperationException(SRClient.MessageBodyConsumed));
                throw new InvalidOperationException("MessageBodyConsumed");
            }
        }

        /// <summary> Copies the message headers described by originalMessage. </summary>
        /// <param name="originalMessage"> Message describing the original. </param>
        /// <param name="clientSideCloning"> specific if it is a client side initialized code path.</param>
        void CopyMessageHeaders(BrokeredMessage originalMessage, bool clientSideCloning = false)
        {
            this.messageFormat = originalMessage.messageFormat;
            this.headersDeserialized = true;
            this.MessageId = originalMessage.MessageId;
            this.headerSize = originalMessage.HeaderSize;

            if ((originalMessage.InitializedMembers & MessageMembers.SessionId) != 0)
            {
                this.CopySessionId(originalMessage.SessionId);
            }

            if ((originalMessage.initializedMembers & MessageMembers.PartitionKey) != 0)
            {
                this.CopyPartitionKey(originalMessage.PartitionKey);
            }

            if ((originalMessage.initializedMembers & MessageMembers.ViaPartitionKey) != 0)
            {
                this.ViaPartitionKey = originalMessage.ViaPartitionKey;
            }

            if ((originalMessage.InitializedMembers & MessageMembers.ScheduledEnqueueTimeUtc) != 0)
            {
                this.ScheduledEnqueueTimeUtc = originalMessage.ScheduledEnqueueTimeUtc;
            }

            if ((originalMessage.InitializedMembers & MessageMembers.TimeToLive) != 0)
            {
                this.TimeToLive = originalMessage.TimeToLive;
            }

            string originalMessageLabel = originalMessage.Label;
            if (originalMessageLabel != null)
            {
                this.Label = originalMessageLabel;
            }

            if (originalMessage.CorrelationId != null)
            {
                this.CorrelationId = originalMessage.CorrelationId;
            }

            if (originalMessage.ReplyTo != null)
            {
                this.ReplyTo = originalMessage.ReplyTo;
            }

            if (originalMessage.To != null)
            {
                this.To = originalMessage.To;
            }

            if ((originalMessage.InitializedMembers & MessageMembers.ReplyToSessionId) != 0)
            {
                this.ReplyToSessionId = originalMessage.ReplyToSessionId;
            }

            if (originalMessage.ContentType != null)
            {
                this.ContentType = originalMessage.ContentType;
            }

            if ((originalMessage.InitializedMembers & MessageMembers.ForcePersistence) != 0)
            {
                this.ForcePersistence = originalMessage.ForcePersistence;
            }

            foreach (KeyValuePair<string, object> property in originalMessage.Properties)
            {
                this.InternalProperties.Add(property);
            }

            // Destination property is intended to be made public eventually.
            // So it gets cloned even in client side cloning.
            if ((originalMessage.initializedMembers & MessageMembers.Destination) != 0)
            {
                this.Destination = originalMessage.Destination;
            }

            // Publisher property is intended to be made public eventually.
            // So it gets cloned even in client side cloning.
            if (originalMessage.Publisher != null)
            {
                this.Publisher = originalMessage.Publisher;
            }

            // Copy any internal properties (which cannot be set through public API)
            // only when it's not client side cloning (which is invoked using public API).
            if (!clientSideCloning)
            {
                if ((originalMessage.InitializedMembers & MessageMembers.PartitionId) != 0)
                {
                    this.PartitionId = originalMessage.PartitionId;
                }

                ReceiverHeaders originalMessageReceiverHeaders = originalMessage.receiverHeaders;
                if (originalMessageReceiverHeaders != null)
                {
                    // Don't copy LockToken or LockedUntilUtc
                    this.BodyId = originalMessage.BodyId;
                    this.DeliveryCount = originalMessageReceiverHeaders.DeliveryCount;
                    this.SequenceNumber = originalMessageReceiverHeaders.SequenceNumber;
                    this.EnqueuedTimeUtc = originalMessage.EnqueuedTimeUtc;
                    this.EnqueuedSequenceNumber = originalMessageReceiverHeaders.EnqueuedSequenceNumber;
                }

                if ((originalMessage.initializedMembers & MessageMembers.PrefilteredHeaders) != 0)
                {
                    this.PrefilteredHeaders = BrokeredMessage.CloneStream(originalMessage.PrefilteredHeaders);
                }

                if ((originalMessage.initializedMembers & MessageMembers.PrefilteredProperties) != 0)
                {
                    this.PrefilteredProperties = BrokeredMessage.CloneStream(originalMessage.PrefilteredProperties);
                }

                if ((originalMessage.initializedMembers & MessageMembers.DeadLetterSource) != 0)
                {
                    this.DeadLetterSource = originalMessage.DeadLetterSource;
                }

                if ((originalMessage.initializedMembers & MessageMembers.TransferDestination) != 0)
                {
                    this.TransferDestination = originalMessage.TransferDestination;
                }

                if ((originalMessage.initializedMembers & MessageMembers.TransferDestinationEntityId) != 0)
                {
                    this.TransferDestinationResourceId = originalMessage.TransferDestinationResourceId;
                }

                if ((originalMessage.initializedMembers & MessageMembers.TransferSessionId) != 0)
                {
                    this.TransferSessionId = originalMessage.TransferSessionId;
                }

                if ((originalMessage.initializedMembers & MessageMembers.TransferSource) != 0)
                {
                    this.TransferSource = originalMessage.TransferSource;
                }

                if ((originalMessage.InitializedMembers & MessageMembers.TransferSequenceNumber) != 0)
                {
                    this.TransferSequenceNumber = originalMessage.TransferSequenceNumber;
                }

                if ((originalMessage.InitializedMembers & MessageMembers.TransferHopCount) != 0)
                {
                    this.TransferHopCount = originalMessage.TransferHopCount;
                }

                if ((originalMessage.InitializedMembers & MessageMembers.MessageState) != 0)
                {
                    this.State = originalMessage.State;
                }
            }
        }

        /// <summary> Ensures that header deserialized. </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times",
            Justification = "Safe here. Any future behavior change is easy to detect")]
        internal void EnsureHeaderDeserialized()
        {
            // For EventHub case, there are no messages headers that need to be deserialized.
            if (this.messageFormat == BrokeredMessageFormat.AmqpEventData)
            {
                return;
            }

            // The whole point of the headersDeserialized bool is to ensure that
            // if we created a BrokeredMessage through the internal 
            // CreateMessage(BufferedInputStream headerStream, Stream bodyStream) or 
            // BrokeredMessage(headerStream, bodyStream) constructor, we first deserialize
            // the header before allow access to message properties.
            if (!this.headersDeserialized)
            {
                lock (this.headerSerializationSyncObject)
                {
                    if (!this.headersDeserialized)
                    {
                        this.ThrowIfDisposed();

                        using (BufferedInputStream clonedHeaderStream = (BufferedInputStream)this.headerStream.Clone())
                        {
                            using (XmlDictionaryReader xmlReader = XmlDictionaryReader.CreateBinaryReader(clonedHeaderStream, XmlDictionaryReaderQuotas.Max))
                            {
                                xmlReader.Read();
                                xmlReader.ReadStartElement();
                                this.ReadHeader(xmlReader, SerializationTarget.Storing);
                                xmlReader.ReadEndElement();
                            }
                        }
                    }

                    this.headersDeserialized = true;
                }
            }
        }

        internal long ReadHeader(XmlReader reader, SerializationTarget serializationTarget)
        {
            long size = 0;

            size += BrokeredMessage.DeserializeVersionAndFlagsFromBinary(this, reader);
            this.messageEncoder = this.messageEncoder ?? BrokeredMessageEncoder.GetEncoder(this.messageFormat);
            size += this.messageEncoder.ReadHeader(reader, this, serializationTarget);

            return size;
        }

        internal long WriteHeader(XmlWriter writer, SerializationTarget serializationTarget)
        {
            long size = 0;

            size += BrokeredMessage.SerializeVersionAndFlagsAsBinary(this, writer);
            this.messageEncoder = this.messageEncoder ?? BrokeredMessageEncoder.GetEncoder(this.messageFormat);
            size += this.messageEncoder.WriteHeader(writer, this, serializationTarget);

            return size;
        }

        internal object GetSystemProperty(string propertyName)
        {
            return SystemPropertyAccessorDictionary[propertyName](this);
        }

        // All properties added or changed by the broker should be done thru this method
        internal void BrokerUpdateProperty(string name, object value)
        {
            this.Properties[name] = value;
            this.SetPropertiesAsModifiedByBroker();
        }

        // All properties removed by the broker should be done thru this method
        internal void BrokerRemoveProperty(string name)
        {
            this.Properties.Remove(name);
            this.SetPropertiesAsModifiedByBroker();
        }

        internal void ResetPropertiesAsModifiedByBroker()
        {
            this.arePropertiesModifiedByBroker = false;
        }

        internal void SetPropertiesAsModifiedByBroker()
        {
            this.arePropertiesModifiedByBroker = true;
        }

        internal void CopySessionId(string sessionId)
        {
            BrokeredMessage.ValidateSessionId(sessionId);
            this.sessionId = sessionId;
            if (sessionId == null)
            {
                this.ClearInitializedMember(MessageMembers.SessionId);
            }
            else
            {
                this.initializedMembers |= MessageMembers.SessionId;
            }
        }

        internal void CopyPartitionKey(string partitionKey)
        {
            BrokeredMessage.ValidatePartitionKey("PartitionKey", partitionKey);
            this.partitionKey = partitionKey;
            if (partitionKey == null)
            {
                this.ClearInitializedMember(MessageMembers.PartitionKey);
            }
            else
            {
                this.initializedMembers |= MessageMembers.PartitionKey;
            }
        }

        internal void DownGradeToVersion1()
        {
            this.version = BrokeredMessage.MessageVersion1;

            this.initializedMembers = this.initializedMembers & BrokeredMessage.V1MessageMembers;

            List<string> unsupportedTypes = new List<string>(8);
            foreach (KeyValuePair<string, object> pair in this.Properties)
            {
                if (pair.Value is Stream)
                {
                    unsupportedTypes.Add(pair.Key);
                }
            }

            foreach (string key in unsupportedTypes)
            {
                this.Properties.Remove(key);
            }
        }

        internal bool IsMembersSet(MessageMembers members)
        {
            bool membersSet = ((this.InitializedMembers & members) != 0);

            return membersSet;
        }

        /// <summary> Ensures that receiver headers. </summary>
        void EnsureReceiverHeaders()
        {
            if (this.receiverHeaders == null)
            {
                this.receiverHeaders = new ReceiverHeaders();
            }
        }

        /// <summary> Gets the header count. </summary>
        /// <returns> The header count. </returns>
        short GetHeaderCount()
        {
            // Get the count of number of headers set explicitly
            int value = (int)this.initializedMembers;

            short count = 0;
            while (value != 0)
            {
                count++;
                value &= value - 1;
            }

            return count;
        }

        void SetMessageHeader(byte memberId, byte[] value, bool ignoreUnknown)
        {
            switch (memberId)
            {
                case (byte)FieldId.MessageId:
                    this.MessageId = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.CorrelationId:
                    this.CorrelationId = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.SessionId:
                    this.CopySessionId((string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value));
                    break;

                case (byte)FieldId.EnqueuedTimeUtc:
                    this.EnqueuedTimeUtc = (DateTime)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.DateTime, value);
                    break;

                case (byte)FieldId.ScheduledEnqueueTimeUtc:
                    this.ScheduledEnqueueTimeUtc = (DateTime)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.DateTime, value);
                    break;

                case (byte)FieldId.TimeToLive:
                    this.TimeToLive = (TimeSpan)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.TimeSpan, value);
                    break;

                case (byte)FieldId.ReplyTo:
                    this.ReplyTo = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.ReplyToSessionId:
                    this.ReplyToSessionId = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.To:
                    this.To = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.SequenceNumber:
                    this.SequenceNumber = (long)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Int64, value);
                    break;

                case (byte)FieldId.LockToken:
                    this.LockToken = (Guid)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Guid, value);
                    break;

                case (byte)FieldId.LockedUntilUtc:
                    this.LockedUntilUtc = (DateTime)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.DateTime, value);
                    break;

                case (byte)FieldId.DeliveryCount:
                    this.DeliveryCount = (int)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Int32, value);
                    break;

                case (byte)FieldId.PartitionKey:
                    this.CopyPartitionKey((string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value));
                    break;

                case (byte)FieldId.Label:
                    this.Label = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.ContentType:
                    this.ContentType = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.PrefilteredMessageHeaders:
                    this.PrefilteredHeaders = (Stream)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Stream, value);
                    break;

                case (byte)FieldId.PrefilteredMessageProperties:
                    this.PrefilteredProperties = (Stream)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Stream, value);
                    break;

                case (byte)FieldId.DeadLetterSource:
                    this.DeadLetterSource = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.TransferDestination:
                    this.TransferDestination = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.TransferDestinationResourceId:
                    this.TransferDestinationResourceId = (long)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Int64, value);
                    break;

                case (byte)FieldId.TransferSessionId:
                    this.TransferSessionId = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.TransferSource:
                    this.TransferSource = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.TransferSequenceNumber:
                    this.TransferSequenceNumber = (long)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Int64, value);
                    break;

                case (byte)FieldId.TransferHopCount:
                    this.TransferHopCount = (int)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Int32, value);
                    break;

                case (byte)FieldId.MessageState:
                    this.State = (MessageState)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Int32, value);
                    break;

                case (byte)FieldId.EnqueuedSequenceNumber:
                    this.EnqueuedSequenceNumber = (long)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Int64, value);
                    break;

                case (byte)FieldId.PartitionId:
                    this.PartitionId = (short)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Int16, value);
                    break;

                case (byte)FieldId.ViaPartitionKey:
                    this.ViaPartitionKey = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.Destination:
                    this.Destination = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                case (byte)FieldId.ForcePersistence:
                    this.ForcePersistence = (bool)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.Boolean, value);
                    break;

                case (byte)FieldId.Publisher:
                    this.Publisher = (string)SerializationUtilities.ConvertByteArrayToNativeValue(this.version, PropertyValueType.String, value);
                    break;

                default:
                    if (ignoreUnknown)
                    {
                        break;
                    }

                    //TODO: throw FxTrace.Exception.ArgumentOutOfRange("memberId", memberId, String.Empty);
                    throw new ArgumentOutOfRangeException("memberId");
            }
        }

        /// <summary> Throw if not locked. </summary>
        /// <exception cref="Exception"> Thrown when as error. </exception>
        //void ThrowIfNotLocked()
        //{
        //    if (this.receiverHeaders == null || this.receiverHeaders.LockToken == Guid.Empty)
        //    {
        //        if (this.ReceiveContext != null && this.ReceiveContext.MessageReceiver != null && this.ReceiveContext.MessageReceiver.Mode == ReceiveMode.ReceiveAndDelete)
        //        {
        //            //throw FxTrace.Exception.AsError(new InvalidOperationException(SRClient.PeekLockModeRequired));
        //            throw new InvalidOperationException("PeekLockModeRequired");
        //        }
        //        else
        //        {
        //            throw Fx.Exception.AsError(new InvalidOperationException());
        //        }
        //    }
        //}

        //TODO
        //void ThrowIfReceiveContextIsNull()
        //{
        //    //TODO: this.ThrowIfReceiveContextIsNull(SRClient.ReceiveContextNull);
        //    this.ThrowIfReceiveContextIsNull("ReceiveContextNull");
        //}

        /// <summary> Throw if receive context is null. </summary>
        /// <exception cref="Fx.Exception"> Thrown when as error. </exception>
        //void ThrowIfReceiveContextIsNull(string message)
        //{
        //    if (this.receiveContext == null)
        //    {
        //        throw Fx.Exception.AsError(new InvalidOperationException(message));
        //    }
        //}

        /// <summary> Throw if disposed. </summary>
        /// <exception cref="Fx.Exception"> Thrown when object disposed. </exception>
        void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                //TODO: throw Fx.Exception.ObjectDisposed("BrokeredMessage has been disposed.");
                throw new ObjectDisposedException("BrokeredMessage has been disposed.");
            }
        }

        /// <summary> Throw if not received. </summary>
        /// <exception cref="Fx.Exception"> Thrown when as error. </exception>
        void ThrowIfNotReceived()
        {
            if (this.receiverHeaders == null)
            {
                throw Fx.Exception.AsError(new InvalidOperationException());
            }
        }

        void ThrowIfDominatingPropertyIsNotEqualToNonNullDormantProperty(MessageMembers dominatingProperty, MessageMembers dormantProperty, string dominatingPropsValue, string dormantPropsValue)
        {
            if ((this.initializedMembers & dormantProperty) != 0 && !string.Equals(dominatingPropsValue, dormantPropsValue))
            {
                //TODO: throw FxTrace.Exception.AsError(new InvalidOperationException(SRClient.DominatingPropertyMustBeEqualsToNonNullDormantProperty(dominatingProperty, dormantProperty)));
                throw new InvalidOperationException("DominatingPropertyMustBeEqualsToNonNullDormantProperty");
            }
        }

        internal static void SetBrokerMode()
        {
            mode = BrokeredMessageMode.Broker;
            binarySerializationItems = BuildBinarySerializationItems(mode);
        }

        void RaiseEvent(EventHandler handler)
        {
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary> Binary serialization item. </summary>
        sealed class BinarySerializationItem
        {
            /// <summary> Gets or sets the extractor. </summary>
            /// <value> The extractor. </value>
            public Func<BrokeredMessage, SerializationTarget, byte[]> Extractor { get; set; }

            /// <summary> Gets or sets the identifier of the field. </summary>
            /// <value> The identifier of the field. </value>
            public FieldId FieldId { get; set; }

            /// <summary> Gets or sets the should serialize. </summary>
            /// <value> The should serialize. </value>
            public Func<BrokeredMessage, SerializationTarget, bool> ShouldSerialize { get; set; }

            /// <summary> Gets the serialized size in bytes (maybe an estimate). </summary>
            public Func<BrokeredMessage, int> CalculateSize { get; set; }
        }

        /// <summary> Receiver headers. </summary>
        sealed class ReceiverHeaders
        {
            /// <summary> Gets or sets the number of deliveries. </summary>
            /// <value> The number of deliveries. </value>
            public int DeliveryCount { get; set; }

            /// <summary> Gets or sets the Date/Time of the locked until utc. </summary>
            /// <value> The locked until utc. </value>
            public DateTime LockedUntilUtc { get; set; }

            /// <summary> Gets or sets the lock token. </summary>
            /// <value> The lock token. </value>
            public Guid LockToken { get; set; }

            /// <summary> Gets or sets the sequence number. </summary>
            /// <value> The sequence number. </value>
            public long SequenceNumber { get; set; }

            /// <summary> Gets or sets the enqueued sequence number. </summary>
            /// <value> The Enqueued sequence number. </value>
            public long EnqueuedSequenceNumber { get; set; }
        }

        enum BrokeredMessageMode
        {
            Client,
            Broker
        }
    }
}
