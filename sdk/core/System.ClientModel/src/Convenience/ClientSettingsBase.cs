// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// .
/// </summary>
public class ClientSettingsBase
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="options"></param>
    public ClientSettingsBase(object options)
    {
        Options = options;
    }

    /// <summary>
    /// .
    /// </summary>
    public CredentialSettings? Credential { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public IConfigurationSection? Properties { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public object? CredentialObject { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public object Options { get; set; }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="section"></param>
    public void Read(IConfigurationSection section)
    {
        Initialized = true;
        Properties = section;
        Credential = new(section.GetRequiredSection("Credential"));
        ReadCore(section);
    }

    /// <summary>
    /// .
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public ClientConnection GetClientConnection()
    {
        if (!Initialized)
            throw new InvalidOperationException("Must call Read with an IConfigurationSection before converting to a ClientConnection");

        if (Credential is null)
            throw new InvalidOperationException("Credential section must exist in configuration");

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

        return ClientConnection.Create(Properties, credential, credentialKind);
    }

    /// <summary>
    /// .
    /// </summary>
    protected bool Initialized { get; private set; }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="section"></param>
    protected virtual void ReadCore(IConfigurationSection section) { }
}
