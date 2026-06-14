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
    public abstract partial class SecurityConnectorEnvironment : IPersistableModel<SecurityConnectorEnvironment>
    {
        protected SecurityConnectorEnvironment() : this(default(EnvironmentType)) { }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SecurityConnectorEnvironment>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SecurityConnectorEnvironment)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("environmentType"u8);
            writer.WriteStringValue(EnvironmentType.ToString());
        }
        SecurityConnectorEnvironment IJsonModel<SecurityConnectorEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { return JsonModelCreateCore(ref reader, options); }
        void IJsonModel<SecurityConnectorEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); }
        SecurityConnectorEnvironment IPersistableModel<SecurityConnectorEnvironment>.Create(BinaryData data, ModelReaderWriterOptions options) { return PersistableModelCreateCore(data, options); }
        string IPersistableModel<SecurityConnectorEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) { return "J"; }
        BinaryData IPersistableModel<SecurityConnectorEnvironment>.Write(ModelReaderWriterOptions options) { return PersistableModelWriteCore(options); }
    }
}
