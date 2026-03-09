// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Redis.Models
{
    public partial class RedisCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="RedisCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> The SKU of the Redis cache to deploy. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RedisCreateOrUpdateContent(AzureLocation location, RedisSku sku) : this(sku, location)
        {
        }
    }
}
