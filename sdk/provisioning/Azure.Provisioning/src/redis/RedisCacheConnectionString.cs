// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Redis
{
    /// <summary>
    /// Represents a connection string.
    /// </summary>
    public class RedisCacheConnectionString : ConnectionString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RedisCacheConnectionString"/>.
        /// </summary>
        /// <param name="cache">The redis cache.</param>
        /// <param name="password">The password.</param>
        public RedisCacheConnectionString(RedisCache cache, Parameter password)
        : base($"${{{cache.Name}.properties.hostName}},ssl=true,password=${{{(password.IsFromOutput ? password.Value : password.Name)}}}")
        {
        }
    }
}
