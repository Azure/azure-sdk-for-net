// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Represents a configuration setting that stores a feature flag value.
    /// Feature flags allow you to activate or deactivate functionality in your application.
    /// A simple feature flag is either on or off.
    /// The application always behaves the same way.
    /// For example, you could roll out a new feature behind a feature flag.
    /// When the feature flag is enabled, all users see the new feature. Disabling the feature flag hides the new feature.
    ///
    /// In contrast, a conditional feature flag allows the feature flag to be enabled or disabled dynamically.
    /// The application may behave differently, depending on the feature flag criteria.
    /// Suppose you want to show your new feature to a small subset of users at first.
    /// A conditional feature flag allows you to enable the feature flag for some users while disabling it for others.
    /// Feature filters determine the state of the feature flag each time it's evaluated.
    ///
    /// NOTE: The Azure.Data.AppConfiguration doesn't evaluate feature flags on retrieval.
    /// It's the responsibility of the library consumer to interpret feature flags and determine whether a feature is enabled.
    /// </summary>
    /// <seealso href="https://github.com/Azure/AppConfiguration/blob/main/docs/FeatureManagement/FeatureFlag.v1.1.0.schema.json">Feature Flag schema</seealso>
    public class FeatureFlagConfigurationSetting : ConfigurationSetting
    {
        internal const string FeatureFlagContentType = "application/vnd.microsoft.appconfig.ff+json;charset=utf-8";

        private static readonly string[] s_jsonPropertyNames =
        {
            "id",
            "description",
            "display_name",
            "enabled",
            "conditions"
        };

        private static readonly string[] s_requiredJsonPropertyNames =
        {
            "id",
            "enabled",
            "conditions"
        };

        /// <summary>
        /// The prefix used for <see cref="FeatureFlagConfigurationSetting"/> setting keys.
        /// </summary>
        public static string KeyPrefix { get; } = ".appconfig.featureflag/";

        private string _originalValue;
        private bool _isValidValue;
        private string _featureId;
        private string _description;
        private string _displayName;
        private bool _isEnabled;
        private IList<FeatureFlagFilter> _clientFilters;
        private List<(string Name, JsonElement Json)> _parsedProperties = new(s_jsonPropertyNames.Length);

        internal FeatureFlagConfigurationSetting()
        {
            _clientFilters = new List<FeatureFlagFilter>();
        }

        /// <summary>
        /// Initializes an instance of the <see cref="FeatureFlagConfigurationSetting"/> using a provided feature id and
        /// the enabled value.
        /// </summary>
        /// <param name="featureId">The identified of the feature flag.</param>
        /// <param name="isEnabled">The value indicating whether the feature flag is enabled.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        public FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label = null): this(featureId, isEnabled, label, default)
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="FeatureFlagConfigurationSetting"/> using a provided feature id and
        /// the enabled value.
        /// </summary>
        /// <param name="featureId">The identified of the feature flag.</param>
        /// <param name="isEnabled">The value indicating whether the feature flag is enabled.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="etag">The ETag value for the configuration setting.</param>
        public FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label, ETag etag) : this()
        {
            _isValidValue = true;

            Key = KeyPrefix + featureId;
            Label = label;
            IsEnabled = isEnabled;
            ContentType = FeatureFlagContentType;
            FeatureId = featureId;
            ETag = etag;
        }

        /// <summary>
        /// Gets or sets an ID used to uniquely identify and reference the feature
        /// </summary>
        public string FeatureId
        {
            get
            {
                CheckValid();
                return _featureId;
            }
            set
            {
                CheckValid();
                _featureId = value;
            }
        }

        /// <summary>
        /// Gets or sets a display name for the feature to use for display rather than the ID.
        /// </summary>
        public string DisplayName
        {
            get
            {
                CheckValid();
                return _displayName;
            }
            set
            {
                CheckValid();
                _displayName = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the features is enabled.
        /// A feature is OFF if enabled is false. If enabled is true, then the feature is ON if there are no conditions or if all conditions are satisfied.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                CheckValid();
                return _isEnabled;
            }
            set
            {
                CheckValid();
                _isEnabled = value;
            }
        }

        /// <summary>
        /// Filters that must run on the client and be evaluated as true for the feature to be considered enabled.
        /// </summary>
        public IList<FeatureFlagFilter> ClientFilters
        {
            get
            {
                CheckValid();
                return _clientFilters;
            }
        }

        internal override void SetValue(string value)
        {
            _originalValue = value;
            _isValidValue = TryParseValue();
        }

        internal override string GetValue()
        {
            // If the value wasn't valid, return it verbatim.
            if (!_isValidValue)
            {
                return _originalValue;
            }

            var knownProperties = new HashSet<string>(s_jsonPropertyNames);

            using var memoryStream = new MemoryStream();
            using var writer = new Utf8JsonWriter(memoryStream);

            writer.WriteStartObject();

            for (var index = 0; index < _parsedProperties.Count; ++index)
            {
                var (name, jsonValue) = _parsedProperties[index];

                if (TryWriteKnownProperty(name, writer, jsonValue, includeOptionalWhenNull: true))
                {
                    knownProperties.Remove(name);
                }
                else
                {
                    writer.WritePropertyName(name);
                    jsonValue.WriteTo(writer);
                }
            }

            foreach (var name in knownProperties)
            {
                TryWriteKnownProperty(name, writer, default);
            }

            writer.WriteEndObject();
            writer.Flush();

            _originalValue = Encoding.UTF8.GetString(memoryStream.ToArray());
            return _originalValue;
        }

        private bool TryParseValue()
        {
            _parsedProperties.Clear();

            try
            {
                var requiredProperties = new HashSet<string>(s_requiredJsonPropertyNames);
                using var doc = JsonDocument.Parse(_originalValue);

                foreach (var item in doc.RootElement.EnumerateObject())
                {
                    switch (item.Name)
                    {
                        case "id":
                            _featureId = item.Value.GetString();
                            _parsedProperties.Add((item.Name, default));
                            requiredProperties.Remove(item.Name);
                            break;

                        case "description":
                            _description = item.Value.GetString();
                            _parsedProperties.Add((item.Name, default));
                            requiredProperties.Remove(item.Name);
                            break;

                        case "display_name":
                            _displayName = item.Value.GetString();
                            _parsedProperties.Add((item.Name, default));
                            requiredProperties.Remove(item.Name);
                            break;

                        case "enabled":
                            _isEnabled = item.Value.GetBoolean();
                            _parsedProperties.Add((item.Name, default));
                            requiredProperties.Remove(item.Name);
                            break;

                        case "conditions":
                            _parsedProperties.Add((item.Name, item.Value.Clone()));

                            if (item.Value.TryGetProperty("client_filters", out var clientFiltersProperty)
                                && clientFiltersProperty.ValueKind == JsonValueKind.Array)
                            {
                                _clientFilters = ParseFilters(clientFiltersProperty);
                            }

                            if (item.Value.ValueKind == JsonValueKind.Object)
                            {
                                requiredProperties.Remove(item.Name);
                            }
                            break;

                        default:
                            _parsedProperties.Add((item.Name, item.Value.Clone()));
                            break;
                    }
                }

                return requiredProperties.Count == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool TryWriteKnownProperty(string propertyName, Utf8JsonWriter writer, JsonElement sourceElement, bool includeOptionalWhenNull = false)
        {
            switch (propertyName)
            {
                case "description" when includeOptionalWhenNull || _description != null:
                    writer.WriteString(propertyName, _description);
                    break;

                case "display_name" when includeOptionalWhenNull || _displayName != null:
                    writer.WriteString(propertyName, _displayName);
                    break;

                case "id":
                    writer.WriteString(propertyName, _featureId);
                    break;

                case "enabled":
                    writer.WriteBoolean(propertyName, _isEnabled);
                    break;

                case "conditions":
                    writer.WriteStartObject(propertyName);

                    if (_clientFilters.Count > 0)
                    {
                        writer.WriteStartArray("client_filters");
                        foreach (var featureFlagFilter in _clientFilters)
                        {
                            writer.WriteStartObject();
                            writer.WriteString("name", featureFlagFilter.Name);
                            writer.WritePropertyName("parameters");
                            WriteParameterValue(writer, featureFlagFilter.Parameters);
                            writer.WriteEndObject();
                        }
                        writer.WriteEndArray();
                    }

                    if (sourceElement.ValueKind != JsonValueKind.Undefined)
                    {
                        foreach (var item in sourceElement.EnumerateObject())
                        {
                            if (item.Name != "client_filters")
                            {
                                item.WriteTo(writer);
                            }
                        }
                    }

                    writer.WriteEndObject();
                    break;

                default:
                    return false;
            }

            return true;
        }

        private static void WriteParameterValue(Utf8JsonWriter writer, object value)
        {
            switch (value)
            {
                case null:
                    writer.WriteNullValue();
                    break;
                case int i:
                    writer.WriteNumberValue(i);
                    break;
                case double d:
                    writer.WriteNumberValue(d);
                    break;
                case float f:
                    writer.WriteNumberValue(f);
                    break;
                case long l:
                    writer.WriteNumberValue(l);
                    break;
                case string s:
                    writer.WriteStringValue(s);
                    break;
                case bool b:
                    writer.WriteBooleanValue(b);
                    break;
                case IEnumerable<KeyValuePair<string, object>> enumerable:
                    writer.WriteStartObject();
                    foreach (KeyValuePair<string, object> pair in enumerable)
                    {
                        writer.WritePropertyName(pair.Key);
                        WriteParameterValue(writer, pair.Value);
                    }
                    writer.WriteEndObject();
                    break;
                case IEnumerable<object> objectEnumerable:
                    writer.WriteStartArray();
                    foreach (object item in objectEnumerable)
                    {
                        WriteParameterValue(writer, item);
                    }
                    writer.WriteEndArray();
                    break;

                default:
                    throw new NotSupportedException("Not supported type " + value.GetType());
            }
        }

        private static IList<FeatureFlagFilter> ParseFilters(JsonElement filters)
        {
            var newFilters = new ObservableCollection<FeatureFlagFilter>();
            if (filters.ValueKind == JsonValueKind.Array)
            {
                foreach (var clientFilter in filters.EnumerateArray())
                {
                    if (!clientFilter.TryGetProperty("name", out var filterNameProperty))
                    {
                        newFilters.Clear();
                        return newFilters;
                    }

                    Dictionary<string, object> value = null;
                    if (clientFilter.TryGetProperty("parameters", out var parametersProperty))
                    {
                        value = (Dictionary<string, object>)ReadParameterValue(parametersProperty);
                    }

                    newFilters.Add(new FeatureFlagFilter(filterNameProperty.GetString(), value ?? new Dictionary<string, object>()));
                }
            }

            return newFilters;
        }

        private static object ReadParameterValue(in JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out int intValue))
                    {
                        return intValue;
                    }
                    if (element.TryGetInt64(out long longValue))
                    {
                        return longValue;
                    }
                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, ReadParameterValue(jsonProperty.Value));
                    }
                    return dictionary;
                case JsonValueKind.Array:
                    var list = new List<object>();
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        list.Add(ReadParameterValue(item));
                    }
                    return list;
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
        }

        private void CheckValid()
        {
            if (!_isValidValue)
            {
                throw new InvalidOperationException($"The content of the {nameof(Value)} property do not represent a valid feature flag object.");
            }
        }
    }
}
