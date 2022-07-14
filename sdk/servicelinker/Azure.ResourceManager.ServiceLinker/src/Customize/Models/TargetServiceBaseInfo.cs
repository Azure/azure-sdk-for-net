// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    /// <summary>
    /// The target service properties
    /// Please note <see cref="TargetServiceBaseInfo"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AzureResourceInfo"/>, <see cref="ConfluentBootstrapServerInfo"/> and <see cref="ConfluentSchemaRegistryInfo"/>.
    /// </summary>
    [CodeGenSuppress("TargetServiceBaseInfo")]
    [CodeGenSuppress("TargetServiceBaseInfo", typeof(TargetServiceType))]
    public partial class TargetServiceBaseInfo
    {
        /// <summary> The target service type. </summary>
        internal TargetServiceType TargetServiceType { get; set; }
    }
}
