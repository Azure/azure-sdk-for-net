// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Models;

    internal class RedisAccessKeysImpl : IRedisAccessKeys
    {
        private RedisAccessKeysInner inner;

        internal RedisAccessKeysImpl(RedisAccessKeysInner inner)
        {
            this.inner = inner;
        }

        public string PrimaryKey
        {
            get
            {
                return this.inner.PrimaryKey;
            }
        }

        public string SecondaryKey
        {
            get
            {
                return this.inner.SecondaryKey;
            }
        }
    }
}