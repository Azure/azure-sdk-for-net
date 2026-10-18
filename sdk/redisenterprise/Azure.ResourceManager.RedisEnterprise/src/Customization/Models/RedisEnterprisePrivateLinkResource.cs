// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RedisEnterprise.Models
{
    // The 1.3.0 stable package exposed this constructor publicly. Keep it so existing
    // applications can continue constructing the model, including for mocking and testing,
    // without introducing a source or binary compatibility break in 1.4.0.
    public partial class RedisEnterprisePrivateLinkResource
    {
        /// <summary> Initializes a new instance of <see cref="RedisEnterprisePrivateLinkResource"/>. </summary>
        public RedisEnterprisePrivateLinkResource()
        { }
    }
}
