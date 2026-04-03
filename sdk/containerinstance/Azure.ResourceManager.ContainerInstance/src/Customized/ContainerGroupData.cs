// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;

// Backward-compat constructors and property shims for TypeSpec migration (ApiCompat MembersMustExist).
// The old API had constructors taking (location, containers) and (location, containers, osType).
// The new generated type wraps collections behind internal Properties object, so we populate via Add().

namespace Azure.ResourceManager.ContainerInstance
{
    public partial class ContainerGroupData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers) : base(location)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            foreach (var c in containers)
                Containers.Add(c);
        }

        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers, ContainerInstanceOperatingSystemType osType) : base(location)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            foreach (var c in containers)
                Containers.Add(c);
            OSType = osType;
        }

        /// <summary> The operating system type required by the containers in the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceOperatingSystemType OSType
        {
            get => ContainerGroupOSType.ToString();
            set => ContainerGroupOSType = value.ToString();
        }

        /// <summary> The provisioning state of the container group. This only appears in the response. </summary>
        public string ProvisioningState { get => ContainerGroupProvisioningState.ToString(); }
    }
}
