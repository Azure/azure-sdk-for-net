// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using Microsoft.Azure.ServiceBus.Grpc;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Grpc
{
    internal static class SettlementExtensions
    {
        internal static object GetPropertyValue(this SettlementProperties properties)
        {
            return properties.ValuesCase switch
            {
                SettlementProperties.ValuesOneofCase.LongValue => properties.LongValue,
                SettlementProperties.ValuesOneofCase.UlongValue => properties.UlongValue,
                SettlementProperties.ValuesOneofCase.DoubleValue => properties.DoubleValue,
                SettlementProperties.ValuesOneofCase.FloatValue => properties.FloatValue,
                SettlementProperties.ValuesOneofCase.IntValue => properties.IntValue,
                SettlementProperties.ValuesOneofCase.UintValue => properties.UintValue,
                SettlementProperties.ValuesOneofCase.BoolValue => properties.BoolValue,
                SettlementProperties.ValuesOneofCase.StringValue => properties.StringValue,
                _ => null
            };
        }
    }
}
#endif