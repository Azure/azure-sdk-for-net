// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // Contextual wrapper: same wire shape as ApiData but with a distinct type name for
    // gateway API operations. The old SDK returned GatewayApiData from gateway-specific
    // list/create endpoints. Not spec-fixable: TypeSpec has no concept of "same model,
    // different name per operation context."
    // Tracking: https://github.com/Azure/azure-sdk-for-net/issues/60083

    /// <summary> API data returned from gateway API operations. </summary>
    public partial class GatewayApiData : ApiData, IJsonModel<GatewayApiData>, IPersistableModel<GatewayApiData>
    {
        /// <summary> Initializes a new instance of <see cref="GatewayApiData"/>. </summary>
        public GatewayApiData()
        {
        }

        internal GatewayApiData(ApiData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        void IJsonModel<GatewayApiData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ApiData>)this).Write(writer, options);

        GatewayApiData IJsonModel<GatewayApiData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ApiData data = ((IJsonModel<ApiData>)new ApiData()).Create(ref reader, options);
            return data is null ? null : new GatewayApiData(data);
        }

        BinaryData IPersistableModel<GatewayApiData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiData>)this).Write(options);

        GatewayApiData IPersistableModel<GatewayApiData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ApiData value = ((IPersistableModel<ApiData>)new ApiData()).Create(data, options);
            return value is null ? null : new GatewayApiData(value);
        }

        string IPersistableModel<GatewayApiData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiData>)new ApiData()).GetFormatFromOptions(options);
    }
}
