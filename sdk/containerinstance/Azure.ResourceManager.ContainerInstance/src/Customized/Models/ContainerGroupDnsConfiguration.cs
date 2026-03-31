// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for DnsConfiguration. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupDnsConfiguration : DnsConfiguration,
        IJsonModel<ContainerGroupDnsConfiguration>, IPersistableModel<ContainerGroupDnsConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupDnsConfiguration"/>. </summary>
        /// <param name="nameServers"> The DNS servers for the container group. </param>
        public ContainerGroupDnsConfiguration(System.Collections.Generic.IEnumerable<string> nameServers) : base(nameServers) { }
        ContainerGroupDnsConfiguration IJsonModel<ContainerGroupDnsConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use DnsConfiguration directly.");
        void IJsonModel<ContainerGroupDnsConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<DnsConfiguration>)this).Write(writer, options);
        ContainerGroupDnsConfiguration IPersistableModel<ContainerGroupDnsConfiguration>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use DnsConfiguration directly.");
        string IPersistableModel<ContainerGroupDnsConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<DnsConfiguration>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupDnsConfiguration>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<DnsConfiguration>)this).Write(options);
    }
}
