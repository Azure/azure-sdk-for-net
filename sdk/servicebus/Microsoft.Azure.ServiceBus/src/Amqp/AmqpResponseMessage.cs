// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Azure.Amqp;
    using Azure.Amqp.Encoding;
    using Azure.Amqp.Framing;

    internal sealed class AmqpResponseMessage
    {
        readonly AmqpMessage responseMessage;

        AmqpResponseMessage(AmqpMessage responseMessage)
        {
            this.responseMessage = responseMessage;
            this.StatusCode = this.responseMessage.GetResponseStatusCode();
            if (this.responseMessage.ApplicationProperties.Map.TryGetValue<string>(ManagementConstants.Properties.TrackingId, out var trackingId))
            {
                this.TrackingId = trackingId;
            }

            if (responseMessage.ValueBody != null)
            {
                this.Map = responseMessage.ValueBody.Value as AmqpMap;
            }
        }

        public AmqpMessage AmqpMessage => this.responseMessage;

        public AmqpResponseStatusCode StatusCode { get; }

        public string TrackingId { get; }

        public AmqpMap Map { get; }

        public static AmqpResponseMessage CreateResponse(AmqpMessage response)
        {
            return new AmqpResponseMessage(response);
        }

        public TValue GetValue<TValue>(MapKey key)
        {
            if (this.Map == null)
            {
                throw new ArgumentException(AmqpValue.Name);
            }

            var valueObject = this.Map[key];
            if (valueObject == null)
            {
                throw new ArgumentException(key.ToString());
            }

            if (!(valueObject is TValue))
            {
                throw new ArgumentException(key.ToString());
            }

            return (TValue)this.Map[key];
        }

        public IEnumerable<TValue> GetListValue<TValue>(MapKey key)
        {
            if (this.Map == null)
            {
                throw new ArgumentException(AmqpValue.Name);
            }

            var list = (List<object>)this.Map[key];

            return list.Cast<TValue>();
        }

        public AmqpSymbol GetResponseErrorCondition()
        {
            var condition = this.responseMessage.ApplicationProperties.Map[ManagementConstants.Response.ErrorCondition];

            return condition is AmqpSymbol amqpSymbol ? amqpSymbol : null;
        }

        public Exception ToMessagingContractException()
        {
            return this.responseMessage.ToMessagingContractException(this.StatusCode);
        }
    }
}