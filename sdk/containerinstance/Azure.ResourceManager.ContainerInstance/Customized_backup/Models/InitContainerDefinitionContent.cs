// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Collections.Generic;
using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.ContainerInstance;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for InitContainerDefinition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InitContainerDefinitionContent : InitContainerDefinition,
        IJsonModel<InitContainerDefinitionContent>, IPersistableModel<InitContainerDefinitionContent>
    {
        /// <summary> Initializes a new instance of <see cref="InitContainerDefinitionContent"/>. </summary>
        /// <param name="name"> The name of the init container. </param>
        public InitContainerDefinitionContent(string name) : base(name) { }
        InitContainerDefinitionContent IJsonModel<InitContainerDefinitionContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use InitContainerDefinition directly.");
        void IJsonModel<InitContainerDefinitionContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<InitContainerDefinition>)this).Write(writer, options);
        InitContainerDefinitionContent IPersistableModel<InitContainerDefinitionContent>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use InitContainerDefinition directly.");
        string IPersistableModel<InitContainerDefinitionContent>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<InitContainerDefinition>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<InitContainerDefinitionContent>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<InitContainerDefinition>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerSecurityContextDefinition SecurityContext
        {
            get => default;
            set => base.SecurityContext = value;
        }

        // backward-compat shim: old property returned IList<ContainerEnvironmentVariable>, new returns IList<EnvironmentVariable>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IList<ContainerEnvironmentVariable> EnvironmentVariables
            => base.EnvironmentVariables != null ? new UpCastList<ContainerEnvironmentVariable, EnvironmentVariable>(base.EnvironmentVariables) : null;

        // backward-compat shim: old property returned IList<ContainerVolumeMount>, new returns IList<VolumeMount>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IList<ContainerVolumeMount> VolumeMounts
            => base.VolumeMounts != null ? new UpCastList<ContainerVolumeMount, VolumeMount>(base.VolumeMounts) : null;
    }
}
