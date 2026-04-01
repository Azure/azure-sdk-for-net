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
    // Backward compatibility: Task-related model types (DockerBuildStep, EncodedTaskStep, FileTaskStep,
    // TaskOverridableValue, TaskPatch, TaskRunContent, TaskStepProperties, TaskStatus enum, etc.) have been
    // moved to Azure.ResourceManager.ContainerRegistryTasks. These deprecated stubs preserve the old API
    // surface with [Obsolete] attributes and NotSupportedException implementations so existing code compiles
    // but directs users to the new package.

    [Obsolete("This type has been moved to Azure.ResourceManager.ContainerRegistryTasks and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerRegistryDockerBuildStep : ContainerRegistryTaskStepProperties, IJsonModel<ContainerRegistryDockerBuildStep>, IPersistableModel<ContainerRegistryDockerBuildStep>
    {
        ContainerRegistryDockerBuildStep IJsonModel<ContainerRegistryDockerBuildStep>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<ContainerRegistryDockerBuildStep>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<ContainerRegistryDockerBuildStep>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        ContainerRegistryDockerBuildStep IPersistableModel<ContainerRegistryDockerBuildStep>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<ContainerRegistryDockerBuildStep>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public ContainerRegistryDockerBuildStep(string dockerFilePath) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("dockerFilePath")]
        public string DockerFilePath { get { throw new NotSupportedException(); } set { } }
        [WirePath("imageNames")]
        public IList<string> ImageNames { get { throw new NotSupportedException(); } }
        [WirePath("isPushEnabled")]
        public bool? IsPushEnabled { get { throw new NotSupportedException(); } set { } }
        [WirePath("noCache")]
        public bool? NoCache { get { throw new NotSupportedException(); } set { } }
        [WirePath("target")]
        public string Target { get { throw new NotSupportedException(); } set { } }
        [WirePath("arguments")]
        public IList<ContainerRegistryRunArgument> Arguments { get { throw new NotSupportedException(); } }
    }
}
