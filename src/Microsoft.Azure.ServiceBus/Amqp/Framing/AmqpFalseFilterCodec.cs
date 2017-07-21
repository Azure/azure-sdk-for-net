// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp.Framing
{
    using Azure.Amqp;

    sealed class AmqpFalseFilterCodec : AmqpFilterCodec
    {
        public static readonly string Name = AmqpConstants.Vendor + ":false-filter:list";
        public const ulong Code = 0x000001370000008;

        public AmqpFalseFilterCodec() : base(Name, Code) { }

        public override string ToString()
        {
            return "false()";
        }
    }
}