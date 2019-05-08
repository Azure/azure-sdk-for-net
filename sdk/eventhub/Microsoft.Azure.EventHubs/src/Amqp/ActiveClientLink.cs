// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Amqp
{
    using System;
    using Azure.Amqp;

    sealed class ActiveClientLink : ActiveClientLinkObject
    {
        readonly AmqpLink link;

        public ActiveClientLink(AmqpLink link, string audience, string endpointUri, string[] requiredClaims, bool isClientToken, DateTime authorizationValidToUtc)
            : base(link, audience, endpointUri, requiredClaims, isClientToken, authorizationValidToUtc)
        {
            this.link = link;
        }

        public AmqpLink Link => this.link;

        public override AmqpConnection Connection => this.link.Session.Connection;
    }
}