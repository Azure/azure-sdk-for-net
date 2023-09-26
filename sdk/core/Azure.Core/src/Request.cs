// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Experimental.Core;
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
        private RequestUriBuilder? _uri;

        /// <summary>
        /// Gets or sets and instance of <see cref="RequestUriBuilder"/> used to create the Uri.
        /// </summary>
        public new virtual RequestUriBuilder Uri
        {
            get
            {
                return _uri ??= new RequestUriBuilder();
            }
            set
            {
                Argument.AssertNotNull(value, nameof(value));
                _uri = value;
            }
        }

        /// <summary>
        /// TBD.
        /// </summary>
        public abstract string ClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets the request HTTP method.
        /// </summary>
        public new virtual RequestMethod Method
        {
            get
            {
                try
                {
                    return SystemToAzureMethod(base.Method);
                }
                catch (NotSupportedException)
                {
                    // Preserve existing Azure.Core functionality
                    return new RequestMethod();
                }
            }
            set { base.Method = AzureToSystemMethod(value); }
        }

        private static RequestMethod SystemToAzureMethod(HttpMethod verb)
        {
            return verb.Method switch
            {
                "GET" => RequestMethod.Get,
                "POST" => RequestMethod.Post,
                "PUT" => RequestMethod.Put,
                "HEAD" => RequestMethod.Head,
                "DELETE" => RequestMethod.Delete,
                "PATCH" => RequestMethod.Patch,
                _ => new RequestMethod(verb.Method),
            };
        }

        // PATCH value needed for compat with pre-net5.0 TFMs
        private static readonly HttpMethod _patchMethod = new HttpMethod("PATCH");

        private static HttpMethod AzureToSystemMethod(RequestMethod method)
        {
            return method.Method switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "HEAD" => HttpMethod.Head,
                "DELETE" => HttpMethod.Delete,
                "PATCH" => _patchMethod,
                _ => new HttpMethod(method.Method),
            };
            ;
        }

        /// <summary>
        /// Gets or sets the request content.
        /// </summary>

        public new virtual RequestContent? Content
        {
            get => (RequestContent?)base.Content;
            set => base.Content = value;
        }

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
        /// TBD.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public override void SetHeaderValue(string name, string value)
            => SetHeader(name, value);

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
        /// Gets the response HTTP headers.
        /// </summary>
        public RequestHeaders Headers => new(this);
    }
}
