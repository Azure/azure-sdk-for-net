// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel.Rest;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline;

internal class MessageAdapter : HttpMessage
{
    private PipelineMessage _message;

    public MessageAdapter(PipelineMessage message)  : base(new RequestAdapter(message), new ResponseClassifier())
    {
        _message = message;
    }
}

internal class RequestAdapter : Request
{
    private PipelineMessage _message;

    public RequestAdapter(PipelineMessage message) => _message = message;

    public override string ClientRequestId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void Dispose()
    {
    }

    protected internal override void AddHeader(string name, string value)
    {
        throw new NotImplementedException();
    }

    protected internal override bool ContainsHeader(string name)
    {
        throw new NotImplementedException();
    }

    protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
    {
        throw new NotImplementedException();
    }

    protected internal override bool RemoveHeader(string name)
    {
        throw new NotImplementedException();
    }

    protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
    {
        throw new NotImplementedException();
    }

    protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
    {
        throw new NotImplementedException();
    }
}

internal class ClientOptionsAdapter : ClientOptions
{
    private RequestOptions _options;
    public ClientOptionsAdapter(RequestOptions options)
        => _options = options;
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
