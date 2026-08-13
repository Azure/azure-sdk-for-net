// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementServiceData
    {
        // Old SDK constructor had parameter order (location, sku, publisherEmail, publisherName).
        // New generator emits (location, publisherEmail, publisherName, sku).
        // This overload preserves the old signature for binary compat.

        /// <summary> Initializes a new instance of <see cref="ApiManagementServiceData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> SKU properties of the API Management service. </param>
        /// <param name="publisherEmail"> Publisher email. </param>
        /// <param name="publisherName"> Publisher name. </param>
        public ApiManagementServiceData(AzureLocation location, ApiManagementServiceSkuProperties sku, string publisherEmail, string publisherName)
            : this(location, publisherEmail, publisherName, sku)
        {
        }
    }
}
