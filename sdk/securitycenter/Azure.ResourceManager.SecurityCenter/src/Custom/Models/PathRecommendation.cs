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
    public partial class PathRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>
    {
        public PathRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? Action { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType? FileType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType? IotSecurityRecommendationType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool? IsCommon { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Path { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo PublisherInfo { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation> Usernames { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<string> UserSids { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.PathRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.PathRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
