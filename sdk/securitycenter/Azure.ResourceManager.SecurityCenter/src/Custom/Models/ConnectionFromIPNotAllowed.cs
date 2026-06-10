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
    // The previous GA SDK exposed this concrete alert-rule discriminator type, but SDK properties
    // used the broader AllowlistCustomAlertRule bucket type. The TypeSpec generator now emits
    // only the bucket type, so this hidden obsolete shim is retained only for ApiCompat.
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConnectionFromIPNotAllowed : AllowlistCustomAlertRule, IJsonModel<ConnectionFromIPNotAllowed>, IPersistableModel<ConnectionFromIPNotAllowed>
    {
        public ConnectionFromIPNotAllowed(bool isEnabled, IEnumerable<string> allowlistValues) : base(default(bool), default(IEnumerable<string>)) { }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        ConnectionFromIPNotAllowed IJsonModel<ConnectionFromIPNotAllowed>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<ConnectionFromIPNotAllowed>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        ConnectionFromIPNotAllowed IPersistableModel<ConnectionFromIPNotAllowed>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<ConnectionFromIPNotAllowed>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<ConnectionFromIPNotAllowed>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
