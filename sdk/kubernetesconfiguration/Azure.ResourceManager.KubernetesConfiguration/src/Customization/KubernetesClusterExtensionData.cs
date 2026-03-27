// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.KubernetesConfiguration.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KubernetesConfiguration
{
    // Customization reason: The new TypeSpec generator generates getter-only collection properties
    // (ConfigurationSettings, ConfigurationProtectedSettings, Statuses), but the previous GA SDK
    // (v1.2.0, ApiCompatVersion) exposed these properties with public setters. To maintain backward
    // API compatibility and avoid breaking changes, we suppress the generated getter-only properties
    // and replace them with custom implementations that include both getters and setters.
    // Additionally, the @@alternateType decorator in client.tsp maps AksAssignedIdentity back to
    // ManagedServiceIdentity and PackageUri back to Uri for backward compatibility with AutoRest SDK.
    [CodeGenSuppress("ConfigurationSettings")]
    [CodeGenSuppress("ConfigurationProtectedSettings")]
    [CodeGenSuppress("Statuses")]
    public partial class KubernetesClusterExtensionData
    {
        /// <summary> Configuration settings, as name-value pairs for configuring this extension. </summary>
        public IDictionary<string, string> ConfigurationSettings
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionProperties();
                }
                return Properties.ConfigurationSettings;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionProperties();
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
                    Properties = new KubernetesClusterExtensionProperties();
                }
                return Properties.ConfigurationProtectedSettings;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionProperties();
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

        /// <summary> Status from this extension. </summary>
        public IList<KubernetesClusterExtensionStatus> Statuses
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionProperties();
                }
                return Properties.Statuses;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionProperties();
                }
                Properties.Statuses.Clear();
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        Properties.Statuses.Add(item);
                    }
                }
            }
        }
    }
}
