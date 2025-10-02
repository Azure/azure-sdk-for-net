// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Data.AppConfiguration
{
    // CUSTOM:
    // - Renamed.
    // - Suppress ConfigurationSetting in favor of custom method.
    /// <summary>
    /// Configuration Setting model factory that enables mocking for the AppConfiguration client library.
    /// </summary>
    [CodeGenType("AzureDataAppConfigurationModelFactory")]
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

        /// <summary> A feature flag. </summary>
        /// <param name="name"> The name of the feature flag. </param>
        /// <param name="alias"> The alias of the feature flag. </param>
        /// <param name="label"> The label the feature flag belongs to. </param>
        /// <param name="description"> The description of the feature flag. </param>
        /// <param name="enabled"> The enabled state of the feature flag. </param>
        /// <param name="conditions"> The conditions of the feature flag. </param>
        /// <param name="variants"> The variants of the feature flag. </param>
        /// <param name="allocation"> The allocation of the feature flag. </param>
        /// <param name="telemetry"> The telemetry settings of the feature flag. </param>
        /// <param name="tags">
        /// A dictionary of tags used to assign additional properties to a feature flag.
        ///     These can be used to indicate how a feature flag may be applied.
        /// </param>
        /// <param name="isReadOnly">
        /// A value indicating whether the feature flag is read only.
        ///     A read only feature flag may not be modified until it is made writable.
        /// </param>
        /// <param name="lastModified"> The last time a modifying operation was performed on the given feature flag. </param>
        /// <param name="eTag"> An ETag indicating the state of a feature flag within a configuration store. </param>
        /// <returns> A new <see cref="AppConfiguration.FeatureFlag"/> instance for mocking. </returns>
        public static FeatureFlag FeatureFlag(string name = default, bool? enabled = default, string label = default, string description = default, string @alias = default, FeatureFlagConditions conditions = default, IEnumerable<FeatureFlagVariantDefinition> variants = default, FeatureFlagAllocation allocation = default, FeatureFlagTelemetryConfiguration telemetry = default, IDictionary<string, string> tags = default, bool? isReadOnly = default, DateTimeOffset? lastModified = default, ETag eTag = default)
        {
            return new FeatureFlag(
                name,
                enabled,
                label,
                description,
                @alias,
                conditions,
                variants != null ? variants.ToList() : null,
                allocation,
                telemetry,
                tags,
                isReadOnly,
                lastModified,
                eTag,
                additionalBinaryDataProperties: null);
        }
    }
}
