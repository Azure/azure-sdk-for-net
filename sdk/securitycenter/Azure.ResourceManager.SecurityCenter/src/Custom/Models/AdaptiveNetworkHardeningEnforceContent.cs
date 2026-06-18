// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningEnforceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>
    {
        public AdaptiveNetworkHardeningEnforceContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule> rules, System.Collections.Generic.IEnumerable<string> networkSecurityGroups) { }
        public System.Collections.Generic.IList<string> NetworkSecurityGroups { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule> Rules { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
