// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    /// Extension methods that aid in making formatted requests using <see cref="HttpClient"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class HttpClientExtensions
    {
        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as JSON.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value)
        {
            return client.PostAsJsonAsync(requestUri, value, CancellationToken.None);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as JSON.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, new JsonMediaTypeFormatter(), cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as JSON.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value)
        {
            return client.PostAsJsonAsync(requestUri, value, CancellationToken.None);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as JSON.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, new JsonMediaTypeFormatter(), cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as XML.
        /// </summary>
        /// <remarks>
        /// This method uses the default instance of <see cref="XmlMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PostAsXmlAsync<T>(this HttpClient client, string requestUri, T value)
        {
            return client.PostAsXmlAsync(requestUri, value, CancellationToken.None);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as XML.
        /// </summary>
        /// <remarks>
        /// This method uses the default instance of <see cref="XmlMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PostAsXmlAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, new XmlMediaTypeFormatter(), cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as XML.
        /// </summary>
        /// <remarks>
        /// This method uses the default instance of <see cref="XmlMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PostAsXmlAsync<T>(this HttpClient client, Uri requestUri, T value)
        {
            return client.PostAsXmlAsync(requestUri, value, CancellationToken.None);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as XML.
        /// </summary>
        /// <remarks>
        /// This method uses the default instance of <see cref="XmlMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PostAsXmlAsync<T>(this HttpClient client, Uri requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, new XmlMediaTypeFormatter(), cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PostAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter)
        {
            return client.PostAsync(requestUri, value, formatter, CancellationToken.None);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PostAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, formatter, mediaType: (MediaTypeHeaderValue)null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PostAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter, string mediaType)
        {
            return client.PostAsync(requestUri, value, formatter, mediaType, CancellationToken.None);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter, string mediaType, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, formatter, ObjectContent.BuildHeaderValue(mediaType), cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "The caller is responsible for disposing the object")]
        [SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings", Justification = "The called method will convert to Uri instance.")]
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType, CancellationToken cancellationToken)
        {
            if (client == null)
            {
                throw Error.ArgumentNull("client");
            }

            var content = new ObjectContent<T>(value, formatter, mediaType);

            return client.PostAsync(requestUri, content, cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PostAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter)
        {
            return client.PostAsync(requestUri, value, formatter, CancellationToken.None);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PostAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, formatter, mediaType: (MediaTypeHeaderValue)null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PostAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter, string mediaType)
        {
            return client.PostAsync(requestUri, value, formatter, mediaType, CancellationToken.None);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter, string mediaType, CancellationToken cancellationToken)
        {
            return client.PostAsync(requestUri, value, formatter, ObjectContent.BuildHeaderValue(mediaType), cancellationToken);
        }

        /// <summary>
        /// Sends a POST request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "The caller is responsible for disposing the object")]
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType, CancellationToken cancellationToken)
        {
            if (client == null)
            {
                throw Error.ArgumentNull("client");
            }

            var content = new ObjectContent<T>(value, formatter, mediaType);

            return client.PostAsync(requestUri, content, cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as JSON.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string requestUri, T value)
        {
            return client.PutAsJsonAsync(requestUri, value, CancellationToken.None);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as JSON.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PutAsync(requestUri, value, new JsonMediaTypeFormatter(), cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as JSON.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value)
        {
            return client.PutAsJsonAsync(requestUri, value, CancellationToken.None);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as JSON.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="JsonMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PutAsync(requestUri, value, new JsonMediaTypeFormatter(), cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as XML.
        /// </summary>
        /// <remarks>
        /// This method uses a default instance of <see cref="XmlMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PutAsXmlAsync<T>(this HttpClient client, string requestUri, T value)
        {
            return client.PutAsXmlAsync(requestUri, value, CancellationToken.None);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as XML.
        /// </summary>
        /// <remarks>
        /// This method uses the default instance of <see cref="XmlMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PutAsXmlAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PutAsync(requestUri, value, new XmlMediaTypeFormatter(), cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as XML.
        /// </summary>
        /// <remarks>
        /// This method uses the default instance of <see cref="XmlMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PutAsXmlAsync<T>(this HttpClient client, Uri requestUri, T value)
        {
            return client.PutAsXmlAsync(requestUri, value, CancellationToken.None);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with the given <paramref name="value"/> serialized
        /// as XML.
        /// </summary>
        /// <remarks>
        /// This method uses the default instance of <see cref="XmlMediaTypeFormatter"/>.
        /// </remarks>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PutAsXmlAsync<T>(this HttpClient client, Uri requestUri, T value, CancellationToken cancellationToken)
        {
            return client.PutAsync(requestUri, value, new XmlMediaTypeFormatter(), cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PutAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter)
        {
            return client.PutAsync(requestUri, value, formatter, CancellationToken.None);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PutAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter, CancellationToken cancellationToken)
        {
            return client.PutAsync(requestUri, value, formatter, mediaType: (MediaTypeHeaderValue)null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PutAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter, string mediaType)
        {
            return client.PutAsync(requestUri, value, formatter, mediaType, CancellationToken.None);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter, string mediaType, CancellationToken cancellationToken)
        {
            return client.PutAsync(requestUri, value, formatter, ObjectContent.BuildHeaderValue(mediaType), cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#", Justification = "We want to support URIs as strings")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "The caller is responsible for disposing the object")]
        [SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings", Justification = "The called method will convert to Uri instance.")]
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, string requestUri, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType, CancellationToken cancellationToken)
        {
            if (client == null)
            {
                throw Error.ArgumentNull("client");
            }

            var content = new ObjectContent<T>(value, formatter, mediaType);

            return client.PutAsync(requestUri, content, cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PutAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter)
        {
            return client.PutAsync(requestUri, value, formatter, CancellationToken.None);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PutAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter, CancellationToken cancellationToken)
        {
            return client.PutAsync(requestUri, value, formatter, mediaType: (MediaTypeHeaderValue)null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <seealso cref="PutAsync{T}(HttpClient, string, T, MediaTypeFormatter, string, CancellationToken)"/>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter, string mediaType)
        {
            return client.PutAsync(requestUri, value, formatter, mediaType, CancellationToken.None);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter, string mediaType, CancellationToken cancellationToken)
        {
            return client.PutAsync(requestUri, value, formatter, ObjectContent.BuildHeaderValue(mediaType), cancellationToken);
        }

        /// <summary>
        /// Sends a PUT request as an asynchronous operation to the specified Uri with <paramref name="value"/>
        /// serialized using the given <paramref name="formatter"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="client">The client used to make the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="value">The value that will be placed in the request's entity body.</param>
        /// <param name="formatter">The formatter used to serialize the <paramref name="value"/>.</param>
        /// <param name="mediaType">The authoritative value of the request's content's Content-Type header. Can be <c>null</c> in which case the
        /// <paramref name="formatter">formatter's</paramref> default content type will be used.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task object representing the asynchronous operation.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "The caller is responsible for disposing the object")]
        public static Task<HttpResponseMessage> PutAsync<T>(this HttpClient client, Uri requestUri, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType, CancellationToken cancellationToken)
        {
            if (client == null)
            {
                throw Error.ArgumentNull("client");
            }

            var content = new ObjectContent<T>(value, formatter, mediaType);

            return client.PutAsync(requestUri, content, cancellationToken);
        }
    }
}
