// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    internal static class Constants
    {
        public const int MaxMessageIdLength = 128;

        public const int MaxPartitionKeyLength = 128;

        public const int MaxSessionIdLength = 128;

        public const string PathDelimiter = @"/";

        public const int RuleNameMaximumLength = 50;

        public const int MaximumSqlRuleFilterStatementLength = 1024;

        public const int MaximumSqlRuleActionStatementLength = 1024;

        public const int DefaultClientPrefetchCount = 0;

        public const int MaxDeadLetterReasonLength = 4096;

        public const long DefaultLastPeekedSequenceNumber = 0;

        public static readonly TimeSpan DefaultOperationTimeout = TimeSpan.FromMinutes(1);

        public static readonly TimeSpan ClientPumpRenewLockTimeout = TimeSpan.FromMinutes(5);

        public static readonly TimeSpan MaximumRenewBufferDuration = TimeSpan.FromSeconds(10);

        public static readonly TimeSpan DefaultRetryDeltaBackoff = TimeSpan.FromSeconds(3);

        public static readonly TimeSpan NoMessageBackoffTimeSpan = TimeSpan.FromSeconds(5);

        public const string SasTokenType = "servicebus.windows.net:sastoken";

        public const string JsonWebTokenType = "jwt";

        public const string AadServiceBusAudience = "https://servicebus.azure.net/";

        /// Represents 00:00:00 UTC Thursday 1, January 1970.
        public static readonly DateTime EpochTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public const int WellKnownPublicPortsLimit = 1023;

        public const string DefaultScope = "https://servicebus.azure.net/.default";

        /// <summary>
        /// The message appended to exceptions returned from the service that contains a link to the troubleshooting guide.
        /// Usage errors with obvious causes do not contain this message.
        /// </summary>
        public const string TroubleshootingMessage =
            "For troubleshooting information, see https://aka.ms/azsdk/net/servicebus/exceptions/troubleshoot.";
    }
}
