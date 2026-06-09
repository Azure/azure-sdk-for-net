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
using Azure.ResourceManager.SecurityCenter.Models;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
[Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningData : ResourceData, IJsonModel<AdaptiveNetworkHardeningData>, IPersistableModel<AdaptiveNetworkHardeningData>
    {
        public AdaptiveNetworkHardeningData() { }
        public IList<EffectiveNetworkSecurityGroups> EffectiveNetworkSecurityGroups { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public IList<RecommendedSecurityRule> Rules { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public DateTimeOffset? RulesCalculatedOn { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveNetworkHardeningData IJsonModel<AdaptiveNetworkHardeningData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AdaptiveNetworkHardeningData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveNetworkHardeningData IPersistableModel<AdaptiveNetworkHardeningData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AdaptiveNetworkHardeningData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<AdaptiveNetworkHardeningData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
