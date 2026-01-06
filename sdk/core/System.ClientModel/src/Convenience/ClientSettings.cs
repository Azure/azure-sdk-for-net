// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
public class ClientSettings
{
    /// <summary>
    /// .
    /// </summary>
    public CredentialSettings? CredentialSettings { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public IConfigurationSection? Configuration { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public object? Credential { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public object? Options { get; set; }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="section"></param>
    public void Read(IConfigurationSection section)
    {
        IsInitialized = true;
        Configuration = section;
        CredentialSettings = new(section.GetRequiredSection("Credential"));
        ReadCore(section);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public ClientConnection GetClientConnection()
    {
        if (!IsInitialized)
            throw new InvalidOperationException("Must call Read with an IConfigurationSection before converting to a ClientConnection");

        if (CredentialSettings is null)
            throw new InvalidOperationException("Credential section must exist in configuration");

        object credential;
        CredentialKind credentialKind = CredentialSettings?.CredentialSource == "ApiKey" ? CredentialKind.ApiKeyString : CredentialKind.TokenCredential;
        if (Credential is null)
        {
            if (CredentialSettings?.CredentialSource == "ApiKey")
            {
                credential = CredentialSettings!.Key!;
            }
            else
            {
                throw new InvalidOperationException("CredentialObject must be provided when CredentialSource is not ApiKey.");
            }
        }
        else
        {
            credential = Credential;
        }

        return ClientConnection.Create(Configuration, credential, credentialKind);
    }

    /// <summary>
    /// .
    /// </summary>
    protected bool IsInitialized { get; private set; }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="section"></param>
    protected virtual void ReadCore(IConfigurationSection section) { }
}
