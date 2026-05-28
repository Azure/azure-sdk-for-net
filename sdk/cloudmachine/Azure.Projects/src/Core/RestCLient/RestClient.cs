// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.Core.Rest
{
    /// <summary>
    /// A simple REST client that sends HTTP requests and receives responses.
    /// </summary>
    public class RestClient
    {
        private readonly ClientPipeline _pipeline;

        /// <summary>
        /// A shared instance of the RestClient class.
        /// </summary>
        public static RestClient Shared { get; } = new RestClient();

        /// <summary>
        /// Initializes a new instance of the RestClient class.
        /// </summary>
        public RestClient() : this(default(RestClientOptions))
        {
        }

        /// <summary>
        /// Initializes a new instance of the RestClient class with the specified authentication policy.
        /// </summary>
        /// <param name="auth"></param>
        public RestClient(PipelinePolicy auth) : this(CreateOptions(auth))
       {
        }

        private static RestClientOptions CreateOptions(PipelinePolicy auth)
        {
            RestClientOptions options = new();
            options.AddPolicy(auth, PipelinePosition.PerTry);
            return options;
        }

        private RestClient(RestClientOptions options = default)
        {
            options ??= new RestClientOptions();
            _pipeline = ClientPipeline.Create(options);
        }

        /// <summary>
        /// Sends a GET request to the specified URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public PipelineResponse Get(string uri, RequestOptions options = default)
        {
            PipelineMessage message = Create("GET", new Uri(uri));
            return Send(message, options);
        }

        /// <summary>
        /// Sends a POST request to the specified URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="content"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public PipelineResponse Post(string uri, BinaryContent content, RequestOptions options = default)
        {
            PipelineMessage message = Create("POST", new Uri(uri));
            message.Request.Content = content;
            return Send(message, options);
        }

        /// <summary>
        /// Sends a PUT request to the specified URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="content"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public PipelineResponse Put(string uri, BinaryContent content, RequestOptions options = default)
        {
            PipelineMessage message = Create("PUT", new Uri(uri));
            message.Request.Content = content;
            return Send(message, options);
        }

        /// <summary>
        /// Sends a DELETE request to the specified URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="content"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public PipelineResponse Patch(string uri, BinaryContent content, RequestOptions options = default)
        {
            PipelineMessage message = Create("PATCH", new Uri(uri));
            message.Request.Content = content;
            return Send(message, options);
        }

        /// <summary>
        /// Sends a request with the specified message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public PipelineResponse Send(PipelineMessage message, RequestOptions options = default)
        {
            if (options != default) message.Apply(options);
            _pipeline.Send(message);
            return message.Response!;
        }

        /// <summary>
        /// Creates a new PipelineMessage with the specified method and URI.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public PipelineMessage Create(string method, Uri uri)
        {
            PipelineMessage message = _pipeline.CreateMessage();
            message.Request.Method = method;
            message.Request.Uri = uri;
            return message;
        }
    }
}
