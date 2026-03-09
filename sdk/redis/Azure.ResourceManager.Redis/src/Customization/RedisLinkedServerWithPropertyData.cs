// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Redis.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis
{
    [CodeGenSuppress("RedisLinkedServerWithPropertyData")]
    public partial class RedisLinkedServerWithPropertyData
    {
        /// <summary> Initializes a new instance of <see cref="RedisLinkedServerWithPropertyData"/>. </summary>
        public RedisLinkedServerWithPropertyData()
        {
        }

        /// <summary> Fully qualified resourceId of the linked redis cache. </summary>
        [WirePath("properties.linkedRedisCacheId")]
        public ResourceIdentifier LinkedRedisCacheId
        {
            get => Properties.LinkedRedisCacheId;
            set => Properties.LinkedRedisCacheId = value;
        }

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
