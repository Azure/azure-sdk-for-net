// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal.Resilience;

namespace Azure.AI.AgentServer.Responses.Tests.Unit;

/// <summary>
/// Unit tests for <see cref="ResponseResilienceDispatch"/> — the canonical row-classification
/// and disposition decision site. Verifies exact parity with Python <c>classify_row</c> /
/// <c>decide_disposition</c> across the full <c>(store, background, resilient_background)</c>
/// truth table.
/// </summary>
public class ResponseResilienceDispatchTests
{
    [TestCase(true, true, true, ResponseResilienceDispatch.Row1ResilientBackground)]
    [TestCase(true, true, false, ResponseResilienceDispatch.Row2Background)]
    [TestCase(true, false, true, ResponseResilienceDispatch.Row3Foreground)]
    [TestCase(true, false, false, ResponseResilienceDispatch.Row3Foreground)]
    [TestCase(false, true, true, ResponseResilienceDispatch.Row4Unstored)]
    [TestCase(false, true, false, ResponseResilienceDispatch.Row4Unstored)]
    [TestCase(false, false, true, ResponseResilienceDispatch.Row4Unstored)]
    [TestCase(false, false, false, ResponseResilienceDispatch.Row4Unstored)]
    public void ClassifyRow_MatchesPythonTruthTable(bool store, bool background, bool resilient, int expectedRow)
    {
        Assert.That(ResponseResilienceDispatch.ClassifyRow(store, background, resilient), Is.EqualTo(expectedRow));
    }

    [TestCase(true, true, true, ResponseRecoveryPayload.DispositionReinvoke)]
    [TestCase(true, true, false, ResponseRecoveryPayload.DispositionMarkFailed)]
    [TestCase(true, false, true, ResponseRecoveryPayload.DispositionMarkFailed)]
    [TestCase(false, true, true, ResponseRecoveryPayload.DispositionMarkFailed)]
    [TestCase(false, false, false, ResponseRecoveryPayload.DispositionMarkFailed)]
    public void DecideDisposition_MatchesPython(bool store, bool background, bool resilient, string expected)
    {
        Assert.That(ResponseResilienceDispatch.DecideDisposition(store, background, resilient), Is.EqualTo(expected));
    }

    [TestCase(true, true, true, true)]
    [TestCase(true, true, false, false)]
    [TestCase(true, false, true, false)]
    [TestCase(false, true, true, false)]
    public void IsResilientBackground_OnlyWhenAllThreeFlagsSet(bool store, bool background, bool resilient, bool expected)
    {
        Assert.That(ResponseResilienceDispatch.IsResilientBackground(store, background, resilient), Is.EqualTo(expected));
    }

    [Test]
    public void DispositionConstants_MatchWireValues()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ResponseRecoveryPayload.DispositionReinvoke, Is.EqualTo("re-invoke"));
            Assert.That(ResponseRecoveryPayload.DispositionMarkFailed, Is.EqualTo("mark-failed"));
        });
    }
}
