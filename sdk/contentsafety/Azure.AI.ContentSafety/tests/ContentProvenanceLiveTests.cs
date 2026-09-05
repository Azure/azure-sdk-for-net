// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.AI.ContentSafety.Tests
{
    public class ContentProvenanceLiveTests : RecordedTestBase<ContentSafetyClientTestEnvironment>
    {
        public ContentProvenanceLiveTests(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");

            // The media are blob SAS URIs; replace each wholesale so no SAS or storage account is recorded.
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"https://[^""]*?/provenance-test/[^""?]*bound\.png[^""]*")
            {
                Value = ContentSafetyClientTestEnvironment.SignedMediaPlaceholder
            });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"https://[^""]*?/provenance-test/[^""?]*testImage\.png[^""]*")
            {
                Value = ContentSafetyClientTestEnvironment.UnsignedMediaPlaceholder
            });
        }

        private ContentProvenanceClient CreateContentProvenanceClient()
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var credential = new AzureKeyCredential(TestEnvironment.Key);
            return InstrumentClient(new ContentProvenanceClient(endpoint, credential, InstrumentClientOptions(new ContentSafetyClientOptions())));
        }

        [RecordedTest]
        public async Task DetectProvenanceInSignedMedia()
        {
            var client = CreateContentProvenanceClient();
            var options = new DetectProvenanceOptions(new ProvenanceContent(new Uri(TestEnvironment.SignedMediaUri)));

            Operation<DetectProvenanceResult> operation = await client.DetectAsync(WaitUntil.Completed, options);

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(DetectOutcome.ProvenanceDetected, operation.Value.Outcome);
            Assert.IsNotEmpty(operation.Value.Results);
            foreach (DetectedProvenance detected in operation.Value.Results)
            {
                Assert.Contains(detected.Type, new[] { DetectedProvenanceType.C2PA, DetectedProvenanceType.Watermark });
                Assert.IsNotEmpty(detected.Provider);
                Assert.IsNotEmpty(detected.ModelName);
            }
        }

        [RecordedTest]
        public async Task DetectNoProvenanceInUnsignedMedia()
        {
            var client = CreateContentProvenanceClient();
            var options = new DetectProvenanceOptions(new ProvenanceContent(new Uri(TestEnvironment.UnsignedMediaUri)));

            Operation<DetectProvenanceResult> operation = await client.DetectAsync(WaitUntil.Completed, options);

            Assert.IsTrue(operation.HasValue);
            Assert.AreEqual(DetectOutcome.NoProvenanceDetected, operation.Value.Outcome);
            Assert.IsEmpty(operation.Value.Results);
        }
    }
}
