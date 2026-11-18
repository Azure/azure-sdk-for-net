// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.Lro.OperationId;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.Lro.OperationId
{
    public class LroOperationIdTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Analyze() => Test(async host =>
        {
            var client = new OperationIdClient(host, null);
            var operation = await client.AnalyzeAsync(WaitUntil.Started, "document-1");
            Assert.AreEqual("analysis-123", operation.Id);
            var token = operation.GetRehydrationToken() ?? throw new InvalidOperationException("The operation must be resumable.");
            var rehydrated = OperationIdClient.RehydrateAnalyzeOperation(client.Pipeline, token);
            Assert.AreEqual("analysis-123", rehydrated.Id);
            await rehydrated.UpdateStatusAsync();
            Assert.IsTrue(rehydrated.HasCompleted);
            Assert.AreEqual("analysis-123", rehydrated.Id);
            Assert.IsNotEmpty(rehydrated.Value.Summary);
        });

        [SpectorTest]
        public Task AnalyzeSynchronouslyToCompletion() => Test(host =>
        {
            var operation = new OperationIdClient(host, null).Analyze(WaitUntil.Completed, "document-1");
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual("analysis-123", operation.Id);
            Assert.IsNotEmpty(operation.Value.Summary);
            return Task.CompletedTask;
        });

        [SpectorTest]
        public Task StartTranslation() => Test(async host =>
        {
            var client = new OperationIdClient(host, null);
            var operation = await client.StartTranslationAsync(WaitUntil.Started);
            Assert.AreEqual("NOT_SET", operation.Id);
            var token = operation.GetRehydrationToken() ?? throw new InvalidOperationException("The operation must be resumable.");
            var rehydrated = OperationIdClient.RehydrateStartTranslationOperation(client.Pipeline, token);
            Assert.AreEqual("translation-123", rehydrated.Id);
            await rehydrated.UpdateStatusAsync();
            Assert.IsTrue(rehydrated.HasCompleted);
            Assert.AreEqual("translation-123", rehydrated.Id);
            Assert.Greater(rehydrated.Value.TranslatedCharacters, 0);
        });

        [SpectorTest]
        public Task StartTranslationProtocolRehydration() => Test(async host =>
        {
            var client = new OperationIdClient(host, null);
            var operation = await client.StartTranslationAsync(WaitUntil.Started, new RequestContext());
            var token = operation.GetRehydrationToken() ?? throw new InvalidOperationException("The operation must be resumable.");
            var rehydrated = OperationIdClient.RehydrateStartTranslationRawOperation(client.Pipeline, token);
            Assert.AreEqual("translation-123", rehydrated.Id);
            await rehydrated.UpdateStatusAsync();
            Assert.IsTrue(rehydrated.HasCompleted);
            Assert.AreEqual("translation-123", rehydrated.Id);
        });

        [SpectorTest]
        public Task StartTranslationWithPath() => Test(async host =>
        {
            var client = new OperationIdClient(host, null);
            var operation = await client.StartTranslationWithPathAsync(WaitUntil.Started);
            Assert.IsTrue(operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var pollingUri));
            StringAssert.Contains("/translations/operations/translation-456", pollingUri);
            Assert.AreEqual("translation-456", operation.Id);
            var token = operation.GetRehydrationToken() ?? throw new InvalidOperationException("The operation must be resumable.");
            var rehydrated = OperationIdClient.RehydrateStartTranslationWithPathOperation(client.Pipeline, token);
            Assert.AreEqual("translation-456", rehydrated.Id);
            await rehydrated.UpdateStatusAsync();
            Assert.IsTrue(rehydrated.HasCompleted);
            Assert.AreEqual("translation-456", rehydrated.Id);
            Assert.Greater(rehydrated.Value.TranslatedCharacters, 0);
        });
    }
}
