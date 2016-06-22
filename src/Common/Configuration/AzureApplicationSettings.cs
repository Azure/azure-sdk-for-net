//
// Copyright Microsoft Corporation
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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;

[assembly: CLSCompliant(true)]
namespace Microsoft.Azure
{
    /// <summary>
    /// Microsoft Azure settings.
    /// </summary>
    internal class AzureApplicationSettings
    {
        private const string RoleEnvironmentTypeName = "Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment";
        private const string RoleEnvironmentExceptionTypeName = "Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironmentException";
        private const string IsAvailablePropertyName = "IsAvailable";
        private const string GetSettingValueMethodName = "GetConfigurationSettingValue";

        // Keep this array sorted by the version in the descendant order.
        private readonly string[] knownAssemblyNames = new string[]
        {
            "Microsoft.WindowsAzure.ServiceRuntime, Culture=neutral, PublicKeyToken=31bf3856ad364e35, ProcessorArchitecture=MSIL"
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
                        string message = string.Format(CultureInfo.InvariantCulture, "Loaded \"{0}\"", assembly.FullName);

                        if (isAvailable)
                        {
                            WriteTraceLine(message);
                        }
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
        /// <param name="outputResultsToTrace"></param>
        /// <returns>Setting value or null if such setting does not exist.</returns>
        internal string GetSetting(string name, bool outputResultsToTrace)
        {
            Debug.Assert(!string.IsNullOrEmpty(name));

            string value = null;

            value = GetValue("ServiceRuntime", name, GetServiceRuntimeSetting, outputResultsToTrace);
            if (value == null)
            {
                value = GetValue("ConfigurationManager", name, n => ConfigurationManager.AppSettings[n], outputResultsToTrace);
            }

            return value;
        }

        /// <summary>
        /// Gets a setting with the given name. This method is included for backwards compatibility.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>Setting value or null if such setting does not exist.</returns>
        internal string GetSetting(string name)
        {
            Debug.Assert(!string.IsNullOrEmpty(name));

            string value = null;

            value = GetValue("ServiceRuntime", name, GetServiceRuntimeSetting, true);
            if (value == null)
            {
                value = GetValue("ConfigurationManager", name, n => ConfigurationManager.AppSettings[n], true);
            }

            return value;
        }

        /// <summary>
        /// Gets setting's value from the given provider.
        /// </summary>
        /// <param name="providerName">Provider name.</param>
        /// <param name="settingName">Setting name</param>
        /// <param name="getValue">Method to obtain given setting.</param>
        /// <returns>Setting value, or null if not found.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Necessary for robust handling withing the configuration module.")]
        private static string GetValue(string providerName, string settingName, Func<string, string> getValue, bool outputResultsToTrace)
        {
            string value = getValue(settingName);

            if (outputResultsToTrace)
            {
                string message;

                if (value != null)
                {
                    message = "PASS";
                }
                else
                {
                    message = "FAIL";
                }

                message = string.Format(CultureInfo.InvariantCulture, "Getting \"{0}\" from {1}: {2}.", settingName, providerName, message);

                try
                {
                    WriteTraceLine(message);
                }
                catch (Exception)
                {
                    // Omit writing the trace message, running outside of dev fabric.
                }
            }

            return value;
        }

        /// <summary>
        /// Gets a configuration setting from the service runtime.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>Setting value or null if not found.</returns>
        private string GetServiceRuntimeSetting(string name)
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
            return value;
        }

        /// <summary>
        /// Loads and returns the latest available version of the service 
        /// runtime assembly.
        /// </summary>
        /// <returns>Loaded assembly, if any.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom",
            Justification = "The ServiceRuntime.dll has to be loaded at runtime so calling Assembly.LoadFrom method is essential to do the loading")]
        private Assembly GetServiceRuntimeAssembly()
        {
            Assembly assembly = null;

            foreach (string assemblyName in knownAssemblyNames)
            {
                string assemblyPath = NativeMethods.GetAssemblyPath(assemblyName);

                try
                {
                    if (!string.IsNullOrEmpty(assemblyPath))
                    {
                        assembly = Assembly.LoadFrom(assemblyPath);
                    }
                }
                catch (Exception e)
                {
                    // The following exceptions are ignored for enabling configuration manager to proceed
                    // and load the configuration from application settings instead of using ServiceRuntime.
                    if (!(e is FileNotFoundException ||
                          e is FileLoadException ||
                          e is BadImageFormatException))
                    {
                        throw;
                    }
                }
            }

            return assembly;
        }

        /// <summary>
        /// Writes to trace output if WriteToTrace is true
        /// </summary>
        /// <param name="message">The message to write to Trace</param>
        private static void WriteTraceLine(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
