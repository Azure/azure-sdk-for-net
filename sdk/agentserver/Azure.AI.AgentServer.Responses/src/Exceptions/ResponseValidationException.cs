// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Thrown when a handler-yielded event fails response validation.
/// Internal — never surfaces to API callers. Full details are logged via <c>ILogger</c>.
/// </summary>
internal sealed class ResponseValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="ResponseValidationException"/>.
    /// </summary>
    /// <param name="errors">The list of validation errors found on the response event.</param>
    public ResponseValidationException(IReadOnlyList<ValidationError> errors)
        : base($"Response validation failed with {errors.Count} error(s).")
    {
        Errors = errors;
    }

    /// <summary>
    /// Gets the list of validation errors found on the response event.
    /// </summary>
    public IReadOnlyList<ValidationError> Errors { get; }
}
