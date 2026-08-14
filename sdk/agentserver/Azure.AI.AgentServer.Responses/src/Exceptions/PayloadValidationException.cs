// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Exception thrown when an incoming request payload fails validation against the API schema.
/// Carries the list of per-field validation errors for structured error reporting.
/// Maps to HTTP 400 Bad Request with <c>Error.Details[]</c>.
/// </summary>
public sealed class PayloadValidationException : BadRequestException
{
    /// <summary>
    /// Initializes a new instance of <see cref="PayloadValidationException"/>.
    /// </summary>
    /// <param name="errors">The list of validation errors found in the payload.</param>
    public PayloadValidationException(IReadOnlyList<ValidationError> errors)
        : base(BuildMessage(errors), errors.Count > 0 ? errors[0].Path : null)
    {
        Errors = errors;
    }

    /// <summary>
    /// Gets the list of validation errors found in the payload.
    /// </summary>
    public IReadOnlyList<ValidationError> Errors { get; }

    private static string BuildMessage(IReadOnlyList<ValidationError> errors)
    {
        if (errors.Count == 0)
        {
            return "Validation failed.";
        }

        if (errors.Count == 1)
        {
            return errors[0].Message;
        }

        const int maxLength = 512;
        var message = $"Validation failed with {errors.Count} errors: ";
        var included = 0;

        for (var i = 0; i < errors.Count; i++)
        {
            var errorDesc = errors[i].Message;
            var separator = i > 0 ? "; " : "";
            var candidate = separator + errorDesc;

            if (message.Length + candidate.Length > maxLength)
            {
                var remaining = errors.Count - included;
                message += $"... and {remaining} more.";
                break;
            }

            message += candidate;
            included++;
        }

        return message;
    }
}
