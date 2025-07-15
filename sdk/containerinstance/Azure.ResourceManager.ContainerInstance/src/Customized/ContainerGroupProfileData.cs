// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerInstance
{
    /// <summary>
    /// A class representing the ContainerGroupProfile data model.
    /// A container group profile.
    /// </summary>
    public partial class ContainerGroupProfileData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProfileData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers, ContainerInstanceOperatingSystemType osType) : base(location)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            Containers = containers.ToList();
            ImageRegistryCredentials = new ChangeTrackingList<ContainerGroupImageRegistryCredential>();
            OSType = osType;
            Volumes = new ChangeTrackingList<ContainerVolume>();
            InitContainers = new ChangeTrackingList<InitContainerDefinitionContent>();
            Extensions = new ChangeTrackingList<DeploymentExtensionSpec>();
            Zones = new ChangeTrackingList<string>();
            RegisteredRevisions = new ChangeTrackingList<long>();
        }
    }
}
