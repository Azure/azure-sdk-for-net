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
    public partial class DiscoveredSecuritySolution : ResourceData, IJsonModel<DiscoveredSecuritySolution>, IPersistableModel<DiscoveredSecuritySolution>
    {
        public DiscoveredSecuritySolution(SecurityFamily securityFamily, string offer, string publisher, string sku) { }
        public AzureLocation? Location { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string Offer { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string Publisher { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public SecurityFamily SecurityFamily { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public string Sku { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DiscoveredSecuritySolution IJsonModel<DiscoveredSecuritySolution>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<DiscoveredSecuritySolution>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DiscoveredSecuritySolution IPersistableModel<DiscoveredSecuritySolution>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<DiscoveredSecuritySolution>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<DiscoveredSecuritySolution>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
