// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Redis.Fluent.Models;

    internal partial class RedisAccessKeysImpl 
    {
        /// <summary>
        /// Gets a secondary key value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys.SecondaryKey
        {
            get
            {
                return this.SecondaryKey();
            }
        }

        /// <summary>
        /// Gets a primary key value.
        /// </summary>
        string Microsoft.Azure.Management.Redis.Fluent.IRedisAccessKeys.PrimaryKey
        {
            get
            {
                return this.PrimaryKey();
            }
        }
    }
}