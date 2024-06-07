// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.AI.OpenAI.Tests.Utils;

namespace Azure.AI.OpenAI.Tests;

internal class TestConfig
{
    private const string AOAI_ENV_KEY_SEPARATOR = "_";
    private const string AOAI_ENV_KEY_PREFIX = "AZURE_OPENAI_";
    private const string SUFFIX_AOAI_API_KEY = "API_KEY";
    private const string SUFFIX_AOAI_ENDPOINT = "ENDPOINT";
    private const string SUFFIX_AOAI_DEPLOYMENT = "DEPLOYMENT";

    private readonly Lazy<IReadOnlyDictionary<string, Config>?> _config;

    public TestConfig()
    {
        // To do: reimplement file-based with Azure SDK artifacts
        _config = new Lazy<IReadOnlyDictionary<string, Config>?>(() =>
        {
            return new[]
            {
                AssetsJson,
                Path.Combine(AssetsSubFolder, AssetsJson),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".Azure", AssetsSubFolder, AssetsJson),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".Azure", AssetsSubFolder, AssetsJson),
            }
            .Select(f =>
            {
                try
                {
                    if (File.Exists(f))
                    {
                        string json = File.ReadAllText(f);
                        return JsonSerializer.Deserialize<Dictionary<string, Config>>(json, new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true,
                            PropertyNamingPolicy = JsonHelpers.SnakeCaseLower,
                            DictionaryKeyPolicy = JsonHelpers.SnakeCaseLower,
                            Converters =
                            {
                                new UnSnakeCaseDictKeyConverter()
                            }
                        });
                    }
                }
                catch (Exception)
                {
                }

                return null;
            })
            .FirstOrDefault(c => c != null);
        });
    }

    protected virtual string AssetsSubFolder => "Assets";
    protected virtual string AssetsJson => "test_config.json";

    public virtual Uri GetEndpointFor<TClient>(string? @override = null)
        => GetConfig(@override ?? ToKey<TClient>())?.Endpoint
            ?? throw new KeyNotFoundException($"{typeof(TClient).FullName}: endpoint");

    public virtual ApiKeyCredential GetApiKeyFor<TClient>(string? @override = null)
        => GetConfig(@override ?? ToKey<TClient>())
            ?.Key
            ?? throw new KeyNotFoundException($"{typeof(TClient).FullName}: API key");

    public virtual string GetDeploymentNameFor<TClient>(string? @override = null)
        => GetConfig(@override ?? ToKey<TClient>())
            ?.Deployment
            ?? throw new KeyNotFoundException($"{typeof(TClient).FullName}: deployment");

    public virtual Config? GetConfig<TClient>()
        => GetConfig(ToKey<TClient>(), false);

    public virtual Config? GetConfig(string name, params string[] additionalTypesToAdd)
        => GetConfig(name, false, additionalTypesToAdd);

    public virtual Config GetConfig(string name, bool ignoreDefault, params string[] additionalTypesToAdd)
    {
        // In order to populate each property of the Config object, the search order is as follows:
        // 1. Getting the specific config for the name in the JSON config file
        // 2. Getting the value from the default config
        // 3. Getting the value from the AZURE_OPENAI_<NAME>_<PROEPRTYNAME> environment variable
        // 4. Getting the value from the AZURE_OPENAI_<PROEPRTYNAME> environment variable
        // It will fall through each one if the value is null

        Config? specificConfig = _config.Value?.GetValueOrDefault(name);
        Config? defaultConfig = ignoreDefault
            ? null
            : _config.Value?.GetValueOrDefault("default");

        Config flattenedConfig = new Config()
        {
            Deployment = specificConfig?.Deployment
                ?? defaultConfig?.Deployment
                ?? GetValueFromEnv<string>(name, SUFFIX_AOAI_DEPLOYMENT, ignoreDefault),
            Endpoint = specificConfig?.Endpoint
                ?? defaultConfig?.Endpoint
                ?? GetValueFromEnv<Uri>(name, SUFFIX_AOAI_ENDPOINT, ignoreDefault),
            Key = specificConfig?.Key
                ?? defaultConfig?.Key
                ?? GetValueFromEnv<string>(name, SUFFIX_AOAI_API_KEY, ignoreDefault),
            ExtensionData = specificConfig?.ExtensionData
        };

        if (additionalTypesToAdd?.Length > 0)
        {
            if (flattenedConfig.ExtensionData == null)
                flattenedConfig.ExtensionData = new Dictionary<string, JsonElement>();

            foreach (var additionalType in additionalTypesToAdd)
            {
                if (flattenedConfig.ExtensionData.ContainsKey(additionalType))
                {
                    continue;
                }

                if (defaultConfig?.ExtensionData?.TryGetValue(additionalType, out var defaultMatch) == true)
                {
                    flattenedConfig.ExtensionData[additionalType] = defaultMatch.Clone();
                    continue;
                }

                string? value = GetValueFromEnv<string>(name, additionalType, true);
                if (value != null)
                {
                    using var json = JsonDocument.Parse($@"""{value}""");
                    flattenedConfig.ExtensionData[additionalType] = json.RootElement.Clone();
                }
            }
        }

        return flattenedConfig;
    }

    protected static string ToKey<TClient>()
        => typeof(TClient).Name.Replace("Client", string.Empty);

    private static TVal? GetValueFromEnv<TVal>(string name, Func<string, TVal?>? converter)
    {
        string? value = Environment.GetEnvironmentVariable(name ?? string.Empty);
        if (value == null)
        {
            return default;
        }
        else if (value is TVal val)
        {
            return val;
        }
        else if (converter is not null)
        {
            return converter(value);
        }
        else
        {
            var defaultConverter = TypeDescriptor.GetConverter(typeof(TVal));
            return (TVal?)defaultConverter.ConvertFromInvariantString(value);
        }
    }

    protected virtual TVal? GetValueFromEnv<TVal>(string name, string type, bool ignoreDefault, Func<string, TVal?>? converter = null)
    {
        string upperType = type.ToUpperInvariant();
        string specificName = AOAI_ENV_KEY_PREFIX + name?.ToUpperInvariant() + AOAI_ENV_KEY_SEPARATOR + upperType;
        string generalName = AOAI_ENV_KEY_PREFIX + upperType;

        TVal? value = GetValueFromEnv(specificName, converter);
        if (value == null && !ignoreDefault)
        {
            value = GetValueFromEnv(generalName, converter);
        }

        return value;
    }

    public class Config
    {
        public string? Key { get; init; }
        public string? Deployment { get; init; }
        public Uri? Endpoint { get; init; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; set; }

        public T GetValueOrDefault<T>(string name)
        {
            T val = default!;

            if (ExtensionData?.TryGetValue(name, out JsonElement element) == true)
            {
                val = element.Deserialize<T>()!;
            }

            return val ?? default(T)!;
        }
    }

    private class UnSnakeCaseDictKeyConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsConstructedGenericType
                && typeToConvert.GetGenericTypeDefinition() == typeof(Dictionary<,>)
                && typeToConvert.GetGenericArguments()[0] == typeof(string);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type closedType = typeof(InnerConverter<>).MakeGenericType([typeToConvert.GetGenericArguments()[1]]);
            return (JsonConverter?)Activator.CreateInstance(
                closedType,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                [options],
                null);
        }

        private class InnerConverter<TValue> : JsonConverter<Dictionary<string, TValue>>
        {
            private JsonSerializerOptions _options;

            public InnerConverter(JsonSerializerOptions options)
            {
#if NETFRAMEWORK
                _options = new()
                {
                    AllowTrailingCommas = options.AllowTrailingCommas,
                    DefaultBufferSize = options.DefaultBufferSize,
                    DictionaryKeyPolicy = options.DictionaryKeyPolicy,
                    Encoder = options.Encoder,
                    IgnoreReadOnlyProperties = options.IgnoreReadOnlyProperties,
                    MaxDepth = options.MaxDepth,
                    PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive,
                    PropertyNamingPolicy = options.PropertyNamingPolicy,
                    ReadCommentHandling = options.ReadCommentHandling,
                    WriteIndented = options.WriteIndented,
                    IgnoreNullValues = options.IgnoreNullValues,
                };
#else
                _options = new(options);
                _options.Converters.Clear();
#endif

                if (options.Converters?.Count > 0)
                {
                    var thisType = GetType();

                    foreach (var conv in options.Converters)
                    {
                        if (conv is not UnSnakeCaseDictKeyConverter
                            && !thisType.IsAssignableFrom(conv.GetType()))
                        {
                            _options.Converters.Add(conv);
                        }
                    }
                }
            }

            public override Dictionary<string, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                StringBuilder builder = new();
                Dictionary<string, TValue> dict = new(StringComparer.OrdinalIgnoreCase);

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        return dict;
                    }

                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        throw new JsonException();
                    }

                    string? propertyName = reader.GetString();
                    bool prevWasSeparator = true;
                    for (int i = 0; i < propertyName?.Length; i++)
                    {
                        if (propertyName[i] == '_' || propertyName[i] == '-')
                        {
                            prevWasSeparator = true;
                        }
                        else if (prevWasSeparator)
                        {
                            prevWasSeparator = false;
                            builder.Append(char.ToUpperInvariant(propertyName[i]));
                        }
                        else
                        {
                            builder.Append(propertyName[i]);
                        }
                    }

                    propertyName = builder.ToString();
                    builder.Clear();

                    reader.Read();
                    TValue? val = JsonSerializer.Deserialize<TValue>(ref reader, _options);

                    dict[propertyName] = val!;
                }

                throw new JsonException();
            }

            public override void Write(Utf8JsonWriter writer, Dictionary<string, TValue> value, JsonSerializerOptions options)
            {
                throw new NotSupportedException("Please use the DictionaryKeyNaming policy option instead");
            }
        }
    }
}
