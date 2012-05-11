//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Web.Configuration;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// Windows Azure settings.
    /// </summary>
    internal class AzureApplicationSettings
    {
        private const string RoleEnvironmentTypeName = "Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment";
        private const string RoleEnvironmentExceptionTypeName = "Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironmentException";
        private const string IsAvailablePropertyName = "IsAvailable";
        private const string GetSettingValueMethodName = "GetConfigurationSettingValue";
        private readonly string[] knownAssemblyNames = new string[]
        {
            "Microsoft.WindowsAzure.ServiceRuntime, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, ProcessorArchitecture=MSIL",
            "Microsoft.WindowsAzure.ServiceRuntime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, ProcessorArchitecture=MSIL",
        };

        private Type _roleEnvironmentExceptionType;         // Exception thrown for missing settings.
        private MethodInfo _getServiceSettingMethod;        // Method for getting values from the service configuration.

        /// <summary>
        /// Initializes the settings.
        /// </summary>
        internal AzureApplicationSettings()
        {
            // Find out if the code is running in the cloud service context.
            Assembly assembly = GetServiceRuntimeAssembly();
            if (assembly != null)
            {
                Type roleEnvironmentType = assembly.GetType(RoleEnvironmentTypeName, false);
                _roleEnvironmentExceptionType = assembly.GetType(RoleEnvironmentExceptionTypeName, false);
                if (roleEnvironmentType != null)
                {
                    PropertyInfo isAvailableProperty = roleEnvironmentType.GetProperty(IsAvailablePropertyName);
                    bool isAvailable;

                    try
                    {
                        isAvailable = isAvailableProperty != null && (bool)isAvailableProperty.GetValue(null, new object[] { });
                    }
                    catch (TargetInvocationException e)
                    {
                        // Running service runtime code from an application targeting .Net 4.0 results
                        // in a type initialization exception unless application's configuration file
                        // explicitly enables v2 runtime activation policy. In this case we should fall
                        // back to the web.config/app.config file.
                        if (!(e.InnerException is TypeInitializationException))
                        {
                            throw;
                        }
                        isAvailable = false;
                    }

                    if (isAvailable)
                    {
                        _getServiceSettingMethod = roleEnvironmentType.GetMethod(GetSettingValueMethodName,
                            BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod);
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether the given exception represents an exception throws
        /// for a missing setting.
        /// </summary>
        /// <param name="e">Exception</param>
        /// <returns>True for the missing setting exception.</returns>
        private bool IsMissingSettingException(Exception e)
        {
            if (e == null)
            {
                return false;
            }
            Type type = e.GetType();

            return object.ReferenceEquals(type, _roleEnvironmentExceptionType)
                || type.IsSubclassOf(_roleEnvironmentExceptionType);
        }

        /// <summary>
        /// Gets a setting with the given name.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>Setting value or null if such setting does not exist.</returns>
        internal string GetSetting(string name)
        {
            Debug.Assert(!string.IsNullOrEmpty(name));

            string value = null;

            if (_getServiceSettingMethod != null)
            {
                try
                {
                    value = (string)_getServiceSettingMethod.Invoke(null, new object[] { name });
                }
                catch (TargetInvocationException e)
                {
                    if (!IsMissingSettingException(e.InnerException))
                    {
                        throw;
                    }
                }
            }
            if (value == null)
            {
                value = ConfigurationManager.AppSettings[name];
            }
            if (value == null)
            {
                value = WebConfigurationManager.AppSettings[name];
            }

            return value;
        }

        /// <summary>
        /// Loads and returns the latest available version of the servuce
        /// runtime assembly.
        /// </summary>
        /// <returns>Loaded assembly, if any.</returns>
        private Assembly GetServiceRuntimeAssembly()
        {
            Assembly assembly = null;

            for (int i = 0; assembly == null && i < knownAssemblyNames.Length; i++)
            {
                AssemblyName name = new AssemblyName(knownAssemblyNames[i]);
                try
                {
                    assembly = Assembly.Load(name);
                    break;
                }
                catch (Exception e)
                {
                    if (!(e is FileNotFoundException || e is FileLoadException || e is BadImageFormatException))
                    {
                        throw;
                    }
                }
            }

            return assembly;
        }

        /// <summary>
        /// Gets the setting defined in the Windows Azure configuration file.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>Setting value.</returns>
        private string GetServiceSetting(string name)
        {
            if (_getServiceSettingMethod != null)
            {
                return (string)_getServiceSettingMethod.Invoke(null, new object[] { name });
            }

            return null;
        }
    }
}
