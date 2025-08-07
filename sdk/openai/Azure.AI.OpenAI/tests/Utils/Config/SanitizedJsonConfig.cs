// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using OpenAI.TestFramework.Utils;

namespace Azure.AI.OpenAI.Tests.Utils.Config
{
    /// <summary>
    /// A sanitized JSON configuration. This will automatically sanitize the Endpoint, Key, subscription ID and resource group in the configuration
    /// file. Please make sure to add any additional sanitization rules to the <see cref="SANITIZERS"/> dictionary.
    /// </summary>
    public class SanitizedJsonConfig : IConfiguration
    {
        /// <summary>
        /// The string to use when masking sensitive data.
        /// </summary>
        public const string MASK_STRING = "Sanitized";

        /// <summary>
        /// The pattern to match the subdomain of a URL.
        /// </summary>
        public const string HOST_SUBDOMAIN_PATTERN = @"(?<=.+://)([^\.]+)(?=[\./])";

        private static readonly Regex HOST_SUBDOMAIN_MATCHER = new Regex(HOST_SUBDOMAIN_PATTERN, RegexOptions.Compiled);
        private static readonly IReadOnlyDictionary<string, Func<object, object>> SANITIZERS = new Dictionary<string, Func<object, object>>
        {
            ["subscription_id"] = v => MASK_STRING,
            ["resource_group"] = v => MASK_STRING,
            ["endpoint"] = v => v is not null && (v is string || v is Uri)
                ? MaskUriSubdomain(v.ToString())!
                : MASK_STRING,
            ["key"] = v => MASK_STRING,
            ["api_key"] = v => MASK_STRING,
        };

        private Uri? _endpoint;
        private string? _key;
        private string? _deployment;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public SanitizedJsonConfig()
        {
            ExtensionData = new SortedDictionary<string, JsonElement>();
        }

        /// <summary>
        /// Creates a new instance from another <see cref="JsonConfig" />.
        /// </summary>
        /// <param name="config">The configuration to create from.</param>
        /// <exception cref="ArgumentNullException">If the configuration was null.</exception>
        public SanitizedJsonConfig(JsonConfig config) : this()
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            Endpoint = config.Endpoint;
            Key = config.Key;
            Deployment = config.Deployment;

            if (config?.ExtensionData != null)
            {
                foreach (var kvp in config.ExtensionData)
                {
                    switch (kvp.Value.ValueKind)
                    {
                        case JsonValueKind.Undefined:
                        case JsonValueKind.Null:
                            break;
                        case JsonValueKind.String:
                            SetValue(kvp.Key, kvp.Value.GetString());
                            break;
                        default:
                            ExtensionData[kvp.Key] = kvp.Value.Clone();
                            break;
                    }
                }
            }
        }

        /// <inheritdoc />
        public Uri? Endpoint
        {
            get => _endpoint;
            set => _endpoint = MaskProperty(value);
        }

        /// <inheritdoc />
        public string? Key
        {
            get => _key;
            set => _key = MaskProperty(value);
        }

        /// <inheritdoc />
        public string? Deployment
        {
            get => _deployment;
            set => _deployment = MaskProperty(value);
        }

        /// <summary>
        /// Json values that are not part of the class go here.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JsonElement> ExtensionData { get; }

        /// <inheritdoc />
        public virtual TVal? GetValue<TVal>(string key)
        {
            if (ExtensionData?.TryGetValue(key, out JsonElement value) == true)
            {
                return value.Deserialize<TVal>(JsonConfig.JSON_OPTIONS);
            }

            return default;
        }

        /// <summary>
        /// Sets an additional value in the configuration. If the value is null it will be removed.
        /// </summary>
        /// <typeparam name="TVal">Type of the value to set.</typeparam>
        /// <param name="key">The name of the value (usually snake cased). For example: fine_tuned_model.</param>
        /// <param name="value">The value to set.</param>
        public virtual void SetValue<TVal>(string key, TVal? value)
        {
            if (value == null)
            {
                if (ExtensionData != null)
                {
                    ExtensionData.Remove(key);
                }
            }
            else
            {
                value = MaskData(key, value);
                JsonElement json = JsonSerializer.SerializeToElement(value, JsonConfig.JSON_OPTIONS);
                ExtensionData[key] = json;
            }
        }

        private static TVal? MaskProperty<TVal>(TVal? value, [CallerMemberName] string? key = null)
        {
            string convertedKey = JsonConfig.JSON_OPTIONS.PropertyNamingPolicy?.ConvertName(key ?? string.Empty) ?? string.Empty;
            return MaskData(convertedKey, value);
        }

        private static TVal? MaskData<TVal>(string key, TVal? value)
        {
            if (value == null)
            {
                return default;
            }
            else if (SANITIZERS.TryGetValue(key ?? string.Empty, out var sanitizer))
            {
                return (TVal?)sanitizer(value);
            }

            return value;
        }

        private static Uri? MaskUriSubdomain(string? uri)
        {
            if (uri == null)
            {
                return null;
            }

            string maskedUrl = HOST_SUBDOMAIN_MATCHER.Replace(uri.ToString(), MASK_STRING);
            return new Uri(maskedUrl);
        }
    }
}
