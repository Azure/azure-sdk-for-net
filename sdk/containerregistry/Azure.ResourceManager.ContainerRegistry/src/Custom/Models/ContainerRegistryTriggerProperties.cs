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
    public partial class ContainerRegistryTriggerProperties : IJsonModel<ContainerRegistryTriggerProperties>, IPersistableModel<ContainerRegistryTriggerProperties>
    {
        ContainerRegistryTriggerProperties IJsonModel<ContainerRegistryTriggerProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTriggerProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTriggerProperties>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTriggerProperties IPersistableModel<ContainerRegistryTriggerProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTriggerProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceTriggers")]
        public IList<ContainerRegistrySourceTrigger> SourceTriggers { get { throw new NotSupportedException(); } }
        [WirePath("timerTriggers")]
        public IList<ContainerRegistryTimerTrigger> TimerTriggers { get { throw new NotSupportedException(); } }
        [WirePath("baseImageTrigger")]
        public ContainerRegistryBaseImageTrigger BaseImageTrigger { get { throw new NotSupportedException(); } set { } }
    }
}
