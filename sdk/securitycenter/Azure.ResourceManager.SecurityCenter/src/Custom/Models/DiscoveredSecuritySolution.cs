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
        private AzureLocation? _location;
        private string _offer;
        private string _publisher;
        private SecurityFamily _securityFamily;
        private string _sku;

        public DiscoveredSecuritySolution(SecurityFamily securityFamily, string offer, string publisher, string sku)
        {
            _securityFamily = securityFamily;
            _offer = offer;
            _publisher = publisher;
            _sku = sku;
        }

        internal DiscoveredSecuritySolution(DiscoveredSecuritySolutionData data)
            : this(data.SecurityFamily, data.Offer, data.Publisher, data.Sku)
        {
            _location = data.Location is null ? default(AzureLocation?) : new AzureLocation(data.Location);
        }

        public AzureLocation? Location { get => _location; }
        public string Offer { get => _offer; set => _offer = value; }
        public string Publisher { get => _publisher; set => _publisher = value; }
        public SecurityFamily SecurityFamily { get => _securityFamily; set => _securityFamily = value; }
        public string Sku { get => _sku; set => _sku = value; }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DiscoveredSecuritySolution IJsonModel<DiscoveredSecuritySolution>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<DiscoveredSecuritySolution>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DiscoveredSecuritySolution IPersistableModel<DiscoveredSecuritySolution>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<DiscoveredSecuritySolution>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<DiscoveredSecuritySolution>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
