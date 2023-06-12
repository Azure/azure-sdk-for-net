// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.AppConfiguration
{
    internal class SettingBatch
    {
        internal SettingBatch(ConfigurationSetting[] settings, string link)
        {
            Settings = settings;
            NextBatchLink = link;
        }

        public string NextBatchLink { get; }

        public ConfigurationSetting[] Settings { get; }
    }
}
