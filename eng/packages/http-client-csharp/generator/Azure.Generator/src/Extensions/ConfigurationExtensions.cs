// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator;

namespace Azure.Generator.Extensions
{
    /// <summary>
    /// Extension methods for Configuration class.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Checks if model namespace is enabled in configuration.
        /// </summary>
        public static bool UseModelNamespace(this Configuration config) =>
            UseModelNamespace(config.AdditionalConfigurationOptions);

        internal static bool UseModelNamespace(IReadOnlyDictionary<string, BinaryData> options)
        {
            return options.TryGetValue("model-namespace", out var value) &&
                   bool.TryParse(value.ToString(), out var parsed) &&
                   parsed;
        }

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