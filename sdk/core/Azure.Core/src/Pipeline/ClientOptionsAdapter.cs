// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core;
using Azure;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core;

internal class HttpMessageToPipelineMessageAdapter : PipelineMessage
{
    internal HttpMessage _message;

    public HttpMessageToPipelineMessageAdapter(HttpMessage message)
    {
        _message = message;
    }
}

internal class PipelineMessageToHttpMessageAdapter : HttpMessage
{
    private PipelineMessage _message;

    public PipelineMessageToHttpMessageAdapter(PipelineMessage message) : base(new RequestAdapter(message), new ResponseClassifier())
    {
        _message = message;
    }
}

internal class RequestAdapter : Request
{
    private PipelineMessage _message;

    public RequestAdapter(PipelineMessage message) => _message = message;

    public override string ClientRequestId { get; set; } = Guid.NewGuid().ToString();

    public override void Dispose()
    {
    }

    protected internal override void AddHeader(string name, string value)
        => _message.AddHeader(name, value);

    protected internal override bool ContainsHeader(string name)
    {
        throw new NotImplementedException();
    }

    protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
    {
        throw new NotImplementedException();
    }

    protected internal override bool RemoveHeader(string name)
        => _message.RemoveHeader(name);

    protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
        => _message.TryGetHeader(name, out value);

    protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
    {
        throw new NotImplementedException();
    }
}

internal class ClientOptionsAdapter : ClientOptions
{
    private RequestOptions _options;
    public ClientOptionsAdapter(RequestOptions options)
    {
        _options = options;
        if (options.Transport != null)
        {
            Transport = new TransportAdapter(options.Transport);
        }
    }
}

internal class TransportAdapter : HttpPipelineTransport
{
    private PipelineTransport _transport;

    public TransportAdapter(PipelineTransport transport)
    {
        _transport = transport;
    }
    public override Request CreateRequest()
    {
        var message = _transport.CreateRequest();
        return new RequestAdapter(message);
    }

    public override void Process(HttpMessage message)
    {
        Console.WriteLine(message.ToString());
    }

    public override ValueTask ProcessAsync(HttpMessage message)
    {
        Console.WriteLine(message.ToString());
        return default;
    }
}

internal class PolicyAdapter : HttpPipelinePolicy
    {
        private PipelinePolicy _policy;

        public PolicyAdapter(PipelinePolicy policy) => _policy = policy;
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            throw new NotImplementedException();
        }
    }
