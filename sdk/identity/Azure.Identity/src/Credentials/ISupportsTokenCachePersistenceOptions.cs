// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity
{
    internal interface ISupportsTokenCachePersistenceOptions
    {
        /// <summary>
        /// The <see cref="TokenCachePersistenceOptions"/>.
        /// </summary>
        TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
}
