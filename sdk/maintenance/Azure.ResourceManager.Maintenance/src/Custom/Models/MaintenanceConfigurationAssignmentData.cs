// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Models
{
    /// <summary>
    /// Maintenance configuration assignment data.
    /// In the old (autorest-generated) SDK, this type was in the Models namespace.
    /// Using [CodeGenType] to keep it in Models for backward compatibility.
    /// </summary>
    [CodeGenType("MaintenanceConfigurationAssignmentData")]
    [CodeGenSuppress("Location")]
    public partial class MaintenanceConfigurationAssignmentData
    {
        /// <summary> Location of the resource. </summary>
        public AzureLocation? Location { get; set; }
    }
}
