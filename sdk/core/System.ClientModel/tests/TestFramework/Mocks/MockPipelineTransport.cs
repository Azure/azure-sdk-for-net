// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockPipelineTransport : PipelineTransport
{
    private readonly Func<int, int> _responseFactory;
    private int _retryCount;

    public string Id { get; }

    public Action<int>? OnSendingRequest { get; set; }
    public Action<int>? OnReceivedResponse { get; set; }

    public MockPipelineTransport(string id, params int[] codes)
        : this(id, i => codes[i])
    {
    }

    public MockPipelineTransport(string id, Func<int, int> responseFactory)
    {
        Id = id;
        _responseFactory = responseFactory;
    }

    protected override PipelineMessage CreateMessageCore()
    {
        return new RetriableTransportMessage();
    }

    protected override void ProcessCore(PipelineMessage message)
    {
        try
        {
            Stamp(message, "Transport");

            OnSendingRequest?.Invoke(_retryCount);

            if (message is RetriableTransportMessage transportMessage)
            {
                int status = _responseFactory(_retryCount);
                transportMessage.SetResponse(status);
            }

            OnReceivedResponse?.Invoke(_retryCount);
        }
        finally
        {
            _retryCount++;
        }
    }

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        try
        {
            Stamp(message, "Transport");

            OnSendingRequest?.Invoke(_retryCount);

            if (message is RetriableTransportMessage transportMessage)
            {
                int status = _responseFactory(_retryCount);
                transportMessage.SetResponse(status);
            }

            OnReceivedResponse?.Invoke(_retryCount);
        }
        finally
        {
            _retryCount++;
        }

        return new ValueTask();
    }

    private void Stamp(PipelineMessage message, string prefix)
    {
        List<string> values;

        if (message.TryGetProperty(typeof(ObservablePolicy), out object? prop) &&
            prop is List<string> list)
        {
            values = list;
        }
        else
        {
            values = new List<string>();
            message.SetProperty(typeof(ObservablePolicy), values);
        }

        values.Add($"{prefix}:{Id}");
    }

    private class RetriableTransportMessage : PipelineMessage
    {
        public RetriableTransportMessage() : this(new TransportRequest())
        {
        }

        protected internal RetriableTransportMessage(PipelineRequest request) : base(request)
        {
        }

        public void SetResponse(int status)
        {
            Response = new RetriableTransportResponse(status);
        }
    }

    private class TransportRequest : PipelineRequest
    {
        private Uri _uri;
        private readonly PipelineRequestHeaders _headers;

        public TransportRequest()
        {
            _headers = new MockRequestHeaders();
            _uri = new Uri("https://www.example.com");
        }

        public override void Dispose() { }

        protected override BinaryContent? GetContentCore()
        {
            throw new NotImplementedException();
        }

        protected override PipelineRequestHeaders GetHeadersCore()
            => _headers;

        protected override string GetMethodCore()
        {
            throw new NotImplementedException();
        }

        protected override Uri GetUriCore()
            => _uri;

        protected override void SetContentCore(BinaryContent? content)
        {
            throw new NotImplementedException();
        }

        protected override void SetMethodCore(string method)
        {
            throw new NotImplementedException();
        }

        protected override void SetUriCore(Uri uri)
            => _uri = uri;
    }

    private class RetriableTransportResponse : PipelineResponse
    {
        public RetriableTransportResponse(int status)
        {
            Status = status;
        }

        public override int Status { get; }

        public override string ReasonPhrase => throw new NotImplementedException();

        public override Stream? ContentStream
        {
            get => null;
            set => throw new NotImplementedException();
        }

        protected override PipelineResponseHeaders GetHeadersCore()
        {
            throw new NotImplementedException();
        }

        public override void Dispose() { }
    }
}
