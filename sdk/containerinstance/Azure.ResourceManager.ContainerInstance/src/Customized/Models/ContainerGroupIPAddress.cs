// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for IpAddress. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupIPAddress : IpAddress,
        IJsonModel<ContainerGroupIPAddress>, IPersistableModel<ContainerGroupIPAddress>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupIPAddress"/>. </summary>
        /// <param name="ports"> The list of ports exposed on the container group. </param>
        /// <param name="addressType"> Specifies if the IP is exposed to the public internet or private VNET. </param>
        public ContainerGroupIPAddress(System.Collections.Generic.IEnumerable<ContainerGroupPort> ports, ContainerGroupIPAddressType addressType) : base(ports?.Select(p => (Port)p) ?? new System.Collections.Generic.List<Port>(), addressType) { }
        private static System.Collections.Generic.IEnumerable<T> EmptyIfNull<T>(System.Collections.Generic.IEnumerable<T> items) => items ?? System.Linq.Enumerable.Empty<T>();
        ContainerGroupIPAddress IJsonModel<ContainerGroupIPAddress>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use IpAddress directly.");
        void IJsonModel<ContainerGroupIPAddress>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<IpAddress>)this).Write(writer, options);
        ContainerGroupIPAddress IPersistableModel<ContainerGroupIPAddress>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use IpAddress directly.");
        string IPersistableModel<ContainerGroupIPAddress>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<IpAddress>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupIPAddress>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<IpAddress>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupIPAddressType AddressType
        {
            get => new ContainerGroupIPAddressType(base.Type.ToString());
            set => base.Type = new ContainerGroupIpAddressType(value.ToString());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.Net.IPAddress IP
        {
            get => System.Net.IPAddress.TryParse(base.Ip, out var ip) ? ip : null;
            set => base.Ip = value?.ToString();
        }
    }
}
