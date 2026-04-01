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
    public partial class SourceCodeRepoAuthInfo : IJsonModel<SourceCodeRepoAuthInfo>, IPersistableModel<SourceCodeRepoAuthInfo>
    {
        SourceCodeRepoAuthInfo IJsonModel<SourceCodeRepoAuthInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceCodeRepoAuthInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceCodeRepoAuthInfo>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceCodeRepoAuthInfo IPersistableModel<SourceCodeRepoAuthInfo>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceCodeRepoAuthInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        public SourceCodeRepoAuthInfo(SourceCodeRepoAuthTokenType tokenType, string token) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        [WirePath("tokenType")]
        public SourceCodeRepoAuthTokenType TokenType { get { throw new NotSupportedException(); } set { } }
        [WirePath("token")]
        public string Token { get { throw new NotSupportedException(); } set { } }
        [WirePath("refreshToken")]
        public string RefreshToken { get { throw new NotSupportedException(); } set { } }
        [WirePath("scope")]
        public string Scope { get { throw new NotSupportedException(); } set { } }
        [WirePath("expiresIn")]
        public int? ExpireInSeconds { get { throw new NotSupportedException(); } set { } }
    }
}
