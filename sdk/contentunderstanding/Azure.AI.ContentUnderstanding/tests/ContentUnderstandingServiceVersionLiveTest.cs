// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    [ClientTestFixture(
        ContentUnderstandingClientOptions.ServiceVersion.V2025_11_01,
        ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview,
        RecordingServiceVersion = ContentUnderstandingClientOptions.ServiceVersion.V2025_11_01)]
    public class ContentUnderstandingServiceVersionLiveTest : RecordedTestBase<ContentUnderstandingClientTestEnvironment>
    {
        private readonly ContentUnderstandingClientOptions.ServiceVersion _serviceVersion;

        public ContentUnderstandingServiceVersionLiveTest(
            bool isAsync,
            ContentUnderstandingClientOptions.ServiceVersion serviceVersion)
            : base(isAsync)
        {
            _serviceVersion = serviceVersion;
            ContentUnderstandingTestBase.ConfigureCommonSanitizers(this);
        }

        private static void AssertCapturedServiceVersion(ApiVersionCapturePolicy apiVersionCapturePolicy, string expectedApiVersion)
        {
            Assert.That(apiVersionCapturePolicy.CapturedApiVersions, Is.Not.Empty, "Expected at least one request to be captured.");
            Assert.That(apiVersionCapturePolicy.CapturedApiVersions, Has.All.EqualTo(expectedApiVersion));
        }

        [LiveOnly]
        [Test]
        public async Task GetDefaultsSupportsConfiguredServiceVersion()
        {
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions(_serviceVersion));
            var client = InstrumentClient(new ContentUnderstandingClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                options));

            Response<ContentUnderstandingDefaults> response = await client.GetDefaultsAsync();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [LiveOnly]
        [Test]
        [ServiceVersion(Max = ContentUnderstandingClientOptions.ServiceVersion.V2025_11_01)]
        public async Task AnalyzeBinarySupportsGaServiceVersion()
        {
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions(_serviceVersion));
            var client = InstrumentClient(new ContentUnderstandingClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                options));

            Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                ContentUnderstandingClientTestEnvironment.CreateBinaryData("sample_invoice.pdf"));

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsNotNull(operation.Value);
            Assert.IsNotEmpty(operation.Value.Contents);
        }

        [LiveOnly]
        [Test]
        [ServiceVersion(Min = ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
        public async Task AnalyzeInlineSupportsPreviewServiceVersion()
        {
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions(_serviceVersion));
            var client = InstrumentClient(new ContentUnderstandingClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                options));

            Response<AnalysisResult> response = await client.AnalyzeInlineAsync(
                "prebuilt-layout",
                new[] { new AnalysisInput { Uri = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf") } });

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
        }

        [LiveOnly]
        [Test]
        [ServiceVersion(Max = ContentUnderstandingClientOptions.ServiceVersion.V2025_11_01)]
        public async Task DefaultClientOptionsUseLatestPreviewServiceVersion()
        {
            const string expectedApiVersion = "2026-06-01-preview";
            ApiVersionCapturePolicy apiVersionCapturePolicy = new();
            ContentUnderstandingClientOptions options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            options.AddPolicy(apiVersionCapturePolicy, HttpPipelinePosition.PerCall);
            ContentUnderstandingClient client = InstrumentClient(new ContentUnderstandingClient(
                new Uri(TestEnvironment.Endpoint),
                TestEnvironment.Credential,
                options));
            BinaryData binaryData = ContentUnderstandingClientTestEnvironment.CreateBinaryData("sample_invoice.pdf");

            Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                binaryData);
            Response<AnalysisResult> inlineResponse = await client.AnalyzeBinaryInlineAsync("prebuilt-layout", binaryData);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value, Is.Not.Null);
            Assert.That(operation.Value.ApiVersion, Is.EqualTo(expectedApiVersion));
            Assert.That(inlineResponse.Value, Is.Not.Null);
            Assert.That(inlineResponse.Value.ApiVersion, Is.EqualTo(expectedApiVersion));
            AssertCapturedServiceVersion(apiVersionCapturePolicy, expectedApiVersion);
        }

        private sealed class ApiVersionCapturePolicy : HttpPipelinePolicy
        {
            public IList<string> CapturedApiVersions { get; } = new List<string>();

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                CaptureApiVersion(message);
                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                CaptureApiVersion(message);
                return ProcessNextAsync(message, pipeline);
            }

            private void CaptureApiVersion(HttpMessage message)
            {
                Uri requestUri = message.Request.Uri.ToUri();
                string query = requestUri.Query.TrimStart('?');
                foreach (string segment in query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] pair = segment.Split(new[] { '=' }, 2);
                    if (pair.Length == 2 && pair[0] == "api-version")
                    {
                        CapturedApiVersions.Add(Uri.UnescapeDataString(pair[1]));
                    }
                }
            }
        }
    }
}
