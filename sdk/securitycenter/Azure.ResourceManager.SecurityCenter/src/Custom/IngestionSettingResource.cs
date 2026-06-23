// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> Provides a compatibility shim for the IngestionSettingResource class. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class IngestionSettingResource : ArmResource, System.ClientModel.Primitives.IJsonModel<IngestionSettingData>, System.ClientModel.Primitives.IPersistableModel<IngestionSettingData>
    {
        /// <summary> Gets the resource type. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Security/ingestionSettings";

        /// <summary> Initializes a new instance of <see cref="IngestionSettingResource"/>. </summary>
        protected IngestionSettingResource()
        {
        }

        internal IngestionSettingResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData { get; } = true;

        /// <summary> Gets the resource data. </summary>
        public virtual IngestionSettingData Data { get; } = new IngestionSettingData();

        /// <summary> Creates a resource identifier. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ingestionSettingName)
        {
            return new ResourceIdentifier($"/subscriptions/{subscriptionId}/providers/Microsoft.Security/ingestionSettings/{ingestionSettingName}");
        }

        /// <summary> Gets the ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual Azure.Response<IngestionSettingResource> Get(System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets the ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<IngestionSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Deletes the ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual ArmOperation Delete(WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Deletes the ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual System.Threading.Tasks.Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Updates the ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual ArmOperation<IngestionSettingResource> Update(WaitUntil waitUntil, IngestionSettingData data, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Updates the ingestion setting. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual System.Threading.Tasks.Task<ArmOperation<IngestionSettingResource>> UpdateAsync(WaitUntil waitUntil, IngestionSettingData data, System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets the ingestion setting connection strings. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual Azure.Pageable<IngestionConnectionString> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets the ingestion setting connection strings. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual Azure.AsyncPageable<IngestionConnectionString> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets the ingestion setting tokens. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual Azure.Response<IngestionSettingToken> GetTokens(System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        /// <summary> Gets the ingestion setting tokens. </summary>
        [System.Obsolete("This API is no longer supported by the service.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<IngestionSettingToken>> GetTokensAsync(System.Threading.CancellationToken cancellationToken = default) { throw new System.NotSupportedException("This API is no longer supported by the service."); }

        IngestionSettingData System.ClientModel.Primitives.IJsonModel<IngestionSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) => new IngestionSettingData();
        void System.ClientModel.Primitives.IJsonModel<IngestionSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        IngestionSettingData System.ClientModel.Primitives.IPersistableModel<IngestionSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) => new IngestionSettingData();
        string System.ClientModel.Primitives.IPersistableModel<IngestionSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) => "J";
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<IngestionSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) => System.BinaryData.FromString("{}");
    }
}
