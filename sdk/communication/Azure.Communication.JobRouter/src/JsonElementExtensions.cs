// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    internal static class JsonElementExtensions
    {
        public static TimeSpan GetTimeSpan(in this JsonElement element) => element.GetTimeSpan("c");
    }
}
