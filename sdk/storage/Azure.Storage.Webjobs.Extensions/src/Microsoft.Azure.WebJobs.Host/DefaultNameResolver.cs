// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// An implementation of <see cref="INameResolver"/> that resolves tokens by looking first
    /// in App Settings and then in environment variables.
    /// </summary>
    public class DefaultNameResolver : INameResolver
    {
        private readonly IConfiguration _configuration;

        public DefaultNameResolver(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Resolves tokens by looking first in App Settings and then in environment variables.
        /// </summary>
        /// <param name="name">The token to resolve.</param>
        /// <returns>The token value from App Settings or environment variables. If the token is not found, null is returned.</returns>
        public virtual string Resolve(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            return _configuration[name];
        }
    }
}