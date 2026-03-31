// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for SecurityContextDefinition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerSecurityContextDefinition : SecurityContextDefinition,
        IJsonModel<ContainerSecurityContextDefinition>, IPersistableModel<ContainerSecurityContextDefinition>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerSecurityContextDefinition"/>. </summary>
        public ContainerSecurityContextDefinition() : base() { }
        ContainerSecurityContextDefinition IJsonModel<ContainerSecurityContextDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use SecurityContextDefinition directly.");
        void IJsonModel<ContainerSecurityContextDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SecurityContextDefinition>)this).Write(writer, options);
        ContainerSecurityContextDefinition IPersistableModel<ContainerSecurityContextDefinition>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use SecurityContextDefinition directly.");
        string IPersistableModel<ContainerSecurityContextDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<SecurityContextDefinition>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerSecurityContextDefinition>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<SecurityContextDefinition>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsPrivileged
        {
            get => base.Privileged;
            set => base.Privileged = value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerSecurityContextCapabilitiesDefinition Capabilities
        {
            get => default;
            set => base.Capabilities = value;
        }
    }
}
