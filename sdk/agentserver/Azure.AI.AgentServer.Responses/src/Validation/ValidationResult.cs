// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// The result of a payload validation operation.
/// </summary>
internal sealed class ValidationResult
{
    /// <summary>
    /// A successful validation result with no errors.
    /// </summary>
    public static readonly ValidationResult Success = new(true, Array.Empty<ValidationError>());

    private ValidationResult(bool isValid, IReadOnlyList<ValidationError> errors)
    {
        IsValid = isValid;
        Errors = errors;
    }

    /// <summary>
    /// Gets a value indicating whether the payload is valid.
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    /// Gets the list of validation errors found. Empty if <see cref="IsValid"/> is <c>true</c>.
    /// </summary>
    public IReadOnlyList<ValidationError> Errors { get; }

    /// <summary>
    /// Creates a failed validation result with one or more errors.
    /// </summary>
    /// <param name="errors">The list of validation errors.</param>
    /// <returns>A <see cref="ValidationResult"/> representing validation failure.</returns>
    public static ValidationResult Failure(IReadOnlyList<ValidationError> errors)
    {
        if (errors.Count == 0)
        {
            throw new ArgumentException("At least one error is required for a failure result.", nameof(errors));
        }

        return new ValidationResult(false, errors);
    }
}
