//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Configuration;

namespace KeyVault.Tests
{
    class TestConfigurationManager
    {
        public static string GetEnvironmentOrAppSetting(string settingName)
        {
            var value = TryGetEnvironmentOrAppSetting(settingName, null);

            if (value == null)
                throw new ConfigurationErrorsException(string.Format("Missing configuration setting for {0}", settingName));

            return value;
        }

        public static string TryGetEnvironmentOrAppSetting(string settingName, string defaultValue = null)
        {
            var value = Environment.GetEnvironmentVariable(settingName);

            // We don't use IsNullOrEmpty because an empty setting overrides what's on AppSettings.
            if (value == null)
                value = ConfigurationManager.AppSettings[settingName];

            return value ?? defaultValue;
        }

        public static string GetEnvironmentSetting(string settingName)
        {
            var result = TryGetEnvironmentSetting(settingName, null);

            if (string.IsNullOrEmpty(result))
                throw new ConfigurationErrorsException(string.Format("Missing environment variable for {0}", settingName));

            return result;
        }

        public static string TryGetEnvironmentSetting(string settingName, string defaultValue = null)
        {
            var result = Environment.GetEnvironmentVariable(settingName);

            if (string.IsNullOrWhiteSpace(result))
                result = defaultValue;

            return result;
        }
    }
}
