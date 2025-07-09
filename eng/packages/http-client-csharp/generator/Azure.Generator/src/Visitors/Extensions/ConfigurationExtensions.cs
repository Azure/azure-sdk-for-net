// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator;

namespace Azure.Generator.Visitors.Extensions
{
    internal static class ConfigurationExtensions
    {
        public static bool UseModelNamespace(this Configuration config) =>
            UseModelNamespace(config.AdditionalConfigurationOptions);

        internal static bool UseModelNamespace(IReadOnlyDictionary<string, BinaryData> options)
        {
            return options.TryGetValue("model-namespace", out var value) &&
                   bool.TryParse(value.ToString(), out var parsed) &&
                   parsed;
        }
    }
}