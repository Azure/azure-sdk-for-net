// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Http;

namespace Azure.ApplicationModel.Configuration
{
    /// <summary>
    /// Configuration Setting model factory that enables mocking for the App Configuration client library
    /// </summary>
    public static class ConfigurationModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSetting"/> for mocking purposes.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="contentType">The content type of the configuration setting's value.</param>
        /// <param name="eTag">An ETag indicating the state of a configuration setting within a configuration store.</param>
        /// <param name="lastModified">The last time a modifying operation was performed on the given configuration setting.</param>
        /// <param name="locked">A value indicating whether the configuration setting is locked.</param>
        public static ConfigurationSetting ConfigurationSetting(
            string key,
            string value,
            string label = null,
            string contentType = null,
            ETag eTag = default,
            DateTimeOffset? lastModified = null,
            bool? locked = null)
        {
            return new ConfigurationSetting(key, value, label)
            {
                ContentType = contentType,
                ETag = eTag,
                LastModified = lastModified,
                Locked = locked
            };
        }
    }
}
