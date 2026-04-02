// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for SecretReference. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupSecretReference : SecretReference,
        IJsonModel<ContainerGroupSecretReference>, IPersistableModel<ContainerGroupSecretReference>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupSecretReference"/>. </summary>
        public ContainerGroupSecretReference(string name, Azure.Core.ResourceIdentifier identity, System.Uri secretReferenceUri) : base(name, identity, secretReferenceUri) { }
        ContainerGroupSecretReference IJsonModel<ContainerGroupSecretReference>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use SecretReference directly.");
        void IJsonModel<ContainerGroupSecretReference>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SecretReference>)this).Write(writer, options);
        ContainerGroupSecretReference IPersistableModel<ContainerGroupSecretReference>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use SecretReference directly.");
        string IPersistableModel<ContainerGroupSecretReference>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<SecretReference>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupSecretReference>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<SecretReference>)this).Write(options);
    }
}
