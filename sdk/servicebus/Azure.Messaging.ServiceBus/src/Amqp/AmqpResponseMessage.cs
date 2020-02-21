// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;

    internal sealed class AmqpResponseMessage
    {
        private readonly AmqpMessage _responseMessage;

        private AmqpResponseMessage(AmqpMessage responseMessage)
        {
            this._responseMessage = responseMessage;
            this.StatusCode = this._responseMessage.GetResponseStatusCode();
            if (this._responseMessage.ApplicationProperties.Map.TryGetValue<string>(ManagementConstants.Properties.TrackingId, out var trackingId))
            {
                this.TrackingId = trackingId;
            }

            if (responseMessage.ValueBody != null)
            {
                this.Map = responseMessage.ValueBody.Value as AmqpMap;
            }
        }

        public AmqpMessage AmqpMessage => this._responseMessage;

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
            var condition = this._responseMessage.ApplicationProperties.Map[ManagementConstants.Response.ErrorCondition];

            return condition is AmqpSymbol amqpSymbol ? amqpSymbol : null;
        }

        //public Exception ToMessagingContractException()
        //{
        //    return this._responseMessage.ToMessagingContractException(this.StatusCode);
        //}
    }
}
