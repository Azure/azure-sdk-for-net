// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Redis.Models
{
    public partial class RedisCreateOrUpdateContent
    {
        // n3 review-comment: backward-compat ctor for API parity.
        // The baseline (Azure.ResourceManager.Redis 1.5.x) shipped this ctor as
        // (AzureLocation, RedisSku); the new TypeSpec-generated ctor is (RedisSku, AzureLocation)
        // because the generator orders parameters by the underlying model's required-property
        // order (sku first in models.tsp, then location from Foundations.Resource). Reordering
        // the spec to flip this would either require breaking the model layout or adding a
        // language-specific argument-reordering hook that the emitter does not currently expose.
        // Keep this overload to preserve source-compat; mark it [Obsolete] so callers move to
        // the canonical ctor.
        /// <summary> Initializes a new instance of <see cref="RedisCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> The SKU of the Redis cache to deploy. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is preserved for backward compatibility. Use the (RedisSku, AzureLocation) constructor instead.", false)]
        public RedisCreateOrUpdateContent(AzureLocation location, RedisSku sku) : this(sku, location)
        {
        }
    }
}
