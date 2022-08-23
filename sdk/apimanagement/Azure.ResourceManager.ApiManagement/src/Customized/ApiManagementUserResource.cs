// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementUserResource
    {
        private static readonly ResourceType ResourceTypeWithGroup = "Microsoft.ApiManagement/service/groups/users";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType || id.ResourceType != ResourceTypeWithGroup)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }
    }
}
