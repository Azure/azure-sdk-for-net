// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator;

namespace Azure.Generator.Management.Extensions
{
    /// <summary>
    /// Extension methods for Configuration class.
    /// </summary>
    internal static class ConfigurationExtensions
    {
        /// <summary>
        /// Gets the custom namespace configured in the emitter options, if any.
        /// </summary>
        public static string? GetNamespace(this Configuration config)
        {
            if (config.AdditionalConfigurationOptions.TryGetValue("namespace", out var value))
            {
                var namespaceValue = value.ToString();
                return !string.IsNullOrWhiteSpace(namespaceValue) ? namespaceValue : null;
            }
            return null;
        }
    }
}
