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
    public partial class ContainerRegistryEncodedTaskStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryEncodedTaskStep>, IPersistableModel<ContainerRegistryEncodedTaskStep>
    {
        ContainerRegistryEncodedTaskStep IJsonModel<ContainerRegistryEncodedTaskStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryEncodedTaskStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryEncodedTaskStep>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryEncodedTaskStep IPersistableModel<ContainerRegistryEncodedTaskStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryEncodedTaskStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryEncodedTaskStep(string encodedTaskContent) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("encodedTaskContent")]
        public string EncodedTaskContent { get { throw new NotSupportedException(); } set { } }
        [WirePath("encodedValuesContent")]
        public string EncodedValuesContent { get { throw new NotSupportedException(); } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }
}
