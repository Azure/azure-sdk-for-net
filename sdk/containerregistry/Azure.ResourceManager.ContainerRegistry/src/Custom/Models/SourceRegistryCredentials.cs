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
    public partial class SourceRegistryCredentials : IJsonModel<SourceRegistryCredentials>, IPersistableModel<SourceRegistryCredentials>
    {
        SourceRegistryCredentials IJsonModel<SourceRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException();
        void IJsonModel<SourceRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        BinaryData IPersistableModel<SourceRegistryCredentials>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException();
        SourceRegistryCredentials IPersistableModel<SourceRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException();
        string IPersistableModel<SourceRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException();
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        /// <summary>
        /// The Entra identity used for source registry login.
        /// The value is `[system]` for system-assigned managed identity, `[caller]` for caller identity,
        /// and client ID for user-assigned managed identity.
        /// </summary>
        [WirePath("identity")]
        public string Identity { get { throw new NotSupportedException(); } set { } }
        /// <summary>
        /// The authentication mode which determines the source registry login scope.
        /// </summary>
        [WirePath("loginMode")]
        public SourceRegistryLoginMode? LoginMode { get { throw new NotSupportedException(); } set { } }
    }
}
