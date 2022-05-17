// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;

namespace Microsoft.Azure
{
    /// <summary>
    /// Configuration manager for accessing Microsoft Azure settings.
    /// </summary>
    public static class CloudConfigurationManager
    {
        private static object _lock = new object();
        private static AzureApplicationSettings _appSettings;

        /// <summary>
        /// Gets a setting with the given name.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <param name="outputResultsToTrace">If true, this will write that a setting was retrieved to Trace. If false, this will not write anything to Trace.</param>
        /// <param name="throwIfNotFoundInRuntime">If true, method will throw exception if setting not found in ServiceRuntime.</param>
        /// <returns>Setting value or null if not found.</returns>
        public static string GetSetting(string name, bool outputResultsToTrace, bool throwIfNotFoundInRuntime)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            else if (name.Length == 0)
            {
                string message = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorArgumentEmptyString, "name");
                throw new ArgumentException(message);
            }

            return AppSettings.GetSetting(name, outputResultsToTrace, throwIfNotFoundInRuntime);
        }

        /// <summary>
        /// Gets a setting with the given name.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <param name="outputResultsToTrace">If true, this will write that a setting was retrieved to Trace. If false, this will not write anything to Trace.</param>
        /// <returns>Setting value or null if not found.</returns>
        public static string GetSetting(string name, bool outputResultsToTrace)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            else if (name.Length == 0)
            {
                string message = string.Format(CultureInfo.CurrentUICulture, Resources.ErrorArgumentEmptyString, "name");
                throw new ArgumentException(message);
            }

            return AppSettings.GetSetting(name, outputResultsToTrace);
        }

        /// <summary>
        /// Gets a setting with the given name. Trace results.
        /// </summary>
        /// <remarks>This overloaded function is kept for backward compatibility.</remarks>
        /// <param name="name">Setting name.</param>
        /// <returns>Setting value or null if not found.</returns>
        public static string GetSetting(string name)
        {
            return GetSetting(name, true);
        }

        /// <summary>
        /// Gets application settings.
        /// </summary>
        internal static AzureApplicationSettings AppSettings
        {
            get
            {
                if (_appSettings == null)
                {
                    lock (_lock)
                    {
                        if (_appSettings == null)
                        {
                            _appSettings = new AzureApplicationSettings();
                        }
                    }
                }

                return _appSettings;
            }
        }
    }
}
