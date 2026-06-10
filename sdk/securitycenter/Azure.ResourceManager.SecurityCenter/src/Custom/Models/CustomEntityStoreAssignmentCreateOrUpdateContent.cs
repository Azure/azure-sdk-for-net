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
    // The previous GA SDK generated this from customEntityStoreAssignment swagger. That API was
    // removed from the spec before the TypeSpec migration, so this hidden obsolete shim is
    // retained only for ApiCompat.
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CustomEntityStoreAssignmentCreateOrUpdateContent : IJsonModel<CustomEntityStoreAssignmentCreateOrUpdateContent>, IPersistableModel<CustomEntityStoreAssignmentCreateOrUpdateContent>
    {
        public CustomEntityStoreAssignmentCreateOrUpdateContent() { }
        public string Principal { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        CustomEntityStoreAssignmentCreateOrUpdateContent IJsonModel<CustomEntityStoreAssignmentCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<CustomEntityStoreAssignmentCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        CustomEntityStoreAssignmentCreateOrUpdateContent IPersistableModel<CustomEntityStoreAssignmentCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<CustomEntityStoreAssignmentCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<CustomEntityStoreAssignmentCreateOrUpdateContent>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
