// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiResource
    {
        private static readonly ResourceType ResourceTypeWithGateway = "Microsoft.ApiManagement/service/gateways/apis";

        private static readonly ResourceType ResourceTypeWithProduct = "Microsoft.ApiManagement/service/products/apis";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType || id.ResourceType != ResourceTypeWithGateway || id.ResourceType != ResourceTypeWithProduct)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }
    }
}
