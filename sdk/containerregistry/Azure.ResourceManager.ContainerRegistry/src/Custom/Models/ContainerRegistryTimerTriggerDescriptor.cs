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
    public partial class ContainerRegistryTimerTriggerDescriptor : IJsonModel<ContainerRegistryTimerTriggerDescriptor>, IPersistableModel<ContainerRegistryTimerTriggerDescriptor>
    {
        ContainerRegistryTimerTriggerDescriptor IJsonModel<ContainerRegistryTimerTriggerDescriptor>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryTimerTriggerDescriptor>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryTimerTriggerDescriptor IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryTimerTriggerDescriptor>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("timerTriggerName")]
        public string TimerTriggerName { get { throw new NotSupportedException(); } set { } }
        [WirePath("scheduleOccurrence")]
        public string ScheduleOccurrence { get { throw new NotSupportedException(); } set { } }
    }
}
