// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.ServiceBus.Management
{
    using System;

    internal class ManagementClientConstants
    {
        public const int QueueNameMaximumLength = 260;
        public const int TopicNameMaximumLength = 260;
        public const int SubscriptionNameMaximumLength = 50;
        public const int RuleNameMaximumLength = 50;

        public const string AtomNs = "http://www.w3.org/2005/Atom";
        public const string SbNs = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect";
        public const string XmlSchemaInstanceNs = "http://www.w3.org/2001/XMLSchema-instance";
        public const string XmlSchemaNs = "http://www.w3.org/2001/XMLSchema";
        public const string ApiVersion = "2017-04";

        public static char[] InvalidEntityPathCharacters = { '@', '?', '#', '*' };
    }
}
