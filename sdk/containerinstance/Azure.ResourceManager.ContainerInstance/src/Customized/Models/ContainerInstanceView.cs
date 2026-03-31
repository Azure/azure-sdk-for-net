// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for ContainerPropertiesInstanceView. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerInstanceView : ContainerPropertiesInstanceView,
        IJsonModel<ContainerInstanceView>, IPersistableModel<ContainerInstanceView>
    {
        internal ContainerInstanceView() { }
        ContainerInstanceView IJsonModel<ContainerInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerPropertiesInstanceView directly.");
        void IJsonModel<ContainerInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ContainerPropertiesInstanceView>)this).Write(writer, options);
        ContainerInstanceView IPersistableModel<ContainerInstanceView>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerPropertiesInstanceView directly.");
        string IPersistableModel<ContainerInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerPropertiesInstanceView>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerInstanceView>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerPropertiesInstanceView>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Collections.Generic.IReadOnlyList<ContainerEvent> Events => default;
    }
}
