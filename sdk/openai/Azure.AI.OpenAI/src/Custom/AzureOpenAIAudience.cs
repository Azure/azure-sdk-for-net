// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.AI.OpenAI;

/// <summary>
/// Represents cloud authentication audiences available for Azure OpenAI.
/// These audiences correspond to authorization token authentication scopes.
/// </summary>
public readonly partial struct AzureOpenAIAudience : IEquatable<AzureOpenAIAudience>
{
    private readonly string _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureOpenAIAudience"/> object.
    /// </summary>
    /// <remarks>
    /// Please consider using one of the known, valid values like <see cref="AzurePublicCloud"/> or <see cref="AzureGovernment"/>.
    /// </remarks>
    /// <param name="value">
    /// The Microsoft Entra audience to use when forming authorization scopes.
    /// For Azure OpenAI, this value corresponds to a URL that identifies the Azure cloud where the resource is located.
    /// For more information: <see href="https://learn.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.
    /// </param>
    /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
    public AzureOpenAIAudience(string value)
    {
        Argument.AssertNotNullOrEmpty(value, nameof(value));
        _value = value;
    }

    private const string AzurePublicCloudValue = "https://cognitiveservices.azure.com/.default";
    private const string AzureGovernmentValue = "https://cognitiveservices.azure.us/.default";

    /// <summary>
    /// The authorization audience used to connect to the public Azure cloud. Default if not otherwise specified.
    /// </summary>
    public static AzureOpenAIAudience AzurePublicCloud { get; } = new AzureOpenAIAudience(AzurePublicCloudValue);

    /// <summary>
    /// The authorization audience used to authenticate with the Azure Government cloud.
    /// </summary>
    /// <remarks>
    /// For more information, please refer to
    /// <see href="https://learn.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.
    /// </remarks>
    public static AzureOpenAIAudience AzureGovernment { get; } = new AzureOpenAIAudience(AzureGovernmentValue);

    /// <summary> Determines if two <see cref="AzureOpenAIAudience"/> values are the same. </summary>
    public static bool operator ==(AzureOpenAIAudience left, AzureOpenAIAudience right) => left.Equals(right);
    /// <summary> Determines if two <see cref="AzureOpenAIAudience"/> values are not the same. </summary>
    public static bool operator !=(AzureOpenAIAudience left, AzureOpenAIAudience right) => !left.Equals(right);
    /// <summary> Converts a string to a <see cref="AzureOpenAIAudience"/>. </summary>
    public static implicit operator AzureOpenAIAudience(string value) => new AzureOpenAIAudience(value);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is AzureOpenAIAudience other && Equals(other);
    /// <inheritdoc />
    public bool Equals(AzureOpenAIAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
    /// <inheritdoc />
    public override string ToString() => _value;
}
