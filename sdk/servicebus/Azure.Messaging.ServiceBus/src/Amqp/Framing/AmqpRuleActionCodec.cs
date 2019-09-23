// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Amqp.Framing
{
    using Microsoft.Azure.Amqp.Framing;

    internal abstract class AmqpRuleActionCodec : DescribedList
    {
        protected AmqpRuleActionCodec(string name, ulong code)
            : base(name, code)
        {
        }
    }
}
