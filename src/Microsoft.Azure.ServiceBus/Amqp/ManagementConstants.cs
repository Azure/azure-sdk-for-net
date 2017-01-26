// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging.Amqp
{
    using Microsoft.Azure.Amqp.Encoding;

    static class ManagementConstants
    {
        public const string Microsoft = "com.microsoft";

        public static class Request
        {
            public const string Operation = "operation";
        }

        public static class Response
        {
            public const string StatusCode = "statusCode";
            public const string StatusDescription = "statusDescription";            public const string ErrorCondition = "errorCondition";
        }

        public static class Operations
        {
            public const string RenewLockOperation = Microsoft + ":renew-lock";
            public const string ReceiveBySequenceNumberOperation = Microsoft + ":receive-by-sequence-number";
            public const string UpdateDispositionOperation = Microsoft + ":update-disposition";
            public const string RenewSessionLockOperation = Microsoft + ":renew-session-lock";
            public const string SetSessionStateOperation = Microsoft + ":set-session-state";
            public const string GetSessionStateOperation = Microsoft + ":get-session-state";
            public const string PeekMessageOperation = Microsoft + ":peek-message";
            public const string AddRuleOperation = Microsoft + ":add-rule";
            public const string RemoveRuleOperation = Microsoft + ":remove-rule";
            public const string ScheduleMessageOperation = Microsoft + ":schedule-message";
            public const string CancelScheduledMessageOperation = Microsoft + ":cancel-scheduled-message";
        }

        public static class Properties
        {
            public static readonly MapKey ServerTimeout = new MapKey(Microsoft + ":server-timeout");
            public static readonly MapKey TrackingId = new MapKey(Microsoft + ":tracking-id");

            public static readonly MapKey SessionState = new MapKey("session-state");
            public static readonly MapKey LockToken = new MapKey("lock-token");
            public static readonly MapKey LockTokens = new MapKey("lock-tokens");
            public static readonly MapKey SequenceNumbers = new MapKey("sequence-numbers");
            public static readonly MapKey Expirations = new MapKey("expirations");
            public static readonly MapKey Expiration = new MapKey("expiration");
            public static readonly MapKey SessionId = new MapKey("session-id");
            public static readonly MapKey MessageId = new MapKey("message-id");
            public static readonly MapKey PartitionKey = new MapKey("partition-key");

            public static readonly MapKey ReceiverSettleMode = new MapKey("receiver-settle-mode");
            public static readonly MapKey Message = new MapKey("message");
            public static readonly MapKey Messages = new MapKey("messages");
            public static readonly MapKey DispositionStatus = new MapKey("disposition-status");

            public static readonly MapKey FromSequenceNumber = new MapKey("from-sequence-number");
            public static readonly MapKey MessageCount = new MapKey("message-count");

            public static readonly MapKey RuleName = new MapKey("rule-name");
            public static readonly MapKey RuleDescription = new MapKey("rule-description");
            public static readonly MapKey SqlFilter = new MapKey("sql-filter");
            public static readonly MapKey SqlRuleAction = new MapKey("sql-rule-action");
            public static readonly MapKey CorrelationFilter = new MapKey("correlation-filter");
            public static readonly MapKey Expression = new MapKey("expression");
            public static readonly MapKey CorrelationId = new MapKey("correlation-id");
            public static readonly MapKey To = new MapKey("to");
            public static readonly MapKey ReplyTo = new MapKey("reply-to");
            public static readonly MapKey Label = new MapKey("label");
            public static readonly MapKey ReplyToSessionId = new MapKey("reply-to-session-id");
            public static readonly MapKey ContentType = new MapKey("content-type");
            public static readonly MapKey CorrelationFilterProperties = new MapKey("properties");
        }
    }
}