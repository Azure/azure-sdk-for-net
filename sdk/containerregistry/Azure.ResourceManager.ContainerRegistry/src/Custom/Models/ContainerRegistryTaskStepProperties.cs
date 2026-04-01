// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591, SA1402, SA1508, CS0618

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [PersistableModelProxy(typeof(UnknownTaskStepProperties))]
    public abstract partial class ContainerRegistryTaskStepProperties : IJsonModel<ContainerRegistryTaskStepProperties>, IPersistableModel<ContainerRegistryTaskStepProperties>
    {
        ContainerRegistryTaskStepProperties IJsonModel<ContainerRegistryTaskStepProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskStepProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskStepProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskStepProperties IPersistableModel<ContainerRegistryTaskStepProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskStepProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected ContainerRegistryTaskStepProperties() { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("baseImageDependencies")]
        public IReadOnlyList<ContainerRegistryBaseImageDependency> BaseImageDependencies { get { throw new NotSupportedException(); } }
        [WirePath("contextPath")]
        public string ContextPath { get { throw new NotSupportedException(); } set { } }
        [WirePath("contextAccessToken")]
        public string ContextAccessToken { get { throw new NotSupportedException(); } set { } }
    }
}
