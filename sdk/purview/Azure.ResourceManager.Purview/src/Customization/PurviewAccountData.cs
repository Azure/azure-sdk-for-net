// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Purview.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Purview
{
    // Old API returned PurviewAccountEndpoint and PurviewManagedResource;
    // new generator creates derived types AccountPropertiesEndpoints/AccountPropertiesManagedResources
    // from property flattening. Suppress and re-expose with base types for backward compatibility.
    public partial class PurviewAccountData
    {
        /// <summary> The URIs that are the public endpoints of the account. </summary>
        public PurviewAccountEndpoint Endpoints => Properties is null ? default : Properties.Endpoints;

        /// <summary> Gets the resource identifiers of the managed resources. </summary>
        public PurviewManagedResource ManagedResources => Properties is null ? default : Properties.ManagedResources;
    }
}
