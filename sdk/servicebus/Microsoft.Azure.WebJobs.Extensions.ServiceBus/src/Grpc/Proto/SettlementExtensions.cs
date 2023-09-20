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
            if (properties.HasLongValue)
            {
                return properties.LongValue;
            }
            if (properties.HasUlongValue)
            {
                return properties.UlongValue;
            }
            if (properties.HasDoubleValue)
            {
                return properties.DoubleValue;
            }
            if (properties.HasFloatValue)
            {
                return properties.FloatValue;
            }
            if (properties.HasUintValue)
            {
                return properties.UintValue;
            }
            if (properties.HasIntValue)
            {
                return properties.IntValue;
            }
            if (properties.HasBoolValue)
            {
                return properties.BoolValue;
            }
            if (properties.HasStringValue)
            {
                return properties.StringValue;
            }

            return null;
        }
    }
}
#endif