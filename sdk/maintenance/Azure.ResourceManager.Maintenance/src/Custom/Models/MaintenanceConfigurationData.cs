// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Rename MaintenancePublicConfigurationData to MaintenanceConfigurationData to maintain backward compatibility
    [CodeGenType("MaintenancePublicConfigurationData")]
    [CodeGenSuppress("Duration")]
    public partial class MaintenanceConfigurationData
    {
        /// <summary> Initializes a new instance of <see cref="MaintenanceConfigurationData"/> with a location. </summary>
        /// <param name="location"> The location of the resource. </param>
        public MaintenanceConfigurationData(AzureLocation location) : this()
        {
            Location = location.ToString();
        }

        /// <summary> Duration of the maintenance window in HH:mm format. If not provided, default value will be used based on maintenance scope provided. Example: 05:00. </summary>
        public TimeSpan? Duration
        {
            get => Properties?.Duration != null ? System.Xml.XmlConvert.ToTimeSpan(Properties.Duration) : null;
            set
            {
                if (Properties is null)
                    Properties = new MaintenanceConfigurationProperties();
                Properties.Duration = value.HasValue ? System.Xml.XmlConvert.ToString(value.Value) : null;
            }
        }
    }
}
