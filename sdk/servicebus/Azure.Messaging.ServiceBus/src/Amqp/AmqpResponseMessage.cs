// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal sealed class AmqpResponseMessage
    {
        private AmqpResponseMessage(AmqpMessage responseMessage)
        {
            AmqpMessage = responseMessage;
            StatusCode = AmqpMessage.GetResponseStatusCode();
            if (AmqpMessage.ApplicationProperties.Map.TryGetValue<string>(ManagementConstants.Properties.TrackingId, out var trackingId))
            {
                TrackingId = trackingId;
            }

            if (responseMessage.ValueBody != null)
            {
                Map = responseMessage.ValueBody.Value as AmqpMap;
            }
        }

        public AmqpMessage AmqpMessage { get; }

        public AmqpResponseStatusCode StatusCode { get; }

        public string TrackingId { get; }

        public AmqpMap Map { get; }

        public static AmqpResponseMessage CreateResponse(AmqpMessage response)
        {
            return new AmqpResponseMessage(response);
        }

        public TValue GetValue<TValue>(MapKey key)
        {
            if (Map == null)
            {
                throw new ArgumentException(AmqpValue.Name);
            }

            var valueObject = Map[key];
            if (valueObject == null)
            {
                throw new ArgumentException(key.ToString());
            }

            if (!(valueObject is TValue))
            {
                throw new ArgumentException(key.ToString());
            }

            return (TValue)Map[key];
        }

        public IEnumerable<TValue> GetListValue<TValue>(MapKey key)
        {
            if (Map == null)
            {
                throw new ArgumentException(AmqpValue.Name);
            }

            var list = (List<object>)Map[key];

            return list.Cast<TValue>();
        }

        public AmqpSymbol GetResponseErrorCondition()
        {
            var condition = AmqpMessage.ApplicationProperties.Map[ManagementConstants.Response.ErrorCondition];

            return condition is AmqpSymbol amqpSymbol ? amqpSymbol : null;
        }

        public Exception ToMessagingContractException()
        {
            return AmqpMessage.ToMessagingContractException(StatusCode);
        }
    }
}
