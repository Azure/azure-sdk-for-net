// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel;

/// <summary>
/// Represents a provider that can provide a token.
/// </summary>
public interface IOauthPolicyFactory
{
    /// <summary>
    /// Additional claims to be included in the token.
    /// </summary>
    OAuthPipelinePolicy CreateAuthenticationPolicy(IReadOnlyDictionary<string, object> context);
}
