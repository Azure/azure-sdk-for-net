// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace System.ClientModel.Tests;

public class ClientPipelineTests
{
    [Test]
    public void RequestOptionsCanCustomizePipeline()
    {
        PipelineOptions clientOptions = new SimpleClientOptions();
        clientOptions.RetryPolicy = new ObservablePolicy("RetryPolicy");
        clientOptions.Transport = new ObservableTransport("Transport");

        ClientPipeline pipeline = ClientPipeline.Create(clientOptions);

        RequestOptions requestOptions = new RequestOptions();
        requestOptions.AddPolicy(new ObservablePolicy("A"), PipelinePosition.PerCall);
        requestOptions.AddPolicy(new ObservablePolicy("B"), PipelinePosition.PerTry);

        PipelineMessage message = pipeline.CreateMessage();
        message.Apply(requestOptions);
        pipeline.Send(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(7, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }

    #region Helpers
    private class SimpleClientOptions : PipelineOptions { }

    private class ObservableTransport : PipelineTransport
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

        // TODO: It may be too hard to mock the transport.
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

            protected override InputContent? GetContentCore()
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

            protected override void SetContentCore(InputContent? content)
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

    private class ObservablePolicy : PipelinePolicy
    {
        public string Id { get; }

        public ObservablePolicy(string id)
        {
            Id = id;
        }

        public override void Process(PipelineMessage message, PipelineProcessor pipeline)
        {
            Stamp(message, "Request");

            pipeline.ProcessNext();

            Stamp(message, "Response");
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
        {
            Stamp(message, "Request");

            await pipeline.ProcessNextAsync().ConfigureAwait(false);

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
    }
    #endregion
}
