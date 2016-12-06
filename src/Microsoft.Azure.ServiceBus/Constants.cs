// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    static class Constants
    {
        public const int MaxMessageIdLength = 128;

        public const int MaxDestinationLength = 128;

        public const int MaxPartitionKeyLength = 128;

        public const int MaxSessionIdLength = 128;

        public static readonly int MaximumMessageHeaderPropertySize = ushort.MaxValue;
    }
}