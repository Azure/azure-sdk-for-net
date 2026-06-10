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
    public partial class AdaptiveApplicationControlGroupData : ResourceData, IJsonModel<AdaptiveApplicationControlGroupData>, IPersistableModel<AdaptiveApplicationControlGroupData>
    {
        public AdaptiveApplicationControlGroupData() { }
        public SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public AdaptiveApplicationControlEnforcementMode? EnforcementMode { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public IReadOnlyList<AdaptiveApplicationControlIssueSummary> Issues { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public AzureLocation? Location { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public IList<PathRecommendation> PathRecommendations { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public SecurityCenterFileProtectionMode ProtectionMode { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public RecommendationStatus? RecommendationStatus { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public AdaptiveApplicationControlGroupSourceSystem? SourceSystem { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public IList<VmRecommendation> VmRecommendations { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveApplicationControlGroupData IJsonModel<AdaptiveApplicationControlGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AdaptiveApplicationControlGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveApplicationControlGroupData IPersistableModel<AdaptiveApplicationControlGroupData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AdaptiveApplicationControlGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<AdaptiveApplicationControlGroupData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
