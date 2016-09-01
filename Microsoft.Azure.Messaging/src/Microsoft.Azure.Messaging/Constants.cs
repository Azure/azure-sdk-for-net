// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging
{
    using System;

    static class Constants
    {
        // String used for versioning
        const string VersionYear = "2011";
        const string VersionMonth = "06";
        const string ServiceBusService = "servicebus";
        public const string Namespace = @"http://schemas.microsoft.com/netservices" + "/" + VersionYear + "/" + VersionMonth + "/" + ServiceBusService;

        public const int MaxMessageIdLength = 128;
        public const int MaxDestinationLength = 128;
        public const int MaxPartitionKeyLength = 128;
        public const int MaxSessionIdLength = 128;

        public static readonly int MaximumMessageHeaderPropertySize = UInt16.MaxValue;
    }
}
