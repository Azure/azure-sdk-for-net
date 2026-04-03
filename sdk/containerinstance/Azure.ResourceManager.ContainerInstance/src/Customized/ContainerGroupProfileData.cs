// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;

// Backward-compat constructor shim: generated base is now ResourceData, not TrackedResourceData.
// Collection properties are now get-only IList behind internal Properties delegation;
// we populate them via Add() instead of direct assignment.

namespace Azure.ResourceManager.ContainerInstance
{
    public partial class ContainerGroupProfileData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProfileData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers, ContainerInstanceOperatingSystemType osType) : this()
        {
            Argument.AssertNotNull(containers, nameof(containers));

            Location = location;
            foreach (var c in containers)
                Containers.Add(c);
            OsType = osType;
        }
    }
}
