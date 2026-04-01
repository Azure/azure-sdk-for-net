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
    public partial class ContainerRegistryTaskOverridableValue : IJsonModel<ContainerRegistryTaskOverridableValue>, IPersistableModel<ContainerRegistryTaskOverridableValue>
    {
        ContainerRegistryTaskOverridableValue IJsonModel<ContainerRegistryTaskOverridableValue>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTaskOverridableValue>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTaskOverridableValue>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTaskOverridableValue IPersistableModel<ContainerRegistryTaskOverridableValue>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTaskOverridableValue>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryTaskOverridableValue(string name, string value) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } set { } }
        [WirePath("value")]
        public string Value { get { throw new NotSupportedException(); } set { } }
        [WirePath("isSecret")]
        public bool? IsSecret { get { throw new NotSupportedException(); } set { } }
    }
}
