// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward compatibility: the old SDK had a 3-param constructor taking (location, containers, osType).
    // The new generator only produces a 2-param constructor (location, containers).
    // Also provides OSType (non-nullable) as a wrapper over ContainerGroupOSType (nullable),
    // and ContainerGroupProvisioningState (typed) as a wrapper over ProvisioningState (string).
    public partial class ContainerGroupData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers, ContainerInstanceOperatingSystemType osType) : this(location, containers)
        {
            OSType = osType;
        }

        /// <summary> The operating system type required by the containers in the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceOperatingSystemType OSType
        {
            get => ContainerGroupOSType.HasValue ? ContainerGroupOSType.Value.ToString() : default;
            set => ContainerGroupOSType = value.ToString();
        }

        /// <summary> The provisioning state of the container group. This only appears in the response. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProvisioningState? ContainerGroupProvisioningState
        {
            get
            {
                var ps = ProvisioningState;
                return ps != null ? new ContainerGroupProvisioningState(ps) : null;
            }
        }
    }
}
