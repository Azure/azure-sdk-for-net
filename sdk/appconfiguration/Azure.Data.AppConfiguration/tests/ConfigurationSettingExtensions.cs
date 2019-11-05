// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Data.AppConfiguration.Tests
{
    public static class ConfigurationSettingExtensions
    {
        public static ConfigurationSetting Clone(this ConfigurationSetting setting)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            foreach (string key in setting.Tags.Keys)
            {
                tags.Add(key, setting.Tags[key]);
            }

            return new ConfigurationSetting(setting.Key, setting.Value)
            {
                Label = setting.Label,
                ContentType = setting.ContentType,
                Tags = tags
            };
        }
    }
}
