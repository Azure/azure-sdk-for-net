// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The previous GA SDK generated this legacy AutoRest support type from older Security swagger.
    // Current TypeSpec either emits the updated resource/model name or no longer includes that
    // legacy schema, so this hidden obsolete shim is retained only for ApiCompat.
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityTopologyResource : ResourceData, IJsonModel<SecurityTopologyResource>, IPersistableModel<SecurityTopologyResource>
    {
        public SecurityTopologyResource() { }
        public DateTimeOffset? CalculatedOn { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public AzureLocation? Location { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public IReadOnlyList<TopologySingleResource> TopologyResources { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityTopologyResource IJsonModel<SecurityTopologyResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityTopologyResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityTopologyResource IPersistableModel<SecurityTopologyResource>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityTopologyResource>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<SecurityTopologyResource>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
