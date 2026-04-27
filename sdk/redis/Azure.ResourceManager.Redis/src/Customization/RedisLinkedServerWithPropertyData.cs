// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Redis.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis
{
    // Binary back-compat shim: the legacy SDK exposes LinkedRedisCacheLocation and
    // ServerRole as Nullable<T> on the data class. The MPG generator flattens them as
    // the underlying value type because they are required input properties on
    // RedisLinkedServerCreateProperties (same root cause as rc3 / #58288).
    //
    // We cannot use `@@alternateType(... | null, "csharp")` to widen these because the
    // same RedisLinkedServerCreateProperties is shared with the input model
    // RedisLinkedServerWithPropertyCreateOrUpdateContent, whose baseline contract
    // requires non-nullable getters and a 3-arg required ctor. Making the underlying
    // properties nullable breaks the input model's contract.
    //
    // TODO: delete this file once #58288 is fixed and the alpha emitter is bumped.
    public partial class RedisLinkedServerWithPropertyData
    {
        /// <summary> Location of the linked redis cache. </summary>
        [WirePath("properties.linkedRedisCacheLocation")]
        public AzureLocation? LinkedRedisCacheLocation
        {
            get => Properties?.LinkedRedisCacheLocation;
            set
            {
                if (value.HasValue)
                {
                    Properties.LinkedRedisCacheLocation = value.Value;
                }
            }
        }

        /// <summary> Role of the linked server. </summary>
        [WirePath("properties.serverRole")]
        public RedisLinkedServerRole? ServerRole
        {
            get => Properties?.ServerRole;
            set
            {
                if (value.HasValue)
                {
                    Properties.ServerRole = value.Value;
                }
            }
        }
    }
}
