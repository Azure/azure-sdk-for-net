// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Amqp;

namespace TrackOne.Amqp.Management
{
    internal sealed class ActiveClientRequestResponseLink : ActiveClientLinkObject
    {
        private readonly RequestResponseAmqpLink link;

        public ActiveClientRequestResponseLink(RequestResponseAmqpLink link, string audience, string endpointUri, string[] requiredClaims, bool isClientToken, DateTime authorizationValidToUtc)
            : base(link, audience, endpointUri, requiredClaims, isClientToken, authorizationValidToUtc)
        {
            this.link = link;
        }

        public RequestResponseAmqpLink Link => link;

        public override AmqpConnection Connection => link.Session.Connection;
    }
}
