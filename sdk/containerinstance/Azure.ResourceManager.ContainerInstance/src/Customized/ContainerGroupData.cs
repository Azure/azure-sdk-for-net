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
    public partial class ContainerGroupData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<Container> containers)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Zones = new ChangeTrackingList<string>();
            Properties = new ContainerGroupPropertiesProperties(containers);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<Container> containers, OperatingSystemTypes osType)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Zones = new ChangeTrackingList<string>();
            Properties = new ContainerGroupPropertiesProperties(containers);
            OsType = osType;
        }

        /// <summary> The operating system type required by the containers in the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OperatingSystemTypes OSType
        {
            get => OsType.ToString();
            set => OsType = value.ToString();
        }

        /// <summary> The provisioning state of the container group. This only appears in the response. </summary>
        public string ProvisioningState { get => Properties?.ProvisioningState; }
    }
}
