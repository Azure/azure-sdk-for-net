// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    internal abstract class AmqpRuleActionCodec : DescribedList
    {
        protected AmqpRuleActionCodec(string name, ulong code)
            : base(name, code)
        {
        }
    }
}
