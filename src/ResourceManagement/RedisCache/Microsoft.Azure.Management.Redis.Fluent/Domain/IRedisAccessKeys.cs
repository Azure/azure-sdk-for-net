// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Redis.Fluent
{
    /// <summary>
    /// The <code>RedisCache.keys()</code> action result.
    /// </summary>
    public interface IRedisAccessKeys 
    {
        /// <summary>
        /// Gets a secondary key value.
        /// </summary>
        string SecondaryKey { get; }

        /// <summary>
        /// Gets a primary key value.
        /// </summary>
        string PrimaryKey { get; }
    }
}