// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Amqp
{
    using System;
    using Microsoft.Azure.Amqp;

    abstract class ActiveClientLinkObject
    {
        readonly bool isClientToken;
        readonly string audience;
        readonly string endpointUri;
        readonly string[] requiredClaims;
        readonly AmqpObject amqpLinkObject;
        DateTime authorizationValidToUtc;

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

        public bool IsClientToken => this.isClientToken;

        public string Audience => this.audience;

        public string EndpointUri => this.endpointUri;

        public string[] RequiredClaims => (string[])this.requiredClaims.Clone();

        public DateTime AuthorizationValidToUtc
        {
            get => this.authorizationValidToUtc;
            set => this.authorizationValidToUtc = value;
        }

        public AmqpObject LinkObject => this.amqpLinkObject;

        public abstract AmqpConnection Connection { get; }
    }
}
