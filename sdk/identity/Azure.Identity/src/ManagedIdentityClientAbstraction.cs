// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal abstract class ManagedIdentityClientAbstraction
    {
        public abstract Task<MsiType> GetMsiTypeAsync(CancellationToken cancellationToken);

        public abstract MsiType GetMsiType(CancellationToken cancellationToken);

        public abstract Task<AccessToken> AuthenticateAsync(MsiType msiType, string[] scopes, string clientId, CancellationToken cancellationToken);

        public abstract AccessToken Authenticate(MsiType msiType, string[] scopes, string clientId, CancellationToken cancellationToken);
    }
}
