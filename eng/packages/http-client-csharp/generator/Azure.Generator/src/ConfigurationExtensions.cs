// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator;

namespace Azure.Generator
{
    internal static class ConfigurationExtensions
    {
        public static bool UseModelNamespace(this Configuration config) =>
            UseModelNamespace(config.AdditionalConfigurationOptions);

        internal static bool UseModelNamespace(IReadOnlyDictionary<string, BinaryData> options)
        {
            return !options.TryGetValue("model-namespace", out var value)
                   // default to true if no value is provided or it cannot be parsed
                   || !bool.TryParse(value.ToString(), out var parsed)
                   || parsed;
        }
    }
}