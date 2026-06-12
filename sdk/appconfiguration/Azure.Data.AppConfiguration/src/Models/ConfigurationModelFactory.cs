// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed.
    // - Suppress ConfigurationSetting in favor of custom method.
    /// <summary>
    /// Configuration Setting model factory that enables mocking for the AppConfiguration client library.
    /// </summary>
    [CodeGenType("AppConfigurationModelFactory")]
    [CodeGenSuppress("ConfigurationSetting", typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(IDictionary<string, string>), typeof(string), typeof(bool?), typeof(ETag))]
    public static partial class ConfigurationModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfiguration.ConfigurationSetting"/> for mocking purposes.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The configuration setting's value.</param>
        /// <param name="label">A label used to group configuration settings.</param>
        /// <param name="contentType">The content type of the configuration setting's value.</param>
        /// <param name="tags">A dictionary of tags used to assign additional properties to the configuration setting.</param>
        /// <param name="description">A description of the configuration setting.</param>
        /// <param name="eTag">An ETag indicating the version of a configuration setting within a configuration store.</param>
        /// <param name="lastModified">The last time a modifying operation was performed on the given configuration setting.</param>
        /// <param name="isReadOnly">A value indicating whether the configuration setting is read only.</param>
        public static ConfigurationSetting ConfigurationSetting(
            string key,
            string value,
            string label = null,
            string contentType = null,
            IDictionary<string, string> tags = null,
            string description = null,
            ETag eTag = default,
            DateTimeOffset? lastModified = null,
            bool? isReadOnly = null)
        {
            ConfigurationSetting setting = new ConfigurationSetting(key, value, label)
            {
                ContentType = contentType,
                Description = description,
                ETag = eTag,
                LastModified = lastModified,
                IsReadOnly = isReadOnly,
            };
            if (tags != null)
            {
                setting.Tags = tags;
            }
            return setting;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfiguration.ConfigurationSetting"/> for mocking purposes.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The configuration setting's value.</param>
        /// <param name="label">A label used to group configuration settings.</param>
        /// <param name="contentType">The content type of the configuration setting's value.</param>
        /// <param name="eTag">An ETag indicating the version of a configuration setting within a configuration store.</param>
        /// <param name="lastModified">The last time a modifying operation was performed on the given configuration setting.</param>
        /// <param name="isReadOnly">A value indicating whether the configuration setting is read only.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConfigurationSetting ConfigurationSetting(
            string key,
            string value,
            string label,
            string contentType,
            ETag eTag,
            DateTimeOffset? lastModified,
            bool? isReadOnly)
        {
            return ConfigurationSetting(
                key: key,
                value: value,
                label: label,
                contentType: contentType,
                tags: default,
                description: default,
                eTag: eTag,
                lastModified: lastModified,
                isReadOnly: isReadOnly);
        }

        /// <summary>
        /// Initializes an instance of the <see cref="FeatureFlagConfigurationSetting"/> for mocking purposes.
        /// </summary>
        /// <param name="featureId">The identified of the feature flag.</param>
        /// <param name="isEnabled">The value indicating whether the feature flag is enabled.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="eTag">An ETag indicating the version of a configuration setting within a configuration store.</param>
        /// <param name="lastModified">The last time a modifying operation was performed on the given configuration setting.</param>
        /// <param name="isReadOnly">A value indicating whether the configuration setting is read only.</param>
        public static FeatureFlagConfigurationSetting FeatureFlagConfigurationSetting(
            string featureId,
            bool isEnabled,
            string label = null,
            ETag eTag = default,
            DateTimeOffset? lastModified = null,
            bool? isReadOnly = null)
        {
            return new FeatureFlagConfigurationSetting(featureId, isEnabled, label)
            {
                ETag = eTag,
                LastModified = lastModified,
                IsReadOnly = isReadOnly
            };
        }

        /// <summary>
        /// Creates a <see cref="SecretReferenceConfigurationSetting"/> for mocking purposes.
        /// </summary>
        /// <param name="key">The primary identifier of the configuration setting.</param>
        /// <param name="secretId">The secret identifier to reference.</param>
        /// <param name="label">A label used to group this configuration setting with others.</param>
        /// <param name="eTag">An ETag indicating the version of a configuration setting within a configuration store.</param>
        /// <param name="lastModified">The last time a modifying operation was performed on the given configuration setting.</param>
        /// <param name="isReadOnly">A value indicating whether the configuration setting is read only.</param>
        public static SecretReferenceConfigurationSetting SecretReferenceConfigurationSetting(
            string key,
            Uri secretId,
            string label = null,
            ETag eTag = default,
            DateTimeOffset? lastModified = null,
            bool? isReadOnly = null)
        {
            return new SecretReferenceConfigurationSetting(key, secretId, label)
            {
                ETag = eTag,
                LastModified = lastModified,
                IsReadOnly = isReadOnly
            };
        }
    }
}
