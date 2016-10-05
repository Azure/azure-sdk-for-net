// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Redis
{


    /// <summary>
    /// The {@link RedisCache#keys} action result.
    /// </summary>
    public interface IRedisAccessKeys 
    {
        /// <returns>a primary key value.</returns>
        string PrimaryKey { get; }

        /// <returns>a secondary key value.</returns>
        string SecondaryKey { get; }

    }
}