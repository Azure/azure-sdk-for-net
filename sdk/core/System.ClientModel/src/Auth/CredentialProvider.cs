// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Represents a provider that can provide a credential.
/// </summary>
public abstract class CredentialProvider
{
    /// <summary>
    /// Gets the credential.
    /// </summary>
    /// <param name="context">I don't ;ove this dictionary param, but I'm not sure if there is a better way to handle an implementation agnostic bag of context to the credential. </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract ValueTask<Credential> GetCredentialAsync(IReadOnlyDictionary<string, object> context, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the credential.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract Credential GetCredential(IReadOnlyDictionary<string, object> context, CancellationToken cancellationToken);
}
