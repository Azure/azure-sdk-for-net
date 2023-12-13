// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TestHelpers.Internal;

internal class SimpleClientOptions : PipelineOptions { }

internal class ObservableTransport : PipelineTransport
{
    public string Id { get; }

    public ObservableTransport(string id)
    {
        Id = id;
    }

    protected override PipelineMessage CreateMessageCore()
    {
        return new TransportMessage();
    }

    protected override void ProcessCore(PipelineMessage message)
    {
        Stamp(message, "Transport");

        if (message is TransportMessage transportMessage)
        {
            transportMessage.SetResponse();
        }
    }

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        Stamp(message, "Transport");

        if (message is TransportMessage transportMessage)
        {
            transportMessage.SetResponse();
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

    private class TransportMessage : PipelineMessage
    {
        public TransportMessage() : this(new TransportRequest())
        {
        }

        protected internal TransportMessage(PipelineRequest request) : base(request)
        {
        }

        public void SetResponse()
        {
            Response = new TransportResponse();
        }
    }

    private class TransportRequest : PipelineRequest
    {
        public TransportRequest() { }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        protected override BinaryContent? GetContentCore()
        {
            throw new NotImplementedException();
        }

        protected override MessageHeaders GetHeadersCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetMethodCore()
        {
            throw new NotImplementedException();
        }

        protected override Uri GetUriCore()
        {
            throw new NotImplementedException();
        }

        protected override void SetContentCore(BinaryContent? content)
        {
            throw new NotImplementedException();
        }

        protected override void SetMethodCore(string method)
        {
            throw new NotImplementedException();
        }

        protected override void SetUriCore(Uri uri)
        {
            throw new NotImplementedException();
        }
    }

    private class TransportResponse : PipelineResponse
    {
        public override int Status => 0;

        public override string ReasonPhrase => throw new NotImplementedException();

        public override Stream? ContentStream
        {
            get => null;
            set => throw new NotImplementedException();
        }

        protected override MessageHeaders GetHeadersCore()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

internal class ObservablePolicy : PipelinePolicy
{
    public string Id { get; }

    public ObservablePolicy(string id)
    {
        Id = id;
    }

    public override void Process(PipelineMessage message, IEnumerable<PipelinePolicy> pipeline)
    {
        Stamp(message, "Request");

        ProcessNext(message, pipeline);

        Stamp(message, "Response");
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IEnumerable<PipelinePolicy> pipeline)
    {
        Stamp(message, "Request");

        await ProcessNextAsync(message, pipeline).ConfigureAwait(false);

        Stamp(message, "Response");
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

    public static List<string> GetData(PipelineMessage message)
    {
        message.TryGetProperty(typeof(ObservablePolicy), out object? prop);

        return prop is List<string> list ? list : new List<string>();
    }

    public override string ToString() => $"ObservablePolicy:{Id}";
}

internal class RetriableTransport : PipelineTransport
{
    private readonly int[] _codes;
    private int _current;

    public string Id { get; }

    public RetriableTransport(string id, params int[] codes)
    {
        Id = id;
        _codes = codes;
    }

    private bool TryGetNextStatus(out int status)
    {
        if (_current < _codes.Length)
        {
            status = _codes[_current++];
            return true;
        }

        status = 0;
        return false;
    }

    protected override PipelineMessage CreateMessageCore()
    {
        return new RetriableTransportMessage();
    }

    protected override void ProcessCore(PipelineMessage message)
    {
        Stamp(message, "Transport");

        if (message is RetriableTransportMessage transportMessage &&
            TryGetNextStatus(out int status))
        {
            transportMessage.SetResponse(status);
        }
    }

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        Stamp(message, "Transport");

        if (message is RetriableTransportMessage transportMessage &&
            TryGetNextStatus(out int status))
        {
            transportMessage.SetResponse(status);
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
        public TransportRequest() { }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        protected override BinaryContent? GetContentCore()
        {
            throw new NotImplementedException();
        }

        protected override MessageHeaders GetHeadersCore()
        {
            throw new NotImplementedException();
        }

        protected override string GetMethodCore()
        {
            throw new NotImplementedException();
        }

        protected override Uri GetUriCore()
        {
            throw new NotImplementedException();
        }

        protected override void SetContentCore(BinaryContent? content)
        {
            throw new NotImplementedException();
        }

        protected override void SetMethodCore(string method)
        {
            throw new NotImplementedException();
        }

        protected override void SetUriCore(Uri uri)
        {
            throw new NotImplementedException();
        }
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

        protected override MessageHeaders GetHeadersCore()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
