// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Models;

    /// <summary>
    /// The RedisCache.keys action result.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlZGlzLmltcGxlbWVudGF0aW9uLlJlZGlzQWNjZXNzS2V5c0ltcGw=
    internal partial class RedisAccessKeysImpl : IRedisAccessKeys
    {
        private RedisAccessKeysInner inner;

        ///GENMHASH:052932D87146B729CFA163215691D8ED:B906418BFAF9A0252DDBFB702ABE2774
        public string SecondaryKey
        {
            get
            {
                return this.inner.SecondaryKey;
            }
        }

        /// <summary>
        /// Creates an instance of the Redis Access keys result object.
        /// </summary>
        /// <param name="inner">The inner object.</param>
        ///GENMHASH:C452582DCEC9B97DA6C301BBFC245AB7:BC4B1282CA708DC220050F834F17A184
        internal  RedisAccessKeysImpl(RedisAccessKeysInner inner)
        {
            this.inner = inner;
        }

        ///GENMHASH:0B1F8FBCA0C4DFB5EA228CACB374C6C2:EF4A3D6252BFD28784D9F9BED7CEA1C0
        public string PrimaryKey
        {
            get
            {
                return this.inner.PrimaryKey;
            }
        }
    }
}
