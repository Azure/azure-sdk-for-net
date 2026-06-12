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
    public partial class SecuritySolution : ResourceData, IJsonModel<SecuritySolution>, IPersistableModel<SecuritySolution>
    {
        private AzureLocation? _location;
        private string _protectionStatus;
        private SecurityFamilyProvisioningState? _provisioningState;
        private SecurityFamily? _securityFamily;
        private string _template;

        public SecuritySolution() { }

        internal SecuritySolution(SecuritySolutionData data)
        {
            _location = data.Location is null ? default(AzureLocation?) : new AzureLocation(data.Location);
            _protectionStatus = data.ProtectionStatus;
            _securityFamily = data.SecurityFamily;
            _template = data.Template;
        }

        public AzureLocation? Location { get => _location; }
        public string ProtectionStatus { get => _protectionStatus; set => _protectionStatus = value; }
        public SecurityFamilyProvisioningState? ProvisioningState { get => _provisioningState; set => _provisioningState = value; }
        public SecurityFamily? SecurityFamily { get => _securityFamily; set => _securityFamily = value; }
        public string Template { get => _template; set => _template = value; }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecuritySolution IJsonModel<SecuritySolution>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecuritySolution>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecuritySolution IPersistableModel<SecuritySolution>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecuritySolution>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<SecuritySolution>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
