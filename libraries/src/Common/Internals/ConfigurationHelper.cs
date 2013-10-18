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

using Microsoft.WindowsAzure.Common.Platform;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Microsoft.WindowsAzure.Common.Internals
{
    public static class ConfigurationHelper
    {
        public static IEnumerable<ICloudSettingsFormat> CloudSettingsFormats =
            new ICloudSettingsFormat[]
            {
                new ConnectionStringSettingsFormat(),
                new JsonSettingsFormat()
            };

        public static string GetSettingName(Type type, string name = null, string format = null)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            StringBuilder text = new StringBuilder();

            text.Append(type.Namespace);
            text.Append('.');

            // Ignore the generics modifier even though it means the type name
            // might not be completely unique
            int genericIndex = type.Name.IndexOf('`');
            string typeName = genericIndex > 0 ?
                type.Name.Substring(0, genericIndex) :
                type.Name;
            text.Append(typeName);

            if (!string.IsNullOrEmpty(name))
            {
                text.Append('.');
                text.Append(name);
            }

            if (!string.IsNullOrEmpty(format))
            {
                text.Append('.');
                text.Append(format);
            }

            return text.ToString();
        }

        /// <summary>
        /// Creates a new credentials instance of type T using the set of
        /// registered cloud credentials providers and provided settings.
        /// </summary>
        /// <typeparam name="T">The requested minimum type of cloud credentials
        /// for successful credential use.</typeparam>
        /// <param name="settings">Dictionary of configuration settings.</param>
        /// <param name="isRequired">Provides a value indicating whether to
        /// throw if the minimum requested credentials type cannot be found.
        /// Defaults to true.</param>
        /// <returns>Returns a new instance of the first provider that supports
        /// the provided settings.</returns>
        public static T GetCredentials<T>(IDictionary<string, object> settings, bool isRequired = true) 
            where T : CloudCredentials
        {
            T credentials = CloudConfiguration.CreateCloudCredentials<T>(settings);

            if (credentials == null && isRequired)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Properties.Resources.ConfigurationHelper_GetCredentials_NotFound,
                        typeof(T).Name));
            }

            return credentials;
        }

        public static string LookupSetting(IEnumerable<Func<string, string>> configurationSources, string name)
        {
            if (configurationSources == null)
            {
                throw new ArgumentNullException("configurationSources");
            }
            else if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            else if (name.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("name");
            }

            foreach (Func<string, string> getSettingFromSource in configurationSources)
            {
                string setting = getSettingFromSource(name);
                if (setting != null)
                {
                    return setting;
                }
            }

            return null;
        }

        public static IDictionary<string, object> LookupConnectionInfo(
            IEnumerable<Func<string, string>> configurationSources,
            Type type,
            string name,
            out string settingsName,
            out string settingsValue)
        {
            if (configurationSources == null)
            {
                throw new ArgumentNullException("configurationSources");
            }
            else if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            settingsName = null;
            settingsValue = null;

            // The type hierarchy should be walked in the outermost loop (so
            // that any FooClient settings will be found before ServiceClient
            // settings).
            while (type != null)
            {
                // The configuration sources should be walked next so that any
                // setting in environment variables will be found before any
                // setting in web.config.
                foreach (Func<string, string> getSettingFromSource in configurationSources)
                {
                    // Finally walk the formats
                    foreach (ICloudSettingsFormat format in ConfigurationHelper.CloudSettingsFormats)
                    {
                        string probeName = ConfigurationHelper.GetSettingName(type, name, format.Name);
                        string settings = getSettingFromSource(probeName);
                        if (settings != null)
                        {
                            settingsName = probeName;
                            settingsValue = settings;
                            return format.Parse(settings);
                        }
                    }
                }

                type = type.BaseType;
            }

            return null;
        }

        public static T CreateFromSettings<T>(Func<IDictionary<string, object>, T> initializer)
        {
            string settingsName = null;
            string settingsValue = null;
            try
            {
                IDictionary<string, object> settings = 
                    CloudContext.Configuration.ProbeForConnectionInfo(typeof(T), null, out settingsName, out settingsValue);
                if (settings != null)
                {
                    return initializer(settings);
                }
            }
            catch (Exception ex)
            {
                string message =
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Properties.Resources.ConfigurationHelper_CreateFromSettings_CreateSettingsFailedException,
                        typeof(T).FullName,
                        settingsName,
                        settingsValue,
                        ex.Message);
                throw new FormatException(message, ex);
            }

            throw new InvalidOperationException(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Properties.Resources.ConfigurationHelper_CreateFromSettings_NoConnectionSettingsFound,
                    GetSettingName(typeof(T))));
        }

        public static Exception CreateCouldNotConvertException<T>(string name, object value)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            else if (name.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("name");
            }

            string message =
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Failed to convert parameter {0} value '{1}' to type {2}.",
                    name,
                    value == null ? "(null)" : value.ToString(),
                    typeof(T).FullName);
            return new FormatException(message);
        }

        public static object GetParameter(IDictionary<string, object> parameters, string name, bool isRequired = true)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            else if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            else if (name.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("name");
            }

            object value = null;
            if (!parameters.TryGetValue(name, out value) && isRequired)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Properties.Resources.ConfigurationHelper_GetParameter_NotFound,
                        name));
            }
            return value;
        }

        public static string GetString(IDictionary<string, object> parameters, string name, bool isRequired = true)
        {
            object value = GetParameter(parameters, name, isRequired);
            string text = value as string;
            if (text == null && value != null)
            {
                text = value.ToString();
            }
            return text;
        }

        public static Uri GetUri(IDictionary<string, object> parameters, string name, bool isRequired = true)
        {
            object value = GetParameter(parameters, name, isRequired);

            Uri uri = value as Uri;
            if (uri == null)
            {
                string text = value as string;
                if (text != null)
                {
                    Uri.TryCreate(text, UriKind.Absolute, out uri);
                }
            }

            if (isRequired && uri == null)
            {
                throw CreateCouldNotConvertException<Uri>(name, value);
            }

            return uri;
        }
    }
}
