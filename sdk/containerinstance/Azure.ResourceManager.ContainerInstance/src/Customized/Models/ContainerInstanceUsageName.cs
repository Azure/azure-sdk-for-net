// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for UsageName. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerInstanceUsageName : UsageName,
        IJsonModel<ContainerInstanceUsageName>, IPersistableModel<ContainerInstanceUsageName>
    {
        internal ContainerInstanceUsageName() { }
        ContainerInstanceUsageName IJsonModel<ContainerInstanceUsageName>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use UsageName directly.");
        void IJsonModel<ContainerInstanceUsageName>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<UsageName>)this).Write(writer, options);
        ContainerInstanceUsageName IPersistableModel<ContainerInstanceUsageName>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use UsageName directly.");
        string IPersistableModel<ContainerInstanceUsageName>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<UsageName>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerInstanceUsageName>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<UsageName>)this).Write(options);
    }
}
