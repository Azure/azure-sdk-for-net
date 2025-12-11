// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

/// <summary>
/// .
/// </summary>
public abstract class ClientSettings : ClientSettingsBase
{
    /// <summary>
    /// .
    /// </summary>
    public ClientPipelineOptions ClientOptions { get; set; } = ClientPipelineOptions.Default;

    /// <inheritdoc/>
    protected override ClientConnection GetClientConnectionCore()
    {
        object credential;
        CredentialKind credentialKind = Credential?.CredentialSource == "ApiKey" ? CredentialKind.ApiKeyString : CredentialKind.TokenCredential;
        if (CredentialObject is null)
        {
            if (Credential?.CredentialSource == "ApiKey")
            {
                credential = Credential!.Key!;
            }
            else
            {
                throw new InvalidOperationException("CredentialObject must be provided when CredentialSource is not ApiKey.");
            }
        }
        else
        {
            credential = CredentialObject;
        }

        if (Properties is null)
        {
            return new(Guid.NewGuid().ToString(), null, credential, credentialKind);
        }
        else
        {
            return new(Properties.Key, Properties["Endpoint"], credential, credentialKind, Properties);
        }
    }
}
