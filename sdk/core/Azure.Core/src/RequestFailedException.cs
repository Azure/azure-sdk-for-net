﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    /// <summary>
    /// An exception thrown when service request fails.
    /// </summary>
    [Serializable]
    public class RequestFailedException : ClientResultException, ISerializable
    {
        private const string DefaultMessage = "Service request failed.";

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="parser"></param>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public static async ValueTask<RequestFailedException> CreateAsync(Response response, RequestFailedDetailsParser? parser = default, Exception? innerException = default)
        {
            ErrorDetails details = await CreateExceptionDetailsAsync(response, parser).ConfigureAwait(false);
            return new RequestFailedException(response, details, innerException);
        }

        /// <summary>
        /// Gets the service specific error code if available. Please refer to the client documentation for the list of supported error codes.
        /// </summary>
        public string? ErrorCode { get; }

        #region Response constructors

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
            : this(response, CreateExceptionDetails(response, detailsParser), innerException)
        {
        }

        private RequestFailedException(Response response, ErrorDetails details, Exception? innerException)
            : base(details.Message, response, innerException)
        {
            ErrorCode = details.ErrorCode;

            if (details.Data != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in details.Data)
                {
                    Data.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
        }

        #endregion

        #region No-Response constructors

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public RequestFailedException(string message) : this(0, message)
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

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RequestFailedException(string message, Exception? innerException)
            : this(0, message, innerException)
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
            : base(message, default, innerException)
        {
            Status = status;
            ErrorCode = errorCode;
        }

        #endregion

        #region ISerializable implementation

        /// <inheritdoc />
        protected RequestFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ErrorCode = info.GetString(nameof(ErrorCode));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(ErrorCode), ErrorCode);

            base.GetObjectData(info, context);
        }

        #endregion

        /// <summary>
        /// Gets the response, if any, that led to the exception.
        /// </summary>
        public new Response? GetRawResponse() => (Response?)base.GetRawResponse();

        private static ErrorDetails CreateExceptionDetails(Response response, RequestFailedDetailsParser? parser)
            => CreateExceptionDetailsSyncOrAsync(response, parser, async: false).EnsureCompleted();

        private static async ValueTask<ErrorDetails> CreateExceptionDetailsAsync(Response response, RequestFailedDetailsParser? parser)
            => await CreateExceptionDetailsSyncOrAsync(response, parser, async: true).ConfigureAwait(false);

        private static async ValueTask<ErrorDetails> CreateExceptionDetailsSyncOrAsync(Response response, RequestFailedDetailsParser? parser, bool async)
        {
            if (async)
            {
                await response.ReadContentAsync().ConfigureAwait(false);
            }
            else
            {
                response.ReadContent();
            }

            parser ??= response.RequestFailedDetailsParser;

            bool parseSuccess = parser == null ?
                DefaultRequestFailedDetailsParser.TryParseDetails(response, out ResponseError? error, out IDictionary<string, string>? additionalInfo) :
                parser.TryParse(response, out error, out additionalInfo);

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

            if (ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out Encoding _))
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

            return new ErrorDetails(messageBuilder.ToString(), error?.Code, additionalInfo);
        }

        // This class needs to be internal rather than private so that it can be used
        // by the System.Text.Json source generator.
        internal class ErrorResponse
        {
            [System.Text.Json.Serialization.JsonPropertyName("error")]
            public ResponseError? Error { get; set; }
        }

        private readonly struct ErrorDetails
        {
            public ErrorDetails(string message, string? errorCode, IDictionary<string, string>? data)
            {
                Message = message;
                ErrorCode = errorCode;
                Data = data;
            }

            public string Message { get; }

            public string? ErrorCode { get; }

            public IDictionary<string, string>? Data { get; }
        }
    }
}
