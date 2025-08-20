// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using Microsoft.Azure.Amqp;
    using System;

    sealed class ActiveRequestResponseLink : ActiveClientLinkObject
    {
        public ActiveRequestResponseLink(RequestResponseAmqpLink link, Uri endpointUri, string[] audience, string[] requiredClaims, DateTime authorizationValidUntilUtc)
            : base(link, endpointUri, audience, requiredClaims, authorizationValidUntilUtc)
        {
            this.Link = link;
        }

        public RequestResponseAmqpLink Link { get; }

        public override AmqpConnection Connection => this.Link.Session.Connection;
    }
}
