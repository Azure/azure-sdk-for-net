// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for AzureFileVolume. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerInstanceAzureFileVolume : AzureFileVolume,
        IJsonModel<ContainerInstanceAzureFileVolume>, IPersistableModel<ContainerInstanceAzureFileVolume>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceAzureFileVolume"/>. </summary>
        /// <param name="shareName"> The name of the Azure File share to be mounted as a volume. </param>
        /// <param name="storageAccountName"> The name of the storage account that contains the Azure File share. </param>
        public ContainerInstanceAzureFileVolume(string shareName, string storageAccountName) : base(shareName, storageAccountName) { }
        ContainerInstanceAzureFileVolume IJsonModel<ContainerInstanceAzureFileVolume>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use AzureFileVolume directly.");
        void IJsonModel<ContainerInstanceAzureFileVolume>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<AzureFileVolume>)this).Write(writer, options);
        ContainerInstanceAzureFileVolume IPersistableModel<ContainerInstanceAzureFileVolume>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use AzureFileVolume directly.");
        string IPersistableModel<ContainerInstanceAzureFileVolume>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<AzureFileVolume>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerInstanceAzureFileVolume>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<AzureFileVolume>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsReadOnly
        {
            get => base.ReadOnly;
            set => base.ReadOnly = value;
        }
    }
}
