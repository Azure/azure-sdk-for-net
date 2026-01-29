// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel.Tests.Pipeline;

public class CustomPipelineProcessorTests
{
    [Test]
    public void EmptyProcessorWontMoveNext()
    {
        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        IEnumerator<PipelinePolicy> enumerator = processor.GetEnumerator();
        Assert.That(enumerator.MoveNext(), Is.False);
    }

    [Test]
    public void AddsPerCallPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] policies = new PipelinePolicy[2];
        policies[0] = new ObservablePolicy("A");
        policies[1] = new TerminalPolicy("LastPolicy");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: policies,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(4));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsPerTryPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] policies = new PipelinePolicy[2];
        policies[0] = new ObservablePolicy("A");
        policies[1] = new TerminalPolicy("LastPolicy");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(4));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsBeforeTransportPoliciesToEmptyPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] policies = new PipelinePolicy[2];
        policies[0] = new ObservablePolicy("A");
        policies[1] = new TerminalPolicy("LastPolicy");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perTryPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            beforeTransportPolicies: policies,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(4));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsAllPolicyTypesToEmptyPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] perCall = new PipelinePolicy[1];
        perCall[0] = new ObservablePolicy("A");

        PipelinePolicy[] perTry = new PipelinePolicy[2];
        perTry[0] = new ObservablePolicy("B");
        perTry[1] = new ObservablePolicy("C");

        PipelinePolicy[] beforeTransport = new PipelinePolicy[2];
        beforeTransport[0] = new ObservablePolicy("D");
        beforeTransport[1] = new TerminalPolicy("LastPolicy");

        ClientPipeline.RequestOptionsProcessor processor = new(
            fixedPolicies: ReadOnlyMemory<PipelinePolicy>.Empty,
            perCallPolicies: perCall,
            perTryPolicies: perTry,
            beforeTransportPolicies: beforeTransport,
            perCallIndex: 0,
            perTryIndex: 0,
            beforeTransportIndex: 0);

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(10));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsPerCallPoliciesAtStartOfPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(12));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
    }

    [Test]
    public void AddsPerCallPoliciesAtEndOfPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(12));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsPerCallPoliciesMidPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[4];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new ObservablePolicy("C");
        original[3] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(12));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsPerTryPoliciesAtStartOfPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(12));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
    }

    [Test]
    public void AddsPerTryPoliciesAtEndOfPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(12));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsPerTryPoliciesMidPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[4];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new ObservablePolicy("C");
        original[3] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(12));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsPerCallAndPerTryPoliciesAtStartOfPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(14));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:F"));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
        Assert.That(observations[index++], Is.EqualTo("Response:F"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
    }

    [Test]
    public void AddsPerCallAndPerTryPoliciesAtEndOfPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[3];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(14));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:F"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:F"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void AddsPerCallAndPerTryPoliciesMidPipeline()
    {
        PipelineRequest request = new MockPipelineRequest();
        PipelineMessage message = new PipelineMessage(request);

        PipelinePolicy[] original = new PipelinePolicy[5];
        original[0] = new ObservablePolicy("A");
        original[1] = new ObservablePolicy("B");
        original[2] = new ObservablePolicy("C");
        original[3] = new ObservablePolicy("D");
        original[4] = new TerminalPolicy("LastPolicy");

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

        processor.Process(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(18));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:E"));
        Assert.That(observations[index++], Is.EqualTo("Request:F"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:G"));
        Assert.That(observations[index++], Is.EqualTo("Request:H"));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Request:D"));
        Assert.That(observations[index++], Is.EqualTo("Request:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:LastPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:D"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
        Assert.That(observations[index++], Is.EqualTo("Response:H"));
        Assert.That(observations[index++], Is.EqualTo("Response:G"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:F"));
        Assert.That(observations[index++], Is.EqualTo("Response:E"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }
}

#region Extension helpers

public static class RequestOptionsProcessorExtensions
{
    internal static void Process(this ClientPipeline.RequestOptionsProcessor processor, PipelineMessage message)
    {
        processor[0].Process(message, processor, 0);
    }
}
#endregion
