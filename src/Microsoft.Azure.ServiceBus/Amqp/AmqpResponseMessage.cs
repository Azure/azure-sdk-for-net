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
    using Microsoft.Azure.Messaging.Amqp;

    public sealed class AmqpResponseMessage
    {
        readonly AmqpMessage responseMessage;

        AmqpResponseMessage(AmqpMessage responseMessage)
        {
            this.responseMessage = responseMessage;
            this.StatusCode = this.responseMessage.GetResponseStatusCode();
            string trackingId;
            if (this.responseMessage.ApplicationProperties.Map.TryGetValue(ManagementConstants.Properties.TrackingId, out trackingId))
            {
                this.TrackingId = trackingId;
            }

            if (responseMessage.ValueBody != null)
            {
                this.Map = responseMessage.ValueBody.Value as AmqpMap;
            }
        }

        public AmqpMessage AmqpMessage
        {
            get { return this.responseMessage; }
        }

        public AmqpResponseStatusCode StatusCode { get; }

        public string TrackingId { get; private set; }

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

            List<object> list = (List<object>)this.Map[key];

            return list.Cast<TValue>();
        }

        public AmqpSymbol GetResponseErrorCondition()
        {
            object condition = this.responseMessage.ApplicationProperties.Map[ManagementConstants.Response.ErrorCondition];

            return condition is AmqpSymbol ? (AmqpSymbol)condition : null;
        }

        public Exception ToMessagingContractException()
        {
            return this.responseMessage.ToMessagingContractException(this.StatusCode);
        }
    }
}