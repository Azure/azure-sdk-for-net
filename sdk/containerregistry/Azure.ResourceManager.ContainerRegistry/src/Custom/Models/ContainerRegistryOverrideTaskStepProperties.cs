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
    public partial class ContainerRegistryOverrideTaskStepProperties : IJsonModel<ContainerRegistryOverrideTaskStepProperties>, IPersistableModel<ContainerRegistryOverrideTaskStepProperties>
    {
        ContainerRegistryOverrideTaskStepProperties IJsonModel<ContainerRegistryOverrideTaskStepProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryOverrideTaskStepProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryOverrideTaskStepProperties IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryOverrideTaskStepProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("contextPath")]
        public string ContextPath { get { throw new NotSupportedException(); } set { } }
        [WirePath("file")]
        public string File { get { throw new NotSupportedException(); } set { } }
        [WirePath("target")]
        public string Target { get { throw new NotSupportedException(); } set { } }
        [WirePath("updateTriggerToken")]
        public string UpdateTriggerToken { get { throw new NotSupportedException(); } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw new NotSupportedException(); } }
        [WirePath("values")]
        public IList<ContainerRegistryTaskOverridableValue> Values { get { throw new NotSupportedException(); } }
    }
}
