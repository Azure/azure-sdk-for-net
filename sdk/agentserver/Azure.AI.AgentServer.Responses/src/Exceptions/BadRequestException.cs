// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Exception thrown when a request is invalid — malformed JSON, missing required fields,
/// or invalid parameter values. Maps to HTTP 400 Bad Request.
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="BadRequestException"/> with a message.
    /// </summary>
    /// <param name="message">A description of the validation error.</param>
    public BadRequestException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="BadRequestException"/> with a message
    /// and the name of the invalid parameter.
    /// </summary>
    /// <param name="message">A description of the validation error.</param>
    /// <param name="paramName">The name of the invalid parameter, or <c>null</c>.</param>
    public BadRequestException(string message, string? paramName)
        : base(message)
    {
        ParamName = paramName;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="BadRequestException"/> with a message,
    /// an error code, and the name of the invalid parameter.
    /// </summary>
    /// <param name="message">A description of the validation error.</param>
    /// <param name="code">An error code identifying the kind of validation failure, or <c>null</c>.</param>
    /// <param name="paramName">The name of the invalid parameter, or <c>null</c>.</param>
    public BadRequestException(string message, string? code, string? paramName)
        : base(message)
    {
        Code = code;
        ParamName = paramName;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="BadRequestException"/> with a message
    /// and an inner exception.
    /// </summary>
    /// <param name="message">A description of the validation error.</param>
    /// <param name="innerException">The exception that caused this error.</param>
    public BadRequestException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Gets the error code identifying the kind of validation failure, if applicable.
    /// </summary>
    public string? Code { get; }

    /// <summary>
    /// Gets the name of the invalid parameter, if applicable.
    /// </summary>
    public string? ParamName { get; }
}
