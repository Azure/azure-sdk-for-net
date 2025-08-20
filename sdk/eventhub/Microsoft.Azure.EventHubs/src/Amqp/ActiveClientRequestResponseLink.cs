// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Amqp.Management
{
    using System;
    using Microsoft.Azure.Amqp;

    sealed class ActiveClientRequestResponseLink : ActiveClientLinkObject
    {
        readonly RequestResponseAmqpLink link;

        public ActiveClientRequestResponseLink(RequestResponseAmqpLink link, string audience, string endpointUri, string[] requiredClaims, bool isClientToken, DateTime authorizationValidToUtc)
            : base(link, audience, endpointUri, requiredClaims, isClientToken, authorizationValidToUtc)
        {
            this.link = link;
        }

        public RequestResponseAmqpLink Link => this.link;

        public override AmqpConnection Connection => this.link.Session.Connection;
    }
}