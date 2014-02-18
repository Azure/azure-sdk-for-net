//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//


using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.WindowsAzure.Common.Platform
{
    internal class CloudConfigurationProvider
        : ICloudConfigurationProvider
    {
        private static IEnumerable<Func<string, string>> ConfigurationSources
        {
            get
            {
                yield return GetLocalSetting;
            }
        }

        /// <summary>
        /// Registers cloud configuration providers with the common runtime
        /// that require the .NET framework.
        /// </summary>
        public void RegisterDefaultCloudCredentialsProviders()
        {
            CloudConfiguration.RegisterCloudCredentialsProvider(new TokenCloudCredentialsProvider());
        }

        public string GetSetting(string name)
        {
            return ConfigurationHelper.LookupSetting(ConfigurationSources, name);
        }

        public IDictionary<string, object> GetConnectionInfo(Type type, string name, out string settingsName, out string settingsValue)
        {
            return ConfigurationHelper.LookupConnectionInfo(ConfigurationSources, type, name, out settingsName, out settingsValue);
        }

        private static string GetLocalSetting(string name)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            object setting;
            string settingAsString = null;
            if (localSettings.Values.TryGetValue(name, out setting) && setting != null)
            {
                settingAsString = setting.ToString();
            }
            Tracing.Configuration("AppConfig", name, settingAsString);
            return settingAsString;
        }
    }
}
