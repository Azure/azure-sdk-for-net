// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KubernetesConfiguration.Models
{
    // Setters restored for backward API compatibility — the new TypeSpec generator omits
    // setters on collection properties, but the previous GA had them.
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
