// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.Amqp;

namespace TrackOne.Amqp
{
    internal abstract class ActiveClientLinkObject
    {
        private readonly bool isClientToken;
        private readonly string audience;
        private readonly string endpointUri;
        private readonly string[] requiredClaims;
        private readonly AmqpObject amqpLinkObject;
        private DateTime authorizationValidToUtc;

        protected ActiveClientLinkObject(
            AmqpObject amqpLinkObject,
            string audience,
            string endpointUri,
            string[] requiredClaims,
            bool isClientToken,
            DateTime authorizationValidToUtc)
        {
            this.amqpLinkObject = amqpLinkObject;
            this.audience = audience;
            this.endpointUri = endpointUri;
            this.requiredClaims = requiredClaims;
            this.isClientToken = isClientToken;
            this.authorizationValidToUtc = authorizationValidToUtc;
        }

        public bool IsClientToken => isClientToken;

        public string Audience => audience;

        public string EndpointUri => endpointUri;

        public string[] RequiredClaims => (string[])requiredClaims.Clone();

        public DateTime AuthorizationValidToUtc
        {
            get => authorizationValidToUtc;
            set => authorizationValidToUtc = value;
        }

        public AmqpObject LinkObject => amqpLinkObject;

        public abstract AmqpConnection Connection { get; }
    }
}
