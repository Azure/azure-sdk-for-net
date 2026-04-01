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
    public partial class SourceCodeRepoUpdateContent : IJsonModel<SourceCodeRepoUpdateContent>, IPersistableModel<SourceCodeRepoUpdateContent>
    {
        SourceCodeRepoUpdateContent IJsonModel<SourceCodeRepoUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceCodeRepoUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoUpdateContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceCodeRepoUpdateContent IPersistableModel<SourceCodeRepoUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceCodeRepoUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("sourceControlType")]
        public SourceControlType? SourceControlType { get { throw new NotSupportedException(); } set { } }
        [WirePath("repositoryUrl")]
        public System.Uri RepositoryUri { get { throw new NotSupportedException(); } set { } }
        [WirePath("branch")]
        public string Branch { get { throw new NotSupportedException(); } set { } }
        [WirePath("sourceControlAuthProperties")]
        public SourceCodeRepoAuthInfoUpdateContent SourceControlAuthProperties { get { throw new NotSupportedException(); } set { } }
    }
}
