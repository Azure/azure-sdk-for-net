﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Communication.JobRouter
{
    internal static class Extensions
    {
        public static IDictionary<TK, TV?> Append<TK, TV>(this IDictionary<TK, TV?> first, IDictionary<TK, TV?> second)
        {
            second.ToList().ForEach(pair => first[pair.Key] = pair.Value);
            return second;
        }
    }
}

#nullable restore
