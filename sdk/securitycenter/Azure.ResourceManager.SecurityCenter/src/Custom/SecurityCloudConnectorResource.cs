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
    public partial class SecurityCloudConnectorResource : ArmResource, IJsonModel<SecurityCloudConnectorData>, IPersistableModel<SecurityCloudConnectorData>
    {
        public static readonly ResourceType ResourceType;
        protected SecurityCloudConnectorResource() { }
        public virtual SecurityCloudConnectorData Data { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string connectorName) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<SecurityCloudConnectorResource> Get(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<SecurityCloudConnectorResource>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        SecurityCloudConnectorData IJsonModel<SecurityCloudConnectorData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityCloudConnectorData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityCloudConnectorData IPersistableModel<SecurityCloudConnectorData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityCloudConnectorData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<SecurityCloudConnectorData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual ArmOperation<SecurityCloudConnectorResource> Update(WaitUntil waitUntil, SecurityCloudConnectorData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation<SecurityCloudConnectorResource>> UpdateAsync(WaitUntil waitUntil, SecurityCloudConnectorData data, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
