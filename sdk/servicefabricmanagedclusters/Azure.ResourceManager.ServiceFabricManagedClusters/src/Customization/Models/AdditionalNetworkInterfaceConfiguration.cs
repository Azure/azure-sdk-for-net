// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public partial class AdditionalNetworkInterfaceConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="AdditionalNetworkInterfaceConfiguration"/>. </summary>
        /// <param name="name"> Name of the network interface. </param>
        /// <param name="ipConfigurations"> Specifies the IP configurations of the network interface. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="ipConfigurations"/> is null. </exception>
        ///
        [Obsolete("This constructor is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AdditionalNetworkInterfaceConfiguration(string name, IEnumerable<ServiceFabricManagedClusterIPConfiguration> ipConfigurations)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(ipConfigurations, nameof(ipConfigurations));

            Name = name;
            List<IPConfiguration> configs = new List<IPConfiguration>();

            foreach (var ipConfiguration in ipConfigurations)
            {
                configs.Add(ipConfiguration.ToIPConfiguration());
            }
            IPConfigurations = configs;
        }
    }
}
