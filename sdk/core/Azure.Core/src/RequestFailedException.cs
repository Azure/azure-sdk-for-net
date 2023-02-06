// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public RequestFailedException(int status, string message)
            : this(status, message, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RequestFailedException(int status, string message, Exception? innerException)
            : this(status, message, null, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code, error code, and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorCode">The service specific error code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
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
        /// with an error message, HTTP status code, error code obtained from the specified response.</summary>
        /// <param name="response">The response to obtain error details from.</param>
        public RequestFailedException(Response response)
            : this(response, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class
        /// with an error message, HTTP status code, error code obtained from the specified response.</summary>
        /// <param name="response">The response to obtain error details from.</param>
        /// <param name="innerException">An inner exception to associate with the new <see cref="RequestFailedException"/>.</param>
        public RequestFailedException(Response response, Exception? innerException)
            : this(response.Status, GetRequestFailedExceptionContent(response), innerException)
        {
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

        internal static (string FormattedError, string? ErrorCode, IDictionary<string, string>? Data) GetRequestFailedExceptionContent(Response response)
        {
            bool parseSuccess = response.RequestFailedDetailsParser == null ? TryExtractErrorContent(response, out ResponseError? error, out IDictionary<string, string>? data) : response.RequestFailedDetailsParser.TryParse(response, out error, out data);
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

            if (parseSuccess && data != null && data.Count > 0)
            {
                messageBuilder
                    .AppendLine()
                    .AppendLine("Additional Information:");
                foreach (KeyValuePair<string, string> info in data)
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
            return (formatMessage, error?.Code, data);
        }

        /// <summary>
        /// This is intentionally sync-only as it will only be called by the ctor.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static string? ReadContent(Response response)
        {
            string? content = null;

            if (response.ContentStream != null &&
                ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out var encoding))
            {
                using (var streamReader = new StreamReader(response.ContentStream, encoding))
                {
                    content = streamReader.ReadToEnd();
                }
            }

            return content;
        }

        internal static bool TryExtractErrorContent(Response response, out ResponseError? error, out IDictionary<string, string>? data)
        {
            error = null;
            data = null;
            try
            {
                string? content = null;
                if (response.ContentStream != null && response.ContentStream.CanSeek)
                {
                    content = response.Content.ToString();
                }
                else
                {
                    // this path should only happen in exceptional cases such as when
                    // the RFE ctor was called directly by client or customer code with an un-buffered response.
                    // Generated code would never do this.
                    content = ReadContent(response);
                }
                // Optimistic check for JSON object we expect
                if (content == null || !content.StartsWith("{", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                error = System.Text.Json.JsonSerializer.Deserialize<ErrorResponse>(content)?.Error;
            }
            catch (Exception)
            {
                // Ignore any failures - unexpected content will be
                // included verbatim in the detailed error message
            }

            return error != null;
        }

        private class ErrorResponse
        {
            [System.Text.Json.Serialization.JsonPropertyName("error")]
            public ResponseError? Error { get; set; }
        }
    }
}
