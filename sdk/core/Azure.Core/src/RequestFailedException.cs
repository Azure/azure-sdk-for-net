﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
#pragma warning disable CA2229, CA2235 // False positive
    /// <summary>
    /// An exception thrown when service request fails.
    /// </summary>
    [Serializable]
    public class RequestFailedException : Exception, ISerializable
    {
        private const string DefaultMessage = "Service request failed.";

        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// Gets the service specific error code if available. Please refer to the client documentation for the list of supported error codes.
        /// </summary>
        public string? ErrorCode { get; }

        /// <summary>
        /// Gets the response, if any, that led to the exception.
        /// </summary>
        private readonly Response? _response;

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public RequestFailedException(string message) : this(0, message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RequestFailedException(string message, Exception? innerException) : this(0, message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message and HTTP status code.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The message that describes the error.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestFailedException(int status, string message)
            : this(status, message, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestFailedException(int status, string message, Exception? innerException)
            : this(status, message, null, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code, error code, and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorCode">The service specific error code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RequestFailedException(int status, string message, string? errorCode, Exception? innerException)
            : base(message, innerException)
        {
            Status = status;
            ErrorCode = errorCode;
        }

        internal RequestFailedException(int status, (string Message, ResponseError? Error) details) :
            this(status, details.Message, details.Error?.Code, null)
        {
        }

        internal RequestFailedException(int status, (string FormatMessage, string? ErrorCode, IDictionary<string, string>? Data) details, Exception? innerException) :
            this(status, details.FormatMessage, details.ErrorCode, innerException)
        {
            if (details.Data != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in details.Data)
                {
                    Data.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class
        /// with an error message, HTTP status code, and error code obtained from the specified response.</summary>
        /// <param name="response">The response to obtain error details from.</param>
        public RequestFailedException(Response response)
            : this(response, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class
        /// with an error message, HTTP status code, and error code obtained from the specified response.</summary>
        /// <param name="response">The response to obtain error details from.</param>
        /// <param name="innerException">An inner exception to associate with the new <see cref="RequestFailedException"/>.</param>
        public RequestFailedException(Response response, Exception? innerException)
            : this(response, innerException, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class
        /// with an error message, HTTP status code, and error code obtained from the specified response.</summary>
        /// <param name="response">The response to obtain error details from.</param>
        /// <param name="innerException">An inner exception to associate with the new <see cref="RequestFailedException"/>.</param>
        /// <param name="detailsParser">The parser to use to parse the response content.</param>
        public RequestFailedException(Response response, Exception? innerException, RequestFailedDetailsParser? detailsParser)
            : this(response.Status, GetRequestFailedExceptionContent(response, detailsParser), innerException)
        {
            _response = response;
        }

        /// <inheritdoc />
        protected RequestFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Status = info.GetInt32(nameof(Status));
            ErrorCode = info.GetString(nameof(ErrorCode));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(Status), Status);
            info.AddValue(nameof(ErrorCode), ErrorCode);

            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Gets the response, if any, that led to the exception.
        /// </summary>
        public Response? GetRawResponse() => _response;

        internal static (string FormattedError, string? ErrorCode, IDictionary<string, string>? Data) GetRequestFailedExceptionContent(Response response, RequestFailedDetailsParser? parser)
        {
            BufferResponseIfNeeded(response);
            parser ??= response.RequestFailedDetailsParser;

            bool parseSuccess = parser == null ? TryExtractErrorContent(response, out ResponseError? error, out IDictionary<string, string>? additionalInfo) : parser.TryParse(response, out error, out additionalInfo);
            if (!parseSuccess)
            {
                error = null;
                additionalInfo = null;
            }
            StringBuilder messageBuilder = new();

            messageBuilder
                .AppendLine(error?.Message ?? DefaultMessage)
                .Append("Status: ")
                .Append(response.Status.ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(response.ReasonPhrase))
            {
                messageBuilder.Append(" (")
                    .Append(response.ReasonPhrase)
                    .AppendLine(")");
            }
            else
            {
                messageBuilder.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(error?.Code))
            {
                messageBuilder.Append("ErrorCode: ")
                    .Append(error?.Code)
                    .AppendLine();
            }

            if (additionalInfo is { Count: > 0 })
            {
                messageBuilder
                    .AppendLine()
                    .AppendLine("Additional Information:");
                foreach (KeyValuePair<string, string> info in additionalInfo)
                {
                    messageBuilder
                        .Append(info.Key)
                        .Append(": ")
                        .AppendLine(info.Value);
                }
            }

            if (response.ContentStream is MemoryStream && ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out Encoding _))
            {
                messageBuilder
                    .AppendLine()
                    .AppendLine("Content:")
                    .AppendLine(response.Content.ToString());
            }

            messageBuilder
                .AppendLine()
                .AppendLine("Headers:");

            foreach (HttpHeader responseHeader in response.Headers)
            {
                string headerValue = response.Sanitizer.SanitizeHeader(responseHeader.Name, responseHeader.Value);
                string header = $"{responseHeader.Name}: {headerValue}";
                messageBuilder.AppendLine(header);
            }

            var formatMessage = messageBuilder.ToString();
            return (formatMessage, error?.Code, additionalInfo);
        }

        private static void BufferResponseIfNeeded(Response response)
        {
            // Buffer into a memory stream if not already buffered
            if (response.ContentStream is null or MemoryStream)
            {
                return;
            }

            var bufferedStream = new MemoryStream();
            response.ContentStream.CopyTo(bufferedStream);

            // Dispose the unbuffered stream
            response.ContentStream.Dispose();

            // Reset the position of the buffered stream and set it on the response
            bufferedStream.Position = 0;
            response.ContentStream = bufferedStream;
        }

        internal static bool TryExtractErrorContent(Response response, out ResponseError? error, out IDictionary<string, string>? data)
        {
            error = null;
            data = null;

            try
            {
                // The response content is buffered at this point.
                string? content = response.Content.ToString();

                // Optimistic check for JSON object we expect
                if (content == null || !content.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                // Try the ErrorResponse format and fallback to the ResponseError format.

#if NET6_0_OR_GREATER
                error = System.Text.Json.JsonSerializer.Deserialize<ErrorResponse>(content, ResponseErrorSourceGenerationContext.Default.ErrorResponse)?.Error;
                error ??= System.Text.Json.JsonSerializer.Deserialize<ResponseError>(content, ResponseErrorSourceGenerationContext.Default.ResponseError);
#else
                error = System.Text.Json.JsonSerializer.Deserialize<ErrorResponse>(content)?.Error;
                error ??= System.Text.Json.JsonSerializer.Deserialize<ResponseError>(content);
#endif
            }
            catch (Exception)
            {
                // Ignore any failures - unexpected content will be
                // included verbatim in the detailed error message
            }

            return error != null;
        }

        // This class needs to be internal rather than private so that it can be used by the System.Text.Json source generator
        internal class ErrorResponse
        {
            [System.Text.Json.Serialization.JsonPropertyName("error")]
            public ResponseError? Error { get; set; }
        }
    }
}
