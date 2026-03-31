// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for SecurityContextCapabilitiesDefinition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerSecurityContextCapabilitiesDefinition : SecurityContextCapabilitiesDefinition,
        IJsonModel<ContainerSecurityContextCapabilitiesDefinition>, IPersistableModel<ContainerSecurityContextCapabilitiesDefinition>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerSecurityContextCapabilitiesDefinition"/>. </summary>
        public ContainerSecurityContextCapabilitiesDefinition() : base() { }
        ContainerSecurityContextCapabilitiesDefinition IJsonModel<ContainerSecurityContextCapabilitiesDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use SecurityContextCapabilitiesDefinition directly.");
        void IJsonModel<ContainerSecurityContextCapabilitiesDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SecurityContextCapabilitiesDefinition>)this).Write(writer, options);
        ContainerSecurityContextCapabilitiesDefinition IPersistableModel<ContainerSecurityContextCapabilitiesDefinition>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use SecurityContextCapabilitiesDefinition directly.");
        string IPersistableModel<ContainerSecurityContextCapabilitiesDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<SecurityContextCapabilitiesDefinition>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerSecurityContextCapabilitiesDefinition>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<SecurityContextCapabilitiesDefinition>)this).Write(options);
    }
}
