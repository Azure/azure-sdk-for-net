// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Tests;

public class CustomPipelineProcessorTests
{
    [Test]
    public void EmptyProcessorReturnsFalse()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);
    }

    [Test]
    public void ConstructorThrowsForInvalidIndexValues()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        var perCallEx = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: new PipelinePolicy[1],
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 1,
            perTryIndex: 0,
            beforeTransportIndex: 0);
        });

        Assert.AreEqual("perCallIndex", perCallEx!.ParamName);

        perCallEx = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: new PipelinePolicy[1],
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 2,
            perTryIndex: 2,
            beforeTransportIndex: 2);
        });

        Assert.AreEqual("perCallIndex", perCallEx!.ParamName);

        var perTryEx = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: new PipelinePolicy[1],
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 2,
            beforeTransportIndex: 2);
        });

        Assert.AreEqual("perTryIndex", perTryEx!.ParamName);
    }

    [Test]
    public void AddsPerCallPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] policies = new PipelinePolicy[1];
        policies[0] = new ObservablePolicy("A");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        IEnumerator<PipelinePolicy> enumerator = processor.GetEnumerator();
        enumerator.MoveNext();
        PipelinePolicy policy = enumerator.Current;
        policy.ProcessAsync(message, processor);

        //processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        Assert.AreEqual(2, observations.Count);
        Assert.AreEqual("Request:A", observations[0]);
        Assert.AreEqual("Response:A", observations[1]);
    }

    [Test]
    public void AddsPerTryPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] policies = new PipelinePolicy[1];
        policies[0] = new ObservablePolicy("A");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        Assert.AreEqual(2, observations.Count);
        Assert.AreEqual("Request:A", observations[0]);
        Assert.AreEqual("Response:A", observations[1]);
    }

    [Test]
    public void AddsPerCallAndPerTryPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] perCall = new PipelinePolicy[1];
        perCall[0] = new ObservablePolicy("A");

        PipelinePolicy[] perTry = new PipelinePolicy[1];
        perTry[0] = new ObservablePolicy("B");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: perCall,
            perTryPolicies: perTry,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        Assert.AreEqual(4, observations.Count);
        Assert.AreEqual("Request:A", observations[0]);
        Assert.AreEqual("Request:B", observations[1]);
        Assert.AreEqual("Response:B", observations[2]);
        Assert.AreEqual("Response:A", observations[3]);
    }

    [Test]
    public void AddsPerCallPoliciesAtStartOfPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] policies = new PipelinePolicy[3];
        policies[0] = new ObservablePolicy("C");
        policies[1] = new ObservablePolicy("D");
        policies[2] = new ObservablePolicy("E");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(10, observations.Count);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
    }

    [Test]
    public void AddsPerCallPoliciesAtEndOfPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] policies = new PipelinePolicy[3];
        policies[0] = new ObservablePolicy("C");
        policies[1] = new ObservablePolicy("D");
        policies[2] = new ObservablePolicy("E");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 2,
            perTryIndex: 2,
            beforeTransportIndex: 2);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(10, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }

    [Test]
    public void AddsPerCallPoliciesMidPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new ObservablePolicy("C");

        PipelinePolicy[] policies = new PipelinePolicy[2];
        policies[0] = new ObservablePolicy("D");
        policies[1] = new ObservablePolicy("E");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 2,
            perTryIndex: 2,
            beforeTransportIndex: 2);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(10, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }

    [Test]
    public void AddsPerTryPoliciesAtStartOfPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] policies = new PipelinePolicy[3];
        policies[0] = new ObservablePolicy("C");
        policies[1] = new ObservablePolicy("D");
        policies[2] = new ObservablePolicy("E");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(10, observations.Count);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
    }

    [Test]
    public void AddsPerTryPoliciesAtEndOfPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] policies = new PipelinePolicy[3];
        policies[0] = new ObservablePolicy("C");
        policies[1] = new ObservablePolicy("D");
        policies[2] = new ObservablePolicy("E");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 2,
            beforeTransportIndex: 2);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(10, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }

    [Test]
    public void AddsPerTryPoliciesMidPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new ObservablePolicy("C");

        PipelinePolicy[] policies = new PipelinePolicy[2];
        policies[0] = new ObservablePolicy("D");
        policies[1] = new ObservablePolicy("E");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 2,
            beforeTransportIndex: 2);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(10, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }

    [Test]
    public void AddsPerCallAndPerTryPoliciesAtStartOfPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] perCall = new PipelinePolicy[2];
        perCall[0] = new ObservablePolicy("C");
        perCall[1] = new ObservablePolicy("D");

        PipelinePolicy[] perTry = new PipelinePolicy[2];
        perTry[0] = new ObservablePolicy("E");
        perTry[1] = new ObservablePolicy("F");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: perCall,
            perTryPolicies: perTry,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(12, observations.Count);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Request:F", observations[index++]);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
        Assert.AreEqual("Response:F", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
    }

    [Test]
    public void AddsPerCallAndPerTryPoliciesAtEndOfPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] perCall = new PipelinePolicy[2];
        perCall[0] = new ObservablePolicy("C");
        perCall[1] = new ObservablePolicy("D");

        PipelinePolicy[] perTry = new PipelinePolicy[2];
        perTry[0] = new ObservablePolicy("E");
        perTry[1] = new ObservablePolicy("F");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: perCall,
            perTryPolicies: perTry,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 2,
            perTryIndex: 2,
            beforeTransportIndex: 2);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(12, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Request:F", observations[index++]);
        Assert.AreEqual("Response:F", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }

    [Test]
    public void AddsPerCallAndPerTryPoliciesMidPipeline()
    {
        PipelineRequest request = new MockRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[4];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new ObservablePolicy("C");
        original[3] = new ObservablePolicy("D");

        PipelinePolicy[] perCall = new PipelinePolicy[2];
        perCall[0] = new ObservablePolicy("E");
        perCall[1] = new ObservablePolicy("F");

        PipelinePolicy[] perTry = new PipelinePolicy[2];
        perTry[0] = new ObservablePolicy("G");
        perTry[1] = new ObservablePolicy("H");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: original,
            perCallPolicies: perCall,
            perTryPolicies: perTry,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 1,
            perTryIndex: 2,
            beforeTransportIndex: 2);

        processor.GetEnumerator().Current.ProcessAsync(message, processor);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(16, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:E", observations[index++]);
        Assert.AreEqual("Request:F", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Request:G", observations[index++]);
        Assert.AreEqual("Request:H", observations[index++]);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Request:D", observations[index++]);
        Assert.AreEqual("Response:D", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
        Assert.AreEqual("Response:H", observations[index++]);
        Assert.AreEqual("Response:G", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:F", observations[index++]);
        Assert.AreEqual("Response:E", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }

    #region Helpers
    private class ObservablePolicy : PipelinePolicy
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
    }

    internal class MockRequest : PipelineRequest
    {
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
    #endregion
}
