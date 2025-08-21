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

            Containers = containers.ToList();
            ImageRegistryCredentials = new ChangeTrackingList<ContainerGroupImageRegistryCredential>();
            Volumes = new ChangeTrackingList<ContainerVolume>();
            SubnetIds = new ChangeTrackingList<ContainerGroupSubnetId>();
            InitContainers = new ChangeTrackingList<InitContainerDefinitionContent>();
            Extensions = new ChangeTrackingList<DeploymentExtensionSpec>();
            Zones = new ChangeTrackingList<string>();
            SecretReferences = new ChangeTrackingList<ContainerGroupSecretReference>();
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

            Containers = containers.ToList();
            ImageRegistryCredentials = new ChangeTrackingList<ContainerGroupImageRegistryCredential>();
            OSType = osType;
            Volumes = new ChangeTrackingList<ContainerVolume>();
            SubnetIds = new ChangeTrackingList<ContainerGroupSubnetId>();
            InitContainers = new ChangeTrackingList<InitContainerDefinitionContent>();
            Extensions = new ChangeTrackingList<DeploymentExtensionSpec>();
            Zones = new ChangeTrackingList<string>();
            SecretReferences = new ChangeTrackingList<ContainerGroupSecretReference>();
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
