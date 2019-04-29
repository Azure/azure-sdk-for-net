// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Credentials
{
    /// <summary>
    /// Represents a credential capable of providing an OAuth token 
    /// </summary>
    public abstract class TokenCredential
    {
        public abstract ValueTask<string> GetTokenAsync(IEnumerable<string> scopes, CancellationToken cancellationToken);
    }
}
