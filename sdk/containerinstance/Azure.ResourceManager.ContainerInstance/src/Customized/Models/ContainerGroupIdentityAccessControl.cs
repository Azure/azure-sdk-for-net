// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for IdentityAccessControl. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupIdentityAccessControl : IdentityAccessControl,
        IJsonModel<ContainerGroupIdentityAccessControl>, IPersistableModel<ContainerGroupIdentityAccessControl>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupIdentityAccessControl"/>. </summary>
        public ContainerGroupIdentityAccessControl() : base() { }
        ContainerGroupIdentityAccessControl IJsonModel<ContainerGroupIdentityAccessControl>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use IdentityAccessControl directly.");
        void IJsonModel<ContainerGroupIdentityAccessControl>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<IdentityAccessControl>)this).Write(writer, options);
        ContainerGroupIdentityAccessControl IPersistableModel<ContainerGroupIdentityAccessControl>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use IdentityAccessControl directly.");
        string IPersistableModel<ContainerGroupIdentityAccessControl>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<IdentityAccessControl>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupIdentityAccessControl>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<IdentityAccessControl>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerGroupIdentityAccessLevel? Access
        {
            get => base.Access.HasValue ? new ContainerGroupIdentityAccessLevel(base.Access.Value.ToString()) : default(ContainerGroupIdentityAccessLevel?);
            set => base.Access = value.HasValue ? new IdentityAccessLevel(value.Value.ToString()) : default(IdentityAccessLevel?);
        }
    }
}
