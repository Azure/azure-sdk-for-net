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
    public static partial class EntityNameFormatter
    {
        public static string FormatDeadLetterPath(string entityPath) { throw null; }
        public static string FormatRulePath(string topicPath, string subscriptionName, string ruleName) { throw null; }
        public static string FormatSubQueuePath(string entityPath, string subQueueName) { throw null; }
        public static string FormatSubscriptionPath(string topicPath, string subscriptionName) { throw null; }
        public static string FormatTransferDeadLetterPath(string entityPath) { throw null; }
    }
    public sealed partial class ProcessErrorEventArgs : System.EventArgs
    {
        public ProcessErrorEventArgs(System.Exception exception, Azure.Messaging.ServiceBus.ServiceBusErrorSource errorSource, string fullyQualifiedNamespace, string entityPath) { }
        public string EntityPath { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusErrorSource ErrorSource { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
    }
    public partial class ProcessMessageEventArgs : System.EventArgs
    {
        internal ProcessMessageEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusReceivedMessage Message { get { throw null; } }
        public System.Threading.Tasks.Task AbandonMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task CompleteMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task DeferMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProcessSessionEventArgs : System.EventArgs
    {
        internal ProcessSessionEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string SessionId { get { throw null; } }
        public System.DateTimeOffset SessionLockedUntil { get { throw null; } }
        public virtual System.Threading.Tasks.Task<byte[]> GetSessionStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SetSessionStateAsync(byte[] sessionState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProcessSessionMessageEventArgs : System.EventArgs
    {
        internal ProcessSessionMessageEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusReceivedMessage Message { get { throw null; } }
        public string SessionId { get { throw null; } }
        public System.DateTimeOffset SessionLockedUntil { get { throw null; } }
        public System.Threading.Tasks.Task AbandonMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task CompleteMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task DeferMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<byte[]> GetSessionStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SetSessionStateAsync(byte[] sessionState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum ReceiveMode
    {
        PeekLock = 0,
        ReceiveAndDelete = 1,
    }
    public partial class ServiceBusClient : System.IAsyncDisposable
    {
        protected ServiceBusClient() { }
        public ServiceBusClient(string connectionString) { }
        public ServiceBusClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential) { }
        public ServiceBusClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential, Azure.Messaging.ServiceBus.ServiceBusClientOptions options) { }
        public ServiceBusClient(string connectionString, Azure.Messaging.ServiceBus.ServiceBusClientOptions options) { }
        public string FullyQualifiedNamespace { get { throw null; } }
        public bool IsDisposed { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusTransportType TransportType { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusReceiver CreateDeadLetterReceiver(string queueName, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options = null) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusReceiver CreateDeadLetterReceiver(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options = null) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string queueName) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string queueName, Azure.Messaging.ServiceBus.ServiceBusProcessorOptions options) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string topicName, string subscriptionName) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusProcessor CreateProcessor(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusProcessorOptions options) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusReceiver CreateReceiver(string queueName) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusReceiver CreateReceiver(string queueName, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusReceiver CreateReceiver(string topicName, string subscriptionName) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusReceiver CreateReceiver(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusReceiverOptions options) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusSender CreateSender(string queueOrTopicName) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusSender CreateSender(string queueOrTopicName, Azure.Messaging.ServiceBus.ServiceBusSenderOptions options) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusSessionProcessor CreateSessionProcessor(string queueName, Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions options = null) { throw null; }
        public Azure.Messaging.ServiceBus.ServiceBusSessionProcessor CreateSessionProcessor(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusSessionReceiver> CreateSessionReceiverAsync(string queueName, Azure.Messaging.ServiceBus.ServiceBusSessionReceiverOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusSessionReceiver> CreateSessionReceiverAsync(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.ServiceBusSessionReceiverOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
    }
    public partial class ServiceBusClientOptions
    {
        public ServiceBusClientOptions() { }
        public System.Net.IWebProxy Proxy { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusRetryOptions RetryOptions { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ServiceBusTransportType TransportType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public enum ServiceBusErrorSource
    {
        Complete = 0,
        Abandon = 1,
        UserCallback = 2,
        Receive = 3,
        RenewLock = 4,
        AcceptMessageSession = 5,
        CloseMessageSession = 6,
    }
    public partial class ServiceBusException : System.Exception
    {
        public ServiceBusException() { }
        public ServiceBusException(bool isTransient, string message, string entityName = null, Azure.Messaging.ServiceBus.ServiceBusException.FailureReason reason = Azure.Messaging.ServiceBus.ServiceBusException.FailureReason.GeneralError, System.Exception innerException = null) { }
        public ServiceBusException(string message, Azure.Messaging.ServiceBus.ServiceBusException.FailureReason reason, string entityPath = null, System.Exception innerException = null) { }
        public string EntityPath { get { throw null; } }
        public bool IsTransient { get { throw null; } }
        public override string Message { get { throw null; } }
        public Azure.Messaging.ServiceBus.ServiceBusException.FailureReason Reason { get { throw null; } }
        public enum FailureReason
        {
            GeneralError = 0,
            ClientClosed = 1,
            MessagingEntityNotFound = 2,
            MessageLockLost = 3,
            MessageNotFound = 4,
            MessageSizeExceeded = 5,
            MessagingEntityDisabled = 6,
            QuotaExceeded = 7,
            ServiceBusy = 8,
            ServiceTimeout = 9,
            ServiceCommunicationProblem = 10,
            SessionCannotBeLocked = 11,
            SessionLockLost = 12,
            Unauthorized = 13,
            MessagingEntityAlreadyExists = 14,
        }
    }
    public partial class ServiceBusMessage
    {
        public ServiceBusMessage() { }
        public ServiceBusMessage(Azure.Core.BinaryData body) { }
        public ServiceBusMessage(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage receivedMessage) { }
        public ServiceBusMessage(System.ReadOnlyMemory<byte> body) { }
        public ServiceBusMessage(string body) { }
        public ServiceBusMessage(string body, System.Text.Encoding encoding) { }
        public Azure.Core.BinaryData Body { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Properties { get { throw null; } }
        public string ReplyTo { get { throw null; } set { } }
        public string ReplyToSessionId { get { throw null; } set { } }
        public System.DateTimeOffset ScheduledEnqueueTime { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public System.TimeSpan TimeToLive { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        public string ViaPartitionKey { get { throw null; } set { } }
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
    public partial class ServiceBusProcessor
    {
        protected ServiceBusProcessor() { }
        public bool AutoComplete { get { throw null; } }
        public string EntityPath { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public bool IsProcessing { get { throw null; } }
        public System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } }
        public int MaxConcurrentCalls { get { throw null; } }
        public System.TimeSpan? MaxReceiveWaitTime { get { throw null; } }
        public int PrefetchCount { get { throw null; } }
        public Azure.Messaging.ServiceBus.ReceiveMode ReceiveMode { get { throw null; } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessErrorEventArgs, System.Threading.Tasks.Task> ProcessErrorAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessMessageEventArgs, System.Threading.Tasks.Task> ProcessMessageAsync { add { } remove { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task StartProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task StopProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusProcessorOptions
    {
        public ServiceBusProcessorOptions() { }
        public bool AutoComplete { get { throw null; } set { } }
        public System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } set { } }
        public int MaxConcurrentCalls { get { throw null; } set { } }
        public System.TimeSpan? MaxReceiveWaitTime { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ReceiveMode ReceiveMode { get { throw null; } set { } }
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
        public Azure.Core.BinaryData Body { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string DeadLetterErrorDescription { get { throw null; } }
        public string DeadLetterReason { get { throw null; } }
        public string DeadLetterSource { get { throw null; } }
        public int DeliveryCount { get { throw null; } }
        public long EnqueuedSequenceNumber { get { throw null; } }
        public System.DateTimeOffset EnqueuedTime { get { throw null; } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset LockedUntil { get { throw null; } }
        public string LockToken { get { throw null; } }
        public string MessageId { get { throw null; } }
        public string PartitionKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
        public string ReplyTo { get { throw null; } }
        public string ReplyToSessionId { get { throw null; } }
        public System.DateTimeOffset ScheduledEnqueueTime { get { throw null; } }
        public long SequenceNumber { get { throw null; } }
        public string SessionId { get { throw null; } }
        public System.TimeSpan TimeToLive { get { throw null; } }
        public string To { get { throw null; } }
        public string ViaPartitionKey { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusReceiver : System.IAsyncDisposable
    {
        protected ServiceBusReceiver() { }
        public string EntityPath { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public bool IsDisposed { get { throw null; } }
        public int PrefetchCount { get { throw null; } }
        public Azure.Messaging.ServiceBus.ReceiveMode ReceiveMode { get { throw null; } }
        public virtual System.Threading.Tasks.Task AbandonMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task AbandonMessageAsync(string lockToken, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteMessageAsync(string lockToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(string lockToken, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeadLetterMessageAsync(string lockToken, string deadLetterReason, string deadLetterErrorDescription = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeferMessageAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task DeferMessageAsync(string lockToken, System.Collections.Generic.IDictionary<string, object> propertiesToModify = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage> PeekMessageAsync(long? fromSequenceNumber = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> PeekMessagesAsync(int maxMessages, long? fromSequenceNumber = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage> ReceiveDeferredMessageAsync(long sequenceNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> ReceiveDeferredMessagesAsync(System.Collections.Generic.IEnumerable<long> sequenceNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage> ReceiveMessageAsync(System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IList<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage>> ReceiveMessagesAsync(int maxMessages, System.TimeSpan? maxWaitTime = default(System.TimeSpan?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task RenewMessageLockAsync(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.DateTimeOffset> RenewMessageLockAsync(string lockToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusReceiverOptions
    {
        public ServiceBusReceiverOptions() { }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ReceiveMode ReceiveMode { get { throw null; } set { } }
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
    public partial class ServiceBusSender : System.IAsyncDisposable
    {
        protected ServiceBusSender() { }
        public string EntityPath { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public bool IsDisposed { get { throw null; } }
        public string ViaEntityPath { get { throw null; } }
        public virtual System.Threading.Tasks.Task CancelScheduledMessageAsync(long sequenceNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CancelScheduledMessagesAsync(System.Collections.Generic.IEnumerable<long> sequenceNumbers, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Messaging.ServiceBus.ServiceBusMessageBatch> CreateMessageBatchAsync(Azure.Messaging.ServiceBus.CreateMessageBatchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.Messaging.ServiceBus.ServiceBusMessageBatch> CreateMessageBatchAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task<long> ScheduleMessageAsync(Azure.Messaging.ServiceBus.ServiceBusMessage message, System.DateTimeOffset scheduledEnqueueTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<long[]> ScheduleMessagesAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.ServiceBusMessage> messages, System.DateTimeOffset scheduledEnqueueTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendMessageAsync(Azure.Messaging.ServiceBus.ServiceBusMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendMessagesAsync(Azure.Messaging.ServiceBus.ServiceBusMessageBatch messageBatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendMessagesAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.ServiceBusMessage> messages, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusSenderOptions
    {
        public ServiceBusSenderOptions() { }
        public string ViaQueueOrTopicName { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusSessionProcessor
    {
        protected ServiceBusSessionProcessor() { }
        public bool AutoComplete { get { throw null; } }
        public string EntityPath { get { throw null; } }
        public string FullyQualifiedNamespace { get { throw null; } }
        public bool IsProcessing { get { throw null; } }
        public System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } }
        public int MaxConcurrentCalls { get { throw null; } }
        public System.TimeSpan? MaxReceiveWaitTime { get { throw null; } }
        public int PrefetchCount { get { throw null; } }
        public Azure.Messaging.ServiceBus.ReceiveMode ReceiveMode { get { throw null; } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessErrorEventArgs, System.Threading.Tasks.Task> ProcessErrorAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessSessionMessageEventArgs, System.Threading.Tasks.Task> ProcessMessageAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessSessionEventArgs, System.Threading.Tasks.Task> SessionClosingAsync { add { } remove { } }
        public event System.Func<Azure.Messaging.ServiceBus.ProcessSessionEventArgs, System.Threading.Tasks.Task> SessionInitializingAsync { add { } remove { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual System.Threading.Tasks.Task StartProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task StopProcessingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusSessionProcessorOptions
    {
        public ServiceBusSessionProcessorOptions() { }
        public bool AutoComplete { get { throw null; } set { } }
        public System.TimeSpan MaxAutoLockRenewalDuration { get { throw null; } set { } }
        public int MaxConcurrentCalls { get { throw null; } set { } }
        public System.TimeSpan? MaxReceiveWaitTime { get { throw null; } set { } }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ReceiveMode ReceiveMode { get { throw null; } set { } }
        public string[] SessionIds { get { throw null; } set { } }
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
        public string SessionId { get { throw null; } }
        public System.DateTimeOffset SessionLockedUntil { get { throw null; } }
        public virtual System.Threading.Tasks.Task<byte[]> GetSessionStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task RenewSessionLockAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SetSessionStateAsync(byte[] sessionState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusSessionReceiverOptions
    {
        public ServiceBusSessionReceiverOptions() { }
        public int PrefetchCount { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.ReceiveMode ReceiveMode { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
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
}
namespace Azure.Messaging.ServiceBus.Management
{
    public enum AccessRights
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    public abstract partial class AuthorizationRule : System.IEquatable<Azure.Messaging.ServiceBus.Management.AuthorizationRule>
    {
        internal AuthorizationRule() { }
        public abstract string ClaimType { get; }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public abstract string KeyName { get; set; }
        public System.DateTimeOffset ModifiedTime { get { throw null; } }
        public abstract System.Collections.Generic.List<Azure.Messaging.ServiceBus.Management.AccessRights> Rights { get; set; }
        public abstract bool Equals(Azure.Messaging.ServiceBus.Management.AuthorizationRule other);
        public abstract override bool Equals(object obj);
        public override int GetHashCode() { throw null; }
    }
    public partial class AuthorizationRules : System.Collections.Generic.List<Azure.Messaging.ServiceBus.Management.AuthorizationRule>, System.IEquatable<Azure.Messaging.ServiceBus.Management.AuthorizationRules>
    {
        public AuthorizationRules() { }
        public bool Equals(Azure.Messaging.ServiceBus.Management.AuthorizationRules other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.AuthorizationRules left, Azure.Messaging.ServiceBus.Management.AuthorizationRules right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.AuthorizationRules left, Azure.Messaging.ServiceBus.Management.AuthorizationRules right) { throw null; }
    }
    public sealed partial class CorrelationRuleFilter : Azure.Messaging.ServiceBus.Management.RuleFilter
    {
        public CorrelationRuleFilter() { }
        public CorrelationRuleFilter(string correlationId) { }
        public string ContentType { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, object> Properties { get { throw null; } }
        public string ReplyTo { get { throw null; } set { } }
        public string ReplyToSessionId { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
        public override bool Equals(Azure.Messaging.ServiceBus.Management.RuleFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.CorrelationRuleFilter left, Azure.Messaging.ServiceBus.Management.CorrelationRuleFilter right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.CorrelationRuleFilter left, Azure.Messaging.ServiceBus.Management.CorrelationRuleFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityStatus : System.IEquatable<Azure.Messaging.ServiceBus.Management.EntityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityStatus(string value) { throw null; }
        public static Azure.Messaging.ServiceBus.Management.EntityStatus Active { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Management.EntityStatus Disable { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Management.EntityStatus ReceiveDisabled { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Management.EntityStatus SendDisabled { get { throw null; } }
        public bool Equals(Azure.Messaging.ServiceBus.Management.EntityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.EntityStatus left, Azure.Messaging.ServiceBus.Management.EntityStatus right) { throw null; }
        public static implicit operator Azure.Messaging.ServiceBus.Management.EntityStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.EntityStatus left, Azure.Messaging.ServiceBus.Management.EntityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class FalseRuleFilter : Azure.Messaging.ServiceBus.Management.SqlRuleFilter
    {
        public FalseRuleFilter() : base (default(string)) { }
        public override bool Equals(Azure.Messaging.ServiceBus.Management.RuleFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.FalseRuleFilter left, Azure.Messaging.ServiceBus.Management.FalseRuleFilter right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.FalseRuleFilter left, Azure.Messaging.ServiceBus.Management.FalseRuleFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageCountDetails
    {
        public MessageCountDetails() { }
        public long ActiveMessageCount { get { throw null; } }
        public long DeadLetterMessageCount { get { throw null; } }
        public long ScheduledMessageCount { get { throw null; } }
        public long TransferDeadLetterMessageCount { get { throw null; } }
        public long TransferMessageCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessagingSku : System.IEquatable<Azure.Messaging.ServiceBus.Management.MessagingSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessagingSku(string value) { throw null; }
        public static Azure.Messaging.ServiceBus.Management.MessagingSku Basic { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Management.MessagingSku Premium { get { throw null; } }
        public static Azure.Messaging.ServiceBus.Management.MessagingSku Standard { get { throw null; } }
        public bool Equals(Azure.Messaging.ServiceBus.Management.MessagingSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.MessagingSku left, Azure.Messaging.ServiceBus.Management.MessagingSku right) { throw null; }
        public static implicit operator Azure.Messaging.ServiceBus.Management.MessagingSku (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.MessagingSku left, Azure.Messaging.ServiceBus.Management.MessagingSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamespaceProperties
    {
        public NamespaceProperties() { }
        public string Alias { get { throw null; } }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public Azure.Messaging.ServiceBus.Management.MessagingSku MessagingSku { get { throw null; } }
        public int MessagingUnits { get { throw null; } }
        public System.DateTimeOffset ModifiedTime { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class QueueDescription : System.IEquatable<Azure.Messaging.ServiceBus.Management.QueueDescription>
    {
        public QueueDescription(string name) { }
        public Azure.Messaging.ServiceBus.Management.AuthorizationRules AuthorizationRules { get { throw null; } }
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
        public long MaxSizeInMegabytes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool RequiresDuplicateDetection { get { throw null; } set { } }
        public bool RequiresSession { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Management.EntityStatus Status { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Management.QueueDescription other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.QueueDescription left, Azure.Messaging.ServiceBus.Management.QueueDescription right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.QueueDescription left, Azure.Messaging.ServiceBus.Management.QueueDescription right) { throw null; }
    }
    public partial class QueueRuntimeInfo
    {
        internal QueueRuntimeInfo() { }
        public System.DateTimeOffset AccessedAt { get { throw null; } }
        public Azure.Messaging.ServiceBus.Management.MessageCountDetails CountDetails { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public long MessageCount { get { throw null; } }
        public string Name { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
    }
    public abstract partial class RuleAction : System.IEquatable<Azure.Messaging.ServiceBus.Management.RuleAction>
    {
        internal RuleAction() { }
        public abstract bool Equals(Azure.Messaging.ServiceBus.Management.RuleAction other);
        public abstract override bool Equals(object obj);
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class RuleDescription : System.IEquatable<Azure.Messaging.ServiceBus.Management.RuleDescription>
    {
        public const string DefaultRuleName = "$Default";
        public RuleDescription() { }
        public RuleDescription(string name) { }
        public RuleDescription(string name, Azure.Messaging.ServiceBus.Management.RuleFilter filter) { }
        public Azure.Messaging.ServiceBus.Management.RuleAction Action { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Management.RuleFilter Filter { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Management.RuleDescription other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.RuleDescription left, Azure.Messaging.ServiceBus.Management.RuleDescription right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.RuleDescription left, Azure.Messaging.ServiceBus.Management.RuleDescription right) { throw null; }
    }
    public abstract partial class RuleFilter : System.IEquatable<Azure.Messaging.ServiceBus.Management.RuleFilter>
    {
        internal RuleFilter() { }
        public abstract bool Equals(Azure.Messaging.ServiceBus.Management.RuleFilter other);
        public abstract override bool Equals(object obj);
        public override int GetHashCode() { throw null; }
    }
    public partial class ServiceBusManagementClient
    {
        protected ServiceBusManagementClient() { }
        public ServiceBusManagementClient(string connectionString) { }
        public ServiceBusManagementClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential) { }
        public ServiceBusManagementClient(string fullyQualifiedNamespace, Azure.Core.TokenCredential credential, Azure.Messaging.ServiceBus.Management.ServiceBusManagementClientOptions options) { }
        public ServiceBusManagementClient(string connectionString, Azure.Messaging.ServiceBus.Management.ServiceBusManagementClientOptions options) { }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.QueueDescription>> CreateQueueAsync(Azure.Messaging.ServiceBus.Management.QueueDescription queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.QueueDescription>> CreateQueueAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.RuleDescription>> CreateRuleAsync(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.Management.RuleDescription rule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.SubscriptionDescription>> CreateSubscriptionAsync(Azure.Messaging.ServiceBus.Management.SubscriptionDescription subscription, Azure.Messaging.ServiceBus.Management.RuleDescription rule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.SubscriptionDescription>> CreateSubscriptionAsync(Azure.Messaging.ServiceBus.Management.SubscriptionDescription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.SubscriptionDescription>> CreateSubscriptionAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.TopicDescription>> CreateTopicAsync(Azure.Messaging.ServiceBus.Management.TopicDescription topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.TopicDescription>> CreateTopicAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueueAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRuleAsync(string topicName, string subscriptionName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSubscriptionAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTopicAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.NamespaceProperties>> GetNamespacePropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.QueueDescription>> GetQueueAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.QueueRuntimeInfo>> GetQueueRuntimeInfoAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Management.QueueDescription> GetQueuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Management.QueueRuntimeInfo> GetQueuesRuntimeInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.RuleDescription>> GetRuleAsync(string topicName, string subscriptionName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Management.RuleDescription> GetRulesAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.SubscriptionDescription>> GetSubscriptionAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.SubscriptionRuntimeInfo>> GetSubscriptionRuntimeInfoAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Management.SubscriptionDescription> GetSubscriptionsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Management.SubscriptionRuntimeInfo> GetSubscriptionsRuntimeInfoAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.TopicDescription>> GetTopicAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.TopicRuntimeInfo>> GetTopicRuntimeInfoAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Management.TopicDescription> GetTopicsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.ServiceBus.Management.TopicRuntimeInfo> GetTopicsRuntimeInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> QueueExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> RuleExistsAsync(string topicName, string subscriptionName, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> SubscriptionExistsAsync(string topicName, string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> TopicExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.QueueDescription>> UpdateQueueAsync(Azure.Messaging.ServiceBus.Management.QueueDescription queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.RuleDescription>> UpdateRuleAsync(string topicName, string subscriptionName, Azure.Messaging.ServiceBus.Management.RuleDescription rule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.SubscriptionDescription>> UpdateSubscriptionAsync(Azure.Messaging.ServiceBus.Management.SubscriptionDescription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.ServiceBus.Management.TopicDescription>> UpdateTopicAsync(Azure.Messaging.ServiceBus.Management.TopicDescription topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusManagementClientOptions : Azure.Core.ClientOptions
    {
        public ServiceBusManagementClientOptions() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class SharedAccessAuthorizationRule : Azure.Messaging.ServiceBus.Management.AuthorizationRule
    {
        public SharedAccessAuthorizationRule(string keyName, System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.Management.AccessRights> rights) { }
        public SharedAccessAuthorizationRule(string keyName, string primaryKey, System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.Management.AccessRights> rights) { }
        public SharedAccessAuthorizationRule(string keyName, string primaryKey, string secondaryKey, System.Collections.Generic.IEnumerable<Azure.Messaging.ServiceBus.Management.AccessRights> rights) { }
        public override string ClaimType { get { throw null; } }
        public sealed override string KeyName { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public override System.Collections.Generic.List<Azure.Messaging.ServiceBus.Management.AccessRights> Rights { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public override bool Equals(Azure.Messaging.ServiceBus.Management.AuthorizationRule other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.SharedAccessAuthorizationRule left, Azure.Messaging.ServiceBus.Management.SharedAccessAuthorizationRule right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.SharedAccessAuthorizationRule left, Azure.Messaging.ServiceBus.Management.SharedAccessAuthorizationRule right) { throw null; }
    }
    public sealed partial class SqlRuleAction : Azure.Messaging.ServiceBus.Management.RuleAction
    {
        public SqlRuleAction(string sqlExpression) { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public string SqlExpression { get { throw null; } }
        public override bool Equals(Azure.Messaging.ServiceBus.Management.RuleAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.SqlRuleAction left, Azure.Messaging.ServiceBus.Management.SqlRuleAction right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.SqlRuleAction left, Azure.Messaging.ServiceBus.Management.SqlRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlRuleFilter : Azure.Messaging.ServiceBus.Management.RuleFilter
    {
        public SqlRuleFilter(string sqlExpression) { }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        public string SqlExpression { get { throw null; } }
        public override bool Equals(Azure.Messaging.ServiceBus.Management.RuleFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.SqlRuleFilter left, Azure.Messaging.ServiceBus.Management.SqlRuleFilter right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.SqlRuleFilter left, Azure.Messaging.ServiceBus.Management.SqlRuleFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionDescription : System.IEquatable<Azure.Messaging.ServiceBus.Management.SubscriptionDescription>
    {
        public SubscriptionDescription(string topicName, string subscriptionName) { }
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
        public Azure.Messaging.ServiceBus.Management.EntityStatus Status { get { throw null; } set { } }
        public string SubscriptionName { get { throw null; } set { } }
        public string TopicName { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Management.SubscriptionDescription other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.SubscriptionDescription left, Azure.Messaging.ServiceBus.Management.SubscriptionDescription right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.SubscriptionDescription left, Azure.Messaging.ServiceBus.Management.SubscriptionDescription right) { throw null; }
    }
    public partial class SubscriptionRuntimeInfo
    {
        internal SubscriptionRuntimeInfo() { }
        public System.DateTimeOffset AccessedAt { get { throw null; } }
        public Azure.Messaging.ServiceBus.Management.MessageCountDetails CountDetails { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public long MessageCount { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
    }
    public partial class TopicDescription : System.IEquatable<Azure.Messaging.ServiceBus.Management.TopicDescription>
    {
        public TopicDescription(string name) { }
        public Azure.Messaging.ServiceBus.Management.AuthorizationRules AuthorizationRules { get { throw null; } }
        public System.TimeSpan AutoDeleteOnIdle { get { throw null; } set { } }
        public System.TimeSpan DefaultMessageTimeToLive { get { throw null; } set { } }
        public System.TimeSpan DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public bool EnableBatchedOperations { get { throw null; } set { } }
        public bool EnablePartitioning { get { throw null; } set { } }
        public long MaxSizeInMegabytes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool RequiresDuplicateDetection { get { throw null; } set { } }
        public Azure.Messaging.ServiceBus.Management.EntityStatus Status { get { throw null; } set { } }
        public bool SupportOrdering { get { throw null; } set { } }
        public string UserMetadata { get { throw null; } set { } }
        public bool Equals(Azure.Messaging.ServiceBus.Management.TopicDescription other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.TopicDescription left, Azure.Messaging.ServiceBus.Management.TopicDescription right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.TopicDescription left, Azure.Messaging.ServiceBus.Management.TopicDescription right) { throw null; }
    }
    public partial class TopicRuntimeInfo
    {
        internal TopicRuntimeInfo() { }
        public System.DateTimeOffset AccessedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Name { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        public int SubscriptionCount { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
    }
    public sealed partial class TrueRuleFilter : Azure.Messaging.ServiceBus.Management.SqlRuleFilter
    {
        public TrueRuleFilter() : base (default(string)) { }
        public override bool Equals(Azure.Messaging.ServiceBus.Management.RuleFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.ServiceBus.Management.TrueRuleFilter left, Azure.Messaging.ServiceBus.Management.TrueRuleFilter right) { throw null; }
        public static bool operator !=(Azure.Messaging.ServiceBus.Management.TrueRuleFilter left, Azure.Messaging.ServiceBus.Management.TrueRuleFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ServiceBusClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.ServiceBusClient, Azure.Messaging.ServiceBus.ServiceBusClientOptions> AddServiceBusClientWithNamespace<TBuilder>(this TBuilder builder, string fullyQualifiedNamespace) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.ServiceBusClient, Azure.Messaging.ServiceBus.ServiceBusClientOptions> AddServiceBusClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.ServiceBus.ServiceBusClient, Azure.Messaging.ServiceBus.ServiceBusClientOptions> AddServiceBusClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
