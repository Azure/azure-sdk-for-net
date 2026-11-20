// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using NUnit.Framework;
using Specs.Azure.ClientGenerator.Core.Lro.Metadata;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.Lro.Metadata
{
    public class LroMetadataTests : SpectorTestBase
    {
        private static Type GetOperationType(string name)
            => typeof(MetadataClient).Assembly.GetType($"Specs.Azure.ClientGenerator.Core.Lro.Metadata.{name}", throwOnError: true)!;

        [Test]
        public void OperationTypesAreInternal()
        {
            foreach (var name in new[] { "AnalyzeWithUsageOperation", "AnalyzeJobOperation", "AnalyzeJobWithFailureOperation" })
            {
                Assert.IsFalse(GetOperationType(name).IsPublic, name);
            }
            Assert.AreEqual(typeof(Operation<LanguageJobResult>), typeof(MetadataClient).GetMethod("AnalyzeJob", [typeof(WaitUntil), typeof(CancellationToken)])!.ReturnType);
        }

        [Test]
        public void MalformedAndMissingMetadataReturnsNull()
        {
            foreach (var json in new[] { "not json", """{"jobId":42}""", """{"status":"Running"}""" })
            {
                using var response = new MetadataResponse(json);
                var operation = CreateAnalyzeJobOperation(() => response);
                Assert.IsNull(GetProperty(operation, "JobId"), json);
                Assert.IsNull(GetProperty(operation, "Statistics"), json);
                Assert.IsNull(GetProperty(operation, "Errors"), json);
                // CreatedOn is a required DateTimeOffset, which the deserializer would otherwise default when absent.
                Assert.IsNull(GetProperty(operation, "CreatedOn"), json);
            }
            using var partial = new MetadataResponse("""{"jobId":"job","lastUpdatedDateTime":"2025-01-01T10:01:00Z"}""");
            var withoutCreatedOn = CreateAnalyzeJobOperation(() => partial);
            Assert.AreEqual("job", GetProperty(withoutCreatedOn, "JobId"));
            Assert.IsNull(GetProperty(withoutCreatedOn, "CreatedOn"));
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:01:00Z"), GetProperty(withoutCreatedOn, "LastUpdatedOn"));
        }

        [Test]
        public void MetadataDeserializesEachMonitorResponseOnce()
        {
            using var first = new MetadataResponse("""{"jobId":"first","createdDateTime":"2025-01-01T10:00:00Z","status":"Running"}""");
            using var second = new MetadataResponse("""{"jobId":"second","createdDateTime":"2025-01-01T10:00:00Z","status":"Running","statistics":{"succeeded":1,"failed":0,"total":3}}""");
            var current = first;
            var operation = CreateAnalyzeJobOperation(() => current);

            Assert.AreEqual("first", GetProperty(operation, "JobId"));
            // Removing the content proves later getters reuse the model deserialized from this response.
            first.ContentStream = null;
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:00:00Z"), GetProperty(operation, "CreatedOn"));

            current = second;
            Assert.AreEqual("second", GetProperty(operation, "JobId"));
            Assert.AreEqual(1, ((JobStatistics)GetProperty(operation, "Statistics")!).Succeeded);
        }

        [SpectorTest]
        public Task AnalyzeWithUsage() => Test(async host =>
        {
            var operation = await new MetadataClient(host, null).AnalyzeWithUsageAsync(WaitUntil.Started, "analyzer-1");
            Assert.AreEqual(GetOperationType("AnalyzeWithUsageOperation"), operation.GetType());
            Assert.IsNull(GetProperty(operation, "Usage"));
            await operation.UpdateStatusAsync();
            var usage = (UsageDetails)GetProperty(operation, "Usage")!;
            Assert.AreEqual(1, usage.DocumentPagesBasic);
            Assert.AreEqual(10, usage.Tokens["input"]);
            await operation.UpdateStatusAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(4, ((UsageDetails)GetProperty(operation, "Usage")!).Tokens["output"]);
            Assert.AreEqual("The document contains three sections.", operation.Value.Contents);
        });

        [SpectorTest]
        public Task AnalyzeJobSynchronouslyToCompletion() => Test(host =>
        {
            var operation = new MetadataClient(host, null).AnalyzeJob(WaitUntil.Completed);
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(3, ((JobStatistics)GetProperty(operation, "Statistics")!).Succeeded);
            Assert.AreEqual(3, operation.Value.Documents.Count);
            return Task.CompletedTask;
        });

        [SpectorTest]
        public Task AnalyzeJob() => Test(async host =>
        {
            var operation = await new MetadataClient(host, null).AnalyzeJobAsync(WaitUntil.Started);
            Assert.AreEqual("job-success", GetProperty(operation, "JobId"));
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:00:00Z"), GetProperty(operation, "CreatedOn"));
            Assert.IsNull(GetProperty(operation, "Statistics"));
            Assert.IsNull(GetProperty(operation, "Errors"));
            var token = operation.GetRehydrationToken();

            await operation.UpdateStatusAsync();
            Assert.AreEqual(1, ((JobStatistics)GetProperty(operation, "Statistics")!).Succeeded);
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:01:00Z"), GetProperty(operation, "LastUpdatedOn"));
            await operation.UpdateStatusAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(3, ((JobStatistics)GetProperty(operation, "Statistics")!).Succeeded);
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:02:00Z"), GetProperty(operation, "LastUpdatedOn"));
            Assert.IsEmpty((IList<JobItemError>)GetProperty(operation, "Errors")!);
            Assert.AreEqual(3, operation.Value.Documents.Count);
            Assert.AreEqual(token.ToString(), operation.GetRehydrationToken().ToString());
        });

        [SpectorTest]
        public Task AnalyzeJobWithFailure() => Test(async host =>
        {
            var operation = await new MetadataClient(host, null).AnalyzeJobWithFailureAsync(WaitUntil.Started);
            await operation.UpdateStatusAsync();
            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.UpdateStatusAsync());
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual(2, ((JobStatistics)GetProperty(operation, "Statistics")!).Failed);
            var errors = (IList<JobItemError>)GetProperty(operation, "Errors")!;
            Assert.AreEqual(2, errors.Count);
            Assert.AreEqual("document-2", errors[0].Target);
            Assert.AreEqual(DateTimeOffset.Parse("2025-01-01T10:02:00Z"), GetProperty(operation, "LastUpdatedOn"));
        });

        private static object CreateAnalyzeJobOperation(Func<Response> getStatusMonitorResponse)
            => Activator.CreateInstance(GetOperationType("AnalyzeJobOperation"), BindingFlags.Instance | BindingFlags.NonPublic, null,
                [null, getStatusMonitorResponse], null)!;

        private sealed class MetadataResponse : Response
        {
            public MetadataResponse(string content) => ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            public override int Status => 200;
            public override string ReasonPhrase => "OK";
            public override Stream? ContentStream { get; set; }
            public override string ClientRequestId { get; set; } = string.Empty;
            public override void Dispose() => ContentStream?.Dispose();
            protected override bool ContainsHeader(string name) => false;
            protected override IEnumerable<HttpHeader> EnumerateHeaders() => Array.Empty<HttpHeader>();
            protected override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value) { value = null; return false; }
            protected override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values) { values = null; return false; }
        }
    }
}
