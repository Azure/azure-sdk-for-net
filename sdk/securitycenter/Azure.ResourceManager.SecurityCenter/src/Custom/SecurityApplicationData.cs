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
    public partial class SecurityApplicationData : SecurityConnectorApplicationData, IJsonModel<SecurityApplicationData>, IPersistableModel<SecurityApplicationData>
    {
        public SecurityApplicationData() { }
        public new IList<BinaryData> ConditionSets { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public new string Description { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public new string DisplayName { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public new ApplicationSourceResourceType? SourceResourceType { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IJsonModel<SecurityApplicationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityApplicationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IPersistableModel<SecurityApplicationData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityApplicationData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<SecurityApplicationData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
