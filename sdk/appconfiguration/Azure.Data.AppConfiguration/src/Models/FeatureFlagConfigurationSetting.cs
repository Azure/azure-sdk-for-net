// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

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
    public class FeatureFlagConfigurationSetting : ConfigurationSetting
    {
        internal const string FeatureFlagContentType = "application/vnd.microsoft.appconfig.ff+json;charset=utf-8";

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
        public FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label = null) : this()
        {
            _isValidValue = true;
            Key = KeyPrefix + featureId;
            Label = label;
            IsEnabled = isEnabled;
            ContentType = FeatureFlagContentType;
            FeatureId = featureId;
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
                CheckValidWrite();
                _featureId = value;
            }
        }

        /// <summary>
        /// Gets or sets a description of the feature.
        /// </summary>
        public string Description
        {
            get
            {
                CheckValid();
                return _description;
            }
            set
            {
                CheckValidWrite();
                _description = value;
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
                CheckValidWrite();
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
                CheckValidWrite();
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

            _isValidValue = TryParseValueWithUnknownProperties();
        }

        internal override string GetValue()
        {
            return _isValidValue ? FormatValue() : _originalValue;
        }

        private string FormatValue()
        {
            using MemoryStream memoryStream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(memoryStream);

            writer.WriteStartObject();
            writer.WriteString("id", _featureId);
            if (_description != null)
            {
                writer.WriteString("description", _description);
            }
            if (_displayName != null)
            {
                writer.WriteString("display_name", _displayName);
            }
            writer.WriteBoolean("enabled", _isEnabled);
            writer.WriteStartObject("conditions");

            if (_clientFilters.Any())
            {
                writer.WriteStartArray("client_filters");
                foreach (FeatureFlagFilter featureFlagFilter in _clientFilters)
                {
                    writer.WriteStartObject();
                    writer.WriteString("name", featureFlagFilter.Name);
                    writer.WritePropertyName("parameters");
                    WriteParameterValue(writer, featureFlagFilter.Parameters);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        private bool TryParseValue()
        {
            try
            {
                using JsonDocument document = JsonDocument.Parse(_originalValue);
                JsonElement root = document.RootElement;

                // "id" - required
                if (!root.TryGetProperty("id", out JsonElement idProperty))
                {
                    return false;
                }
                _featureId = idProperty.GetString();

                // "enabled" - required
                if (!root.TryGetProperty("enabled", out JsonElement enabledProperty))
                {
                    return false;
                }
                _isEnabled = enabledProperty.GetBoolean();

                // "conditions" - required
                if (!root.TryGetProperty("conditions", out JsonElement conditionsProperty))
                {
                    return false;
                }

                // "description" - optional
                if (root.TryGetProperty("description", out JsonElement descriptionProperty))
                {
                    _description = descriptionProperty.GetString();
                }

                // "display_name" - optional
                if (root.TryGetProperty("display_name", out JsonElement displayNameProperty))
                {
                    _displayName = displayNameProperty.GetString();
                }

                // "conditions.client_filters" - optional
                ObservableCollection<FeatureFlagFilter> newFilters = new ObservableCollection<FeatureFlagFilter>();
                if (conditionsProperty.TryGetProperty("client_filters", out JsonElement clientFiltersProperty) &&
                    clientFiltersProperty.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement clientFilter in clientFiltersProperty.EnumerateArray())
                    {
                        if (!clientFilter.TryGetProperty("name", out JsonElement filterNameProperty))
                        {
                            return false;
                        }

                        Dictionary<string, object> value = null;
                        if (clientFilter.TryGetProperty("parameters", out JsonElement parametersProperty))
                        {
                            value = (Dictionary<string, object>)ReadParameterValue(parametersProperty);
                        }

                        newFilters.Add(new FeatureFlagFilter(filterNameProperty.GetString(), value ?? new Dictionary<string, object>()));
                    }
                }

                _clientFilters = newFilters;
            }
            // TODO: we shouldn't catch a top-level exception; this could swallow something important.
            // Should it be JsonException?
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private bool TryParseValueWithUnknownProperties()
        {
            using JsonDocument document = JsonDocument.Parse(_originalValue);
            JsonElement root = document.RootElement;

            // required
            string featureId = default;
            bool? isEnabled = default;
            bool hasConditions = false;

            // optional
            string description = default;
            string displayName = default;

            ObservableCollection<FeatureFlagFilter> newFilters = default;

            // unknowns
            Dictionary<string, JsonElement> unknownRootValues = new();
            Dictionary<string, JsonElement> unknownConditions = new();

            foreach (JsonProperty property in root.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    featureId = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("enabled"u8))
                {
                    isEnabled = property.Value.GetBoolean();
                    continue;
                }

                if (property.NameEquals("conditions"u8))
                {
                    hasConditions = true;

                    foreach (JsonProperty conditionProperty in property.Value.EnumerateObject())
                    {
                        if (conditionProperty.NameEquals("client_filters"u8))
                        {
                            if (conditionProperty.Value.ValueKind != JsonValueKind.Array)
                            {
                                continue;
                            }

                            newFilters = new();

                            foreach (JsonElement clientFilter in conditionProperty.Value.EnumerateArray())
                            {
                                if (!clientFilter.TryGetProperty("name", out JsonElement filterNameProperty))
                                {
                                    return false;
                                }

                                Dictionary<string, object> value = null;
                                if (clientFilter.TryGetProperty("parameters", out JsonElement parametersProperty))
                                {
                                    value = (Dictionary<string, object>)ReadParameterValue(parametersProperty);
                                }

                                newFilters.Add(new FeatureFlagFilter(filterNameProperty.GetString(), value ?? new Dictionary<string, object>()));
                            }

                            continue;
                        }

                        // unknown conditions
                        unknownConditions[conditionProperty.Name] = conditionProperty.Value.Clone();
                    }

                    continue;
                }

                if (property.NameEquals("description"u8))
                {
                    _description = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("display_name"u8))
                {
                    _displayName = property.Value.GetString();
                    continue;
                }

                // Store any unknown properties - use Clone to allow disposing the root document.
                unknownRootValues[property.Name] = property.Value.Clone();
            }

            // Validate
            if (featureId == default ||
                isEnabled == default ||
                !hasConditions)
            {
                return false;
            }

            // required
            _featureId = featureId;
            _isEnabled = isEnabled.Value;

            // optional
            if (description != null)
            {
                _description = description;
            }

            if (displayName != null)
            {
                _displayName = displayName;
            }

            if (newFilters != default)
            {
                _clientFilters = newFilters;
            }

            return true;
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
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    foreach (JsonProperty jsonProperty in element.EnumerateObject())
                    {
                        dictionary.Add(jsonProperty.Name, ReadParameterValue(jsonProperty.Value));
                    }
                    return dictionary;
                case JsonValueKind.Array:
                    List<object> list = new List<object>();
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        list.Add(ReadParameterValue(item));
                    }
                    return list;
                default:
                    throw new NotSupportedException("Not supported value kind " + element.ValueKind);
            }
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

        private void CheckValidWrite()
        {
            CheckValid();
            _originalValue = null;
        }

        private void CheckValid()
        {
            if (!_isValidValue)
            {
                throw new InvalidOperationException($"The content of the {nameof(Value)} property do not represent a valid feature flag object.");
            }
        }

        private void OnFiltersCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            CheckValidWrite();
        }
    }
}
