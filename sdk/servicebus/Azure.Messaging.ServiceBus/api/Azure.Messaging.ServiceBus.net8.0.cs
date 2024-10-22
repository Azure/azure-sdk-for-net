namespace Azure.Messaging.ServiceBus
{
    public partial class CreateMessageBatchOptions
    {
        public CreateMessageBatchOptions() { }
        public long? MaxSizeInBytes { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class MessageLockLostEventArgs
    {
        public MessageLockLostEventArgs(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Exception exception) { }
        public System.Exception Exception { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusReceivedMessage Message { get { throw null; } }
    }
    public sealed partial class ProcessErrorEventArgs : System.EventArgs
    {
        public ProcessErrorEventArgs(System.Exception exception, Azure.Messaging.ServiceBus.ServiceBusErrorSource errorSource, string fullyQualifiedNamespace, string entityPath, string identifier, System.Threading.CancellationToken cancellationToken) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ProcessErrorEventArgs(System.Exception exception, Azure.Messaging.ServiceBus.ServiceBusErrorSource errorSource, string fullyQualifiedNamespace, string entityPath, System.Threading.CancellationToken cancellationToken) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string EntityPath { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusErrorSource ErrorSource { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
    }
    public partial class ProcessMessageEventArgs : System.EventArgs
    {
        public ProcessMessageEventArgs(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, Azure.Messaging.ServiceBus.ServiceBusReceiver receiver, string identifier, System.Threading.CancellationToken cancellationToken) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ProcessMessageEventArgs(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, Azure.Messaging.ServiceBus.ServiceBusReceiver receiver, System.Threading.CancellationToken cancellationToken) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string EntityPath { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusReceivedMessage Message { get { throw null; } }
        public event System.Func<Azure.Messaging.ServiceBus.MessageLockLostEventArgs, System.Threading.Tasks.Task> MessageLockLostAsync { add { } remove { } }
        public virtual System.Threading.Tasks.Task AbandonMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeferMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ProcessorReceiveActions GetReceiveActions() { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnMessageLockLostAsync(Azure.Messaging.ServiceBus.MessageLockLostEventArgs args) { throw null; }
        public virtual System.Threading.Tasks.Task RenewMessageLockAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProcessorReceiveActions
    {
        protected ProcessorReceiveActions() { }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> PeekMessagesAsync(int maxMessages, long? fromSequenceNumber = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(System.Collections.Generic.IEnumerable<long> sequenceNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> ReceiveMessagesAsync(int maxMessages, System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProcessSessionEventArgs : System.EventArgs
    {
        public ProcessSessionEventArgs(Azure.Messaging.ServiceBus.ServiceBusSessionReceiver receiver, string identifier, System.Threading.CancellationToken cancellationToken) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ProcessSessionEventArgs(Azure.Messaging.ServiceBus.ServiceBusSessionReceiver receiver, System.Threading.CancellationToken cancellationToken) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string EntityPath { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public string SessionId { get { throw null; } }
        public System.DateTimeOffset SessionLockedUntil { get { throw null; } }
        public virtual System.Threading.Tasks.Task<System.BinaryData> GetSessionStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void ReleaseSession() { }
        public virtual System.Threading.Tasks.Task RenewSessionLockAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SetSessionStateAsync(System.BinaryData sessionState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProcessSessionMessageEventArgs : System.EventArgs
    {
        public ProcessSessionMessageEventArgs(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, Azure.Messaging.ServiceBus.ServiceBusSessionReceiver receiver, string identifier, System.Threading.CancellationToken cancellationToken) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ProcessSessionMessageEventArgs(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, Azure.Messaging.ServiceBus.ServiceBusSessionReceiver receiver, System.Threading.CancellationToken cancellationToken) { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string EntityPath { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string Identifier { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusReceivedMessage Message { get { throw null; } }
        public string SessionId { get { throw null; } }
        public System.DateTimeOffset SessionLockedUntil { get { throw null; } }
        public event System.Func<Azure.Messaging.ServiceBus.SessionLockLostEventArgs, System.Threading.Tasks.Task> SessionLockLostAsync { add { } remove { } }
        public virtual System.Threading.Tasks.Task AbandonMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.Dictionary<string, object> propertiesToModify, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeferMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ProcessorReceiveActions GetReceiveActions() { throw null; }
        public virtual System.Threading.Tasks.Task<System.BinaryData> GetSessionStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnSessionLockLostAsync(Azure.Messaging.ServiceBus.SessionLockLostEventArgs args) { throw null; }
        public virtual void ReleaseSession() { }
        public virtual System.Threading.Tasks.Task RenewSessionLockAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SetSessionStateAsync(System.BinaryData sessionState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusClient : System.IAsyncDisposable
    {
        protected ServiceBusClient() { }
        public ServiceBusClient(string connectionString) { }
        public ServiceBusClient(string fullyQualifiedNamespace, Azure.AzureNamedKeyCredential credential, Azure.Messaging.ServiceBus.ServiceBusClientOptions options = null) { }
        public ServiceBusClient(string fullyQualifiedNamespace, Azure.AzureSasCredential credential, Azure.Messaging.ServiceBus.ServiceBusClientOptions options = null) { }
        public ServiceBusClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential) { }
        public ServiceBusClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential, Azure.Messaging.ServiceBus.ServiceBusClientOptions options) { }
        public ServiceBusClient(string connectionString, Azure.Messaging.ServiceBus.ServiceBusClientOptions options) { }
        public virtual string FullyQualifiedNamespace { get { throw null; } }
        public virtual string Identifier { get { throw null; } }
        public virtual bool IsClosed { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusTransportType TransportType { get { throw null; } }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusSessionReceiver> AcceptNextSessionAsync(string queueName, Azure.Messaging.ServiceBus.ServiceBusSessionReceiverOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusSessionReceiver> AcceptNextSessionAsync(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusSessionReceiverOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusSessionReceiver> AcceptSessionAsync(string queueName, string sessionId, Azure.Messaging.ServiceBus.ServiceBusSessionReceiverOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusSessionReceiver> AcceptSessionAsync(string topicName, string subscriptionName, string sessionId, Azure.Messaging.ServiceBus.ServiceBusSessionReceiverOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string queueName) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string queueName, Azure.Messaging.ServiceBus.ServiceBusProcessorOptions options) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string topicName, string subscriptionName) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusProcessorOptions options) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusReceiver CreateReceiver(string queueName) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusReceiver CreateReceiver(string queueName, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusReceiver CreateReceiver(string topicName, string subscriptionName) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusReceiver CreateReceiver(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusRuleManager CreateRuleManager(string topicName, string subscriptionName) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusSender CreateSender(string queueOrTopicName) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusSender CreateSender(string queueOrTopicName, Azure.Messaging.ServiceBus.ServiceBusSenderOptions options) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusSessionProcessor CreateSessionProcessor(string queueName, Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions options = null) { throw null; }
        public virtual Azure.Messaging.ServiceBus.ServiceBusSessionProcessor CreateSessionProcessor(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
    }
    public partial class ServiceBusClientOptions
    {
        public ServiceBusClientOptions() { }
        public System.TimeSpan ConnectionIdleTimeout { get { throw null; } set { } }
        public System.Uri CustomEndpointAddress { get { throw null; } set { } }
        public bool EnableCrossEntityTransactions { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusRetryOptions RetryOptions { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusTransportType TransportType { get { throw null; } set { } }
        public System.Net.IWebProxy WebProxy { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusConnectionStringProperties
    {
        public ServiceBusConnectionStringProperties() { }
        public System.Uri Endpoint { get { throw null; } }
        public string EntityPath { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public string SharedAccessKey { get { throw null; } }
        public string SharedAccessKeyName { get { throw null; } }
        public string SharedAccessSignature { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static Azure.Messaging.ServiceBus.ServiceBusConnectionStringProperties Parse(string connectionString) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public enum ServiceBusErrorSource
    {
        Complete = 0,
        Abandon = 1,
        ProcessMessageCallback = 2,
        Receive = 3,
        RenewLock = 4,
        AcceptSession = 5,
        CloseSession = 6,
    }
    public partial class ServiceBusException : System.Exception
    {
        public ServiceBusException() { }
        public ServiceBusException(bool isTransient, string message, string entityName = null, Azure.Messaging.ServiceBus.ServiceBusFailureReason reason = Azure.Messaging.ServiceBus.ServiceBusFailureReason.GeneralError, System.Exception innerException = null) { }
        public ServiceBusException(string message, Azure.Messaging.ServiceBus.ServiceBusFailureReason reason, string entityPath = null, System.Exception innerException = null) { }
        public string EntityPath { get { throw null; } }
        public bool IsTransient { get { throw null; } }
        public override string Message { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusFailureReason Reason { get { throw null; } }
    }
    public enum ServiceBusFailureReason
    {
        GeneralError = 0,
        MessagingEntityNotFound = 1,
        MessageLockLost = 2,
        MessageNotFound = 3,
        MessageSizeExceeded = 4,
        MessagingEntityDisabled = 5,
        QuotaExceeded = 6,
        ServiceBusy = 7,
        ServiceTimeout = 8,
        ServiceCommunicationProblem = 9,
        SessionCannotBeLocked = 10,
        SessionLockLost = 11,
        MessagingEntityAlreadyExists = 12,
    }
    public partial class ServiceBusMessage
    {
        public ServiceBusMessage() { }
        public ServiceBusMessage(Azure.Core.Amqp.AmqpAnnotatedMessage message) { }
        public ServiceBusMessage(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage receivedMessage) { }
        public ServiceBusMessage(System.BinaryData body) { }
        public ServiceBusMessage(System.ReadOnlyMemory<byte> body) { }
        public ServiceBusMessage(string body) { }
        public System.Collections.Generic.IDictionary<string, object> ApplicationProperties { get { throw null; } }
        public System.BinaryData Body { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
        public string ReplyTo { get { throw null; } set { } }
        public string ReplyToSessionId { get { throw null; } set { } }
        public System.DateTimeOffset ScheduledEnqueueTime { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public System.TimeSpan TimeToLive { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        public string TransactionPartitionKey { get { throw null; } set { } }
        public Azure.Core.Amqp.AmqpAnnotatedMessage GetRawAmqpMessage() { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class ServiceBusMessageBatch : System.IDisposable
    {
        internal ServiceBusMessageBatch() { }
        public int Count { get { throw null; } }
        public long MaxSizeInBytes { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        public void Dispose() { }
        public bool TryAddMessage(Azure.Messaging.ServiceBus.ServiceBusMessage message) { throw null; }
    }
    public enum ServiceBusMessageState
    {
        Active = 0,
        Deferred = 1,
        Scheduled = 2,
    }
    public static partial class ServiceBusModelFactory
    {
        public static Azure.Messaging.ServiceBus.Administration.NamespaceProperties NamespaceProperties(string name, System.DateTimeOffset createdTime, System.DateTimeOffset modifiedTime, Azure.Messaging.ServiceBus.Administration.MessagingSku messagingSku, int messagingUnits, string alias) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.QueueProperties QueueProperties(string name, System.TimeSpan lockDuration, long maxSizeInMegabytes, bool requiresDuplicateDetection, bool requiresSession, System.TimeSpan defaultMessageTimeToLive, System.TimeSpan autoDeleteOnIdle, bool deadLetteringOnMessageExpiration, System.TimeSpan duplicateDetectionHistoryTimeWindow, int maxDeliveryCount, bool enableBatchedOperations, Azure.Messaging.ServiceBus.Administration.EntityStatus status, string forwardTo, string forwardDeadLetteredMessagesTo, string userMetadata, bool enablePartitioning) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.ServiceBus.Administration.QueueProperties QueueProperties(string name, System.TimeSpan lockDuration = default(System.TimeSpan), long maxSizeInMegabytes = (long)0, bool requiresDuplicateDetection = false, bool requiresSession = false, System.TimeSpan defaultMessageTimeToLive = default(System.TimeSpan), System.TimeSpan autoDeleteOnIdle = default(System.TimeSpan), bool deadLetteringOnMessageExpiration = false, System.TimeSpan duplicateDetectionHistoryTimeWindow = default(System.TimeSpan), int maxDeliveryCount = 0, bool enableBatchedOperations = false, Azure.Messaging.ServiceBus.Administration.EntityStatus status = default(Azure.Messaging.ServiceBus.Administration.EntityStatus), string forwardTo = null, string forwardDeadLetteredMessagesTo = null, string userMetadata = null, bool enablePartitioning = false, long maxMessageSizeInKilobytes = (long)0) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.QueueRuntimeProperties QueueRuntimeProperties(string name, long activeMessageCount = (long)0, long scheduledMessageCount = (long)0, long deadLetterMessageCount = (long)0, long transferDeadLetterMessageCount = (long)0, long transferMessageCount = (long)0, long totalMessageCount = (long)0, long sizeInBytes = (long)0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), System.DateTimeOffset accessedAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.RuleProperties RuleProperties(string name, Azure.Messaging.ServiceBus.Administration.RuleFilter filter = null, Azure.Messaging.ServiceBus.Administration.RuleAction action = null) { throw null; }
        public static Azure.Messaging.ServiceBus.ServiceBusMessageBatch ServiceBusMessageBatch(long batchSizeBytes, System.Collections.Generic.IList<Azure.Messaging.ServiceBus.ServiceBusMessage> batchMessageStore, Azure.Messaging.ServiceBus.CreateMessageBatchOptions batchOptions = null, System.Func<Azure.Messaging.ServiceBus.ServiceBusMessage, bool> tryAddCallback = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.ServiceBus.ServiceBusReceivedMessage ServiceBusReceivedMessage(System.BinaryData body, string messageId, string partitionKey, string viaPartitionKey, string sessionId, string replyToSessionId, System.TimeSpan timeToLive, string correlationId, string subject, string to, string contentType, string replyTo, System.DateTimeOffset scheduledEnqueueTime, System.Collections.Generic.IDictionary<string, object> properties, System.Guid lockTokenGuid, int deliveryCount, System.DateTimeOffset lockedUntil, long sequenceNumber, string deadLetterSource, long enqueuedSequenceNumber, System.DateTimeOffset enqueuedTime) { throw null; }
        public static Azure.Messaging.ServiceBus.ServiceBusReceivedMessage ServiceBusReceivedMessage(System.BinaryData body = null, string messageId = null, string partitionKey = null, string viaPartitionKey = null, string sessionId = null, string replyToSessionId = null, System.TimeSpan timeToLive = default(System.TimeSpan), string correlationId = null, string subject = null, string to = null, string contentType = null, string replyTo = null, System.DateTimeOffset scheduledEnqueueTime = default(System.DateTimeOffset), System.Collections.Generic.IDictionary<string, object> properties = null, System.Guid lockTokenGuid = default(System.Guid), int deliveryCount = 0, System.DateTimeOffset lockedUntil = default(System.DateTimeOffset), long sequenceNumber = (long)-1, string deadLetterSource = null, long enqueuedSequenceNumber = (long)0, System.DateTimeOffset enqueuedTime = default(System.DateTimeOffset), Azure.Messaging.ServiceBus.ServiceBusMessageState serviceBusMessageState = Azure.Messaging.ServiceBus.ServiceBusMessageState.Active) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.SubscriptionProperties SubscriptionProperties(string topicName, string subscriptionName, System.TimeSpan lockDuration = default(System.TimeSpan), bool requiresSession = false, System.TimeSpan defaultMessageTimeToLive = default(System.TimeSpan), System.TimeSpan autoDeleteOnIdle = default(System.TimeSpan), bool deadLetteringOnMessageExpiration = false, int maxDeliveryCount = 0, bool enableBatchedOperations = false, Azure.Messaging.ServiceBus.Administration.EntityStatus status = default(Azure.Messaging.ServiceBus.Administration.EntityStatus), string forwardTo = null, string forwardDeadLetteredMessagesTo = null, string userMetadata = null) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.SubscriptionRuntimeProperties SubscriptionRuntimeProperties(string topicName, string subscriptionName, long activeMessageCount = (long)0, long deadLetterMessageCount = (long)0, long transferDeadLetterMessageCount = (long)0, long transferMessageCount = (long)0, long totalMessageCount = (long)0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), System.DateTimeOffset accessedAt = default(System.DateTimeOffset)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Messaging.ServiceBus.Administration.TopicProperties TopicProperties(string name, long maxSizeInMegabytes, bool requiresDuplicateDetection, System.TimeSpan defaultMessageTimeToLive, System.TimeSpan autoDeleteOnIdle, System.TimeSpan duplicateDetectionHistoryTimeWindow, bool enableBatchedOperations, Azure.Messaging.ServiceBus.Administration.EntityStatus status, bool enablePartitioning) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.TopicProperties TopicProperties(string name, long maxSizeInMegabytes = (long)0, bool requiresDuplicateDetection = false, System.TimeSpan defaultMessageTimeToLive = default(System.TimeSpan), System.TimeSpan autoDeleteOnIdle = default(System.TimeSpan), System.TimeSpan duplicateDetectionHistoryTimeWindow = default(System.TimeSpan), bool enableBatchedOperations = false, Azure.Messaging.ServiceBus.Administration.EntityStatus status = default(Azure.Messaging.ServiceBus.Administration.EntityStatus), bool enablePartitioning = false, long maxMessageSizeInKilobytes = (long)0) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.TopicRuntimeProperties TopicRuntimeProperties(string name, long scheduledMessageCount = (long)0, long sizeInBytes = (long)0, int subscriptionCount = 0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), System.DateTimeOffset accessedAt = default(System.DateTimeOffset)) { throw null; }
    }
    public partial class ServiceBusProcessor : System.IAsyncDisposable
    {
        protected ServiceBusProcessor() { }
        protected ServiceBusProcessor(Azure.Messaging.ServiceBus.ServiceBusClient client, string queueName, Azure.Messaging.ServiceBus.ServiceBusProcessorOptions options) { }
        protected ServiceBusProcessor(Azure.Messaging.ServiceBus.ServiceBusClient client, string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusProcessorOptions options) { }
        public virtual bool AutoCompleteMessages { get { throw null; } }
        public virtual string EntityPath { get { throw null; } }
        public virtual string FullyQualifiedNamespace { get { throw null; } }
        public virtual string Identifier { get { throw null; } }
        public virtual bool IsClosed { get { throw null; } }
        public virtual bool IsProcessing { get { throw null; } }
        public virtual System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } }
        public virtual int MaxConcurrentCalls { get { throw null; } }
        public virtual int PrefetchCount { get { throw null; } }
        public virtual Azure.Messaging.ServiceBus.ServiceBusReceiveMode ReceiveMode { get { throw null; } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessErrorEventArgs, System.Threading.Tasks.Task> ProcessErrorAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessMessageEventArgs, System.Threading.Tasks.Task> ProcessMessageAsync { add { } remove { } }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnProcessErrorAsync(Azure.Messaging.ServiceBus.ProcessErrorEventArgs args) { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnProcessMessageAsync(Azure.Messaging.ServiceBus.ProcessMessageEventArgs args) { throw null; }
        public virtual System.Threading.Tasks.Task StartProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task StopProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public void UpdateConcurrency(int maxConcurrentCalls) { }
        public void UpdatePrefetchCount(int prefetchCount) { }
    }
    public partial class ServiceBusProcessorOptions
    {
        public ServiceBusProcessorOptions() { }
        public bool AutoCompleteMessages { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } set { } }
        public int MaxConcurrentCalls { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusReceiveMode ReceiveMode { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.SubQueue SubQueue { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusReceivedMessage
    {
        internal ServiceBusReceivedMessage() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> ApplicationProperties { get { throw null; } }
        public System.BinaryData Body { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string DeadLetterErrorDescription { get { throw null; } }
        public string DeadLetterReason { get { throw null; } }
        public string DeadLetterSource { get { throw null; } }
        public int DeliveryCount { get { throw null; } }
        public long EnqueuedSequenceNumber { get { throw null; } }
        public System.DateTimeOffset EnqueuedTime { get { throw null; } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } }
        public System.DateTimeOffset LockedUntil { get { throw null; } }
        public string LockToken { get { throw null; } }
        public string MessageId { get { throw null; } }
        public string PartitionKey { get { throw null; } }
        public string ReplyTo { get { throw null; } }
        public string ReplyToSessionId { get { throw null; } }
        public System.DateTimeOffset ScheduledEnqueueTime { get { throw null; } }
        public long SequenceNumber { get { throw null; } }
        public string SessionId { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusMessageState State { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.TimeSpan TimeToLive { get { throw null; } }
        public string To { get { throw null; } }
        public string TransactionPartitionKey { get { throw null; } }
        public static Azure.Messaging.ServiceBus.ServiceBusReceivedMessage FromAmqpMessage(Azure.Core.Amqp.AmqpAnnotatedMessage message, System.BinaryData lockTokenBytes) { throw null; }
        public Azure.Core.Amqp.AmqpAnnotatedMessage GetRawAmqpMessage() { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ServiceBusReceiveMode
    {
        PeekLock = 0,
        ReceiveAndDelete = 1,
    }
    public partial class ServiceBusReceiver : System.IAsyncDisposable
    {
        protected ServiceBusReceiver() { }
        protected ServiceBusReceiver(Azure.Messaging.ServiceBus.ServiceBusClient client, string queueName, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options) { }
        protected ServiceBusReceiver(Azure.Messaging.ServiceBus.ServiceBusClient client, string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options) { }
        public virtual string EntityPath { get { throw null; } }
        public virtual string FullyQualifiedNamespace { get { throw null; } }
        public virtual string Identifier { get { throw null; } }
        public virtual bool IsClosed { get { throw null; } }
        public virtual int PrefetchCount { get { throw null; } }
        public virtual Azure.Messaging.ServiceBus.ServiceBusReceiveMode ReceiveMode { get { throw null; } }
        public virtual System.Threading.Tasks.Task AbandonMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeferMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage> PeekMessageAsync(long? fromSequenceNumber = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> PeekMessagesAsync(int maxMessages, long? fromSequenceNumber = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage> ReceiveDeferredMessageAsync(long sequenceNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(System.Collections.Generic.IEnumerable<long> sequenceNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage> ReceiveMessageAsync(System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> ReceiveMessagesAsync(int maxMessages, System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage> ReceiveMessagesAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task RenewMessageLockAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusReceiverOptions
    {
        public ServiceBusReceiverOptions() { }
        public string Identifier { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusReceiveMode ReceiveMode { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.SubQueue SubQueue { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public enum ServiceBusRetryMode
    {
        Fixed = 0,
        Exponential = 1,
    }
    public partial class ServiceBusRetryOptions
    {
        public ServiceBusRetryOptions() { }
        public Azure.Messaging.ServiceBus.ServiceBusRetryPolicy CustomRetryPolicy { get { throw null; } set { } }
        public System.TimeSpan Delay { get { throw null; } set { } }
        public System.TimeSpan MaxDelay { get { throw null; } set { } }
        public int MaxRetries { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusRetryMode Mode { get { throw null; } set { } }
        public System.TimeSpan TryTimeout { get { throw null; } set { } }
    }
    public abstract partial class ServiceBusRetryPolicy
    {
        protected ServiceBusRetryPolicy() { }
        public abstract System.TimeSpan? CalculateRetryDelay(System.Exception lastException, int attemptCount);
        public abstract System.TimeSpan CalculateTryTimeout(int attemptCount);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusRuleManager : System.IAsyncDisposable
    {
        protected ServiceBusRuleManager() { }
        public virtual string FullyQualifiedNamespace { get { throw null; } }
        public virtual bool IsClosed { get { throw null; } }
        public virtual string SubscriptionPath { get { throw null; } }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CreateRuleAsync(Azure.Messaging.ServiceBus.Administration.CreateRuleOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CreateRuleAsync(string ruleName, Azure.Messaging.ServiceBus.Administration.RuleFilter filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeleteRuleAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<Azure.Messaging.ServiceBus.Administration.RuleProperties> GetRulesAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusSender : System.IAsyncDisposable
    {
        protected ServiceBusSender() { }
        protected ServiceBusSender(Azure.Messaging.ServiceBus.ServiceBusClient client, string queueOrTopicName) { }
        protected ServiceBusSender(Azure.Messaging.ServiceBus.ServiceBusClient client, string queueOrTopicName, Azure.Messaging.ServiceBus.ServiceBusSenderOptions options) { }
        public virtual string EntityPath { get { throw null; } }
        public virtual string FullyQualifiedNamespace { get { throw null; } }
        public virtual string Identifier { get { throw null; } }
        public virtual bool IsClosed { get { throw null; } }
        public virtual System.Threading.Tasks.Task CancelScheduledMessageAsync(long sequenceNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CancelScheduledMessagesAsync(System.Collections.Generic.IEnumerable<long> sequenceNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Messaging.ServiceBus.ServiceBusMessageBatch> CreateMessageBatchAsync(Azure.Messaging.ServiceBus.CreateMessageBatchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Messaging.ServiceBus.ServiceBusMessageBatch> CreateMessageBatchAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<long> ScheduleMessageAsync(Azure.Messaging.ServiceBus.ServiceBusMessage message, System.DateTimeOffset scheduledEnqueueTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<long>> ScheduleMessagesAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.ServiceBusMessage> messages, System.DateTimeOffset scheduledEnqueueTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendMessageAsync(Azure.Messaging.ServiceBus.ServiceBusMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendMessagesAsync(Azure.Messaging.ServiceBus.ServiceBusMessageBatch messageBatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendMessagesAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.ServiceBusMessage> messages, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusSenderOptions
    {
        public ServiceBusSenderOptions() { }
        public string Identifier { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusSessionProcessor : System.IAsyncDisposable
    {
        protected ServiceBusSessionProcessor() { }
        protected ServiceBusSessionProcessor(Azure.Messaging.ServiceBus.ServiceBusClient client, string queueName, Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions options) { }
        protected ServiceBusSessionProcessor(Azure.Messaging.ServiceBus.ServiceBusClient client, string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions options) { }
        public virtual bool AutoCompleteMessages { get { throw null; } }
        public virtual string EntityPath { get { throw null; } }
        public virtual string FullyQualifiedNamespace { get { throw null; } }
        public virtual string Identifier { get { throw null; } }
        protected internal virtual Azure.Messaging.ServiceBus.ServiceBusProcessor InnerProcessor { get { throw null; } }
        public virtual bool IsClosed { get { throw null; } }
        public virtual bool IsProcessing { get { throw null; } }
        public virtual System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } }
        public virtual int MaxConcurrentCallsPerSession { get { throw null; } }
        public virtual int MaxConcurrentSessions { get { throw null; } }
        public virtual int PrefetchCount { get { throw null; } }
        public virtual Azure.Messaging.ServiceBus.ServiceBusReceiveMode ReceiveMode { get { throw null; } }
        public virtual System.TimeSpan? SessionIdleTimeout { get { throw null; } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessErrorEventArgs, System.Threading.Tasks.Task> ProcessErrorAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessSessionMessageEventArgs, System.Threading.Tasks.Task> ProcessMessageAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessSessionEventArgs, System.Threading.Tasks.Task> SessionClosingAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessSessionEventArgs, System.Threading.Tasks.Task> SessionInitializingAsync { add { } remove { } }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnProcessErrorAsync(Azure.Messaging.ServiceBus.ProcessErrorEventArgs args) { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnProcessSessionMessageAsync(Azure.Messaging.ServiceBus.ProcessSessionMessageEventArgs args) { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnSessionClosingAsync(Azure.Messaging.ServiceBus.ProcessSessionEventArgs args) { throw null; }
        protected internal virtual System.Threading.Tasks.Task OnSessionInitializingAsync(Azure.Messaging.ServiceBus.ProcessSessionEventArgs args) { throw null; }
        public virtual System.Threading.Tasks.Task StartProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task StopProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public void UpdateConcurrency(int maxConcurrentSessions, int maxConcurrentCallsPerSession) { }
        public void UpdatePrefetchCount(int prefetchCount) { }
    }
    public partial class ServiceBusSessionProcessorOptions
    {
        public ServiceBusSessionProcessorOptions() { }
        public bool AutoCompleteMessages { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } set { } }
        public int MaxConcurrentCallsPerSession { get { throw null; } set { } }
        public int MaxConcurrentSessions { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusReceiveMode ReceiveMode { get { throw null; } set { } }
        public System.TimeSpan? SessionIdleTimeout { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SessionIds { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusSessionReceiver : Azure.Messaging.ServiceBus.ServiceBusReceiver
    {
        protected ServiceBusSessionReceiver() { }
        public override bool IsClosed { get { throw null; } }
        public virtual string SessionId { get { throw null; } }
        public virtual System.DateTimeOffset SessionLockedUntil { get { throw null; } }
        public virtual System.Threading.Tasks.Task<System.BinaryData> GetSessionStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task RenewSessionLockAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SetSessionStateAsync(System.BinaryData sessionState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusSessionReceiverOptions
    {
        public ServiceBusSessionReceiverOptions() { }
        public string Identifier { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusReceiveMode ReceiveMode { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public enum ServiceBusTransportType
    {
        AmqpTcp = 0,
        AmqpWebSockets = 1,
    }
    public partial class SessionLockLostEventArgs : System.EventArgs
    {
        public SessionLockLostEventArgs(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.DateTimeOffset sessionLockedUntil, System.Exception exception) { }
        public System.Exception Exception { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusReceivedMessage Message { get { throw null; } }
        public System.DateTimeOffset SessionLockedUntil { get { throw null; } }
    }
    public enum SubQueue
    {
        None = 0,
        DeadLetter = 1,
        TransferDeadLetter = 2,
    }
}
namespace Azure.Messaging.ServiceBus.Administration
{
    public enum AccessRights
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    public abstract partial class AuthorizationRule : System.IEquatable<Azure.Messaging.ServiceBus.Administration.AuthorizationRule>
    {
        internal AuthorizationRule() { }
        public abstract string ClaimType { get; }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public abstract string KeyName { get; set; }
        public System.DateTimeOffset ModifiedTime { get { throw null; } }
        public abstract System.Collections.Generic.List<Azure.Messaging.ServiceBus.Administration.AccessRights> Rights { get; set; }
        public abstract bool Equals(Azure.Messaging.ServiceBus.Administration.AuthorizationRule other);
        public abstract override bool Equals(object obj);
        public override int GetHashCode() { throw null; }
    }
    public partial class AuthorizationRules : System.Collections.Generic.List<Azure.Messaging.ServiceBus.Administration.AuthorizationRule>, System.IEquatable<Azure.Messaging.ServiceBus.Administration.AuthorizationRules>
    {
        internal AuthorizationRules() { }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.AuthorizationRules other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.AuthorizationRules left, Azure.Messaging.ServiceBus.Administration.AuthorizationRules right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.AuthorizationRules left, Azure.Messaging.ServiceBus.Administration.AuthorizationRules right) { throw null; }
    }
    public sealed partial class CorrelationRuleFilter : Azure.Messaging.ServiceBus.Administration.RuleFilter
    {
        public CorrelationRuleFilter() { }
        public CorrelationRuleFilter(string correlationId) { }
        public System.Collections.Generic.IDictionary<string, object> ApplicationProperties { get { throw null; } }
        public string ContentType { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string ReplyTo { get { throw null; } set { } }
        public string ReplyToSessionId { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        public override bool Equals(Azure.Messaging.ServiceBus.Administration.RuleFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.CorrelationRuleFilter left, Azure.Messaging.ServiceBus.Administration.CorrelationRuleFilter right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.CorrelationRuleFilter left, Azure.Messaging.ServiceBus.Administration.CorrelationRuleFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateQueueOptions : System.IEquatable<Azure.Messaging.ServiceBus.Administration.CreateQueueOptions>
    {
        public CreateQueueOptions(Azure.Messaging.ServiceBus.Administration.QueueProperties queue) { }
        public CreateQueueOptions(string name) { }
        public Azure.Messaging.ServiceBus.Administration.AuthorizationRules AuthorizationRules { get { throw null; } }
        public System.TimeSpan AutoDeleteOnIdle { get { throw null; } set { } }
        public bool DeadLetteringOnMessageExpiration { get { throw null; } set { } }
        public System.TimeSpan DefaultMessageTimeToLive { get { throw null; } set { } }
        public System.TimeSpan DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public bool EnableBatchedOperations { get { throw null; } set { } }
        public bool EnablePartitioning { get { throw null; } set { } }
        public string ForwardDeadLetteredMessagesTo { get { throw null; } set { } }
        public string ForwardTo { get { throw null; } set { } }
        public System.TimeSpan LockDuration { get { throw null; } set { } }
        public int MaxDeliveryCount { get { throw null; } set { } }
        public long? MaxMessageSizeInKilobytes { get { throw null; } set { } }
        public long MaxSizeInMegabytes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool RequiresDuplicateDetection { get { throw null; } set { } }
        public bool RequiresSession { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Administration.EntityStatus Status { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.CreateQueueOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.CreateQueueOptions left, Azure.Messaging.ServiceBus.Administration.CreateQueueOptions right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.CreateQueueOptions left, Azure.Messaging.ServiceBus.Administration.CreateQueueOptions right) { throw null; }
    }
    public sealed partial class CreateRuleOptions : System.IEquatable<Azure.Messaging.ServiceBus.Administration.CreateRuleOptions>
    {
        public const string DefaultRuleName = "$Default";
        public CreateRuleOptions() { }
        public CreateRuleOptions(Azure.Messaging.ServiceBus.Administration.RuleProperties rule) { }
        public CreateRuleOptions(string name) { }
        public CreateRuleOptions(string name, Azure.Messaging.ServiceBus.Administration.RuleFilter filter) { }
        public Azure.Messaging.ServiceBus.Administration.RuleAction Action { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Administration.RuleFilter Filter { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.CreateRuleOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.CreateRuleOptions left, Azure.Messaging.ServiceBus.Administration.CreateRuleOptions right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.CreateRuleOptions left, Azure.Messaging.ServiceBus.Administration.CreateRuleOptions right) { throw null; }
    }
    public partial class CreateSubscriptionOptions : System.IEquatable<Azure.Messaging.ServiceBus.Administration.CreateSubscriptionOptions>
    {
        public CreateSubscriptionOptions(Azure.Messaging.ServiceBus.Administration.SubscriptionProperties subscription) { }
        public CreateSubscriptionOptions(string topicName, string subscriptionName) { }
        public System.TimeSpan AutoDeleteOnIdle { get { throw null; } set { } }
        public bool DeadLetteringOnMessageExpiration { get { throw null; } set { } }
        public System.TimeSpan DefaultMessageTimeToLive { get { throw null; } set { } }
        public bool EnableBatchedOperations { get { throw null; } set { } }
        public bool EnableDeadLetteringOnFilterEvaluationExceptions { get { throw null; } set { } }
        public string ForwardDeadLetteredMessagesTo { get { throw null; } set { } }
        public string ForwardTo { get { throw null; } set { } }
        public System.TimeSpan LockDuration { get { throw null; } set { } }
        public int MaxDeliveryCount { get { throw null; } set { } }
        public bool RequiresSession { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Administration.EntityStatus Status { get { throw null; } set { } }
        public string SubscriptionName { get { throw null; } set { } }
        public string TopicName { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.CreateSubscriptionOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.CreateSubscriptionOptions left, Azure.Messaging.ServiceBus.Administration.CreateSubscriptionOptions right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.CreateSubscriptionOptions left, Azure.Messaging.ServiceBus.Administration.CreateSubscriptionOptions right) { throw null; }
    }
    public partial class CreateTopicOptions : System.IEquatable<Azure.Messaging.ServiceBus.Administration.CreateTopicOptions>
    {
        public CreateTopicOptions(Azure.Messaging.ServiceBus.Administration.TopicProperties topic) { }
        public CreateTopicOptions(string name) { }
        public Azure.Messaging.ServiceBus.Administration.AuthorizationRules AuthorizationRules { get { throw null; } }
        public System.TimeSpan AutoDeleteOnIdle { get { throw null; } set { } }
        public System.TimeSpan DefaultMessageTimeToLive { get { throw null; } set { } }
        public System.TimeSpan DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public bool EnableBatchedOperations { get { throw null; } set { } }
        public bool EnablePartitioning { get { throw null; } set { } }
        public long? MaxMessageSizeInKilobytes { get { throw null; } set { } }
        public long MaxSizeInMegabytes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool RequiresDuplicateDetection { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Administration.EntityStatus Status { get { throw null; } set { } }
        public bool SupportOrdering { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.CreateTopicOptions other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.CreateTopicOptions left, Azure.Messaging.ServiceBus.Administration.CreateTopicOptions right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.CreateTopicOptions left, Azure.Messaging.ServiceBus.Administration.CreateTopicOptions right) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityStatus : System.IEquatable<Azure.Messaging.ServiceBus.Administration.EntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityStatus(string value) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.EntityStatus Active { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Administration.EntityStatus Disabled { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Administration.EntityStatus ReceiveDisabled { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Administration.EntityStatus SendDisabled { get { throw null; } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.EntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.EntityStatus left, Azure.Messaging.ServiceBus.Administration.EntityStatus right) { throw null; }
        public static implicit operator Azure.Messaging.ServiceBus.Administration.EntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.EntityStatus left, Azure.Messaging.ServiceBus.Administration.EntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class FalseRuleFilter : Azure.Messaging.ServiceBus.Administration.SqlRuleFilter
    {
        public FalseRuleFilter() : base (default(string)) { }
        public override bool Equals(Azure.Messaging.ServiceBus.Administration.RuleFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.FalseRuleFilter left, Azure.Messaging.ServiceBus.Administration.FalseRuleFilter right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.FalseRuleFilter left, Azure.Messaging.ServiceBus.Administration.FalseRuleFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessagingSku : System.IEquatable<Azure.Messaging.ServiceBus.Administration.MessagingSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessagingSku(string value) { throw null; }
        public static Azure.Messaging.ServiceBus.Administration.MessagingSku Basic { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Administration.MessagingSku Premium { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Administration.MessagingSku Standard { get { throw null; } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.MessagingSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.MessagingSku left, Azure.Messaging.ServiceBus.Administration.MessagingSku right) { throw null; }
        public static implicit operator Azure.Messaging.ServiceBus.Administration.MessagingSku (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.MessagingSku left, Azure.Messaging.ServiceBus.Administration.MessagingSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamespaceProperties
    {
        public NamespaceProperties() { }
        public string Alias { get { throw null; } }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public Azure.Messaging.ServiceBus.Administration.MessagingSku MessagingSku { get { throw null; } }
        public int MessagingUnits { get { throw null; } }
        public System.DateTimeOffset ModifiedTime { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class QueueProperties : System.IEquatable<Azure.Messaging.ServiceBus.Administration.QueueProperties>
    {
        internal QueueProperties() { }
        public Azure.Messaging.ServiceBus.Administration.AuthorizationRules AuthorizationRules { get { throw null; } }
        public System.TimeSpan AutoDeleteOnIdle { get { throw null; } set { } }
        public bool DeadLetteringOnMessageExpiration { get { throw null; } set { } }
        public System.TimeSpan DefaultMessageTimeToLive { get { throw null; } set { } }
        public System.TimeSpan DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public bool EnableBatchedOperations { get { throw null; } set { } }
        public bool EnablePartitioning { get { throw null; } }
        public string ForwardDeadLetteredMessagesTo { get { throw null; } set { } }
        public string ForwardTo { get { throw null; } set { } }
        public System.TimeSpan LockDuration { get { throw null; } set { } }
        public int MaxDeliveryCount { get { throw null; } set { } }
        public long? MaxMessageSizeInKilobytes { get { throw null; } set { } }
        public long MaxSizeInMegabytes { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public bool RequiresDuplicateDetection { get { throw null; } }
        public bool RequiresSession { get { throw null; } }
        public Azure.Messaging.ServiceBus.Administration.EntityStatus Status { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.QueueProperties other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.QueueProperties left, Azure.Messaging.ServiceBus.Administration.QueueProperties right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.QueueProperties left, Azure.Messaging.ServiceBus.Administration.QueueProperties right) { throw null; }
    }
    public partial class QueueRuntimeProperties
    {
        internal QueueRuntimeProperties() { }
        public System.DateTimeOffset AccessedAt { get { throw null; } }
        public long ActiveMessageCount { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public long DeadLetterMessageCount { get { throw null; } }
        public string Name { get { throw null; } }
        public long ScheduledMessageCount { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        public long TotalMessageCount { get { throw null; } }
        public long TransferDeadLetterMessageCount { get { throw null; } }
        public long TransferMessageCount { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
    }
    public abstract partial class RuleAction : System.IEquatable<Azure.Messaging.ServiceBus.Administration.RuleAction>
    {
        internal RuleAction() { }
        public abstract bool Equals(Azure.Messaging.ServiceBus.Administration.RuleAction other);
        public abstract override bool Equals(object obj);
        public override int GetHashCode() { throw null; }
    }
    public abstract partial class RuleFilter : System.IEquatable<Azure.Messaging.ServiceBus.Administration.RuleFilter>
    {
        internal RuleFilter() { }
        public abstract bool Equals(Azure.Messaging.ServiceBus.Administration.RuleFilter other);
        public abstract override bool Equals(object obj);
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class RuleProperties : System.IEquatable<Azure.Messaging.ServiceBus.Administration.RuleProperties>
    {
        internal RuleProperties() { }
        public const string DefaultRuleName = "$Default";
        public Azure.Messaging.ServiceBus.Administration.RuleAction Action { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Administration.RuleFilter Filter { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.RuleProperties other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.RuleProperties left, Azure.Messaging.ServiceBus.Administration.RuleProperties right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.RuleProperties left, Azure.Messaging.ServiceBus.Administration.RuleProperties right) { throw null; }
    }
    public partial class ServiceBusAdministrationClient
    {
        protected ServiceBusAdministrationClient() { }
        public ServiceBusAdministrationClient(string connectionString) { }
        public ServiceBusAdministrationClient(string fullyQualifiedNamespace, Azure.AzureNamedKeyCredential credential, Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions options = null) { }
        public ServiceBusAdministrationClient(string fullyQualifiedNamespace, Azure.AzureSasCredential credential, Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions options = null) { }
        public ServiceBusAdministrationClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential) { }
        public ServiceBusAdministrationClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential, Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions options) { }
        public ServiceBusAdministrationClient(string connectionString, Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions options) { }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.QueueProperties>> CreateQueueAsync(Azure.Messaging.ServiceBus.Administration.CreateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.QueueProperties>> CreateQueueAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.RuleProperties>> CreateRuleAsync(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.Administration.CreateRuleOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.SubscriptionProperties>> CreateSubscriptionAsync(Azure.Messaging.ServiceBus.Administration.CreateSubscriptionOptions options, Azure.Messaging.ServiceBus.Administration.CreateRuleOptions rule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.SubscriptionProperties>> CreateSubscriptionAsync(Azure.Messaging.ServiceBus.Administration.CreateSubscriptionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.SubscriptionProperties>> CreateSubscriptionAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.TopicProperties>> CreateTopicAsync(Azure.Messaging.ServiceBus.Administration.CreateTopicOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.TopicProperties>> CreateTopicAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueueAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRuleAsync(string topicName, string subscriptionName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSubscriptionAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTopicAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.NamespaceProperties>> GetNamespacePropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.QueueProperties>> GetQueueAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.QueueRuntimeProperties>> GetQueueRuntimePropertiesAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Administration.QueueProperties> GetQueuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Administration.QueueRuntimeProperties> GetQueuesRuntimePropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.RuleProperties>> GetRuleAsync(string topicName, string subscriptionName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Administration.RuleProperties> GetRulesAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.SubscriptionProperties>> GetSubscriptionAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.SubscriptionRuntimeProperties>> GetSubscriptionRuntimePropertiesAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Administration.SubscriptionProperties> GetSubscriptionsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Administration.SubscriptionRuntimeProperties> GetSubscriptionsRuntimePropertiesAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.TopicProperties>> GetTopicAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.TopicRuntimeProperties>> GetTopicRuntimePropertiesAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Administration.TopicProperties> GetTopicsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Administration.TopicRuntimeProperties> GetTopicsRuntimePropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> QueueExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> RuleExistsAsync(string topicName, string subscriptionName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> SubscriptionExistsAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> TopicExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.QueueProperties>> UpdateQueueAsync(Azure.Messaging.ServiceBus.Administration.QueueProperties queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.RuleProperties>> UpdateRuleAsync(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.Administration.RuleProperties rule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.SubscriptionProperties>> UpdateSubscriptionAsync(Azure.Messaging.ServiceBus.Administration.SubscriptionProperties subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Administration.TopicProperties>> UpdateTopicAsync(Azure.Messaging.ServiceBus.Administration.TopicProperties topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public ServiceBusAdministrationClientOptions(Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions.ServiceVersion version = Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions.ServiceVersion.V2021_05) { }
        public Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions.ServiceVersion Version { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public enum ServiceVersion
        {
            V2017_04 = 1,
            V2021_05 = 2,
        }
    }
    public partial class SharedAccessAuthorizationRule : Azure.Messaging.ServiceBus.Administration.AuthorizationRule
    {
        public SharedAccessAuthorizationRule(string keyName, System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.Administration.AccessRights> rights) { }
        public SharedAccessAuthorizationRule(string keyName, string primaryKey, System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.Administration.AccessRights> rights) { }
        public SharedAccessAuthorizationRule(string keyName, string primaryKey, string secondaryKey, System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.Administration.AccessRights> rights) { }
        public override string ClaimType { get { throw null; } }
        public sealed override string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public override System.Collections.Generic.List<Azure.Messaging.ServiceBus.Administration.AccessRights> Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public override bool Equals(Azure.Messaging.ServiceBus.Administration.AuthorizationRule other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.SharedAccessAuthorizationRule left, Azure.Messaging.ServiceBus.Administration.SharedAccessAuthorizationRule right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.SharedAccessAuthorizationRule left, Azure.Messaging.ServiceBus.Administration.SharedAccessAuthorizationRule right) { throw null; }
    }
    public sealed partial class SqlRuleAction : Azure.Messaging.ServiceBus.Administration.RuleAction
    {
        public SqlRuleAction(string sqlExpression) { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public string SqlExpression { get { throw null; } }
        public override bool Equals(Azure.Messaging.ServiceBus.Administration.RuleAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.SqlRuleAction left, Azure.Messaging.ServiceBus.Administration.SqlRuleAction right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.SqlRuleAction left, Azure.Messaging.ServiceBus.Administration.SqlRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlRuleFilter : Azure.Messaging.ServiceBus.Administration.RuleFilter
    {
        public SqlRuleFilter(string sqlExpression) { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public string SqlExpression { get { throw null; } }
        public override bool Equals(Azure.Messaging.ServiceBus.Administration.RuleFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.SqlRuleFilter left, Azure.Messaging.ServiceBus.Administration.SqlRuleFilter right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.SqlRuleFilter left, Azure.Messaging.ServiceBus.Administration.SqlRuleFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionProperties : System.IEquatable<Azure.Messaging.ServiceBus.Administration.SubscriptionProperties>
    {
        internal SubscriptionProperties() { }
        public System.TimeSpan AutoDeleteOnIdle { get { throw null; } set { } }
        public bool DeadLetteringOnMessageExpiration { get { throw null; } set { } }
        public System.TimeSpan DefaultMessageTimeToLive { get { throw null; } set { } }
        public bool EnableBatchedOperations { get { throw null; } set { } }
        public bool EnableDeadLetteringOnFilterEvaluationExceptions { get { throw null; } set { } }
        public string ForwardDeadLetteredMessagesTo { get { throw null; } set { } }
        public string ForwardTo { get { throw null; } set { } }
        public System.TimeSpan LockDuration { get { throw null; } set { } }
        public int MaxDeliveryCount { get { throw null; } set { } }
        public bool RequiresSession { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Administration.EntityStatus Status { get { throw null; } set { } }
        public string SubscriptionName { get { throw null; } set { } }
        public string TopicName { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.SubscriptionProperties other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.SubscriptionProperties left, Azure.Messaging.ServiceBus.Administration.SubscriptionProperties right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.SubscriptionProperties left, Azure.Messaging.ServiceBus.Administration.SubscriptionProperties right) { throw null; }
    }
    public partial class SubscriptionRuntimeProperties
    {
        internal SubscriptionRuntimeProperties() { }
        public System.DateTimeOffset AccessedAt { get { throw null; } }
        public long ActiveMessageCount { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public long DeadLetterMessageCount { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
        public long TotalMessageCount { get { throw null; } }
        public long TransferDeadLetterMessageCount { get { throw null; } }
        public long TransferMessageCount { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
    }
    public partial class TopicProperties : System.IEquatable<Azure.Messaging.ServiceBus.Administration.TopicProperties>
    {
        internal TopicProperties() { }
        public Azure.Messaging.ServiceBus.Administration.AuthorizationRules AuthorizationRules { get { throw null; } }
        public System.TimeSpan AutoDeleteOnIdle { get { throw null; } set { } }
        public System.TimeSpan DefaultMessageTimeToLive { get { throw null; } set { } }
        public System.TimeSpan DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public bool EnableBatchedOperations { get { throw null; } set { } }
        public bool EnablePartitioning { get { throw null; } set { } }
        public long? MaxMessageSizeInKilobytes { get { throw null; } set { } }
        public long MaxSizeInMegabytes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool RequiresDuplicateDetection { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Administration.EntityStatus Status { get { throw null; } set { } }
        public bool SupportOrdering { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Administration.TopicProperties other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.TopicProperties left, Azure.Messaging.ServiceBus.Administration.TopicProperties right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.TopicProperties left, Azure.Messaging.ServiceBus.Administration.TopicProperties right) { throw null; }
    }
    public partial class TopicRuntimeProperties
    {
        internal TopicRuntimeProperties() { }
        public System.DateTimeOffset AccessedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Name { get { throw null; } }
        public long ScheduledMessageCount { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        public int SubscriptionCount { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
    }
    public sealed partial class TrueRuleFilter : Azure.Messaging.ServiceBus.Administration.SqlRuleFilter
    {
        public TrueRuleFilter() : base (default(string)) { }
        public override bool Equals(Azure.Messaging.ServiceBus.Administration.RuleFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Administration.TrueRuleFilter left, Azure.Messaging.ServiceBus.Administration.TrueRuleFilter right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Administration.TrueRuleFilter left, Azure.Messaging.ServiceBus.Administration.TrueRuleFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ServiceBusClientBuilderExtensions
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClient, Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions> AddServiceAdministrationBusClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClient, Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions> AddServiceBusAdministrationClientWithNamespace<TBuilder>(this TBuilder builder, string fullyQualifiedNamespace) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClient, Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions> AddServiceBusAdministrationClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClient, Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions> AddServiceBusAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.ServiceBusClient, Azure.Messaging.ServiceBus.ServiceBusClientOptions> AddServiceBusClientWithNamespace<TBuilder>(this TBuilder builder, string fullyQualifiedNamespace) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.ServiceBusClient, Azure.Messaging.ServiceBus.ServiceBusClientOptions> AddServiceBusClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.ServiceBusClient, Azure.Messaging.ServiceBus.ServiceBusClientOptions> AddServiceBusClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
