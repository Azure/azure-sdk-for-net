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
using Microsoft.WindowsAzure.Common.Platform;

namespace Microsoft.WindowsAzure.Common
{
    /// <summary>
    /// Utilities for easily retrieving configuration settings across a variety
    /// of platform appropriate sources.
    /// </summary>
    public sealed class CloudConfiguration
    {
        /// <summary>
        /// Initializes platform-specific cloud configuration and credentials
        /// providers.
        /// </summary>
        static CloudConfiguration()
        {
            _cloudCredentialsProviders = new List<ICloudCredentialsProvider>();

            PortablePlatformAbstraction.Get<ICloudConfigurationProvider>().RegisterDefaultCloudCredentialsProviders();
        }

        private static List<ICloudCredentialsProvider> _cloudCredentialsProviders;

        /// <summary>
        /// Registers a cloud credentials provider with the configuration
        /// runtime.
        /// </summary>
        /// <param name="provider">Instance of a cloud credentials provider.</param>
        public static void RegisterCloudCredentialsProvider(ICloudCredentialsProvider provider)
        {
            _cloudCredentialsProviders.Add(provider);
        }

        /// <summary>
        /// Creates a new credentials instance of type T using the set of
        /// registered cloud credentials providers.
        /// </summary>
        /// <typeparam name="T">The requested minimum type of cloud credentials
        /// for successful credential use.</typeparam>
        /// <param name="settings">Dictionary of configuration settings.</param>
        /// <returns>Returns a new instance of the first provider that supports
        /// the provided settings.</returns>
        internal static T CreateCloudCredentials<T>(IDictionary<string, object> settings) 
            where T : CloudCredentials
        {
            T credentials;
            foreach (ICloudCredentialsProvider provider in _cloudCredentialsProviders)
            {
                credentials = provider.CreateCredentials(settings) as T;
                if (credentials != null)
                {
                    return credentials;
                }
            }

            return null;
        }

        /// <summary>
        /// A platform specific configuration provider.  There is no standard
        /// configuration support in the Portable Class Libraries BCL.
        /// </summary>
        private static ICloudConfigurationProvider _configurationProvider;

        /// <summary>
        /// Gets a platform specific configuration provider.  There is no
        /// standard configuration support in the Portable Class Libraries BCL.
        /// </summary>
        public static ICloudConfigurationProvider ConfigurationProvider
        {
            get
            {
                // Obtain the configuration provider on its first use
                if (_configurationProvider == null)
                {
                    _configurationProvider = PortablePlatformAbstraction.Get<ICloudConfigurationProvider>();
                }
                return _configurationProvider;
            }
        }

        /// <summary>
        /// Gets the tracing utilities used to provide insight into all aspects
        /// of client operations.
        /// </summary>
        public CloudTracing Tracing { get; private set; }        

        /// <summary>
        /// Initializes a new instance of the CloudConfiguration class.
        /// </summary>
        internal CloudConfiguration()
        {
            Tracing = new CloudTracing();
        }

        /// <summary>
        /// Get the value of a configuration setting from a platform specific
        /// configuration source.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <returns>The value of the setting, or null if not found.</returns>
        public string GetSetting(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            else if (name.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("name");
            }

            return ConfigurationProvider.GetSetting(name);
        }

        /// <summary>
        /// Get connection info that can be used to instantiate type T by
        /// searching for configuration settings of the form
        /// Namespace.Type.format.  If no connection info is found for the
        /// type, we will search for connection info for all of its base types.
        /// </summary>
        /// <typeparam name="T">
        /// The type to obtain connection info for.
        /// </typeparam>
        /// <returns>
        /// Connection info used to instantiate the given type or null if no
        /// connection info is found.
        /// </returns>
        /// <remarks>
        /// You can get insight into the connection info search by checking
        /// the tracing output.
        /// </remarks>
        public IDictionary<string, object> GetConnectionInfo<T>()
        {
            return GetConnectionInfo(typeof(T));
        }

