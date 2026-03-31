// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for Container. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerInstanceContainer : Container,
        IJsonModel<ContainerInstanceContainer>, IPersistableModel<ContainerInstanceContainer>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The name of the container instance. </param>
        public ContainerInstanceContainer(string name) : base(name) { }

        /// <summary> Initializes a new instance of <see cref="ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The name of the container instance. </param>
        /// <param name="image"> The name of the image used to create the container instance. </param>
        /// <param name="resources"> The resource requirements of the container instance. </param>
        public ContainerInstanceContainer(string name, string image, ContainerResourceRequirements resources) : base(name, image, resources) { }
        ContainerInstanceContainer IJsonModel<ContainerInstanceContainer>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Container directly.");
        void IJsonModel<ContainerInstanceContainer>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<Container>)this).Write(writer, options);
        ContainerInstanceContainer IPersistableModel<ContainerInstanceContainer>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use Container directly.");
        string IPersistableModel<ContainerInstanceContainer>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<Container>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<ContainerInstanceContainer>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<Container>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerInstanceView InstanceView => default;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerResourceRequirements Resources
        {
            get => default;
            set => base.Resources = value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerSecurityContextDefinition SecurityContext
        {
            get => default;
            set => base.SecurityContext = value;
        }
    }
}
