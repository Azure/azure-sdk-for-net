// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents the settings used to configure a client that can be loaded from an <see cref="IConfigurationSection"/>.
/// </summary>
public abstract class ClientSettings
{
    /// <summary>
    /// Gets or sets the credential settings.
    /// </summary>
    public CredentialSettings? Credential { get; set; }

    /// <summary>
    /// Gets or sets the credential object.
    /// </summary>
    public AuthenticationTokenProvider? CredentialObject { get; set; }

    /// <summary>
    /// Binds the values from the <see cref="IConfigurationSection"/> to the properties of the <see cref="ClientSettings"/>.
    /// </summary>
    public void Bind(IConfigurationSection section)
    {
        if (section is null)
        {
            throw new ArgumentNullException(nameof(section));
        }

        Credential ??= new CredentialSettings(section.GetSection("Credential"));

        BindCore(section);
    }

    /// <summary>
    /// Allows derived classes to bind their specific properties from the <see cref="IConfigurationSection"/>.
    /// </summary>
    protected abstract void BindCore(IConfigurationSection section);
}
