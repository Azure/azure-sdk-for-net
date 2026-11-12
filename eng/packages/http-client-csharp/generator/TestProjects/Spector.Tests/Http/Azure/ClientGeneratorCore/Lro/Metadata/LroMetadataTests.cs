// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.Lro.Metadata;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.Lro.Metadata
{
    public class LroMetadataTests : SpectorTestBase
    {
        [SpectorTest]
        public Task AnalyzeWithUsage() => Test(async host =>
        {
            var operation = await new MetadataClient(host, null).AnalyzeWithUsageAsync(WaitUntil.Started, "analyzer-1");
            var metadata = operation.Metadata;
            Assert.IsNull(metadata.Usage);
            await operation.UpdateStatusAsync();
            Assert.AreEqual(1, metadata.Usage.DocumentPagesBasic);
            Assert.AreEqual(10, metadata.Usage.Tokens["input"]);
            await operation.UpdateStatusAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(4, metadata.Usage.Tokens["output"]);
            Assert.AreEqual("The document contains three sections.", operation.Value.Contents);
        });

        [SpectorTest]
        public Task AnalyzeJob() => Test(async host =>
        {
            var client = new MetadataClient(host, null);
            var operation = await client.AnalyzeJobAsync(WaitUntil.Started);
            Assert.AreEqual("NOT_SET", operation.Id);
            Assert.AreEqual("job-success", operation.Metadata.JobId);
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:00:00Z"), operation.Metadata.CreatedOn);
            Assert.IsNull(operation.Metadata.Statistics);
            Assert.IsNull(operation.Metadata.Errors);
            var token = operation.GetRehydrationToken() ?? throw new InvalidOperationException("The operation must be resumable.");
            var rehydrated = MetadataClientAnalyzeJobOperation.FromRehydrationToken(client.Pipeline, token);
            var metadata = rehydrated.Metadata;
            Assert.IsNull(metadata.JobId);
            Assert.IsNull(metadata.CreatedOn);
            await rehydrated.UpdateStatusAsync();
            Assert.AreEqual(1, metadata.Statistics.Succeeded);
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:01:00Z"), metadata.LastUpdatedOn);
            await rehydrated.UpdateStatusAsync();
            Assert.AreEqual(3, metadata.Statistics.Succeeded);
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:02:00Z"), metadata.LastUpdatedOn);
            Assert.IsEmpty(metadata.Errors);
            Assert.AreEqual(3, rehydrated.Value.Documents.Count);
        });

        [SpectorTest]
        public Task AnalyzeJobWithFailure() => Test(async host =>
        {
            var operation = await new MetadataClient(host, null).AnalyzeJobWithFailureAsync(WaitUntil.Started);
            var metadata = operation.Metadata;
            await operation.UpdateStatusAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(2, metadata.Statistics.Failed);
            Assert.AreEqual(2, metadata.Errors.Count);
            Assert.AreEqual("document-2", metadata.Errors[0].Target);
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:02:00Z"), metadata.LastUpdatedOn);
        });
    }
}
