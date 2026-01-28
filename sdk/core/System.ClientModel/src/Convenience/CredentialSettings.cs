// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Holds the credential settings used to configure authentication for a client that can be loaded from an <see cref="IConfigurationSection"/>.
/// </summary>
[Experimental("SCME0002")]
public sealed class CredentialSettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CredentialSettings"/> class.
    /// </summary>
    /// <param name="section">The <see cref="IConfigurationSection"/> to load from.</param>
    public CredentialSettings(IConfigurationSection section)
    {
        if (section is null)
        {
            throw new ArgumentNullException(nameof(section));
        }

        CredentialSource = section["CredentialSource"];
        Key = section["Key"];
        AdditionalProperties = section.GetSection("AdditionalProperties");
    }

    /// <summary>
    /// Gets or sets the source of the credential.
    /// </summary>
    /// <remarks>
    /// This value determines the type of authentication policy to use. For example, "ApiKey" creates an <see cref="ApiKeyAuthenticationPolicy"/>.
    /// </remarks>
    public string? CredentialSource { get; set; }

    /// <summary>
    /// Gets or sets the ApiKey.
    /// </summary>
    public string? Key { get; set; }

    /// <summary>
    /// Gets or sets additional properties for the credential.
    /// </summary>
    public IConfigurationSection? AdditionalProperties { get; set; }
}
