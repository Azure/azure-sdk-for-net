// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for ResourceRequirements. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerResourceRequirements : ResourceRequirements,
        IJsonModel<ContainerResourceRequirements>, IPersistableModel<ContainerResourceRequirements>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerResourceRequirements"/>. </summary>
        /// <param name="requests"> The resource requests of this container instance. </param>
        public ContainerResourceRequirements(ContainerResourceRequestsContent requests) : base(requests) { }
        ContainerResourceRequirements IJsonModel<ContainerResourceRequirements>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ResourceRequirements directly.");
        void IJsonModel<ContainerResourceRequirements>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ResourceRequirements>)this).Write(writer, options);
        ContainerResourceRequirements IPersistableModel<ContainerResourceRequirements>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use ResourceRequirements directly.");
        string IPersistableModel<ContainerResourceRequirements>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ResourceRequirements>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerResourceRequirements>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ResourceRequirements>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerResourceLimits Limits
        {
            get => default;
            set => base.Limits = value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerResourceRequestsContent Requests
        {
            get => default;
            set => base.Requests = value;
        }
    }
}
