// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    /// <summary>
    ///   The set of well-known properties associated with Service Bus diagnostics.
    /// </summary>
    ///
    internal static class DiagnosticProperty
    {
        /// <summary>The namespace used for the Service Bus diagnostic scope.</summary>
        public const string DiagnosticNamespace = "Azure.Messaging.ServiceBus";

        /// <summary>The namespace used for the Azure Resource Manager provider namespace.</summary>
        public const string ResourceProviderNamespace = "Microsoft.ServiceBus";

        /// <summary>The value which identifies the Service Bus diagnostics context.</summary>
        public const string ServiceBusServiceContext = "servicebus";

        /// <summary>
        ///   The activity name associated with events.
        /// </summary>
        public static string MessageActivityName { get; } = "Message";

        /// <summary>
        ///   The activity name associated with the send operation.
        /// </summary>
        public static string SendActivityName { get; } = "ServiceBusSender.Send";

        /// <summary>
        ///   The activity name associated with the schedule operation.
        /// </summary>
        public static string ScheduleActivityName { get; } = "ServiceBusSender.Schedule";

        /// <summary>
        ///   The activity name associated with the cancel scheduled message operation.
        /// </summary>
        public static string CancelActivityName { get; } = "ServiceBusSender.Cancel";

        /// <summary>
        ///   The activity name associated with the receive operation.
        /// </summary>
        public static string ReceiveActivityName { get; } = "ServiceBusReceiver.Receive";

        /// <summary>
        ///   The activity name associated with the receive operation.
        /// </summary>
        public static string ReceiveDeferredActivityName { get; } = "ServiceBusReceiver.ReceiveDeferred";

        /// <summary>
        ///   The activity name associated with the peek operation.
        /// </summary>
        public static string PeekActivityName { get; } = "ServiceBusReceiver.Peek";

        /// <summary>
        ///   The activity name associated with the abandon operation.
        /// </summary>
        public static string AbandonActivityName { get; } = "ServiceBusReceiver.Abandon";

        /// <summary>
        ///   The activity name associated with the complete operation.
        /// </summary>
        public static string CompleteActivityName { get; } = "ServiceBusReceiver.Complete";

        /// <summary>
        ///   The activity name associated with the dead letter operation.
        /// </summary>
        public static string DeadLetterActivityName { get; } = "ServiceBusReceiver.DeadLetter";

        /// <summary>
        ///   The activity name associated with the defer operation.
        /// </summary>
        public static string DeferActivityName { get; } = "ServiceBusReceiver.Defer";

        /// <summary>
        ///   The activity name associated with the delete operation.
        /// </summary>
        public static string DeleteActivityName { get; } = "ServiceBusReceiver.Delete";

        /// <summary>
        ///   The activity name associated with the purge operation.
        /// </summary>
        public static string PurgeActivityName { get; } = "ServiceBusReceiver.Purge";

        /// <summary>
        ///   The activity name associated with the renew message lock operation.
        /// </summary>
        public static string RenewMessageLockActivityName { get; } = "ServiceBusReceiver.RenewMessageLock";

        /// <summary>
        ///   The activity name associated with the renew session lock operation.
        /// </summary>
        public static string RenewSessionLockActivityName { get; } = "ServiceBusSessionReceiver.RenewSessionLock";

        /// <summary>
        ///   The activity name associated with the get session state
        ///   operation.
        /// </summary>
        public static string GetSessionStateActivityName { get; } = "ServiceBusSessionReceiver.GetSessionState";

        /// <summary>
        ///   The activity name associated with the set session state
        ///   operation.
        /// </summary>
        public static string SetSessionStateActivityName { get; } = "ServiceBusSessionReceiver.SetSessionState";

        /// <summary>
        ///   The activity name associated with processing a single message.
        /// </summary>
        public static string ProcessMessageActivityName { get; } = "ServiceBusProcessor.ProcessMessage";

        /// <summary>
        ///   The activity name associated with the set session state operation.
        /// </summary>
        public static string ProcessSessionMessageActivityName { get; } = "ServiceBusSessionProcessor.ProcessSessionMessage";

        /// <summary>
        /// The activity name associated with the add rule operation using the <see cref="ServiceBusRuleManager"/>.
        /// </summary>
        public static string CreateRuleActivityName { get; } = "ServiceBusRuleManager.CreateRule";

        /// <summary>
        /// The activity name associated with the delete rule operation using the <see cref="ServiceBusRuleManager"/>.
        /// </summary>
        public static string DeleteRuleActivityName { get; } = "ServiceBusRuleManager.DeleteRule";

        /// <summary>
        /// The activity name associated with the get rules operation using the <see cref="ServiceBusRuleManager"/>.
        /// </summary>
        public static string GetRulesActivityName { get; } = "ServiceBusRuleManager.GetRules";
    }
}
