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
    public partial class ContainerRegistryFileTaskStepUpdateContent : ContainerRegistryTaskStepUpdateContent, IJsonModel<ContainerRegistryFileTaskStepUpdateContent>, IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>
    {
        ContainerRegistryFileTaskStepUpdateContent IJsonModel<ContainerRegistryFileTaskStepUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryFileTaskStepUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryFileTaskStepUpdateContent IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryFileTaskStepUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("taskFilePath")]
        public string TaskFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("valuesFilePath")]
        public string ValuesFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }
}
