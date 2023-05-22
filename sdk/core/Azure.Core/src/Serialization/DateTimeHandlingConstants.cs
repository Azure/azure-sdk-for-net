// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Serialization
{
    internal class DateTimeHandlingConstants
    {
        // From: https://github.com/Azure/autorest.csharp/blob/d835b0b7bffae08c1037ccc5824e928eaac55b96/src/assets/Generator.Shared/TypeFormatters.cs#L14
        internal const string RoundtripZFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ";
    }
}
