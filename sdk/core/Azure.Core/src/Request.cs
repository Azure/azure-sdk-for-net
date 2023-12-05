// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Represents an HTTP request. Use <see cref="HttpPipeline.CreateMessage()"/> or <see cref="HttpPipeline.CreateRequest"/> to create an instance.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Request : PipelineRequest
#pragma warning restore AZC0012 // Avoid single word type names
    {
        private RequestMethod _method;
        private RequestUriBuilder? _uriBuilder;
        private RequestContent? _content;

        private string? _clientRequestId;

        /// <summary>
        /// Gets or sets the request HTTP method.
        /// </summary>
        public new virtual RequestMethod Method
        {
            get => _method;
            set => SetMethodCore(value.Method);
        }

        /// <summary>
        /// Gets or sets and instance of <see cref="RequestUriBuilder"/> used to create the Uri.
        /// </summary>
        public new virtual RequestUriBuilder Uri
        {
            get => _uriBuilder ??= new RequestUriBuilder();
            set
            {
                Argument.AssertNotNull(value, nameof(value));

                _uriBuilder = value;
            }
        }

        /// <summary>
        /// Gets or sets the request content.
        /// </summary>
        public new virtual RequestContent? Content
        {
            get => (RequestContent?)GetContentCore();
            set => SetContentCore(value);
        }

        /// <summary>
        /// Gets or sets the client request id that was sent to the server as <c>x-ms-client-request-id</c> headers.
        /// </summary>
        public virtual string ClientRequestId
        {
            get => _clientRequestId ??= Guid.NewGuid().ToString();
            set
            {
                Argument.AssertNotNull(value, nameof(value));
                _clientRequestId = value;
            }
        }

        /// <summary>
        /// Gets the request HTTP headers.
        /// </summary>
        public new RequestHeaders Headers => new(this);

        #region Overrides for "Core" methods from the PipelineRequest Template pattern

        /// <summary>
        /// TBD.
        /// </summary>
        /// <returns></returns>
        protected override string GetMethodCore()
            => _method.Method;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="method"></param>
        protected override void SetMethodCore(string method)
            => _method = RequestMethod.Parse(method);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <returns></returns>
        protected override Uri GetUriCore()
            => Uri.ToUri();

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="uri"></param>
        protected override void SetUriCore(Uri uri)
            => Uri.Reset(uri);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <returns></returns>
        protected override InputContent? GetContentCore()
            => _content;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="content"></param>
        protected override void SetContentCore(InputContent? content)
            => _content = (RequestContent?)content;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <returns></returns>
        protected override MessageHeaders GetHeadersCore()
            => new AzureCoreMessageHeaders(Headers);

        #endregion

        /// <summary>
        /// Adds a header value to the header collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        protected internal abstract void AddHeader(string name, string value);

        /// <summary>
        /// Returns header value if the header is stored in the collection. If the header has multiple values they are going to be joined with a comma.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The reference to populate with value.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        protected internal abstract bool TryGetHeader(string name, [NotNullWhen(true)] out string? value);

        /// <summary>
        /// Returns header values if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="values">The reference to populate with values.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        protected internal abstract bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values);

        /// <summary>
        /// Returns <c>true</c> if the header is stored in the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <returns><c>true</c> if the specified header is stored in the collection, otherwise <c>false</c>.</returns>
        protected internal abstract bool ContainsHeader(string name);

        /// <summary>
        /// Sets a header value the header collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        protected internal virtual void SetHeader(string name, string value)
        {
            RemoveHeader(name);
            AddHeader(name, value);
        }

        /// <summary>
        /// Removes the header from the collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        protected internal abstract bool RemoveHeader(string name);

        /// <summary>
        /// Returns an iterator enumerating <see cref="HttpHeader"/> in the request.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/> enumerating <see cref="HttpHeader"/> in the response.</returns>
        protected internal abstract IEnumerable<HttpHeader> EnumerateHeaders();

        /// <summary>
        /// Backwards adapter to MessageHeaders to implement GetHeadersCore
        /// </summary>
        private sealed class AzureCoreMessageHeaders : MessageHeaders
        {
            /// <summary>
            /// Headers on the Azure.Core.Request type to adapt to.
            /// </summary>
            private readonly RequestHeaders _headers;

            public AzureCoreMessageHeaders(RequestHeaders headers)
                => _headers = headers;

            public override int Count => _headers.Count();

            public override void Add(string name, string value)
                => _headers.Add(name, value);

            public override bool Remove(string name)
                => _headers.Remove(name);

            public override void Set(string name, string value)
                => _headers.SetValue(name, value);

            public override bool TryGetHeaders(out IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
            {
                headers = GetHeadersEnumerableValues();
                return true;
            }

            private IEnumerable<KeyValuePair<string, IEnumerable<string>>> GetHeadersEnumerableValues()
            {
                foreach (HttpHeader header in _headers)
                {
                    yield return new KeyValuePair<string, IEnumerable<string>>(header.Name, GetHeaderValues(header.Value));
                }
            }

            private IEnumerable<string> GetHeaderValues(string compositeHeaderValue)
                => compositeHeaderValue.Split(';');

            public override bool TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers)
            {
                headers = GetHeadersCompositeValues();
                return true;
            }

            private IEnumerable<KeyValuePair<string, string>> GetHeadersCompositeValues()
            {
                foreach (HttpHeader header in _headers)
                {
                    yield return new KeyValuePair<string, string>(header.Name, header.Value);
                }
            }

            public override bool TryGetValue(string name, out string? value)
                => _headers.TryGetValue(name, out value);

            public override bool TryGetValues(string name, out IEnumerable<string>? values)
                => _headers.TryGetValues(name, out values);
        }
    }
}
