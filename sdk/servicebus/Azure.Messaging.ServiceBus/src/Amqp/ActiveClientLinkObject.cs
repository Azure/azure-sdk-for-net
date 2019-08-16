// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;

namespace Azure.Messaging.ServiceBus.Amqp
{
    using Microsoft.Azure.Amqp;
    using System;

    internal class ActiveClientLinkObject
    {
        public ActiveClientLinkObject(AmqpObject link, AmqpConnection connection, Uri endpointUri, string[] audience, string[] requiredClaims, DateTime authorizationValidUntilUtc)
        {
            EndpointUri = endpointUri;
            Audience = audience;
            RequiredClaims = requiredClaims.ToArray();
            AuthorizationValidUntilUtc = authorizationValidUntilUtc;
            Link = link;
            Connection = connection;
        }

        public string[] Audience { get; }

        public Uri EndpointUri { get; }

        public string[] RequiredClaims { get; }

        public DateTime AuthorizationValidUntilUtc { get; set; }

        public AmqpObject Link { get; }

        public AmqpConnection Connection { get; }
    }
}
