using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Web.Configuration;

namespace Microsoft.WindowsAzure.Configuration
{
    /// <summary>
    /// Windows Azure settings.
    /// </summary>
    public class AzureApplicationSettings
    {
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
                Type roleEnvironmentType = assembly.GetType("Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment", false);
                if (roleEnvironmentType != null)
                {
                    PropertyInfo isAvailableProperty = roleEnvironmentType.GetProperty("IsAvailable");
                    bool isAvailable = isAvailableProperty != null && (bool)isAvailableProperty.GetValue(null, new object[] {});

                    if (isAvailable)
                    {
                        _getServiceSettingMethod = roleEnvironmentType.GetMethod("GetConfigurationSettingValue",
                            BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a setting with the given name.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>Setting value or null if such setting does not exist.</returns>
        public string GetSetting(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (name.Length == 0)
            {
                string message = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorArgumentEmptyString, "name");
                throw new ArgumentException(message);
            }

            string value = null;

            if (_getServiceSettingMethod != null)
            {
                value = (string)_getServiceSettingMethod.Invoke(null, new object[] { name });
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
            // Assemblies prior to 1.7 had version tag 1.0.
            string[] assemblies = new string[]
            {
                "Microsoft.WindowsAzure.ServiceRuntime, Version=1.7, Culture=neutral, PublicKeyToken=31bf3856ad364e35, ProcessorArchitecture=MSIL",
                "Microsoft.WindowsAzure.ServiceRuntime, Version=1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, ProcessorArchitecture=MSIL",
            };

            Assembly assembly = null;

            for (int i = 0; assembly == null && i < assemblies.Length; i++)
            {
                AssemblyName name = new AssemblyName(assemblies[i]);
                try
                {
                    assembly = Assembly.Load(name);
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
