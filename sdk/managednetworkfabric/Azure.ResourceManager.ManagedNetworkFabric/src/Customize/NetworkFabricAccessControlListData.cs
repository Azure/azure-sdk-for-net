// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shims for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added a required constructor parameter (configurationType) and changed the type
    // of the ConfigurationType property from NetworkFabricConfigurationType? to NetworkFabricConfigurationType.
    // This preserves the v1.1.2 constructor and property type.
    public partial class NetworkFabricAccessControlListData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricAccessControlListData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkFabricAccessControlListData(AzureLocation location) : this(location, default)
        {
        }

        /// <summary> Input method to configure Access Control List. </summary>
        public NetworkFabricConfigurationType? ConfigurationType { get; set; }
    }
}
