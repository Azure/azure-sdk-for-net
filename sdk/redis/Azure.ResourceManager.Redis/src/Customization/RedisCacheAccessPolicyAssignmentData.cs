// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Redis.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis
{
    [CodeGenSuppress("ObjectId")]
    public partial class RedisCacheAccessPolicyAssignmentData
    {
        /// <summary> Object Id to assign access policy to. </summary>
        [WirePath("properties.objectId")]
        public Guid? ObjectId
        {
            get
            {
                return Properties is null ? default(Guid?) : Properties.ObjectId;
            }
            set
            {
                if (value.HasValue)
                {
                    if (Properties is null)
                    {
                        Properties = new RedisCacheAccessPolicyAssignmentProperties();
                    }
                    Properties.ObjectId = value.Value;
                }
            }
        }
    }
}
