﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    internal partial class SubscriptionListResult
    {
        internal static SubscriptionListResult DeserializeSubscriptionListResult(JsonElement element)
        {
            Optional<IReadOnlyList<SubscriptionData>> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SubscriptionData> array = new List<SubscriptionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SubscriptionData.DeserializeSubscriptionData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new SubscriptionListResult(Optional.ToList(value), nextLink);
        }
    }
}
