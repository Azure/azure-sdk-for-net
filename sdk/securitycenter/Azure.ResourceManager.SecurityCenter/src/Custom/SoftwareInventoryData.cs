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

namespace Azure.ResourceManager.SecurityCenter
{
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SoftwareInventoryData : ResourceData, IJsonModel<SoftwareInventoryData>, IPersistableModel<SoftwareInventoryData>
    {
        public SoftwareInventoryData() { }
        public string DeviceId { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string EndOfSupportDate { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public EndOfSupportStatus? EndOfSupportStatus { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public DateTimeOffset? FirstSeenOn { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public int? NumberOfKnownVulnerabilities { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string OSPlatform { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string SoftwareName { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string Vendor { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string Version { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SoftwareInventoryData IJsonModel<SoftwareInventoryData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SoftwareInventoryData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SoftwareInventoryData IPersistableModel<SoftwareInventoryData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SoftwareInventoryData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<SoftwareInventoryData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
