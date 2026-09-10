// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // Contextual wrapper: same wire shape as ApiManagementGroupData but with a distinct
    // type name for product group operations. The old SDK returned ProductGroupData from
    // product-specific group endpoints. Not spec-fixable: TypeSpec has no concept of
    // "same model, different name per operation context."
    // Tracking: https://github.com/Azure/azure-sdk-for-net/issues/60083

    /// <summary> Group data returned from product group operations. </summary>
    public partial class ProductGroupData : ApiManagementGroupData, IJsonModel<ProductGroupData>, IPersistableModel<ProductGroupData>
    {
        /// <summary> Initializes a new instance of <see cref="ProductGroupData"/>. </summary>
        public ProductGroupData()
        {
        }

        internal ProductGroupData(ApiManagementGroupData data)
            : base(data.Id, data.Name, data.ResourceType, data.SystemData, data.Properties, default)
        {
        }

        void IJsonModel<ProductGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ApiManagementGroupData>)this).Write(writer, options);

        ProductGroupData IJsonModel<ProductGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ApiManagementGroupData data = ((IJsonModel<ApiManagementGroupData>)new ApiManagementGroupData()).Create(ref reader, options);
            return data is null ? null : new ProductGroupData(data);
        }

        BinaryData IPersistableModel<ProductGroupData>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiManagementGroupData>)this).Write(options);

        ProductGroupData IPersistableModel<ProductGroupData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ApiManagementGroupData value = ((IPersistableModel<ApiManagementGroupData>)new ApiManagementGroupData()).Create(data, options);
            return value is null ? null : new ProductGroupData(value);
        }

        string IPersistableModel<ProductGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ApiManagementGroupData>)new ApiManagementGroupData()).GetFormatFromOptions(options);
    }
}
