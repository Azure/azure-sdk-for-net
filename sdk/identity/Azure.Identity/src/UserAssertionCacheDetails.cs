﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    /// <summary>
    /// Details related to a <see cref="UserAssertionScope"/> cache delegate.
    /// </summary>
    public struct UserAssertionCacheDetails
    {
        /// <summary>
        /// The bytes representing the state of the token cache.
        /// </summary>
        public ReadOnlyMemory<byte> CacheBytes { get; set; }
    }
}
