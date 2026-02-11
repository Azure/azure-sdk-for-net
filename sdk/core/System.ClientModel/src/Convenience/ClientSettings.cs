// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Represents the settings used to configure a client that can be loaded from an <see cref="IConfigurationSection"/>.
/// </summary>
[Experimental("SCME0002")]
public abstract class ClientSettings
{
    private IConfigurationSection? _section;

    /// <summary>
    /// Gets or sets the credential settings.
    /// </summary>
    public CredentialSettings? Credential { get; set; }

    /// <summary>
    /// Gets or sets the credential provider.
    /// </summary>
    public AuthenticationTokenProvider? CredentialProvider { get; set; }

    /// <summary>
    /// Binds the values from the <see cref="IConfigurationSection"/> to the properties of the <see cref="ClientSettings"/>.
    /// </summary>
    public void Bind(IConfigurationSection section)
    {
        if (section is null)
        {
            throw new ArgumentNullException(nameof(section));
        }

        _section = section;

        Credential ??= new CredentialSettings(section.GetSection("Credential"));

        BindCore(section);
    }

    /// <summary>
    /// Allows derived classes to bind their specific properties from the <see cref="IConfigurationSection"/>.
    /// </summary>
    protected abstract void BindCore(IConfigurationSection section);

    /// <summary>
    /// Allows for additional configuration using the <see cref="IConfigurationSection"/> after the initial binding.
    /// </summary>
    /// <param name="configure">Factory method to modify this instance of <see cref="ClientSettings"/>.</param>
    public void PostConfigure(Action<IConfigurationSection> configure)
    {
        if (configure is null)
        {
            throw new ArgumentNullException(nameof(configure));
        }

        if (_section is null)
        {
            throw new InvalidOperationException("Bind must be called before PostConfigure.");
        }

        configure(_section);
    }
}
