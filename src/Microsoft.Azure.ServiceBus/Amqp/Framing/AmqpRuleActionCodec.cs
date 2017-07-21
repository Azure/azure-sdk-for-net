// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp.Framing
{
    using Azure.Amqp.Framing;

    abstract class AmqpRuleActionCodec : DescribedList
    {
        protected AmqpRuleActionCodec(string name, ulong code)
            : base(name, code)
        {
        }
    }
}
