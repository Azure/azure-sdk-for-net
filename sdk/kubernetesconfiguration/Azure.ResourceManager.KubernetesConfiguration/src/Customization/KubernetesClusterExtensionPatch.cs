// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KubernetesConfiguration.Models
{
    // Customization reason: The new TypeSpec generator generates getter-only collection properties
    // (ConfigurationSettings, ConfigurationProtectedSettings), but the previous GA SDK (v1.2.0,
    // ApiCompatVersion) exposed these properties with public setters. To maintain backward API
    // compatibility and avoid breaking changes, we suppress the generated getter-only properties
    // and replace them with custom implementations that include both getters and setters.
    [CodeGenSuppress("ConfigurationSettings")]
    [CodeGenSuppress("ConfigurationProtectedSettings")]
    public partial class KubernetesClusterExtensionPatch
    {
        /// <summary> Configuration settings, as name-value pairs for configuring this extension. </summary>
        public IDictionary<string, string> ConfigurationSettings
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionPatchProperties();
                }
                return Properties.ConfigurationSettings;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionPatchProperties();
                }
                Properties.ConfigurationSettings.Clear();
                if (value != null)
                {
                    foreach (var kvp in value)
                    {
                        Properties.ConfigurationSettings[kvp.Key] = kvp.Value;
                    }
                }
            }
        }

        /// <summary> Configuration settings that are sensitive, as name-value pairs for configuring this extension. </summary>
        public IDictionary<string, string> ConfigurationProtectedSettings
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionPatchProperties();
                }
                return Properties.ConfigurationProtectedSettings;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionPatchProperties();
                }
                Properties.ConfigurationProtectedSettings.Clear();
                if (value != null)
                {
                    foreach (var kvp in value)
                    {
                        Properties.ConfigurationProtectedSettings[kvp.Key] = kvp.Value;
                    }
                }
            }
        }
    }
}
