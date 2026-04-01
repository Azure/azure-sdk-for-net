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
    public partial class ContainerRegistryTimerTriggerUpdateContent : IJsonModel<ContainerRegistryTimerTriggerUpdateContent>, IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>
    {
        ContainerRegistryTimerTriggerUpdateContent IJsonModel<ContainerRegistryTimerTriggerUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTimerTriggerUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTimerTriggerUpdateContent IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTimerTriggerUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryTimerTriggerUpdateContent(string name) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("schedule")]
        public string Schedule { get { throw new NotSupportedException(); } set { } }
        [WirePath("name")]
        public string Name { get { throw new NotSupportedException(); } }
        [WirePath("status")]
        public ContainerRegistryTriggerStatus? Status { get { throw new NotSupportedException(); } set { } }
    }
}
