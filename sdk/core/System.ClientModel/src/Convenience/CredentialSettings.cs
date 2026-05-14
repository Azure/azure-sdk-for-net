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
    private readonly IConfigurationSection? _section;

    /// <summary>
    /// Initializes a new instance of the <see cref="CredentialSettings"/> class.
    /// </summary>
    /// <param name="section">The <see cref="IConfigurationSection"/> to load from.</param>
    public CredentialSettings(IConfigurationSection section)
    {
        if (section is null)
        {
            return;
        }

        _section = section;
        CredentialSource = section["CredentialSource"];
        Key = section["Key"];
        AdditionalProperties = section.GetSection("AdditionalProperties");
    }

    /// <summary>
    /// Reads an arbitrary value from the underlying credential configuration
    /// section. Library authors can extend the credential schema with custom
    /// properties (for example, a service-specific name or region) and surface
    /// them via extension methods that read through this indexer, without
    /// exposing the underlying <see cref="IConfigurationSection"/>. Supports
    /// the standard configuration <c>:</c> delimiter for nested paths. Returns
    /// <see langword="null"/> when no section was bound or if the specified value does not exist.
    /// </summary>
    /// <param name="key">The configuration key to read, relative to the credential section.</param>
    public string? this[string key] => _section?[key];

    /// <summary>
    /// Gets or sets the source of the credential.
    /// </summary>
    /// <remarks>
    /// This value determines the type of authentication policy to use. For example, "ApiKeyCredential" creates an <see cref="ApiKeyAuthenticationPolicy"/>.
    /// </remarks>
    public string? CredentialSource
    {
        get => field;
        set => field = NormalizeCredentialSource(value);
    }

    private static string? NormalizeCredentialSource(string? value)
    {
        if (value is null)
        {
            return null;
        }

        string lower = value.ToLowerInvariant();

        return lower switch
        {
            "apikey" => "apikeycredential",
            _ => lower
        };
    }

    /// <summary>
    /// Gets or sets the ApiKey.
    /// </summary>
    public string? Key { get; set; }

    /// <summary>
    /// Gets or sets additional properties for the credential.
    /// </summary>
    public IConfigurationSection? AdditionalProperties { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="AuthenticationTokenProvider"/> for this credential.
    /// </summary>
    public AuthenticationTokenProvider? CredentialProvider { get; set; }
}
