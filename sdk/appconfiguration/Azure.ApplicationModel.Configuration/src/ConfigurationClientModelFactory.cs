// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ApplicationModel.Configuration
{
    public static class ConfigurationClientModelFactory
    {
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

        public static SettingBatch SettingBatch(ConfigurationSetting[] settings, string link, SettingSelector selector)
        {
            return new SettingBatch(settings, link, selector);
        }
    }
}
