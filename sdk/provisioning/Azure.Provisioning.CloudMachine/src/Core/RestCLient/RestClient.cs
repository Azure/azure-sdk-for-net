// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ClientModel;

namespace Azure
{
    public class RestClient
    {
        private static readonly RestClient _shared = new RestClient();

        private readonly ClientPipeline _pipeline;

        public static RestClient Shared => _shared;

        public RestClient() : this(default(RestClientOptions))
        {
        }

        public RestClient(PipelinePolicy auth) : this(CreateOptions(auth))
        {
        }

        private static RestClientOptions CreateOptions(PipelinePolicy auth)
        {
            RestClientOptions options = new RestClientOptions();
            options.AddPolicy(auth, PipelinePosition.PerTry);
            return options;
        }

        private RestClient(RestClientOptions? options = default)
        {
            if (options == null)
                options = new RestClientOptions();
            _pipeline = ClientPipeline.Create(options);
        }

        public PipelineResponse Get(string uri, RequestOptions? options = default)
        {
            PipelineMessage message = Create("GET", new Uri(uri));
            return Send(message, options);
        }

        public PipelineResponse Post(string uri, BinaryContent content, RequestOptions? options = default)
        {
            PipelineMessage message = Create("POST", new Uri(uri));
            message.Request.Content = content;
            return Send(message, options);
        }

        public PipelineResponse Put(string uri, BinaryContent content, RequestOptions? options = default)
        {
            PipelineMessage message = Create("PUT", new Uri(uri));
            message.Request.Content = content;
            return Send(message, options);
        }

        public PipelineResponse Patch(string uri, BinaryContent content, RequestOptions? options = default)
        {
            PipelineMessage message = Create("PATCH", new Uri(uri));
            message.Request.Content = content;
            return Send(message, options);
        }

        public PipelineResponse Send(PipelineMessage message, RequestOptions? options = default)
        {
            if (options != default) message.Apply(options);
            _pipeline.Send(message);
            return message.Response!;
        }

        public PipelineMessage Create(string method, Uri uri)
        {
            PipelineMessage message = _pipeline.CreateMessage();
            message.Request.Method = method;
            message.Request.Uri = uri;
            return message;
        }
    }
}