        /// <summary>
        /// Get named connection info that can be used to instantiate a type by
        /// searching for configuration settings of the format
        /// Namespace.Type.Name.format.  If no connection info is found for the
        /// type, we will search for connection info for all of its base types.
        /// </summary>
        /// <typeparam name="T">
        /// The type to obtain connection info for.
        /// </typeparam>
        /// <param name="name">The name of the connection info.</param>
        /// <returns>
        /// Connection info used to instantiate the given type or null if no
        /// connection info is found.
        /// </returns>
        /// <remarks>
        /// You can get insight into the connection info search by checking
        /// the tracing output.
        /// </remarks>
        public IDictionary<string, object> GetConnectionInfo<T>(string name)
        {
            return GetConnectionInfo(typeof(T), name);
        }

        /// <summary>
        /// Get connection info that can be used to instantiate a type by
        /// searching for configuration settings of the form
        /// Namespace.Type.format.  If no connection info is found for the
        /// type, we will search for connection info for all of its base types.
        /// </summary>
        /// <param name="type">
        /// The type to obtain connection info for.
        /// </param>
        /// <returns>
        /// Connection info used to instantiate the given type or null if no
        /// connection info is found.
        /// </returns>
        /// <remarks>
        /// You can get insight into the connection info search by checking
        /// the tracing output.
        /// </remarks>
        public IDictionary<string, object> GetConnectionInfo(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            string key = null;
            string value = null;
            return ProbeForConnectionInfo(type, null, out key, out value);
        }

        /// <summary>
        /// Get named connection info that can be used to instantiate a type by
        /// searching for configuration settings of the format
        /// Namespace.Type.Name.format.  If no connection info is found for
        /// the type, we will search for connection info for all of its base
        /// types.
        /// </summary>
        /// <param name="type">
        /// The type to obtain connection info for.
        /// </param>
        /// <param name="name">The name of the connection info.</param>
        /// <returns>
        /// Connection info used to instantiate the given type or null if
        /// no connection string is found.
        /// </returns>
        /// <remarks>
        /// You can get insight into the connection info search by checking
        /// the tracing output.
        /// </remarks>
        public IDictionary<string, object> GetConnectionInfo(Type type, string name)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            else if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            else if (name.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("name");
            }

            string key = null;
            string value = null;
            return ProbeForConnectionInfo(type, name, out key, out value);
        }

        /// <summary>
        /// Get connection info that can be used to instantiate a type by
        /// searching for configuration settings of the format
        /// Namespace.Type[.Name].format  If no settings are found for the
        /// type, we will search for connection info for all of its base types.
        /// </summary>
        /// <param name="type">
        /// The type to obtain connection info for.
        /// </param>
        /// <param name="name">Optional value for named settings.</param>
        /// <param name="settingsName">
        /// Name of the config setting item where the setting was found.
        /// </param>
        /// <param name="settingsValue">
        /// Value of the config setting item where the setting was found.
        /// </param>
        /// <returns>
        /// Connection info used to instantiate the given type or null if
        /// no connection info is found.
        /// </returns>
        /// <remarks>
        /// You can get insight into the connection info search by checking
        /// the tracing output.
        /// </remarks>
        internal IDictionary<string, object> ProbeForConnectionInfo(Type type, string name, out string settingsName, out string settingsValue)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            return ConfigurationProvider.GetConnectionInfo(type, name, out settingsName, out settingsValue);
        }

        /// <summary>
        /// Parse a connection string.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>
        /// A dictionary of the setting names and values from the connection
        /// string.
        /// </returns>
        public IDictionary<string, object> ParseConnectionStringSettings(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("connectionString");
            }
            else if (connectionString.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("connectionString");
            }

            return new ConnectionStringSettingsFormat().Parse(connectionString);
        }

        /// <summary>
        /// Parse a JSON settings file.
        /// </summary>
        /// <param name="settings">The JSON settings.</param>
        /// <returns>
        /// A dictionary of the setting names and values from the JSON
        /// settings.
        /// </returns>
        public IDictionary<string, object> ParseJsonSettings(string settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            else if (settings.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("settings");
            }

            return new JsonSettingsFormat().Parse(settings);
        }
    }
}
