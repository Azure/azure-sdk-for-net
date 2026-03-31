// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for Event. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerEvent : Event,
        IJsonModel<ContainerEvent>, IPersistableModel<ContainerEvent>
    {
        internal ContainerEvent() { }
        ContainerEvent IJsonModel<ContainerEvent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Event directly.");
        void IJsonModel<ContainerEvent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<Event>)this).Write(writer, options);
        ContainerEvent IPersistableModel<ContainerEvent>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Event directly.");
        string IPersistableModel<ContainerEvent>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<Event>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerEvent>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<Event>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string EventType => base.Type;
    }
}
