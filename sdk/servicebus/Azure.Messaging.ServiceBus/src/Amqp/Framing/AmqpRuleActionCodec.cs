// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
