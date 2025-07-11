// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Configuration Setting model factory that enables mocking for the AppConfiguration client library.
    /// </summary>
    public static class ConfigurationModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSetting"/> for mocking purposes.
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

        /// <summary>
        /// Creates a <see cref="ConfigurationSnapshot"/> for mocking purposes.
        /// </summary>
        /// <param name="filters">A list of filters used to filter the key-values included in the snapshot.</param>
        /// <param name="name">The name of the snapshot.</param>
        /// <param name="status">The current status of the snapshot.</param>
        /// <param name="snapshotComposition">The composition type describes how the key-values within the snapshot are composed.</param>
        /// <param name="createdOn">The time that the snapshot was created.</param>
        /// <param name="expiresOn">The time that the snapshot will expire.</param>
        /// <param name="retentionPeriod">The amount of time that a snapshot will remain in the archived state before expiring.</param>
        /// <param name="sizeInBytes">The size in bytes of the snapshot.</param>
        /// <param name="itemCount">The amount of key-values in the snapshot.</param>
        /// <param name="tags">The tags of the snapshot.</param>
        /// <param name="eTag">A value representing the current state of the snapshot.</param>
        public static ConfigurationSnapshot ConfigurationSnapshot(
            IEnumerable<ConfigurationSettingsFilter> filters,
            string name = null,
            ConfigurationSnapshotStatus? status = null,
            SnapshotComposition? snapshotComposition = null,
            DateTimeOffset? createdOn = null,
            DateTimeOffset? expiresOn = null,
            TimeSpan? retentionPeriod = null,
            long? sizeInBytes = null,
            long? itemCount = null,
            IDictionary<string, string> tags = null,
            ETag eTag = default)
        {
            // Convert TimeSpan to long for the internal constructor
            long? retentionPeriodSeconds = retentionPeriod?.TotalSeconds is double seconds ? (long)seconds : null;

            return new ConfigurationSnapshot(
                name,
                status,
                filters?.ToList(),
                snapshotComposition,
                createdOn,
                expiresOn,
                retentionPeriodSeconds,
                sizeInBytes,
                itemCount,
                tags,
                eTag);
        }

        /// <summary>
        /// Creates a <see cref="SettingLabel"/> for mocking purposes.
        /// </summary>
        /// <param name="name">The name of the label.</param>
        public static SettingLabel SettingLabel(string name)
        {
            return new SettingLabel(name);
        }
    }
}
