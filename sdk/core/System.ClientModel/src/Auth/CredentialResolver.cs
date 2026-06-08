// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using System.ClientModel.Internal;

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

    /// <summary>
    /// Attempts to construct an <see cref="AuthenticationTokenProvider"/> for
    /// the supplied credential configuration section, with access to a callback
    /// that recursively resolves child sections through the same active resolver
    /// chain.
    /// </summary>
    /// <param name="credentialSection">The credential configuration section
    /// (post-overlay if any overrides were applied by the caller).</param>
    /// <param name="resolveChild">A callback that resolves a child
    /// <see cref="IConfigurationSection"/> through the active resolver chain
    /// (including caching, normalization, and ordering). Returns the resolved
    /// <see cref="AuthenticationTokenProvider"/>, or <see langword="null"/> if
    /// no resolver in the chain claims the child section. Always non-null;
    /// resolvers that do not need the chain can ignore the callback.
    /// Must only be invoked synchronously during this call. The engine
    /// classifies a resolver as chain-dependent by observing whether
    /// <paramref name="resolveChild"/> is invoked here; capturing the
    /// callback and invoking it after <c>TryResolve</c> returns will throw
    /// <see cref="InvalidOperationException"/>.</param>
    /// <param name="provider">When this method returns <see langword="true"/>,
    /// contains the constructed provider; otherwise <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if this resolver recognized and handled
    /// the section; <see langword="false"/> to defer to the next resolver in the
    /// chain.</returns>
    /// <remarks>
    /// This overload exists so chain-owning resolvers (e.g., a resolver that
    /// builds a <c>ChainedTokenCredential</c> from child <c>Sources[]</c>
    /// entries) can recurse back into the active engine for each child entry
    /// without re-implementing the engine's caching, normalization, or
    /// ordering logic — and without requiring the resolver to know about
    /// credential sources owned by other packages. The default implementation
    /// ignores <paramref name="resolveChild"/> and forwards to
    /// <see cref="TryResolve(IConfigurationSection, out AuthenticationTokenProvider?)"/>,
    /// so existing resolvers continue to work unchanged.
    /// </remarks>
    public virtual bool TryResolve(
        IConfigurationSection credentialSection,
        Func<IConfigurationSection, AuthenticationTokenProvider?> resolveChild,
        [NotNullWhen(true)] out AuthenticationTokenProvider? provider)
    {
        Argument.AssertNotNull(resolveChild, nameof(resolveChild));
        return TryResolve(credentialSection, out provider);
    }
}
