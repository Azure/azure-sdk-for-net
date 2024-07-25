// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Tests.Utils.Config
{
    /// <summary>
    /// A basic configuration that allows you to directly set values.
    /// </summary>
    public class BasicConfig : IConfiguration
    {
        private Dictionary<string, object> _values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        /// <inheritdoc />
        public Uri? Endpoint { get; set; }
        /// <inheritdoc />
        public string? Key { get; set; }
        /// <inheritdoc />
        public string? Deployment { get; set; }

        /// <summary>
        /// Adds an additional value to the configuration.
        /// </summary>
        /// <typeparam name="TVal">The type of the value to add.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>The instance for chaining.</returns>
        public BasicConfig AddValue<TVal>(string key, TVal? value)
        {
            if (value != null)
            {
                _values[key] = value;
            }
            else
            {
                _values.Remove(key);
            }

            return this;
        }

        /// <inheritdoc />
        public TVal? GetValue<TVal>(string key)
        {
            if (_values.TryGetValue(key, out object? val)
                && val is TVal cast)
            {
                return cast;
            }

            return default;
        }
    }
}
