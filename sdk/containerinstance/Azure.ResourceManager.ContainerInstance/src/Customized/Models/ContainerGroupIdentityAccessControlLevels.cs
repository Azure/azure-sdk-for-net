// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for IdentityAcls. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupIdentityAccessControlLevels : IdentityAcls,
        IJsonModel<ContainerGroupIdentityAccessControlLevels>, IPersistableModel<ContainerGroupIdentityAccessControlLevels>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupIdentityAccessControlLevels"/>. </summary>
        public ContainerGroupIdentityAccessControlLevels() : base() { }
        ContainerGroupIdentityAccessControlLevels IJsonModel<ContainerGroupIdentityAccessControlLevels>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use IdentityAcls directly.");
        void IJsonModel<ContainerGroupIdentityAccessControlLevels>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<IdentityAcls>)this).Write(writer, options);
        ContainerGroupIdentityAccessControlLevels IPersistableModel<ContainerGroupIdentityAccessControlLevels>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use IdentityAcls directly.");
        string IPersistableModel<ContainerGroupIdentityAccessControlLevels>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<IdentityAcls>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupIdentityAccessControlLevels>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<IdentityAcls>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerGroupIdentityAccessLevel? DefaultAccess
        {
            get => base.DefaultAccess.HasValue ? new ContainerGroupIdentityAccessLevel(base.DefaultAccess.Value.ToString()) : default(ContainerGroupIdentityAccessLevel?);
            set => base.DefaultAccess = value.HasValue ? new IdentityAccessLevel(value.Value.ToString()) : default(IdentityAccessLevel?);
        }
    }
}
