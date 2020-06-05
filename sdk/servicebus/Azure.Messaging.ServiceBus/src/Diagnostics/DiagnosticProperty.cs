// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    /// <summary>
    ///   The set of well-known properties associated with Service Bus diagnostics.
    /// </summary>
    ///
    internal static class DiagnosticProperty
    {
        /// <summary>The common root for activity names in the Service Bus context.</summary>
        public const string BaseActivityName = "Azure.Messaging.ServiceBus";

        /// <summary>The attribute which represents a unique identifier for the diagnostics context.</summary>
        public const string DiagnosticIdAttribute = "Diagnostic-Id";

        /// <summary>The attribute which represents the message Id.</summary>
        public const string MessageIdAttribute = "MessageId";

        /// <summary>The attribute which represents the session Id. Only populated for sessions.</summary>
        public const string SessionIdAttribute = "SessionId";

        /// <summary>The attribute which represents the sequence number.</summary>
        public const string SequenceNumbersAttribute = "SequenceNumber";

        /// <summary>The attribute which represents the requested message count for peek/receive operations.</summary>
        public const string RequestedMessageCountAttribute = "RequestedMessageCount";

        /// <summary>The attribute which represents the lock tokens.</summary>
        public const string LockTokensAttribute = "LockTokens";

        /// <summary>The attribute which represents the message lock expiration time.</summary>
        public const string LockedUntilAttribute = "LockedUntilUtc";

        /// <summary>The attribute which represents the type of diagnostics information.</summary>
        public const string TypeAttribute = "kind";

        /// <summary>The attribute which represents the Azure service to associate with diagnostics information.</summary>
        public const string ServiceContextAttribute = "component";

        /// <summary>The attribute which represents the Service Bus entity instance to associate with diagnostics information.</summary>
        public const string EntityAttribute = "message_bus.destination";

        /// <summary>The attribute which represents the fully-qualified endpoint address of the Service Bus namespace to associate with diagnostics information.</summary>
        public const string EndpointAttribute = "peer.address";

        /// <summary>The value which identifies the Service Bus diagnostics context.</summary>
        public const string ServiceBusServiceContext = "servicebus";

        /// <summary>The attribute which represents the kind of diagnostic scope.</summary>
        public const string KindAttribute = "kind";

        /// <summary>The value which identifies the Event Processor scope kind.</summary>
        public const string ServerKind = "server";

        /// <summary>The value which identifies the message client scope kind.</summary>
        public const string ClientKind = "client";

        /// <summary>The value which identifies an Service Bus entity producer as the type associated with the diagnostics information.</summary>
        public const string SenderKind = "sender";

        /// <summary>
        ///   The activity name associated with events.
        /// </summary>
        ///
        public static string MessageActivityName { get; } = "Message";

        /// <summary>
        ///   The activity name associated with the send operation.
        /// </summary>
        ///
        public static string SendActivityName { get; } = "ServiceBusSender.Send";

        /// <summary>
        ///   The activity name associated with the schedule operation.
        /// </summary>
        ///
        public static string ScheduleActivityName { get; } = "ServiceBusSender.Schedule";

        /// <summary>
        ///   The activity name associated with the cancel
        ///   scheduled message operation.
        /// </summary>
        ///
        public static string CancelActivityName { get; } = "ServiceBusSender.Cancel";

        /// <summary>
        ///   The activity name associated with the receive
        ///   operation.
        /// </summary>
        ///
        public static string ReceiveActivityName { get; } = "ServiceBusReceiver.Receive";

        /// <summary>
        ///   The activity name associated with the receive
        ///   operation.
        /// </summary>
        ///
        public static string ReceiveDeferredActivityName { get; } = "ServiceBusReceiver.ReceiveDeferred";

        /// <summary>
        ///   The activity name associated with the peek
        ///   operation.
        /// </summary>
        ///
        public static string PeekActivityName { get; } = "ServiceBusReceiver.Peek";

        /// <summary>
        ///   The activity name associated with the abandon
        ///   operation.
        /// </summary>
        ///
        public static string AbandonActivityName { get; } = "ServiceBusReceiver.Abandon";

        /// <summary>
        ///   The activity name associated with the complete
        ///   operation.
        /// </summary>
        ///
        public static string CompleteActivityName { get; } = "ServiceBusReceiver.Complete";

        /// <summary>
        ///   The activity name associated with the dead letter
        ///   operation.
        /// </summary>
        ///
        public static string DeadLetterActivityName { get; } = "ServiceBusReceiver.DeadLetter";

        /// <summary>
        ///   The activity name associated with the defer
        ///   operation.
        /// </summary>
        ///
        public static string DeferActivityName { get; } = "ServiceBusReceiver.Defer";

        /// <summary>
        ///   The activity name associated with the renew message lock
        ///   operation.
        /// </summary>
        ///
        public static string RenewMessageLockActivityName { get; } = "ServiceBusReceiver.RenewMessageLock";

        /// <summary>
        ///   The activity name associated with the renew session lock
        ///   operation.
        /// </summary>
        ///
        public static string RenewSessionLockActivityName { get; } = "ServiceBusSessionReceiver.RenewSessionLock";

        /// <summary>
        ///   The activity name associated with the get session state
        ///   operation.
        /// </summary>
        ///
        public static string GetSessionStateActivityName { get; } = "ServiceBusSessionReceiver.GetSessionState";

        /// <summary>
        ///   The activity name associated with the set session state
        ///   operation.
        /// </summary>
        ///
        public static string SetSessionStateActivityName { get; } = "ServiceBusSessionReceiver.SetSessionState";

        /// <summary>
        ///   The activity name associated with the get session state
        ///   operation.
        /// </summary>
        ///
        public static string ProcessMessageActivityName { get; } = "ServiceBusProcessor.ProcessMessage";

        /// <summary>
        ///   The activity name associated with the set session state
        ///   operation.
        /// </summary>
        ///
        public static string ProcessSessionMessageActivityName { get; } = "ServiceBusSessionProcessor.ProcessSessionMessage";
    }
}
