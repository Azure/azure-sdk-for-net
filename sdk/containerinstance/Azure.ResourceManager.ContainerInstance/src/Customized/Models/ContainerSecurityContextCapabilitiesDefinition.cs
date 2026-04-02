// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

// Backward-compat: type alias for renamed type (ApiCompat TypesMustExist + CannotRemoveBaseTypeOrInterface)
// Old name: ContainerSecurityContextCapabilitiesDefinition, New name: SecurityContextCapabilitiesDefinition

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward compatibility alias for <see cref="SecurityContextCapabilitiesDefinition"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerSecurityContextCapabilitiesDefinition : SecurityContextCapabilitiesDefinition,
        IJsonModel<ContainerSecurityContextCapabilitiesDefinition>,
        IPersistableModel<ContainerSecurityContextCapabilitiesDefinition>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerSecurityContextCapabilitiesDefinition"/>. </summary>
        public ContainerSecurityContextCapabilitiesDefinition()
        {
        }

        ContainerSecurityContextCapabilitiesDefinition IJsonModel<ContainerSecurityContextCapabilitiesDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use SecurityContextCapabilitiesDefinition for deserialization.");

        void IJsonModel<ContainerSecurityContextCapabilitiesDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SecurityContextCapabilitiesDefinition>)this).Write(writer, options);

        ContainerSecurityContextCapabilitiesDefinition IPersistableModel<ContainerSecurityContextCapabilitiesDefinition>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use SecurityContextCapabilitiesDefinition for deserialization.");

        string IPersistableModel<ContainerSecurityContextCapabilitiesDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<SecurityContextCapabilitiesDefinition>)this).GetFormatFromOptions(options);

        BinaryData IPersistableModel<ContainerSecurityContextCapabilitiesDefinition>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<SecurityContextCapabilitiesDefinition>)this).Write(options);
    }
}
