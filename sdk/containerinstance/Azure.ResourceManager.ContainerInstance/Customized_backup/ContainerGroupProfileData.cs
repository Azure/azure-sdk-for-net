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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProfileData(AzureLocation location)
        {
            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Zones = new ChangeTrackingList<string>();
        }

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

        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="containers"> The containers within the container group. </param>
        /// <param name="osType"> The operating system type required by the containers in the container group. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containers"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupProfileData(AzureLocation location, IEnumerable<ContainerInstanceContainer> containers, ContainerInstanceOperatingSystemType osType)
        {
            Argument.AssertNotNull(containers, nameof(containers));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Zones = new ChangeTrackingList<string>();
            Properties = new ContainerGroupProfileProperties(containers.Cast<Container>(), osType.ToString());
        }

        /// <summary> The operating system type required by the containers in the container group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceOperatingSystemType? OSType
        {
            get => new ContainerInstanceOperatingSystemType(OsType.ToString());
            set => OsType = value.HasValue ? new OperatingSystemTypes(value.Value.ToString()) : default;
        }

        // backward-compat shim: old property name was IPAddress, new is IpAddress
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupIPAddress IPAddress
        {
            get => IpAddress as ContainerGroupIPAddress;
            set => IpAddress = value;
        }

        // NOTE: Other property type shims (Containers, EncryptionProperties, DiagnosticsLogAnalytics, etc.)
        // cannot be added here because ContainerGroupProfileData is a generated partial class and
        // the generated file already defines these properties with new types. C# does not allow
        // redefining a property in the same partial class even with the 'new' keyword.
    }
}
