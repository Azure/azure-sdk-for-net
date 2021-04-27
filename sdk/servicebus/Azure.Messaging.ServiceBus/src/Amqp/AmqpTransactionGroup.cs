// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Transaction;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal class AmqpTransactionGroup
    {
        public FaultTolerantAmqpObject<AmqpSession> Session { get; }

        public FaultTolerantAmqpObject<Controller> Controller { get; }

        public AmqpTransactionGroup(FaultTolerantAmqpObject<AmqpSession> session, FaultTolerantAmqpObject<Controller> controller)
        {
            Session = session;
            Controller = controller;
        }
    }
}
