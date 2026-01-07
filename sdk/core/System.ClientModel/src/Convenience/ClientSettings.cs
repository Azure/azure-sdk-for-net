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
    public CredentialSettings? Credential { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public object? CredentialObject { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public object? Options { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public void Bind(IConfigurationSection? section = null)
    {
        IsInitialized = true;
        if (Credential is null && section is not null)
        {
            Credential = new CredentialSettings(section.GetSection("Credential"));
        }

        if (CredentialObject is null && Credential?.CredentialSource == "ApiKey")
        {
            CredentialObject = Credential?.Key;
        }

        BindCore(section);
    }

    /// <summary>
    /// .
    /// </summary>
    protected bool IsInitialized { get; private set; }

    /// <summary>
    /// .
    /// </summary>
    protected virtual void BindCore(IConfigurationSection? section = null) { }
}
