// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for ContainerGroupPropertiesPropertiesInstanceView. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupInstanceView : ContainerGroupPropertiesPropertiesInstanceView,
        IJsonModel<ContainerGroupInstanceView>, IPersistableModel<ContainerGroupInstanceView>
    {
        internal ContainerGroupInstanceView() { }

        internal ContainerGroupInstanceView(System.Collections.Generic.IReadOnlyList<Event> events, string state)
            : base(events, state, null) { }

        ContainerGroupInstanceView IJsonModel<ContainerGroupInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerGroupPropertiesPropertiesInstanceView directly.");
        void IJsonModel<ContainerGroupInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ContainerGroupPropertiesPropertiesInstanceView>)this).Write(writer, options);
        ContainerGroupInstanceView IPersistableModel<ContainerGroupInstanceView>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ContainerGroupPropertiesPropertiesInstanceView directly.");
        string IPersistableModel<ContainerGroupInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerGroupPropertiesPropertiesInstanceView>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerGroupInstanceView>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ContainerGroupPropertiesPropertiesInstanceView>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new System.Collections.Generic.IReadOnlyList<ContainerEvent> Events => default;
    }
}
