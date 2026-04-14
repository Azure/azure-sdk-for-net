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
        /// Specifies the <see cref="TokenCachePersistenceOptions"/> to be used by the credential. If no options are specified, the token cache will not be persisted to disk.
        /// </summary>
        TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
    }
}
