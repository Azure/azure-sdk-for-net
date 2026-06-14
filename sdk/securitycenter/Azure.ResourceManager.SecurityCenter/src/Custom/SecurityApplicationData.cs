// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shims do not need public docs.

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
    // The previous GA SDK generated this legacy AutoRest support type from older Security swagger.
    // Current TypeSpec either emits the updated resource/model name or no longer includes that
    // legacy schema, so this hidden shim is retained only for ApiCompat.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityApplicationData : SecurityConnectorApplicationData, IJsonModel<SecurityApplicationData>, IPersistableModel<SecurityApplicationData>
    {
        public SecurityApplicationData() { }

        internal SecurityApplicationData(SecurityConnectorApplicationData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        public new IList<BinaryData> ConditionSets => base.ConditionSets;
        public new string Description { get => base.Description; set => base.Description = value; }
        public new string DisplayName { get => base.DisplayName; set => base.DisplayName = value; }
        public new ApplicationSourceResourceType? SourceResourceType { get => base.SourceResourceType; set => base.SourceResourceType = value; }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IJsonModel<SecurityApplicationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityApplicationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IPersistableModel<SecurityApplicationData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityApplicationData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<SecurityApplicationData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
