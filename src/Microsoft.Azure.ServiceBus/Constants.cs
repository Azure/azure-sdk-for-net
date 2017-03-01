// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    static class Constants
    {
        public const int MaxMessageIdLength = 128;

        public const int MaxDestinationLength = 128;

        public const int MaxPartitionKeyLength = 128;

        public const int MaxSessionIdLength = 128;

        public const string PathDelimiter = @"/";

        public const int RuleNameMaximumLength = 50;

        public const int MaximumSqlFilterStatementLength = 1024;

        public const int MaximumSqlRuleActionStatementLength = 1024;

        public static readonly int MaximumMessageHeaderPropertySize = ushort.MaxValue;

        public static readonly long DefaultLastPeekedSequenceNumber = 0;

        public static readonly TimeSpan DefaultOperationTimeout = TimeSpan.FromMinutes(1);

        public static readonly TimeSpan ClientPumpRenewLockTimeout = TimeSpan.FromMinutes(5);

        public static readonly TimeSpan MinimumLockDuration = TimeSpan.FromSeconds(5);

        public static readonly TimeSpan MaximumRenewBufferDuration = TimeSpan.FromSeconds(10);
    }
}