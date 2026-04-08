// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    public partial class ProfileData
    {
        /// <summary> Initializes a new instance of <see cref="ProfileData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The pricing tier (defines Azure Front Door Standard or Premium or a CDN provider, feature list and rate) of the profile. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public ProfileData(AzureLocation location, CdnSku sku) : base(location)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            Sku = sku;
        }
    }
}
