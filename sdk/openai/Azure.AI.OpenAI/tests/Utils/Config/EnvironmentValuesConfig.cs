// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.AI.OpenAI.Tests.Utils.Config
{
    /// <summary>
    /// Configuration that reads from environment variables.
    /// </summary>
    public class EnvironmentValuesConfig : INamedConfiguration
    {
        private const char ENV_KEY_SEPARATOR = '_';
        private const string SUFFIX_AOAI_API_KEY = "API_KEY";
        private const string SUFFIX_AOAI_ENDPOINT = "ENDPOINT";
        private const string SUFFIX_AOAI_DEPLOYMENT = "DEPLOYMENT";

        private readonly string _prefix;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="prefix">The environment value prefix to use. For example AZURE_OPENAI.</param>
        /// <exception cref="ArgumentNullException">The prefix specified was null.</exception>
        public EnvironmentValuesConfig(string prefix)
        {
            _prefix = prefix
                ?.TrimEnd(ENV_KEY_SEPARATOR)
                .ToUpperInvariant()
                ?? throw new ArgumentNullException(nameof(prefix));

            Endpoint = GetValue<Uri>(SUFFIX_AOAI_ENDPOINT);
            Key = GetValue<string>(SUFFIX_AOAI_API_KEY);
            Deployment = GetValue<string>(SUFFIX_AOAI_DEPLOYMENT);
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="prefix">The environment value prefix to use. For example AZURE_OPENAI.</param>
        /// <param name="clientName">The specific type of client we want to get environment variable for</param>
        /// <exception cref="ArgumentNullException">The prefix specified was null.</exception>
        public EnvironmentValuesConfig(string prefix, string clientName)
            : this($"{prefix}{ENV_KEY_SEPARATOR}{clientName}")
        {
            Name = clientName;
        }

        /// <inheritdoc />
        public string? Name { get; }

        /// <inheritdoc />
        public Uri? Endpoint { get; }

        /// <inheritdoc />
        public string? Key { get; }

        /// <inheritdoc />
        public string? Deployment { get; }

        /// <inheritdoc />
        public TVal? GetValue<TVal>(string key)
        {
            string envKey = $"{_prefix}{ENV_KEY_SEPARATOR}{key.ToUpperInvariant()}";

            string? value = Environment.GetEnvironmentVariable(envKey);
            if (value == null)
            {
                return default;
            }
            else if (value is TVal val)
            {
                return val;
            }
            else
            {
                var defaultConverter = TypeDescriptor.GetConverter(typeof(TVal));
                return (TVal?)defaultConverter.ConvertFromInvariantString(value);
            }
        }
    }
}
