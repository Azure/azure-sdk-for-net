// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
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
            var rehydrated = OperationIdClientAnalyzeOperation.FromRehydrationToken(client.Pipeline, token);
            Assert.AreEqual("analysis-123", rehydrated.Id);
            await rehydrated.UpdateStatusAsync();
            await rehydrated.UpdateStatusAsync();
            Assert.IsTrue(rehydrated.HasCompleted);
            Assert.AreEqual("analysis-123", rehydrated.Id);
            Assert.IsNotEmpty(rehydrated.Value.Summary);
        });

        [SpectorTest]
        public Task StartTranslation() => Test(async host =>
        {
            var operation = await new OperationIdClient(host, null).StartTranslationAsync(WaitUntil.Started);
            Assert.AreEqual("NOT_SET", operation.Id);
            await operation.UpdateStatusAsync();
            Assert.AreEqual("translation-123", operation.Id);
            await operation.UpdateStatusAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual("translation-123", operation.Id);
            Assert.Greater(operation.Value.TranslatedCharacters, 0);
        });

        [SpectorTest]
        public Task StartTranslationWithPath() => Test(async host =>
        {
            var operation = await new OperationIdClient(host, null).StartTranslationWithPathAsync(WaitUntil.Started);
            Assert.IsTrue(operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var pollingUri));
            StringAssert.Contains("/translations/operations/translation-456", pollingUri);
            Assert.AreEqual("translation-456", operation.Id);
            await operation.UpdateStatusAsync();
            Assert.AreEqual("translation-456", operation.Id);
            await operation.UpdateStatusAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual("translation-456", operation.Id);
            Assert.Greater(operation.Value.TranslatedCharacters, 0);
        });
    }
}
