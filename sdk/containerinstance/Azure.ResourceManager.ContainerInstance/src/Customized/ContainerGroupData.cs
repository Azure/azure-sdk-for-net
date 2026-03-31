// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;
using Azure.ResourceManager.Models;
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

        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Zones = new ChangeTrackingList<string>();
            Properties = new ContainerGroupPropertiesProperties(containers.Cast<Container>());
        }

        /// <summary> Initializes a new instance of <see cref="ContainerGroupData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers, ContainerInstanceOperatingSystemType osType)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Zones = new ChangeTrackingList<string>();
            Properties = new ContainerGroupPropertiesProperties(containers.Cast<Container>());
            OsType = osType.ToString();
        }

        /// <summary> The operating system type required by the containers in the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceOperatingSystemType? ContainerGroupOSType
        {
            get => OsType.HasValue ? new ContainerInstanceOperatingSystemType(OsType.Value.ToString()) : null;
            set => OsType = value.HasValue ? new OperatingSystemTypes(value.Value.ToString()) : null;
        }

        /// <summary> The provisioning state of the container group. This only appears in the response. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProvisioningState? ContainerGroupProvisioningState
        {
            get => Properties?.ProvisioningState;
        }

        // backward-compat shim: old property name was IPAddress (with capital P), new is IpAddress
        /// <summary> The IP address type of the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupIPAddress IPAddress
        {
            get => IpAddress is ContainerGroupIPAddress cgip ? cgip : null;
            set => IpAddress = value;
        }

        // NOTE: Many property type shims (Containers→IList<ContainerInstanceContainer>,
        // EncryptionProperties→ContainerGroupEncryptionProperties, DiagnosticsLogAnalytics→ContainerGroupLogAnalytics,
        // Identity→ManagedServiceIdentity, etc.) cannot be added here because ContainerGroupData is a
        // generated partial class and the generated file already defines these properties with new types.
        // C# does not allow redefining a property in the same partial class even with the 'new' keyword.
        // These will remain as ApiCompat errors that require generator-level fixes.
    }
}
