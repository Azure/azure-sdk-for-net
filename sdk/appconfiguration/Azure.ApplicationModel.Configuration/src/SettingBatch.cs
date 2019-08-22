// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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
