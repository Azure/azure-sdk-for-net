// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis.Models
{
    public partial class RedisPrivateLinkResource
    {
        // Back-compat: the legacy SDK exposed a public parameterless constructor
        // (api/Azure.ResourceManager.Redis.net10.0.cs:904). The MPG-generated class only
        // emits an internal constructor because the model has no settable input properties,
        // so without this customization ApiCompat fails with MembersMustExist on the ctor.
        /// <summary> Initializes a new instance of <see cref="RedisPrivateLinkResource"/>. </summary>
        public RedisPrivateLinkResource()
        {
        }
    }
}
