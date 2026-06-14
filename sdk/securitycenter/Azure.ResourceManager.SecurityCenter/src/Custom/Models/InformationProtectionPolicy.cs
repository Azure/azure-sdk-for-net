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
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class InformationProtectionPolicy : ResourceData, IJsonModel<InformationProtectionPolicy>, IPersistableModel<InformationProtectionPolicy>
    {
        public InformationProtectionPolicy() { }
        public IDictionary<string, SecurityInformationTypeInfo> InformationTypes { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public IDictionary<string, SensitivityLabel> Labels { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public DateTimeOffset? LastModifiedUtc { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string Version { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        InformationProtectionPolicy IJsonModel<InformationProtectionPolicy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<InformationProtectionPolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        InformationProtectionPolicy IPersistableModel<InformationProtectionPolicy>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<InformationProtectionPolicy>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<InformationProtectionPolicy>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
