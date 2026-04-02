// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

// Backward-compat: type alias for renamed type (ApiCompat TypesMustExist + CannotRemoveBaseTypeOrInterface)
// Old name: ContainerInstanceUsageName, New name: UsageName

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward compatibility alias for <see cref="UsageName"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerInstanceUsageName : UsageName,
        IJsonModel<ContainerInstanceUsageName>,
        IPersistableModel<ContainerInstanceUsageName>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceUsageName"/>. </summary>
        internal ContainerInstanceUsageName()
        {
        }

        ContainerInstanceUsageName IJsonModel<ContainerInstanceUsageName>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use UsageName for deserialization.");

        void IJsonModel<ContainerInstanceUsageName>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<UsageName>)this).Write(writer, options);

        ContainerInstanceUsageName IPersistableModel<ContainerInstanceUsageName>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use UsageName for deserialization.");

        string IPersistableModel<ContainerInstanceUsageName>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<UsageName>)this).GetFormatFromOptions(options);

        BinaryData IPersistableModel<ContainerInstanceUsageName>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<UsageName>)this).Write(options);
    }
}
