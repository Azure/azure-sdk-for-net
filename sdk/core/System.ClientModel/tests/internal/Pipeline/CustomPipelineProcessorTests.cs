// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Internal.Primitives;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Tests;

public class CustomPipelineProcessorTests
{
    [Test]
    public void EmptyProcessorReturnsFalse()
    {
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0);

        Assert.IsFalse(processor.ProcessNext());
    }

    [Test]
    public void AddsPerCallPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] policies = new PipelinePolicy[1];
        policies[0] = new ObservablePolicy("A");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0);

        Assert.IsTrue(processor.ProcessNext());

        List<string> observations = ObservablePolicy.GetData(message);

        Assert.AreEqual(2, observations.Count);
        Assert.AreEqual("Request:A", observations[0]);
        Assert.AreEqual("Response:A", observations[1]);
    }

    [Test]
    public void AddsPerTryPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] policies = new PipelinePolicy[1];
        policies[0] = new ObservablePolicy("A");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 0);

        Assert.IsTrue(processor.ProcessNext());

        List<string> observations = ObservablePolicy.GetData(message);

        Assert.AreEqual(2, observations.Count);
        Assert.AreEqual("Request:A", observations[0]);
        Assert.AreEqual("Response:A", observations[1]);
    }

    [Test]
    public void AddsPerCallAndPerTryPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] perCall = new PipelinePolicy[1];
        perCall[0] = new ObservablePolicy("A");

        PipelinePolicy[] perTry = new PipelinePolicy[1];
        perTry[0] = new ObservablePolicy("B");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: perCall,
            perTryPolicies: perTry,
            perCallIndex: 0,
            perTryIndex: 0);

        Assert.IsTrue(processor.ProcessNext());

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
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] policies = new PipelinePolicy[3];
        policies[0] = new ObservablePolicy("C");
        policies[1] = new ObservablePolicy("D");
        policies[2] = new ObservablePolicy("E");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: original,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0);

        Assert.IsTrue(processor.ProcessNext());

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
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] policies = new PipelinePolicy[3];
        policies[0] = new ObservablePolicy("C");
        policies[1] = new ObservablePolicy("D");
        policies[2] = new ObservablePolicy("E");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: original,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 2,
            perTryIndex: 0);

        Assert.IsTrue(processor.ProcessNext());

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
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new ObservablePolicy("C");

        PipelinePolicy[] policies = new PipelinePolicy[2];
        policies[0] = new ObservablePolicy("D");
        policies[1] = new ObservablePolicy("E");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: original,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 2,
            perTryIndex: 0);

        Assert.IsTrue(processor.ProcessNext());

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
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] policies = new PipelinePolicy[3];
        policies[0] = new ObservablePolicy("C");
        policies[1] = new ObservablePolicy("D");
        policies[2] = new ObservablePolicy("E");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: original,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 0);

        Assert.IsTrue(processor.ProcessNext());

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
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[2];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");

        PipelinePolicy[] policies = new PipelinePolicy[3];
        policies[0] = new ObservablePolicy("C");
        policies[1] = new ObservablePolicy("D");
        policies[2] = new ObservablePolicy("E");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: original,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 2);

        Assert.IsTrue(processor.ProcessNext());

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
        PipelineRequest request = new HttpPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new ObservablePolicy("C");

        PipelinePolicy[] policies = new PipelinePolicy[2];
        policies[0] = new ObservablePolicy("D");
        policies[1] = new ObservablePolicy("E");

        ClientPipeline.CustomPipelineProcessor processor = new(message,
            original: original,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 2);

        Assert.IsTrue(processor.ProcessNext());

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

    #region Helpers
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
