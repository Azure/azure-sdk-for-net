// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // Contextual wrapper: same wire shape as ApiData but with a distinct type name for
    // product API operations. The old SDK returned ProductApiData from product-specific
    // list/create endpoints. Not spec-fixable: TypeSpec has no concept of "same model,
    // different name per operation context."
    // Tracking: https://github.com/Azure/azure-sdk-for-net/issues/60083

    /// <summary> API data returned from product API operations. </summary>
    public partial class ProductApiData : ApiData, IJsonModel<ProductApiData>, IPersistableModel<ProductApiData>
    {
        /// <summary> Initializes a new instance of <see cref="ProductApiData"/>. </summary>
        public ProductApiData()
        {
        }

        internal ProductApiData(ApiData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        void IJsonModel<ProductApiData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ApiData>)this).Write(writer, options);

        ProductApiData IJsonModel<ProductApiData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ApiData data = ((IJsonModel<ApiData>)new ApiData()).Create(ref reader, options);
            return data is null ? null : new ProductApiData(data);
        }

        BinaryData IPersistableModel<ProductApiData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiData>)this).Write(options);

        ProductApiData IPersistableModel<ProductApiData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ApiData value = ((IPersistableModel<ApiData>)new ApiData()).Create(data, options);
            return value is null ? null : new ProductApiData(value);
        }

        string IPersistableModel<ProductApiData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiData>)new ApiData()).GetFormatFromOptions(options);
    }
}
