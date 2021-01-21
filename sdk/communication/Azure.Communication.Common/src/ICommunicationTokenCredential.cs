// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Communication
{
    internal interface ICommunicationTokenCredential : IDisposable
    {
        AccessToken GetToken(CancellationToken cancellationToken);
        ValueTask<AccessToken> GetTokenAsync(CancellationToken cancellationToken);
    }
}
