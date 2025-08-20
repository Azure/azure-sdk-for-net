// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Amqp
{
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;

    sealed class AmqpSelectorFilter : AmqpDescribed
    {
        public static readonly string Name = AmqpConstants.Apache + ":selector-filter:string";
        public static readonly ulong Code = 0x00000137000000A;

        public AmqpSelectorFilter(string sqlExpression)
            : base(Name, Code)
        {
            this.Value = sqlExpression;
        }

        public string SqlExpression => this.Value?.ToString();
    }
}
