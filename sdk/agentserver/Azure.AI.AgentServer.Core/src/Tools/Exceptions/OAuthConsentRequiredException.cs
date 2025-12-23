// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Exceptions;

/// <summary>
/// Exception thrown when OAuth consent is required for a tool operation.
/// </summary>
public class OAuthConsentRequiredException : Exception
{
    /// <summary>
    /// Gets the consent URL where the user can grant consent.
    /// </summary>
    public string? ConsentUrl { get; }

    /// <summary>
    /// Gets the payload containing additional error information.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? Payload { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OAuthConsentRequiredException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="consentUrl">The consent URL.</param>
    /// <param name="payload">Additional error payload.</param>
    public OAuthConsentRequiredException(
        string message,
        string? consentUrl = null,
        IReadOnlyDictionary<string, object?>? payload = null)
        : base(message)
    {
        ConsentUrl = consentUrl;
        Payload = payload;
    }
}
