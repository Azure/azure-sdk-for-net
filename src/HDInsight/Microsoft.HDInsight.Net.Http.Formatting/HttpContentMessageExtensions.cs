// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers;

    /// <summary>
    /// Extension methods to read <see cref="HttpRequestMessage"/> and <see cref="HttpResponseMessage"/> entities from <see cref="HttpContent"/> instances.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class HttpContentMessageExtensions
    {
        private const int MinBufferSize = 256;
        private const int DefaultBufferSize = 32 * 1024;

        /// <summary>
        /// Determines whether the specified content is HTTP request message content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if the specified content is HTTP message content; otherwise, <c>false</c>.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception translates to false.")]
        public static bool IsHttpRequestMessageContent(this HttpContent content)
        {
            if (content == null)
            {
                throw Error.ArgumentNull("content");
            }

            try
            {
                return HttpMessageContent.ValidateHttpMessageContent(content, true, false);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified content is HTTP response message content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if the specified content is HTTP message content; otherwise, <c>false</c>.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception translates to false.")]
        public static bool IsHttpResponseMessageContent(this HttpContent content)
        {
            if (content == null)
            {
                throw Error.ArgumentNull("content");
            }

            try
            {
                return HttpMessageContent.ValidateHttpMessageContent(content, false, false);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpRequestMessage"/>.</returns>
        public static Task<HttpRequestMessage> ReadAsHttpRequestMessageAsync(this HttpContent content)
        {
            return ReadAsHttpRequestMessageAsync(content, "http", DefaultBufferSize);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpRequestMessage"/>.</returns>
        public static Task<HttpRequestMessage> ReadAsHttpRequestMessageAsync(this HttpContent content, CancellationToken cancellationToken)
        {
            return ReadAsHttpRequestMessageAsync(content, "http", DefaultBufferSize, cancellationToken);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="uriScheme">The URI scheme to use for the request URI.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpRequestMessage"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "This is not a full URI but only the URI scheme")]
        public static Task<HttpRequestMessage> ReadAsHttpRequestMessageAsync(this HttpContent content, string uriScheme)
        {
            return ReadAsHttpRequestMessageAsync(content, uriScheme, DefaultBufferSize);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="uriScheme">The URI scheme to use for the request URI.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpRequestMessage"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "This is not a full URI but only the URI scheme")]
        public static Task<HttpRequestMessage> ReadAsHttpRequestMessageAsync(this HttpContent content, string uriScheme,
            CancellationToken cancellationToken)
        {
            return ReadAsHttpRequestMessageAsync(content, uriScheme, DefaultBufferSize, cancellationToken);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="uriScheme">The URI scheme to use for the request URI (the 
        /// URI scheme is not actually part of the HTTP Request URI and so must be provided externally).</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpRequestMessage"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "This is not a full URI but only the URI scheme")]
        public static Task<HttpRequestMessage> ReadAsHttpRequestMessageAsync(this HttpContent content, string uriScheme, int bufferSize)
        {
            return ReadAsHttpRequestMessageAsync(content, uriScheme, bufferSize, HttpRequestHeaderParser.DefaultMaxHeaderSize);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="uriScheme">The URI scheme to use for the request URI (the 
        /// URI scheme is not actually part of the HTTP Request URI and so must be provided externally).</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpRequestMessage"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "This is not a full URI but only the URI scheme")]
        public static Task<HttpRequestMessage> ReadAsHttpRequestMessageAsync(this HttpContent content, string uriScheme,
            int bufferSize, CancellationToken cancellationToken)
        {
            return ReadAsHttpRequestMessageAsync(content, uriScheme, bufferSize,
                HttpRequestHeaderParser.DefaultMaxHeaderSize, cancellationToken);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="uriScheme">The URI scheme to use for the request URI (the 
        /// URI scheme is not actually part of the HTTP Request URI and so must be provided externally).</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="maxHeaderSize">The max length of the HTTP header.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpRequestMessage"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "This is not a full URI but only the URI scheme")]
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception translates to parser state.")]
        public static Task<HttpRequestMessage> ReadAsHttpRequestMessageAsync(this HttpContent content, string uriScheme,
            int bufferSize, int maxHeaderSize)
        {
            return ReadAsHttpRequestMessageAsync(content, uriScheme, bufferSize, maxHeaderSize, CancellationToken.None);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="uriScheme">The URI scheme to use for the request URI (the 
        /// URI scheme is not actually part of the HTTP Request URI and so must be provided externally).</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="maxHeaderSize">The max length of the HTTP header.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpRequestMessage"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "This is not a full URI but only the URI scheme")]
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception translates to parser state.")]
        public static Task<HttpRequestMessage> ReadAsHttpRequestMessageAsync(this HttpContent content, string uriScheme,
            int bufferSize, int maxHeaderSize, CancellationToken cancellationToken)
        {
            if (content == null)
            {
                throw Error.ArgumentNull("content");
            }

            if (uriScheme == null)
            {
                throw Error.ArgumentNull("uriScheme");
            }

            if (!Uri.CheckSchemeName(uriScheme))
            {
                throw Error.Argument("uriScheme", Resources.HttpMessageParserInvalidUriScheme, uriScheme, typeof(Uri).Name);
            }

            if (bufferSize < MinBufferSize)
            {
                throw Error.ArgumentMustBeGreaterThanOrEqualTo("bufferSize", bufferSize, MinBufferSize);
            }

            if (maxHeaderSize < InternetMessageFormatHeaderParser.MinHeaderSize)
            {
                throw Error.ArgumentMustBeGreaterThanOrEqualTo("maxHeaderSize", maxHeaderSize, InternetMessageFormatHeaderParser.MinHeaderSize);
            }

            HttpMessageContent.ValidateHttpMessageContent(content, true, true);

            return content.ReadAsHttpRequestMessageAsyncCore(uriScheme, bufferSize, maxHeaderSize, cancellationToken);
        }

        private static async Task<HttpRequestMessage> ReadAsHttpRequestMessageAsyncCore(this HttpContent content,
            string uriScheme, int bufferSize, int maxHeaderSize, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Stream stream = await content.ReadAsStreamAsync();

            HttpUnsortedRequest httpRequest = new HttpUnsortedRequest();
            HttpRequestHeaderParser parser = new HttpRequestHeaderParser(httpRequest,
                HttpRequestHeaderParser.DefaultMaxRequestLineSize, maxHeaderSize);
            ParserState parseStatus;

            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            int headerConsumed = 0;

            while (true)
            {
                try
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                }
                catch (Exception e)
                {
                    throw new IOException(Resources.HttpMessageErrorReading, e);
                }

                try
                {
                    parseStatus = parser.ParseBuffer(buffer, bytesRead, ref headerConsumed);
                }
                catch (Exception)
                {
                    parseStatus = ParserState.Invalid;
                }

                if (parseStatus == ParserState.Done)
                {
                    return CreateHttpRequestMessage(uriScheme, httpRequest, stream, bytesRead - headerConsumed);
                }
                else if (parseStatus != ParserState.NeedMoreData)
                {
                    throw Error.InvalidOperation(Resources.HttpMessageParserError, headerConsumed, buffer);
                }
                else if (bytesRead == 0)
                {
                    throw new IOException(Resources.ReadAsHttpMessageUnexpectedTermination);
                }
            }
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpResponseMessage"/>.</returns>
        public static Task<HttpResponseMessage> ReadAsHttpResponseMessageAsync(this HttpContent content)
        {
            return ReadAsHttpResponseMessageAsync(content, DefaultBufferSize);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpResponseMessage"/>.</returns>
        public static Task<HttpResponseMessage> ReadAsHttpResponseMessageAsync(this HttpContent content, CancellationToken cancellationToken)
        {
            return ReadAsHttpResponseMessageAsync(content, DefaultBufferSize, cancellationToken);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpResponseMessage"/>.</returns>
        public static Task<HttpResponseMessage> ReadAsHttpResponseMessageAsync(this HttpContent content, int bufferSize)
        {
            return ReadAsHttpResponseMessageAsync(content, bufferSize, HttpResponseHeaderParser.DefaultMaxHeaderSize);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpResponseMessage"/>.</returns>
        public static Task<HttpResponseMessage> ReadAsHttpResponseMessageAsync(this HttpContent content, int bufferSize,
            CancellationToken cancellationToken)
        {
            return ReadAsHttpResponseMessageAsync(content, bufferSize, HttpResponseHeaderParser.DefaultMaxHeaderSize, cancellationToken);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="maxHeaderSize">The max length of the HTTP header.</param>
        /// <returns>A task object representing reading the content as an <see cref="HttpResponseMessage"/>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception translates to parser state.")]
        public static Task<HttpResponseMessage> ReadAsHttpResponseMessageAsync(this HttpContent content, int bufferSize,
            int maxHeaderSize)
        {
            return ReadAsHttpResponseMessageAsync(content, bufferSize, maxHeaderSize, CancellationToken.None);
        }

        /// <summary>
        /// Read the <see cref="HttpContent"/> as an <see cref="HttpResponseMessage"/>.
        /// </summary>
        /// <param name="content">The content to read.</param>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="maxHeaderSize">The max length of the HTTP header.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>The parsed <see cref="HttpResponseMessage"/> instance.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception translates to parser state.")]
        public static Task<HttpResponseMessage> ReadAsHttpResponseMessageAsync(this HttpContent content, int bufferSize,
            int maxHeaderSize, CancellationToken cancellationToken)
        {
            if (content == null)
            {
                throw Error.ArgumentNull("content");
            }

            if (bufferSize < MinBufferSize)
            {
                throw Error.ArgumentMustBeGreaterThanOrEqualTo("bufferSize", bufferSize, MinBufferSize);
            }

            if (maxHeaderSize < InternetMessageFormatHeaderParser.MinHeaderSize)
            {
                throw Error.ArgumentMustBeGreaterThanOrEqualTo("maxHeaderSize", maxHeaderSize, InternetMessageFormatHeaderParser.MinHeaderSize);
            }

            HttpMessageContent.ValidateHttpMessageContent(content, false, true);

            return content.ReadAsHttpResponseMessageAsyncCore(bufferSize, maxHeaderSize, cancellationToken);
        }

        private static async Task<HttpResponseMessage> ReadAsHttpResponseMessageAsyncCore(this HttpContent content,
            int bufferSize, int maxHeaderSize, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Stream stream = await content.ReadAsStreamAsync();

            HttpUnsortedResponse httpResponse = new HttpUnsortedResponse();
            HttpResponseHeaderParser parser = new HttpResponseHeaderParser(httpResponse, HttpResponseHeaderParser.DefaultMaxStatusLineSize, maxHeaderSize);
            ParserState parseStatus;

            byte[] buffer = new byte[bufferSize];
            int bytesRead = 0;
            int headerConsumed = 0;

            while (true)
            {
                try
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                }
                catch (Exception e)
                {
                    throw new IOException(Resources.HttpMessageErrorReading, e);
                }

                try
                {
                    parseStatus = parser.ParseBuffer(buffer, bytesRead, ref headerConsumed);
                }
                catch (Exception)
                {
                    parseStatus = ParserState.Invalid;
                }

                if (parseStatus == ParserState.Done)
                {
                    // Create and return parsed HttpResponseMessage
                    return CreateHttpResponseMessage(httpResponse, stream, bytesRead - headerConsumed);
                }
                else if (parseStatus != ParserState.NeedMoreData)
                {
                    throw Error.InvalidOperation(Resources.HttpMessageParserError, headerConsumed, buffer);
                }
                else if (bytesRead == 0)
                {
                    throw new IOException(Resources.ReadAsHttpMessageUnexpectedTermination);
                }
            }
        }

        /// <summary>
        /// Creates the request URI by combining scheme (provided) with parsed values of
        /// host and path.
        /// </summary>
        /// <param name="uriScheme">The URI scheme to use for the request URI.</param>
        /// <param name="httpRequest">The unsorted HTTP request.</param>
        /// <returns>A fully qualified request URI.</returns>
        private static Uri CreateRequestUri(string uriScheme, HttpUnsortedRequest httpRequest)
        {
            Contract.Assert(httpRequest != null, "httpRequest cannot be null.");
            Contract.Assert(uriScheme != null, "uriScheme cannot be null");

            IEnumerable<string> hostValues;
            if (httpRequest.HttpHeaders.TryGetValues(FormattingUtilities.HttpHostHeader, out hostValues))
            {
                int hostCount = hostValues.Count();
                if (hostCount != 1)
                {
                    throw Error.InvalidOperation(Resources.HttpMessageParserInvalidHostCount, FormattingUtilities.HttpHostHeader, hostCount);
                }
            }
            else
            {
                throw Error.InvalidOperation(Resources.HttpMessageParserInvalidHostCount, FormattingUtilities.HttpHostHeader, 0);
            }

            // We don't use UriBuilder as hostValues.ElementAt(0) contains 'host:port' and UriBuilder needs these split out into separate host and port.
            string requestUri = String.Format(CultureInfo.InvariantCulture, "{0}://{1}{2}", uriScheme, hostValues.ElementAt(0), httpRequest.RequestUri);
            return new Uri(requestUri);
        }

        /// <summary>
        /// Copies the unsorted header fields to a sorted collection.
        /// </summary>
        /// <param name="source">The unsorted source headers</param>
        /// <param name="destination">The destination <see cref="HttpRequestHeaders"/> or <see cref="HttpResponseHeaders"/>.</param>
        /// <param name="contentStream">The input <see cref="Stream"/> used to form any <see cref="HttpContent"/> being part of this HTTP request.</param>
        /// <param name="rewind">Start location of any request entity within the <paramref name="contentStream"/>.</param>
        /// <returns>An <see cref="HttpContent"/> instance if header fields contained and <see cref="HttpContentHeaders"/>.</returns>
        private static HttpContent CreateHeaderFields(HttpHeaders source, HttpHeaders destination, Stream contentStream, int rewind)
        {
            Contract.Assert(source != null, "source headers cannot be null");
            Contract.Assert(destination != null, "destination headers cannot be null");
            Contract.Assert(contentStream != null, "contentStream must be non null");
            HttpContentHeaders contentHeaders = null;
            HttpContent content = null;

            // Set the header fields
            foreach (KeyValuePair<string, IEnumerable<string>> header in source)
            {
                if (!destination.TryAddWithoutValidation(header.Key, header.Value))
                {
                    if (contentHeaders == null)
                    {
                        contentHeaders = FormattingUtilities.CreateEmptyContentHeaders();
                    }

                    contentHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // If we have content headers then create an HttpContent for this Response
            if (contentHeaders != null)
            {
                // Need to rewind the input stream to be at the position right after the HTTP header
                // which we may already have parsed as we read the content stream.
                if (!contentStream.CanSeek)
                {
                    throw Error.InvalidOperation(Resources.HttpMessageContentStreamMustBeSeekable, "ContentReadStream", FormattingUtilities.HttpResponseMessageType.Name);
                }

                contentStream.Seek(0 - rewind, SeekOrigin.Current);
                content = new StreamContent(contentStream);
                contentHeaders.CopyTo(content.Headers);
            }

            return content;
        }

        /// <summary>
        /// Creates an <see cref="HttpRequestMessage"/> based on information provided in <see cref="HttpUnsortedRequest"/>.
        /// </summary>
        /// <param name="uriScheme">The URI scheme to use for the request URI.</param>
        /// <param name="httpRequest">The unsorted HTTP request.</param>
        /// <param name="contentStream">The input <see cref="Stream"/> used to form any <see cref="HttpContent"/> being part of this HTTP request.</param>
        /// <param name="rewind">Start location of any request entity within the <paramref name="contentStream"/>.</param>
        /// <returns>A newly created <see cref="HttpRequestMessage"/> instance.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "caller becomes owner.")]
        private static HttpRequestMessage CreateHttpRequestMessage(string uriScheme, HttpUnsortedRequest httpRequest, Stream contentStream, int rewind)
        {
            Contract.Assert(uriScheme != null, "URI scheme must be non null");
            Contract.Assert(httpRequest != null, "httpRequest must be non null");
            Contract.Assert(contentStream != null, "contentStream must be non null");

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();

            // Set method, requestURI, and version
            httpRequestMessage.Method = httpRequest.Method;
            httpRequestMessage.RequestUri = CreateRequestUri(uriScheme, httpRequest);
            httpRequestMessage.Version = httpRequest.Version;

            // Set the header fields and content if any
            httpRequestMessage.Content = CreateHeaderFields(httpRequest.HttpHeaders, httpRequestMessage.Headers, contentStream, rewind);

            return httpRequestMessage;
        }

        /// <summary>
        /// Creates an <see cref="HttpResponseMessage"/> based on information provided in <see cref="HttpUnsortedResponse"/>.
        /// </summary>
        /// <param name="httpResponse">The unsorted HTTP Response.</param>
        /// <param name="contentStream">The input <see cref="Stream"/> used to form any <see cref="HttpContent"/> being part of this HTTP Response.</param>
        /// <param name="rewind">Start location of any Response entity within the <paramref name="contentStream"/>.</param>
        /// <returns>A newly created <see cref="HttpResponseMessage"/> instance.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "caller becomes owner.")]
        private static HttpResponseMessage CreateHttpResponseMessage(HttpUnsortedResponse httpResponse, Stream contentStream, int rewind)
        {
            Contract.Assert(httpResponse != null, "httpResponse must be non null");
            Contract.Assert(contentStream != null, "contentStream must be non null");

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            // Set version, status code and reason phrase
            httpResponseMessage.Version = httpResponse.Version;
            httpResponseMessage.StatusCode = httpResponse.StatusCode;
            httpResponseMessage.ReasonPhrase = httpResponse.ReasonPhrase;

            // Set the header fields and content if any
            httpResponseMessage.Content = CreateHeaderFields(httpResponse.HttpHeaders, httpResponseMessage.Headers, contentStream, rewind);

            return httpResponseMessage;
        }
    }
}
