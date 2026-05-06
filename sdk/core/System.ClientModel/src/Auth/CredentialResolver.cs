// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Plug-in point for resolving an <see cref="AuthenticationTokenProvider"/> from
/// an <see cref="IConfigurationSection"/> that describes a credential. Credential
/// libraries derive from this class and ship a typed
/// <c>Add{Brand}CredentialResolver()</c> registration extension.
/// </summary>
[Experimental("SCME0002")]
public abstract class CredentialResolver
{
    /// <summary>
    /// Attempts to construct an <see cref="AuthenticationTokenProvider"/> for
    /// the supplied credential configuration section.
    /// </summary>
    /// <param name="credentialSection">The credential configuration section
    /// (post-overlay if any overrides were applied by the caller).</param>
    /// <param name="provider">When this method returns <see langword="true"/>,
    /// contains the constructed provider; otherwise <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if this resolver recognized and handled
    /// the section; <see langword="false"/> to defer to the next resolver in the
    /// chain.</returns>
    public abstract bool TryResolve(
        IConfigurationSection credentialSection,
        [NotNullWhen(true)] out AuthenticationTokenProvider? provider);
}
