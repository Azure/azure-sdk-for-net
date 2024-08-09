// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using static System.Net.WebRequestMethods;

namespace Azure.AI.OpenAI;

/// <summary>
/// Represents cloud authentication audiences available for Azure OpenAI.
/// These audiences correspond to authorization token authentication scopes.
/// </summary>
public readonly partial struct AzureOpenAIAuthorizationAudience : IEquatable<AzureOpenAIAuthorizationAudience>
{
    private readonly string _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureOpenAIAuthorizationAudience"/> object.
    /// </summary>
    /// <remarks>
    /// Please consider using one of the known, valid values like <see cref="AzurePublicCloud"/> or <see cref="AzureGovernmentCloud"/>.
    /// </remarks>
    /// <param name="value">
    /// The Azure Active Directory audience to use when forming authorization scopes.
    /// For Azure OpenAI, this value corresponds to a URL that identifies the Azure cloud where the resource is located.
    /// For more information: <see href="https://docs.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.
    /// </param>
    /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
    public AzureOpenAIAuthorizationAudience(string value)
    {
        Argument.AssertNotNullOrEmpty(value, nameof(value));
        _value = value;
    }

    private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com";
    private const string AzureGovernmentCloudValue = "https://cognitiveservices.azure.us";

    /// <summary>
    /// The authorization audience used to connect to the public Azure cloud. Default if not otherwise specified.
    /// </summary>
    public static AzureOpenAIAuthorizationAudience AzurePublicCloud { get; } = new AzureOpenAIAuthorizationAudience(AzurePublicCloudValue);

    /// <summary>
    /// The authorization audience used to authenticate with the Azure Government cloud.
    /// </summary>
    /// <remarks>
    /// For more information, please refer to
    /// <see href="https://learn.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.
    /// </remarks>
    public static AzureOpenAIAuthorizationAudience AzureGovernmentCloud { get; } = new AzureOpenAIAuthorizationAudience(AzureGovernmentCloudValue);

    /// <summary> Determines if two <see cref="AzureOpenAIAuthorizationAudience"/> values are the same. </summary>
    public static bool operator ==(AzureOpenAIAuthorizationAudience left, AzureOpenAIAuthorizationAudience right) => left.Equals(right);
    /// <summary> Determines if two <see cref="AzureOpenAIAuthorizationAudience"/> values are not the same. </summary>
    public static bool operator !=(AzureOpenAIAuthorizationAudience left, AzureOpenAIAuthorizationAudience right) => !left.Equals(right);
    /// <summary> Converts a string to a <see cref="AzureOpenAIAuthorizationAudience"/>. </summary>
    public static implicit operator AzureOpenAIAuthorizationAudience(string value) => new AzureOpenAIAuthorizationAudience(value);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is AzureOpenAIAuthorizationAudience other && Equals(other);
    /// <inheritdoc />
    public bool Equals(AzureOpenAIAuthorizationAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;
    /// <inheritdoc />
    public override string ToString() => _value;
}
