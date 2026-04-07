// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

// Backward-compat: type alias for renamed type (ApiCompat TypesMustExist + CannotRemoveBaseTypeOrInterface)
// Old name: InitContainerDefinitionContent, New name: InitContainerDefinition

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward compatibility alias for <see cref="InitContainerDefinition"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class InitContainerDefinitionContent : InitContainerDefinition,
        IJsonModel<InitContainerDefinitionContent>,
        IPersistableModel<InitContainerDefinitionContent>
    {
        /// <summary> Initializes a new instance of <see cref="InitContainerDefinitionContent"/>. </summary>
        protected InitContainerDefinitionContent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="InitContainerDefinitionContent"/>. </summary>
        /// <param name="name"> The init container name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InitContainerDefinitionContent(string name) : base(name)
        {
        }

        /// <summary> Wraps an <see cref="InitContainerDefinition"/> instance. </summary>
        internal InitContainerDefinitionContent(InitContainerDefinition other) : base(other?.Name)
        {
        }

        InitContainerDefinitionContent IJsonModel<InitContainerDefinitionContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use InitContainerDefinition for deserialization.");

        void IJsonModel<InitContainerDefinitionContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            // Write directly instead of delegating to IJsonModel<InitContainerDefinition>.Write
            // to avoid infinite recursion via WriteObjectValue generic dispatch.
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        InitContainerDefinitionContent IPersistableModel<InitContainerDefinitionContent>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use InitContainerDefinition for deserialization.");

        string IPersistableModel<InitContainerDefinitionContent>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => "J";

        BinaryData IPersistableModel<InitContainerDefinitionContent>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);
    }
}
