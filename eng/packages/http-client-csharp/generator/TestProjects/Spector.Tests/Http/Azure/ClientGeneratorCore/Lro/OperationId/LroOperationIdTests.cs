// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var operation = await new OperationIdClient(host, null).AnalyzeAsync(WaitUntil.Started, "document-1");
            Assert.AreEqual("analysis-123", operation.Id);
            await operation.WaitForCompletionAsync();
            Assert.AreEqual("analysis-123", operation.Id);
            Assert.IsNotEmpty(operation.Value.Summary);
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
            var operation = await new OperationIdClient(host, null).StartTranslationAsync(WaitUntil.Started);
            Assert.AreEqual("NOT_SET", operation.Id);
            await operation.WaitForCompletionAsync();
            Assert.AreEqual("translation-123", operation.Id);
            Assert.Greater(operation.Value.TranslatedCharacters, 0);
        });

        [SpectorTest]
        public Task StartTranslationProtocol() => Test(async host =>
        {
            var operation = await new OperationIdClient(host, null).StartTranslationAsync(WaitUntil.Completed, new RequestContext());
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual("translation-123", operation.Id);
        });

        [SpectorTest]
        public Task StartTranslationWithPath() => Test(async host =>
        {
            var operation = await new OperationIdClient(host, null).StartTranslationWithPathAsync(WaitUntil.Started);
            Assert.IsTrue(operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var pollingUri));
            StringAssert.Contains("/translations/operations/translation-456", pollingUri);
            Assert.AreEqual("translation-456", operation.Id);
            await operation.WaitForCompletionAsync();
            Assert.AreEqual("translation-456", operation.Id);
            Assert.Greater(operation.Value.TranslatedCharacters, 0);
        });
    }
}
