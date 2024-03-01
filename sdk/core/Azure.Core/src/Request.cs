// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Represents an HTTP request. Use <see cref="HttpPipeline.CreateMessage()"/>
    /// or <see cref="HttpPipeline.CreateRequest"/> to create an instance.
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public abstract class Request : PipelineRequest
#pragma warning restore AZC0012 // Avoid single word type names
    {
        private RequestUriBuilder? _uriBuilder;
        private string _method = RequestMethod.Get.Method;
        private RequestContent? _content;

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
        /// Gets or sets the request HTTP method.
        /// </summary>
        public new virtual RequestMethod Method
        {
            get => RequestMethod.Parse(MethodCore);
            set => MethodCore = value.Method;
        }

        /// <summary>
        /// Gets or sets the request content.
        /// </summary>
        public new virtual RequestContent? Content
        {
            get => (RequestContent?)ContentCore;
            set => ContentCore = value;
        }

        /// <summary>
        /// Gets or sets the client request id that was sent to the server as <c>x-ms-client-request-id</c> headers.
        /// </summary>
        public abstract string ClientRequestId { get; set; }

        /// <summary>
        /// Gets the request HTTP headers.
        /// </summary>
        public new RequestHeaders Headers => new(this);

        internal TimeSpan? NetworkTimeout { get; set; }

        #region Overrides for "Core" methods from the PipelineRequest Template pattern

        /// <summary>
        /// Gets or sets the value of <see cref="PipelineRequest.Method"/> on
        /// the base <see cref="PipelineRequest"/> type.
        /// </summary>
        protected override string MethodCore
        {
            get => _method;
            set => _method = value;
        }

        /// <summary>
        /// Gets or sets the value of <see cref="PipelineRequest.Uri"/> on
        /// the base <see cref="PipelineRequest"/> type.
        /// </summary>
        protected override Uri? UriCore
        {
            // The _uriBuilder field on this type is the source of truth for
            // the type's Uri implementation. Accessing it through the Uri
            // property allows us to reuse the lazy-instantation implemented
            // there.
            get => Uri.ToUri();

            // This setter effectively adapts the BCL Uri type to the Azure.Core
            // RequestUriBuilder interface, in that the only way
            // RequestUriBuilder provides to fully reset the Uri (i.e. from null)
            // is to create a new instance of the builder.
            set
            {
                if (value is null)
                {
                    Uri = new();
                }
                else
                {
                    Uri.Reset(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of <see cref="PipelineRequest.Content"/> on
        /// the base <see cref="PipelineRequest"/> type.
        /// </summary>
        protected override BinaryContent? ContentCore
        {
            get => _content;
            set => _content = value switch
            {
                RequestContent content => content,
                BinaryContent => new RequestContent.BinaryContentAdapter(value),
                null => null,
            };
        }

        /// <summary>
        /// Gets the value of <see cref="PipelineRequest.Headers"/> on
        /// the base <see cref="PipelineRequest"/> type.
        /// </summary>
        protected override PipelineRequestHeaders HeadersCore
            => new RequestHeadersAdapter(Headers);

        #endregion

        #region Abstract header methods
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
        #endregion

        /// <summary>
        /// This adapter adapts the Azure.Core <see cref="RequestHeaders"/>
        /// type to the System.ClientModel <see cref="PipelineRequestHeaders"/>
        /// interface, so that it can <see cref="Request"/> can implement the
        /// <see cref="HeadersCore"/> property inherited from
        /// <see cref="PipelineRequest"/>.
        /// </summary>
        private sealed class RequestHeadersAdapter : PipelineRequestHeaders
        {
            /// <summary>
            /// Headers on the Azure.Core.Request type to adapt to.
            /// </summary>
            private readonly RequestHeaders _headers;

            public RequestHeadersAdapter(RequestHeaders headers)
                => _headers = headers;

            public override void Add(string name, string value)
                => _headers.Add(name, value);

            public override bool Remove(string name)
                => _headers.Remove(name);

            public override void Set(string name, string value)
                => _headers.SetValue(name, value);

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
                => GetHeadersCompositeValues().GetEnumerator();

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
