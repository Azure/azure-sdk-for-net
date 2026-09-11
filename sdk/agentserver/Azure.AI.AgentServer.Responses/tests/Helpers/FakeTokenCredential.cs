// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// A no-op <see cref="TokenCredential"/> for hosted-registration tests. It is never invoked —
/// hosted tests exercise the task-invoker / registration / composition paths, not a real storage
/// call — so it throws if a token is ever requested to surface an unexpected network dependency.
/// </summary>
internal sealed class FakeTokenCredential : TokenCredential
{
    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        => throw new NotSupportedException("FakeTokenCredential must not be used to fetch a real token in tests.");

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        => throw new NotSupportedException("FakeTokenCredential must not be used to fetch a real token in tests.");
}
