// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using static Microsoft.Azure.WebJobs.Utility;

namespace Microsoft.Azure.WebJobs
{
    public class ExtensionInfo
    {
        private ExtensionInfo(string name, string configurationSectionName)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ConfigurationSectionName = configurationSectionName ?? throw new ArgumentNullException(nameof(configurationSectionName));
        }

        /// <summary>
        /// Gets the friendly human readable name of the extension.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the resolved configuration section name for this extension.
        /// </summary>
        public string ConfigurationSectionName { get; }


        public static ExtensionInfo FromExtension<TExtension>() where TExtension : IExtensionConfigProvider
        {
            return GetExtensionInfo(typeof(TExtension));
        }

        public static ExtensionInfo FromInstance(IExtensionConfigProvider extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            return GetExtensionInfo(extension.GetType());
        }

        private static ExtensionInfo GetExtensionInfo(Type extensionType)
        {
            if (extensionType == null)
            {
                throw new ArgumentNullException(nameof(extensionType));
            }

            var attribute = extensionType.GetTypeInfo().GetCustomAttribute<ExtensionAttribute>(false);

            string name = null;
            string configSectionName = null;

            if (attribute != null)
            {
                name = attribute.Name;
                configSectionName = attribute.ConfigurationSection ?? GetExtensionAliasFromTypeName(extensionType.Name);
            }
            else
            {
                name = GetExtensionAliasFromTypeName(extensionType.Name);
                configSectionName = name;
            }

            return new ExtensionInfo(name, configSectionName);
        }
    }
}
