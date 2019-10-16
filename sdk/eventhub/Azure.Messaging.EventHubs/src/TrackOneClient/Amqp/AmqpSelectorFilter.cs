// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace TrackOne.Amqp
{
    internal sealed class AmqpSelectorFilter : AmqpDescribed
    {
        public static readonly string Name = AmqpConstants.Apache + ":selector-filter:string";
        public static readonly ulong Code = 0x00000137000000A;

        public AmqpSelectorFilter(string sqlExpression)
            : base(Name, Code)
        {
            Value = sqlExpression;
        }

        public string SqlExpression => Value?.ToString();
    }
}
