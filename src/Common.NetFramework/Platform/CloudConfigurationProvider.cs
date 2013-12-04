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
using System.Configuration;
using System.Web.Configuration;
using Microsoft.WindowsAzure.Common.Internals;
using System.Globalization;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Common.Platform
{
    internal class CloudConfigurationProvider
        : ICloudConfigurationProvider
    {
        private static ServiceRuntimeReference _serviceRuntime = null;

        private static IEnumerable<Func<string, string>> ConfigurationSources
        {
            get
            {
                yield return GetEnvironmentSetting;
                yield return GetCloudConfigSetting;
                yield return GetWebConfigSetting;
                yield return GetAppConfigSetting;
                yield return GetMachineConfigSetting;
            }
        }

        /// <summary>
        /// Registers cloud configuration providers with the common runtime
        /// that require the .NET framework.
        /// </summary>
        public void RegisterDefaultCloudCredentialsProviders()
        {
            CloudConfiguration.RegisterCloudCredentialsProvider(new CertificateCloudCredentialsProvider());
        }

        public string GetSetting(string name)
        {
            return ConfigurationHelper.LookupSetting(ConfigurationSources, name);
        }

        public IDictionary<string, object> GetConnectionInfo(Type type, string name, out string settingsName, out string settingsValue)
        {
            return ConfigurationHelper.LookupConnectionInfo(ConfigurationSources, type, name, out settingsName, out settingsValue);
        }

        private static bool IsConnectionStringSetting(string name)
        {
            return name.EndsWith(".connection", StringComparison.Ordinal);
        }

        private static void Trace(string source, string name, string value)
        {
            if (value == null)
            {
                Tracing.Information(
                    "Did not find configuration setting {0} in {1}.",
                    name,
                    source);
            }
            else
            {
                Tracing.Information(
                    "Found configuration setting {0} in {1} with value '{2}'.",
                    name,
                    source,
                    value);
            }
        }

        private static string GetEnvironmentSetting(string name)
        {
            string setting = Environment.GetEnvironmentVariable(name);
            Tracing.Configuration("EnvironmentVariables", name, setting);

            if (setting == null)
            {
                name = name.Replace('.', '_');
                setting = Environment.GetEnvironmentVariable(name);
                Tracing.Configuration("EnvironmentVariables", name, setting);
            }

            return setting;
        }

        private static string GetAppConfigSetting(string name)
        {
            string setting = ConfigurationManager.AppSettings[name];
            if (string.IsNullOrEmpty(setting) && IsConnectionStringSetting(name))
            {
                ConnectionStringSettings connectionSettings = ConfigurationManager.ConnectionStrings[name];
                if (connectionSettings != null)
                {
                    setting = connectionSettings.ConnectionString;
                }
            }
            Tracing.Configuration("AppConfig", name, setting);
            return setting;
        }

        private static string GetWebConfigSetting(string name)
        {
            string setting = WebConfigurationManager.AppSettings[name];
            if (string.IsNullOrEmpty(setting) && IsConnectionStringSetting(name))
            {
                ConnectionStringSettings connectionSettings = WebConfigurationManager.ConnectionStrings[name];
                if (connectionSettings != null)
                {
                    setting = connectionSettings.ConnectionString;
                }
            }
            Tracing.Configuration("WebConfig", name, setting);
            return setting;
        }

        private static string GetMachineConfigSetting(string name)
        {
            string setting = null;
            Configuration machine = ConfigurationManager.OpenMachineConfiguration();
            if (machine != null)
            {
                KeyValueConfigurationElement appSetting = machine.AppSettings.Settings[name];
                if (appSetting != null)
                {
                    setting = appSetting.Value;
                    if (string.IsNullOrEmpty(setting) && IsConnectionStringSetting(name))
                    {
                        ConnectionStringSettings connectionSettings = machine.ConnectionStrings.ConnectionStrings[name];
                        if (connectionSettings != null)
                        {
                            setting = connectionSettings.ConnectionString;
                        }
                    }
                }
            }
            Tracing.Configuration("MachineConfig", name, setting);
            return setting;
        }

        public static string GetCloudConfigSetting(string name)
        {
            if (_serviceRuntime == null)
            {
                _serviceRuntime = new ServiceRuntimeReference();
            }

            string setting = null;
            if (_serviceRuntime != null)
            {
                setting = _serviceRuntime.GetSetting(name);
            }

            Tracing.Configuration("CloudConfig", name, setting);
            return setting;
        }
    }
}
