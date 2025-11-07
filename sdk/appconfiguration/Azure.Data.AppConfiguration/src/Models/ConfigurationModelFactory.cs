// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed.
    // - Suppress ConfigurationSetting in favor of custom method.
    /// <summary>
    /// Configuration Setting model factory that enables mocking for the AppConfiguration client library.
    /// </summary>
    [CodeGenType("AppConfigurationModelFactory")]
    [CodeGenSuppress("ConfigurationSetting", typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(IDictionary<string, string>), typeof(bool?), typeof(ETag))]
    public static partial class ConfigurationModelFactory
    {
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
        public static ConfigurationSetting ConfigurationSetting(
            string key,
            string value,
            string label = null,
            string contentType = null,
            ETag eTag = default,
            DateTimeOffset? lastModified = null,
            bool? isReadOnly = null)
        {
            return new ConfigurationSetting(key, value, label)
            {
                ContentType = contentType,
                ETag = eTag,
                LastModified = lastModified,
                IsReadOnly = isReadOnly
            };
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
