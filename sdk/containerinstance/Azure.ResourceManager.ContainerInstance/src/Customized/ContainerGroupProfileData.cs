// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;
using Container = Azure.ResourceManager.ContainerInstance.Models.Container;

namespace Azure.ResourceManager.ContainerInstance
{
    /// <summary>
    /// A class representing the ContainerGroupProfile data model.
    /// A container group profile.
    /// </summary>
    public partial class ContainerGroupProfileData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProfileData(AzureLocation location, IEnumerable<Container> containers, OperatingSystemTypes osType)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Zones = new ChangeTrackingList<string>();
            Properties = new ContainerGroupProfileProperties(containers, osType);
        }
    }
}
