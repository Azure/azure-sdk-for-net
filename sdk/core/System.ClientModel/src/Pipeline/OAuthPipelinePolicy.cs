// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// A policy that can be added to a <see cref="ClientPipeline"/> to perform OAuth2 authentication.
/// </summary>
public abstract class OAuthPipelinePolicy: PipelinePolicy
{
    /// <summary>
    /// Creates a new instance of <see cref="OAuthPipelinePolicy"/>.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public abstract OAuthPipelinePolicy CreateAuthenticationPolicy(IReadOnlyDictionary<string, object> context);

    /// <summary>
    /// Proposed: Gets the token using the context of the policy instance.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract ValueTask<Token> GetTokenAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Proposed: Gets the token using the context of the policy instance.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract Token GetToken(CancellationToken cancellationToken);
}
